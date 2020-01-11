using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Harry.LabTools.LabCommType
{

	/// <summary>
	/// 使用的控件
	/// </summary>
	interface ICommControl
	{
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

		/// <summary>
		/// 释放使用的控件
		/// </summary>
		/// <returns></returns>
		void DestroyControl();

	}
}
