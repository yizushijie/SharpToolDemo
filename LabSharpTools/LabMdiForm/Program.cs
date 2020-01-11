using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Harry.LabTools.LabMdiForm
{
	static class Program
	{
		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			//---创建登录界面
			LabLoginForm frmLogin = new LabLoginForm();
			//--检查登录界面
			if (frmLogin.ShowDialog() == DialogResult.OK)
			{
				//---释放登录界面的志愿
				frmLogin.Dispose();
				//---创建主界面
				Application.Run(new LabMdiForm());
			}
		}
	}
}
