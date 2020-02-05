using Harry.LabTools.LabControlPlus;
using Harry.LabTools.LabGenFunc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;

namespace Harry.LabTools.LabCommPort
{
	public partial class CSerialPort
	{
		#region 变量定义
		
		/// <summary>
		/// 上一次的接收是不是错误，true---正常，false---异常
		/// </summary>
		private bool defaultLastRecePass = true;

		/// <summary>
		/// 是否注册过了接收事件,用于避免事件被多次重复注册，导致的多次调用
		/// true---已经注册，false---未注册
		/// </summary>
		private bool defaultHaveEventDataReceivedState = false;

		#endregion

		#region 属性定义

		#endregion

		#region 构造函数

		#endregion

		#region 公有函数
		/// <summary>
		/// 初始化设备
		/// </summary>
		/// <param name="cbb"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int Init(ComboBox cbb, RichTextBox msg = null)
		{
			int _return = -1;
			if (this.GetSerialPortName() == true)
			{
				if (cbb != null)
				{
					//---异步调用
					if (cbb.InvokeRequired)
					{
						cbb.BeginInvoke((EventHandler)
								 //cbb.Invoke((EventHandler)
								 (delegate
								 {
									 cbb.Items.Clear();
									 for (int i = 0; i < this.defaultSerialIndexMemu.Count; i++)
									 {
										 cbb.Items.Add("COM" + this.defaultSerialIndexMemu[i].ToString());
									 }
                                     //---当前端口在设备中索引
                                     _return = this.defaultSerialIndexMemu.IndexOf((byte)this.mCOMMIndex);
                                     if (_return < 0)
                                     {
                                         cbb.SelectedIndex = 0;
                                         _return = 0;
                                     }
                                     else
                                     {
                                         cbb.SelectedIndex = _return;
                                     }
                                 }));
					}
					else
					{
						cbb.Items.Clear();
						for (int i = 0; i < this.defaultSerialIndexMemu.Count; i++)
						{
							cbb.Items.Add("COM" + this.defaultSerialIndexMemu[i].ToString());
						}
                        //---当前端口在设备中索引
                        _return = this.defaultSerialIndexMemu.IndexOf((byte)this.mCOMMIndex);
                        if (_return<0)
                        {
                            cbb.SelectedIndex = 0;
                            _return = 0;
                        }
                        else
                        {
                            cbb.SelectedIndex = _return;
                        }
					}
					//---获取设备的驱动信息
					this.defaultSerialInfo = this.defaultSerialInfoMemu[_return];
					//---获取设备的名称信息
					this.mCOMMName = "COM" + this.defaultSerialIndexMemu[_return].ToString();
				}
				this.defaultSerialMsg = "端口刷新成功！";
				_return = 0;
			}
			else
			{
				if (cbb != null)
				{
					//---异步调用
					if (cbb.InvokeRequired)
					{
						cbb.BeginInvoke((EventHandler)
								 //cbb.Invoke((EventHandler)
								 (delegate
								 {
									 cbb.Items.Clear();
									 cbb.SelectedIndex = -1;
								 }));
					}
					else
					{
						cbb.Items.Clear();
						cbb.SelectedIndex = -1;
					}
				}
				this.defaultSerialMsg = "端口刷新失败！";
			}


          	this.mCCommComBox = cbb;
            this.mCCommRichTextBox = msg;
            //---添加端口监控函数
            this.AddWatcherCommEvent();

			if (msg != null)
			{
				CRichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.defaultSerialMsg, (_return == 0 ? Color.Black : Color.Red));
			}

			return _return;
		}

		/// <summary>
		/// 刷新设备
		/// </summary>
		/// <param name="cbb"></param>
		/// <param name="msg"></param>
		public override int RefreshDevice(ComboBox cbb, RichTextBox msg = null)
		{
			return this.Init(cbb,msg);
		}

