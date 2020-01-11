using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Harry.LabTools.LabControlPlus
{
	/// <summary>
	///
	/// </summary>
	public class CCheckedListBoxEx : CheckedListBox
	{

		#region 变量定义

		#endregion

		#region 属性定义

		#endregion

		#region 构造函数

		/// <summary>
		/// 
		/// </summary>
		public CCheckedListBoxEx()
		{
			//设置控件风格
			this.SetStyle(ControlStyles.AllPaintingInWmPaint |  //全部在窗口绘制消息中绘图
							ControlStyles.OptimizedDoubleBuffer,    //使用双缓冲
							true
						);
		}

		#endregion

		#region 析构函数

		#endregion

		#region 公共函数

		#endregion

		#region 保护函数

		/// <summary>
		/// 重新绘制选中是的背景为透明色
		/// </summary>
		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			//Color.Black --- 为字体颜色
			DrawItemEventArgs e2 = new DrawItemEventArgs(e.Graphics, e.Font, new Rectangle(e.Bounds.Location, e.Bounds.Size), e.Index, (e.State & DrawItemState.Focus) == DrawItemState.Focus ? DrawItemState.Focus : DrawItemState.None, Color.Black, this.BackColor);
			base.OnDrawItem(e2);
		}

		#endregion

		#region 私有函数

		#endregion

		#region 事件函数

		#endregion

	}
}
