using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Harry.LabTools.LabComm
{
	public partial class CommBase : ICommParam
	{
		#region 变量定义

		#endregion

		#region 属性定义
		public virtual string Name
		{
			get
			{
				return string.Empty;
			}
			set
			{
			}
		}
		public virtual int Index
		{
			get
			{
				return -1;
			}
			set
			{
			}
		}
		public virtual string Info
		{
			get
			{
				return string.Empty;
			}
			set
			{
			}
		}
		public virtual int Timeout
		{
			get
			{
				return 200;
			}
			set
			{
			}
		}

		public bool IsMultipleAddr
		{
			get
			{
				return false;
			}
			set
			{
			}
		}
		public virtual string BaudRate
		{
			get
			{
				return "115200";
			}
			set
			{
			}
		}
		public virtual string Parity
		{
			get;
			set;
		}
		public virtual string DataBits
		{
			get;
			set;
		}
		public virtual string StopBits
		{
			get;
			set;
		}

		public int ID
		{
			get
			{
				return -1;
			}
			set
			{
			}
		}
		public virtual int VID
		{
			get
			{
				return -1;
			}
			set
			{
			}
		}
		public virtual int PID
		{
			get
			{
				return -1;
			}
			set
			{
			}
		}
		
	
		#endregion

		#region 构造函数

		#endregion

		#region 公有函数

		#endregion

		#region 私有函数

		#endregion

	}
}
