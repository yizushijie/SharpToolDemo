using Harry.LabTools.LabCommType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Harry.LabTools.LabMcuFunc
{
	public partial class CMcuFuncAVR8BitsHVSP 
	{
		#region 变量定义

		#endregion

		#region 属性定义

		/// <summary>
		/// 通讯使用的端口为读写属性
		/// </summary>
		public override CCommBase mCCOMM
		{
			get
			{
				return base.mCCOMM;
			}
			set
			{
				base.mCCOMM = value;
			}
		}

		/// <summary>
		/// 使用的MCU参数
		/// </summary>
		public override CMcuFuncInfoAVR8BitsParam mMcuInfoParam
		{
			get
			{
				return base.mMcuInfoParam;
			}
			set
			{
				base.mMcuInfoParam = value;
			}
		}

		/// <summary>
		/// 消息提示
		/// </summary>
		public override string mMsgText
		{
			get
			{
				return base.mMsgText;
			}
			set
			{
				base.mMsgText = value;
			}
		}

		/// <summary>
		/// 编程时钟属性为只读属性
		/// </summary>
		public override string[] mChipClock
		{
			get
			{
				return new string[] { "0.5", "1", "2", "4", "8", "16", "32", "64", "128", "256", "163.94", "328.95", "657.89", "1315", "2625", "5250", "1050", "2100" };
			}
		}

		#endregion

		#region 构造函数

		/// <summary>
		/// 有参数构造函数
		/// </summary>
		public CMcuFuncAVR8BitsHVSP(CMcuFuncAVR8BitsBase cMcuFunc)
		{
			this.mCCOMM = cMcuFunc.mCCOMM;
			this.mMcuInfoParam = cMcuFunc.mMcuInfoParam;
			this.mMsgText = cMcuFunc.mMsgText;
			this.mSoftwareVersion = cMcuFunc.mSoftwareVersion;
			this.mHardwareVersion = cMcuFunc.mHardwareVersion;
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
