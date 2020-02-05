using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Harry.LabTools.LabControlPlus;
using System.Reflection;

namespace Harry.LabTools.LabCommPort
{
    public partial class CCommPortControl : UserControl
    {

		#region 委托事件

		/// <summary>
		/// 通讯设备同步事件
		/// </summary>
		public virtual event EventCCommChanged EventHandlerCCommSynchronized = null;

		#endregion

		#region 变量定义

		/// <summary>
		/// 使用的端口
		/// </summary>
		private CCommPort defaultCCOMM = new CCommPort();//null;

		/// <summary>
		/// 是否显示端口配置参数
		/// </summary>
		private bool defaultShowCommParam=false;

		/// <summary>
		/// 是否限定控件的大小，false---不缩放，true---缩放
		/// </summary>
		private bool defaultLimitedControlSize = false;

		#endregion

		#region 属性定义

		/// <summary>
		/// 通讯端口对象
		/// </summary>
		public virtual CCommPort mCCOMM
        {
            get
            {
                return this.defaultCCOMM;
            }
            set
            {
                if (this.defaultCCOMM==null)
                {
                    this.defaultCCOMM = new CCommPort();
                }
                this.defaultCCOMM = value;
            }
        }

        /// <summary>
        /// 初始化端口的按钮
        /// </summary>
        public virtual Button mButton
        {
            get
            {
                return this.button_COMM;
            }
            set
            {
                this.button_COMM = value;
            }
        }

        /// <summary>
        /// 端口操作状态指示
        /// </summary>
        public virtual PictureBox mPictureBox
        {
            get
            {
                return this.pictureBox_COMM;
            }
            set
            {
                this.pictureBox_COMM = value;
            }
        }

		/// <summary>
		/// 是否显示端口配置参数
		/// </summary>
		[Description("通讯端口的参数"), Category("自定义属性")]
		public virtual bool mShowCommParam
		{
			get
			{
				return this.defaultShowCommParam;
			}
			set
			{
				this.defaultShowCommParam=value;
			}
		}

		/// <summary>
		/// 是否限制控件的大小
		/// </summary>
		[Description("限制控件的大小"), Category("自定义属性")]
		public virtual bool mLimitedControlSize
		{
			get
			{
				return this.defaultLimitedControlSize;
			}
			set
			{
				this.defaultLimitedControlSize=value;
			}
		}

		/// <summary>
		/// 通讯端口名称
		/// </summary>
		[Description("通讯端口的名称"), Category("自定义属性")]
		public virtual string mCCommName
		{
			get
			{
				return this.comboBox_COMM.Text;
			}
		}

		/// <summary>
		/// 消息显示的控件
		/// </summary>
		public virtual RichTextBox mCCommRichTextBox
		{
			get
			{
				if (this.defaultCCOMM!=null)
				{
					return this.defaultCCOMM.mCCommRichTextBox;
				}
				else
				{
					return  null;
				}
			}
			set
			{
				if (this.defaultCCOMM!=null)
				{
					this.defaultCCOMM.mCCommRichTextBox=value;
				}
			}
		}
		
		/// <summary>
		/// 每包字节的大小
		/// </summary>
		public virtual int mPerPackageMaxSize
		{
			get
			{
				if (this.defaultCCOMM != null)
				{
					return this.defaultCCOMM.mPerPackageMaxSize;
				}
				else
				{
					return 64;
				}

			}
			set
			{
				if (this.defaultCCOMM != null)
				{
					this.defaultCCOMM.mPerPackageMaxSize = value;
				}
			}
		}

		/// <summary>
		/// 系统类型
		/// </summary>
		private Boolean IsXpOr2003
		{
			get
			{
				OperatingSystem os = Environment.OSVersion;
				Version vs = os.Version;
				if (os.Platform == PlatformID.Win32NT)
				{
					if ((vs.Major == 5) && (vs.Minor != 0))
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				else
				{
					return false;
				}
			}
		}

		/// <summary>
		/// 设置控件窗口创建参数的扩展风格
		/// </summary>
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				// Turn on WS_EX_COMPOSITED    
				cp.ExStyle |= 0x02000000;
				if (this.IsXpOr2003 == true)
				{
					// Turn on WS_EX_LAYERED  
					cp.ExStyle |= 0x00080000;
					//---设置窗体不透明度
					//this.Opacity = 1;
				}
				return cp;
			}
		}

