using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Harry.LabTools.LabHexEdit
{
	public partial class CHexLine : IHexLine
	{
		#region 变量定义

		/// <summary>
		/// 数据可用
		/// </summary>
		private bool defaultIsOK = false;

		/// <summary>
		/// 数据长度
		/// </summary>
		private byte defaultLength = 0;

		/// <summary>
		/// 数据地址
		/// </summary>
		private long defaultAddr = 0;

		/// <summary>
		/// 数据类型
		/// </summary>
		private HexType defaultType = HexType.END_OF_FILE_RECORD;

		/// <summary>
		/// 数据信息
		/// </summary>
		private byte[] defaultInfoData = null;

		/// <summary>
		/// 校验和信息
		/// </summary>
		private byte defaultCheckSum = 0;

		/// <summary>
		/// 信息记录
		/// </summary>
		private string defaultLogMessage = "";

		#endregion

		#region 属性定义

		/// <summary>
		/// 数据有效
		/// </summary>
		public virtual bool IsOK
		{
			get
			{
				return this.defaultIsOK;
			}
		}
		
		/// <summary>
		/// 数据长度
		/// </summary>
		public virtual  byte Length
		{
			get
			{
				return this.defaultLength;
			}
		}

		/// <summary>
		/// 数据地址
		/// </summary>
		public virtual long Addr
		{
			get
			{
				return this.defaultAddr;
			}
			set
			{
				this.defaultAddr = value;
			}
		}

		/// <summary>
		/// 数据类型
		/// </summary>
		public virtual HexType Type
		{
			get
			{
				return this.defaultType;
			}
		}

		/// <summary>
		/// 数据信息
		/// </summary>
		public virtual byte[] InfoData
		{
			get
			{
				return this.defaultInfoData;
			}
		}

		/// <summary>
		/// 校验和
		/// </summary>
		public virtual byte CheckSum
		{
			get
			{
				return this.defaultCheckSum;
			}
		}

		/// <summary>
		/// 信息记录
		/// </summary>
		public virtual string LogMessage
		{
			get
			{
				return this.defaultLogMessage;
			}
		}

		#endregion

		#region 构造函数

		/// <summary>
		/// 构造函数
		/// </summary>
		public CHexLine()
		{

		}

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="str"></param>
		public CHexLine(string str)
		{
			this.defaultIsOK = this.AnalyseHexLine(str);
		}

		#endregion

		#region 析构函数

		/// <summary>
		/// 析构函数
		/// </summary>
		~CHexLine()
		{
			//===资源回收
			GC.SuppressFinalize(this);
			
		}

		#endregion

		#region 公共函数

		/// <summary>
		/// 
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public bool AnalyseHexLine(string str)
		{
			//---将数据记录行的首位空格去除并装换成大写模式
			str = str.Trim().ToUpper();
			//---判断字符串是否合法
			//if ((str==string.Empty)||(str==""))
			if (string.IsNullOrEmpty(str))
			{
				this.defaultLogMessage = "Hex数据为空!";
				return false;
			}
			//---获取数据记录行的开始信息，已：开始
			if (str[0]!=':')
			{
				this.defaultLogMessage = "Hex数据格式不合法";
			}
			//---检查其余数据信息是否都是0~9，a~f的数据
			if (this.IsHexNumber(str.Substring(1))==false)
			{
				this.defaultLogMessage = "Hex数据中含有不合法信息!";
				return false;
			}
			//---解析数据长度
			try
			{
				this.defaultLength = byte.Parse(str.Substring(1, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
			}
			catch
			{
				this.defaultLogMessage = "Hex数据长度解析错误!";
				return false;
			}

			this.defaultCheckSum = (byte) this.defaultLength;
			//---解析地址信息
			try
			{
				this.defaultAddr = long.Parse(str.Substring(3, 4), System.Globalization.NumberStyles.AllowHexSpecifier);
			}
			catch 
			{
				this.defaultLogMessage = "Hex数据地址解析错误!";
				return false;
			}

			this.defaultCheckSum += (byte) ((this.defaultAddr >> 8)&0xFF);
			this.defaultCheckSum += (byte)(this.defaultAddr&0xFF);
			//---解析数据类型
			try
			{
				this.defaultType = (HexType)(byte.Parse(str.Substring(7, 2), System.Globalization.NumberStyles.AllowHexSpecifier));
			}
			catch 
			{
				this.defaultLogMessage = "Hex数据类型解析错误!";
				return false;
			}

			//---校验数据类型
			if (Enum.IsDefined(typeof(HexType),this.defaultType)==false)
			{
				this.defaultLogMessage = "Hex数据类型识别错误!";
				return false;
			}

			this.defaultCheckSum += (byte) (this.defaultType);
			//---申请数据空间
			this.defaultInfoData = new byte[this.defaultLength];
			//---遍历解析数据
			for (int i = 0; i < this.defaultLength; i++)
			{
				//---解析数据
				try
				{
					this.defaultInfoData[i] = byte.Parse(str.Substring(9 + i * 2, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
					this.defaultCheckSum += this.defaultInfoData[i];
				}
				catch 
				{
					this.defaultLogMessage = "Hex数据信息解析错误!";
					return false;
				}
			}

			//---解析数据中的校验和信息
			byte tempCheckSum = 0;
			try
			{
				tempCheckSum= byte.Parse(str.Substring(9 + this.defaultLength * 2, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
			}
			catch 
			{
				this.defaultLogMessage = "Hex数据校验和解析错误!";
				return false;
			}

			this.defaultCheckSum = (byte) (0x100 - this.defaultCheckSum);
			//---校验和校验
			if (this.defaultCheckSum!=tempCheckSum)
			{
				this.defaultLogMessage = "Hex数据校验和校验错误!";
				return false;
			}
			//---数据类型校验
			switch (this.defaultType)
			{
				case HexType.DATA_RECORD:
					if (this.defaultLength != this.defaultInfoData.Length)
					{
						this.defaultLogMessage = "Hex格式记录标识错误!";
						return false;
					}
					break;
				case HexType.END_OF_FILE_RECORD:
					if (this.defaultLength!=0)
					{
						this.defaultLogMessage = "Hex格式结束标识错误!";
						return false;
					}
					break;
				case HexType.EXTEND_SEGMENT_ADDRESS_RECORD:
					if (this.defaultLength != 2)
					{
						this.defaultLogMessage = "Hex格式扩展段地址标识错误!";
						return false;
					}
					break;
				case HexType.START_SEGMENT_ADDRESS_RECORD:
					if (this.defaultLength != 4)
					{
						this.defaultLogMessage = "Hex格式段地址标识错误!";
						return false;
					}
					break;
				case HexType.EXTEND_LINEAR_ADDRESS_RECORD:
					if (this.defaultLength != 2)
					{
						this.defaultLogMessage = "Hex格式扩展线性地址标识错误!";
						return false;
					}
					break;
				case HexType.START_LINEAR_ADDRESS_RECORD:
					if (this.defaultLength != 4)
					{
						this.defaultLogMessage = "Hex格式开始线性地址标识错误!";
						return false;
					}
					break;
				default:
					this.defaultLogMessage = "Hex格式不识别错误!";
					return false;
			}
			//---将数据的个数解析为偶数
			if ((this.defaultLength&0x01)!=0)
			{
				this.defaultLength += 1;
				//---修改缓存区的大小为指定大小
				Array.Resize<byte>(ref this.defaultInfoData, this.defaultLength);
				//---补偿最后一个数据为0xFF
				this.defaultInfoData[this.defaultInfoData.Length - 1] = 0xFF;
			}
			return true;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="addr"></param>
		/// <param name="type"></param>
		/// <param name="val"></param>
		/// <param name="isHighFirst"></param>
		/// <returns></returns>
		public static string ToHexLine(long addr, HexType type, byte[] val,bool isHighFirst=false)
		{
			string _return = ":";
			byte checkSum = (byte)(val.Length);
			_return += checkSum.ToString("X2");
			checkSum += (byte)(addr >> 8);
			checkSum += (byte)(addr);
			_return += addr.ToString("X4");
			checkSum += (byte)(type);
			_return += ((byte)type).ToString("X2");
			for (int i = 0; i < val.Length; i += 2)
			{
				if (isHighFirst)
				{
					_return += string.Format("{0:X2}{1:X2}", val[i + 1], val[i]);
				}
				else
				{
					_return += string.Format("{0:X2}{1:X2}", val[i], val[i + 1]);
				}
				checkSum += val[i];
				checkSum += val[i + 1];
			}
			checkSum = (byte)(0x100 - checkSum);
			_return += checkSum.ToString("X2");
			_return += "\r\n";
			return _return;
		}

		/// <summary>
		/// 记录行
		/// </summary>
		/// <param name="addr"></param>
		/// <param name="buffer"></param>
		/// <returns></returns>
		public static string ToHexLineDataRecord(long addr, byte[] buffer)
		{
			return CHexLine.ToHexLine(addr, HexType.DATA_RECORD, buffer);
		}

		/// <summary>
		/// 结束标识符
		/// </summary>
		/// <returns></returns>
		public static string ToHexLineEndOfFileRecord()
		{
			return (":00000001FF" + "\r\n");
		}

		/// <summary>
		/// 扩展段地址
		/// </summary>
		/// <param name="addr"></param>
		/// <returns></returns>
		public static string ToHexLineExternSegmentAddrRecord(long addr)
		{
			string _return = "";
			//addr <<= 12;
			byte[] line = new byte[2] { (byte)((addr<<4) & 0xFF), (byte)(((addr<<4)>>8)& 0xFF) };
			_return = CHexLine.ToHexLine(0, HexType.EXTEND_SEGMENT_ADDRESS_RECORD, line);
			return _return;
		}

		/// <summary>
		/// 扩展线性地址
		/// </summary>
		/// <param name="addr"></param>
		/// <returns></returns>
		public static string ToHexLineExternLineAddrRecord(long addr)
		{
			string _return = "";
			/*
			addr <<= 24;
			byte[] line = new byte[2] { (byte)((addr >> 8) & 0xFF), (byte)(addr & 0xFF) };
			_return = CHexLine.ToHexLine(0, HexType.EXTEND_LINEAR_ADDRESS_RECORD, line);
			*/
			byte[] line = new byte[2] { (byte)((addr >>8) & 0xFF), (byte)(addr & 0xFF) };
			_return = CHexLine.ToHexLine(0, HexType.EXTEND_LINEAR_ADDRESS_RECORD, line);
			return _return;
		}

		#endregion

		#region 保护函数

		#endregion

		#region 私有函数

		/// <summary>
		/// 判断给定的字符串是不是都是16进制数
		/// </summary>
		/// <param name="hexString"></param>
		/// <returns></returns>
		private bool IsHexNumber(string hexString)
		{
			//if ((hexString == string.Empty) || (hexString == null))
			if(string.IsNullOrEmpty(hexString))
			{
				return false;
			}
			hexString = hexString.Trim().ToUpper();
			//if (hexString == "")
			if(string.IsNullOrEmpty(hexString))
			{
				return false;
			}
			//---利用正则表达式
			return Regex.IsMatch(hexString, "^[0-9A-Fa-f]+$");
		}
		#endregion

		#region 事件函数

		#endregion

	}
}
