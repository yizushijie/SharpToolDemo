using Harry.LabTools.LabGenForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Harry.LabTools.LabCommPort
{
    public partial class CCommPortForm : CFloatPopupBaseForm
    {
		#region 变量定义
		
		#endregion

		#region 属性定义

        /// <summary>
		/// 串口参数
		/// </summary>
		public virtual CSerialPortParam mCCommSrialParam
		{
			get
			{
				return null;
			}
		}

		/// <summary>
		/// USB参数
		/// </summary>
		public virtual CUSBPortParam mCCommUSBParam
		{
			get
			{
				return null;
			}
		}

		/// <summary>
		/// 端口变化
		/// </summary>
		public virtual bool mCCommChanged
		{
			get
			{
				return false;
			}
		}

		/// <summary>
		/// 接收数据校验方式
		/// </summary>
		public virtual CCOMM_CRC mRxCRC
		{
			get
			{
				return CCOMM_CRC.CRC_NONE;
			}
		}

		/// <summary>
		/// 发送数据校验方式
		/// </summary>
		public virtual CCOMM_CRC mTxCRC
		{
			get
			{
				return CCOMM_CRC.CRC_NONE;
			}
		}

		/// <summary>
		/// 每包字节的大小
		/// </summary>
		public virtual int mPerPackageMaxSize
		{
			get
			{
				return 0;
			}
		}
		
		#endregion

		#region 构造函数

		/// <summary>
		/// 
		/// </summary>
		public CCommPortForm()
        {
            InitializeComponent();
        }

        #endregion

        #region 析构函数

        /// <summary>
        /// 
        /// </summary>
        ~CCommPortForm()
        {
            this.FreeResource();
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void FreeResource()
        {
			GC.SuppressFinalize(this);
        }

        #endregion

        #region 公有函数
		
        #endregion

        #region 保护函数

        #endregion

        #region 私有函数

        #endregion

        #region 事件函数

		/// <summary>
		/// 
		/// </summary>
		public virtual void ParamShowDialog_Click(object sender, System.EventArgs e)
        {
            //---返回操作完成状态
            this.DialogResult = System.Windows.Forms.DialogResult.None;
        }

		#endregion
    }
}
