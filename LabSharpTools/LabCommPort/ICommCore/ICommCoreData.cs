using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Harry.LabTools.LabCommPort
{
	/// <summary>
	/// CRC校验方式
	/// </summary>
	public enum CCOMM_CRC : int
	{
		CRC_NONE			= 0,																						//---无校验方式
		CRC_CHECKSUM		= 1,																						//---检验和
		CRC_CRC8			= 2,																						//---CRC8校验
		CRC_CRC16			= 3,																						//---CRC16校验
		CRC_CRC32			= 4,																						//---CRC32校验
	};

	/// <summary>
	/// 
	/// </summary>
	public class CCommData
	{
		#region 变量定义

		/// <summary>
		/// 数据
		/// </summary>
		private List<byte> defaultByte = null;

		/// <summary>
		/// CRC的结果
		/// </summary>
		private UInt32 defaultCRCVal = 0;

		/// <summary>
		/// 数据的长度
		/// </summary>
		private int defaultLength = 0;

		/// <summary>
		/// CRC的方式
		/// </summary>
		private CCOMM_CRC defaultCRCMode = CCOMM_CRC.CRC_NONE;

		/// <summary>
		/// 父命令
		/// </summary>
		private byte defaultParentCMD = 0;

		/// <summary>
		/// 子命令
		/// </summary>
		private byte defaultChildCMD = 0;

		/// <summary>
		/// 数据发送的长度
		/// </summary>
		private int defaultSize = 64;

		/// <summary>
		/// 数据报头信息
		/// </summary>
		private int defaultID = 0x00;

		/// <summary>
		/// 结果标志位，0---数据合格，其他失效
		/// </summary>
		private int defaultOkFlag = -1;

		/// <summary>
		/// 数据命令的偏移
		/// </summary>
		private uint defaultIndexOffset = 0;

		#endregion

		#region 属性定义

		/// <summary>
		/// 数据缓存区属性为读写属性
		/// </summary>
		public virtual List<byte> mByte
		{
			get
			{
				return this.defaultByte;
			}
			set
			{
				this.defaultByte = value;
			}
		}

		/// <summary>
		/// 数据缓存区的数组
		/// </summary>
		public virtual byte[] mArray
		{
			get
			{
				if ((this.defaultByte!=null)&&(this.defaultByte.Count > 0))
				{
					return this.defaultByte.ToArray();
				}
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// 校验结果属性为读写属性
		/// </summary>
		public UInt32 mCRCVal
		{
			get
			{
				return this.defaultCRCVal;
			}
			set
			{
				this.defaultCRCVal = value;
			}
		}

		/// <summary>
		/// 数据长度属性为读写属性
		/// </summary>
		public virtual int mLength
		{
			get
			{
				return this.defaultLength;
			}
			set
			{
				this.defaultLength = value;
			}
		}

		/// <summary>
		/// CRC校验模式属性为读写属性
		/// </summary>
		public virtual CCOMM_CRC mCRCMode
		{
			get
			{
				return this.defaultCRCMode;
			}
			set
			{
				this.defaultCRCMode = value;
			}
		}

		/// <summary>
		/// 父命令属性为读写属性
		/// </summary>
		public virtual byte mParentCMD
		{
			get
			{
				return this.defaultParentCMD;
			}
			set
			{
				this.defaultParentCMD = value;
			}
		}

		/// <summary>
		/// 子命令属性为读写属性
		/// </summary>
		public virtual byte mChildCMD
		{
			get
			{
				return this.defaultChildCMD;
			}
			set
			{
				this.defaultChildCMD = value;
			}
		}

		/// <summary>
		/// 缓存区的大小属性为读写属性
		/// </summary>
		public virtual int mSize
		{
			get
			{
				return this.defaultSize;
			}
			set
			{
				this.defaultSize = value;
			}
		}

		/// <summary>
		/// 通讯ID信息属性为读写属性
		/// </summary>
		public virtual int mID
		{
			get
			{
				return this.defaultID;
			}
			set
			{
				this.defaultID = value;
			}
		}

		/// <summary>
		/// 数据结果属性为读写属性，0---数据合格，其他失效
		/// </summary>
		public virtual int mOkFlag
		{
			get
			{
				return this.defaultOkFlag;
			}
			set
			{
				this.defaultOkFlag=value;
			}
		}

		/// <summary>
		/// 数据索引的偏移
		/// </summary>
		public virtual  uint mIndexOffset
		{
			get
			{
				return this.defaultIndexOffset;
			}
			set
			{
				this.defaultIndexOffset = value;
			}
		}

		#endregion

		#region 构造函数

		/// <summary>
		/// 构造函数
		/// </summary>
		public CCommData()
		{

		}

		/// <summary>
		/// 构造函数
		/// </summary>
		public CCommData(int val,bool isID=true)
		{
			if (isID)
			{
				this.defaultID = val;
			}
			else
			{
				this.defaultSize = val;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="size"></param>
		public CCommData(int id,int size)
		{
			this.defaultID = id;
			this.defaultSize = size;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="size"></param>
		/// <param name="crcMode"></param>
		public CCommData(int id, int size,CCOMM_CRC crcMode)
		{
			this.defaultID = id;
			this.defaultSize = size;
			this.defaultCRCMode = crcMode;
		}

		#endregion

		#region 析构函数

		/// <summary>
		/// 析构函数
		/// </summary>
		~CCommData()
		{
			//---垃圾回收
			GC.SuppressFinalize(this);
		}

		#endregion

		#region 公有函数

		/// <summary>
		/// 构造函数
		/// </summary>
		public void Init(int val, bool isID = true)
		{
			if (isID)
			{
				this.defaultID = val;
			}
			else
			{
				this.defaultSize = val;
			}
		}

		#endregion

		#region 私有函数

		#endregion

		#region 事件函数

		#endregion
	}

	/// <summary>
	/// 通讯接口的数据函数
	/// </summary>
	interface ICommData
	{
		#region 属性定义

		/// <summary>
		/// 接收数据
		/// </summary>
		CCommData mReceData
		{
			get;
			set;
		}


		/// <summary>
		/// 发送数据
		/// </summary>
		CCommData mSendData
		{
			get;
			set;
		}

		/// <summary>
		/// 接收校验通过
		/// </summary>
		bool mReceCheckPass
		{
			get;
		}

		#endregion

		#region 函数定义

		/// <summary>
		/// 分析接收数据
		/// </summary>
		/// <returns></returns>
		bool AnalyseReceData(byte[] cmd);

		/// <summary>
		/// 解析发送数据
		/// </summary>
		/// <param name="cmd">发送命令</param>
		/// <returns></returns>
		bool AnalyseSendData(byte[]cmd);

		#endregion

	}
}
