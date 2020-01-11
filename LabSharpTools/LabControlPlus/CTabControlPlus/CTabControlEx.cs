using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Harry.LabTools.LabControlPlus
{
	public partial class CTabControlEx : TabControl
	{
		#region 变量定义

		#endregion

		#region	属性定义

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
				}
				return cp;
			}
		}

		#endregion

		#region 构造函数

		/// <summary>
		/// 
		/// </summary>
		public CTabControlEx()
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

		#endregion

		#region 私有函数

		#endregion

		#region 事件函数

		#endregion

	}
}
