using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Harry.LabTools.LabMcuFunc
{
	public partial class CMcuFuncAVR8BitsISP :CMcuFuncAVR8BitsBase
	{
		#region 变量定义

		#endregion

		#region 属性定义

		/// <summary>
		/// 软件版本为读写属性
		/// </summary>
		public override byte[] mSoftwareVersion
		{
			get
			{
				return base.mSoftwareVersion;
			}
			set
			{
				base.mSoftwareVersion = value;
			}
		}

		/// <summary>
		/// 硬件版本为读写属性
		/// </summary>
		public override byte[] mHardwareVersion
		{
			get
			{
				return base.mHardwareVersion;
			}
			set
			{
				base.mHardwareVersion = value;
			}
		}

		#endregion

		#region 构造函数

		/// <summary>
		/// 构造函数
		/// </summary>
		public CMcuFuncAVR8BitsISP ():base()
		{
			
		}

		#endregion

		#region 公有函数

		#endregion

		#region 私有函数

		#endregion

		#region 事件函数

		#endregion
	}
}
