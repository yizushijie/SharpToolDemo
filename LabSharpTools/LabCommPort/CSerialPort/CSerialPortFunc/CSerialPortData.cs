using Harry.LabTools.LabGenFunc;
using System.Collections.Generic;

namespace Harry.LabTools.LabCommPort
{
	public partial class CSerialPort
	{
		#region 变量定义

		/// <summary>
		/// 接收数据
		/// </summary>
		private CCommData defaultSerialReceData = new CCommData(0x5A, 64, CCOMM_CRC.CRC_NONE);

		/// <summary>
		/// 发送数据
		/// </summary>
		private CCommData defaultSerialSendData = new CCommData(0x55, 64, CCOMM_CRC.CRC_NONE);

		#endregion

		#region 属性定义
		/// <summary>
		/// 接收数据
		/// </summary>
		public override CCommData mReceData
		{
			get
			{
				return this.defaultSerialReceData;
			}
			set
			{
				this.defaultSerialReceData = value;
			}
		}

		/// <summary>
		/// 发送数据
		/// </summary>
		public override CCommData mSendData
		{
			get
			{
				return this.defaultSerialSendData;
			}
			set
			{
				this.defaultSerialSendData = value;
			}
		}

		/// <summary>
		/// 数据校验通过
		/// </summary>
		public override bool mReceCheckPass
		{
			get
			{
				bool _return = false;
				if ((this.defaultSerialReceData!=null)&&
					(this.defaultSerialReceData.mByte!=null)&&
					(this.defaultSerialReceData.mByte.Count>3)&&
					(this.defaultSerialReceData.mOkFlag==0)&&
					(this.defaultSerialSendData.mParentCMD==this.defaultSerialReceData.mParentCMD))
				{
					_return = true;
				}
				return _return;
			}
		}
		#endregion

		#region 构造函数

		#endregion

		#region 公有函数

		/// <summary>
		/// 解析接收数据
		/// </summary>
		/// <returns></returns>
		public override bool AnalyseReceData(byte[] cmd)
		{
			bool _return = false;
			this.defaultSerialMsg = "";
			if ((cmd == null) || (cmd.Length == 0))
			{
				this.defaultSerialMsg = "接收数据为空！";
				//_return = false;
			}
			else
			{
				int length = cmd[1];
				int id = 0;
				//---获取数据长度
				this.defaultSerialReceData.mLength = cmd.Length-2;
				if (this.defaultSerialReceData.mSize>250)
				{
					length = (length << 8) + cmd[2];
					this.defaultSerialReceData.mLength -= 1;

					cmd[1] = (byte)(length >> 8);
					cmd[2] = (byte)(length);
					if (this.mMultiAddr)
					{
						id = cmd[3];
						this.defaultSerialReceData.mParentCMD = cmd[4];
						if (this.mMultiCMD)
						{
							this.defaultSerialReceData.mChildCMD = cmd[5];
							this.defaultSerialReceData.mOkFlag = cmd[6];
							this.defaultSerialReceData.mIndexOffset = 7;
						}
						else
						{
							this.defaultSerialReceData.mChildCMD = 0;
							this.defaultSerialReceData.mOkFlag = cmd[5];
							this.defaultSerialReceData.mIndexOffset = 6;
						}
					}
					else
					{

						this.defaultSerialReceData.mParentCMD = cmd[3];
						if (this.mMultiCMD)
						{
							this.defaultSerialReceData.mChildCMD = cmd[4];
							this.defaultSerialReceData.mOkFlag = cmd[5];
							this.defaultSerialReceData.mIndexOffset = 6;
						}
						else
						{
							this.defaultSerialReceData.mChildCMD = 0;
							this.defaultSerialReceData.mOkFlag = cmd[4];
							this.defaultSerialReceData.mIndexOffset = 5;
						}
					}
				}
				else
				{
					cmd[1] = (byte)(length);
					if (this.mMultiAddr)
					{
						id = cmd[2];
						this.defaultSerialReceData.mParentCMD = cmd[3];
						if (this.mMultiCMD)
						{
							this.defaultSerialReceData.mChildCMD = cmd[4];
							this.defaultSerialReceData.mOkFlag = cmd[5];
							this.defaultSerialReceData.mIndexOffset = 6;
						}
						else
						{
							this.defaultSerialReceData.mChildCMD = 0;
							this.defaultSerialReceData.mOkFlag = cmd[4];
							this.defaultSerialReceData.mIndexOffset = 5;
						}
					}
					else
					{
						this.defaultSerialReceData.mParentCMD = cmd[2];
						if (this.mMultiCMD)
						{
							this.defaultSerialReceData.mChildCMD = cmd[3];
							this.defaultSerialReceData.mOkFlag = cmd[4];
							this.defaultSerialReceData.mIndexOffset = 5;
						}
						else
						{
							this.defaultSerialReceData.mChildCMD = 0;
							this.defaultSerialReceData.mOkFlag = cmd[3];
							this.defaultSerialReceData.mIndexOffset = 4;
						}
					}
				}
				if (this.mMultiCMD)
				{
					if (id != this.defaultSerialParam.mAddrID)
					{
						this.defaultSerialMsg = "设备通讯地址不匹配！";
						_return = false;
					}
				}
				else
				{
					//---校验数据长度
					if (this.defaultSerialReceData.mLength != length)
					{
						this.defaultSerialMsg = "接收数据的长度校验错误！";
						//_return = false;
					}
					else
					{
						this.defaultSerialReceData.mLength = cmd.Length;
						//---计算CRC的位置
						if (this.defaultSerialReceData.mCRCMode == CCOMM_CRC.CRC_CHECKSUM)
						{
							this.defaultSerialReceData.mLength -= 1;
							//---计算校验和
							this.defaultSerialReceData.mCRCVal = CGenFuncCRC.GenFuncCheckSum(cmd, this.defaultSerialReceData.mLength);
						}
						else if (this.defaultSerialReceData.mCRCMode == CCOMM_CRC.CRC_CRC8)
						{
							this.defaultSerialReceData.mLength -= 1;
							//---计算CRC8
							this.defaultSerialReceData.mCRCVal = CGenFuncCRC.GenFuncCheckSum(cmd, this.defaultSerialReceData.mLength);
						}
						else if (this.defaultSerialReceData.mCRCMode == CCOMM_CRC.CRC_CRC16)
						{
							this.defaultSerialReceData.mLength -= 2;
							//---计算CRC16
							this.defaultSerialReceData.mCRCVal = CGenFuncCRC.GenFuncCRC16Table(cmd, this.defaultSerialReceData.mLength);
						}
						else if (this.defaultSerialReceData.mCRCMode == CCOMM_CRC.CRC_CRC32)
						{
							this.defaultSerialReceData.mLength -= 4;
							//---计算CRC32
							this.defaultSerialReceData.mCRCVal = CGenFuncCRC.GenFuncCRC32Table(cmd, this.defaultSerialReceData.mLength);
						}
						if (this.defaultSerialReceData.mByte == null)
						{
							this.defaultSerialReceData.mByte = new List<byte>();
						}
						else
						{
							this.defaultSerialReceData.mByte.Clear();
						}
						//---数据拷贝
						for (length = 0; length < this.defaultSerialReceData.mLength; length++)
						{
							this.defaultSerialReceData.mByte.Add(cmd[length]);
						}
						_return = true;
					}
				}
			}
			return _return;
		}

