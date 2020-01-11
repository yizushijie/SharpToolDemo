using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Harry.LabTools.LabCommType
{
    public partial class CCommSerialForm : CCommBaseForm
    {
		#region 变量函数

		#endregion

		#region 属性函数

		/// <summary>
		/// 每包字节的大小
		/// </summary>
		public override int mPerPackageMaxSize
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
		public CCommSerialForm() : base()
		{
			InitializeComponent();
		}

		#endregion

		#region 析构函数

		#endregion

		#region 公共函数

		#endregion

		#region 保护函数

		#endregion

		#region 私有函数

		#endregion

		#region 事件函数

		#endregion

	}
}
