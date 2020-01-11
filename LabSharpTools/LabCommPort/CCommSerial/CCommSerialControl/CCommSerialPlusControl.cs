using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Harry.LabTools.LabCommType
{
    public partial class CCommSerialPlusControl : CCommBaseControl
    {
        #region 变量定义
		
		/// <summary>
		/// 默认波特率的配置的最大个数
		/// </summary>
		private int defaultBaudRateMaxNum=0;

		#endregion

		#region 属性定义

		/// <summary>
		/// 端口对象
		/// </summary>
		public override CCommBase mCCOMM
        {
            get
            {
                return base.mCCOMM;
            }
            set
            {
                base.mCCOMM = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override Button mButton
        {
            get
            {
               return  base.mButton;
            }
            set
            {
                base.mButton = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override PictureBox mPictureBox
        {
            get
            {
                return base.mPictureBox;
            }
            set
            {
                base.mPictureBox = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		public override bool mIsShowCommParam
		{
			get
			{
				return base.mIsShowCommParam;
			}
			set
			{
				base.mIsShowCommParam = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public override string mCCommName
		{
			get
			{
				return base.mCCommName;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual string mBaudRate
		{
			get
			{
				return this.comboBox_BaudRate.Text;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual string mStopBits
		{
			get
			{
				return this.comboBox_StopBits.Text;
			}
		}


		/// <summary>
		/// 
		/// </summary>
		public virtual string mDataBits
		{
			get
			{
				return this.comboBox_DataBits.Text;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual string mParity
		{
			get
			{
				return this.comboBox_Parity.Text;
			}
		}

		/// <summary>
		/// 每包字节的大小
		/// </summary>
		public override int mPerPackageMaxSize
		{
			get
			{
				if (this.mCCOMM != null)
				{
					return this.mCCOMM.mPerPackageMaxSize;
				}
				else
				{
					return 64;
				}

			}
			set
			{
				if (this.mCCOMM != null)
				{
					this.mCCOMM.mPerPackageMaxSize = value;
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
		public CCommSerialPlusControl():base()
        {
            InitializeComponent();

			//---限制窗体的大小
			//this.MinimumSize = this.Size;
			//this.MaximumSize = this.Size;

			this.StartupInit();

        }

        #endregion

        #region 析构函数

        ~CCommSerialPlusControl()
        {
            this.FreeResource();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void FreeResource()
        {
            base.FreeResource();
			this.Dispose();
        }

        #endregion

        #region 公有函数

		/// <summary>
		/// 解析波特率
		/// </summary>
		/// <param name="baudRate"></param>
		public virtual void AnalyseBaudRate(string baudRate)
		{
			int index = this.comboBox_BaudRate.Items.IndexOf(baudRate);
			if (index<0)
			{
				this.comboBox_BaudRate.Items.Add(baudRate);
				this.comboBox_BaudRate.SelectedIndex = this.comboBox_BaudRate.Items.Count - 1;
			}
			else
			{
				this.comboBox_BaudRate.SelectedIndex = index;
			}
		}

		/// <summary>
		/// 数据位解析
		/// </summary>
		/// <param name="dataBits"></param>
		public virtual void AnalyseDataBits(string dataBits)
		{
			int index = this.comboBox_DataBits.Items.IndexOf(dataBits);
			if (index<0)
			{
			
				this.comboBox_DataBits.SelectedIndex =1;
			}
			else
			{
				this.comboBox_DataBits.SelectedIndex = index;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="stopBits"></param>
		public virtual void AnalyseStopBits(string stopBits)
		{
			int index = this.comboBox_StopBits.Items.IndexOf(stopBits);
			if (index<0)
			{
			
				this.comboBox_StopBits.SelectedIndex =0;
			}
			else
			{
				this.comboBox_StopBits.SelectedIndex = index;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="parity"></param>
		public virtual void AnalyseParity(string parity)
		{
			int index = this.comboBox_Parity.Items.IndexOf(parity);
			if (index<0)
			{
			
				this.comboBox_Parity.SelectedIndex =0;
			}
			else
			{
				this.comboBox_Parity.SelectedIndex = index;
			}
		}

        #endregion

        #region 保护函数

        #endregion

        #region 私有函数

		private void StartupInit()
		{
			this.comboBox_BaudRate.SelectedIndex = 7;
			this.comboBox_DataBits.SelectedIndex = 1;
			this.comboBox_StopBits.SelectedIndex = 0;
			this.comboBox_Parity.SelectedIndex = 0;

			this.defaultBaudRateMaxNum=this.comboBox_BaudRate.Items.Count;

			//---注册波特率选择变化事件
			this.comboBox_BaudRate.SelectedIndexChanged += new EventHandler(this.ComboBox_SelectedIndexChanged);
		}

        #endregion

        #region 事件函数

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private  void ComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ComboBox cbb = (ComboBox)sender;
			switch (cbb.Name)
			{
				case "comboBox_BaudRate":
					if (cbb.Text=="自定义")
					{
						if (this.comboBox_BaudRate.DropDownStyle != System.Windows.Forms.ComboBoxStyle.DropDown)
						{
							this.comboBox_BaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
						}
						cbb.SelectedValue = "";
						cbb.SelectedText = "";
						cbb.Text = "";

						//---判断是否添加了新数据，如果添加，去除新添加的数据
						if (cbb.Items.Count > this.defaultBaudRateMaxNum)
						{
							cbb.Items.Remove(cbb.Items[cbb.Items.Count - 1]);
						}

					}
					else
					{
						if (this.comboBox_BaudRate.DropDownStyle == System.Windows.Forms.ComboBoxStyle.DropDown)
						{
							this.comboBox_BaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
						}
						if (this.comboBox_BaudRate.Items.IndexOf(cbb.Text)<0)
						{
							//---判断是否添加了新数据，如果添加，去除新添加的数据
							if (cbb.Items.Count > this.defaultBaudRateMaxNum)
							{
								cbb.Items.Remove(cbb.Items[cbb.Items.Count - 1]);
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
