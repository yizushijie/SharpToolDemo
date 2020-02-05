using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Harry.LabTools.LabCommPort
{
	public partial class CSerialPort
	{
		#region 变量定义

		/// <summary>
		/// 使用的串口类
		/// </summary>
		private SerialPort defaultSerialPort = new SerialPort();
		/// <summary>
		/// 设备信息
		/// </summary>
		private string defaultSerialInfo = string.Empty;
		/// <summary>
		/// 超时时间，单位是ms
		/// </summary>
		private int defaultSerialTimeout = 200;
		/// <summary>
		/// 是不是复合命令
		/// </summary>
		private bool defaultSerialMultiCMD = false;
		/// <summary>
		/// 信息提示
		/// </summary>
		private string defaultSerialMsg = string.Empty;
		/// <summary>
		/// 工作状态
		/// </summary>
		private CCOMM_STATE defaultSerialSTATE = CCOMM_STATE.STATE_IDLE;
		/// <summary>
		/// 串口参数
		/// </summary>
		private CSerialPortParam defaultSerialPortParam = new CSerialPortParam();
		/// <summary>
		/// 使用的时间
		/// </summary>
		private TimeSpan defaultSerialUsedTime;
        /// <summary>
        /// 设备连接状态 true---连接，false---断开
        /// </summary>
        private bool defaultConnected = false;
		/// <summary>
		/// 设备是否发生变化,TRUE---发生变化，FALSE---未变化
		/// </summary>
		private bool defaultChanged = false;
		/// <summary>
		/// 是否显示全部参数
		/// </summary>
		private bool defaultFullParam = true;
		/// <summary>
		/// 每包传输数据的字节数
		/// </summary>
		private int defaultPerPackageMaxSize = 64;

		#endregion

		#region 公共属性

		/// <summary>
		/// 使用的通讯端口
		/// </summary>
		public override CCOMM_TYPE mCOMMType
		{
			get
			{
				return CCOMM_TYPE.COMM_SERIAL;
			}
			set
			{
				base.mCOMMType = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public override string mCOMMName
		{
			get
			{
				return this.defaultSerialPort.PortName;
			}
			set
			{
				if (this.defaultSerialPort.PortName!=value)
				{
					if (this.defaultSerialPort.IsOpen)
					{
						try
						{
							this.defaultSerialPort.Close();
						}
						catch (Exception)
						{
							//---清理资源
							this.defaultSerialPort.Dispose();
						}
						
					}
				}
				if(string.IsNullOrEmpty(value))
				{
					this.defaultSerialPort.PortName = "COM1";
				}
				else
				{
					this.defaultSerialPort.PortName = value;
				}
				this.defaultSerialPortParam.mName = this.defaultSerialPort.PortName;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public override int mCOMMIndex
		{
			get
			{
				if(string.IsNullOrEmpty(this.mCOMMName))
				{
					return 0;
				}
				else
				{
					return int.Parse(Regex.Replace(this.mCOMMName, @"[^\d]*", ""));
				}
			}
			set
			{
				this.mCOMMName = "COM" + value.ToString();
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public override string mCOMMInfo
		{
			get
			{
				return this.defaultSerialInfo;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public override int mTimeout
		{
			get
			{
				return this.defaultSerialTimeout;
			}
			set
			{
				this.defaultSerialTimeout = value;
			}
		}

		/// <summary>
		/// 读取超时时间
		/// </summary>
		public override int mCOMMReadTimeout
		{
			get
			{
				return this.defaultSerialPort.ReadTimeout;
			}
			set
			{
				this.defaultSerialPort.ReadTimeout = value;
			}
		}

		/// <summary>
		/// 写入超时
		/// </summary>
		public override int mCOMMWriteTimeout
		{
			get
			{
				return this.defaultSerialPort.WriteTimeout;
			}
			set
			{
				this.defaultSerialPort.WriteTimeout = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public override int mCOMMInfiniteTimeout
		{
			get
			{
				return 200;
			}
		}

		/// <summary>
		/// 多地址通信
		/// </summary>
		public override bool mChildAddr
		{
			get
			{
				return ((this.defaultSerialPortParam!=null)&&(defaultSerialPortParam.mAddrID>0));
			}
		}

		/// <summary>
		/// 是不是复合命令
		/// </summary>
		public override bool mChildCMD
		{
			get
			{
				return this.defaultSerialMultiCMD;
			}
			set
			{
				this.defaultSerialMultiCMD = value;
			}
		}


		/// <summary>
		/// 端口是否打开
		/// </summary>
		public override bool mCOMMOpen
		{
			get
			{
				if (this.defaultSerialPort==null)
				{
					return false;
				}
				else
				{
					return this.defaultSerialPort.IsOpen;
				}
			}
		}

		/// <summary>
		/// 消息Log信息
		/// </summary>
		public override string mLogMsg
		{
			get
			{
				return this.defaultSerialMsg;
			}
		}

		/// <summary>
		/// 通讯状态
		/// </summary>
		public override CCOMM_STATE mCOMMSTATE
		{
			get
			{
				return this.defaultSerialSTATE;
			}
		}


		/// <summary>
		/// 使用的时间
		/// </summary>
		public override TimeSpan mUsedTime
		{
			get
			{
				return this.defaultSerialUsedTime;
			}
		}

        /// <summary>
        /// 设备连接状态
        /// </summary>
        public override bool mCOMMConnected
        {
            get
            {
                return this.defaultConnected;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		public override bool mCOMMChanged
		{
			get
			{
				return this.defaultChanged;
			}
			set
			{
				this.defaultChanged = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public override bool mFullParam
		{
			get
			{
				return this.defaultFullParam;
			}
			set
			{
				this.defaultFullParam = value;
			}
		}

		/// <summary>
		/// 每包字节的大小
		/// </summary>
		public override int mPerPackageMaxSize
		{
			get
			{
				return this.defaultPerPackageMaxSize;
			}
			set
			{
				this.defaultPerPackageMaxSize = value;
				this.defaultSerialReceData.Init(value, false);
				this.defaultSerialSendData.Init(value, false);
			}
		}
		
		#endregion

		#region 串口属性

		/// <summary>
		/// 串口参数配置信息
		/// </summary>
		public override CSerialPortParam mSerialPortParam
		{
			get
			{
				if (this.defaultSerialPortParam==null)
				{
					this.defaultSerialPortParam = new CSerialPortParam();
				}
				return this.defaultSerialPortParam;
			}
			set
			{
                if (this.defaultSerialPortParam!=null)
                {
                    if ((value != null)&&(this.defaultSerialPortParam.mName!=value.mName))
                    {
                        this.CloseDevice(this.defaultSerialPortParam.mName);
                    }
					if (value!=null)
					{
						this.defaultSerialPortParam.AnalyseParam(value.mName, value.mBaudRate, value.mStopBits, value.mDataBits, value.mParity);
						//---波特率
						if (this.defaultSerialPort.BaudRate != int.Parse(this.defaultSerialPortParam.mBaudRate))
						{
							this.defaultSerialPort.BaudRate = int.Parse(this.defaultSerialPortParam.mBaudRate);
						}
						//---停止位
						if (this.defaultSerialPort.StopBits != this.GetStopBits(this.defaultSerialPortParam.mStopBits))
						{
							this.defaultSerialPort.StopBits = this.GetStopBits(this.defaultSerialPortParam.mStopBits);
						}
						//---数据位
						if (this.defaultSerialPort.DataBits != int.Parse(this.defaultSerialPortParam.mDataBits))
						{
							this.defaultSerialPort.DataBits = int.Parse(this.defaultSerialPortParam.mDataBits);
						}
						//---校验位
						if (this.defaultSerialPort.Parity != this.GetParityBits(this.defaultSerialPortParam.mParity))
						{
							this.defaultSerialPort.Parity = this.GetParityBits(this.defaultSerialPortParam.mParity);
						}						
					}
                }
				else
				{
					if (value!=null)
					{
						this.defaultSerialPortParam = new CSerialPortParam(value.mName, value.mBaudRate, value.mStopBits, value.mDataBits, value.mParity);
					}					
				}
                if (value!=null)
                {
                    this.mCOMMName = value.mName;
                }
            }
		}
		#endregion

		#region 构造函数

		#endregion

		#region 公有函数

		/// <summary>
		/// 初始化串口参数
		/// </summary>
		/// <param name="serialParam"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int Init(CSerialPortParam serialParam, RichTextBox msg = null)
		{
			return -1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="serialParam"></param>
		/// <param name="rxCRC"></param>
		/// <param name="tcCRC"></param>
		/// <param name="msg"></param>
		public override int Init(CSerialPortParam serialParam, CCOMM_CRC rxCRC, CCOMM_CRC txCRC, RichTextBox msg = null)
		{
			return -1;
		}

		#endregion

		#region 私有函数

		/// <summary>
		/// 获取校验位
		/// </summary>
		/// <param name="parityBits"></param>
		/// <returns></returns>
		private System.IO.Ports.Parity GetParityBits(string parityBits)
		{
			//---获取校验位
			System.IO.Ports.Parity _return;//= new Parity();

			//---奇校验
			if (parityBits.StartsWith("奇",System.StringComparison.CurrentCultureIgnoreCase) || parityBits.StartsWith("Odd", System.StringComparison.CurrentCultureIgnoreCase) || parityBits.StartsWith("ODD", System.StringComparison.CurrentCultureIgnoreCase) || parityBits.StartsWith("odd", System.StringComparison.CurrentCultureIgnoreCase) || parityBits.StartsWith("oDD", System.StringComparison.CurrentCultureIgnoreCase))
			{
				_return = System.IO.Ports.Parity.Odd;
			}

			//---偶校验
			else if (parityBits.StartsWith("偶", System.StringComparison.CurrentCultureIgnoreCase) || parityBits.StartsWith("Even", System.StringComparison.CurrentCultureIgnoreCase) || parityBits.StartsWith("EVEN", System.StringComparison.CurrentCultureIgnoreCase) || parityBits.StartsWith("even", System.StringComparison.CurrentCultureIgnoreCase) || parityBits.StartsWith("eVEN", System.StringComparison.CurrentCultureIgnoreCase))
			{
				_return = System.IO.Ports.Parity.Even;
			}

			//---无校验位
			else
			{
				_return = System.IO.Ports.Parity.None;
			}
			return _return;
		}

		/// <summary>
		/// 获取停止位
		/// </summary>
		/// <param name="stopBits"></param>
		/// <returns></returns>
		private StopBits GetStopBits(string stopBits)
		{
			//---获取校验位
			StopBits _return;// = new StopBits();
			try
			{
				double stopVal = Math.Truncate(Convert.ToDouble(stopBits));

				int temp = (int)(stopVal * 10);

				//---1位停止位
				if (temp == 10)
				{
					_return = System.IO.Ports.StopBits.One;
				}

				//---1.5位停止位
				else if (temp == 15)
				{
					_return = System.IO.Ports.StopBits.OnePointFive;
				}

				//---2位停止位
				else if (temp == 20)
				{
					_return = System.IO.Ports.StopBits.Two;
				}
				else
				{
					_return = System.IO.Ports.StopBits.None;
				}
			}
			catch
			{
				_return = System.IO.Ports.StopBits.None;
			}
			return _return;
		}

		#endregion

		#region 事件函数

		#endregion
	}
}