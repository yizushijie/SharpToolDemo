using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Harry.LabTools.LabControlPlus
{
	internal static class CMessageBoxPlusHelp
	{
		/// <summary>
		/// 子窗体自动显示在父窗体中心位置
		/// </summary>
		/// <param name="owner">要中心化子窗体的窗体</param>
		/// <remarks>扩展方法</remarks>
		public static void MessageBoxCenterTask(Form ownerForm)
		{
			MessageBoxCenterHelp _messageBoxCenterTask = new MessageBoxCenterHelp(ownerForm);
		}

		/// <summary>
		/// 基于Hook实现子窗体自动显示在父窗体中心位置
		/// </summary>
		private class MessageBoxCenterHelp
		{
			#region 变量定义

			/// <summary>
			/// idHoot类型
			///
			/// </summary>
			private const Int32 WH_MSGFILTER = -1;            // 线程级; 截获用户与控件交互的消息

			private const Int32 WH_JOURNALRECORD = 0;       // 系统级; 记录所有消息队列从消息队列送出的输入消息, 在消息从队列中清除时发生; 可用于宏记录
			private const Int32 WH_JOURNALPLAYBACK = 1;     // 系统级; 回放由 WH_JOURNALRECORD 记录的消息, 也就是将这些消息重新送入消息队列
			private const Int32 WH_KEYBOARD = 2;            // 系统级或线程级; 截获键盘消息
			private const Int32 WH_GETMESSAGE = 3;          // 系统级或线程级; 截获从消息队列送出的消息
			private const Int32 WH_CALLWNDPROC = 4;         // 系统级或线程级; 截获发送到目标窗口的消息, 在 SendMessage 调用时发生
			private const Int32 WH_CBT = 5;                 // 系统级或线程级; 截获系统基本消息, 譬如: 窗口的创建、激活、关闭、最大最小化、移动等等
			private const Int32 WH_SYSMSGFILTER = 6;        // 系统级; 截获系统范围内用户与控件交互的消息
			private const Int32 WH_MOUSE = 7;               // 系统级或线程级; 截获鼠标消息
			private const Int32 WH_HARDWARE = 8;            // 系统级或线程级; 截获非标准硬件(非鼠标、键盘)的消息
			private const Int32 WH_DEBUG = 9;               // 系统级或线程级; 在其他钩子调用前调用, 用于调试钩子
			private const Int32 WH_SHELL = 10;              // 系统级或线程级; 截获发向外壳应用程序的消息
			private const Int32 WH_FOREGROUNDIDLE = 11;     // 系统级或线程级; 在程序前台线程空闲时调用
			private const Int32 WH_CALLWNDPROCRET = 12;     // 系统级或线程级; 截获目标窗口处理完毕的消息, 在 SendMessage 调用后发生
			private const Int32 HCBT_ACTIVATE = 5;          // 系统激活一个窗口
			private const Int32 GWL_EXSTYLE = -20;            // 获得扩展窗口风格。
			private const Int32 GWL_STYLE = -16;              // 获得窗口风格。
			private const Int32 GWL_WNDPROC = -4;             // 获得窗口过程的地址，或代表窗口过程的地址的句柄。必须使用GWL_WNDPROC函数调用窗口过程。

			private const Int32 GWL_HINSTANCE = -6;          // 获得应用事例的句柄。
			private const Int32 GWL_HWNDPAAENT = -8;          // 如果父窗口存在，获得父窗口句柄。
			private const Int32 GWL_ID = -12;                 // 获得窗口标识。
			private const Int32 GWL_USERDATA = -21;           // 获得与窗口有关的32位值。每一个窗口均有一个由创建该窗口的应用程序使用的32位值。

			private IntPtr _hhk;    // 钩子句柄
			private IntPtr _parent; // 父窗体句柄
			private GCHandle _gch;   // 提供用于从非托管内存访问托管对象的方法

			#endregion 变量定义

			#region 构造函数

			/// <summary>
			///
			/// </summary>
			public MessageBoxCenterHelp()
			{
			}

			/// <summary>
			/// 有参数构造函数
			/// </summary>
			public MessageBoxCenterHelp(Form ownerForm)
			{
				if (ownerForm!=null)
				{
					this.PrepRun(ownerForm);
				}
			}

			#endregion 构造函数

			#region 函数定义

			/// <summary>
			/// 消息窗体在父窗体中居中显示
			/// </summary>
			/// <param name="ownerForm"></param>
			private void PrepRun(Form ownerForm)
			{
				//定义委托事件
				NativeMethods.MessageBoxCenterProcDelegate _delegateMessageBoxCenter = new NativeMethods.MessageBoxCenterProcDelegate(MessageBoxCenterCallBack);

				// 分配新的GCHandle，保护对象不被垃圾回收
				_gch=GCHandle.Alloc(_delegateMessageBoxCenter);

				//父窗体句柄
				_parent=ownerForm.Handle;

				// 注意：dwThreadId为System.Threading.Thread.CurrentThread.ManagedThreadId不起作用

				/// new IntPtr(NativeMethods.GetWindowLong(parentFormHandle, -6)), NativeMethods.GetCurrentThreadId()
				//_hhk = NativeMethods.SetWindowsHookEx(WH_CBT, _delegateMessageBoxCenter, IntPtr.Zero, NativeMethods.GetCurrentThreadId());
				_hhk=NativeMethods.SetWindowsHookEx(WH_CBT, _delegateMessageBoxCenter, new IntPtr(NativeMethods.GetWindowLong(_parent, GWL_HINSTANCE)), NativeMethods.GetCurrentThreadId());
			}

			/// <summary>
			/// 获取窗体的位置
			/// </summary>
			/// <param name="nCode">系统时间模式</param>
			/// <param name="wParam">要激活的窗口句柄<</param>
			/// <param name="lParam">指向CBTACTIVATESTRUCT结构</param>
			/// <returns>0 执行,1 阻止</returns>
			private IntPtr MessageBoxCenterCallBack(Int32 nCode, IntPtr wParam, IntPtr lParam)
			{
				if (nCode==HCBT_ACTIVATE)
				{
					//父窗体的位置信息
					NativeMethods.RECT _formRect;
					NativeMethods.GetWindowRect(_parent, out _formRect);

					//子窗体的位置信息
					NativeMethods.RECT _messageBoxRect;
					NativeMethods.GetWindowRect(wParam, out _messageBoxRect);

					//计算窗体位置
					Int32 _width = _messageBoxRect.right-_messageBoxRect.left;            //消息窗体的宽度
					Int32 _height = _messageBoxRect.bottom-_messageBoxRect.top;           //消息窗体的高度
					Int32 _xPos = (_formRect.left+_formRect.right-_width)>>1;         //X轴的位置
					Int32 _yPos = (_formRect.top+_formRect.bottom-_height)>>1;        //Y轴的位置

					//将消息窗体移动到父窗体的中心位置
					NativeMethods.MoveWindow(wParam, _xPos, _yPos, _width, _height, false);

					//卸载钩子句柄
					NativeMethods.UnhookWindowsHookEx(_hhk);

					//释放分配的GCHandle
					_gch.Free();
				}

				//允许操作
				return IntPtr.Zero;
			}

			#endregion 函数定义
		}

		private static class NativeMethods
		{
			/// <summary>
			/// internal 访问仅限于当前程序集
			/// </summary>
			internal struct RECT
			{
				public Int32 left;
				public Int32 top;
				public Int32 right;
				public Int32 bottom;
			}

			#region API函数

			/// <summary>
			/// 委托声明
			/// </summary>
			/// <param name="nCode">HCBT_ACTIVATE：系统将要激活一个窗口</param>
			/// <param name="wParam">要激活的窗口句柄</param>
			/// <param name="lParam">指向CBTACTIVATESTRUCT结构</param>
			/// <returns></returns>
			internal delegate IntPtr MessageBoxCenterProcDelegate(Int32 nCode, IntPtr wParam, IntPtr lParam);

			/// <summary>
			/// WinAPI用于设置钩子
			/// </summary>
			/// <param name="idHook">钩子类型</param>
			/// <param name="lpfn">函数指针</param>
			/// <param name="hMod">包含钩子函数的模块(EXE、DLL)句柄; 一般是 HInstance; 如果是当前线程这里可以是 0</param>
			/// <param name="dwThreadId">关联的线程; 可用 GetCurrentThreadId 获取当前线程; 0 表示是系统级钩子</param>
			/// <returns>返回钩子的句柄; 0 表示失败</returns>
			[DllImport("user32.dll", SetLastError = true)]
			internal static extern IntPtr SetWindowsHookEx(Int32 idHook, MessageBoxCenterProcDelegate lpfn, IntPtr hMod, Int32 dwThreadId);

			/// <summary>
			/// 释放钩子
			/// </summary>
			/// <param name="hhk">钩子句柄</param>
			/// <returns>成功True;失败false</returns>
			[DllImport("user32.dll")]
			[return: MarshalAs(UnmanagedType.Bool)]
			internal static extern Boolean UnhookWindowsHookEx(IntPtr hhk);

			/// <summary>
			/// 函数获得有关指定窗口的信息，函数也获得在额外窗口内存中指定偏移位地址的32位度整型值
			/// </summary>
			/// <param name="hWnd">窗口句柄</param>
			/// <param name="nIndex">指定要检索的基于0的的偏移量</param>
			/// <returns></returns>
			[DllImport("user32.dll", SetLastError = true)]
			internal static extern int GetWindowLong(IntPtr hWnd, int nIndex);

			/// <summary>
			/// 获得整个窗口的范围矩形，窗口的边框、标题栏、滚动条及菜单等都在这个矩形内
			/// </summary>
			/// <param name="hWnd">窗口句柄</param>
			/// <param name="lpRect">指向一个RECT结构的指针，该结构接收窗口的左上角和右下角的屏幕坐标</param>
			/// <returns>返回值：如果函数成功，返回值为非零：如果函数失败，返回值为零</returns>
			[DllImport("user32.dll")]
			[return: MarshalAs(UnmanagedType.Bool)]
			internal static extern Boolean GetWindowRect(IntPtr hWnd, out RECT lpRect);

			/// <summary>
			/// 该函数改变指定窗口的位置和尺寸。对于顶层窗口，位置和尺寸是相对于屏幕的左上角的：对于子窗口，位置和尺寸是相对于父窗口客户区的左上角坐标的
			/// </summary>
			/// <param name="hWnd">窗口句柄</param>
			/// <param name="nX">指定窗口的新位置的左边界</param>
			/// <param name="nY">指定窗口的新位置的顶部边界</param>
			/// <param name="nWidth">指定窗口的新的宽度</param>
			/// <param name="nHeight">指定窗口的新的高度</param>
			/// <param name="bRepaint">>是否刷新窗体</param>
			/// <returns></returns>
			[DllImport("user32.dll")]
			[return: MarshalAs(UnmanagedType.Bool)]
			internal static extern Boolean MoveWindow(IntPtr hWnd, Int32 nX, Int32 nY, Int32 nWidth, Int32 nHeight, [MarshalAs(UnmanagedType.Bool)]Boolean bRepaint);

			/// <summary>
			/// 改变窗口的位置与状态
			/// </summary>
			/// <param name="hWnd">窗口句柄</param>
			/// <param name="hWndInsertAfter">窗口的 Z 顺序</param>
			/// <param name="nX">以客户坐标指定窗口新位置的左边界</param>
			/// <param name="nY">以客户坐标指定窗口新位置的顶边界</param>
			/// <param name="nWidth">以像素指定窗口的新的宽度</param>
			/// <param name="nHeight">以像素指定窗口的新的高度</param>
			/// <param name="uFlags">窗口尺寸和定位的标志</param>
			/// <returns></returns>
			[DllImport("user32.dll")]
			[return: MarshalAs(UnmanagedType.Bool)]
			internal static extern Boolean SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int nX, int nY, int nWidth, int nHeight, int uFlags);

			/// <summary>
			/// 获取当前线程一个唯一的线程标识符
			/// </summary>
			/// <returns>当前的线程标识符</returns>
			[DllImport("kernel32.dll")]
			internal static extern Int32 GetCurrentThreadId();

			#endregion API函数
		}
	}
}