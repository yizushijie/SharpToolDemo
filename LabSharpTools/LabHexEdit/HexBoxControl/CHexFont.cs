using System.Drawing;
using System.Windows.Forms;

namespace Harry.LabTools.LabHexEdit
{
	/// <summary>
	/// 计算字体的高度和宽度
	/// </summary>
	public partial class CHexBox 
	{
		/// <summary>
		/// 计算算字体的大小
		/// </summary>
		/// <returns></returns>
		private SizeF FontSize()
		{
			Graphics g = this.CreateGraphics();
			SizeF sizeF = g.MeasureString("00", this.defaultFont);
			g.Dispose();
			return sizeF;
		}

		/// <summary>
		/// 计算字体的大小
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		private SizeF FontSize(string str)
		{
			Graphics g = this.CreateGraphics();
			SizeF sizeF = g.MeasureString(str, this.defaultFont);
			g.Dispose();
			return sizeF;
		}

		/// <summary>
		/// 计算字体的大小
		/// </summary>
		/// <param name="str"></param>
		/// <param name="ft"></param>
		/// <returns></returns>
		private SizeF FontSize(string str, Font ft)
		{
			Graphics g = this.CreateGraphics();
			SizeF sizeF = g.MeasureString(str, ft);
			g.Dispose();
			return sizeF;
		}

		/// <summary>
		/// 计算字体的宽度
		/// </summary>
		/// <returns></returns>
		private int FontWidth()
		{
			SizeF size = FontSize("00", this.defaultFont);
			return (int)(size.Width-1.5);
		}

		/// <summary>
		/// 计算字体的宽度
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		private int FontWidth(string str)
		{
			SizeF size = FontSize(str, this.defaultFont);
			return (int)(size.Width-1.5);
		}

		/// <summary>
		/// 计算字体的宽度
		/// </summary>
		/// <param name="str"></param>
		/// <param name="ft"></param>
		/// <returns></returns>
		private int FontWidth(string str, Font ft)
		{
			SizeF size = FontSize(str, ft);
			return (int)(size.Width);
		}

		/// <summary>
		/// 计算字体的高度
		/// </summary>
		/// <returns></returns>
		private int FontHeigth()
		{
			SizeF size = FontSize("00", this.defaultFont);

			return (int)(size.Height);
		}

		/// <summary>
		/// 计算字体的高度
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		private int FontHeigth(string str)
		{
			SizeF size = FontSize(str, this.defaultFont);

			return (int)(size.Height);
		}

		/// <summary>
		/// 计算字体的高度
		/// </summary>
		/// <param name="str"></param>
		/// <param name="ft"></param>
		/// <returns></returns>defaultXScaleShow
		private int FontHeigth(string str, Font ft)
		{
			SizeF size = FontSize(str, ft);
			return (int)(size.Height);
		}


	}
}