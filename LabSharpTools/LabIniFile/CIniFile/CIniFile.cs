using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Harry.LabTools.LabIniFile
{
	public partial class CIniFile
	{
		#region 变量定义

		/// <summary>
		/// 文件路劲
		/// </summary>
		private string defaultFilePath=string.Empty;

		#endregion

		#region 属性定义

		/// <summary>
		/// 文件路径
		/// </summary>
		public virtual string mFilePath
		{
			get
			{
				return this.defaultFilePath;
			}
		}

		/// <summary>
		/// 文件路径是否存在
		/// </summary>
		public virtual bool mPathExists
		{
			get
			{
				return (!(string.IsNullOrEmpty(this.defaultFilePath)) && (File.Exists(this.defaultFilePath)));
			}
		}

		#endregion

		#region 构造函数

		/// <summary>
		/// 无参数构造函数
		/// </summary>
		public CIniFile()
		{
		
		}

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="path"></param>
		public CIniFile(string path,bool isAutoCreadte=false)
		{
			this.defaultFilePath = path;
			//---校验是否需要创建新的Ini文件
			if ((this.mPathExists==false)&&(isAutoCreadte==true))
			{
				FileStream file = System.IO.File.Create(path);
				file.Close();
				file.Dispose();
			}
		}

		#endregion

		#region 析构函数

		~CIniFile()
		{
			this.CIniFileUpdateFile();
		}

		#endregion

		#region 公共函数

		
		/// <summary>
		/// 清除某个Section
		/// </summary>
		/// <param name="Section"></param>
		public bool CIniFileEraseSection(string section)
		{
			return WritePrivateProfileString(section, null, null, this.defaultFilePath);
		}

		/// <summary>
		/// 删除某个Section下的键
		/// </summary>
		/// <param name="Section"></param>
		/// <param name="Ident"></param>
		public bool CIniFileDeleteKey(string section, string ident)
		{
			return WritePrivateProfileString(section, ident, null, this.defaultFilePath);
		}

		/// <summary>
		/// 在Win NT, 2000和XP上，都是直接写文件，没有缓冲，所以，无须实现UpdateFile 
		/// Note:对于Win9X，来说需要实现UpdateFile方法将缓冲中的数据写入文件
		/// 执行完对Ini文件的修改之后，应该调用本方法更新缓冲区。
		/// </summary>
		public bool CIniFileUpdateFile()
		{
			return WritePrivateProfileString(null, null, null, this.defaultFilePath);
		}

		/// <summary>
		/// 检查某个Section下的某个键值是否存在 
		/// </summary>
		/// <param name="Section"></param>
		/// <param name="Ident"></param>
		/// <returns></returns>
		public bool CIniFileValueExists(string section, string ident)
		{
			StringCollection Idents = new StringCollection();
			this.CIniFileReadSection(section, ref Idents);
			return Idents.IndexOf(ident) > -1;
		}

		/// <summary>
		/// 检查某个Section下的某个键值是否存在 
		/// </summary>
		/// <param name="Section"></param>
		/// <param name="Ident"></param>
		/// <returns></returns>
		public bool CIniFileSectionExists(string section)
		{
			StringCollection Idents = new StringCollection();
			this.CIniFileReadSection(section, ref Idents);
			return ((Idents.Count>0)?true:false);
		}
		#endregion

		#region 保护函数

		#endregion

		#region 私有函数

		#endregion

		#region 事件函数

		#endregion

		#region API函数

		/// <summary>
		/// 声明读写INI文件的API函数 
		/// </summary>
		/// <param name="section"></param>
		/// <param name="key"></param>
		/// <param name="val"></param>
		/// <param name="filePath"></param>
		/// <returns></returns>
		[DllImport("kernel32")]
		private static extern bool WritePrivateProfileString(string section, string key, string val, string filePath);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="section"></param>
		/// <param name="key"></param>
		/// <param name="def"></param>
		/// <param name="retVal"></param>
		/// <param name="size"></param>
		/// <param name="filePath"></param>
		/// <returns></returns>
		[DllImport("kernel32")]
		private static extern int GetPrivateProfileString(string section, string key, string def, byte[] retVal, int size, string filePath);
		#endregion

	}
}
