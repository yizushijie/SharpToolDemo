using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Harry.LabTools.LabControlPlus
{
	/// <summary>
	/// 修改显示的内容为16进制的格式
	/// </summary>
	public partial class CNumericUpDownEx : NumericUpDown
	{

		#region 变量定义

		#endregion

		#region 属性定义

		/// <summary>
		/// 
		/// </summary>
		public override string Text
		{
			get
			{
				string temp = base.Text;
				if (base.Hexadecimal==true)
				{
					if (base.Maximum<256)
					{
						temp = (Convert.ToInt32(temp, 16)).ToString("X2");
					}
					else if (base.Maximum < 65536)
					{
						temp = (Convert.ToInt32(temp, 16)).ToString("X4");
					}
					else
					{
						temp = (Convert.ToInt32(temp, 16)).ToString("X8");
					}
				}
				return temp;
			}
			set
			{
				if (base.Hexadecimal == true)
				{
					//---将输入数字转换成16进制数据
					if (base.Maximum < 256)
					{

						base.Text = (Convert.ToInt32(value, 16)).ToString("X2");
					}
					else if (base.Maximum < 65536)
					{

						base.Text = (Convert.ToInt32(value, 16)).ToString("X4");
					}
					else
					{

						base.Text = (Convert.ToInt32(value, 16)).ToString("X8");
					}
					//---刷新控件
					this.Invalidate();
				}
				else
				{
					base.Text = value;
				}
			}
		}

		#endregion

		#region 构造函数

		/// <summary>
		/// 
		/// </summary>
		public CNumericUpDownEx()
		{
			//设置控件风格
			this.SetStyle(ControlStyles.AllPaintingInWmPaint |  //全部在窗口绘制消息中绘图
							ControlStyles.OptimizedDoubleBuffer,    //使用双缓冲
							true
						);
		}

		#endregion

		#region 事件定义

		#endregion

		#region 函数定义

		#endregion


	}
}
