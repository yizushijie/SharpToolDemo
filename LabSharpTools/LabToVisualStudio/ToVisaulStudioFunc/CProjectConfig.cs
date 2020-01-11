using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Harry.LabTools.LabToVisualStudio
{
	public partial class CProjectConfig
	{
		#region 变量定义
		/// <summary>
		/// 名称
		/// </summary>
		private string defaultName = null;

		/// <summary>
		/// 宏定义
		/// </summary>
		///
		private List<string> defaultDefine = null;

		/// <summary>
		/// 包含路劲
		/// </summary>
		private List<string> defaultIncludePath = null;

		/// <summary>
		/// 预包含路劲
		/// </summary>Harry.LabTools.LabToVisualStudio
		private List<string> defaultPreInclude = null;

		/// <summary>
		/// 
		/// </summary>
		private bool defaulCMSIS = false;

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
		public virtual List<string> mDefine
		{
			get
			{
				return this.defaultDefine;
			}
			set
			{
				this.defaultDefine = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual List<string> mIncludePath
		{
			get
			{
				return this.defaultIncludePath;
			}
			set
			{
				this.defaultIncludePath = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual List<string> mPreInclude
		{
			get
			{
				return this.defaultPreInclude;
			}
			set
			{
				this.defaultPreInclude = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual bool mCMSIS
		{
			get
			{
				return this.defaulCMSIS;
			}
			set
			{
				this.defaulCMSIS = value;
			}
		}

		#endregion

		#region 构造函数

		/// <summary>
		/// 
		/// </summary>
		public CProjectConfig()
		{
			this.defaultName = string.Empty;
			this.defaultDefine = new List<string>();
			this.defaultIncludePath = new List<string>();
			this.defaultPreInclude = new List<string>();
			this.defaulCMSIS = false;
		}

		#endregion
	}
}
