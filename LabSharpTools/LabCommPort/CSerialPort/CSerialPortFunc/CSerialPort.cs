using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Harry.LabTools.LabCommPort
{
	public partial class CSerialPort : CCommPort
	{
		#region 变量定义
	
		/// <summary>
		/// 设备索引列表，用于监控设备的拔插
		/// </summary>
		private List<byte> defaultSerialIndexMemu = new List<byte>();

		/// <summary>
		/// 设备驱动表
		/// </summary>
		private List<string> defaultSerialInfoMemu = new List<string>();

        #endregion

        #region 属性定义

        #endregion

        #region 构造函数

        /// <summary>
        /// 
        /// </summary>
        public CSerialPort() : base()
        {

        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cCommBase"></param>
		public CSerialPort(CCommPort cCommBase)
		{
			if (cCommBase!=null)
			{
				//---参数的分析
				base.AnalyseParam(cCommBase.mPerPackageMaxSize, cCommBase.mSerialPortParam, cCommBase.mUSBPortParam, cCommBase.mChildAddr);
			}			
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cbb"></param>
		/// <param name="msg"></param>
		public CSerialPort(ComboBox cbb = null, RichTextBox msg = null)
        {
            this.Init(cbb, msg);
        }
		
        #endregion

        #region 析构函数

        /// <summary>
        /// 
        /// </summary>
        ~CSerialPort()
		{
			this.Dispose();
		}

		/// <summary>
		/// 
		/// </summary>
		public override void Dispose()
		{
			base.Dispose();
			if (this.defaultSerialPort!=null)
			{
				this.defaultSerialPort.Dispose();
			}
			GC.SuppressFinalize(this);
		}

		#endregion

		#region 公有函数

		#endregion

		#region 保护函数

		#endregion

		#region 私有函数
		/// <summary>
		/// 接收8Bits长度的数据
		/// </summary>
		/// <param name="timeout"></param>
		/// <returns></returns>
		private int Analyse8BitsData(int timeout = 200)
		{
			int _return = -1;
			//---接收缓存区
			List<byte> cmd = new List<byte>();
			//---接收数据步序
			byte taskStep = 0;
			//---数据存储的临时变量
			int temp;
			//---通信端口为接收状态,不响应其他操作(阻塞操作)
			bool isWork = true;
			//---清空错误消息
			this.defaultSerialMsg = string.Empty;
			//---工作状态是忙碌
			this.defaultSerialSTATE = CCOMM_STATE.STATE_POLLREAD;
			// CRC的计算结果
			UInt32 crcVal = 0;
			//---时间计数器
			DateTime startTime = DateTime.Now;
			//---数据的读取---阻塞读取
			while (isWork)
			{
				switch (taskStep)
				{
					case 0:         //---获取数据报头
						if (this.defaultSerialPort.BytesToRead > 0)
						{
							temp = this.defaultSerialPort.ReadByte();
							//---读取报头
							if ((byte)temp == this.defaultSerialReceData.mID)
							{
								//---保存数据
								cmd.Add((byte)temp);
								//---进入下一任务
								taskStep = 1;
								//---重置时间标签
								startTime = DateTime.Now;
								//---进入数据接收状态
								_return = 0;
							}
						}
						break;
					case 1:         //---获取数据长度
						if (this.defaultSerialPort.BytesToRead > 0)
						{
							//---读取接收到的数据
							temp = this.defaultSerialPort.ReadByte();
							//---数据长度的合法性验证
							if ((temp > 0) && (temp < (this.defaultSerialReceData.mSize - 1)))
							{
								//---数据长度合法，接收数据长度
								cmd.Add((byte)temp);
								//---进入下一任务
								taskStep = 2;
								//---重置时间标签
								startTime = DateTime.Now;
							}
							else
							{
								//---数据长度不合法，重新接收数据
								cmd.Clear();
								taskStep = 0;
								//---重新进入数据接收状态
								_return = -2;
							}
						}
						break;
					case 2:         //---获取数据
						if (this.defaultSerialPort.BytesToRead > 0)
						{
							//---读取接收到的数据
							temp = this.defaultSerialPort.ReadByte();
							cmd.Add((byte)temp);
							//---重置时间标签
							startTime = DateTime.Now;
						}
						break;
					case 3:
					default:
						isWork = false;
						this.defaultSerialMsg = "接收数据的逻辑异常！";
						_return = 1;
						break;
				}
				//---计算时间
				TimeSpan endTime = DateTime.Now - startTime;
				//---判断是否发生超时错误
				if (endTime.TotalMilliseconds > (timeout+1))
				{
					//---退出while循环
					isWork = false;
					this.defaultSerialMsg += "接收数据发生超时错误！";
					_return = 2;
					break;
				}
				//---判断接收到的数据
				if ((_return == 0) && (taskStep == 2) && (cmd != null) && (cmd.Count > 2) && ((cmd.Count - 2) == cmd[1]))
				{
					//---退出当前while循环
					isWork = false;
					break;
				}
				//---响应其他应用
				Application.DoEvents();
			}
			//---判断接收的数据
			if ((_return == 0) && (taskStep == 2) && (isWork == false) && (cmd.Count > 2))
			{
				//---解析接收到的数据
				if (this.AnalyseReceData(cmd.ToArray()) == true)
				{
					//---校验CRC
					if ((this.defaultSerialReceData.mCRCMode == CCOMM_CRC.CRC_CHECKSUM) || (this.defaultSerialReceData.mCRCMode == CCOMM_CRC.CRC_CRC8))
					{
						crcVal = cmd[this.defaultSerialReceData.mLength];
					}
					else if (this.defaultSerialReceData.mCRCMode == CCOMM_CRC.CRC_CRC16)
					{
						crcVal = cmd[this.defaultSerialReceData.mLength];
						crcVal = (crcVal >> 8) + cmd[this.defaultSerialReceData.mLength + 1];
					}
					else if (this.defaultSerialReceData.mCRCMode == CCOMM_CRC.CRC_CRC32)
					{
						crcVal = cmd[this.defaultSerialReceData.mLength];
						crcVal = (crcVal >> 8) + cmd[this.defaultSerialReceData.mLength + 1];
						crcVal = (crcVal >> 8) + cmd[this.defaultSerialReceData.mLength + 2];
						crcVal = (crcVal >> 8) + cmd[this.defaultSerialReceData.mLength + 3];
					}
					if (this.defaultSerialReceData.mCRCMode != CCOMM_CRC.CRC_NONE)
					{
						if (this.defaultSerialReceData.mCRCVal != crcVal)
						{
							this.defaultSerialMsg += "接收数据发生CRC校验错误！";
							_return = 3;
						}
					}
				}
			}
			//---工作状态是空闲
			this.defaultSerialSTATE = CCOMM_STATE.STATE_IDLE;
			//---清空接收缓存区
			this.defaultSerialPort.DiscardInBuffer();
			//---清空发送缓存区
			this.defaultSerialPort.DiscardOutBuffer();
			return _return;
		}

		/// <summary>
		/// 接收16Bits长度的数据
		/// </summary>
		/// <param name="timeout"></param>
		/// <returns></returns>
		private int Analyse16BitsData(int timeout = 200)
		{
			int _return = 0;
			//---接收缓存区
			List<byte> cmd = new List<byte>();
			//---接收数据步序
			byte taskStep = 0;
			//---时间计数器
			DateTime startTime = DateTime.Now;
			//---数据存储的临时变量
			int temp = 0;
			int length = 0;
			//---通信端口为接收状态,不响应其他操作(阻塞操作)
			bool isWork = true;
			//---清空错误消息
			this.defaultSerialMsg = string.Empty;
			//---工作状态是忙碌
			this.defaultSerialSTATE = CCOMM_STATE.STATE_POLLREAD;
			// CRC的计算结果
			UInt32 crcVal = 0;
			//---数据的读取---阻塞读取
			while (isWork)
			{
				switch (taskStep)
				{
					case 0:         //---获取数据报头
						if (this.defaultSerialPort.BytesToRead > 0)
						{
							temp = this.defaultSerialPort.ReadByte();
							//---读取报头
							if ((byte)temp == this.defaultSerialReceData.mID)
							{
								//---保存数据
								cmd.Add((byte)temp);
								length = 0;
								//---接收数据长度高字节
								taskStep = 1;
								//---重置时间标签
								startTime = DateTime.Now;
								//---进入数据接收状态
								_return = 0;
							}
						}
						break;
					case 1:             //---获取数据长度高位
						if (this.defaultSerialPort.BytesToRead > 0)
						{
							temp = this.defaultSerialPort.ReadByte();
							//---保存数据
							cmd.Add((byte)temp);
							length = temp;
							length <<= 8;
							//---接收数据长度低字节
							taskStep = 2;
							//---重置时间标签
							startTime = DateTime.Now;
						}
						break;
					case 2:             //---获取数据长度低位
						if (this.defaultSerialPort.BytesToRead > 0)
						{
							//---读取接收到的数据
							temp = (temp << 8) + this.defaultSerialPort.ReadByte();
							//---数据长度的合法性验证
							if ((temp > 0) && (temp < (this.defaultSerialReceData.mSize - 1)))
							{
								//---数据长度合法，接收数据长度
								cmd.Add((byte)temp);
								length += temp;
								//---接收数据
								taskStep = 3;
								//---重置时间标签
								startTime = DateTime.Now;
							}
							else
							{
								//---数据长度不合法，重新接收数据
								cmd.Clear();
								taskStep = 0;
								//---重新进入数据接收状态
								_return = -2;
							}
						}
						break;
					case 3:         //---获取数据
						if (this.defaultSerialPort.BytesToRead > 0)
						{
							//---读取接收到的数据
							temp = this.defaultSerialPort.ReadByte();
							cmd.Add((byte)temp);
							//---重置时间标签
							startTime = DateTime.Now;
						}
						break;

					case 4:
					default:
						isWork = false;
						this.defaultSerialMsg = "接收数据的逻辑异常！";
						_return = 1;
						break;
				}

				//---计算时间
				TimeSpan endTime = DateTime.Now - startTime;
				//---判断是否发生超时错误
				if (endTime.TotalMilliseconds > timeout)
				{
					//---退出while循环
					isWork = false;
					this.defaultSerialMsg += "接收数据发生超市错误！";
					_return = 2;
					break;
				}

				//---判断接收到的数据
				if ((_return == 0) && (taskStep == 3) && (cmd != null) && (cmd.Count > 2))
				{
					if (length == (cmd.Count - 3))
					{
						//---退出当前while循环
						isWork = false;
						break;
					}
				}
				//---响应其他应用
				Application.DoEvents();
			}
			//---判断接收的数据
			if ((_return == 0) && (taskStep == 3) && (isWork == false) && (cmd.Count > 2))
			{
				//---解析接收到的数据
				if (this.AnalyseReceData(cmd.ToArray()) == true)
				{
					//---校验CRC
					if ((this.defaultSerialReceData.mCRCMode == CCOMM_CRC.CRC_CHECKSUM) || (this.defaultSerialReceData.mCRCMode == CCOMM_CRC.CRC_CRC8))
					{
						crcVal = cmd[this.defaultSerialReceData.mLength];
					}
					else if (this.defaultSerialReceData.mCRCMode == CCOMM_CRC.CRC_CRC16)
					{
						crcVal = cmd[this.defaultSerialReceData.mLength];
						crcVal = (crcVal >> 8) + cmd[this.defaultSerialReceData.mLength + 1];
					}
					else if (this.defaultSerialReceData.mCRCMode == CCOMM_CRC.CRC_CRC32)
					{
						crcVal = cmd[this.defaultSerialReceData.mLength];
						crcVal = (crcVal >> 8) + cmd[this.defaultSerialReceData.mLength + 1];
						crcVal = (crcVal >> 8) + cmd[this.defaultSerialReceData.mLength + 2];
						crcVal = (crcVal >> 8) + cmd[this.defaultSerialReceData.mLength + 3];
					}
					if (this.defaultSerialReceData.mCRCMode != CCOMM_CRC.CRC_NONE)
					{
						if (this.defaultSerialReceData.mCRCVal != crcVal)
						{
							this.defaultSerialMsg += "接收数据发生CRC校验错误！";
							_return = 3;
						}
					}
				}
			}
			//---工作状态是忙碌
			this.defaultSerialSTATE = CCOMM_STATE.STATE_IDLE;
			//---清空接收缓存区
			this.defaultSerialPort.DiscardInBuffer();
			//---清空发送缓存区
			this.defaultSerialPort.DiscardOutBuffer();
			return _return;
		}


		/// <summary>
		/// 获取串口的序号，并从小到大排列
		/// </summary>
		/// <param name="argNames"></param>
		/// <returns></returns>
		private List<byte>  GetSerialPortIndex(string[] argNames)
		{
			if ((argNames.Length == 0) || (argNames == null))
			{
				return null;
			}
			List<byte> temp = new List<byte>();
			List<byte> _return = new List<byte>();
			//---遍历端口信息
			for (int index = 0; index < argNames.Length; index++)
			{
				//---判断端口名称是否合法
				if (argNames[index].StartsWith("COM",System.StringComparison.CurrentCultureIgnoreCase) || argNames[index].StartsWith("com", System.StringComparison.CurrentCultureIgnoreCase))
				{
					//---去除字符串中非数字字符
					string str = Regex.Replace(argNames[index], @"[^\d]*", "");
					//---不获取COM1，一般为系统使用，不可被外部调用操作
					//if (str!="1")
					{
						//---将字符串转换成数字
						temp.Add((byte)(int.Parse(str)));
					}
				}
			}
			//---从到大小排列数据
			_return.AddRange((temp.ToArray().OrderBy(x => x).ToArray()));
			//---设置设备没有发生变化
			this.defaultChanged = false;
			//---检查是否发生设备变化
			if (this.defaultSerialIndexMemu.Count == 0)
			{
				this.defaultChanged = true;
			}
			else if (this.defaultSerialIndexMemu.Count > 0)
			{
				//---判断连个数组是否相等
				if (Enumerable.SequenceEqual(_return.ToArray(), this.defaultSerialIndexMemu.ToArray())!=true)
				{
					this.defaultChanged = true;
				}
			}
			//---返回测试结果
			return _return;
		}

		/// <summary>
		/// 获取设备的信息
		/// </summary>
		/// <param name="argNames"></param>
		/// <returns></returns>
		private List<string> GetSerialPortInfo(string[] argNames)
		{
			if ((argNames.Length == 0) || (argNames == null))
			{
				return null;
			}
			List<string> _return = new List<string>();
			int i ,j ;
			//---遍历端口信息
			for (i = 0; i < this.defaultSerialIndexMemu.Count; i++)
			{
				for (j = 0; j < argNames.Length; j++)
				{
					if (argNames[j].Contains("COM"+this.defaultSerialIndexMemu[i].ToString()))
					{
						_return.Add(argNames[j]);
						//---结束本次循环
						break;
					}
				}
			}
			//---返回测试结果
			return _return;
		}

		/// <summary>
		/// 获取串口设备的名称
		/// </summary>
		private bool GetSerialPortName()
		{
			bool _return = false;
			//---获取当前设备的端口
			string[] argNames = SerialPort.GetPortNames();
			//---获取端口的信息
			string[] argInfo = SystemHardware.GetSerialPort();
			if ((argNames==null)||(argNames.Length==0))
			{
				if (this.defaultSerialIndexMemu!=null)
				{
					this.defaultSerialIndexMemu.Clear();
				}
				if (this.defaultSerialInfoMemu != null)
				{
					this.defaultSerialInfoMemu.Clear();
				}
			}
			else
			{
				this.defaultSerialIndexMemu = this.GetSerialPortIndex(argNames);
				if ((this.defaultSerialIndexMemu != null)&&(this.defaultSerialIndexMemu.Count>0))
				{
					this.defaultSerialInfoMemu = this.GetSerialPortInfo(argInfo);
				}
				_return = true;
			}
			return _return;
		}

		#endregion
		
		#region 事件函数

		#endregion

	}

	#region 系统硬件

	internal class SystemHardware
	{
		#region 硬件类型枚举

		/// <summary>
		/// 枚举win32 api
		/// </summary>
		public enum HardwareEnum
		{
			//===硬件
			Win32_Processor,                                // CPU 处理器
			Win32_PhysicalMemory,                           // 物理内存条
			Win32_Keyboard,                                 // 键盘
			Win32_PointingDevice,                           // 点输入设备，包括鼠标。
			Win32_FloppyDrive,                              // 软盘驱动器
			Win32_DiskDrive,                                // 硬盘驱动器
			Win32_CDROMDrive,                               // 光盘驱动器
			Win32_BaseBoard,                                // 主板
			Win32_BIOS,                                     // BIOS 芯片
			Win32_ParallelPort,                             // 并口
			Win32_SerialPort,                               // 串口
			Win32_SerialPortConfiguration,                  // 串口配置
			Win32_SoundDevice,                              // 多媒体设置，一般指声卡。
			Win32_SystemSlot,                               // 主板插槽 (ISA & PCI & AGP)
			Win32_USBController,                            // USB 控制器
			Win32_NetworkAdapter,                           // 网络适配器
			Win32_NetworkAdapterConfiguration,              // 网络适配器设置
			Win32_Printer,                                  // 打印机
			Win32_PrinterConfiguration,                     // 打印机设置
			Win32_PrintJob,                                 // 打印机任务
			Win32_TCPIPPrinterPort,                         // 打印机端口
			Win32_POTSModem,                                // MODEM
			Win32_POTSModemToSerialPort,                    // MODEM 端口
			Win32_DesktopMonitor,                           // 显示器
			Win32_DisplayConfiguration,                     // 显卡
			Win32_DisplayControllerConfiguration,           // 显卡设置
			Win32_VideoController,                          // 显卡细节。
			Win32_VideoSettings,                            // 显卡支持的显示模式。

			//===操作系统
			Win32_TimeZone,                                 // 时区
			Win32_SystemDriver,                             // 驱动程序
			Win32_DiskPartition,                            // 磁盘分区
			Win32_LogicalDisk,                              // 逻辑磁盘
			Win32_LogicalDiskToPartition,                   // 逻辑磁盘所在分区及始末位置。
			Win32_LogicalMemoryConfiguration,               // 逻辑内存配置
			Win32_PageFile,                                 // 系统页文件信息
			Win32_PageFileSetting,                          // 页文件设置
			Win32_BootConfiguration,                        // 系统启动配置
			Win32_ComputerSystem,                           // 计算机信息简要
			Win32_OperatingSystem,                          // 操作系统信息
			Win32_StartupCommand,                           // 系统自动启动程序
			Win32_Service,                                  // 系统安装的服务
			Win32_Group,                                    // 系统管理组
			Win32_GroupUser,                                // 系统组帐号
			Win32_UserAccount,                              // 用户帐号
			Win32_Process,                                  // 系统进程
			Win32_Thread,                                   // 系统线程
			Win32_Share,                                    // 共享
			Win32_NetworkClient,                            // 已安装的网络客户端
			Win32_NetworkProtocol,                          // 已安装的网络协议
			Win32_PnPEntity,                                //all device
		}

		#endregion

		#region 静态公共函数

		/// <summary>
		/// 获取CPU序列号
		/// </summary>
		/// <returns></returns>
		public static string GetCPUSerialNumber()
		{
			try
			{
				ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_Processor");
				string sCPUSerialNumber = "";
				foreach (ManagementObject mo in searcher.Get())
				{
					sCPUSerialNumber = mo["ProcessorId"].ToString().Trim();
					break;
				}
				GC.SuppressFinalize(searcher);
				return sCPUSerialNumber;
			}
			catch(Exception e)
			{
				return e.ToString();
			}
		}

		/// <summary>
		/// 获取主板序列号
		/// </summary>
		/// <returns></returns>
		public static string GetBIOSSerialNumber()
		{
			try
			{
				ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_BIOS");
				string sBIOSSerialNumber = "";
				foreach (ManagementObject mo in searcher.Get())
				{
					sBIOSSerialNumber = mo.GetPropertyValue("SerialNumber").ToString().Trim();
					break;
				}
				GC.SuppressFinalize(searcher);
				return sBIOSSerialNumber;
			}
			catch
			{
				return "";
			}
		}

		/// <summary>
		/// 获取硬盘序列号
		/// </summary>
		/// <returns></returns>
		public static string GetHardDiskSerialNumber()
		{
			try
			{
				ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
				string sHardDiskSerialNumber = "";
				foreach (ManagementObject mo in searcher.Get())
				{
					sHardDiskSerialNumber = mo["SerialNumber"].ToString().Trim();
					break;
				}
				//---回收资源
				GC.SuppressFinalize(searcher);
				return sHardDiskSerialNumber;
			}
			catch
			{
				return "";
			}
		}



		/// <summary>
		/// 获取系统所有的串行设备
		/// </summary>
		/// <returns></returns>
		public static string[] GetSerialPort()
		{
			List<string> spList = new List<string>();
			Regex reg = new Regex(@"COM\d+");
			string[] strArr = SystemHardware.GetHarewareInfo(HardwareEnum.Win32_PnPEntity, "Name");
			foreach (string s in strArr)
			{
				if (reg.IsMatch(s))
				{
					spList.Add(s);
				}
			}

			return spList.ToArray();
		}

		/// <summary>
		/// 获取系统设备信息
		/// </summary>
		/// <param name="hardType"></param>
		/// <param name="propKey"></param>
		/// <returns></returns>
		public static string[] GetHarewareInfo(HardwareEnum hardType, string propKey)
		{

			List<string> strs = new List<string>();
			try
			{
				using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from " + hardType))
				{
					var hardInfos = searcher.Get();
					foreach (var hardInfo in hardInfos)
					{
						if (hardInfo.Properties[propKey].Value != null)
						{
							String str = hardInfo.Properties[propKey].Value.ToString();
							strs.Add(str);
						}

					}
				}
				return strs.ToArray();
			}
			catch
			{
				return null;
			}
		}

		#endregion
	}

	#endregion
}