		/// <summary>
		/// 设备插入
		/// </summary>
		/// <param name="cbb"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int InsertDevice()
		{
			int _return = 0;
			int portIndex = -1;
			//---获取当前设备存在的通信端口
			List<byte> addNames = this.GetSerialPortIndex(SerialPort.GetPortNames());
			//---检查设备端口
			if ((addNames == null) || (addNames.Count == 0))
			{
				if (this.defaultSerialIndexMemu!=null)
				{
					this.defaultSerialIndexMemu.Clear();
				}
				if (this.defaultSerialInfoMemu!=null)
				{
					this.defaultSerialInfoMemu.Clear();
				}
				if (this.mCCommComBox != null)
				{
					//---异步调用
					if (this.mCCommComBox.InvokeRequired)
					{
						this.mCCommComBox.BeginInvoke((EventHandler)
								 //cbb.Invoke((EventHandler)
								 (delegate
								 {
									 this.mCCommComBox.Items.Clear();
									 this.mCCommComBox.SelectedIndex = -1;
								 }));
					}
					else
					{
						this.mCCommComBox.Items.Clear();
						this.mCCommComBox.SelectedIndex = -1;
					}
				}
                _return = 1;
                this.defaultSerialMsg = "获取设备失败，请插入设备！";
			}
			else
			{
				
				int i = 0;
                this.defaultSerialMsg = "";
                //---遍历是哪个设备插入
                for (i = 0; i < addNames.Count; i++)
				{
					if ((this.defaultSerialIndexMemu != null) && (this.defaultSerialIndexMemu.Count > 0))
					{
						//---查询是哪个设备插入
						portIndex = this.defaultSerialIndexMemu.IndexOf(addNames[i]);
					}
					//---UI显示插入的设备
					if (portIndex < 0)
					{
                        this.defaultSerialMsg += "COM" + addNames[i].ToString() + "设备插入！";
					}
				}

				portIndex = -1;

				List<byte> addDevice = new List<byte>();

				//---获取当前选择的端口
				if (this.mCCommComBox != null)
				{
					//---异步调用
					if (this.mCCommComBox.InvokeRequired)
					{
						this.mCCommComBox.Invoke((EventHandler)
									 (delegate
									 {
										 portIndex = this.mCCommComBox.SelectedIndex;
									 }));
					}
					else
					{
						portIndex = this.mCCommComBox.SelectedIndex;
					}
				}

				if ((this.defaultSerialIndexMemu.Count != 0) && (portIndex >= 0))
				{
					portIndex = this.defaultSerialIndexMemu[portIndex];
				}

  				this.defaultSerialIndexMemu = new List<byte>();
				this.defaultSerialIndexMemu.AddRange(addNames.ToArray());

				if (this.defaultSerialIndexMemu.Count != 0)
				{
					if (portIndex < 0)
					{
						portIndex = 0;
					}
					else
					{
						portIndex = this.defaultSerialIndexMemu.IndexOf((byte)portIndex);
					}

				}

				if (this.mCCommComBox != null)
				{
					//---异步调用
					if (this.mCCommComBox.InvokeRequired)
					{
						this.mCCommComBox.BeginInvoke((EventHandler)
								 //cbb.Invoke((EventHandler)
								 (delegate
								 {
									 this.mCCommComBox.Items.Clear();
									 for (i = 0; i < this.defaultSerialIndexMemu.Count; i++)
									 {
										 this.mCCommComBox.Items.Add("COM" + this.defaultSerialIndexMemu[i].ToString());
									 }
									 this.mCCommComBox.SelectedIndex = portIndex;
								 }));
					}
					else
					{
						this.mCCommComBox.Items.Clear();
						for (i = 0; i < this.defaultSerialIndexMemu.Count; i++)
						{
							this.mCCommComBox.Items.Add("COM" + this.defaultSerialIndexMemu[i].ToString());
						}
						this.mCCommComBox.SelectedIndex = portIndex;
					}
				}
			}
			//---获取驱动信息
			this.defaultSerialInfoMemu = this.GetSerialPortInfo(SystemHardware.GetSerialPort());
			if ((this.defaultSerialInfoMemu!=null)&&(this.defaultSerialInfoMemu.Count>0)&&(this.defaultSerialInfoMemu.Count> portIndex))
			{
				this.defaultSerialInfo = this.defaultSerialInfoMemu[portIndex];
			}

            if (this.mCCommRichTextBox != null)
            {
                CRichTextBoxPlus.AppendTextInfoTopWithDataTime(this.mCCommRichTextBox, this.defaultSerialMsg,(_return==0?Color.Black:Color.Red));
            }
            return _return;
		}

