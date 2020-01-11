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
			LabLoginForm frmLogin = new LabLoginForm();
			if (frmLogin.ShowDialog() == DialogResult.OK)
			{
				Application.Run(new LabMdiForm());
			}
		}
	}
}
