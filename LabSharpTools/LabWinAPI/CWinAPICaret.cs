using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Harry.LabTools.LabWinAPI
{

	/// <summary>
	/// 系统API调用插入符操作
	/// </summary>
	public class CWinAPICaret
	{
		#region 坐标结构
		/// <summary>
		/// 插入符的坐标
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct CaretPoint
		{
			public int X;
			public int Y;

			public CaretPoint(int x, int y)
			{
				this.X = x;
				this.Y = y;
			}
		}
		#endregion

		#region API调用

		/// <summary>
		/// 获取插入符的位置
		/// </summary>
		/// <param name="lpPoint"></param>
		/// <returns></returns>

		[DllImport("user32.dll")]
		public static extern bool GetCaretPos(out CaretPoint lpPoint);

		/// <summary>
		/// 创建插入符
		/// </summary>
		/// <param name="hWnd"></param>
		/// <param name="hBitmap"></param>
		/// <param name="nWidth"></param>
		/// <param name="nHeight"></param>
		/// <returns></returns>
		[DllImport("user32.dll")]
		public static extern bool CreateCaret(IntPtr hWnd, IntPtr hBitmap, int nWidth, int nHeight);

		/// <summary>
		/// 显示插入符
		/// </summary>
		/// <param name="hWnd"></param>
		/// <returns></returns>
		[DllImport("user32.dll")]
		public static extern bool ShowCaret(IntPtr hWnd);

		/// <summary>
		/// 隐藏插入符
		/// </summary>
		/// <param name="hWnd"></param>
		/// <returns></returns>
		[DllImport("User32.dll")]
		public static extern bool HideCaret(IntPtr hWnd);

		/// <summary>
		/// 设置插入符的位置
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns></returns>
		[DllImport("User32.dll")]
		public static extern bool SetCaretPos(int x, int y);

		/// <summary>
		/// 释放插入符
		/// </summary>
		/// <returns></returns>
		[DllImport("user32.dll")]
		public static extern bool DestroyCaret();

		/// <summary>
		/// 获取插入符闪烁的间隔
		/// </summary>
		/// <returns></returns>
		[DllImport("user32.dll")]
		public static extern uint GetCaretBlinkTime();

		/// <summary>
		/// 设置插入符闪烁的间隔
		/// </summary>
		/// <param name="uMSeconds"></param>
		/// <returns></returns>
		[DllImport("user32.dll")]
		public static extern bool SetCaretBlinkTime(uint uMSeconds);

		#endregion


	}
}
