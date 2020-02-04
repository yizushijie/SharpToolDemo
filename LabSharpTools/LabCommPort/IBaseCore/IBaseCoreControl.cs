using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Harry.LabTools.LabCommPort
{

	/// <summary>
	/// 使用的控件
	/// </summary>
	interface ICommControl
	{
		#region 属性定义
		/// <summary>
		/// 通讯端口
		/// </summary>
		ComboBox mCCommComBox
		{
			get;
			set;
		}

		/// <summary>
		/// 消息控件
		/// </summary>
		RichTextBox mCCommRichTextBox
		{
			get;
			set;
		}

		/// <summary>
		/// 窗体控件
		/// </summary>
		Form mCCommForm
		{
			get;
			set;
		}
		#endregion

		#region 函数定义
		/// <summary>
		/// 释放使用的控件
		/// </summary>
		/// <returns></returns>
		void DestroyControl();
		#endregion


	}
}
