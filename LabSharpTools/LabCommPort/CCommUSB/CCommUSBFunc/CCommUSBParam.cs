using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Harry.LabTools.LabCommType
{
	public partial class CCommUSB
	{
		#region 变量定义

		#endregion

		#region 公共属性

		/// <summary>
		/// 使用的通讯端口
		/// </summary>
		public override CCOMM_TYPE mType
		{
			get
			{
				return CCOMM_TYPE.COMM_USB;
			}
			set
			{
				base.mType = value;
			}
		}


		#endregion

		#region 属性定义
		/// <summary>
		/// 
		/// </summary>
		public override CCommUSBParam mUSBParam
		{
			get
			{
				return base.mUSBParam;
			}
			set
			{
				base.mUSBParam = value;			
			}
		}

		#endregion

		#region 构造函数

		#endregion

		#region 公有函数

		/// <summary>
		/// 初始化USB参数
		/// </summary>
		/// <param name="uSBParam"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int Init(CCommUSBParam uSBParam, RichTextBox msg = null)
		{
			return -1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="usbParam"></param>
		/// <param name="rxCRC"></param>
		/// <param name="tcCRC"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public override int Init(CCommUSBParam usbParam, CCOMM_CRC rxCRC, CCOMM_CRC txCRC, RichTextBox msg = null)
		{
			return -1;
		}
		#endregion

		#region 私有函数

		#endregion

		#region 事件函数

		#endregion
	}
}