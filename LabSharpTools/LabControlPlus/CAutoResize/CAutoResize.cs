using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Harry.LabTools.LabControlPlus
{
	/// <summary>
	/// 控件自适应大小
	/// </summary>
	public partial class CAutoSize
	{
		#region 变量定义

		/// <summary>
		/// 默认宽度
		/// </summary>
		private float defaultWidth = 0.0F;

		/// <summary>
		/// 默认高度
		/// </summary>
		private float defaultHeight = 0.0F;

		/// <summary>
		/// 第一次进入是默认尺寸，再次进入需要修改尺寸
		/// </summary>
		private bool defaultSize = false;

		#endregion

		#region 属性定义

		#endregion

		#region 构造函数

		/// <summary>
		/// 
		/// </summary>
		public CAutoSize()
		{

		}

		/// <summary>
		/// 
		/// </summary>
		public CAutoSize(Control cons)
		{
			this.ControlInit(cons);
		}

		#endregion
		
		#region 公共函数

		/// <summary>
		/// 
		/// </summary>
		public void ControlInit(Control cons)
		{
			this.defaultWidth = cons.Width;
			this.defaultHeight = cons.Height;
			this.defaultSize = false;
			this.ControlTag(cons);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cons"></param>
		public void ControlTag(Control cons)
		{
			foreach (Control con in cons.Controls)
			{
				con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;
				if (con.Controls.Count > 0)
				{
					ControlTag(con);
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="newWidth"></param>
		/// <param name="newHeight"></param>
		/// <param name="cons"></param>
		public void ControlResize(float newWidth, float newHeight, Control cons)
		{
			foreach (Control con in cons.Controls)
			{
				string[] myControlTag = con.Tag.ToString().Split(new char[] { ':' });
				float a = Convert.ToSingle(myControlTag[0]) * newWidth;
				con.Width = (int)a;
				a = Convert.ToSingle(myControlTag[1]) * newHeight;
				con.Height = (int)a;
				a = Convert.ToSingle(myControlTag[2]) * newWidth;
				con.Left = (int)a;
				a = Convert.ToSingle(myControlTag[3]) * newHeight;
				con.Top = (int)a;
				Single currentsize = Convert.ToSingle(myControlTag[4]) * Math.Min(newWidth, newHeight);
				con.Font = new Font(con.Font.Name, currentsize, con.Font.Style, con.Font.Unit);
				if (con.Controls.Count > 0)
				{
					this.ControlResize(newWidth, newHeight, con);
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void AutoResize(Control cons)
		{
			if (this.defaultSize == false)
			{
				this.defaultSize = true;
				return;
			}
			float newWidth = (cons.Width) / this.defaultWidth;
			float newHeight = (cons.Height) / this.defaultHeight;
			this.ControlResize(newWidth, newHeight, cons);
		}
		#endregion
	}
}
