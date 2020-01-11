using Harry.LabTools.LabGenFunc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Harry.LabTools.LabHexEdit
{
	public partial class CHexFile
	{
		#region 变量定义

		/// <summary>
		/// Hex数据行
		/// </summary>
		private List<CHexLine> defaultCHexLine = null;

		/// <summary>
		/// LOG信息
		/// </summary>
		private string defaultLogMessage = null;

		/// <summary>
		/// 数据是否有效
		/// </summary>
		private bool defaultIsOK = false;

		/// <summary>
		/// 
		/// </summary>
		private ushort defaultCS = 0;

		/// <summary>
		/// 
		/// </summary>
		private ushort defaultIP = 0;

		/// <summary>
		/// 
		/// </summary>
		private uint defaultEIP = 0;

		/// <summary>
		/// 结束地址
		/// </summary>
		private long defaultSTOPAddr = 0;

		/// <summary>
		/// 开始定制
		/// </summary>
		private long defaultSTARTAddr = 0;

		/// <summary>
		/// 数据缓存区
		/// </summary>
		private byte[] defaultDataMap = null;
		
		#endregion

		#region 属性定义

		/// <summary>
		/// 
		/// </summary>
		public virtual bool mIsOK
		{
			get
			{
				return this.defaultIsOK;
			}
		}

		/// <summary>
		/// Log信息
		/// </summary>
		public virtual string mLogMessage
		{
			get
			{
				return this.defaultLogMessage;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual ushort mCS
		{
			get
			{
				return this.defaultCS;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		public virtual ushort mIP
		{
			get
			{
				return this.defaultIP;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual uint mEIP
		{
			get
			{
				return this.defaultEIP;
			}
		}

		/// <summary>
		/// 起始地址
		/// </summary>
		public virtual long mSTARTAddr
		{
			get
			{
				return this.defaultSTARTAddr;
			}
		}

		/// <summary>
		/// 终止地址
		/// </summary>
		public virtual long mSTOPAddr
		{
			get
			{
				return this.defaultSTOPAddr;
			}
		}

		/// <summary>
		/// 数据信息
		/// </summary>

		public virtual byte[] mDataMap
		{
			get
			{
				return this.defaultDataMap;
			}
		}

		#endregion

		#region 构造函数

		/// <summary>
		/// 构造函数
		/// </summary>
		public CHexFile()
		{

		}

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="hexPath"></param>
		public CHexFile(string hexPath)
		{
			this.defaultIsOK = this.AnalyseHexFile(hexPath);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="val"></param>
		/// <param name="num"></param>
		/// <param name="addr"></param>
		public CHexFile(byte[] val, int num = 16, long addr = 0)
		{
			this.SaveHexFile(val, num, addr);
		}

		#endregion

		#region 析构函数

		/// <summary>
		/// 
		/// </summary>
		//~CHexFile()
		//{
		//	//if ((this.defaultCHexLine != null) || (this.defaultCHexLine.Count > 0))
		//	//{
		//	//	GC.SuppressFinalize(this.defaultCHexLine);
		//	//}
		//	GC.SuppressFinalize(this);
		//}

		#endregion

		#region 公共函数

		/// <summary>
		/// 解析Hex文件数据
		/// </summary>
		/// <param name="filePath"></param>
		/// <returns></returns>
		public bool AnalyseHexFile(string filePath)
		{
			//---检查文件是否存在
			if (!File.Exists(filePath))
			{
				this.defaultLogMessage = "Hex文件不存在!\r\n";
				return false;
			}
			try
			{
				//---读取文件
				using (StreamReader std = new StreamReader(filePath))
				{
					long i = 0;
					if ((this.defaultCHexLine == null) || (this.defaultCHexLine.Count == 0))
					{
						this.defaultCHexLine = new List<CHexLine>();
					}
					else
					{
						this.defaultCHexLine.Clear();
					}
					while (std.Peek() >= 0)
					{
						i++;
						//---读取一行的数据
						string readline = std.ReadLine();
						//---每行数据创建一个对象
						CHexLine readHexLine = new CHexLine(readline);
						//---判断数据的读取是否有效
						if (readHexLine.IsOK)
						{
							this.defaultCHexLine.Add(readHexLine);
						}
						else
						{
							this.defaultLogMessage = "第" + i.ToString() + "行" + "的数据解析错误!" + readHexLine.LogMessage + "\r\n";
							return false;
						}
						Application.DoEvents();
					}
				}
			}
			catch
			{
				this.defaultLogMessage = "Hex文件解析错误!\r\n";
				return false;
			}
			//---计算地址信息
			this.CalcAddr();
			//---获取数据信息
			this.defaultDataMap = this.GetHexFileDataMap();
			//---返回结果
			return true;
		}

		/// <summary>
		/// 获取解析后的数据
		/// </summary>
		/// <param name="length"></param>
		/// <returns></returns>
		public byte[] GetHexFileDataMap()
		{
			byte[] buffer = null;
			long myAddr = 0;
			//---创建缓存区
			byte[] _return = new byte[this.mSTOPAddr];
			//---校验缓存区的申请
			if ((_return == null)||(_return.Length==0))
			{
				this.defaultLogMessage = "缓存区申请失败!\r\n";
				return null;
			}
			//---校验固件文件信息
			if ((this.defaultCHexLine == null) || (this.defaultCHexLine.Count == 0))
			{
				this.defaultLogMessage = "固件文件无有效信息!\r\n";
				return null;
			}
			myAddr=this.mSTARTAddr;
			//---用指定的数据填充缓存区
			CGenFuncMem.GenFuncMemset(ref _return, _return.Length, 0xFF);
			//---将解析后的数据填充到数据缓存区
			for (int i = 0; i < this.defaultCHexLine.Count; i++)
			{
				//---数据类型的解析
				switch (this.defaultCHexLine[i].Type)
				{
					//---记录数据
					case HexType.DATA_RECORD:
						//---拷贝数据
						Array.Copy(this.defaultCHexLine[i].InfoData, 0, _return, ((this.defaultCHexLine[i].Addr)+myAddr), this.defaultCHexLine[i].Length);
						break;
					//---文件结束记录
					case HexType.END_OF_FILE_RECORD:                    //1
						break;
					//---扩展段地址
					case HexType.EXTEND_SEGMENT_ADDRESS_RECORD:         //2
						//--解析段地址
						buffer = new byte[2] { this.defaultCHexLine[i].InfoData[1], this.defaultCHexLine[i].InfoData[0] };
						myAddr = BitConverter.ToUInt16(buffer, 0);
						myAddr <<= 4;
						break;
					//---开始段地址
					case HexType.START_SEGMENT_ADDRESS_RECORD:          //3
						break;
					//---扩展线性地址
					case HexType.EXTEND_LINEAR_ADDRESS_RECORD:          //4
						//---解析拓展线性地址
						buffer = new byte[2] { this.defaultCHexLine[i].InfoData[1], this.defaultCHexLine[i].InfoData[0] };
						//---将字节地址转换成字地址
						myAddr = BitConverter.ToUInt16(buffer, 0);
						//---将拓展线性地址转换成实际的对应的地址段
						myAddr <<= 16;
						break;
					//---开始线性地址
					case HexType.START_LINEAR_ADDRESS_RECORD:           //5
						break;
					default:
						break;
				}
			}
			return _return;
		}

		/// <summary>
		/// 获取解析后的数据,空白位置用指定的数据填充
		/// </summary>
		/// <param name="maxSize">Hex文件最大容量</param>
		/// <param name="isHighFirst">true---高位在前，false---地位在前</param>
		/// <param name="fillVal">填充的数据</param>
		/// <returns></returns>
		public byte[] GetHexFileDataMap(long maxSize,bool isHighFirst=false,byte fillVal=0xFF)
		{
			//---创建缓存区
			byte[] _return = null;
			byte[] buffer = null;
			long myAddr = this.mSTOPAddr;
			//---校验数据长度
			if (maxSize < myAddr)
			{
				maxSize = myAddr;
			}
			_return= new byte[maxSize];
			//---校验缓存区的申请
			if (_return == null)
			{
				this.defaultLogMessage = "缓存区申请失败!\r\n";
				return null;
			}
			//---校验固件文件信息
			if ((this.defaultCHexLine == null) || (this.defaultCHexLine.Count == 0))
			{
				this.defaultLogMessage = "固件文件无有效信息!\r\n";
				return null;
			}
			//---获取起始地址
			myAddr = this.mSTARTAddr;
			//---用指定的数据填充缓存区
			CGenFuncMem.GenFuncMemset(ref _return, _return.Length, fillVal);
			//---将解析后的数据填充到数据缓存区
			for (int i = 0; i < this.defaultCHexLine.Count; i++)
			{
				//---数据类型的解析
				switch (this.defaultCHexLine[i].Type)
				{
					case HexType.DATA_RECORD:
						//---拷贝数据
						Array.Copy(this.defaultCHexLine[i].InfoData, 0, _return, ((this.defaultCHexLine[i].Addr) + myAddr), this.defaultCHexLine[i].Length);
						break;
					case HexType.END_OF_FILE_RECORD:                    //1
						break;
					case HexType.EXTEND_SEGMENT_ADDRESS_RECORD:         //2
						buffer = new byte[2] { this.defaultCHexLine[i].InfoData[1], this.defaultCHexLine[i].InfoData[0] };
						myAddr = BitConverter.ToUInt16(buffer, 0);
						myAddr <<= 4;
						break;
					case HexType.START_SEGMENT_ADDRESS_RECORD:          //3
						break;
					case HexType.EXTEND_LINEAR_ADDRESS_RECORD:          //4
						buffer = new byte[2] { this.defaultCHexLine[i].InfoData[1], this.defaultCHexLine[i].InfoData[0] };
						//---将字节地址转换成字地址
						myAddr = BitConverter.ToUInt16(buffer, 0);
						//---将拓展线性地址转换成实际的对应的地址段
						myAddr <<= 16;
						break;
					case HexType.START_LINEAR_ADDRESS_RECORD:           //5
						break;
					default:
						break;
				}
			}
			//---Hex文件默认是低位在前高位在后，判断是否需要将数据转换成高位在前低位在后的格式
			if (isHighFirst==true)
			{
				byte[] _returnTemp = new byte[_return.Length];
			}
			return _return;
		}

		/// <summary>
		/// 将指定的数据保存为Hex文件
		/// </summary>
		/// <param name="val">数据</param>
		/// <param name="num">每行字节数</param>
		/// <param name="addr">存储起始地址</param>
		/// <param name="isHighFirst">true---给定的数据是高位在前，false---给定的数据是地位在前</param>
		/// <returns></returns>
		public string SaveHexFile(byte[] val, int num=16, long addr=0, bool isHighFirst = false)
		{
			string _return = "";
			//---如果给定的数据是高位在前，需要将数据转换为低位在前，Hex文件默认是低位在前高位在后的格式
			if (isHighFirst==true)
			{
				
			}
			//---获取数据行
			string[] hexLineTemp =this.SaveHexLine(val, num, addr);
			//---校验数据记录行数据保存的记过
			if ((hexLineTemp == null)||(hexLineTemp.Length==0)||(hexLineTemp.Length==1))
			{
				this.defaultLogMessage = "转存Hex文件错误";
				return null;
			}
			//---数据记录行的信息
			if ((this.defaultCHexLine != null) || (this.defaultCHexLine.Count > 0))
			{
				//---清零操作
				this.defaultCHexLine.Clear();
			}
			else
			{
				this.defaultCHexLine = new List<CHexLine>();
			}
			//---填充数据行
			for (int i = 0; i < hexLineTemp.Length; i++)
			{
				//---每行数据创建一个对象
				CHexLine readHexLine = new CHexLine(hexLineTemp[i]);
				//---判断数据的读取是否有效
				if (readHexLine.IsOK)
				{
					this.defaultCHexLine.Add(readHexLine);
					_return += hexLineTemp[i];
				}
				else
				{
					this.defaultLogMessage = "Hex转存发生错误，错误提示"+readHexLine.LogMessage;
					break;
				}
			}
			//---保存为数据行,数据结束行
			_return += CHexLine.ToHexLineEndOfFileRecord();
			//---返回Hex文件记录
			return _return;
		}

		/// <summary>
		/// 将指定的数据保存为Hex文件
		/// </summary>
		/// <param name="val"></param>
		/// <returns></returns>
		public string SaveHexFile(byte[] val)
		{
			List<string> hexFile = new List<string>();
			//---保存数据记录行
			hexFile.AddRange(this.SaveHexLine(val, 16, 0));
			//---添加数据结束行
			hexFile.Add(CHexLine.ToHexLineEndOfFileRecord());
			string _return = "";
			foreach (string str in hexFile)
			{
				_return += str;
			}
			return _return;
		}

		/// <summary>
		/// 将指定的数据保存为Hex数据行
		/// </summary>
		/// <param name="val"></param>
		/// <returns></returns>
		public string[] SaveHexLine(byte[] val)
		{
			List<string> hexFile = new List<string>();
			//---保存数据记录行
			hexFile.AddRange(this.SaveHexLine(val, 16, 0));
			//---添加数据结束行
			hexFile.Add(CHexLine.ToHexLineEndOfFileRecord());
			//---返回结果
			return hexFile.ToArray();
		}

		#endregion

		#region 保护函数

		#endregion

		#region 私有函数

		/// <summary>
		/// 将指定的数据保存为Hex数据行数
		/// </summary>
		/// <param name="hexVal">数据</param>
		/// <param name="lineNum">每行多少字节，默认16字节</param>
		/// <param name="addr">数据存储的起始地址</param>
		/// <returns></returns>
		private string[] SaveHexLine(byte[] val,int lineNum=16,long addr=0)
		{
			List<string> _return = new List<string>();
			//判断每行的数据是否过大或者不能被16整除
			if ((lineNum > 0xFF) || ((lineNum % 16) != 0))
			{
				lineNum = 16;
			}
			//---进行分行处理，计算最大多少行
			long lineCount = (val.Length / lineNum);
			//---如果不是整数行，将其设置为整数行
			if ((val.Length % lineNum) != 0)
			{
				lineCount += 1;
			}
			//---校验是大文件，添加拓展线性地址，线性地址是0
			if (val.Length>65536)
			{
				//---拓展段地址
				_return.Add(CHexLine.ToHexLineExternSegmentAddrRecord(0));
			}
			//---数据地址
			long baseAddr = addr;
			//---数据保存处理
			for (long i = 0; i < lineCount; i++)
			{
				string temp = "";
				//---计算当前数据行的数据
				int byteCount = (int)(((val.Length - i * lineNum) > lineNum) ? lineNum : (val.Length - i * lineNum));
				//---当前行数据
				byte[] lineVal = new byte[byteCount];
				//---拷贝数据
				Array.Copy(val, i * lineNum, lineVal, 0, lineVal.Length);
				//---数据空间64K检查
				if (((baseAddr % 65536) == 0) && (baseAddr != 0))
				{
					//---对65536求整处理
					long externLineAddr = (baseAddr / 65536);
					//---拓展段地址
					//temp = CHexLine.ToHexLineExternLineAddrRecord(externLineAddr);
					temp = CHexLine.ToHexLineExternSegmentAddrRecord(externLineAddr);
					_return.Add(temp);
				}
				
				//---本次数组的内容为0xFF，则跳过,否则写入数据
				if (CGenFuncEqual.GenFuncEqual(lineVal,0xFF)==false)
				{
					//---保存数据记录文件
					temp = CHexLine.ToHexLineDataRecord((baseAddr & 0xFFFF), lineVal);
					_return.Add(temp);
				}
				//---计算地址偏移
				baseAddr += lineNum;
			}
			return _return.ToArray();
		}

		/// <summary>
		/// 计算起始地址
		/// </summary>
		private void CalcStartAddr()
		{
			long _return = 0;
			byte[] buffer = null;
			if ((this.defaultCHexLine == null) || (this.defaultCHexLine.Count == 0))
			{
				this.defaultIsOK = false;
				_return = 0;
			}
			else
			{
				switch (this.defaultCHexLine[0].Type)
				{
					case HexType.DATA_RECORD:               //---文件信息首先填充0xFF，开始地址是0x00
						_return = this.defaultCHexLine[0].Addr;
						//if (_return != 0)
						//{
						//	_return = 0;
						//}
						break;
					case HexType.END_OF_FILE_RECORD:
						_return = 0;
						this.defaultIsOK = false;
						break;
					case HexType.EXTEND_SEGMENT_ADDRESS_RECORD:
						buffer = new byte[2] { this.defaultCHexLine[0].InfoData[1], this.defaultCHexLine[0].InfoData[0] };
						_return = BitConverter.ToUInt16(buffer, 0);
						_return <<= 4;
						break;
					case HexType.START_SEGMENT_ADDRESS_RECORD:
						buffer = new byte[4] { this.defaultCHexLine[0].InfoData[3], this.defaultCHexLine[0].InfoData[2], this.defaultCHexLine[0].InfoData[1], this.defaultCHexLine[0].InfoData[0] };
						_return = BitConverter.ToUInt32(buffer, 0);
						_return <<= 4;
						break;
					case HexType.EXTEND_LINEAR_ADDRESS_RECORD:
						buffer = new byte[2] { this.defaultCHexLine[0].InfoData[1], this.defaultCHexLine[0].InfoData[0] };
						_return = BitConverter.ToUInt16(buffer, 0);
						_return <<= 16;
						break;
					case HexType.START_LINEAR_ADDRESS_RECORD:
						buffer = new byte[4] { this.defaultCHexLine[0].InfoData[3], this.defaultCHexLine[0].InfoData[2], this.defaultCHexLine[0].InfoData[1], this.defaultCHexLine[0].InfoData[0] };
						_return = BitConverter.ToUInt32(buffer, 0);
						break;
					default:
						this.defaultIsOK = false;
						break;
				}
			}
			this.defaultSTARTAddr=_return;
		}


		/// <summary>
		/// 计算结束地址
		/// </summary>
		private void CalcStopAddr()
		{
			long _return = 0;
			HexType lastHexType = HexType.DATA_RECORD;
			long tempAddr = 0;
			byte[] buffer = null;
			//---校验数据是否有效
			if ((this.defaultCHexLine == null) || (this.defaultCHexLine.Count == 0))
			{
				_return = 0;
				this.defaultIsOK = false;
			}
			else
			{
				//---遍历数据从而获得结束地址
				for (int i = 0; i < this.defaultCHexLine.Count; i++)
				{
					switch (this.defaultCHexLine[i].Type)
					{
						case HexType.DATA_RECORD:                           //0
																			//---当前数据的地址，不包含扩展线性地址
							tempAddr = (long)(this.defaultCHexLine[i].Addr + this.defaultCHexLine[i].Length);
							//---用来标识数据记录文件,并校验数据地址是否超出64K
							if ((lastHexType == HexType.DATA_RECORD) || ((_return & 0xFFFF0000) == 0))
							{
								//---保留数据地址为最后最大的数据地址，避免某些编译器编译后的固件，数据信息的地址不是递增的
								//---理论上Hex文件的数据地址是递增模式的，但是某些编译器会存在乱序模式
								if (tempAddr > _return)
								{
									_return = tempAddr;
								}
							}
							//---用来标识扩展线性地址的记录
							else if (lastHexType == HexType.EXTEND_LINEAR_ADDRESS_RECORD)
							{
								//---保留数据地址为最后最大的数据地址，避免某些编译器编译后的固件，数据信息的地址不是递增的
								//---理论上Hex文件的数据地址是递增模式的，但是某些编译器会存在乱序模式
								if (tempAddr > (_return & 0xFFFF))
								{
									_return = (_return & 0xFFFF0000) + tempAddr;
								}
							}
							//---是其他格式的数据信息
							else
							{
								_return = (_return & 0xFFFF0000) + tempAddr;//(long)(this.defaultCHexLine[i].Addr + this.defaultCHexLine[i].Length);
							}
							//---将数据地址修改为实际对应的地址
							//(this.defaultCHexLine[i].Addr) += (_return & 0xFFFF0000);
							break;
						case HexType.END_OF_FILE_RECORD:                    //1
							//_return = 0;
							break;
						case HexType.EXTEND_SEGMENT_ADDRESS_RECORD:         //2
							buffer = new byte[2] { this.defaultCHexLine[i].InfoData[1], this.defaultCHexLine[i].InfoData[0] };
							_return = BitConverter.ToUInt16(buffer, 0);
							_return <<= 4;
							lastHexType = HexType.EXTEND_SEGMENT_ADDRESS_RECORD;
							break;
						case HexType.START_SEGMENT_ADDRESS_RECORD:          //3
							buffer = new byte[4]
							{
									this.defaultCHexLine[i].InfoData[3], this.defaultCHexLine[i].InfoData[2], this.defaultCHexLine[i].InfoData[1],
									this.defaultCHexLine[i].InfoData[0]
							};
							//_return = BitConverter.ToUInt32(buffer, 0);
							this.defaultCS = (ushort)(BitConverter.ToUInt32(buffer, 0));
							this.defaultIP = (ushort)((this.defaultCS >> 16) & 0xFFFF);
							lastHexType = HexType.START_SEGMENT_ADDRESS_RECORD;
							break;
						case HexType.EXTEND_LINEAR_ADDRESS_RECORD:          //4
							buffer = new byte[2] { this.defaultCHexLine[i].InfoData[1], this.defaultCHexLine[i].InfoData[0] };
							//---将字节地址转换成字地址
							_return = BitConverter.ToUInt16(buffer, 0);
							//---将拓展线性地址转换成实际的对应的地址段
							_return <<= 16;
							lastHexType = HexType.EXTEND_LINEAR_ADDRESS_RECORD;
							break;
						case HexType.START_LINEAR_ADDRESS_RECORD:           //5
							buffer = new byte[4]
							{
									//this.defaultCHexLine[i].InfoData[3], this.defaultCHexLine[i].InfoData[2], this.defaultCHexLine[i].InfoData[1],
									//this.defaultCHexLine[i].InfoData[0]
									this.defaultCHexLine[i].InfoData[0], this.defaultCHexLine[i].InfoData[1],
									this.defaultCHexLine[i].InfoData[2], this.defaultCHexLine[i].InfoData[3]
							};
							//_return = BitConverter.ToUInt32(buffer, 0);
							this.defaultEIP = (uint)(BitConverter.ToUInt32(buffer, 0));
							lastHexType = HexType.START_LINEAR_ADDRESS_RECORD;
							break;
						default:
							break;
					}
				}
			}
			this.defaultSTOPAddr= _return;
		}

		/// <summary>
		/// 计算地址
		/// </summary>
		private void CalcAddr()
		{
			//---这个函数当前计算有误，只计算第一行数据，导致计算的结果可能不是需要的，发生起始地址计算错误
			//this.CalcStartAddr();
			this.CalcStopAddr();
		}

		#endregion

		#region 事件函数

		#endregion

	}
}
