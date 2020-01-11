using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Harry.LabTools.LabCommType
{
	public partial class CCommBase : ICommControl
	{
		#region 控件变量

		/// <summary>
		/// 端口属性
		/// </summary>
		private ComboBox defaultComboBox = null;

		/// <summary>
		/// 消息控件
		/// </summary>
		private RichTextBox defaultRichTextBox = null;

		/// <summary>
		/// 
		/// </summary>

		private Form defaultForm = null;

		#endregion

		#region 控件属性

		/// <summary>
		/// 端口名称使用的控件
		/// </summary>
		public virtual ComboBox mCCommComBox
		{
			get
			{
				return this.defaultComboBox;
			}
			set
			{
				this.defaultComboBox = value;
			}
		}

		/// <summary>
		/// 消息控件
		/// </summary>
		public virtual RichTextBox mCCommRichTextBox
		{
			get
			{
				return this.defaultRichTextBox;
			}
			set
			{
				this.defaultRichTextBox=value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual Form mCCommForm
		{
			get
			{
				return this.defaultForm;
			}
			set
			{
				this.defaultForm = value;
			}
		}

		#endregion

		/// <summary>
		/// 销毁控件
		/// </summary>
		public virtual void DestroyControl()
		{
            if (this.defaultRichTextBox!=null)
            {
                GC.SuppressFinalize(this.defaultRichTextBox);
            }
            if (this.defaultComboBox!=null)
            {
                GC.SuppressFinalize(this.defaultComboBox);
            }
            if (this.defaultForm!=null)
            {
                GC.SuppressFinalize(this.defaultForm);
            }
		}

	}
}