		/// <summary>
		/// 设备移除
		/// </summary>
		/// <param name="cbb"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int RemoveDevice()
		{
			int _return = 0;
			//---获取当前设备存在的通信端口
			List<byte> addNames = this.GetSerialPortIndex(SerialPort.GetPortNames());
			if ((addNames == null) || (addNames.Count == 0))
			{
				this.defaultSerialIndexMemu = new List<byte>();
				if (this.mCCommComBox != null)
				{
					//---异步调用
					if (this.mCCommComBox.InvokeRequired)
					{
						this.mCCommComBox.BeginInvoke((EventHandler)
								 //cbb.Invoke((EventHandler)
								 (delegate
								 {
									 this.mCCommComBox.Items.Clear();
                                     this.mCCommComBox.Text = string.Empty;
                                     this.mCCommComBox.SelectedIndex = -1;
								 }));
					}
					else
					{
						this.mCCommComBox.Items.Clear();
                        this.mCCommComBox.Text = string.Empty;
                        this.mCCommComBox.SelectedIndex = -1;
					}
				}
                _return = 1;
                this.defaultSerialMsg = "获取设备失败，请插入设备！";
			}
			else
			{
				int portIndex = -1;
				int i = 0;
                this.defaultSerialMsg = "";
                //---遍历是哪个设备移除
                for (i = 0; i < this.defaultSerialIndexMemu.Count; i++)
				{
					//---查询是哪个设备移除
					portIndex = addNames.IndexOf(this.defaultSerialIndexMemu[i]);
					//---UI显示插入的设备
					if (portIndex < 0)
					{
                        //---判断是不是当前设备
						if (this.defaultSerialIndexMemu[i] == this.mCOMMIndex)
						{
							this.mCOMMName = "";
                            if (this.defaultConnected ==true)
                            {
                                if (this.defaultSerialPort!=null)
                                {
									//---注销事件接收函数
									if (this.defaultHaveEventDataReceivedState==true)
									{
										this.defaultSerialPort.DataReceived -= new SerialDataReceivedEventHandler(this.HandleDataReceivedEvent);
										this.defaultHaveEventDataReceivedState = false;
									}                                   
                                    //---释放资源
                                    this.defaultSerialPort.Dispose();
                                }
                            }
						}
                        _return = 2;
                        this.defaultSerialMsg += "COM" + this.defaultSerialIndexMemu[i].ToString() + "设备移除！";
					}
				}

				portIndex = -1;

				List<byte> addDevice = new List<byte>();

				//---获取当前使用的设备列表
				if (this.mCCommComBox != null)
				{
					//---异步调用
					if (this.mCCommComBox.InvokeRequired)
					{
						this.mCCommComBox.Invoke((EventHandler)
									 (delegate
									 {
										 portIndex = this.mCCommComBox.SelectedIndex;
									 }));
					}
					else
					{
						portIndex = this.mCCommComBox.SelectedIndex;
					}
				}

				if ((this.defaultSerialIndexMemu.Count != 0) && (portIndex >= 0))
				{
					portIndex = this.defaultSerialIndexMemu[portIndex];
				}

				if (this.defaultSerialIndexMemu==null)
				{
					this.defaultSerialIndexMemu = new List<byte>();
				}
				else
				{
					this.defaultSerialIndexMemu.Clear();
				}
				this.defaultSerialIndexMemu.AddRange(addNames.ToArray());

				if (this.defaultSerialIndexMemu.Count != 0)
				{
					if (portIndex < 0)
					{
                        //---默认选择第一个设备
						portIndex = 0;
					}
					else
					{
						portIndex = this.defaultSerialIndexMemu.IndexOf((byte)portIndex);
						if (portIndex < 0)
						{
                            //---默认选择第一个设备
                            portIndex = 0;
						}
					}
				}
                //---刷新设备
                if (this.mCCommComBox != null)
				{
					//---异步调用
					if (this.mCCommComBox.InvokeRequired)
					{
						this.mCCommComBox.BeginInvoke((EventHandler)
								 //cbb.Invoke((EventHandler)
								 (delegate
								 {
									 this.mCCommComBox.Items.Clear();
									 for (i = 0; i < this.defaultSerialIndexMemu.Count; i++)
									 {
										 this.mCCommComBox.Items.Add("COM" + this.defaultSerialIndexMemu[i].ToString());
									 }
									 this.mCCommComBox.SelectedIndex = portIndex;
								 }));
					}
					else
					{
						this.mCCommComBox.Items.Clear();
						for (i = 0; i < this.defaultSerialIndexMemu.Count; i++)
						{
							this.mCCommComBox.Items.Add("COM" + this.defaultSerialIndexMemu[i].ToString());
						}
						this.mCCommComBox.SelectedIndex = portIndex;
					}
				}
			}
			//---判断设备是否为空
			if (this.defaultSerialIndexMemu.Count == 0)
			{
				//---释放端口
				if ((this.defaultSerialPort != null) && (this.mCOMMIndex != 0))
				{
					//---端口状态，空闲
					this.defaultSerialSTATE = CCOMM_STATE.STATE_IDLE;
					//---关闭端口
					this.defaultSerialPort.Close();
                    //---释放串口资源
                    this.defaultSerialPort.Dispose();
					this.mCOMMName = string.Empty;
				}
			}
            if (this.mCCommRichTextBox != null)
            {
                CRichTextBoxPlus.AppendTextInfoTopWithDataTime(this.mCCommRichTextBox, this.defaultSerialMsg, (_return == 0 ? Color.Black : Color.Red));
            }
            return _return;
		}

