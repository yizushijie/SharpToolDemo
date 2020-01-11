using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Harry.LabTools.LabToVisualStudio
{
    public partial class CProjectGroup
	{
		#region 变量定义

		/// <summary>
		/// 名称
		/// </summary>
		private string defaultName = null;

		/// <summary>
		/// 文件
		/// </summary>
		private List<CProjectFile> defaultFile = null;

		/// <summary>
		/// 子群
		/// </summary>
		private List<CProjectGroup> defaultChildGroup = null;

		/// <summary>
		/// 主群
		/// </summary>
		private CProjectGroup defaultParentGroup = null;

		/// <summary>
		/// 不包含
		/// </summary>
		private List<string> defaultExclude= null;

		#endregion

		#region 属性定义

		/// <summary>
		/// 
		/// </summary>
		public string mName
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
		public List<CProjectFile> mFile
		{
			get
			{
				return this.defaultFile;
			}
			set
			{
				this.defaultFile = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public List<CProjectGroup> mChildGroup
		{
			get
			{
				return this.defaultChildGroup;
			}
			set
			{
				this.defaultChildGroup = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public CProjectGroup mParentGroup
		{
			get
			{
				return this.defaultParentGroup;
			}
			set
			{
				this.defaultParentGroup = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public List<string> mExclude
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
		/// <summary>
		/// 全称呼
		/// </summary>
		public string mFullName
		{
			get
			{
				if (this.defaultParentGroup == null)
				{
					return this.defaultName;
				}
				else
				{
					return this.defaultParentGroup.mFullName + "/" + this.defaultName;
				}
			}
		}
		#endregion

		#region 构造函数

		/// <summary>
		/// 
		/// </summary>
		/// <param name="masterGroup"></param>
		public CProjectGroup()
		{
			this.defaultParentGroup = null;
			this.defaultExclude = new List<string>();
			this.defaultFile = new List<CProjectFile>();
			this.defaultChildGroup = new List<CProjectGroup>();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="masterGroup"></param>
		public CProjectGroup(CProjectGroup masterGroup )
		{
			this.defaultParentGroup = masterGroup;
			this.defaultExclude = new List<string>();
			this.defaultFile = new List<CProjectFile>();
			this.defaultChildGroup = new List<CProjectGroup>();
		}

		#endregion

		#region 公共函数

		/// <summary>
		///
		/// </summary>
		/// <param name="prjGroup"></param>
		/// <param name="exclude"></param>
		/// <param name="_return"></param>
		/// <returns></returns>
		public List<string> GetPath(List<CProjectGroup> prjGroup, string exclude, List<string> _return = null)
		{
			if (_return == null)
			{
				_return = new List<string>();
			}
			foreach (CProjectGroup temp in prjGroup)
			{
				if (temp.defaultExclude.Contains(exclude))
				{
					continue;
				}
				_return.Add("[\"" + temp.mFullName + "\"] = { \"" + string.Join("\" , \"", from file in temp.defaultFile where (!file.mExclude.Contains(exclude)) select file.mName) + "\" }");
				this.GetPath(temp.defaultChildGroup, exclude, _return);
			}
			return _return;
		}

		/// <summary>
		///
		/// </summary>
		/// <param name="prjGroup"></param>
		/// <param name="exclude"></param>
		/// <returns></returns>
		public List<string> GetFile(List<CProjectGroup> prjGroup, string exclude)
		{
			List<string> _return = new List<string>();
			foreach (var temp in prjGroup)
			{
				if (temp.defaultExclude.Contains(exclude))
				{
					break;
				}
				_return.AddRange(from file in temp.defaultFile where (!file.mExclude.Contains(exclude)) select file.mName);
				_return.AddRange(this.GetFile(temp.defaultChildGroup, exclude));
			}
			return _return;
		}

		#endregion

	}
}
