using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace Harry.LabTools.LabMcuFunc
{
	/// <summary>
	/// 芯片的基本信息
	/// </summary>
	public class CMcuFuncInfoAVR8BitsParam : CMcuFuncInfoBaseParam,IMcuFuncInfoAVR8BitsParam 
	{
		#region 变量定义

		/// <summary>
		/// 设备支持的编程接口
		/// </summary>
		private readonly string[] defaultInterfaceName = new string[4] { "ISP", "JTAG", "HVPP", "HVSP" };

		/// <summary>
		/// 当前设备的名称
		/// </summary>
		private string defaultChipName = string.Empty;// "ATmega8";

		/// <summary>
		/// MCU参数的解析结果，true---正常，false---失效
		/// </summary>
		private bool defaultChipInfoOK = true;

		/// <summary>
		/// 编程接口名称
		/// </summary>
		/// { "ISP", "JTAG", "HVPP", "HVSP" };
		/// <summary>
		/// 支持的编程接口
		/// </summary>
		private CMcuFuncAVR8BitsParam defaultInterface = null;//new byte[] { (byte)AVR8BITS_PROG_INTERFACE.ISP, (byte)AVR8BITS_PROG_INTERFACE.HVPP };

		/// <summary>
		/// 芯片是否支持轮训模式，true---支持，编程查询表示；false---不支持，编程通过延时指定
		/// </summary>
		private bool defaultChipPollReady = false;

		/// <summary>
		/// 设备ID信息
		/// </summary>
		private byte[] defaultChipID = null;// new byte[] { 0x1E, 0x93, 0x07 };

		/// <summary>
		/// 设备的JTAG的ID信息
		/// </summary>
		private int defaultIDChip = 0x00;

		/// <summary>
		/// 设备的熔丝位
		/// </summary>
		private byte[] defaultChipFuse = null;//new byte[] { 0xE1, 0xD9 };

		/// <summary>
		/// 芯片的加密位
		/// </summary>
		private byte defaultChipLock = 0;//0xFF;

		/// <summary>
		/// 芯片的Flash的页数
		/// </summary>
		private int defaultChipFlashPageNum = 0;//128;

		/// <summary>
		/// 芯片Flash的每页字节数
		/// </summary>
		private int defaultChipFlashPerPageWordNum = 0;//32;

		/// <summary>
		/// 芯片的Eeprom的页数
		/// </summary>
		private int defaultChipEepromPageNum = 0;//128;

		/// <summary>
		/// 芯片Eeprom的每页字节数
		/// </summary>
		private int defaultChipEepromPerPageByteNum = 0;// 4;

		/// <summary>
		/// eeprom是否支持页编程模式，true---支持，false---不支持
		/// </summary>
		private bool defaultChipEepromPageMode = false;

		/// <summary>
		/// 设备的校准字
		/// </summary>
		private CMcuFuncAVR8BitsParam defaultChipOSCCalibration = null;

		/// <summary>
		/// 低位熔丝位,Bits信息
		/// </summary>
		private CMcuFuncAVR8BitsParam defaultChipLowFuseBits = null;

		/// <summary>
		/// 低位熔丝位,Text信息
		/// </summary>
		private CMcuFuncAVR8BitsParam defaultChipLowFuseText = null;

		/// <summary>
		/// 高位熔丝位
		/// </summary>
		private CMcuFuncAVR8BitsParam defaultChipHighFuseBits = null;

		/// <summary>
		/// 高位熔丝位
		/// </summary>
		private CMcuFuncAVR8BitsParam defaultChipHighFuseText = null;

		/// <summary>
		/// 拓展位熔丝位
		/// </summary>
		private CMcuFuncAVR8BitsParam defaultChipExternFuseBits = null;

		/// <summary>
		/// 拓展位熔丝位
		/// </summary>
		private CMcuFuncAVR8BitsParam defaultChipExternFuseText = null;

		/// <summary>
		/// 加密位熔丝位
		/// </summary>
		private CMcuFuncAVR8BitsParam defaultChipLockFuseBits = null;

		/// <summary>
		/// 加密位熔丝位
		/// </summary>
		private CMcuFuncAVR8BitsParam defaultChipLockFuseText = null;

		/// <summary>
		/// 错误消息提示
		/// </summary>
		private string defaultMsgText = "";

		/// <summary>
		///功能操作1
		/// </summary>
		private CMcuFuncMaskParam defaultChipFuncMask1 = new CMcuFuncMaskParam(0, 0B00010110);

		/// <summary>
		/// 功能操作1
		/// </summary>
		private CMcuFuncMaskParam defaultChipFuncMask2 = new CMcuFuncMaskParam(0, 0B00000010);

		#endregion

		#region 属性定义

		/// <summary>
		/// 芯片类型属性为只读
		/// </summary>
		public override string mTypeChip
		{
			get
			{
				return "AVR";
			}
		}

		/// <summary>
		/// 芯片名称属性为只读
		/// </summary>
		public override string mTypeName
		{
			get
			{
				return this.mChipName;
			}
		}

		/// <summary>
		/// mcu的类型为读写属性
		/// </summary>
		public override MCU_INFO_TYPE mTypeMcuInfo
		{
			get
			{
				return MCU_INFO_TYPE.MCU_AVR8BITS;
			}
		}

		/// <summary>
		/// 参数解析结果的正常的属性为只读
		/// </summary>
		public virtual bool mChipInfoOK
		{
			get
			{
				return this.defaultChipInfoOK;
			}
		}

		/// <summary>
		/// 芯片名称为读写属性
		/// </summary>
		public virtual string mChipName
		{
			get
			{
				return this.defaultChipName;			
			}
			set
			{
				this.defaultChipName = value;
			}
		}

		/// <summary>
		/// 支持的总编程接口为只读属性
		/// </summary>
		public virtual string[] mChipInterfaceName
		{
			get
			{
				return this.defaultInterfaceName;
			}
		}

		/// <summary>
		/// 设备支持的编程接口为只读属性
		/// </summary>
		public virtual CMcuFuncAVR8BitsParam mChipInterface
		{
			get
			{
				return this.defaultInterface;
			}
			//set
			//{
			//	if (this.defaultInterface == null)
			//	{
			//		this.defaultInterface = new CMcuAVR8BitsParam(value);
			//	}
			//	else
			//	{
			//		this.defaultInterface.Init(value);
			//	}
			//}
		}

		/// <summary>
		/// Chip支持轮序模式未只读属性
		/// </summary>
		public virtual bool mPollReady
		{
			get
			{
				return this.defaultChipPollReady;
			}
		}

		/// <summary>
		/// Chip的ID信息为读写属性
		/// </summary>
		public virtual byte[] mChipID
		{
			get
			{
				return this.defaultChipID;
			}
			//set
			//{
			//	if (value != null)
			//	{
			//		this.defaultChipID = new byte[value.Length];
			//		//---数据拷贝
			//		Array.Copy(value, this.defaultChipID, value.Length);
			//	}
			//}
		}

		/// <summary>
		/// JTAG的ID信息为读写属性
		/// </summary>
		public virtual int mIDChip
		{
			get
			{
				return this.defaultIDChip;
			}
			//set
			//{
			//	this.defaultIDChip = value;
			//}
		}

		/// <summary>
		/// 熔丝位为读写属性
		/// </summary>
		public virtual byte[] mChipFuse
		{
			get
			{
				return this.defaultChipFuse;
			}
			set
			{
				if (value != null)
				{
					this.defaultChipFuse = new byte[value.Length];
					//---数据拷贝
					Array.Copy(value, this.defaultChipFuse, value.Length);
				}
			}
		}

		/// <summary>
		/// 默认熔丝位
		/// </summary>
		public virtual byte[] mDefaultFuse
		{
			get
			{
				if (this.defaultChipFuse != null)
				{
					byte[] _return = new byte[this.defaultChipFuse.Length];
					for (int i = 0; i < _return.Length; i++)
					{
						_return[i] = (byte)this.defaultChipOSCCalibration.mMask[i];
					}
					return _return;
				}
				else
				{
					return null;
				}
			}
		}
		/// <summary>
		/// 加密位为读写属性
		/// </summary>
		public virtual byte mChipLock
		{
			get
			{
				return this.defaultChipLock;
			}
			set
			{
				this.defaultChipLock = value;
			}
		}

		/// <summary>
		/// Flash的页数为读写属性
		/// </summary>
		public virtual int mChipFlashPageNum
		{
			get
			{
				return this.defaultChipFlashPageNum;
			}
			//set
			//{
			//	this.defaultChipFlashPageNum = value;
			//}
		}

		/// <summary>
		/// 每页Flash的字数为读写属性
		/// </summary>
		public virtual int mChipFlashPerPageWordNum
		{
			get
			{
				return this.defaultChipFlashPerPageWordNum;
			}
			//set
			//{
			//	this.defaultChipFlashPerPageWordNum = value;
			//}
		}

		/// <summary>
		/// 每页Flash的字节数为只读属性
		/// </summary>
		public virtual int mChipFlashPerPageByteNum
		{
			get
			{
				return this.defaultChipFlashPerPageWordNum * 2;
			}
		}

		/// <summary>
		/// 芯片ROM页的字大小为只读属性
		/// </summary>
		public virtual int mChipRomWordSize
		{
			get
			{
				return this.defaultChipFlashPerPageWordNum;
			}
		}

		/// <summary>
		/// ROM页的字节大小为只读属性
		/// </summary>
		public virtual int mChipRomByteSize
		{
			get
			{
				return this.defaultChipFlashPerPageWordNum * 2;
			}
		}

		/// <summary>
		/// Flash的总字节数为只读属性
		/// </summary>
		public virtual long mChipFlashByteSize
		{
			get
			{
				return (((long)this.defaultChipFlashPageNum) * this.defaultChipFlashPerPageWordNum * 2);
			}
		}

		/// <summary>
		/// Flash的总字数为只读属性
		/// </summary>
		public virtual long mChipFlashWordSize
		{
			get
			{
				return (((long)this.defaultChipFlashPageNum) * this.defaultChipFlashPerPageWordNum);
			}
		}

		/// <summary>
		/// Eeprom的页数为读写属性
		/// </summary>
		public virtual int mChipEepromPageNum
		{
			get
			{
				return this.defaultChipEepromPageNum;
			}
			//set
			//{
			//	this.defaultChipEepromPageNum = value;
			//}
		}

		/// <summary>
		/// Eeprom的每页字节数为读写属性
		/// </summary>
		public virtual int mChipEepromPerPageByteNum
		{
			get
			{
				return this.defaultChipEepromPerPageByteNum;
			}
			//set
			//{
			//	this.defaultChipEepromPerPageByteNum = value;
			//}
		}

		/// <summary>
		/// Eeprom的总字节数为读写属性
		/// </summary>
		public virtual long mChipEepromByteSize
		{
			get
			{
				return ((long)this.defaultChipEepromPageNum) * this.defaultChipEepromPerPageByteNum;
			}
		}

		/// <summary>
		/// Eeprom支持页编程模式
		/// </summary>
		public virtual bool mChipEepromPageMode
		{
			get
			{
				return this.defaultChipEepromPageMode;
			}
		}

		/// <summary>
		/// 内部OSC的校准字为读写属性
		/// </summary>
		public CMcuFuncAVR8BitsParam mChipOSCCalibration
		{
			get
			{
				return this.defaultChipOSCCalibration;
			}
			//set
			//{
			//	if (this.defaultChipOSCCalibration == null)
			//	{
			//		this.defaultChipOSCCalibration = new CMcuFuncAVR8BitsParam(value);
			//	}
			//	else
			//	{
			//		this.defaultChipOSCCalibration.Init(value);
			//	}
			//}
		}

		/// <summary>
		/// 熔丝位低位值为读写属性
		/// </summary>
		public CMcuFuncAVR8BitsParam mChipLowFuseBits
		{
			get
			{
				return this.defaultChipLowFuseBits;
			}
			//set
			//{
			//	if (this.defaultChipLowFuseBits == null)
			//	{
			//		this.defaultChipLowFuseBits = new CMcuFuncAVR8BitsParam(value);
			//	}
			//	else
			//	{
			//		this.defaultChipLowFuseBits.Init(value);
			//	}
			//}
		}

		/// <summary>
		/// 熔丝位低位值为读写属性
		/// </summary>
		public CMcuFuncAVR8BitsParam mChipLowFuseText
		{
			get
			{
				return this.defaultChipLowFuseText;
			}
			//set
			//{
			//	if (this.defaultChipLowFuseText == null)
			//	{
			//		this.defaultChipLowFuseText = new CMcuFuncAVR8BitsParam(value);
			//	}
			//	else
			//	{
			//		this.defaultChipLowFuseText.Init(value);
			//	}
			//}
		}

		/// <summary>
		/// 熔丝位高位值为读写属性
		/// </summary>
		public CMcuFuncAVR8BitsParam mChipHighFuseBits
		{
			get
			{
				return this.defaultChipHighFuseBits;
			}
			//set
			//{
			//	if (this.defaultChipHighFuseBits == null)
			//	{
			//		this.defaultChipHighFuseBits = new CMcuFuncAVR8BitsParam(value);
			//	}
			//	else
			//	{
			//		this.defaultChipHighFuseBits.Init(value);
			//	}
			//}
		}

		/// <summary>
		/// 熔丝位高位值为读写属性
		/// </summary>
		public CMcuFuncAVR8BitsParam mChipHighFuseText
		{
			get
			{
				return this.defaultChipHighFuseText;
			}
			//set
			//{
			//	if (this.defaultChipHighFuseText == null)
			//	{
			//		this.defaultChipHighFuseText = new CMcuFuncAVR8BitsParam(value);
			//	}
			//	else
			//	{
			//		this.defaultChipHighFuseText.Init(value);
			//	}
			//}
		}

		/// <summary>
		/// 熔丝位拓展位值为读写属性
		/// </summary>
		public CMcuFuncAVR8BitsParam mChipExternFuseBits
		{
			get
			{
				return this.defaultChipExternFuseBits;
			}
			//set
			//{
			//	if (this.defaultChipExternFuseBits == null)
			//	{
			//		this.defaultChipExternFuseBits = new CMcuFuncAVR8BitsParam(value);
			//	}
			//	else
			//	{
			//		this.defaultChipExternFuseBits.Init(value);
			//	}
			//}
		}

		/// <summary>
		/// 熔丝位拓展位值为读写属性
		/// </summary>
		public CMcuFuncAVR8BitsParam mChipExternFuseText
		{
			get
			{
				return this.defaultChipExternFuseText;
			}
			//set
			//{
			//	if (this.defaultChipExternFuseText == null)
			//	{
			//		this.defaultChipExternFuseText = new CMcuFuncAVR8BitsParam(value);
			//	}
			//	else
			//	{
			//		this.defaultChipExternFuseText.Init(value);
			//	}
			//}
		}

		/// <summary>
		/// 熔丝位加密位值为读写属性
		/// </summary>
		public CMcuFuncAVR8BitsParam mChipLockFuseBits
		{
			get
			{
				return this.defaultChipLockFuseBits;
			}
			//set
			//{
			//	if (this.defaultChipLockFuseBits == null)
			//	{
			//		this.defaultChipLockFuseBits = new CMcuFuncAVR8BitsParam(value);
			//	}
			//	else
			//	{
			//		this.defaultChipLockFuseBits.Init(value);
			//	}
			//}
		}

		/// <summary>
		/// 熔丝位加密位值为读写属性
		/// </summary>
		public CMcuFuncAVR8BitsParam mChipLockFuseText
		{
			get
			{
				return this.defaultChipLockFuseText;
			}
			//set
			//{
			//	if (this.defaultChipLockFuseText == null)
			//	{
			//		this.defaultChipLockFuseText = new CMcuFuncAVR8BitsParam(value);
			//	}
			//	else
			//	{
			//		this.defaultChipLockFuseText.Init(value);
			//	}
			//}
		}

		/// <summary>
		/// 消息为读写属性
		/// </summary>
		public virtual string mMsgText
		{
			get
			{
				return this.defaultMsgText;		
			}
			set
			{
				this.defaultMsgText = value;
			}
		}

		/// <summary>
		/// 功能步骤1为读写属性
		/// </summary>
		public virtual CMcuFuncMaskParam mChipFuncMask1
		{
			get
			{
				return this.defaultChipFuncMask1;
			}
			set
			{
				this.defaultChipFuncMask1 = value;
			}
		}

		/// <summary>
		/// 功能步骤2为读写属性
		/// </summary>
		public virtual CMcuFuncMaskParam mChipFuncMask2
		{
			get
			{
				return this.defaultChipFuncMask2;
			}
			set
			{
				this.defaultChipFuncMask2 = value;
			}
		}

		#endregion

		#region 构造函数

		/// <summary>
		/// 无参数的构造函数
		/// </summary>
		public CMcuFuncInfoAVR8BitsParam ()
		{
			
		}

		/// <summary>
		/// 带有参数的构造函数
		/// </summary>
		/// <param name="mcuInfo"></param>
		public CMcuFuncInfoAVR8BitsParam (CMcuFuncInfoAVR8BitsParam cMcuFuncInfoAVR8BitsParam)
		{
			
		}

		#endregion

		#region 公有函数

		/// <summary>
		/// MCU信息
		/// </summary>
		/// <param name="chipName"></param>
		/// <returns></returns>
		public override bool McuTypeInfo(string chipName, ComboBox cbbInterface = null, TextBox tbChipID = null)
		{
			//---解析MCU的基本信息
			bool _return = this.AnalyseAVR8BitsMcuInfo(chipName.ToLower());
			//---判断解析结果和校验接口控件
			if ((_return==true)&&(cbbInterface!=null))
			{
				_return = this.McuInterfaceInfo(cbbInterface);
			}
			//---校验ChipID
			if ((_return==true)&&(tbChipID!=null))
			{
				if (tbChipID.InvokeRequired)
				{
					tbChipID.BeginInvoke((EventHandler)
							 //cbb.Invoke((EventHandler)
							 (delegate
							 {
								 tbChipID.Text = this.defaultChipID[0].ToString("X2").ToUpper()
								 + ":" + this.defaultChipID[1].ToString("X2").ToUpper()
								 + ":" + this.defaultChipID[2].ToString("X2").ToUpper();
							 }));
				}
				else
				{
					tbChipID.Text = this.defaultChipID[0].ToString("X2").ToUpper() + ":" + this.defaultChipID[1].ToString("X2").ToUpper() + ":" + this.defaultChipID[2].ToString("X2").ToUpper();
				}
			}
			return _return ;
		}

		/// <summary>
		/// MCU列表信息
		/// </summary>
		/// <param name="chipName"></param>
		/// <returns></returns>
		public override string[] McuListInfo(ComboBox cbbList = null)
		{
			string[] _return = this.AnalyseAVR8BitsMcuList();
			if ((_return!=null)&&(cbbList!=null))
			{
				if (cbbList.InvokeRequired)
				{
					cbbList.BeginInvoke((EventHandler)
							 //cbb.Invoke((EventHandler)
							 (delegate
							 {
								 cbbList.Items.Clear();
								 cbbList.Items.AddRange(_return);
								 cbbList.SelectedIndex = 0;
							 }));
				}
				else
				{
					cbbList.Items.Clear();
					cbbList.Items.AddRange(_return);
					cbbList.SelectedIndex = 0;
				}
				
			}
			return _return;
		}

		/// <summary>
		/// MCU默认熔丝位
		/// </summary>
		/// <returns></returns>
		public override int[] McuDefaultFuseInfo()
		{
			return this.defaultChipOSCCalibration.mMask;
		}

		/// <summary>
		/// MCU的接口信息
		/// </summary>
		/// <param name="cbbInterface"></param>
		/// <returns></returns>
		public override bool McuInterfaceInfo(ComboBox cbbInterface)
		{
			if (cbbInterface!=null)
			{
				if (cbbInterface.InvokeRequired)
				{
					cbbInterface.BeginInvoke((EventHandler)
							 //cbb.Invoke((EventHandler)
							 (delegate
							 {
								 cbbInterface.Items.Clear();
								 if (this.defaultInterface != null)
								 {
									 cbbInterface.Items.AddRange(this.defaultInterface.mText);
									 cbbInterface.SelectedIndex = 0;
								 }
							 }));
				}
				else
				{
					cbbInterface.Items.Clear();
					if (this.defaultInterface!=null)
					{
						cbbInterface.Items.AddRange(this.defaultInterface.mText);
						cbbInterface.SelectedIndex = 0;
					}
				}
				return true;
			}
			return false;
		}

		/// <summary>
		/// 初始化控件
		/// </summary>
		public void FormControlInit(CheckedListBox lowFuseBits, CheckedListBox highFuseBits, CheckedListBox externFuseBits, CheckedListBox lockFuseBits,
									CheckedListBox fuseText,
									Label oscText1,Label oscText2,Label oscText3,Label oscText4,
									TextBox oscValue1,TextBox oscValue2,TextBox oscValue3,TextBox oscValue4,
									TextBox lowFuseValue, TextBox highFuseValue, TextBox externFuseValue, TextBox lockFuseValue)
		{
			this.FuseCheckedListBoxBitsInit(lowFuseBits,	this.defaultChipLowFuseBits);
			this.FuseCheckedListBoxBitsInit(highFuseBits,	this.defaultChipHighFuseBits);
			//---判断拓展位是不是全部都是NC，自动规避XML文件存在的细小差异
			if (this.FuseCheckedListBoxBitsInit(externFuseBits, this.defaultChipExternFuseBits) == 8)
			{
				this.defaultChipExternFuseText = null;
			}
			this.FuseCheckedListBoxBitsInit(lockFuseBits,	this.defaultChipLockFuseBits);
			this.FuseCheckedListBoxTextInit(fuseText, lowFuseValue,highFuseValue,externFuseValue,lockFuseValue);
			this.InternalRCOSControlInit(oscText1,oscText2,oscText3,oscText4,
								oscValue1, oscValue2, oscValue3, oscValue4);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="clb"></param>
		/// <param name="fuseBits"></param>
		public void FuseCheckedListBoxBitsRefresh(CheckedListBox clb, TextBox tb, int index)
		{
			int temp = 0;
			for (int i = 0; i < 8; i++)
			{
				if (clb.InvokeRequired)
				{
					clb.BeginInvoke((EventHandler)
							 //cbb.Invoke((EventHandler)
							 (delegate
							 {
								 if (clb.Items[i].ToString() == "NC")
								 {
									 temp |= (1 << (7 - i));
								 }
								 else
								 {
									 string str = clb.Items[i].ToString();
									 if (clb.GetItemCheckState(i) == CheckState.Checked)
									 {
										 temp |= (1 << (7 - i));
									 }
									 else
									 {
										 temp &= ~(1 << (7 - i));
									 }
								 }
							 }));
				}
				else
				{
					if (clb.Items[i].ToString() == "NC")
					{
						temp |= (1 << (7 - i));
					}
					else
					{
						string str = clb.Items[i].ToString();
						if (clb.GetItemCheckState(i) == CheckState.Checked)
						{
							temp |= (1 << (7 - i));
						}
						else
						{
							temp &= ~(1 << (7 - i));
						}
					}
				}
				
			}
			if (index <3)
			{
				//---检验熔丝位的配置超出默认数组的大小
				if (this.defaultChipFuse.Length>index)
				{
					this.defaultChipFuse[index] = (byte)temp;
				}
				else
				{
					temp = 0;
				}
			}
			else
			{
				this.defaultChipLock = (byte)temp;
			}
			if (tb.InvokeRequired)
			{
				tb.BeginInvoke((EventHandler)
								 //cbb.Invoke((EventHandler)
								 (delegate
								 {
									 tb.Text = temp.ToString("X2").ToUpper();
								 }));
			}
			else
			{
				tb.Text = temp.ToString("X2").ToUpper();
			}
		}

		/// <summary>
		/// 属性改变值
		/// </summary>
		/// <param name="clb"></param>
		/// <param name="index"></param>
		public void FuseCheckedListBoxBitsRefresh(CheckedListBox clb,int fuseVal, int index)
		{
			int val = 0;
			if (index <3)
			{
				//if (fuseVal != this.defaultChipFuse[index]) 
				if (this.defaultChipFuse.Length > index)
				{
					this.defaultChipFuse[index] = (byte)fuseVal;
				}
				else
				{
					fuseVal = 0x00;
				}
				val = fuseVal;
			}
			else
			{
				if (fuseVal != this.defaultChipLock)
				{
					this.defaultChipLock = (byte)fuseVal;
				}
				val = this.defaultChipLock;
			}
			for (int i = 0; i < 8; i++)
			{
				if (clb.InvokeRequired)
				{
					clb.BeginInvoke((EventHandler)
									 //cbb.Invoke((EventHandler)
									 (delegate
									 {
										 if (clb.Items[i].ToString() == "NC")
										 {
											 clb.SetItemCheckState(i, CheckState.Indeterminate);  //是控件处于不可选定状态
										 }
										 else
										 {
											 if ((val & 0x80) == 0)
											 {
												 clb.SetItemCheckState(i, CheckState.Unchecked);
											 }
											 else
											 {
												 clb.SetItemCheckState(i, CheckState.Checked);
											 }
										 }
									 }));
				}
				else
				{
					if (clb.Items[i].ToString() == "NC")
					{
						clb.SetItemCheckState(i, CheckState.Indeterminate);  //是控件处于不可选定状态
					}
					else
					{
						if ((val & 0x80) == 0)
						{
							clb.SetItemCheckState(i, CheckState.Unchecked);
						}
						else
						{
							clb.SetItemCheckState(i, CheckState.Checked);
						}
					}
				}
				
				val <<= 1;
			}
		}
		/// <summary>
		/// 刷新Text信息
		/// </summary>
		/// <param name="clb"></param>
		/// <param name="highFuse"></param>
		public bool FuseCheckedListBoxTextRefresh(CheckedListBox clb, int index)
		{
			int offset = 0;
			int fuseVal = 0;
			CMcuFuncAVR8BitsParam tempCMcuFuncInfo = null;
			if (clb == null)
			{
				return false;
			}
			else
			{
				//---校验低位熔丝位
				if (index == 0)
				{
					if ((this.defaultChipExternFuseText != null) && (this.defaultChipExternFuseText.mText.Length > 0))
					{
						offset += this.defaultChipExternFuseText.mLength;
					}
					if ((this.defaultChipHighFuseText != null) && (this.defaultChipHighFuseText.mText.Length > 0))
					{
						offset += this.defaultChipHighFuseText.mLength;
					}
					tempCMcuFuncInfo = this.defaultChipLowFuseText;
					//---低位熔丝位
					fuseVal = this.defaultChipFuse[0];
				}
				//---校验高位熔丝位
				else if (index == 1)
				{
					if ((this.defaultChipExternFuseText != null) && (this.defaultChipExternFuseText.mText.Length > 0))
					{
						offset += this.defaultChipExternFuseText.mLength;
					}
					tempCMcuFuncInfo = this.defaultChipHighFuseText;
					//---高位熔丝位
					fuseVal = this.defaultChipFuse[1];
				}
				//---校验拓展熔丝位
				else if (index == 2)
				{
					if ((this.defaultChipExternFuseText == null) ||(this.defaultChipExternFuseText.mText.Length == 0))
					{
						return false;
					}
					else
					{
						tempCMcuFuncInfo = this.defaultChipExternFuseText;
						//---拓展位熔丝位
						fuseVal = this.defaultChipFuse[2];
					}
				}
				//---校验加密熔丝位
				else if (index == 3)
				{
					if ((this.defaultChipExternFuseText!=null) &&(this.defaultChipExternFuseText.mText.Length > 0))
					{
						offset += this.defaultChipExternFuseText.mLength;
					}
					if ((this.defaultChipHighFuseText!=null) &&(this.defaultChipHighFuseText.mText.Length > 0))
					{
						offset += this.defaultChipHighFuseText.mLength;
					}
					if ((this.defaultChipLowFuseText != null) && (this.defaultChipLowFuseText.mText.Length > 0))
					{
						offset += this.defaultChipLowFuseText.mLength;
					}
					tempCMcuFuncInfo = this.defaultChipLockFuseText;
					//---加密位熔丝位
					fuseVal = this.defaultChipLock;
				}
				else
				{
					return false;
				}
				//刷新text的状态
				for (int i = 0; i < tempCMcuFuncInfo.mLength; i++)
				{
					if (clb.InvokeRequired)
					{
						clb.BeginInvoke((EventHandler)
										 //cbb.Invoke((EventHandler)
										 (delegate
										 {
											 if ((fuseVal & tempCMcuFuncInfo.mMask[i]) == tempCMcuFuncInfo.mValue[i])
											 {
												 clb.SetItemCheckState(i + offset, CheckState.Checked);
											 }
											 else
											 {
												 clb.SetItemCheckState(i + offset, CheckState.Unchecked);
											 }
										 }));
					}
					else
					{
						if ((fuseVal & tempCMcuFuncInfo.mMask[i]) == tempCMcuFuncInfo.mValue[i])
						{
							clb.SetItemCheckState(i + offset, CheckState.Checked);
						}
						else
						{
							clb.SetItemCheckState(i + offset, CheckState.Unchecked);
						}
					}

				}
				return true;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="clbBits"></param>
		/// <param name="clbText"></param>
		/// <param name="tb"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		public bool FuseCheckedListBoxRefresh(CheckedListBox clbBits, CheckedListBox clbText, TextBox tb, int index)
		{
			this.FuseCheckedListBoxBitsRefresh(clbBits,tb, index);
			return this.FuseCheckedListBoxTextRefresh(clbText, index);
		}

		/// <summary>
		/// 获取改变的值
		/// </summary>
		/// <param name="clb"></param>
		/// <param name="val"></param>
		public void FuseCheckedListBoxRefresh(CheckedListBox clb, TextBox lowFuse, TextBox highFuse, TextBox externFuse, TextBox lockFuse )
		{
			int[] val = new int[] { Convert.ToByte(externFuse.Text, 16), Convert.ToByte(highFuse.Text, 16), Convert.ToByte(lowFuse.Text, 16), Convert.ToByte(lockFuse.Text, 16) };
			//---当前选择值
			int selectIndex = clb.SelectedIndex;
			int offset = 0;
			int temp = 0;
			CheckState cb = CheckState.Unchecked;
			if (clb.InvokeRequired)
			{
				clb.BeginInvoke((EventHandler)
										 //cbb.Invoke((EventHandler)
										 (delegate
										 {
											 cb =clb.GetItemCheckState(selectIndex);
										 }));
			}
			else
			{
				cb = clb.GetItemCheckState(selectIndex);
			}
			
			//---拓展熔丝位
			if ((this.defaultChipExternFuseText!=null) &&(this.defaultChipExternFuseText.mText.Length > 0))
			{
				if ((selectIndex < (this.defaultChipExternFuseText.mLength + offset)) && (selectIndex >= offset))
				{
					temp = this.defaultChipFuse[2];
					if (clb.InvokeRequired)
					{
						clb.BeginInvoke((EventHandler)
												 //cbb.Invoke((EventHandler)
												 (delegate
												 {
													 if (clb.GetItemCheckState(selectIndex) == CheckState.Unchecked)
													 {
														 if (!(	(this.defaultChipExternFuseText.mMask[selectIndex - offset] == 0x80) || 
																(this.defaultChipExternFuseText.mMask[selectIndex - offset] == 0x40) || 
																(this.defaultChipExternFuseText.mMask[selectIndex - offset] == 0x20) || 
																(this.defaultChipExternFuseText.mMask[selectIndex - offset] == 0x10) ||
																(this.defaultChipExternFuseText.mMask[selectIndex - offset] == 0x08) || 
																(this.defaultChipExternFuseText.mMask[selectIndex - offset] == 0x04) || 
																(this.defaultChipExternFuseText.mMask[selectIndex - offset] == 0x02) || 
																(this.defaultChipExternFuseText.mMask[selectIndex - offset] == 0x01)))
														 {
															 clb.SetItemCheckState(selectIndex, CheckState.Checked);
															 return;
														 }

														 temp |= this.defaultChipExternFuseText.mMask[selectIndex - offset] | (this.defaultChipExternFuseText.mValue[selectIndex - offset]);
													 }
													 else
													 {
														 temp = temp & (~this.defaultChipExternFuseText.mMask[selectIndex - offset]) | (this.defaultChipExternFuseText.mValue[selectIndex - offset]);
													 }
												 }));
					}
					else
					{
						if (clb.GetItemCheckState(selectIndex) == CheckState.Unchecked)
						{
							if (!(	(this.defaultChipExternFuseText.mMask[selectIndex - offset] == 0x80) || 
									(this.defaultChipExternFuseText.mMask[selectIndex - offset] == 0x40) || 
									(this.defaultChipExternFuseText.mMask[selectIndex - offset] == 0x20) || 
									(this.defaultChipExternFuseText.mMask[selectIndex - offset] == 0x10) ||
									(this.defaultChipExternFuseText.mMask[selectIndex - offset] == 0x08) || 
									(this.defaultChipExternFuseText.mMask[selectIndex - offset] == 0x04) || 
									(this.defaultChipExternFuseText.mMask[selectIndex - offset] == 0x02) || 
									(this.defaultChipExternFuseText.mMask[selectIndex - offset] == 0x01)))
							{
								clb.SetItemCheckState(selectIndex, CheckState.Checked);
								return;
							}

							temp |= this.defaultChipExternFuseText.mMask[selectIndex - offset] | (this.defaultChipExternFuseText.mValue[selectIndex - offset]);
						}
						else
						{
							temp = temp & (~this.defaultChipExternFuseText.mMask[selectIndex - offset]) | (this.defaultChipExternFuseText.mValue[selectIndex - offset]);
						}
					}
					
					this.defaultChipFuse[2] = (byte)temp;
					if (externFuse.InvokeRequired)
					{
						externFuse.BeginInvoke((EventHandler)
								 //cbb.Invoke((EventHandler)
								 (delegate
								 {
									 externFuse.Text = temp.ToString("X2").ToUpper();
								 }));
					}
					else
					{
						externFuse.Text = temp.ToString("X2").ToUpper();
					}					
					return;
				}
				offset += this.defaultChipExternFuseText.mLength;
			}
			//---高位熔丝位
			if ((this.defaultChipHighFuseText!=null) &&(this.defaultChipHighFuseText.mText.Length > 0))
			{
				if ((selectIndex < (this.defaultChipHighFuseText.mLength + offset)) && (selectIndex >= offset))
				{
					temp = this.defaultChipFuse[1];
					if (clb.InvokeRequired)
					{
						clb.BeginInvoke((EventHandler)
												 //cbb.Invoke((EventHandler)
												 (delegate
												 {
													 if (clb.GetItemCheckState(selectIndex) == CheckState.Unchecked)
													 {
														 if (!(	(this.defaultChipHighFuseText.mMask[selectIndex - offset] == 0x80) || 
																(this.defaultChipHighFuseText.mMask[selectIndex - offset] == 0x40) || 
																(this.defaultChipHighFuseText.mMask[selectIndex - offset] == 0x20) || 
																(this.defaultChipHighFuseText.mMask[selectIndex - offset] == 0x10) ||
																(this.defaultChipHighFuseText.mMask[selectIndex - offset] == 0x08) || 
																(this.defaultChipHighFuseText.mMask[selectIndex - offset] == 0x04) || 
																(this.defaultChipHighFuseText.mMask[selectIndex - offset] == 0x02) || 
																(this.defaultChipHighFuseText.mMask[selectIndex - offset] == 0x01)))
														 {
															 clb.SetItemCheckState(selectIndex, CheckState.Checked);
															 return;
														 }
														 temp |= this.defaultChipHighFuseText.mMask[selectIndex - offset] | (this.defaultChipHighFuseText.mValue[selectIndex - offset]);
													 }
													 else
													 {
														 temp = temp & (~this.defaultChipHighFuseText.mMask[selectIndex - offset]) | (this.defaultChipHighFuseText.mValue[selectIndex - offset]);
													 }
												 }));
					}
					else
					{
						if (clb.GetItemCheckState(selectIndex) == CheckState.Unchecked)
						{
							if (!(	(this.defaultChipHighFuseText.mMask[selectIndex - offset] == 0x80) || 
									(this.defaultChipHighFuseText.mMask[selectIndex - offset] == 0x40) || 
									(this.defaultChipHighFuseText.mMask[selectIndex - offset] == 0x20) || 
									(this.defaultChipHighFuseText.mMask[selectIndex - offset] == 0x10) ||
									(this.defaultChipHighFuseText.mMask[selectIndex - offset] == 0x08) || 
									(this.defaultChipHighFuseText.mMask[selectIndex - offset] == 0x04) || 
									(this.defaultChipHighFuseText.mMask[selectIndex - offset] == 0x02) || 
									(this.defaultChipHighFuseText.mMask[selectIndex - offset] == 0x01)))
							{
								clb.SetItemCheckState(selectIndex, CheckState.Checked);
								return;
							}
							temp |= this.defaultChipHighFuseText.mMask[selectIndex - offset] | (this.defaultChipHighFuseText.mValue[selectIndex - offset]);
						}
						else
						{
							temp = temp & (~this.defaultChipHighFuseText.mMask[selectIndex - offset]) | (this.defaultChipHighFuseText.mValue[selectIndex - offset]);
						}
					}
					this.defaultChipFuse[1] = (byte)temp;
					if (highFuse.InvokeRequired)
					{
						highFuse.BeginInvoke((EventHandler)
								 //cbb.Invoke((EventHandler)
								 (delegate
								 {
									 highFuse.Text = temp.ToString("X2").ToUpper();
								 }));
					}
					else
					{
						highFuse.Text = temp.ToString("X2").ToUpper();
					}
					return;
				}
				offset += this.defaultChipHighFuseText.mLength;
			}
			if ((this.defaultChipLowFuseText!=null)&&(this.defaultChipLowFuseText.mText.Length > 0))
			{
				if ((selectIndex < (this.defaultChipLowFuseText.mLength + offset)) && (selectIndex >= offset))
				{
					temp = this.defaultChipFuse[0];
					if (clb.InvokeRequired)
					{
						clb.BeginInvoke((EventHandler)
												 //cbb.Invoke((EventHandler)
												 (delegate
												 {
													 if (clb.GetItemCheckState(selectIndex) == CheckState.Unchecked)
													 {
														 if (!(	(this.defaultChipLowFuseText.mMask[selectIndex - offset] == 0x80) || 
																(this.defaultChipLowFuseText.mMask[selectIndex - offset] == 0x40) || 
																(this.defaultChipLowFuseText.mMask[selectIndex - offset] == 0x20) || 
																(this.defaultChipLowFuseText.mMask[selectIndex - offset] == 0x10) ||
																(this.defaultChipLowFuseText.mMask[selectIndex - offset] == 0x08) || 
																(this.defaultChipLowFuseText.mMask[selectIndex - offset] == 0x04) || 
																(this.defaultChipLowFuseText.mMask[selectIndex - offset] == 0x02) || 
																(this.defaultChipLowFuseText.mMask[selectIndex - offset] == 0x01)))
														 {
															 clb.SetItemCheckState(selectIndex, CheckState.Checked);
															 return;
														 }
														 temp |= this.defaultChipLowFuseText.mMask[selectIndex - offset] | (this.defaultChipLowFuseText.mValue[selectIndex - offset]);
													 }
													 else
													 {
														 temp = temp & (~this.defaultChipLowFuseText.mMask[selectIndex - offset]) | (this.defaultChipLowFuseText.mValue[selectIndex - offset]);
													 }
												 }));
					}
					else
					{
						if (clb.GetItemCheckState(selectIndex) == CheckState.Unchecked)
						{
							if (!(	(this.defaultChipLowFuseText.mMask[selectIndex - offset] == 0x80) || 
									(this.defaultChipLowFuseText.mMask[selectIndex - offset] == 0x40) || 
									(this.defaultChipLowFuseText.mMask[selectIndex - offset] == 0x20) || 
									(this.defaultChipLowFuseText.mMask[selectIndex - offset] == 0x10) ||
									(this.defaultChipLowFuseText.mMask[selectIndex - offset] == 0x08) || 
									(this.defaultChipLowFuseText.mMask[selectIndex - offset] == 0x04) || 
									(this.defaultChipLowFuseText.mMask[selectIndex - offset] == 0x02) || 
									(this.defaultChipLowFuseText.mMask[selectIndex - offset] == 0x01)))
							{
								clb.SetItemCheckState(selectIndex, CheckState.Checked);
								return;
							}
							temp |= this.defaultChipLowFuseText.mMask[selectIndex - offset] | (this.defaultChipLowFuseText.mValue[selectIndex - offset]);
						}
						else
						{
							temp = temp & (~this.defaultChipLowFuseText.mMask[selectIndex - offset]) | (this.defaultChipLowFuseText.mValue[selectIndex - offset]);
						}
					}
					this.defaultChipFuse[0] = (byte)temp;					
					if (lowFuse.InvokeRequired)
					{
						lowFuse.BeginInvoke((EventHandler)
								 //cbb.Invoke((EventHandler)
								 (delegate
								 {
									 lowFuse.Text = temp.ToString("X2").ToUpper();
								 }));
					}
					else
					{
						lowFuse.Text = temp.ToString("X2").ToUpper();
					}
					return;
				}
				offset += this.defaultChipLowFuseText.mLength;
			}
			if ((this.defaultChipLockFuseText != null) &&(this.defaultChipLockFuseText.mText.Length>0))
			{
				if ((selectIndex < (this.defaultChipLockFuseText.mLength + offset)) && (selectIndex >= offset))
				{
					temp = this.defaultChipLock;
					if (clb.InvokeRequired)
					{
						clb.BeginInvoke((EventHandler)
												 //cbb.Invoke((EventHandler)
												 (delegate
												 {
													 if (clb.GetItemCheckState(selectIndex) == CheckState.Unchecked)
													 {
														 if (!(	(this.defaultChipLockFuseText.mMask[selectIndex - offset] == 0x80) || 
																(this.defaultChipLockFuseText.mMask[selectIndex - offset] == 0x40) || 
																(this.defaultChipLockFuseText.mMask[selectIndex - offset] == 0x20) || 
																(this.defaultChipLockFuseText.mMask[selectIndex - offset] == 0x10) ||
																(this.defaultChipLockFuseText.mMask[selectIndex - offset] == 0x08) || 
																(this.defaultChipLockFuseText.mMask[selectIndex - offset] == 0x04) || 
																(this.defaultChipLockFuseText.mMask[selectIndex - offset] == 0x02) || 
																(this.defaultChipLockFuseText.mMask[selectIndex - offset] == 0x01)))
														 {
															 clb.SetItemCheckState(selectIndex, CheckState.Checked);
															 return;
														 }
														 temp |= this.defaultChipLockFuseText.mMask[selectIndex - offset] | (this.defaultChipLockFuseText.mValue[selectIndex - offset]);
													 }
													 else
													 {
														 temp = temp & (~this.defaultChipLockFuseText.mMask[selectIndex - offset]) | (this.defaultChipLockFuseText.mValue[selectIndex - offset]);
													 }
												 }));
					}
					else
					{
						if (clb.GetItemCheckState(selectIndex) == CheckState.Unchecked)
						{
							if (!(	(this.defaultChipLockFuseText.mMask[selectIndex - offset] == 0x80) || 
									(this.defaultChipLockFuseText.mMask[selectIndex - offset] == 0x40) || 
									(this.defaultChipLockFuseText.mMask[selectIndex - offset] == 0x20) || 
									(this.defaultChipLockFuseText.mMask[selectIndex - offset] == 0x10) ||
									(this.defaultChipLockFuseText.mMask[selectIndex - offset] == 0x08) || 
									(this.defaultChipLockFuseText.mMask[selectIndex - offset] == 0x04) || 
									(this.defaultChipLockFuseText.mMask[selectIndex - offset] == 0x02) || 
									(this.defaultChipLockFuseText.mMask[selectIndex - offset] == 0x01)))
							{
								clb.SetItemCheckState(selectIndex, CheckState.Checked);
								return;
							}
							temp |= this.defaultChipLockFuseText.mMask[selectIndex - offset] | (this.defaultChipLockFuseText.mValue[selectIndex - offset]);
						}
						else
						{
							temp = temp & (~this.defaultChipLockFuseText.mMask[selectIndex - offset]) | (this.defaultChipLockFuseText.mValue[selectIndex - offset]);
						}
					}
					this.defaultChipLock = (byte)temp;
					if (lockFuse.InvokeRequired)
					{
						lockFuse.BeginInvoke((EventHandler)
								 //cbb.Invoke((EventHandler)
								 (delegate
								 {
									 lockFuse.Text = temp.ToString("X2").ToUpper();
								 }));
					}
					else
					{
						lockFuse.Text = temp.ToString("X2").ToUpper();
					}
					return;
				}
				offset += this.defaultChipLockFuseText.mLength;
			}
		}

		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="clbBits"></param>
		/// <param name="clbText"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		public bool FuseCheckedListBoxRefresh(CheckedListBox clbBits, CheckedListBox clbText, int fuseVal,int index)
		{
			FuseCheckedListBoxBitsRefresh(clbBits, fuseVal,index);
			return this.FuseCheckedListBoxTextRefresh(clbText, index);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="clb"></param>
		/// <returns></returns>
		public CMcuFuncMaskParam GetFuncMaskCheckedListBox(CheckedListBox clb)
		{
			int _return = 0;
			int length = clb.Items.Count;
			for (int i = 0; i <length ; i++)
			{
				if (clb.GetItemCheckState(i)==CheckState.Checked)
				{
					_return |= 1<<(i);
				}
			}
			return new CMcuFuncMaskParam(length,_return);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="clb"></param>
		/// <param name="val"></param>
		/// <returns></returns>
		public CMcuFuncMaskParam SetFuncMaskCheckedListBox(CheckedListBox clb,CMcuFuncMaskParam val)
		{
			if ((val==null)||(val.mMask<0))
			{
				return null;
			}
			int length = clb.Items.Count;
			int mask = val.mMask;
			for (int i = 0; i < length; i++)
			{
				if (clb.InvokeRequired)
				{
					clb.BeginInvoke((EventHandler)
							 //cbb.Invoke((EventHandler)
							 (delegate
							 {
								 if ((mask & 0x01) != 0)
								 {
									 clb.SetItemCheckState(i, CheckState.Checked);
								 }
								 else
								 {
									 clb.SetItemCheckState(i, CheckState.Unchecked);
								 }
							 }));
				}
				else
				{
					if ((mask & 0x01) != 0)
					{
						clb.SetItemCheckState(i, CheckState.Checked);
					}
					else
					{
						clb.SetItemCheckState(i, CheckState.Unchecked);
					}
				}
				mask >>= 1;
			}
			val.mCout = length;
			return val;
		}

		#endregion

		#region 保护函数

		#endregion

		#region 私有函数

		/// <summary>
		/// 解析AVR的8Bits的MCU的信息
		/// </summary>
		/// <param name="chipName">设备名称</param>
		/// <returns>true---合格，False---失败</returns>
		private bool AnalyseAVR8BitsMcuInfo(string chipName)
		{
			this.defaultChipInfoOK = this.AnalyseAVR8BitsMcuInfoXml(chipName);
			return this.defaultChipInfoOK;
		}

		/// <summary>
		/// 解析AVR的8Bits的MCU的列表
		/// </summary>
		/// <param name="chipName"></param>
		/// <returns></returns>
		private string[] AnalyseAVR8BitsMcuList()
		{
			string[] _return= this.AnalyseAVR8BitsMcuListXml();
			//---校验设备列表解析结果
			if ((_return==null)||(_return.Length==0))
			{
				this.defaultChipInfoOK = false;
			}
			return _return;
		}

		#region 解析MCU的信息

		/// <summary>
		/// 通过XML文件解析MCU设备的信息
		/// </summary>
		/// <param name="chipName"></param>
		/// <returns></returns>
		private bool AnalyseAVR8BitsMcuInfoXml(string chipName)
		{
			//---获取XML文件的位置
			string xmlPath = System.IO.Directory.GetCurrentDirectory() + "\\deviceXml" + "\\" + chipName + ".xml";
			//---清空错误消息
			this.defaultMsgText = string.Empty;
			//---校验当前XML文件是否存在
			if (!File.Exists(xmlPath))
			{
				this.defaultMsgText = "设备XML文件识别错误！";
				//---打印Debug信息
				Debug.WriteLine(this.defaultMsgText);
				return false;
			}
			try
			{
				XmlDocument xmlDoc = new XmlDocument();
				XmlReaderSettings settings = new XmlReaderSettings();
				//---忽略文档里面的注释
				settings.IgnoreComments = true;      
				XmlReader reader = XmlReader.Create(xmlPath, settings);
				//---加载XML文件
				xmlDoc.Load(reader);
				//---得到更节点所有的子节点
				XmlNodeList xmlNodeList = xmlDoc.SelectSingleNode("AVRPART").ChildNodes;
				//---对于拓展熔丝位进行归零处理
				this.defaultChipExternFuseBits = null;
				this.defaultChipExternFuseText = null;
				//---遍历所有的子节点
				foreach (XmlNode xmlNode in xmlNodeList)
				{
					//---将节点强制转换成元素
					XmlElement xmlElement = (XmlElement)xmlNode;
					//---查找的指定的属性
					string str = xmlElement.GetAttribute("Type").ToString();
					switch (str.ToUpper())
					{
						case "CHIP":
							//---从XML文件中解析设备的基本信息
							this.AnalyseChipAVR8BitsMcuChipXml(xmlElement.GetAttribute("ID").ToString(),xmlNode);
							break;
						case "FUSEBITS":
							//---从XML文件中解析熔丝每BIT的含义
							this.AnalyseChipAVR8BitsMcuFuseBitsXml(xmlElement.GetAttribute("ID").ToString(), xmlNode);
							break;
						case "FUSETEXT":
							//---从XML文件中解析熔丝的文本信息
							this.AnalyseChipAVR8BitsMcuFuseTextXml(xmlElement.GetAttribute("ID").ToString(), xmlNode);
							break;
						default:
							break;
					}
				}
			}
			catch (Exception e)
			{
				this.defaultMsgText = e.ToString();
				//---打印Debug信息
				Debug.WriteLine(this.defaultMsgText);
				return false;
			}
			return true;
		}

		/// <summary>
		/// 从指定的XML节点中分析芯片的信息
		/// </summary>
		/// <param name="xmlNode"></param>
		/// <returns></returns>
		private bool AnalyseChipAVR8BitsMcuChipXml(string chipName,XmlNode xmlNode)
		{
			XmlNodeList xmlNodeList = xmlNode.ChildNodes;
			//---设置芯片不支持轮训
			this.defaultChipPollReady = false;
			//---设置芯片不支持eeprom的页编程模式
			this.defaultChipEepromPageMode = false;
			//---返回结果
			int _return = 0;
			//---轮询获取数据
			foreach (XmlNode xn in xmlNodeList)
			{
				switch (xn.Name.ToUpper())
				{
					//---获取设备的ID信息
					case "ID":
						this.defaultChipID = this.AnalyseChipAVR8BitsMcuXml(xn.InnerText, 16);
						_return += 1;
						break;
					//---获取芯片的ChipID
					case "IDCHIP":
						this.defaultIDChip = Convert.ToInt32(xn.InnerText, 16);
						_return += 1;
						break;
					//---获取设备的熔丝位
					case "FUSE":
						this.defaultChipFuse = this.AnalyseChipAVR8BitsMcuXml(xn.InnerText, 16);
						_return += 1;
						break;
					//---获取设备的加密位
					case "LOCK":
						this.defaultChipLock =(byte)Convert.ToInt32(xn.InnerText, 16);
						_return += 1;
						break;
					//---获取设备的Flash
					case "FLASH":
						if (this.AnalyseChipAVR8BitsMcuMemeryXml(xn.InnerText, ref this.defaultChipFlashPerPageWordNum, ref this.defaultChipFlashPageNum) == true)
						{
							_return += 1;
						}
						break;
					//---获取设备的Eeprom
					case "EEPROM":
						if (this.AnalyseChipAVR8BitsMcuMemeryXml(xn.InnerText, ref this.defaultChipEepromPerPageByteNum, ref this.defaultChipEepromPageNum) == true)
						{
							_return += 1;
						}
						break;
					//---获取内部RC的信息
					case "OSC":
						this.defaultChipOSCCalibration = new CMcuFuncAVR8BitsParam(this.AnalyseChipAVR8BitsMcuXml("内部RC频率",xn.InnerText));
						_return += 1;
						break;
					case "INTERFACE":
						this.defaultInterface=new CMcuFuncAVR8BitsParam(this.AnalyseChipAVR8BitsMcuXml("可用编程接口",xn.InnerText));
						_return += 1;
						break;
					case "POLLREADY":
						this.defaultChipPollReady = (Convert.ToUInt16(xn.InnerText, 16)==0)?false:true;
						_return += 1;
						break;
					case "EEPROMPAGE":
						this.defaultChipEepromPageMode = (Convert.ToUInt16(xn.InnerText, 16) == 0) ? false : true;
						_return += 1;
						break;
					default:
						break;
				}
			}
			if (_return!= xmlNodeList.Count)
			{
				this.defaultMsgText = "XML文件中的设备信息不完整！";
				//---打印Debug信息
				Debug.WriteLine(this.defaultMsgText);
				return false;
			}
			//---作为默认熔丝位
			this.defaultChipOSCCalibration.mMask = new int[this.defaultChipFuse.Length];
			//---拷贝数据
			Array.Copy(this.defaultChipFuse, this.defaultChipOSCCalibration.mMask, this.defaultChipFuse.Length);
			//---芯片名称
			this.defaultChipName = chipName;
			return true;
		}

		/// <summary>
		/// 熔丝位BIT信息
		/// </summary>
		/// <param name="chipName"></param>
		/// <param name="xmlNode"></param>
		/// <returns></returns>
		private bool AnalyseChipAVR8BitsMcuFuseBitsXml(string chipName, XmlNode xmlNode)
		{
			switch (chipName.ToUpper())
			{
				case "LOWFUSE":
					this.defaultChipLowFuseBits = new CMcuFuncAVR8BitsParam(this.AnalyseChipAVR8BitsMcuFuseXml(chipName, xmlNode));
					break;
				case "HIGHFUSE":
					this.defaultChipHighFuseBits = new CMcuFuncAVR8BitsParam(this.AnalyseChipAVR8BitsMcuFuseXml(chipName, xmlNode));
					break;
				case "EXTERNFUSE":
					this.defaultChipExternFuseBits = new CMcuFuncAVR8BitsParam(this.AnalyseChipAVR8BitsMcuFuseXml(chipName, xmlNode));
					break;
				case "LOCKFUSE":
					this.defaultChipLockFuseBits = new CMcuFuncAVR8BitsParam(this.AnalyseChipAVR8BitsMcuFuseXml(chipName, xmlNode));
					break;
				default:
					break;
			}
			return true;
		}

		/// <summary>
		/// 熔丝位展开后的信息
		/// </summary>
		/// <param name="chipName"></param>
		/// <param name="xmlNode"></param>
		/// <returns></returns>
		private bool AnalyseChipAVR8BitsMcuFuseTextXml(string chipName, XmlNode xmlNode)
		{
			string str = chipName.ToUpper();
			switch (chipName.ToUpper().Trim())
			{
				case "LOWFUSE":
					this.defaultChipLowFuseText=new CMcuFuncAVR8BitsParam (this.AnalyseChipAVR8BitsMcuFuseXml(chipName,xmlNode,1));
					break;
				case "HIGHFUSE":
					this.defaultChipHighFuseText = new CMcuFuncAVR8BitsParam(this.AnalyseChipAVR8BitsMcuFuseXml(chipName, xmlNode, 1));
					break;
				case "EXTERNFUSE":
					this.defaultChipExternFuseText = new CMcuFuncAVR8BitsParam(this.AnalyseChipAVR8BitsMcuFuseXml(chipName, xmlNode, 1));
					break;
				case "LOCKFUSE":
					this.defaultChipLockFuseText = new CMcuFuncAVR8BitsParam(this.AnalyseChipAVR8BitsMcuFuseXml(chipName, xmlNode, 1));
					break;
				default:
					break;
			}
			return true;
		}

		/// <summary>
		/// 从指定的字符串中获取mcu的信息
		/// </summary>
		/// <param name=""></param>
		/// <returns></returns>
		private byte[] AnalyseChipAVR8BitsMcuXml(string str, int fromBase)
		{
			string[] tempStr = str.Trim(' ').Split(',');
			byte[] _return = new byte[tempStr.Length];
			for (int i = 0; i < tempStr.Length; i++)
			{
				_return[i] = (byte)Convert.ToInt32(tempStr[i], fromBase);
			}
			return _return;
		}

		/// <summary>
		/// 从XML文件中获取存储器的信息
		/// </summary>
		/// <param name="str"></param>
		/// <param name="perPageNum"></param>
		/// <param name="pageNum"></param>
		/// <returns></returns>
		private bool AnalyseChipAVR8BitsMcuMemeryXml(string str, ref int perPageNum, ref int pageNum)
		{
			string[] tempStr = str.Trim(' ').Split(',');
			int[] _return = new int[tempStr.Length];
			for (int i = 0; i < tempStr.Length; i++)
			{
				_return[i] = Convert.ToInt32(tempStr[i], 10);
			}
			if (_return.Length != 2)
			{
				this.defaultMsgText = "XML文件中的解析错误！";
				//---打印Debug信息
				Debug.WriteLine(this.defaultMsgText);
				return false;
			}
			else
			{
				perPageNum = _return[0];
				pageNum = _return[1];
				return true;
			}
		}

		/// <summary>
		/// 从指定的数据中分析OSC信息
		/// </summary>
		/// <param name="str"></param>
		/// <param name="perPageNum"></param>
		/// <param name="pageNum"></param>
		/// <returns></returns>
		private CMcuFuncAVR8BitsParam AnalyseChipAVR8BitsMcuXml(string name, string str)
		{
			CMcuFuncAVR8BitsParam _return = new CMcuFuncAVR8BitsParam(name);
			string[] tempStr = str.Trim(' ').Split(',');
			if ((tempStr.Length & 0x01) != 0)
			{
				return null;
			}
			else
			{
				_return.mText = new string[tempStr.Length / 2];
				_return.mValue = new int[tempStr.Length / 2];
				for (int i = 0; i < _return.mText.Length; i++)
				{
					_return.mText[i] = tempStr[2 * i];
					_return.mValue[i] = Convert.ToInt32(tempStr[2 * i+1], 16);
				}
			}
			return _return;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="xmlNode"></param>
		/// <returns></returns>
		private CMcuFuncAVR8BitsParam AnalyseChipAVR8BitsMcuFuseXml(string chipName,XmlNode xmlNode,int offset=0)
		{
			XmlNodeList xmlNodeListP = xmlNode.ChildNodes;
			CMcuFuncAVR8BitsParam _return = null;
			if ((offset == 0)&&(xmlNodeListP.Count < 8))
			{
				_return = new CMcuFuncAVR8BitsParam(8, chipName);
			}
			else
			{
				_return = new CMcuFuncAVR8BitsParam(xmlNodeListP.Count, chipName);
			}
			
			int i = 0;
			//---轮询获取数据
			foreach (XmlNode xnp in xmlNodeListP)
			{
				//---去除字符串中非数字字符
				string str = Regex.Replace(xnp.Name, @"[^\d]*", "");
				i = int.Parse(str)-offset;
				//---获取相关节点下的信息
				XmlNodeList xmlNodeListC = xnp.ChildNodes;
				foreach (XmlNode xnc in xmlNodeListC)
				{
					switch (xnc.Name.ToUpper())
					{
						case "MASK":
							_return.mMask[i] = Convert.ToInt32(xnc.InnerText, 16);
							break;
						case "VALUE":
							_return.mValue[i] = Convert.ToInt32(xnc.InnerText, 16);
							break;
						case "TEXT":
							_return.mText[i] = xnc.InnerText;
							break;
						default:
							break;
						
					}
				}
			}
			return _return;
		}


		#endregion


		#region 解析MCU列表

		/// <summary>
		/// 获取支持的MCU列表
		/// </summary>
		/// <returns></returns>
		private string[] AnalyseAVR8BitsMcuListXml()
		{
			//---获取XML文件的位置
			string xmlPath = System.IO.Directory.GetCurrentDirectory() + "\\deviceXml" + "\\" + "Config.xml";
			//---清空错误消息
			this.defaultMsgText = string.Empty;
			//---校验当前XML文件是否存在
			if (!File.Exists(xmlPath))
			{
				this.defaultMsgText = "设备列别XML文件解析失败！";
				//---显示错误
				MessageBox.Show(this.defaultMsgText, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				//---返回结果
				return null;
			}
			List<string> _return = new List<string>();
			try
			{
				XmlDocument xmlDoc = new XmlDocument();
				XmlReaderSettings settings = new XmlReaderSettings();
				//---忽略文档里面的注释
				settings.IgnoreComments = true;
				XmlReader reader = XmlReader.Create(xmlPath, settings);
				//---加载XML文件
				xmlDoc.Load(reader);
				//---得到更节点所有的子节点
				XmlNodeList xmlNodeRoot = xmlDoc.SelectSingleNode("AVRPART").ChildNodes;
				//---遍历所有的子节点
				foreach (XmlNode xmlNode in xmlNodeRoot)
				{
					XmlNodeList xmlNodeA = xmlNode.ChildNodes;
					foreach (XmlNode xmlNodeB in xmlNodeA)
					{
						if (xmlNodeB.Name.ToUpper() == "TYPE")
						{
							XmlNodeList xmlNodeC = xmlNodeB.ChildNodes;
							foreach (XmlNode xmlNodeD in xmlNodeC)
							{
								_return.Add(xmlNodeD.InnerText);
							}
						}
						else
						{
							continue;
						}
					}
				}
			}
			catch (Exception e)
			{
				this.defaultMsgText = e.ToString();
				//---显示错误
				MessageBox.Show(this.defaultMsgText, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				//---返回结果
				return null;
			}
			return _return.ToArray();
		}


		#endregion

		#region 控件参数的解析

		/// <summary>
		/// 每Bit的信息
		/// </summary>
		/// <param name="clb"></param>
		/// <param name="fuseBits"></param>
		private int FuseCheckedListBoxBitsInit(CheckedListBox clb, CMcuFuncAVR8BitsParam fuseBits)
		{
			int _return = 0;
			if (clb.InvokeRequired)
			{
				clb.BeginInvoke((EventHandler)
									//cbb.Invoke((EventHandler)
									(delegate
									{
										 clb.Items.Clear();
									}
								));
			}
			else
			{
				clb.Items.Clear();
			}			
			//---轮训解析数据
			for (int i = 0; i < 8; i++)
			{
				if (clb.InvokeRequired)
				{
					clb.BeginInvoke((EventHandler)
										//cbb.Invoke((EventHandler)
										(delegate
										{
											//---检验是否为空
											if (fuseBits == null)
											{
												 clb.Items.Add("NC");
												 clb.SetItemCheckState(i, CheckState.Unchecked);
												 clb.SetItemCheckState(i, CheckState.Indeterminate);  //是控件处于不可选定状态
											}
											else
											{
												 clb.Items.Add(fuseBits.mText[7 - i]);
												 //---检验是不是NC参数
												 if (fuseBits.mText[7 - i] == "NC")
												 {
													 clb.SetItemCheckState(i, CheckState.Unchecked);
													 clb.SetItemCheckState(i, CheckState.Indeterminate);  //是控件处于不可选定状态
												 }
												 else
												 {
													 if (fuseBits.mValue[7 - i] != 0)
													 {
														 clb.SetItemCheckState(i, CheckState.Checked);
													 }
													 else
													 {
														 clb.SetItemCheckState(i, CheckState.Unchecked);
													 }
												 }
											}
										}
									));
				}
				else
				{
					//---检验是否为空
					if (fuseBits == null)
					{
						clb.Items.Add("NC");
						clb.SetItemCheckState(i, CheckState.Unchecked);
						clb.SetItemCheckState(i, CheckState.Indeterminate);  //是控件处于不可选定状态
					}
					else
					{
						clb.Items.Add(fuseBits.mText[7 - i]);
						//---检验是不是NC参数
						if (fuseBits.mText[7 - i] == "NC")
						{
							clb.SetItemCheckState(i, CheckState.Unchecked);
							clb.SetItemCheckState(i, CheckState.Indeterminate);  //是控件处于不可选定状态
							_return++;
						}
						else
						{
							if (fuseBits.mValue[7 - i] != 0)
							{
								clb.SetItemCheckState(i, CheckState.Checked);
							}
							else
							{
								clb.SetItemCheckState(i, CheckState.Unchecked);
							}
						}
					}
				}
			}
			return _return;
		}



		/// <summary>
		/// 组合Bit对应的Text值
		/// </summary>
		private void FuseCheckedListBoxTextInit(CheckedListBox clb, TextBox lowFuseValue, TextBox highFuseValue, TextBox externFuseValue, TextBox lockFuseValue)
		{
			int offsetIndex = 0;
			int i = 0;
			if (clb.InvokeRequired)
			{
				clb.BeginInvoke((EventHandler)
									//cbb.Invoke((EventHandler)
									(delegate
									{
										clb.Items.Clear();
									}
								));
			}
			else
			{
				clb.Items.Clear();
			}
			int fuse = 0;
			int[] tempFuse = new int[this.mChipFuse.Length + 1];
			Array.Copy(this.mChipFuse, tempFuse, (tempFuse.Length - 1));
			//---当前加密位
			tempFuse[tempFuse.Length - 1] = this.mChipLock;
			//---获取拓展位
			CMcuFuncAVR8BitsParam temCMcuParam = this.mChipExternFuseText;
			//---校验熔丝位
			if ((temCMcuParam!=null)&&(temCMcuParam.mText.Length > 0))
			{
				for (i = 0; i < temCMcuParam.mLength; i++)
				{
					if (clb.InvokeRequired)
					{
						clb.BeginInvoke((EventHandler)
											//cbb.Invoke((EventHandler)
											(delegate
											{
												clb.Items.Add(temCMcuParam.mText[i]);
												if ((tempFuse[2] & temCMcuParam.mMask[i]) == temCMcuParam.mValue[i])
												{
													 clb.SetItemCheckState(i + offsetIndex, CheckState.Checked);
												}
												else
												{
													 clb.SetItemCheckState(i + offsetIndex, CheckState.Unchecked);
												}
											}
										));
					}
					else
					{
						clb.Items.Add(temCMcuParam.mText[i]);
						if ((tempFuse[2] & temCMcuParam.mMask[i]) == temCMcuParam.mValue[i])
						{
							clb.SetItemCheckState(i + offsetIndex, CheckState.Checked);
						}
						else
						{
							clb.SetItemCheckState(i + offsetIndex, CheckState.Unchecked);
						}
					}
				}
				offsetIndex += i;
				fuse = Convert.ToInt32(externFuseValue.Text, 16);
				if (fuse != tempFuse[2])
				{
					if (externFuseValue.InvokeRequired)
					{
						externFuseValue.BeginInvoke((EventHandler)
														//cbb.Invoke((EventHandler)
														(delegate
														{
															 externFuseValue.Text = tempFuse[2].ToString("X2");
														}
													));
					}
					else
					{
						externFuseValue.Text = tempFuse[2].ToString("X2");
					}
				}
			}
			else
			{
				fuse = 0xFF;
				if (externFuseValue.InvokeRequired)
				{
					externFuseValue.BeginInvoke((EventHandler)
													 //cbb.Invoke((EventHandler)
													(delegate
													{
														 externFuseValue.Text = tempFuse[2].ToString("X2");
													}
												));
				}
				else
				{
					externFuseValue.Text = tempFuse[2].ToString("X2");
				}
			}
			//---获取高位
			temCMcuParam = this.mChipHighFuseText;
			//---校验熔丝位
			if ((temCMcuParam!=null) &&(temCMcuParam.mText.Length > 0))
			{
				for (i = 0; i < temCMcuParam.mLength; i++)
				{
					if (clb.InvokeRequired)
					{
						clb.BeginInvoke((EventHandler)
											//cbb.Invoke((EventHandler)
											(delegate
											{
												clb.Items.Add(temCMcuParam.mText[i]);
												if ((tempFuse[1] & temCMcuParam.mMask[i]) == temCMcuParam.mValue[i])
												{
													clb.SetItemCheckState(i + offsetIndex, CheckState.Checked);
												}
												else
												{
													clb.SetItemCheckState(i + offsetIndex, CheckState.Unchecked);
												}
											}
										));
					}
					else
					{
						clb.Items.Add(temCMcuParam.mText[i]);
						if ((tempFuse[1] & temCMcuParam.mMask[i]) == temCMcuParam.mValue[i])
						{
							clb.SetItemCheckState(i + offsetIndex, CheckState.Checked);
						}
						else
						{
							clb.SetItemCheckState(i + offsetIndex, CheckState.Unchecked);
						}
					}
				}
				offsetIndex += i;
				fuse = Convert.ToInt32(highFuseValue.Text, 16);
				if (fuse != tempFuse[1])
				{
					if (highFuseValue.InvokeRequired)
					{
						highFuseValue.BeginInvoke((EventHandler)
												//cbb.Invoke((EventHandler)
												(delegate
												{
													 highFuseValue.Text = tempFuse[1].ToString("X2");
												}
											));
					}
					else
					{
						highFuseValue.Text = tempFuse[1].ToString("X2");
					}					
				}
			}
			//---获取低位
			temCMcuParam = this.mChipLowFuseText;
			//---校验熔丝位
			if ((temCMcuParam != null) && (temCMcuParam.mText.Length > 0))
			{
				for (i = 0; i < temCMcuParam.mLength; i++)
				{
					if (clb.InvokeRequired)
					{
						clb.BeginInvoke((EventHandler)
											//cbb.Invoke((EventHandler)
											(delegate
											{
												clb.Items.Add(temCMcuParam.mText[i]);
												if ((tempFuse[0] & temCMcuParam.mMask[i]) == temCMcuParam.mValue[i])
												{
													clb.SetItemCheckState(i + offsetIndex, CheckState.Checked);
												}
												else
												{
													clb.SetItemCheckState(i + offsetIndex, CheckState.Unchecked);
												}
											}
										));
					}
					else
					{
						clb.Items.Add(temCMcuParam.mText[i]);
						if ((tempFuse[0] & temCMcuParam.mMask[i]) == temCMcuParam.mValue[i])
						{
							clb.SetItemCheckState(i + offsetIndex, CheckState.Checked);
						}
						else
						{
							clb.SetItemCheckState(i + offsetIndex, CheckState.Unchecked);
						}
					}
				}
				offsetIndex += i;
				fuse = Convert.ToInt32(lowFuseValue.Text, 16);
				if (fuse != tempFuse[0])
				{
					if (lowFuseValue.InvokeRequired)
					{
						lowFuseValue.BeginInvoke((EventHandler)
													//cbb.Invoke((EventHandler)
													(delegate
													{
														lowFuseValue.Text = tempFuse[0].ToString("X2");
													}
												));
					}
					else
					{
						lowFuseValue.Text = tempFuse[0].ToString("X2");
					}
				}
			}
			//---获取加密位
			temCMcuParam = this.mChipLockFuseText;
			//---校验加密位
			if ((temCMcuParam != null) && (temCMcuParam.mText.Length > 0))
			{
				for (i = 0; i < temCMcuParam.mLength; i++)
				{
					if (clb.InvokeRequired)
					{
						clb.BeginInvoke((EventHandler)
											//cbb.Invoke((EventHandler)
											(delegate
											{
												clb.Items.Add(temCMcuParam.mText[i]);
												if ((tempFuse[tempFuse.Length-1] & temCMcuParam.mMask[i]) == temCMcuParam.mValue[i])
												{
													clb.SetItemCheckState(i + offsetIndex, CheckState.Checked);
												}
												else
												{
													clb.SetItemCheckState(i + offsetIndex, CheckState.Unchecked);
												}
											}
										));
					}
					else
					{
						clb.Items.Add(temCMcuParam.mText[i]);
						if ((tempFuse[tempFuse.Length - 1] & temCMcuParam.mMask[i]) == temCMcuParam.mValue[i])
						{
							clb.SetItemCheckState(i + offsetIndex, CheckState.Checked);
						}
						else
						{
							clb.SetItemCheckState(i + offsetIndex, CheckState.Unchecked);
						}
					}
				}
				offsetIndex += i;
				fuse = Convert.ToInt32(lockFuseValue.Text, 16);
				if (fuse != tempFuse[tempFuse.Length - 1])
				{
					if (lockFuseValue.InvokeRequired)
					{
						lockFuseValue.BeginInvoke((EventHandler)
													//cbb.Invoke((EventHandler)
													delegate
													{
														lockFuseValue.Text = tempFuse[tempFuse.Length - 1].ToString("X2");
													}
												);
					}
					else
					{
						lockFuseValue.Text = tempFuse[tempFuse.Length - 1].ToString("X2");
					}					
				}
			}
		}

		/// <summary>
		/// 内部RC振荡器控件初始化
		/// </summary>
		private void InternalRCOSControlInit(Label oscText1, Label oscText2, Label oscText3, Label oscText4,
											TextBox oscValue1, TextBox oscValue2, TextBox oscValue3, TextBox oscValue4)
		{
			//---第一个内部OSC
			if (oscText1.InvokeRequired)
			{
				oscText1.BeginInvoke((EventHandler)
										//cbb.Invoke((EventHandler)
										delegate
										{
											oscText1.Visible = false;
										}
									 );
			}
			else
			{
				oscText1.Visible = false;
			}
			//---第二个内部OSC
			if (oscText2.InvokeRequired)
			{
				oscText2.BeginInvoke((EventHandler)
										//cbb.Invoke((EventHandler)
										delegate
										{
											oscText2.Visible = false;
										}
									 );
			}
			else
			{
				oscText2.Visible = false;
			}
			//---第三个内部OSC
			if (oscText3.InvokeRequired)
			{
				oscText3.BeginInvoke((EventHandler)
										//cbb.Invoke((EventHandler)
										delegate
										{
											oscText3.Visible = false;
										}
									);
			}
			else
			{
				oscText3.Visible = false;
			}
			//---第四个内部OSC
			if (oscText4.InvokeRequired)
			{
				oscText4.BeginInvoke((EventHandler)
										//cbb.Invoke((EventHandler)
										delegate
										{
											oscText4.Visible = false;
										}
									);
			}
			else
			{
				oscText4.Visible = false;
			}
			//---第一个内部OSC校准字
			if (oscValue1.InvokeRequired)
			{
				oscValue1.BeginInvoke((EventHandler)
										//cbb.Invoke((EventHandler)
										delegate
										{
											oscValue1.Visible = false;
										}
									);
			}
			else
			{
				oscValue1.Visible = false;
			}
			//---第二个内部OSC校准字
			if (oscValue2.InvokeRequired)
			{
				oscValue2.BeginInvoke((EventHandler)
										//cbb.Invoke((EventHandler)
										delegate
										{
											oscValue2.Visible = false;
										}
									);
			}
			else
			{
				oscValue2.Visible = false;
			}
			//---第三个内部OSC校准字
			if (oscValue3.InvokeRequired)
			{
				oscValue3.BeginInvoke((EventHandler)
										//cbb.Invoke((EventHandler)
										delegate
										{
											oscValue3.Visible = false;
										}
									);
			}
			else
			{
				oscValue3.Visible = false;
			}
			//---第四个内部OSC校准字
			if (oscValue4.InvokeRequired)
			{
				oscValue4.BeginInvoke((EventHandler)
										//cbb.Invoke((EventHandler)
										delegate
										{
											oscValue4.Visible = false;
										}
									);
			}
			else
			{
				oscValue4.Visible = false;
			}
			//---遍历显示OSC和校准字对应的关系
			for (int i = 0; i < this.defaultChipOSCCalibration.mLength; i++)
			{
				switch (i)
				{
					case 0:
						if (oscText1.InvokeRequired)
						{
							oscText1.BeginInvoke((EventHandler)
													//cbb.Invoke((EventHandler)
													delegate
													{
														oscText1.Visible = true;
														oscText1.Text = this.defaultChipOSCCalibration.mText[i];
													}
												);
						}
						else
						{
							oscText1.Visible = true;
							oscText1.Text = this.defaultChipOSCCalibration.mText[i];
						}
						if (oscValue1.InvokeRequired)
						{
							oscValue1.BeginInvoke((EventHandler)
													//cbb.Invoke((EventHandler)
													delegate
													{
														oscValue1.Visible = true;
														oscValue1.Text = this.defaultChipOSCCalibration.mValue[i].ToString("X2");
													}
												);
						}
						else
						{
							oscValue1.Visible = true;
							oscValue1.Text = this.defaultChipOSCCalibration.mValue[i].ToString("X2");
						}						
						break;
					case 1:
						if (oscText2.InvokeRequired)
						{
							oscText2.BeginInvoke((EventHandler)
													//cbb.Invoke((EventHandler)
													delegate
													{
														oscText2.Visible = true;
														oscText2.Text = this.defaultChipOSCCalibration.mText[i];
													}
												);
						}
						else
						{
							oscText2.Visible = true;
							oscText2.Text = this.defaultChipOSCCalibration.mText[i];
						}
						if (oscValue2.InvokeRequired)
						{
							oscValue2.BeginInvoke((EventHandler)
													//cbb.Invoke((EventHandler)
													delegate
													{
														oscValue2.Visible = true;
														oscValue2.Text = this.defaultChipOSCCalibration.mValue[i].ToString("X2");
													}
												);
						}
						else
						{
							oscValue2.Visible = true;
							oscValue2.Text = this.defaultChipOSCCalibration.mValue[i].ToString("X2");
						}
						break;
					case 2:
						if (oscText3.InvokeRequired)
						{
							oscText3.BeginInvoke((EventHandler)
													//cbb.Invoke((EventHandler)
													delegate
													{
														oscText3.Visible = true;
														oscText3.Text = this.defaultChipOSCCalibration.mText[i];
													}
												);
						}
						else
						{
							oscText3.Visible = true;
							oscText3.Text = this.defaultChipOSCCalibration.mText[i];
						}
						if (oscValue3.InvokeRequired)
						{
							oscValue3.BeginInvoke((EventHandler)
													//cbb.Invoke((EventHandler)
													delegate
													{
														oscValue3.Visible = true;
														oscValue3.Text = this.defaultChipOSCCalibration.mValue[i].ToString("X2");
													}
												);
						}
						else
						{
							oscValue3.Visible = true;
							oscValue3.Text = this.defaultChipOSCCalibration.mValue[i].ToString("X2");
						}
						break;
					case 3:
						if (oscText4.InvokeRequired)
						{
							oscText4.BeginInvoke((EventHandler)
													//cbb.Invoke((EventHandler)
													delegate
													{
														oscText4.Visible = true;
														oscText4.Text = this.defaultChipOSCCalibration.mText[i];
													}
												);
						}
						else
						{
							oscText4.Visible = true;
							oscText4.Text = this.defaultChipOSCCalibration.mText[i];
						}
						if (oscValue4.InvokeRequired)
						{
							oscValue4.BeginInvoke((EventHandler)
													//cbb.Invoke((EventHandler)
													delegate
													{
														oscValue4.Visible = true;
														oscValue4.Text = this.defaultChipOSCCalibration.mValue[i].ToString("X2");
													}
												);
						}
						else
						{
							oscValue4.Visible = true;
							oscValue4.Text = this.defaultChipOSCCalibration.mValue[i].ToString("X2");
						}
						break;
					default:
						break;
				}
			}
		}

		
		#endregion

		#endregion

		#region 事件函数

		#endregion
	}
}
