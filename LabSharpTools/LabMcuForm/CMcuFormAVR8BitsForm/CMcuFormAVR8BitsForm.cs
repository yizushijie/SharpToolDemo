using Harry.LabTools.LabCommPort;
using Harry.LabTools.LabControlPlus;
using Harry.LabTools.LabGenFunc;
using Harry.LabTools.LabIniFile;
using Harry.LabTools.LabMcuFunc;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace LabMcuForm
{	
	public partial class CMcuFormAVR8BitsForm : Form
	{
		#region	定义委托事件

		/// <summary>
		/// 定义同步事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public delegate void EventSynchronized();

		/// <summary>
		/// 定义任务空闲事件
		/// </summary>
		public delegate void EventCallBackTaskIdle();

		#endregion

		#region 委托事件

		/// <summary>
		/// 通讯端口同步事件
		/// </summary>
		public virtual event EventSynchronized EventHandlerCCommSynchronized = null;		

		#endregion

		#region 变量定义

		/// <summary>
		/// 使用的通讯端口
		/// </summary>
		private CCommPort defaultCComm = new CSerialPort();

		/// <summary>
		/// MCU的参数
		/// </summary>
		private CMcuFuncAVR8BitsBase defaultCMcuFunc = new CMcuFuncAVR8BitsISP();

		/// <summary>
		/// 任务空闲，false---空闲；true---忙
		/// </summary>
		private bool defaultTaskIdle = false;

		#endregion

		#region 属性定义

		/// <summary>
		/// 通讯端口的属性为只读
		/// </summary>
		public virtual CCommPort mCComm
		{
			get
			{
				return this.defaultCComm;
			}
			set
			{
				this.defaultCComm = value;
			}
		}

		/// <summary>
		/// MCU功能的属性为只读
		/// </summary>
		public virtual CMcuFuncAVR8BitsBase mCMcuFunc
		{
			get
			{
				return this.defaultCMcuFunc;
			}
		}

		/// <summary>
		/// 通讯端口类的属性为读写属性
		/// </summary>
		public virtual CCommPortControl mCCommControl
		{
			get
			{
				return this.cCommBaseControl_ChipCOMM;
			}
			set
			{
				this.cCommBaseControl_ChipCOMM = value;
			}
		}

		/// <summary>
		/// 熔丝位加密位
		/// </summary>
		public virtual TextBox mLockFuse
		{
			get
			{
				return this.cMcuFormAVR8BitsFuseAndLockControl_ChipFuse.mLockFuse;
			}
			set
			{
				this.cMcuFormAVR8BitsFuseAndLockControl_ChipFuse.mLockFuse = value;
			}
		}

		/// <summary>
		/// 器件类型
		/// </summary>
		public virtual MCU_INFO_TYPE mTypeMcuInfo
		{
			get
			{
				if (this.mCMcuFunc != null)
				{
					return this.mCMcuFunc.mMcuInfoParam.mTypeMcuInfo;
				}
				else
				{
					return MCU_INFO_TYPE.MCU_NONE;
				}
			}
		}

		/// <summary>
		/// 系统类型
		/// </summary>
		private Boolean IsXpOr2003
		{
			get
			{
				OperatingSystem os = Environment.OSVersion;
				Version vs = os.Version;
				if (os.Platform == PlatformID.Win32NT)
				{
					if ((vs.Major == 5) && (vs.Minor != 0))
					{
						return true;
					}
					else
					{
						return false;
					}
				}
				else
				{
					return false;
				}

			}
		}

		/// <summary>
		/// 设置控件窗口创建参数的扩展风格
		/// </summary>
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				// Turn on WS_EX_COMPOSITED    
				cp.ExStyle |= 0x02000000;
				if (this.IsXpOr2003 == true)
				{
					// Turn on WS_EX_LAYERED  
					cp.ExStyle |= 0x00080000;
					//---设置窗体的不透明度
					this.Opacity = 1;
				}
				return cp;
			}
		}

		#endregion

		#region 构造函数

		/// <summary>
		/// 无参构造函数
		/// </summary>
		public CMcuFormAVR8BitsForm()
		{
			InitializeComponent();
			//---限定最小尺寸
			this.MinimumSize = this.Size;
			//---修改自适应宽度的进度条
			this.toolStripProgressBar_ChipBar.Width += 30;//28;
			this.toolStripProgressBar_ChipBar.Tag = this.toolStripProgressBar_ChipBar.Width.ToString();
			this.toolStrip_ChipTool.Tag = this.toolStrip_ChipTool.Width.ToString();
			//---窗体事件处理
			this.FormEventHandler();
		}

		/// <summary>
		/// 有参构造函数
		/// </summary>
		public CMcuFormAVR8BitsForm(CCommPort usedCComm, CMcuFuncAVR8BitsBase usedCMcuFunc)
		{
			InitializeComponent();
			//---限定最小尺寸
			this.MinimumSize = this.Size;
			//---修改自适应宽度的进度条
			this.toolStripProgressBar_ChipBar.Width += 30;//28;
			this.toolStripProgressBar_ChipBar.Tag = this.toolStripProgressBar_ChipBar.Width.ToString();
			this.toolStrip_ChipTool.Tag = this.toolStrip_ChipTool.Width.ToString();
			//---检查通讯端口
			if (this.defaultCComm==usedCComm)
			{
				this.defaultCComm = new CCommPort();
			}
			//---通讯接口
			this.defaultCComm = usedCComm;
			//---检查设备函数
			if (this.defaultCMcuFunc==null)
			{
				this.defaultCMcuFunc = new CMcuFuncAVR8BitsBase();
			}
			//---校验类型
			if ((usedCMcuFunc!=null)&&(usedCMcuFunc.mMcuInfoParam.mTypeMcuInfo!=MCU_INFO_TYPE.MCU_AVR8BITS))
			{
				this.defaultCMcuFunc = usedCMcuFunc;
			}
			//---窗体事件处理
			this.FormEventHandler();
		}

		#endregion

		#region	析构函数

		/// <summary>
		/// 析构函数
		/// </summary>
		~CMcuFormAVR8BitsForm()
		{
			if (this.defaultCComm != null)
			{
				this.defaultCComm.Dispose();
			}
			//---垃圾回收
			GC.SuppressFinalize(this);
		}

		#endregion

		#region 公共函数

		#endregion

		#region 保护函数

		#endregion

		#region 私有函数

		/// <summary>
		/// 启动初始化
		/// </summary>
		private void StartupInit()
		{
			//---初始化MCU列表
			//this.defaultCMcuFunc.mMcuInfoParam.McuListInfo(this.comboBox_ChipType);
			this.defaultCMcuFunc.McuListInfo(this.comboBox_ChipType);
			//---自动从ini文件中加载配置信息
			CIniFile ini = new CIniFile(Application.StartupPath + @"\Config.ini");
			if (ini.mPathExists)
			{
				NameValueCollection values = null;
				//---设备ID信息
				ini.CIniFileReadSectionValues("ChipID", ref values);
				if ((values != null)&&(values.Count>0))
				{
					this.comboBox_ChipType.SelectedIndex = Convert.ToInt32(values.GetValues(0)[0]);
				}
			}
			//---初始化MCU类型
			this.McuTypeChanged(this.comboBox_ChipType.Text.ToLower());
			//---初始化通信端口
			this.cCommBaseControl_ChipCOMM.Init(this.defaultCComm,this.cRichTextBoxEx_ChipMsg);
			//---初始化版本信息
			this.toolStripLabel_Version.Text =	this.defaultCMcuFunc.mSoftwareVersion[0].ToString("X2") + "-" + this.defaultCMcuFunc.mSoftwareVersion[1].ToString("X2") + "-" +
												this.defaultCMcuFunc.mSoftwareVersion[2].ToString("X2") + "-" + this.defaultCMcuFunc.mSoftwareVersion[3].ToString("X2");
			//--- 初始化当前系统时间
			this.toolStripLabel_ChipRTCTimer.Text = DateTime.Now.ToString();
			//---事件注册
			this.RegistrationEventHandler();
			//---刷新功能选择项
			this.defaultCMcuFunc.mMcuInfoParam.mChipFuncMask1=this.defaultCMcuFunc.mMcuInfoParam.SetFuncMaskCheckedListBox(this.cCheckedListBoxEx_FuncMaskStep1, this.defaultCMcuFunc.mMcuInfoParam.mChipFuncMask1);
			this.defaultCMcuFunc.mMcuInfoParam.mChipFuncMask2=this.defaultCMcuFunc.mMcuInfoParam.SetFuncMaskCheckedListBox(this.cCheckedListBoxEx_FuncMaskStep2, this.defaultCMcuFunc.mMcuInfoParam.mChipFuncMask2);

		}

		/// <summary>
		/// 窗体事件处理
		/// </summary>
		private void FormEventHandler()
		{
			//---窗体显示事件
			this.Shown += new System.EventHandler(this.Form_Shown);
			//---窗体尺寸事件
			this.Resize += new System.EventHandler(this.Form_Resize);
			//---窗体关闭事件
			this.FormClosing += new FormClosingEventHandler(this.Form_Closing);
			//---窗体加载事件
		}

		/// <summary>
		/// 注册事件函数
		/// </summary>
		private void RegistrationEventHandler()
		{
			//---注册通讯端口的的同步
			this.cCommBaseControl_ChipCOMM.EventHandlerCCommSynchronized += this.CCOMMSynchronized;
			//---时间滴答
			this.timer_ChipRTCTime.Tick += new EventHandler(this.Timer_Tick);
			//---MCU类型发生变化
			this.comboBox_ChipType.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
			//---接口类型发生变化
			//this.comboBox_ChipInterface.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectedIndexChanged);
			this.button_SetChipInterface.Click += new EventHandler(this.Button_Click);
			//---Buton事件
			this.button_ReadChipID.Click += new EventHandler(this.Button_Click);
			this.button_ReadChipPWR.Click += new EventHandler(this.Button_Click);
			this.button_SetChipPWR.Click += new EventHandler(this.Button_Click);
			this.button_SetChipClock.Click += new EventHandler(this.Button_Click);

			this.button_Erase.Click += new EventHandler(this.Button_Click);
			this.button_AutoChip.Click += new EventHandler(this.Button_Click);

			this.button_LoadFlashFile.Click += new EventHandler(this.Button_Click);
			this.button_LoadEepromFile.Click += new EventHandler(this.Button_Click);
			this.button_SaveFlashFile.Click += new EventHandler(this.Button_Click);
			this.button_SaveEepromFile.Click += new EventHandler(this.Button_Click);
			this.button_ChipAuto.Click += new EventHandler(this.Button_Click);
			this.button_EraseChip.Click += new EventHandler(this.Button_Click);
			this.button_CheckChipEmpty.Click += new EventHandler(this.Button_Click);
			this.button_ReadIDChip.Click += new EventHandler(this.Button_Click);
			this.button_ReadChipFlash.Click += new EventHandler(this.Button_Click);
			this.button_WriteChipFlash.Click += new EventHandler(this.Button_Click);
			this.button_CheckChipFlash.Click += new EventHandler(this.Button_Click);
			this.button_ReadChipEeprom.Click += new EventHandler(this.Button_Click);
			this.button_WriteChipEeprom.Click += new EventHandler(this.Button_Click);
			this.button_CheckChipEeprom.Click += new EventHandler(this.Button_Click);
			this.button_WriteChipFuse.Click += new EventHandler(this.Button_Click);
			this.button_WriteChipLock.Click += new EventHandler(this.Button_Click);
			this.button_ReadChipROM.Click += new EventHandler(this.Button_Click);

			//---菜单Tab页发生变化
			this.tabControl_ChipMenu.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
			//---菜单Tab页选择
			this.tabControl_ChipMenu.Selected += new System.Windows.Forms.TabControlEventHandler(this.TabControl_Selected);
			//---Memery的Tab页发生变化
			this.tabControl_ChipMemery.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);

			//---编程的时钟的变化
			this.trackBar_ChipClock.MouseHover += new System.EventHandler(this.TrackBar_MouseHover);
			this.trackBar_ChipClock.Scroll += new System.EventHandler(this.TrackBar_Scroll);

			//---电压发生变化
			this.textBox_ChipPWR.TextChanged += new EventHandler(this.TextBox_TextChanged);

			//---功能码的变化
			this.cCheckedListBoxEx_FuncMaskStep1.SelectedIndexChanged += new EventHandler(this.CheckedListBox_SelectedIndexChanged);
			this.cCheckedListBoxEx_FuncMaskStep2.SelectedIndexChanged += new EventHandler(this.CheckedListBox_SelectedIndexChanged);

		}

		/// <summary>
		/// MCU的类型变换
		/// </summary>
		/// <param name="chipName"></param>
		private void McuTypeChanged(string chipName,bool isAutoConfig=true)
		{
			//---初始化芯片信息
			//this.defaultCMcuFunc.mMcuInfoParam.McuTypeInfo(chipName, this.comboBox_ChipInterface,this.textBox_ChipID);
			this.defaultCMcuFunc.McuTypeInfo(chipName, this.comboBox_ChipInterface, this.textBox_ChipID);
			//---校验是否需要自动加载配置文件
			if (isAutoConfig)
			{
				//---自动从ini文件中加载配置信息
				CIniFile ini = new CIniFile(Application.StartupPath + @"\Config.ini");
				if (ini.mPathExists)
				{
					NameValueCollection values = null;
					//---设备接口信息
					ini.CIniFileReadSectionValues("Interface", ref values);
					if ((values != null) && (values.Count > 0))
					{
						this.comboBox_ChipInterface.SelectedIndex = Convert.ToInt32(values.GetValues(0)[0]);
					}
				}
			}			
			//---依据芯片的类型进行控件的初始化
			this.cMcuFormAVR8BitsFuseAndLockControl_ChipFuse.Init(this.defaultCMcuFunc, this.cRichTextBoxEx_ChipMsg);
			//-->>>依据芯片进行Memery的信息初始化---开始
			//---初始化Flash信息
			this.cHexBox_Flash.AddData(this.defaultCMcuFunc.mMcuInfoParam.mChipFlashByteSize);
			//---初始化Eeprom信息
			this.cHexBox_Eeprom.AddData(this.defaultCMcuFunc.mMcuInfoParam.mChipEepromByteSize);
			//---初始化ROM信息
			this.cHexBox_ROM.AddData(this.defaultCMcuFunc.mMcuInfoParam.mChipFlashPerPageByteNum);
			//--<<<依据芯片进行Memery的信息初始化---结束
			this.label_EepromSize.Text = "0/" + this.defaultCMcuFunc.mMcuInfoParam.mChipEepromByteSize.ToString();
			this.label_FlashSize.Text = "0/" + this.defaultCMcuFunc.mMcuInfoParam.mChipFlashByteSize.ToString();
		}

		/// <summary>
		/// 同步通讯端口,避免不同地方使用同一个端口，导致的通讯异常
		/// </summary>
		private void CCOMMSynchronized()
		{
			//---控件中使用的通讯端口
			this.defaultCComm = this.cCommBaseControl_ChipCOMM.mCCOMM;
			//---控件中使用的通讯端口
			this.cMcuFormAVR8BitsFuseAndLockControl_ChipFuse.mCMcuFunc.mCCOMM = this.cCommBaseControl_ChipCOMM.mCCOMM;
			//---执行同步委托事件
			this.EventHandlerCCommSynchronized?.Invoke();
		}

		#region UI处理函数

		/// <summary>
		/// 窗体显示
		/// </summary>
		/// <param name="fm"></param>
		private void UI_Form_Shown(Form fm)
		{
			switch (fm.Name)
			{
				case "CMcuFormAVR8BitsForm":
					this.StartupInit();
					break;
				default:
					break;
			}
			//---任务空闲
			this.defaultTaskIdle = false;
		}

		/// <summary>
		/// ComboBox控件发生变化
		/// </summary>
		/// <param name="cbb"></param>
		private void UI_ComboBox_SelectedIndexChanged(ComboBox cbb)
		{
			//cbb.Enabled = false;
			switch (cbb.Name)
			{
				//---芯片类型发生变化
				case "comboBox_ChipType":
					if (!string.IsNullOrEmpty(this.comboBox_ChipType.Text))
					{
						if (this.comboBox_ChipType.Text != this.defaultCMcuFunc.mMcuInfoParam.mTypeName)
						{
							//---芯片类型发生改变，但是不在加载配置文件
							this.McuTypeChanged(this.comboBox_ChipType.Text,false);
							//---打印器件型号
							CRichTextBoxPlus.AppendTextInfoTopWithDataTime(this.cRichTextBoxEx_ChipMsg, "器件型号是："+ this.defaultCMcuFunc.mMcuInfoParam.mTypeName, Color.Black);
							//---写入配置信息
							CIniFile ini = new CIniFile(Application.StartupPath + @"\Config.ini", true);
							//---记录设备信息
							if (ini.CIniFileSectionExists("ChipID"))
							{
								ini.CIniFileEraseSection("ChipID");
							}
							ini.CIniFileWriteInt("ChipID", this.comboBox_ChipType.Text, this.comboBox_ChipType.SelectedIndex);
							//---写入设备接口信息
							if (ini.CIniFileSectionExists("Interface"))
							{
								ini.CIniFileEraseSection("Interface");
							}
							ini.CIniFileWriteInt("Interface", this.comboBox_ChipInterface.Text, this.comboBox_ChipInterface.SelectedIndex);
						}
					}
					break;
				//---芯片接口发生变化
				case "comboBox_ChipInterface":
					break;
				default:
					break;
			}
			//---任务空闲
			this.defaultTaskIdle = false;
			//cbb.Enabled = true;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="bt"></param>
		private void UI_Button_Click(Button bt)
		{
			switch (bt.Name)
			{
				//---设备接口发生变化
				case "button_SetChipInterface":
					if (!string.IsNullOrEmpty(this.comboBox_ChipInterface.Text))
					{
						switch (this.comboBox_ChipInterface.Text.ToUpper())
						{
							case "ISP":
								if (this.defaultCMcuFunc.GetType() != typeof(CMcuFuncAVR8BitsISP))
								{
									this.defaultCMcuFunc = new CMcuFuncAVR8BitsISP(this.defaultCMcuFunc);
								}
								break;
							case "JTAG":
								if (this.defaultCMcuFunc.GetType() != typeof(CMcuFuncAVR8BitsJTAG))
								{
									this.defaultCMcuFunc = new CMcuFuncAVR8BitsJTAG(this.defaultCMcuFunc);
								}
								break;
							case "HVPP":
								if (this.defaultCMcuFunc.GetType() != typeof(CMcuFuncAVR8BitsHVPP))
								{
									this.defaultCMcuFunc = new CMcuFuncAVR8BitsHVPP(this.defaultCMcuFunc);
								}
								break;
							case "HVSP":
								if (this.defaultCMcuFunc.GetType() != typeof(CMcuFuncAVR8BitsHVSP))
								{
									this.defaultCMcuFunc = new CMcuFuncAVR8BitsHVSP(this.defaultCMcuFunc);
								}
								break;
							default:
								break;
						}
						//---写入配置信息
						CIniFile ini = new CIniFile(Application.StartupPath + @"\Config.ini", true);
						//---记录设备接口
						if (ini.CIniFileSectionExists("Interface"))
						{
							ini.CIniFileEraseSection("Interface");
						}
						ini.CIniFileWriteInt("Interface", this.comboBox_ChipInterface.Text, this.comboBox_ChipInterface.SelectedIndex);
						this.cMcuFormAVR8BitsFuseAndLockControl_ChipFuse.mCMcuFunc = this.defaultCMcuFunc;
					}
					else
					{
						CMessageBoxPlus.Show(this, "？？？不识别的编程接口", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					break;
				//---读取供电电压
				case "button_ReadChipPWR":
					this.defaultCMcuFunc.CMcuFunc_ReadChipPower(this.textBox_ChipPWR, this.cRichTextBoxEx_ChipMsg);
					break;
				//---设置供电电压
				case "button_SetChipPWR":
					this.defaultCMcuFunc.CMcuFunc_WriteChipPower(this.textBox_ChipPWR, this.cRichTextBoxEx_ChipMsg,this.checkBox_ChipPWR.Checked);
					break;
				//---设置编程时钟
				case "button_SetChipClock":
					this.defaultCMcuFunc.CMcuFunc_SetProgClock((byte)this.trackBar_ChipClock.Value, this.cRichTextBoxEx_ChipMsg);
					break;
				//---加载Flash数据
				case "button_LoadFlashFile":
					this.defaultCMcuFunc.CMcuFunc_LoadFlashHexFile(this.cHexBox_Flash, this.label_FlashSize, this.cRichTextBoxEx_ChipMsg);
					break;
				//---加载Eeprom
				case "button_LoadEepromFile":
					this.defaultCMcuFunc.CMcuFunc_LoadEepromHexFile(this.cHexBox_Eeprom, this.label_EepromSize, this.cRichTextBoxEx_ChipMsg);
					break;
				//---保存Flash
				case "button_SaveFlashFile":
					this.defaultCMcuFunc.CMcuFunc_SaveFlashHexFile(this.cHexBox_Flash, this.cRichTextBoxEx_ChipMsg);
					break;
				//---保存EEPROM文件
				case "button_SaveEepromFile":
					this.defaultCMcuFunc.CMcuFunc_SaveEepromHexFile(this.cHexBox_Eeprom, this.cRichTextBoxEx_ChipMsg);
					break;
				//---自动
				case "button_AutoChip":
				case "button_ChipAuto":
					this.defaultCMcuFunc.CMcuFunc_DoChipTask(this.defaultCMcuFunc.mMcuInfoParam.mChipFuse,Convert.ToByte(this.mLockFuse.Text,16),this.cHexBox_Flash, this.cHexBox_Eeprom, this.cRichTextBoxEx_ChipMsg, this.toolStripLabel_ChipState, this.toolStripLabel_ChipTime, this.toolStripProgressBar_ChipBar);
					break;
				//---擦除
				case "button_Erase":
				case "button_EraseChip":
					this.defaultCMcuFunc.CMcuFunc_EraseChip(this.mLockFuse, this.cRichTextBoxEx_ChipMsg);
					break;
				//---存储器查空操作
				case "button_CheckEmpty":
					this.defaultCMcuFunc.CMcuFunc_CheckChipMemeryEmpty(this.cRichTextBoxEx_ChipMsg, false);
					break;
				//---读取识别字
				case "button_ReadIDChip":
				case "button_ReadChipID":
					this.defaultCMcuFunc.CMcuFunc_ReadChipID(this.cRichTextBoxEx_ChipMsg, this);
					break;
				//---读取Flash
				case "button_ReadChipFlash":
					this.defaultCMcuFunc.CMcuFunc_ReadChipFlash(this.cHexBox_Flash, this.cRichTextBoxEx_ChipMsg, this.toolStripLabel_ChipState, this.toolStripLabel_ChipTime, this.toolStripProgressBar_ChipBar);
					break;
				//---编程Flash
				case "button_WriteChipFlash":
					this.defaultCMcuFunc.CMcuFunc_WriteChipFlash(this.cHexBox_Flash, this.cRichTextBoxEx_ChipMsg, true, this.toolStripLabel_ChipState, this.toolStripLabel_ChipTime, this.toolStripProgressBar_ChipBar);
					break;
				//---校验Flash
				case "button_CheckChipFlash":
					this.defaultCMcuFunc.CMcuFunc_CheckChipFlash(this.cHexBox_Flash, this.cRichTextBoxEx_ChipMsg, this.toolStripLabel_ChipState, this.toolStripLabel_ChipTime, this.toolStripProgressBar_ChipBar);
					break;
				//---读取Eeprom
				case "button_ReadChipEeprom":
					this.defaultCMcuFunc.CMcuFunc_ReadChipEeprom(this.cHexBox_Eeprom, this.cRichTextBoxEx_ChipMsg, this.toolStripLabel_ChipState, this.toolStripLabel_ChipTime, this.toolStripProgressBar_ChipBar);
					break;
				//---编程Eeprom
				case "button_WriteChipEeprom":
					this.defaultCMcuFunc.CMcuFunc_WriteChipEeprom(this.cHexBox_Eeprom, this.cRichTextBoxEx_ChipMsg, true,this.toolStripLabel_ChipState, this.toolStripLabel_ChipTime, this.toolStripProgressBar_ChipBar);
					break;
				//---校验Eeprom
				case "button_CheckChipEeprom":
					this.defaultCMcuFunc.CMcuFunc_CheckChipEeprom(this.cHexBox_Eeprom, this.cRichTextBoxEx_ChipMsg, this.toolStripLabel_ChipState, this.toolStripLabel_ChipTime, this.toolStripProgressBar_ChipBar);
					break;
				//---编程熔丝位
				case "button_WriteChipFuse":
					this.defaultCMcuFunc.CMcuFunc_WriteChipFuse(this.cMcuFormAVR8BitsFuseAndLockControl_ChipFuse.mCMcuFunc.mMcuInfoParam.mChipFuse, this.cRichTextBoxEx_ChipMsg);
					break;
				//---编程加密位
				case "button_WriteChipLock":
					this.defaultCMcuFunc.CMcuFunc_WriteChipLock(this.mLockFuse, this.cRichTextBoxEx_ChipMsg);
					break;
				//---读取ROM信息
				case "button_ReadChipROM":
					this.defaultCMcuFunc.CMcuFunc_ReadChipRom(this.cHexBox_ROM, this.cRichTextBoxEx_ChipMsg,true);
					break;
				default:
					break;
			}
			//---任务空闲
			this.defaultTaskIdle = false;
		}
		#endregion

		#endregion

		#region 事件函数

		/// <summary>
		/// 首次显示窗体时发生,在这个函数里面加载控件事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form_Shown(Object sender, EventArgs e)
		{
			Form fm = (Form)sender;
			//---无参数的线程
			ThreadStart threadStart = delegate 
			{
				if (fm.InvokeRequired)
				{
					fm.BeginInvoke((EventHandler)
						 (delegate
						 {
							 this.UI_Form_Shown(fm);
						 }));
				}
				else
				{
					this.UI_Form_Shown(fm);
				}
			};
			//---后台线程执行函数
			Thread t = new Thread(threadStart);
			//---校验线程
			if (t!=null)
			{
				//---后台任务
				t.IsBackground = true;
				//---启动任务
				t.Start();
			}			
			//this.UI_Form_Shown(fm);
			//fm.Focus();
		}

		/// <summary>
		/// 窗体大小发生变化的时候
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form_Resize(object sender, EventArgs e)
		{
			Form fm = (Form)sender;
			switch (fm.Name)
			{
				case "CMcuFormAVR8BitsForm":
					int offset = (this.toolStrip_ChipTool.Size.Width - int.Parse(this.toolStrip_ChipTool.Tag.ToString()));
					//---判断大小
					if (offset > 0)
					{
						this.toolStripProgressBar_ChipBar.Width = int.Parse(this.toolStripProgressBar_ChipBar.Tag.ToString()) + offset;
					}
					else
					{
						if (this.toolStripProgressBar_ChipBar.Width != int.Parse(this.toolStripProgressBar_ChipBar.Tag.ToString()))
						{
							this.toolStripProgressBar_ChipBar.Width = int.Parse(this.toolStripProgressBar_ChipBar.Tag.ToString());
						}
					}
					break;
				default:
					break;
			}
			fm.Focus();
		}

		/// <summary>
		/// 窗体关闭
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form_Closing(object sender, FormClosingEventArgs e)
		{
			Form fm = (Form)sender;
			//fm.Enabled = false;
			switch (fm.Name)
			{
				case "CMcuFormAVR8BitsForm":
					if (e.CloseReason == CloseReason.MdiFormClosing)
					{
						return;
					}
					else if (e.CloseReason == CloseReason.UserClosing)
					{
						if (DialogResult.OK == CMessageBoxPlus.Show(this, "你确定要关闭应用程序吗？", "关闭提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
						{
							//---为保证Application.Exit();时不再弹出提示，所以将FormClosing事件取消
							this.FormClosing -= new FormClosingEventHandler(this.Form_Closing);
							//---检查通讯端口
							if (this.defaultCComm!= null)
							{
								//---关闭端口
								while (true)
								{
									if (this.defaultCComm.mCOMMSTATE == CCOMM_STATE.STATE_IDLE)
									{	
										break;
									}
									Application.DoEvents();
								}
								this.defaultCComm.CloseDevice();
							}
							//---确认关闭事件
							e.Cancel = false;
							//---退出当前窗体
							this.Dispose();
						}
						else
						{
							//---取消关闭事件
							e.Cancel = true;
						}
					}
					break;
				default:
					break;
			}
			//fm.Enabled = true;
			fm.Focus();
		}

		/// <summary>
		/// 定时器滴答
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Timer_Tick(object sender, EventArgs e)
		{
			if (sender==null)
			{
				return;
			}
			Timer timer = (Timer)sender;
			switch (timer.Tag.ToString())
			{
				case "timer_ChipRTCTime":
					this.toolStripLabel_ChipRTCTimer.Text = DateTime.Now.ToString();
					break;
				default:
					break;
			}
		}

		/// <summary>
		/// 鼠标悬停事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TrackBar_MouseHover(object sender, EventArgs e)
		{
			if (sender==null)
			{
				return;
			}
			TrackBar tb = (TrackBar)sender;
			//---获取输入点
			//tb.Focus();
			//---校验控件
			switch (tb.Name)
			{
				case "trackBar_ChipClock":
					this.toolTip_ChipClock.SetToolTip(this.trackBar_ChipClock, this.defaultCMcuFunc.mChipClock[this.trackBar_ChipClock.Value] + "KHz");
					break;
				default:
					break;
			}
		}

		/// <summary>
		/// 滑块滑动
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TrackBar_Scroll(object sender, EventArgs e)
		{
			if (sender == null)
			{
				return;
			}
			TrackBar tb = (TrackBar)sender;
			//---获取输入点
			//tb.Focus();
			//---校验控件
			switch (tb.Name)
			{
				case "trackBar_ChipClock":
					this.toolTip_ChipClock.SetToolTip(this.trackBar_ChipClock, this.defaultCMcuFunc.mChipClock[this.trackBar_ChipClock.Value]+"KHz");
					this.textBox_ChipClock.Text = this.defaultCMcuFunc.mChipClock[this.trackBar_ChipClock.Value];
					break;
				default:
					break;
			}
		}

		/// <summary>
		/// Text窗体事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TextBox_TextChanged(object sender, EventArgs e)
		{
			if (sender == null)
			{
				return;
			}
			TextBox tb = (TextBox)sender;
			//tb.Enabled = false;
			//---设置输入焦点
			//tb.Focus();
			switch (tb.Name)
			{
				default:
					break;
			}
			//tb.Enabled = true;
			//tb.Focus();
			//---光标显示在文本末尾
			tb.Select(tb.Text.Length, 0);
		}

		/// <summary>
		/// ComboBox事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			//---检验当前任务空闲
			if ((sender==null)||(this.defaultTaskIdle == true))
			{
				return;
			}
			ComboBox cbb = (ComboBox)sender;
			//cbb.Enabled = false;
			//cbb.Focus();
			//---后台线程执行函数
			Thread t = new Thread
			(delegate ()
			{
				if (cbb.InvokeRequired)
				{
					cbb.BeginInvoke((EventHandler)
						 (delegate
						 {
							 this.UI_ComboBox_SelectedIndexChanged(cbb);
						 }));
				}
				else
				{
					this.UI_ComboBox_SelectedIndexChanged(cbb);
				}

			}
			);
			//---校验线程有效
			if (t != null)
			{
				//---后台任务
				t.IsBackground = true;
				//---启动任务
				t.Start();
			}
			//this.UI_ComboBox_SelectedIndexChanged(cbb);
			//cbb.Focus();
			//cbb.Enabled = true;
		}
		
		/// <summary>
		/// 功能码的变化
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (sender == null)
			{
				return;
			}
			CheckedListBox clb = (CheckedListBox)sender;
			//---这里是为防止双击操作，如果没有，快速双击会导致状态解析错误
			CGenFuncDelay.GenFuncDelayms(150);
			//---检测变化状态
			switch (clb.Name)	
			{
				case "cCheckedListBoxEx_FuncMaskStep1":
					if ((this.defaultCMcuFunc!=null)&&(this.defaultCMcuFunc.mMcuInfoParam!=null))
					{
						this.defaultCMcuFunc.mMcuInfoParam.mChipFuncMask1 = this.defaultCMcuFunc.mMcuInfoParam.GetFuncMaskCheckedListBox(clb);
					}
					break;
				case "cCheckedListBoxEx_FuncMaskStep2":
					if ((this.defaultCMcuFunc != null) && (this.defaultCMcuFunc.mMcuInfoParam != null))
					{
						this.defaultCMcuFunc.mMcuInfoParam.mChipFuncMask2 = this.defaultCMcuFunc.mMcuInfoParam.GetFuncMaskCheckedListBox(clb);
					}
					break;
				default:
					break;
			}
		}

		/// <summary>
		/// Button事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Button_Click(object sender, EventArgs e)
		{
			//---检验当前任务空闲
			if ((sender == null) || (this.defaultTaskIdle == true))
			{
				return;
			}
			if (this.defaultCComm.mOpen==false)
			{
				CMessageBoxPlus.Show(this, "通讯端口初始化异常!", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			Button bt = (Button)sender;
			//---任务执行中
			this.defaultTaskIdle = true;
			//bt.Enabled = false;
			//bt.Focus();
			//---无参数的线程
			ThreadStart threadStart = delegate
			{
				if (bt.InvokeRequired)
				{
					bt.BeginInvoke((EventHandler)
						 (delegate
						 {
							 this.UI_Button_Click(bt);
						 }));
				}
				else
				{
					this.UI_Button_Click(bt);
				}
			};
			//---后台线程执行函数
			Thread t = new Thread(threadStart);
			//---校验线程有效
			if (t != null)
			{
				//---后台任务
				t.IsBackground = true;
				//---启动任务
				t.Start();
			}
			//this.UI_Button_Click(bt);
			//bt.Enabled = true;
		}

		/// <summary>
		/// TabControl页选择事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (sender == null)
			{
				return;
			}
			//---转化为TabControl控件
			TabControl tcl = (TabControl)sender;
			//tcl.Focus();
			//---判断控件
			switch (tcl.SelectedTab.Text)
			{
				case "编程":
					break;
				case "编辑":
					if (this.tabControl_ChipMemery.SelectedTab.Text.ToUpper() == "FLASH")
					{
						//---重新锁定光标
						this.cHexBox_Flash.OnFindCaret();
					}
					else if (this.tabControl_ChipMemery.SelectedTab.Text.ToUpper() == "EEPROM")
					{
						//---重新锁定光标
						this.cHexBox_Eeprom.OnFindCaret();
					}
					else if (this.tabControl_ChipMemery.SelectedTab.Text.ToUpper() == "ROM")
					{
						//---重新锁定光标
						this.cHexBox_ROM.OnFindCaret();
					}
					break;
				case "FLASH":
					//---将光标锁定在Flash编辑框
					this.cHexBox_Flash.OnFindCaret();
					break;
				case "EEPROM":
					//---将光标锁定在Eeprom编辑框
					this.cHexBox_Eeprom.OnFindCaret();
					break;
				case "ROM":
					//---将光标锁定在Eeprom编辑框
					this.cHexBox_ROM.OnFindCaret();
					break;
				default:
					break;

			}
		}

		/// <summary>
		/// TabControl页切换事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TabControl_Selected(object sender, TabControlEventArgs e)
		{
			if (sender==null)
			{
				return;
			}
			//---转化为TabControl控件
			TabControl tcl = (TabControl)sender;
			//tcl.Focus();
			//---判断控件
			switch (tcl.Name)
			{
				case "tabControl_ChipMenu":
					if (tcl.SelectedTab.Text == "编程")
					{
						if (this.cHexBox_Flash.mNewDataChange || (this.cHexBox_Eeprom.mNewDataChange))
						{
							if (DialogResult.OK == CMessageBoxPlus.Show(this, "是否更新数据缓存区？", "问题提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
							{
								//---Flash数据发生变化
								if (this.cHexBox_Flash.mNewDataChange)
								{
									this.cHexBox_Flash.mNewDataChange = false;
									this.cHexBox_Flash.AddData(this.cHexBox_Flash.mNowData);
								}

								//---Eeprom数据发生变化
								if (this.cHexBox_Eeprom.mNewDataChange)
								{
									this.cHexBox_Eeprom.mNewDataChange = false;
									this.cHexBox_Eeprom.AddData(this.cHexBox_Eeprom.mNowData);
								}
							}
							else
							{
								//---Flash数据发生变化
								if (this.cHexBox_Flash.mNewDataChange)
								{
									this.cHexBox_Flash.mNewDataChange = false;
									this.cHexBox_Flash.AddData(this.cHexBox_Flash.mLastData);
								}

								//---Eeprom数据发生变化
								if (this.cHexBox_Eeprom.mNewDataChange)
								{
									this.cHexBox_Eeprom.mNewDataChange = false;
									this.cHexBox_Eeprom.AddData(this.cHexBox_Eeprom.mLastData);
								}
							}
						}
					}
					break;
				case "tabControl_ChipMemery":
					break;
				default:
					break;
			}
			
		}

		#endregion
	}
}
