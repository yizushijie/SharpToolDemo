using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Harry.LabTools.LabToVisualStudio
{
	public class CProjectFile
	{
		#region 变量定义
		/// <summary>
		/// 名称
		/// </summary>
		private string defaultName=null;

		/// <summary>
		/// 不包含
		/// </summary>
		private List<string> defaultExclude= null;

		#endregion

		#region 属性定义

		/// <summary>
		/// 
		/// </summary>
		public virtual string mName
		{
			get
			{
				return this.defaultName;
			}
			set
			{
				this.defaultName = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual List<string> mExclude
		{
			get
			{
				return this.defaultExclude;
			}
			set
			{
				this.defaultExclude = value;
			}
		}

		#endregion

		#region 构造函数

		/// <summary>
		/// 无参数构造函数
		/// </summary>
		public CProjectFile()
		{
			this.defaultName = string.Empty;
			this.defaultExclude = new List<string>();
		}
		#endregion

	}
}
