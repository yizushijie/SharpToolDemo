using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Harry.LabTools.LabCommType
{
	public partial class CCommBase : ICommParam
	{
		#region 变量定义

		/// <summary>
		/// 通讯方式的类型
		/// </summary>
		private CCOMM_TYPE defaultCCommType = CCOMM_TYPE.COMM_SERIAL;

		#endregion

		#region 公共属性

		/// <summary>
		/// 通讯端口的类型
		/// </summary>
		public virtual CCOMM_TYPE mType
		{
			get
			{
				return this.defaultCCommType;
			}
			set
			{
				this.defaultCCommType = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual string mName
		{
			get
			{
				return string.Empty;
			}
			set
			{
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual int mIndex
		{
			get
			{
				return -1;
			}
			set
			{
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual string mInfo
		{
			get
			{
				return string.Empty;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual int mTimeout
		{
			get
			{
				return 200;
			}
			set
			{
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual bool mMultiAddr
		{
			get
			{
				return false;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual bool mMultiCMD
		{
			get
			{
				return false;
			}
			set
			{
			}
		}


		/// <summary>
		/// 端口是否打开
		/// </summary>
		public virtual bool mOpen
		{
			get
			{
				return false;
			}
		}

		/// <summary>
		/// 消息信息
		/// </summary>
		public virtual string mLogMsg
		{
			get
			{
				return null;
			}
		}

		/// <summary>
		/// 通讯状态
		/// </summary>
		public virtual CCOMM_STATE mCOMMSTATE
		{
			get
			{
				return CCOMM_STATE.STATE_IDLE;
			}
		}

		/// <summary>
		/// 使用的时间
		/// </summary>
		public virtual TimeSpan mUsedTime
		{
			get
			{
				return new TimeSpan();
			}
		}

		/// <summary>
		/// 设备连接状态
		/// </summary>
		public virtual bool mConnected
		{
			get
			{
				return false;
			}
		}

		/// <summary>
		/// 设备是否发生变化,TRUE---发生变化，FALSE---未变化
		/// </summary>
		public virtual bool mChanged
		{
			get
			{
				return false;
			}
			set
			{

			}
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual bool mFullParam
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		/// <summary>
		/// 每包字节的大小
		/// </summary>
		public virtual int mPerPackageMaxSize
		{
			get
			{
				return 64;
			}
			set
			{
			
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public virtual int mFirstCMDIndex
		{
			get
			{
				if (this.mPerPackageMaxSize > 0xFF)
				{
					return 3;
				}
				else
				{
					return 2;
				}
			}
		}

		#endregion

		#region 串口属性

		/// <summary>
		/// 串行参数
		/// </summary>
		public virtual CCommSerialParam mSerialParam
		{
			get
			{
				return null;
			}
			set
			{

			}
		}

		#endregion

		#region USB属性

		/// <summary>
		/// USB属性
		/// </summary>
		public virtual CCommUSBParam mUSBParam
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		#endregion

		#region 函数定义

		/// <summary>
		/// 初始化串口参数
		/// </summary>
		/// <param name="serialParam"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int Init(CCommSerialParam serialParam, RichTextBox msg = null)
		{
			return -1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="serialParam"></param>
		/// <param name="rxCRC"></param>
		/// <param name="tcCRC"></param>
		/// <param name="msg"></param>
		public virtual int Init(CCommSerialParam serialParam, CCOMM_CRC rxCRC, CCOMM_CRC txCRC, RichTextBox msg = null)
		{
			return -1;
		}
		/// <summary>
		/// 初始化USB参数
		/// </summary>
		/// <param name="uSBParam"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int Init(CCommUSBParam usbParam, RichTextBox msg = null)
		{
			return -1;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="usbParam"></param>
		/// <param name="rxCRC"></param>
		/// <param name="tcCRC"></param>
		/// <param name="msg"></param>
		/// <returns></returns>
		public virtual int Init(CCommUSBParam usbParam, CCOMM_CRC rxCRC, CCOMM_CRC txCRC, RichTextBox msg = null)
		{
			return -1;
		}

		/// <summary>
		/// 分析参数
		/// </summary>
		/// <param name="serialParam"></param>
		/// <param name="uSBParam"></param>
		public virtual void  AnalyseParam( int perPackageSize,CCommSerialParam serialParam,CCommUSBParam usbParam,bool isUpAddrID=false)
		{
			if ((serialParam!=null)&&(this.mSerialParam!=null))
			{
				this.mSerialParam.mName		=serialParam.mName		;
				this.mSerialParam.mBaudRate	=serialParam.mBaudRate	;
				this.mSerialParam.mStopBits	=serialParam.mStopBits	;
				this.mSerialParam.mDataBits	=serialParam.mDataBits	;
				this.mSerialParam.mParity	=serialParam.mParity	;
				//---是否需要更新ID
				if (isUpAddrID)
				{
					this.mSerialParam.mAddrID = serialParam.mAddrID;
				}

				this.mName = this.mSerialParam.mName;
            }
			if ((usbParam!=null)&&(this.mUSBParam!=null))
			{
				this.mUSBParam.mVID=mUSBParam.mVID;
				this.mUSBParam.mPID=mUSBParam.mPID;
			}
			this.mPerPackageMaxSize = perPackageSize;
		}

		/// <summary>
		/// 分析参数
		/// </summary>
		/// <param name="serialParam"></param>
		/// <param name="uSBParam"></param>
		public virtual void AnalyseParam(int perPackageSize, CCommSerialParam serialParam, CCommUSBParam usbParam,CCOMM_CRC rxCRC, CCOMM_CRC txCRC, bool isUpAddrID = false)
		{
			if ((serialParam != null) && (this.mSerialParam != null))
			{
				this.mSerialParam.mName		= serialParam.mName		;
				this.mSerialParam.mBaudRate = serialParam.mBaudRate	;
				this.mSerialParam.mStopBits = serialParam.mStopBits	;
				this.mSerialParam.mDataBits = serialParam.mDataBits	;
				this.mSerialParam.mParity	= serialParam.mParity	;
				//---是否需要更新ID
				if ((isUpAddrID)&&(this.mSerialParam.mAddrID != serialParam.mAddrID))
				{
					this.mSerialParam.mAddrID = serialParam.mAddrID;
				}
				this.mName = this.mSerialParam.mName;
				
			}
			if ((usbParam != null) && (this.mUSBParam != null))
			{
				this.mUSBParam.mVID = mUSBParam.mVID;
				this.mUSBParam.mPID = mUSBParam.mPID;
			}
			//---发送数据校验方式
			this.mSendData.mCRCMode = txCRC;
			//---接收数据校验方式
			this.mReceData.mCRCMode = rxCRC;
			this.mPerPackageMaxSize = perPackageSize;
		}

		#endregion

	}
}
