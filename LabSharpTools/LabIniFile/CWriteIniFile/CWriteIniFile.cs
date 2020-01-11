using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Harry.LabTools.LabIniFile
{
	public partial class CIniFile
	{

		#region 公共函数

		/// <summary>
		/// 写入Ini
		/// </summary>
		/// <param name="section"></param>
		/// <param name="key"></param>
		/// <param name="value"></param>
		public bool CIniFileWriteValue(string section, string key, string value)
		{
			return WritePrivateProfileString(section, key, value, this.defaultFilePath);
		}

		/// <summary>
		/// 写INI文件 
		/// </summary>
		/// <param name="Section"></param>
		/// <param name="Ident"></param>
		/// <param name="Value"></param>
		public bool CIniFileWriteString(string section, string ident, string value)
		{
			return WritePrivateProfileString(section, ident, value, this.defaultFilePath);
		}

		/// <summary>
		/// 在给定的"小结"中写入整形"键"值 
		/// </summary>
		/// <param name="Section">小结</param>
		/// <param name="Ident">键</param>
		/// <param name="Value">整形键值</param>
		public bool CIniFileWriteInt(string section, string ident, int value)
		{
			return CIniFileWriteString(section, ident, value.ToString());
		}

		/// <summary>
		/// 写Bool 
		/// </summary>
		/// <param name="Section">小结</param>
		/// <param name="Ident">键</param>
		/// <param name="Value">键值</param>
		public bool CIniFileWriteBool(string section, string ident, bool value)
		{
			return CIniFileWriteString(section, ident, Convert.ToString(value));
		}

		#endregion

		#region 保护函数

		#endregion

		#region 私有函数

		#endregion


	}
}