		#endregion

		#region 构造函数

		/// <summary>
		/// 
		/// </summary>
		public CCommPortControl()
		{
			 InitializeComponent();
			 this.StartupInit(null);
			this.defaultShowCommParam=true;
		}

        /// <summary>
        /// 
        /// </summary>
        public CCommPortControl(bool isShowCommParam=true)
        {
            InitializeComponent();
            this.StartupInit(null);
			this.defaultShowCommParam=isShowCommParam;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ccomm"></param>
        public CCommPortControl(CCommPort ccomm, RichTextBox msg = null)
        {
            InitializeComponent();
            this.StartupInit(ccomm,msg);
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ccommBaseControl"></param>
		public CCommPortControl(CCommPortControl ccommBaseControl)
		{
			
		}

		#endregion

		#region 析构函数

		/// <summary>
		/// 
		/// </summary>
		~CCommPortControl()
        {
            this.FreeResource();
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public virtual void FreeResource()
        {
            if (this.defaultCCOMM != null)
            {
				 //this.defaultCCOMM.Dispose();
				GC.SuppressFinalize(this.defaultCCOMM);
			}
            GC.SuppressFinalize(this);
        }

        #endregion

        #region 公有函数

        /// <summary>
        /// 打开设备
        /// </summary>
        public virtual void OpenDevice()
        {
            if (this.comboBox_COMM.Items.Count>0)
            {
                if (this.defaultCCOMM!=null)
                {
                    if(this.defaultCCOMM.OpenDevice(this.comboBox_COMM.Text, this.defaultCCOMM.mCCommRichTextBox)==0)
                    {
						//---切换按钮的功能
						if (this.button_COMM.InvokeRequired)
						{
							this.button_COMM.BeginInvoke((EventHandler)
											(delegate
											{
												this.button_COMM.Text = "关闭设备";
											}));
						}
						else
						{
							this.button_COMM.Text = "关闭设备";
						}
						//---屏蔽端口的选择
						if (this.comboBox_COMM.InvokeRequired)
						{
							this.comboBox_COMM.BeginInvoke((EventHandler)
												(delegate
												{
													this.comboBox_COMM.Enabled = false;
												}));
						}
						else
						{
							this.comboBox_COMM.Enabled = false;
						}
                        this.pictureBox_COMM.Image= Properties.Resources.open;
                        this.defaultCCOMM.EventCCommChangedHandler += this.EventDeviceChanged;
						this.defaultShowCommParam = false;
						//---执行设备的同步事件
						this.EventHandlerCCommSynchronized?.Invoke();
					}
                }
            }
        }

        /// <summary>
        /// 关闭设备
        /// </summary>
        public virtual void CloseDevice()
        {
            if (this.defaultCCOMM!=null)
            {
                if (this.defaultCCOMM.DetectDevice())
                {
                   if( this.defaultCCOMM.CloseDevice(this.defaultCCOMM.mCCommRichTextBox)==0)
                   {
						//---切换按键的功能
						if (this.button_COMM.InvokeRequired)
						{
							this.button_COMM.BeginInvoke((EventHandler)
											(delegate
											{
												this.button_COMM.Text = "打开设备";
											}));
						}
						else
						{
							this.button_COMM.Text = "打开设备";
						}
						//---使能端口的选择
						if (this.comboBox_COMM.InvokeRequired)
						{
							this.comboBox_COMM.BeginInvoke((EventHandler)
												(delegate
												{
													this.comboBox_COMM.Enabled = true;
												}));
						}
						else
						{
							this.comboBox_COMM.Enabled = true;
						}
						this.pictureBox_COMM.Image = Properties.Resources.lost;
						//---设备移除事件
						this.defaultCCOMM.EventCCommChangedHandler -= this.EventDeviceChanged;
						this.defaultShowCommParam = true;
						//---执行设备的同步事件
						this.EventHandlerCCommSynchronized?.Invoke();
					}
                }
            }
        }

        /// <summary>
        /// 配置参数
        /// </summary>
        public virtual void ConfigParam()
        {
			
        }

        /// <summary>
        /// 错误信息
        /// </summary>
        public virtual void ErrMessage()
        {
            CMessageBoxPlus.Show(null, "设备操作异常！错误操作：" + this.button_COMM.Text, "错误提示");
        }

        /// <summary>
        /// 设备发生变化的时候
        /// </summary>
        public virtual void EventDeviceChanged()
        {
            if (this.defaultCCOMM!=null)
            {
                if (this.InvokeRequired)
                {
                    this.BeginInvoke((EventHandler)
                                 (delegate
                                 {
                                     if ((!string.IsNullOrEmpty(this.comboBox_COMM.Text))|| ((this.defaultCCOMM.mCOMMName != this.comboBox_COMM.Text)))
                                     {
										 //if (this.pictureBox_COMM.Image.Flags == Properties.Resources.open.Flags)
										 if (LabGenFunc.CGenFuncBitMap.GenFuncCompareBitMap((Bitmap)this.pictureBox_COMM.Image, Properties.Resources.open) == true)
										 {
											 if (this.button_COMM.InvokeRequired)
											 {
												 this.button_COMM.BeginInvoke((EventHandler)
																 (delegate
																 {
																	 this.button_COMM.Text = "打开设备";
																 }
																 )
																 );
											 }
											 else
											 {
												 this.button_COMM.Text = "打开设备";
											 }
											 //---使能端口的选择
											 if (this.comboBox_COMM.InvokeRequired)
											 {
												 this.comboBox_COMM.BeginInvoke((EventHandler)
																	 (delegate
																	 {
																		 this.comboBox_COMM.Enabled = true;
																	 }));
											 }
											 else
											 {
												 this.comboBox_COMM.Enabled = true;
											 }
											 //---注销资源,一般这里不能释放资源，如果资源被释放，就不能主动监控端口的拔插事件
											 //this.defaultCCOMM.Dispose();
											 this.pictureBox_COMM.Image = Properties.Resources.lost;
											 this.defaultShowCommParam = true;
										 }
                                     }
                                 }));
                }
                else
                {
					if (!(string.IsNullOrEmpty(this.comboBox_COMM.Text)) || ((this.defaultCCOMM.mCOMMName != this.comboBox_COMM.Text)))
                    {
						//if (this.pictureBox_COMM.Image.Flags == Properties.Resources.open.Flags)
						if (LabGenFunc.CGenFuncBitMap.GenFuncCompareBitMap((Bitmap)this.pictureBox_COMM.Image, Properties.Resources.open) == true)
						{
							if (this.button_COMM.InvokeRequired)
							{
								this.button_COMM.BeginInvoke((EventHandler)
												(delegate
												{
													this.button_COMM.Text = "打开设备";
												}
												)
												);
							}
							else
							{
								this.button_COMM.Text = "打开设备";
							}
							//---使能端口的选择
							if (this.comboBox_COMM.InvokeRequired)
							{
								this.comboBox_COMM.BeginInvoke((EventHandler)
													(delegate
													{
														this.comboBox_COMM.Enabled = true;
													}));
							}
							else
							{
								this.comboBox_COMM.Enabled = true;
							}
							//---注销资源
							this.defaultCCOMM.Dispose();
							this.pictureBox_COMM.Image = Properties.Resources.lost;
							this.defaultShowCommParam = true;
						}
                    }
                }
            }
        }
		
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="ccomm"></param>
        public virtual void Init(CCommPort ccomm = null,RichTextBox msg = null)
        {
            if (ccomm != null)
            {
                if (this.defaultCCOMM == null)
                {
                    this.defaultCCOMM = new CCommPort();
                }
                this.defaultCCOMM =ccomm;

                this.defaultCCOMM.Init(this.comboBox_COMM, msg);
            }
        }

		/// <summary>
		/// 移除端口控件的鼠标按下事件
		/// </summary>
		public virtual void RemoveComboBoxMouseDownClick()
		{
			LabGenFunc.CGenFuncEvent.GenFuncClearAllEvents(this.comboBox_COMM,"MouseDown");
		}

		/// <summary>
		/// 移除按键点击事件
		/// </summary>
		public virtual void RemoveButtonClick()
		{
			LabGenFunc.CGenFuncEvent.GenFuncClearAllEvents(this.button_COMM,"Click");
		}
		
		/// <summary>
		/// 刷新断口 
		/// </summary>
		/// <param name="cbb"></param>
		public virtual void RefreshCOMM(ComboBox cbb)
		{
			if (cbb==null)
			{
				return;
			}
			//---刷新设备存在的通信端口
			this.comboBox_COMM.Items.Clear();
			for (int i = 0; i < cbb.Items.Count; i++)
			{
				this.comboBox_COMM.Items.Add(cbb.Items[i]);
			}
			this.comboBox_COMM.SelectedIndex = cbb.SelectedIndex;
		}
		
		#endregion

		#region 保护函数

		#endregion

		#region 私有函数

		/// <summary>
		/// 启动初始化
		/// </summary>
		/// <param name="ccomm"></param>
		/// <param name="msg"></param>
		private void StartupInit(CCommPort ccomm=null, RichTextBox msg = null)
        {
            //---button 点击事件
            this.button_COMM.Click += new System.EventHandler(this.Button_Click);
			//---button 右击事件
			this.button_COMM.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonMouseDown_Click);

			//---端口状态刷新事件
			this.pictureBox_COMM.Click += new EventHandler(this.PictureBox_Click);

			//---增加鼠标移动事件
			this.comboBox_COMM.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ComboBoxMouseDown_Click);

			if (ccomm!=null)
            {
                if (this.defaultCCOMM==null)
                {
                    this.defaultCCOMM = new CCommPort();
                }
                this.defaultCCOMM = ccomm;
                this.defaultCCOMM.Init(this.comboBox_COMM, msg);
            }
        }

		/// <summary>
		/// 配置通信端口的参数
		/// </summary>
		private void ConfigCCOMMParam(bool isLockFrame=false)
		{
			if ((this.comboBox_COMM.Text != null) && (this.comboBox_COMM.Items.Count > 0))
			{
				CCommPortForm p=null;
				//---检查对象类型
				if ((this.defaultCCOMM.GetType() == typeof(CSerialPort)) && (this.defaultCCOMM.mCOMMType == CCOMM_TYPE.COMM_SERIAL))
				{
					if (this.defaultCCOMM.mFullParam)
					{
						//---串行通讯对象的参数
						p = new CSerialPortFullForm(this.defaultCCOMM.mPerPackageMaxSize,this.comboBox_COMM, this.defaultCCOMM, this.defaultCCOMM.mCCommRichTextBox, "配置设备", true);
					}
					else
					{
						//---串行通讯对象的参数
						p = new CSerialPortPlusForm(this.comboBox_COMM, this.defaultCCOMM, this.defaultCCOMM.mCCommRichTextBox, "配置设备", true);
					}
				}
				else if ((this.defaultCCOMM.GetType() == typeof(CUSBPort)) && (this.defaultCCOMM.mCOMMType == CCOMM_TYPE.COMM_USB))
				{
					//---USB通讯对象的参数
					p = new CCommUSBPlusForm();
				}
				else
				{
					MessageBox.Show("不支持的端口的参数配置!");
				}
				//---判断对象是否可用
				if (p!=null)
				{
					//---禁止船体移动
					p.mLockFrame = isLockFrame;
					//---计算位置偏移，避免超出可见区域
					int offset = 0;
					if (this.Location.X>this.comboBox_COMM.Size.Width)
					{
						offset = this.comboBox_COMM.Location.X - p.Size.Width+24;
					}
					//---显示弹出窗体
					if (p.ShowDialog(this.comboBox_COMM, offset, this.comboBox_COMM.Height+4) == System.Windows.Forms.DialogResult.OK)
					{
						//---解析参数
						if (this.defaultCCOMM.mFullParam)
						{
							this.defaultCCOMM.AnalyseParam(p.mPerPackageMaxSize,p.mCCommSrialParam, p.mCCommUSBParam,p.mRxCRC,p.mTxCRC,true);
						}
						else
						{
							this.defaultCCOMM.AnalyseParam(p.mPerPackageMaxSize, p.mCCommSrialParam, p.mCCommUSBParam);
						}
						//---检查端口是否发生变化
						if (p.mCCommChanged == true)
						{
							if (this.defaultCCOMM != null)
							{
								//---刷新设备
								this.defaultCCOMM.RefreshDevice(this.comboBox_COMM, this.defaultCCOMM.mCCommRichTextBox);
							}
						}
						if (this.defaultCCOMM.mCCommRichTextBox != null)
						{
							CRichTextBoxPlus.AppendTextInfoTopWithDataTime(this.defaultCCOMM.mCCommRichTextBox, "通信端口参数配置成功。", Color.Black);
						}
						//---执行设备的同步事件
						this.EventHandlerCCommSynchronized?.Invoke();
					}
					else
					{
						if (this.defaultCCOMM.mCCommRichTextBox != null)
						{
							CRichTextBoxPlus.AppendTextInfoTopWithDataTime(this.defaultCCOMM.mCCommRichTextBox, "通信端口参数配置失败。", Color.Red);
						}
					}
					//---释放资源
					p.FreeResource();
					GC.SuppressFinalize(p);
				}

			}
		}

		/// <summary>
		/// 配置通讯方式
		/// </summary>
		private void ConfigCCOMMType(bool isLockFrame=false)
		{
			if (this.defaultCCOMM!=null)
			{
				CCommPortTypeForm p = new CCommPortTypeForm(this.defaultCCOMM.mCOMMType,true);
				if (p != null)
				{
					//---计算位置偏移，避免超出可见区域
					int offset = 0;
					if (this.Location.X > this.button_COMM.Size.Width)
					{
						offset = -24;
					}
					if (p.ShowDialog(this.button_COMM, offset, this.button_COMM.Height +4) == System.Windows.Forms.DialogResult.OK)
					{
						if (this.defaultCCOMM.mCOMMType != p.mCCommType)
						{
							//if (p.mCCommType == CCOMM_TYPE.COMM_SERIAL)
							if ((p.mCCommType == CCOMM_TYPE.COMM_SERIAL)&&(this.defaultCCOMM.GetType() == typeof(CUSBPort)))
							{
								this.defaultCCOMM = new CSerialPort(this.comboBox_COMM,this.defaultCCOMM.mCCommRichTextBox);
							}
							//else if (p.mCCommType == CCOMM_TYPE.COMM_USB)
							else if ((p.mCCommType == CCOMM_TYPE.COMM_USB) &&(this.defaultCCOMM.GetType() == typeof(CSerialPort)))
							{
								this.defaultCCOMM = new CUSBPort(this.comboBox_COMM,this.defaultCCOMM.mCCommRichTextBox);
							}
							else 
							{
								MessageBox.Show("不支持的通讯端口,端口类型未发生更改!");
								//this.defaultCCOMM = null;
							}
							//---切换端口的状态为初始值
							if (this.button_COMM.InvokeRequired)
							{
								this.BeginInvoke((EventHandler)
												(delegate
												{
													this.button_COMM.Text = "打开设备";
												}
												)
												);
							}
							else
							{
								this.button_COMM.Text = "打开设备";
							}
							//---注销资源
							this.defaultCCOMM.Dispose();
							this.pictureBox_COMM.Image = Properties.Resources.lost;
							this.defaultShowCommParam = true;
						}
						//---执行设备的同步事件
						this.EventHandlerCCommSynchronized?.Invoke();
					}
					//---释放资源
					p.FreeResource();
					GC.SuppressFinalize(p);
				}
			}
			
		}

		#endregion

		#region 事件函数

		/// <summary>
		/// 按钮点击事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public virtual void Button_Click(object sender, System.EventArgs e)
        {
			if (sender==null)
			{
				return;
			}
            Button btn = (Button)sender;
            btn.Enabled = false;
            switch (btn.Name)
            {
                case "button_COMM":
                    if (btn.Text == "打开设备")
                    {
                        this.OpenDevice();
                    }
                    else if (btn.Text == "关闭设备")
                    {
                        this.CloseDevice();
                    }
                    else if (btn.Text == "配置设备")
                    {
                        this.ConfigParam();
                    }
                    else
                    {
                        this.ErrMessage();
                    }
                    break;

                default:
                    break;
            }
            btn.Enabled = true;
        }

		/// <summary>
		/// 按钮的右键按下
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public virtual void ButtonMouseDown_Click(object sender, MouseEventArgs e)
		{
			if ((sender == null)||(e==null))
			{
				return;
			}
			Button btn = (Button)sender;
			switch (btn.Name)
			{
				case "button_COMM":
					//---判断鼠标按下的按键，用于切换通讯端口的变化，如果是打开状态，
					//---则当前端口不可配置，必须关闭之后在进行配置
					if ((e.Button == MouseButtons.Right)&&(this.button_COMM.Text=="打开设备"))
					{
						this.ConfigCCOMMType(true);
					}
					break;
				default:
					break;
			}
		}	

		/// <summary>
		/// 图片点击事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public virtual void PictureBox_Click(object sender, System.EventArgs e)
        {
			if (sender == null)
			{
				return;
			}
			PictureBox ptb = (PictureBox)sender;
            ptb.Enabled = false;
            switch (ptb.Name)
            {
                case "pictureBox_COMM":
                    if ((this.button_COMM.Text == "打开设备")||(this.button_COMM.Text == "配置设备"))
                    {
                        if (this.defaultCCOMM != null)
                        {
                            //---刷新设备
                            this.defaultCCOMM.RefreshDevice(this.comboBox_COMM,this.defaultCCOMM.mCCommRichTextBox);
                        }
                    }
                    break;
                default:
                    break;
            }
            ptb.Enabled = true;
        }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public virtual void ComboBoxMouseDown_Click(object sender, MouseEventArgs e)
		{
			if ((sender == null) || (e == null))
			{
				return;
			}
			ComboBox cbb = (ComboBox)sender;
			int index;
			switch (cbb.Name)
			{
				case "comboBox_COMM":
					//---判断鼠标按下的按键
					//if (e.Button == MouseButtons.Right)
					if ((e.Button == MouseButtons.Right) && (this.defaultShowCommParam == true))
					{
						//---通过图片校验端口的状态
						//if (LabGenFunc.CGenFuncBitMap.GenFuncCompareBitMap((Bitmap)this.pictureBox_COMM.Image, Properties.Resources.open)!=true)
						{
							//---鼠标右键配置通信端口的参数
							this.ConfigCCOMMParam(true);
							//---判断是否端口发生了变化
							if ((!string.IsNullOrEmpty(this.comboBox_COMM.Text)) && (!string.IsNullOrEmpty(this.defaultCCOMM.mCOMMName)) && (this.defaultCCOMM.mCOMMName != this.comboBox_COMM.Text))
							{
								//---数据位
								index = this.comboBox_COMM.Items.IndexOf(this.defaultCCOMM.mCOMMName);
								if (index < 0)
								{
									this.comboBox_COMM.SelectedIndex = 0;
								}
								else
								{
									this.comboBox_COMM.SelectedIndex = index;
								}
							}
						}
					}
					break;
				default:
					break;
			}
		}

		#endregion
	}
}
