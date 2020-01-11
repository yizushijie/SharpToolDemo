using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Harry.LabTools.LabCommType
{
	public partial class CCommSerialFullForm : CCommBaseForm
	{
		#region 变量定义

		#endregion

		#region 属性定义

		/// <summary>
		/// 串口参数
		/// </summary>
		public override CCommSerialParam mCCommSrialParam
		{
			get
			{
				return new CCommSerialParam(this.cCommSerial.mCCommName, this.cCommSerial.mBaudRate, this.cCommSerial.mStopBits, this.cCommSerial.mDataBits, this.cCommSerial.mParity,this.cCommSerial.mAddrID);
			}
		}
		
		/// <summary>
		/// 接收数据校验方式
		/// </summary>
		public override CCOMM_CRC mRxCRC
		{
			get
			{
				return this.cCommSerial.mRxCRC;
			}
		}

		/// <summary>
		/// 发送数据校验方式
		/// </summary>
		public override CCOMM_CRC mTxCRC
		{
			get
			{
				return this.cCommSerial.mTxCRC;
			}
		}

		/// <summary>
		/// 每包字节的大小
		/// </summary>
		public override int mPerPackageMaxSize
		{
			get
			{
				return this.cCommSerial.mPerPackageMaxSize;
			}
		}

		#endregion

		#region 构造函数

		/// <summary>
		/// 构造函数
		/// </summary>
		public CCommSerialFullForm() : base()
		{
			InitializeComponent();
		}


		/// <summary>
		/// 构造函数
		/// </summary>
		public CCommSerialFullForm(bool isLimitedSize = false)
		{
			InitializeComponent();
			//---判断是否限定最小尺寸
			if (isLimitedSize)
			{
				//---限制窗体的大小
				this.MinimumSize = this.Size;
				this.MaximumSize = this.Size;
			}
		}

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="text"></param>
		/// <param name="isLimitedSize"></param>
		public CCommSerialFullForm(int perPackageSize, CCommBase cComm, string text = null, bool isLimitedSize = false)
		{
			InitializeComponent();

			if ((!string.IsNullOrEmpty(text)))
			{
				this.cCommSerial.mButton.Text = text;
			}

			//---判断是否限定最小尺寸
			if (isLimitedSize)
			{
				//---限制窗体的大小
				this.MinimumSize = this.Size;
				this.MaximumSize = this.Size;
			}
			this.Init(perPackageSize, cComm);
		}

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="text"></param>
		/// <param name="isLimitedSize"></param>
		public CCommSerialFullForm(int perPackageSize, ComboBox cbb, CCommBase cComm, string text = null, bool isLimitedSize = false)
		{
			InitializeComponent();

			if ((!string.IsNullOrEmpty(text)))
			{
				this.cCommSerial.mButton.Text = text;
			}

			//---判断是否限定最小尺寸
			if (isLimitedSize)
			{
				//---限制窗体的大小
				this.MinimumSize = this.Size;
				this.MaximumSize = this.Size;
			}
			this.Init(perPackageSize, cbb, cComm);
		}

		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="cbb"></param>
		/// <param name="cComm"></param>
		/// <param name="msg"></param>
		/// <param name="text"></param>
		/// <param name="isLimitedSize"></param>
		public CCommSerialFullForm(int perPackageSize, ComboBox cbb, CCommBase cComm, RichTextBox msg = null, string text = null, bool isLimitedSize = false)
		{
			InitializeComponent();

			if ((!string.IsNullOrEmpty(text)))
			{
				this.cCommSerial.mButton.Text = text;
			}

			//---判断是否限定最小尺寸
			if (isLimitedSize)
			{
				//---限制窗体的大小
				this.MinimumSize = this.Size;
				this.MaximumSize = this.Size;
			}
			this.Init(perPackageSize, cbb, cComm);
		}

		#endregion

		#region 析构函数

		/// <summary>
		/// 析构函数
		/// </summary>
		~CCommSerialFullForm()
		{
			this.FreeResource();
		}

		/// <summary>
		/// 
		/// </summary>
		public override void FreeResource()
		{
			base.FreeResource();
			if (this.cCommSerial != null)
			{
				GC.SuppressFinalize(this.cCommSerial);
			}
			GC.SuppressFinalize(this);
		}

		#endregion

		#region 公有函数

		#endregion

		#region 保护函数

		#endregion

		#region 私有函数

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cComm"></param>
		private void Init(int perPackageSize, CCommBase cComm)
		{
			if (cComm != null)
			{
				this.cCommSerial.RemoveComboBoxMouseDownClick();
				this.cCommSerial.RemoveButtonClick();
				this.cCommSerial.mPerPackageMaxSize = perPackageSize;
				//---加载按钮事件
				this.cCommSerial.mButton.Click += new EventHandler(this.ParamShowDialog_Click);
			}
			else
			{
				this.DialogResult = DialogResult.None;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cbb"></param>
		/// <param name="cComm"></param>
		private void Init(int perPackageSize, ComboBox cbb, CCommBase cComm)
		{
			if (cComm != null)
			{
				this.cCommSerial.RemoveComboBoxMouseDownClick();
				this.cCommSerial.RemoveButtonClick();
				this.cCommSerial.RefreshCOMM(cbb);
				this.cCommSerial.mPerPackageMaxSize = perPackageSize;

				//---传递端口类型
				this.cCommSerial.mCCOMM = cComm;

				//---加载按钮事件
				this.cCommSerial.mButton.Click += new EventHandler(this.ParamShowDialog_Click);
				//---波特率
				this.cCommSerial.AnalyseBaudRate(cComm.mSerialParam.mBaudRate);
				//---数据位
				this.cCommSerial.AnalyseDataBits(cComm.mSerialParam.mDataBits);
				//---停止位
				this.cCommSerial.AnalyseStopBits(cComm.mSerialParam.mStopBits);
				//---校验位
				this.cCommSerial.AnalyseParity(cComm.mSerialParam.mParity);
				//---设备地址
				this.cCommSerial.AnalyseAddrID(cComm.mSerialParam.mAddrID.ToString());
				//---包大小
				this.cCommSerial.AnalysePerPackageMaxSize(perPackageSize);
				//---数据发送校验方式
				this.cCommSerial.AnalyseTxCRC((int)cComm.mSendData.mCRCMode);
				//---数据接收校验方式
				this.cCommSerial.AnalyseRxCRC((int)cComm.mReceData.mCRCMode);
			}
			else
			{
				this.DialogResult = DialogResult.None;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cbb"></param>
		/// <param name="cComm"></param>
		/// <param name="msg"></param>
		private void Init(int perPackageSize, ComboBox cbb, CCommBase cComm, RichTextBox msg = null)
		{
			if (cComm != null)
			{
				this.cCommSerial.RemoveComboBoxMouseDownClick();
				this.cCommSerial.RemoveButtonClick();
				this.cCommSerial.RefreshCOMM(cbb);
				this.cCommSerial.mPerPackageMaxSize = perPackageSize;

				//---传递端口类型
				this.cCommSerial.mCCOMM = cComm;
				this.cCommSerial.mCCommRichTextBox = msg;

				//---加载按钮事件
				this.cCommSerial.mButton.Click += new EventHandler(this.ParamShowDialog_Click);
				//---波特率
				this.cCommSerial.AnalyseBaudRate(cComm.mSerialParam.mBaudRate);
				//---数据位
				this.cCommSerial.AnalyseDataBits(cComm.mSerialParam.mDataBits);
				//---停止位
				this.cCommSerial.AnalyseStopBits(cComm.mSerialParam.mStopBits);
				//---校验位
				this.cCommSerial.AnalyseParity(cComm.mSerialParam.mParity);
				//---设备地址
				this.cCommSerial.AnalyseAddrID(cComm.mSerialParam.mAddrID.ToString());
				//---包大小
				this.cCommSerial.AnalysePerPackageMaxSize(perPackageSize);
				//---数据发送校验方式
				this.cCommSerial.AnalyseTxCRC((int)cComm.mSendData.mCRCMode);
				//---数据接收校验方式
				this.cCommSerial.AnalyseRxCRC((int)cComm.mReceData.mCRCMode);
			}
			else
			{
				this.DialogResult = DialogResult.None;
			}
		}

		#endregion

		#region 事件函数

		/// <summary>
		/// 按键点击事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public override void ParamShowDialog_Click(object sender, System.EventArgs e)
		{
			//---返回操作完成状态
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
		}

		#endregion

	}
}
