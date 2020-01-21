using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Harry.LabTools.LabMcuFunc
{
	/// <summary>
	/// AVR的8BitsMcu的编程接口类型
	/// </summary>
	public enum CMCUFUNC_AVR8BITS_PROG_INTERFACE : byte
	{
		ISP  = 0,			 //---串行编程
		JTAG = 1,			 //---JTAG编程
		HVPP = 2,            //---高压并行编程
		HVSP = 3,            //---高压串行编程
	};
	
	#region 熔丝类定义

	/// <summary>
	/// 芯片熔丝位和加密位的信息
	/// </summary>
	public class CMcuFuncAVR8BitsParam
	{
		#region 变量定义

		/// <summary>
		/// 名称
		/// </summary>
		private string[] defaultText = null;

		/// <summary>
		/// 值
		/// </summary>
		private int[] defaultValue = null;

		/// <summary>
		/// Msks值
		/// </summary>
		private int[] defaultMask = null;

		/// <summary>
		/// 信息名称
		/// </summary>
		private string defaultName = "";

		#endregion

		#region 属性定义

		/// <summary>
		/// 名称为读写属性
		/// </summary>
		public virtual string[] mText
		{
			get
			{
				return this.defaultText;
			}
			set
			{
				if (value != null)
				{
					this.defaultText = new string[value.Length];
					//---数据拷贝
					Array.Copy(value, this.defaultText, value.Length);
				}
			}
		}

		/// <summary>
		/// 值为读写属性
		/// </summary>
		public virtual int[] mValue
		{
			get
			{
				return this.defaultValue;
			}
			set
			{
				if (value != null)
				{
					this.defaultValue = new int[value.Length];
					//---数据拷贝
					Array.Copy(value, this.defaultValue, value.Length);
				}
			}
		}

		/// <summary>
		/// Mask值为读写属性
		/// </summary>
		public virtual int[] mMask
		{
			get
			{
				return this.defaultMask;
			}
			set
			{
				if (value != null)
				{
					this.defaultMask = new int[value.Length];
					//---数据拷贝
					Array.Copy(value, this.defaultMask, value.Length);
				}
			}
		}

		/// <summary>
		/// 信息属性为读写属性
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
		/// 获取信息的长度，value和text是等长的，为只读属性
		/// </summary>
		public virtual int mLength
		{
			get
			{
				if ((this.defaultValue == null) || (this.defaultValue.Length == 0))
				{
					return 0;
				}
				else
				{
					return this.defaultValue.Length;
				}
			}
		}

		#endregion

		#region 构造函数

		/// <summary>
		/// 参数可为空的构造构造函数
		/// </summary>
		public CMcuFuncAVR8BitsParam(string name="")
		{
			this.defaultText	= null;
			this.defaultValue	= null;
			this.defaultMask	= null;
			this.defaultName	= name;
		}

		/// <summary>
		/// 有参数的构造函数
		/// </summary>
		/// <param name="cMcuBits"></param>
		public CMcuFuncAVR8BitsParam( CMcuFuncAVR8BitsParam cMcuBits)
		{
			this.mText	= cMcuBits.mText;
			this.mValue = cMcuBits.mValue;
			this.mMask	= cMcuBits.mMask;
			this.mName	= cMcuBits.mName;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cMcuBits"></param>
		public CMcuFuncAVR8BitsParam(int length, string name)
		{
			this.defaultText = new string[length];
			for (int i = 0; i < length; i++)
			{
				this.defaultText[i] = "NC";
			}
			this.defaultValue = new int[length];
			this.defaultMask = new int[length];
			this.defaultName = name;
		}

		#endregion

		#region 公有函数

		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public bool Init(string name = "")
		{
			this.defaultText = null;
			this.defaultValue = null;
			this.defaultMask = null;
			this.defaultName = name;
			return true;
		}

		/// <summary>
		/// 初始化
		/// </summary>
		/// <param name="cMcuBits"></param>
		/// <returns></returns>
		public bool Init(CMcuFuncAVR8BitsParam cMcuBits)
		{
			this.mText = cMcuBits.mText;
			this.mValue = cMcuBits.mValue;
			this.mMask = cMcuBits.mMask;
			this.mName = cMcuBits.mName;
			return true;
		}


		#endregion

		#region 私有函数

		#endregion

		#region 事件函数

		#endregion
	}

	#endregion

	#region 结构体定义
	public class CMcuFuncMaskParam
	{
		#region 变量定义
		/// <summary>
		/// 
		/// </summary>
		private int defaultCout=0;
		/// <summary>
		/// 
		/// </summary>
		public int defaultMask=0;

		#endregion

		#region 属性定义

		/// <summary>
		/// 
		/// </summary>
		public virtual int mCout
		{
			get
			{
				return this.defaultCout;
			}
			set
			{
				this.defaultCout = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual int mMask
		{
			get
			{
				return this.defaultMask;
			}
			set
			{
				this.defaultMask = value;
			}
		}

		#endregion

		#region 构造函数

		/// <summary>
		/// 
		/// </summary>
		public CMcuFuncMaskParam()
		{
			this.defaultCout = 0;
			this.defaultMask = 0;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="count"></param>
		/// <param name="mask"></param>
		public CMcuFuncMaskParam(int count, int mask)
		{
			this.defaultCout = count;
			this.defaultMask = mask;
		}

		#endregion

		#region 公共函数

		#endregion

		#region 保护函数

		#endregion

		#region 私有函数

		#endregion

		#region 事件函数

		#endregion

	}
	#endregion

	#region 接口定义

	/// <summary>
	/// Mcu的基本信息参数
	/// </summary>
	interface IMcuFuncInfoAVR8BitsParam
	{
		
		#region 属性参数

		/// <summary>
		/// 参数解析是是否正常
		/// </summary>
		bool mChipInfoOK
		{
			get;
		}

		/// <summary>
		/// 芯片名称
		/// </summary>
		string mChipName
		{
			get;
			set;
		}
		
		/// <summary>
		/// 芯片的总接口
		/// </summary>
		string[] mChipInterfaceName
		{
			get;
		}

		/// <summary>
		/// 当前芯片的支持的编程接口
		/// </summary>
		CMcuFuncAVR8BitsParam mChipInterface
		{
			get;
			//set;
		}

		/// <summary>
		/// 当前芯片是否需要轮训接口,属性为只读
		/// </summary>
		bool mPollReady
		{
			get;
		}

		/// <summary>
		/// 设备的ID信息
		/// </summary>
		byte[] mChipID
		{
			get;
			//set;
		}

		/// <summary>
		/// 设备的JTAG的信息
		/// </summary>
		int mIDChip
		{
			get;
			//set;
		}

		/// <summary>
		/// 设备的熔丝位
		/// </summary>
		byte[] mChipFuse
		{
			get;
			set;
		}

		/// <summary>
		/// 设备的加密位
		/// </summary>
		byte mChipLock
		{
			get;
			set;
		}

		/// <summary>
		/// Flash的页数
		/// </summary>
		int mChipFlashPageNum
		{
			get;
			//set;
		}

		/// <summary>
		/// Flash的每页的字大小
		/// </summary>
		int mChipFlashPerPageWordNum
		{
			get;
			//set;
		}

		/// <summary>
		/// Flash的每页的字大小
		/// </summary>
		int mChipFlashPerPageByteNum
		{
			get;
		}

		/// <summary>
		/// 芯片ROM页的字大小
		/// </summary>
		int mChipRomWordSize
		{
			get;
		}

		/// <summary>
		/// ROM页的字节大小
		/// </summary>
		int mChipRomByteSize
		{
			get;
		}

		/// <summary>
		/// Flash的字节大小
		/// </summary>
		long mChipFlashByteSize
		{
			get;
		}

		/// <summary>
		/// Flash的字大小
		/// </summary>
		long mChipFlashWordSize
		{
			get;
		}

		/// <summary>
		/// Eeprom的页数
		/// </summary>
		int mChipEepromPageNum
		{
			get;
			//set;
		}

		/// <summary>
		/// Eeprom的每页的字节数
		/// </summary>
		int mChipEepromPerPageByteNum
		{
			get;
			//set;
		}

		/// <summary>
		/// Eeprom的字节大小
		/// </summary>
		long mChipEepromByteSize
		{
			get;
		}

		/// <summary>
		/// Eeprom支持页编程模式，true---支持，flase---不支持
		/// </summary>
		bool mChipEepromPageMode
		{
			get;
		}

		/// <summary>
		/// 设备的校准字
		/// </summary>
		CMcuFuncAVR8BitsParam mChipOSCCalibration
		{
			get;
			//set;
		}

		/// <summary>
		/// 低位熔丝位
		/// </summary>
		CMcuFuncAVR8BitsParam mChipLowFuseBits
		{
			get;
			//set;
		}

		/// <summary>
		/// 低位熔丝位
		/// </summary>
		CMcuFuncAVR8BitsParam mChipLowFuseText
		{
			get;
			//set;
		}

		/// <summary>
		/// 高位熔丝位
		/// </summary>
		CMcuFuncAVR8BitsParam mChipHighFuseBits
		{
			get;
			//set;
		}

		/// <summary>
		/// 高位熔丝位
		/// </summary>
		CMcuFuncAVR8BitsParam mChipHighFuseText
		{
			get;
			//set;
		}

		/// <summary>
		/// 拓展位熔丝位
		/// </summary>
		CMcuFuncAVR8BitsParam mChipExternFuseBits
		{
			get;
			//set;
		}

		/// <summary>
		/// 拓展位熔丝位
		/// </summary>
		CMcuFuncAVR8BitsParam mChipExternFuseText
		{
			get;
			//set;
		}

		/// <summary>
		/// 加密位熔丝位
		/// </summary>
		CMcuFuncAVR8BitsParam mChipLockFuseBits
		{
			get;
			//set;
		}

		/// <summary>
		/// 加密位熔丝位
		/// </summary>
		CMcuFuncAVR8BitsParam mChipLockFuseText
		{
			get;
			//set;
		}

		/// <summary>
		/// 功能函数的执行步序1
		/// </summary>
		CMcuFuncMaskParam mChipFuncMask1
		{
			get;
			set;
		}

		/// <summary>
		/// 功能函数的执行步序2
		/// </summary>
		CMcuFuncMaskParam mChipFuncMask2
		{
			get;
			set;
		}

		#endregion

		#region 函数定义

		#endregion
	}

	#endregion
}
