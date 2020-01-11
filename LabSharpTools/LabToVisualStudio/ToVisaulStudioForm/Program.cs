using System;
using System.Linq;
using System.Windows.Forms;

namespace Harry.LabTools.LabToVisualStudio
{
	static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
		static void Main(string[] arg)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			//---判断路劲的长度
			if (arg.Count()>0)
			{
				string str = null;
				for (int i = 0; i < arg.Length; i++)
				{
					str += arg[i].ToString();
					//---路劲由于空格进行了分组，这里是将空格补上
					if ((i!=(arg.Length-1)))
					{
						str += " ";
					}
				}
				//MessageBox.Show(str);
                Application.Run(new ToVisualStudioForm(str));
			}
			else
			{
				Application.Run(new ToVisualStudioForm());
			}
			
		}
	}
}
