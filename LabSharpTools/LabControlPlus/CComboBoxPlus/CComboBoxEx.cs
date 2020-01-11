using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Harry.LabTools.LabControlPlus
{
	public partial class CComboBoxEx : ComboBox
	{

		#region 构造函数

		/// <summary>
		/// 系统类型
		/// </summary>
		private Boolean IsXpOr2003
		{
			get
			{
				OperatingSystem os = Environment.OSVersion;
				Version vs = os.Version;
				if (os.Platform == PlatformID.Win32NT)
				{
					if ((vs.Major == 5) && (vs.Minor != 0))
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				else
				{
					return false;
				}
			}
		}

		/// <summary>
		/// 设置控件窗口创建参数的扩展风格
		/// </summary>
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				// Turn on WS_EX_COMPOSITED    
				cp.ExStyle |= 0x02000000;
				if (this.IsXpOr2003 == true)
				{
					// Turn on WS_EX_LAYERED  
					cp.ExStyle |= 0x00080000;
					//---设置窗体不透明度
					//this.Opacity = 1;
				}
				return cp;
			}
		}

		#endregion


		#region	属性定义

		#endregion

		#region 构造函数

		/// <summary>
		/// 
		/// </summary>
		public CComboBoxEx()
		{
			//设置控件风格
			this.SetStyle(ControlStyles.AllPaintingInWmPaint |  //全部在窗口绘制消息中绘图
							ControlStyles.OptimizedDoubleBuffer,    //使用双缓冲
							true
						);
		}

		#endregion

		#region	 保护函数
		#endregion
		protected override void OnTextChanged(EventArgs e)
		{
			base.OnTextChanged(e);
		}

	}
}
