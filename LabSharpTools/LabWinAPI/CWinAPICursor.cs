using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Harry.LabTools.LabWinAPI
{
	/// <summary>
	/// 光标
	/// </summary>
	public  class CWinAPICursor
	{
		#region 变量定义

		[StructLayout(LayoutKind.Sequential)]
		struct CURSORINFO
		{
			public int cbSize;
			public int flags;
			public IntPtr hCursor;
			public Point ptScreenPos;
		}
		
		private const int CURSOR_SHOWING = 0x00000001;

		#endregion

		#region API

		/// <summary>
		/// 
		/// </summary>
		/// <param name="pci"></param>
		/// <returns></returns>
		[DllImport("user32.dll")]
		static extern bool GetCursorInfo(out CURSORINFO pci);



		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static Cursor GetMouseCursor()
		{
			CURSORINFO vCurosrInfo;
			vCurosrInfo.cbSize = Marshal.SizeOf(typeof(CURSORINFO));
			GetCursorInfo(out vCurosrInfo);
			Cursor vCursor = new Cursor(vCurosrInfo.hCursor);
			return vCursor;
		}

		/// <summary>
		/// 获取鼠标的位置
		/// </summary>
		/// <param name="pt"></param>
		/// <returns></returns>
		[DllImport("user32.dll")]
		public static extern bool GetCursorPos(out Point pt);

		#endregion
	}
}
