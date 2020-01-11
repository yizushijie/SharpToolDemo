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
    public partial class CCommSerialControl : CCommBaseControl
    {
		#region 变量定义


		#endregion

		#region 属性定义

		/// <summary>
		/// 端口属性
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
                return base.mButton;
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
				return	base.mIsShowCommParam;
			}
			set 
			{
				base.mIsShowCommParam = value;
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
		public CCommSerialControl()
        {
            InitializeComponent();
			//---限制窗体的大小
			this.MinimumSize = this.Size;
			this.MaximumSize = this.Size;
		}

        #endregion

        #region 析构函数

        ~CCommSerialControl()
        {
            this.FreeResource();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void FreeResource()
        {
            base.FreeResource();
        }

        #endregion

        #region 公有函数

        #endregion

        #region 保护函数

        #endregion

        #region 私有函数

        #endregion

        #region 事件函数

        #endregion
    }
}
