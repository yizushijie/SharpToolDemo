using Microsoft.Win32;

namespace Harry.LabTools.LabGenFunc
{
	public partial class CGenFuncEXE
	{

		#region 函数定义

		/// <summary>
		/// 获取exe程序的路劲
		/// </summary>
		/// <param name="exeName"></param>
		/// <returns></returns>
		public static string GenFuncGetExeNamePatch(string exeName)
		{
			string _return = null;
			string softName = exeName;
			if (!softName.Contains(".exe"))
			{
				softName += ".exe";
			}
			string strKeyName = string.Empty;
			string softPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\";
			RegistryKey regKey = Registry.LocalMachine;
			RegistryKey regSubKey = regKey.OpenSubKey(softPath + softName, false);

			if (regSubKey!=null)
			{
				object objResult = regSubKey.GetValue(strKeyName);
				RegistryValueKind regValueKind = regSubKey.GetValueKind(strKeyName);
				if (regValueKind == Microsoft.Win32.RegistryValueKind.String)
				{
					_return = objResult.ToString();
				}
			}
			return _return;
		}
		#endregion
	}
}