		/// <summary>
		/// 解析发送数据
		/// </summary>
		/// <returns></returns>
		public override bool AnalyseSendData(byte[] cmd)
		{
			bool _return = false;
			this.defaultSerialMsg = "";
;			if ((cmd == null) || (cmd.Length == 0))
			{
				this.defaultSerialMsg = "发送数据为空！";
				//_return = false;
			}
			else
			{
				if (this.defaultSerialSendData==null)
				{
					this.defaultSerialSendData = new CCommData(0x55, 64, CCOMM_CRC.CRC_NONE);
				}
				this.defaultSerialSendData.mLength = 0;
				if (this.defaultSerialSendData.mByte == null)
				{
					this.defaultSerialSendData.mByte = new List<byte>();
				}
				else
				{
					this.defaultSerialSendData.mByte.Clear();
				}
				if (this.mMultiAddr == true)
				{
					//---通过报头判断是否需要进行
					if (cmd[0] == this.defaultSerialParam.mAddrID)
					{
						this.defaultSerialSendData.mByte.AddRange(cmd);
					}
					else
					{
						this.defaultSerialSendData.mByte.Add((byte)this.defaultSerialSendData.mID);
						this.defaultSerialSendData.mByte.Add(0x00);
						//---传输数据的长度。默认是8Bits长度，最大支持16Bits长度
						if (this.defaultSerialSendData.mSize > 255)
						{
							this.defaultSerialSendData.mByte.Add(0x00);
						}
						//---设备地址
						this.defaultSerialSendData.mByte.Add((byte)this.defaultSerialParam.mAddrID);
						//---填充命令
						this.defaultSerialSendData.mByte.AddRange(cmd);
					}
				}
				else
				{
					//---通过报头判断是否需要进行
					if (cmd[0] == this.defaultSerialSendData.mID)
					{
						this.defaultSerialSendData.mByte.AddRange(cmd);
					}
					else
					{
						this.defaultSerialSendData.mByte.Add((byte)this.defaultSerialSendData.mID);
						this.defaultSerialSendData.mByte.Add(0x00);
						//---传输数据的长度。默认是8Bits长度，最大支持16Bits长度
						if (this.defaultSerialSendData.mSize > 255)
						{
							this.defaultSerialSendData.mByte.Add(0x00);
						}
						this.defaultSerialSendData.mByte.AddRange(cmd);
					}
				}
				//---计算传输数据的长度
				this.defaultSerialSendData.mLength = this.defaultSerialSendData.mByte.Count;
				//---判断数据长度是不是16Bits长度
				if (this.defaultSerialSendData.mSize > 255)
				{
					this.defaultSerialSendData.mLength -= 3;
					this.defaultSerialSendData.mByte[1] = (byte)(this.defaultSerialSendData.mLength>>8);
					this.defaultSerialSendData.mByte[2] = (byte)(this.defaultSerialSendData.mLength);
					this.defaultSerialSendData.mParentCMD = this.defaultSerialSendData.mByte[3];
					if (this.mMultiCMD)
					{
						this.defaultSerialSendData.mChildCMD = this.defaultSerialSendData.mByte[4];
					}
					else
					{
						this.defaultSerialSendData.mChildCMD = 0;
					}
				}
				else
				{
					this.defaultSerialSendData.mLength -= 2;
					this.defaultSerialSendData.mByte[1] = (byte)(this.defaultSerialSendData.mLength);
					this.defaultSerialSendData.mParentCMD = this.defaultSerialSendData.mByte[2];
					if (this.mMultiCMD)
					{
						this.defaultSerialSendData.mChildCMD = this.defaultSerialSendData.mByte[3];
					}
					else
					{
						this.defaultSerialSendData.mChildCMD = 0;
					}
				}

				//---计算CRC数据
				if (this.defaultSerialSendData.mCRCMode == CCOMM_CRC.CRC_CHECKSUM)
				{
					//---计算校验和
					this.defaultSerialSendData.mCRCVal = CGenFuncCRC.GenFuncCheckSum(this.defaultSerialSendData.mByte.ToArray(), this.defaultSerialSendData.mByte.Count);
					this.defaultSerialSendData.mByte.Add((byte)this.defaultSerialSendData.mCRCVal);
				}
				else if (this.defaultSerialSendData.mCRCMode == CCOMM_CRC.CRC_CRC8)
				{
					//---计算CRC8
					this.defaultSerialSendData.mCRCVal = CGenFuncCRC.GenFuncCRC8Table(CGenFuncCRC.USE_CRC8_Type.USE_CRC8_07H,this.defaultSerialSendData.mByte.ToArray(), this.defaultSerialSendData.mByte.Count);
					this.defaultSerialSendData.mByte.Add((byte)this.defaultSerialSendData.mCRCVal);
				}
				else if (this.defaultSerialSendData.mCRCMode == CCOMM_CRC.CRC_CRC16)
				{
					//---计算CRC16
					this.defaultSerialSendData.mCRCVal = CGenFuncCRC.GenFuncCRC16Table(this.defaultSerialSendData.mByte.ToArray(), this.defaultSerialSendData.mByte.Count);
					this.defaultSerialSendData.mByte.Add((byte)(this.defaultSerialSendData.mCRCVal>>8));
					this.defaultSerialSendData.mByte.Add((byte)this.defaultSerialSendData.mCRCVal);
				}
				else if (this.defaultSerialSendData.mCRCMode == CCOMM_CRC.CRC_CRC32)
				{
					//---计算CRC32
					this.defaultSerialSendData.mCRCVal = CGenFuncCRC.GenFuncCRC16Table(this.defaultSerialSendData.mByte.ToArray(), this.defaultSerialSendData.mByte.Count);
					this.defaultSerialSendData.mByte.Add((byte)(this.defaultSerialSendData.mCRCVal >> 24));
					this.defaultSerialSendData.mByte.Add((byte)(this.defaultSerialSendData.mCRCVal >> 16));
					this.defaultSerialSendData.mByte.Add((byte)(this.defaultSerialSendData.mCRCVal >> 8));
					this.defaultSerialSendData.mByte.Add((byte)this.defaultSerialSendData.mCRCVal);
				}
				//---计算CRC之后，重新整理数据长度
				if (this.defaultSerialSendData.mCRCMode != CCOMM_CRC.CRC_NONE)
				{
					//---计算传输数据的长度
					this.defaultSerialSendData.mLength = this.defaultSerialSendData.mByte.Count;
					//---判断数据长度是不是16Bits长度
					if (this.defaultSerialSendData.mSize > 255)
					{
						this.defaultSerialSendData.mLength -= 3;
						this.defaultSerialSendData.mByte[1] = (byte)(this.defaultSerialSendData.mLength >> 8);
						this.defaultSerialSendData.mByte[2] = (byte)(this.defaultSerialSendData.mLength);
					}
					else
					{
						this.defaultSerialSendData.mByte[1] = (byte)(this.defaultSerialSendData.mLength);
					}
				}
				_return = true;
			}
			return _return;
		}

		#endregion

		#region 私有函数

		#endregion

		#region 事件函数

		#endregion
	}
}