		/// <summary>
		/// 向设备写入命令
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int WriteCmdToDevice(string cmd, RichTextBox msg = null)
		{
			int _return = -1;
			if ((this.defaultSerialPort != null) && (this.defaultSerialPort.IsOpen))
			{
				//---等待发送完成
				while (this.defaultSerialPort.BytesToWrite > 0)
				{
					//---响应窗体函数
					Application.DoEvents();
				}
				//---发送数据
				this.defaultSerialPort.WriteLine(cmd);
				_return = 0;
			}
			else
			{
				this.defaultSerialMsg = "端口：" + this.mCOMMName + "初始化异常！";
			}
			if ((msg != null) && (_return != 0))
			{
				CRichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.defaultSerialMsg, Color.Red);
			}
			return _return;
		}

		/// <summary>
		/// 向设备写入命令
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int WriteCmdToDevice(byte[] cmd, RichTextBox msg = null)
		{
			int _return = -1;
			if (this.AnalyseSendData(cmd)==true)
			{
				if ((this.defaultSerialPort!=null)&&(this.defaultSerialPort.IsOpen))
				{
					//---等待发送完成
					while (this.defaultSerialPort.BytesToWrite > 0)
					{
						//---响应窗体函数
						Application.DoEvents();
					}
					//---发送数据
					this.defaultSerialPort.Write(this.defaultSerialSendData.mByte.ToArray(), 0, this.defaultSerialSendData.mByte.Count);
					_return = 0;
				}
				else
				{
					this.defaultSerialMsg = "端口：" + this.mCOMMName + "初始化异常！";
				}
			}
			if ((msg!=null)&&(_return!=0))
			{
				CRichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.defaultSerialMsg, Color.Red, false);
			}
			return _return;
		}

		/// <summary>
		/// 从设备中读取命令
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="timeout"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int ReadCmdFromDevice(ref string cmd, int timeout = 200, RichTextBox msg = null)
		{
			//---获取开始时间标签
			DateTime nowTime = DateTime.Now;
			int _return = -1;
			if ((this.defaultSerialPort != null) && (this.defaultSerialPort.IsOpen))
			{
				CGenFuncDelay.GenFuncDelayms(timeout);
				if (this.defaultSerialPort.BytesToRead > 0)
				{
					cmd = this.defaultSerialPort.ReadExisting();
					_return = 0;
				}
				else
				{
					this.defaultSerialMsg = "未收到响应数据！";
				}
			}
			else
			{
				this.defaultSerialMsg = "端口：" + this.mCOMMName + "初始化异常！";
			}
			if ((msg != null) && (_return != 0))
			{
				CRichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.defaultSerialMsg, Color.Red);
			}
			this.defaultSerialTimeout = timeout;
			//---结束时间
			this.defaultSerialUsedTime = DateTime.Now - nowTime;
			return _return;
		}

		/// <summary>
		/// 从设备中读取命令
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="timeout"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int ReadCmdFromDevice(ref byte[] cmd, int timeout = 200, RichTextBox msg = null)
		{
			//---获取开始时间标签
			DateTime nowTime = DateTime.Now;
			int _return = -1;
			if (this.defaultSerialReceData.mSize>250)
			{
				_return = this.Analyse16BitsData(timeout);
			}
			else
			{
				_return = this.Analyse8BitsData(timeout);
			}
			if (_return == 0)
			{
				cmd = new byte[this.defaultSerialReceData.mByte.Count];
				this.defaultSerialReceData.mByte.CopyTo(cmd);
			}
			else
			{	
				//---接收发生错误
				this.defaultLastRecePass = false;
			}
			if ((msg != null) && (_return != 0))
			{
				CRichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.defaultSerialMsg, Color.Red);
			}
			this.defaultSerialTimeout = timeout;
			//---结束时间
			this.defaultSerialUsedTime = DateTime.Now - nowTime;
			return _return;
		}

		/// <summary>
		/// 发送并读取响应
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="res"></param>
		/// <param name="timeout"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int SendCmdAndReadResponse(byte[] cmd, ref byte[] res, int timeout = 300, RichTextBox msg = null)
		{
			//---校验上一次的接收状态
			if (this.defaultLastRecePass == false)
			{
				//---读取接收缓存区的数据
				if (this.defaultSerialPort.BytesToRead>0)
				{
					this.defaultSerialPort.ReadExisting();
				}
				//---清空接收缓存区
				this.defaultSerialPort.DiscardInBuffer();
				//---清空发送缓存区
				this.defaultSerialPort.DiscardOutBuffer();
				//---置位上一次的数据接收为正常
				this.defaultLastRecePass = true;
			}
			//---获取开始时间标签
			DateTime nowTime = DateTime.Now;
			//---发送数据
			int _return = this.WriteCmdToDevice(cmd, msg);
			//---校验发送结果
			if (_return==0)
			{
				//---读取响应
				_return = this.ReadCmdFromDevice(ref res, timeout, msg);
			}
			//---结束时间
			this.defaultSerialUsedTime = DateTime.Now - nowTime;
			return _return;
		}

		/// <summary>
		/// 发送并读取响应
		/// </summary>
		/// <param name="cmd"></param>
		/// <param name="res"></param>
		/// <param name="timeout"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int SendCmdAndReadResponse(string cmd, ref string res, int timeout = 200, RichTextBox msg = null)
		{
			//---校验上一次的接收状态
			if (this.defaultLastRecePass == false)
			{
				//---读取接收缓存区的数据
				if (this.defaultSerialPort.BytesToRead > 0)
				{
					this.defaultSerialPort.ReadExisting();
				}
				//---清空接收缓存区
				this.defaultSerialPort.DiscardInBuffer();
				//---清空发送缓存区
				this.defaultSerialPort.DiscardOutBuffer();
				//---置位上一次的数据接收为正常
				this.defaultLastRecePass = true;
			}
			//---获取开始时间标签
			DateTime nowTime = DateTime.Now;
			//---发送数据
			int _return = this.WriteCmdToDevice(cmd, msg);
			//---校验发送结果
			if (_return==0)
			{
				//---读取响应
				_return = ReadCmdFromDevice(ref res, timeout, msg);
			}
			//---结束时间
			this.defaultSerialUsedTime = DateTime.Now - nowTime;
			return _return;
		}

		/// <summary>
		/// 打开设备
		/// </summary>
		/// <returns></returns>
		public override int OpenDevice()
		{
			return this.OpenDevice(this.defaultSerialPortParam.mName,null);
		}

		/// <summary>
		/// 打开设备
		/// </summary>
		/// <param name="argName"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int OpenDevice(string argName, RichTextBox msg = null)
		{
			int _return = 0;
			if ((!string.IsNullOrEmpty(argName)) && (argName.StartsWith("COM",System.StringComparison.CurrentCultureIgnoreCase)))
			{
				//---判断串口类是否初始化
				if (this.defaultSerialPort == null)
				{
					this.defaultSerialPort = new SerialPort();
				}
				//---判断当前端口是否可用
				if (this.defaultSerialPort.IsOpen)
				{
					//---等待端口事件处理完成
					while (!((this.defaultSerialSTATE == CCOMM_STATE.STATE_IDLE) || (this.defaultSerialSTATE == CCOMM_STATE.STATE_ERROR)))
					{
						Application.DoEvents();
					}
					//---端口状态，空闲
					this.defaultSerialSTATE = CCOMM_STATE.STATE_IDLE;
					//---关闭端口
					this.defaultSerialPort.Close();
				}
				//---判断端口状态
				if (this.defaultSerialPort.IsOpen == false)
				{
					//---获取端口名称
					if (this.defaultSerialPort.PortName != argName)
					{
						this.defaultSerialPort.PortName = argName;
					}					
					//---查空操作
					if (this.defaultSerialPortParam == null)
					{
						this.defaultSerialPortParam = new CSerialPortParam();
					}
					//---使用的设备端口
					this.mCOMMName = argName;
					//---波特率
					if (this.defaultSerialPort.BaudRate != int.Parse(this.defaultSerialPortParam.mBaudRate))
					{
						this.defaultSerialPort.BaudRate = int.Parse(this.defaultSerialPortParam.mBaudRate);
					}
					//---校验位
					if (this.defaultSerialPort.Parity != this.GetParityBits(this.defaultSerialPortParam.mParity))
					{
						this.defaultSerialPort.Parity = this.GetParityBits(this.defaultSerialPortParam.mParity);
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
					try
					{
						//---打开端口
						this.defaultSerialPort.Open();
						//---判断端口打开是否成功
						if (this.defaultSerialPort.IsOpen == false)
						{
							//---端口状态，错误
							this.defaultSerialSTATE = CCOMM_STATE.STATE_ERROR;
							this.defaultSerialMsg = "端口：" + this.mCOMMName + "打开失败!";
							_return = 2;
						}
						else
						{
                            this.defaultConnected = true;
                            this.defaultSerialMsg = "端口：" + this.mCOMMName + "打开成功!";
							//---注册事件接收函数
							if (this.defaultHaveEventDataReceivedState==false)
							{
								this.defaultSerialPort.DataReceived += new SerialDataReceivedEventHandler(this.HandleDataReceivedEvent);
								this.defaultHaveEventDataReceivedState = true;
							}							
							_return = 0;
						}
					}
					catch 
					{
						this.defaultSerialMsg = "端口：" + this.mCOMMName + "打开异常!";
						_return = 3;
					}
					
				}
				else
				{
					//---端口状态，错误
					this.defaultSerialSTATE = CCOMM_STATE.STATE_ERROR;
					this.defaultSerialMsg = "端口：" + argName + "初始化失败!";
					_return = 4;
				}
			}
			if (_return > 0)
			{
				//---消息插件弹出
				CMessageBoxPlus.Show(this.mCCommForm, this.defaultSerialMsg + "\r\n" + "错误号：" + _return.ToString() + "\r\n", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else if (_return < 0)
			{
				CMessageBoxPlus.Show(this.mCCommForm, "端口名称不合法!\r\n", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				_return = 5;
			}
			else
			{
				//---消息显示
				if (msg != null)
				{
					CRichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.defaultSerialMsg, _return == 0 ? Color.Black : Color.Red);
				}
			}
			return _return;
		
		}

		/// <summary>
		/// 打开设备
		/// </summary>
		/// <param name="argIndex"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int OpenDevice(int argIndex, RichTextBox msg = null)
		{
			this.mCOMMName = "COM" + argIndex.ToString();
			return this.OpenDevice(this.mCOMMName, msg); 
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="argSerialParam"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int OpenDevice(CSerialPortParam argSerialParam, RichTextBox msg = null)
		{
			if (argSerialParam != null)
			{
				if (this.defaultSerialPortParam == null)
				{
					this.defaultSerialPortParam = new CSerialPortParam();
				}
				this.mCOMMName = argSerialParam.mName;
				this.defaultSerialPortParam.mBaudRate = argSerialParam.mBaudRate;
				this.defaultSerialPortParam.mParity = argSerialParam.mParity;
				this.defaultSerialPortParam.mDataBits = argSerialParam.mDataBits;
				this.defaultSerialPortParam.mStopBits = argSerialParam.mStopBits;
				this.defaultSerialPortParam.mAddrID = argSerialParam.mAddrID;
				return this.OpenDevice(this.mCOMMName, msg);
			}
			else
			{
				return -1;
			}
		}

		/// <summary>
		/// 关闭设备
		/// </summary>
		/// <returns></returns>
		public override int CloseDevice()
		{
			return this.CloseDevice(null);
		}
		/// <summary>
		/// 关闭设备
		/// </summary>
		/// <returns></returns>
		public override int CloseDevice(RichTextBox msg = null)
		{
            int _return = -1;
            if ((this.defaultSerialPort!=null)&&(this.defaultSerialPort.IsOpen))
            {
                try
                {
                    this.defaultSerialPort.Close();
                    if (this.defaultSerialPort.IsOpen==false)
                    {
                        this.defaultConnected = false;
                        _return = 0;
                        this.defaultSerialMsg = "端口:" + this.mCOMMName.ToString() + "关闭成功!";
						//---注销事件接收函数
						if (this.defaultHaveEventDataReceivedState == true)
						{
							this.defaultSerialPort.DataReceived -= new SerialDataReceivedEventHandler(this.HandleDataReceivedEvent);
							this.defaultHaveEventDataReceivedState = false;
						}
                        //---释放端口使用的资源
                        this.defaultSerialPort.Dispose();
                    }
                    else
                    {
                        this.defaultSerialMsg = "端口:" + this.mCOMMName.ToString() + "关闭失败!";
                        _return = 1;
                    }
                }
                catch
                {
                    this.defaultSerialMsg = "端口:" + this.mCOMMName.ToString() + "关闭异常!";
                    _return = 2;
                }
            }
            else
            {
                this.defaultSerialMsg = "端口资源已释放!";
                _return = 3;
            }
			//---消息显示
            if (msg != null)
            {
                CRichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.defaultSerialMsg, _return == 0 ? Color.Black : Color.Red);
            }
            return _return;
		}

		/// <summary>
		/// 关闭设备
		/// </summary>
		/// <param name="argName"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int CloseDevice(string argName, RichTextBox msg = null)
		{
            int _return = -1;
            if (this.defaultSerialPort == null)
            {
                this.defaultSerialMsg = "端口资源已释放!";
                _return = 1;
            }
            else if(this.defaultSerialPort.PortName!=argName)
            {
                this.defaultSerialMsg = "释放端口名称不匹配!";
                _return = 2;
            }
            else if(this.defaultSerialPort.IsOpen==false)
            {
                this.defaultSerialMsg = "端口:"+argName+"已关闭!";
                this.defaultSerialPort.Dispose();
                _return = 3;
            }
            else
            {
                try
                {
					//---等待端口空闲
					this.WaitForIdle(argName);
					//---关闭端口
                    this.defaultSerialPort.Close();
                    if (this.defaultSerialPort.IsOpen == false)
                    {
                        this.defaultConnected = false;
                        _return = 0;
                        this.defaultSerialMsg = "端口:" + this.mCOMMName.ToString() + "关闭成功!";
						//---注销事件接收函数
						if (this.defaultHaveEventDataReceivedState == true)
						{
							this.defaultSerialPort.DataReceived -= new SerialDataReceivedEventHandler(this.HandleDataReceivedEvent);
							this.defaultHaveEventDataReceivedState = false;
						}						
                        //---释放端口使用的资源
                        this.defaultSerialPort.Dispose();
                    }
                    else
                    {
                        this.defaultSerialMsg = "端口:" + this.mCOMMName.ToString() + "关闭失败!";
                        _return = 4;
                    }
                }
                catch
                {
                    this.defaultSerialMsg = "端口:" + this.mCOMMName.ToString() + "关闭异常!";
                    _return = 5;
                }
            }
            //---消息显示
            if (msg != null)
            {
                CRichTextBoxPlus.AppendTextInfoTopWithDataTime(msg, this.defaultSerialMsg, _return == 0 ? Color.Black : Color.Red);
            }
            return _return;
        }

		/// <summary>
		/// 关闭设备
		/// </summary>
		/// <param name="argIndex"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int CloseDevice(int argIndex, RichTextBox msg = null)
		{
            string argName = "COM" + argIndex.ToString();
            return this.CloseDevice(argName, msg);
		}

		/// <summary>
		/// 设备是否处于连接状态
		/// </summary>
		/// <returns></returns>
		public override bool DetectDevice()
		{
            if (this.defaultSerialPort == null)
            {
                return false;
            }
            else
            {
                return this.defaultSerialPort.IsOpen;
            }
		}

		/// <summary>
		/// 设备是否处于连接状态
		/// </summary>
		/// <param name="argName"></param>
		/// <returns></returns>
		public override bool DetectDevice(string argName)
		{
            if (this.defaultSerialPort == null)
            {
                return false;
            }
            else if(this.defaultSerialPort.PortName==argName)
            {
                return this.defaultSerialPort.IsOpen;
            }
            else
            {
                return false;
            }
        }

		/// <summary>
		/// 设备是否处于连接状态
		/// </summary>
		/// <param name="argIndex"></param>
		/// <returns></returns>
		public override bool DetectDevice(int argIndex)
		{
            string argName = "COM" + argIndex.ToString();
            return this.DetectDevice(argName);
        }

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public override bool WaitForIdle()
		{
			bool _return = false;
			//---当前端口必须处于打开状态
			while (this.DetectDevice())
			{
				//---检查端口状态必须是空闲或者错误状态，才能退出操作
				if ((this.defaultSerialSTATE == CCOMM_STATE.STATE_IDLE) || (this.defaultSerialSTATE == CCOMM_STATE.STATE_ERROR))
				{
					_return = true;
					break;
				}
				else
				{
					//---响应其他事件
					Application.DoEvents();
				}
			}
			return _return;
		}

		/// <summary>
		/// 等待设备空闲
		/// </summary>
		/// <returns></returns>
		public override bool WaitForIdle(string argName)
		{
			bool _return = false;
			//---当前端口必须处于打开状态
			while (this.DetectDevice(argName))
			{
				//---检查端口状态必须是空闲或者错误状态，才能退出操作
				if ((this.defaultSerialSTATE == CCOMM_STATE.STATE_IDLE)||(this.defaultSerialSTATE==CCOMM_STATE.STATE_ERROR))
				{
					_return = true;
					break;
				}
				else
				{
					//---响应其他事件
					Application.DoEvents();
				}
			}
			return _return;
		}

		/// <summary>
		/// 等待空闲
		/// </summary>
		/// <param name="argIndex"></param>
		/// <returns></returns>
		public override bool WaitForIdle(int argIndex)
		{
			string argName = "COM" + argIndex.ToString();
			return this.WaitForIdle(argName);
		}

		#endregion

		#region 私有函数

		#endregion

		#region 事件函数

		#endregion
	}
}
