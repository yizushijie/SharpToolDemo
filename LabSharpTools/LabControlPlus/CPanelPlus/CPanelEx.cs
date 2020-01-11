using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using Harry.LabTools.LabWinAPI;
using Harry.LabTools.LabGenFunc;

namespace Harry.LabTools.LabControlPlus
{

	/// <summary>
	/// 使用本控件是嵌套外部exe应用，不支持计算器
	/// </summary>
	public partial class CPanelEx : Panel
	{

		#region 变量定义

		/// <summary>
		/// 
		/// </summary>
		private readonly ManualResetEvent EventDone = new ManualResetEvent(false);

		/// <summary>
		/// 
		/// </summary>
		private Process defaultProcess = null;

		/// <summary>
		/// 
		/// </summary>
		private IntPtr defaultEmbededWindowHandle=(IntPtr)0;

		#endregion

		#region 属性定义

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

		#region 构造函数
		public CPanelEx()
		{
			InitializeComponent();
		}


		#endregion

		#region 重载函数

		/// <summary>
		/// 句柄销毁
		/// </summary>
		/// <param name="e"></param>
		protected override void OnHandleDestroyed(EventArgs e)
		{
			this.KillProcess();
			base.OnHandleDestroyed(e);
		}

		/// <summary>
		/// 大小重置
		/// </summary>
		/// <param name="e"></param>
		protected override void OnResize(EventArgs e)
		{
			if (defaultProcess != null)
			{
				CWinAPIWindows.MoveWindow(this.defaultProcess.MainWindowHandle, 0, 0, this.Width, this.Height, true);
			}

			base.OnResize(e);
		}

		/// <summary>
		/// 尺寸发生改变
		/// </summary>
		/// <param name="e"></param>
		protected override void OnSizeChanged(EventArgs e)
		{
			this.Invalidate();
			base.OnSizeChanged(e);
		}

		#endregion

		#region 私有函数定义

		/// <summary>
		/// 启动外进程
		/// </summary>
		/// <param name="appPath"></param>
		/// <returns></returns>
		private Process StartProcess(string appPath)
		{
			if (!File.Exists(appPath))
			{
				return null;
			}
			ProcessStartInfo info = new ProcessStartInfo(appPath)
			{
				//UseShellExecute = true,
				//CreateNoWindow = true,
				UseShellExecute = false,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				RedirectStandardInput= true,
				CreateNoWindow = true,
				WindowStyle = ProcessWindowStyle.Minimized
			};
			Process process = Process.Start(info);

			//if ((process==null)||(process.HasExited==true))
			//{
			//	///process = new Process();
			//	//process.StartInfo.FileName = appPath;
			//	process.Kill();
			//}

			return process;
		}

		/// <summary>
		/// 关闭外进程
		/// </summary>
		/// <param name="process"></param>
		private void KillProcess(Process process)
		{
			if ((process != null) && (!process.HasExited))
			{
				process.Kill();
			}
		}


		/// <summary>
		/// 将外进程嵌入到当前程序
		/// </summary>
		/// <param name="process"></param>
		private bool EmbeddedProcess(Process process)
		{
			//---是否嵌入成功标志，用作返回值
			bool isEmbedSuccess = false;
			//---外进程句柄
			IntPtr processHwnd = process.MainWindowHandle;
			//---容器句柄
			IntPtr panelHwnd = this.Handle;

			if (processHwnd != (IntPtr)0 && panelHwnd != (IntPtr)0)
			{
				//---把本窗口句柄与目标窗口句柄关联起来
				int setTime = 0;
				while (!isEmbedSuccess && setTime < 10)
				{
					isEmbedSuccess = (CWinAPIWindows.SetParent(processHwnd, panelHwnd) != 0);
					CGenFuncDelay.GenFuncDelayms(150);
					//Thread.Sleep(100);
					setTime++;
				}
				//---设置初始尺寸和位置
				CWinAPIWindows.MoveWindow(this.defaultProcess.MainWindowHandle, 0, 0, this.Width, this.Height, true);
				// Remove border and whatnot               
				//---移除边框和右上角的最大，最小和关闭功能
				CWinAPIWindows.SetWindowLong(new HandleRef(this, this.defaultProcess.MainWindowHandle), CWinAPIWindows.GWL_STYLE, CWinAPIWindows.WS_VISIBLE);
			}

			if (isEmbedSuccess)
			{
				this.defaultEmbededWindowHandle = this.defaultProcess.MainWindowHandle;
			}

			return isEmbedSuccess;
		}


		

		#endregion

		#region 公有函数定义

		/// <summary>
		/// 嵌入进程
		/// </summary>
		/// <param name="processPath"></param>
		/// <returns></returns>
		public bool EmbeddedProcess(string processPath)
		{
			bool isStartAndEmbedSuccess = false;
			this.EventDone.Reset();

			//---启动进程
			this.defaultProcess = this.StartProcess(processPath);
			
			if (this.defaultProcess == null)
			{
				return false;
			}

			//---等待新进程完成它的初始化并等待用户输入
			this.defaultProcess.WaitForInputIdle();

			//---确保可获取到句柄
			Thread thread = new Thread(new ThreadStart(() =>
			{
				while (true)
				{
					if (this.defaultProcess.MainWindowHandle != (IntPtr)0)
					{
						this.EventDone.Set();
						break;
					}
					//---
					CGenFuncDelay.GenFuncDelayms(20);
					//Thread.Sleep(10);
				}
			}));
			thread.Start();

			//---嵌入进程
			if (this.EventDone.WaitOne(10000))
			{
				isStartAndEmbedSuccess = this.EmbeddedProcess(defaultProcess);
				if (!isStartAndEmbedSuccess)
				{
					this.KillProcess(this.defaultProcess);
				}
			}
			return isStartAndEmbedSuccess;
		}

		
		/// <summary>
		/// 关闭进程
		/// </summary>
		public void KillProcess()
		{
			this.KillProcess(this.defaultProcess);
		}


		/// <summary>
		/// 嵌入已经存在的进程
		/// </summary>
		/// <param name="process"></param>
		/// <returns></returns>
		public bool EmbeddedExistedProcess(Process process)
		{
			this.defaultProcess = process;

			return this.EmbeddedProcess(process);
		}


		/// <summary>
		/// 关闭指定名称的进程
		/// </summary>
		/// <param name="strProcessesByName"></param>
		public  void KillProcess(string strProcessesByName)
		{
			foreach (Process p in Process.GetProcesses())
			{
				if (p.ProcessName.ToUpper().Contains(strProcessesByName.ToUpper()))
				{
					try
					{
						//---杀死指定的线程
						p.Kill();
						//---等待退出
						p.WaitForExit(); // possibly with a timeout
					}
					catch (Win32Exception e)
					{
						// process was terminating or can't be terminated - deal with it
						MessageBox.Show(e.Message.ToString());   
					}
					catch (InvalidOperationException e)
					{
						// process has already exited - might be able to let this one go
						MessageBox.Show(e.Message.ToString()); 
					}
				}
			}
		}

		#endregion

	}
}
