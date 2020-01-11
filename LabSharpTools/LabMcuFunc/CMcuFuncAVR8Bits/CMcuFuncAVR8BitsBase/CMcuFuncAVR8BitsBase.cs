using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Harry.LabTools.LabMcuFunc
{
	public partial class CMcuFuncAVR8BitsBase:CMcuFuncBase
	{
		#region 变量定义

		/// <summary>
		/// 软件版本信息
		/// </summary>
		private byte[] defaultSoftwareVersion = new byte[] { 0x00, 0x00, 0x00, 0x01 };

		/// <summary>
		/// 硬件版本信息
		/// </summary>
		private byte[] defaultHardwareVersion = new byte[] { 0x00, 0x00, 0x00, 0x00 };

		#endregion

		#region 属性定义

		/// <summary>
		/// 软件版本为读写属性
		/// </summary>
		public virtual byte[] mSoftwareVersion
		{
			get
			{
				return this.defaultSoftwareVersion;
			}
			set
			{
				if (value!=null)
				{
					this.defaultSoftwareVersion = new byte[value.Length];
					//---数据拷贝
					Array.Copy(value, this.defaultSoftwareVersion, value.Length);
				}
			}
		}

		/// <summary>
		/// 硬件版本为读写属性
		/// </summary>
		public virtual byte[] mHardwareVersion
		{
			get
			{
				return this.defaultHardwareVersion;
			}
			set
			{
				if (value != null)
				{
					this.defaultHardwareVersion = new byte[value.Length];
					//---数据拷贝
					Array.Copy(value, this.defaultHardwareVersion, value.Length);
				}
			}
		}

		#endregion

		#region 构造函数

		/// <summary>
		/// 构造函数
		/// </summary>
		public CMcuFuncAVR8BitsBase():base()
		{
			if ((this.defaultMcuInfoParam == null) || (this.defaultMcuInfoParam.GetType() != typeof(CMcuFuncInfoAVR8BitsParam)))
			{
				this.defaultMcuInfoParam = new CMcuFuncInfoAVR8BitsParam();
			}
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
