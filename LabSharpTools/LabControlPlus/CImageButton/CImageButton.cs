using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Harry.LabTools.LabControlPlus
{
	public partial class CImageButton : Button
	{
		#region	构造函数
		/// <summary>
		/// 
		/// </summary>
		public CImageButton()
		{
			InitializeComponent();
		}
		#endregion

		#region	析构函数

		#endregion

		#region 公共函数

		#endregion

		#region 保护函数

		/// <summary>
		/// 重载OnPaint方法
		/// </summary>
		/// <param name="e"></param>
		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			StringFormat sf = new StringFormat();
			sf.Alignment = StringAlignment.Near;
			sf.LineAlignment = StringAlignment.Near;
			if (BackgroundImage != null)
			{
				Image img = this.BackgroundImage;
				g.DrawImage(img, e.ClipRectangle, 0, 0, img.Width, img.Height, GraphicsUnit.Pixel);
			}
			g.DrawString(Text, Font, new SolidBrush(Color.Black), e.ClipRectangle, sf);
		}

		#endregion

		#region 私有函数

		#endregion

		#region 事件函数

		#endregion

	}
}
