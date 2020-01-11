using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Harry.LabTools.LabCommType
{
	public partial class CCommUSB : CCommBase
	{
		#region 变量定义

		#endregion

		#region 属性定义

		#endregion

		#region 构造函数

		/// <summary>
		/// 构造函数
		/// </summary>
		public CCommUSB():base()
		{
		
		}

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="cbb"></param>
		/// <param name="msg"></param>
		public CCommUSB(ComboBox cbb = null, RichTextBox msg = null)
		{
			this.Init(cbb, msg);
		}

		#endregion

		#region 析构函数

		/// <summary>
		/// 
		/// </summary>
		~CCommUSB()
		{
			this.Dispose();
		}

		/// <summary>
		/// 
		/// </summary>
		public override void Dispose()
		{
			base.Dispose();
			GC.SuppressFinalize(this);
		}

		#endregion

		#region 公有函数

		#endregion

		#region 私有函数

		#endregion

		#region 事件函数

		#endregion
	}
}
