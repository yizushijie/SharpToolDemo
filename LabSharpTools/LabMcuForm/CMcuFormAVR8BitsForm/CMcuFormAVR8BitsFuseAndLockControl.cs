using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Harry.LabTools.LabCommPort;
using Harry.LabTools.LabMcuFunc;
using Harry.LabTools.LabGenFunc;
using System.Threading;

namespace LabMcuForm.CMcuFormAVR8Bits
{
	public partial class CMcuFormAVR8BitsFuseAndLockControl : UserControl
	{

		#region	定义委托事件
		
		/// <summary>
		/// 定义任务空闲事件
		/// </summary>
		public delegate void EventCallBackTaskIdle();

		#endregion

		#region 变量定义

		/// <summary>
		/// MCU的参数
		/// </summary>
		private CMcuFuncAVR8BitsBase defaultCMcuFunc = null;

		/// <summary>
		/// 是否刷新FuseText设备
		/// </summary>
		private bool defaultRefreshFuseText = false;

		/// <summary>
		/// 消息窗体
		/// </summary>
		private RichTextBox defaultRichTextBoxMsg = null;

		/// <summary>
		/// 事件注册的状态，false---未注册事件，true---已经注册事件
		/// </summary>
		private bool defaultRegisterEventState = false;

		/// <summary>
		/// 任务空闲，false---空闲；true---忙
		/// </summary>
		private bool defaultTaskIdle = false;

		#endregion

		#region 属性定义

		/// <summary>
		/// MCU功能的属性为只读
		/// </summary>
		public virtual CMcuFuncAVR8BitsBase mCMcuFunc
		{
			get
			{
				return this.defaultCMcuFunc;
			}
			set
			{
				this.defaultCMcuFunc = value;
			}
		}

		/// <summary>
		/// 加密熔丝位的属性为读写
		/// </summary>
		public virtual TextBox mLockFuse
		{
			get
			{
				return this.textBox_LockFuseValue;
			}
			set
			{
				this.textBox_LockFuseValue = value;
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
				}
				return cp;
			}
		}


		#endregion

		#region 构造函数

		/// <summary>
		/// 无参数构造函数
		/// </summary>
		public CMcuFormAVR8BitsFuseAndLockControl()
		{
			InitializeComponent();
			//---在内存中先绘制界面，禁止擦除背景
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			//---双缓冲，防止绘制时抖动
			this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			//---双缓存
			this.SetStyle(ControlStyles.DoubleBuffer, true);
			//---限制窗体的大小
			this.MinimumSize = this.Size;
			this.MaximumSize = this.Size;
			//---启动初始化
			this.StartupInit();
		}

		/// <summary>
		/// 有参数构造函数
		/// </summary>
		/// <param name="cCommBase"></param>
		/// <param name="cMcuFuncInfoBaseParam"></param>
		public CMcuFormAVR8BitsFuseAndLockControl(CMcuFuncAVR8BitsBase cMcuFunc,RichTextBox msg=null)
		{
			InitializeComponent();
			//---在内存中先绘制界面，禁止擦除背景
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			//---双缓冲，防止绘制时抖动
			this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			//---双缓存
			this.SetStyle(ControlStyles.DoubleBuffer, true);
			//---限制窗体的大小
			this.MinimumSize = this.Size;
			this.MaximumSize = this.Size;
			//---初始化芯片信息
			if (this.defaultCMcuFunc==null)
			{
				this.defaultCMcuFunc = new CMcuFuncAVR8BitsBase();
			}
			this.defaultCMcuFunc = cMcuFunc;
			//---初始化
			this.Init(cMcuFunc,msg);
		}

		#endregion

		#region 公共函数
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="cMcuFuncInfoBaseParam"></param>
		public void Init(CMcuFuncAVR8BitsBase cMcuFunc,RichTextBox msg=null)
		{
			if (cMcuFunc==null)
			{
				return;
			}
			//---初始化芯片信息
			if (this.defaultCMcuFunc == null)
			{
				this.defaultCMcuFunc = new CMcuFuncAVR8BitsBase();
			}
			this.defaultCMcuFunc = cMcuFunc;
			//---初始化相关控件
			this.defaultCMcuFunc.mMcuInfoParam.FormControlInit(	this.cCheckedListBoxEx_LowFuseBits, this.cCheckedListBoxEx_HighFuseBits, this.cCheckedListBoxEx_ExternFuseBits, this.cCheckedListBoxEx_LockFuseBits,
																this.cCheckedListBoxEx_FuseText,
																this.label_OSCText1, this.label_OSCText2, this.label_OSCText3, this.label_OSCText4,
																this.textBox_OSCValue1, this.textBox_OSCValue2, this.textBox_OSCValue3, this.textBox_OSCValue4,
																this.textBox_LowFuseValue, this.textBox_HighFuseValue, this.textBox_ExternFuseValue, this.textBox_LockFuseValue
																);
			//---校验是否已经注册了事件
			if (this.defaultRegisterEventState==false)
			{
				this.RegisterEventHandler();
				this.defaultRegisterEventState = true;
			}
			//---消息显示
			if (msg!=null)
			{
				this.defaultRichTextBoxMsg = msg;
			}
			
		}

		#endregion

		#region 保护函数

		#endregion

		#region 私有函数

		/// <summary>
		/// 启动初始化
		/// </summary>
		private void StartupInit()
		{
			//---控件变量初始化
			this.label_OSCText1.Visible		= false;
			this.label_OSCText2.Visible		= false;
			this.label_OSCText3.Visible		= false;
			this.label_OSCText4.Visible		= false;

			this.textBox_OSCValue1.Visible	= false;
			this.textBox_OSCValue2.Visible	= false;
			this.textBox_OSCValue3.Visible	= false;
			this.textBox_OSCValue4.Visible	= false;

			this.textBox_LockFuseValue.Text		= "00";
			this.textBox_HighFuseValue.Text		= "00";
			this.textBox_ExternFuseValue.Text	= "00";
			this.textBox_LockFuseValue.Text		= "00";

			//---注册事件

		}

		/// <summary>
		/// 注册事件函数
		/// </summary>
		private void RegisterEventHandler()
		{
			this.cCheckedListBoxEx_LowFuseBits.SelectedIndexChanged += new EventHandler(this.CheckedListBox_SelectedIndexChanged);
			this.cCheckedListBoxEx_HighFuseBits.SelectedIndexChanged += new EventHandler(this.CheckedListBox_SelectedIndexChanged);
			//---校验拓展熔丝位
			if (this.defaultCMcuFunc.mMcuInfoParam.mChipExternFuseBits != null)
			{
				this.cCheckedListBoxEx_ExternFuseBits.SelectedIndexChanged += new EventHandler(this.CheckedListBox_SelectedIndexChanged);
			}
			this.cCheckedListBoxEx_LockFuseBits.SelectedIndexChanged += new EventHandler(this.CheckedListBox_SelectedIndexChanged);
			this.cCheckedListBoxEx_FuseText.SelectedIndexChanged += new EventHandler(this.CheckedListBox_SelectedIndexChanged);

			this.textBox_LowFuseValue.TextChanged += new EventHandler(this.TextBox_TextChanged);
			this.textBox_HighFuseValue.TextChanged += new EventHandler(this.TextBox_TextChanged);
			this.textBox_ExternFuseValue.TextChanged += new EventHandler(this.TextBox_TextChanged);
			this.textBox_LockFuseValue.TextChanged += new EventHandler(this.TextBox_TextChanged);

			this.button_ReadChipCalibration.Click += new EventHandler(this.Button_Click);
			this.button_ReadChipFuse.Click += new EventHandler(this.Button_Click);
			this.button_DefaultChipFuse.Click += new EventHandler(this.Button_Click);
			this.button_WriteChipFuse.Click += new EventHandler(this.Button_Click);

			this.button_ReadChipLock.Click += new EventHandler(this.Button_Click);
			this.button_WriteChipLock.Click += new EventHandler(this.Button_Click);
		}

		#region UI处理事件

		/// <summary>
		/// 事件处理函数
		/// </summary>
		/// <param name="clb"></param>
		private void UI_CheckedListBox_SelectedIndexChanged(CheckedListBox clb)
		{
			switch (clb.Name)
			{
				case "cCheckedListBoxEx_LowFuseBits":
					this.defaultRefreshFuseText = true;
					this.defaultCMcuFunc.mMcuInfoParam.FuseCheckedListBoxRefresh(this.cCheckedListBoxEx_LowFuseBits, this.cCheckedListBoxEx_FuseText, this.textBox_LowFuseValue, 0);
					break;
				case "cCheckedListBoxEx_HighFuseBits":
					this.defaultRefreshFuseText = true;
					this.defaultCMcuFunc.mMcuInfoParam.FuseCheckedListBoxRefresh(this.cCheckedListBoxEx_HighFuseBits, this.cCheckedListBoxEx_FuseText, this.textBox_HighFuseValue, 1);
					break;
				case "cCheckedListBoxEx_ExternFuseBits":
					this.defaultRefreshFuseText = true;
					this.defaultCMcuFunc.mMcuInfoParam.FuseCheckedListBoxRefresh(this.cCheckedListBoxEx_ExternFuseBits, this.cCheckedListBoxEx_FuseText, this.textBox_ExternFuseValue, 2);
					break;
				case "cCheckedListBoxEx_LockFuseBits":
					this.defaultRefreshFuseText = true;
					this.defaultCMcuFunc.mMcuInfoParam.FuseCheckedListBoxRefresh(this.cCheckedListBoxEx_LockFuseBits, this.cCheckedListBoxEx_FuseText, this.textBox_LockFuseValue, 3);
					break;
				case "cCheckedListBoxEx_FuseText":
					this.defaultRefreshFuseText = false;
					this.defaultCMcuFunc.mMcuInfoParam.FuseCheckedListBoxRefresh(this.cCheckedListBoxEx_FuseText, this.textBox_LowFuseValue, this.textBox_HighFuseValue, this.textBox_ExternFuseValue, this.textBox_LockFuseValue);
					break;
				default:
					break;
			}
			//---任务结束
			this.defaultTaskIdle = false;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="tb"></param>
		private void UI_TextBox_TextChanged(TextBox tb)
		{
			switch (tb.Name)
			{
				case "textBox_LowFuseValue":
					this.defaultCMcuFunc.mMcuInfoParam.FuseCheckedListBoxRefresh(this.cCheckedListBoxEx_LowFuseBits, (this.defaultRefreshFuseText == false) ? this.cCheckedListBoxEx_FuseText : null, Convert.ToByte(this.textBox_LowFuseValue.Text, 16), 0);
					this.defaultRefreshFuseText = false;
					break;
				case "textBox_HighFuseValue":
					this.defaultCMcuFunc.mMcuInfoParam.FuseCheckedListBoxRefresh(this.cCheckedListBoxEx_HighFuseBits, (this.defaultRefreshFuseText == false) ? this.cCheckedListBoxEx_FuseText : null, Convert.ToByte(this.textBox_HighFuseValue.Text, 16), 1);
					this.defaultRefreshFuseText = false;
					break;
				case "textBox_ExternFuseValue":
					this.defaultCMcuFunc.mMcuInfoParam.FuseCheckedListBoxRefresh(this.cCheckedListBoxEx_ExternFuseBits, (this.defaultRefreshFuseText == false) ? this.cCheckedListBoxEx_FuseText : null, Convert.ToByte(this.textBox_ExternFuseValue.Text, 16), 2);
					this.defaultRefreshFuseText = false;
					break;
				case "textBox_LockFuseValue":
					this.defaultCMcuFunc.mMcuInfoParam.FuseCheckedListBoxRefresh(this.cCheckedListBoxEx_LockFuseBits, (this.defaultRefreshFuseText == false) ? this.cCheckedListBoxEx_FuseText : null, Convert.ToByte(this.textBox_LockFuseValue.Text, 16), 3);
					this.defaultRefreshFuseText = false;
					break;
				default:
					break;
			}
			//---任务结束
			this.defaultTaskIdle = false;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="bt"></param>
		private void UI_Button_Click(Button bt)
		{
			switch (bt.Name)
			{
				//---读取校准字
				case "button_ReadChipCalibration":
					this.defaultCMcuFunc.CMcuFunc_ReadChipCalibration(this.textBox_OSCValue1, this.textBox_OSCValue2, this.textBox_OSCValue3, this.textBox_OSCValue4,
																		this.defaultRichTextBoxMsg);
					break;
				//---读取熔丝位
				case "button_ReadChipFuse":
					this.defaultCMcuFunc.CMcuFunc_ReadChipFuse(this.textBox_LowFuseValue, this.textBox_HighFuseValue, this.textBox_ExternFuseValue, this.defaultRichTextBoxMsg);
					break;
				//---默认熔丝位
				case "button_DefaultChipFuse":
					//---恢复默认熔丝位
					this.defaultCMcuFunc.CMcuFunc_DefaultChipFuse(this.textBox_LowFuseValue, this.textBox_HighFuseValue, this.textBox_ExternFuseValue, this.defaultRichTextBoxMsg);
					//---刷新低位熔丝位的BIT控件，原因是更改TextBox的值text的值，未发生回调函数
					this.defaultCMcuFunc.mMcuInfoParam.FuseCheckedListBoxBitsRefresh(this.cCheckedListBoxEx_LowFuseBits, Convert.ToByte(this.textBox_LowFuseValue.Text, 16), 0);
					//---刷新高位熔丝位的BIT控件，原因是更改TextBox的值text的值，未发生回调函数
					this.defaultCMcuFunc.mMcuInfoParam.FuseCheckedListBoxBitsRefresh(this.cCheckedListBoxEx_HighFuseBits, Convert.ToByte(this.textBox_HighFuseValue.Text, 16), 1);
					//---刷新拓展位熔丝位的BIT控件，原因是更改TextBox的值text的值，未发生回调函数
					this.defaultCMcuFunc.mMcuInfoParam.FuseCheckedListBoxBitsRefresh(this.cCheckedListBoxEx_ExternFuseBits, Convert.ToByte(this.textBox_ExternFuseValue.Text, 16), 2);
					//---刷新低位熔丝位的TEXT控件，原因是更改TextBox的值text的值，未发生回调函数
					this.defaultCMcuFunc.mMcuInfoParam.FuseCheckedListBoxTextRefresh(this.cCheckedListBoxEx_FuseText, 0);
					//---刷新高位熔丝位的TEXT控件，原因是更改TextBox的值text的值，未发生回调函数
					this.defaultCMcuFunc.mMcuInfoParam.FuseCheckedListBoxTextRefresh(this.cCheckedListBoxEx_FuseText, 1);
					//---刷新拓展位熔丝位的TEXT控件，原因是更改TextBox的值text的值，未发生回调函数
					this.defaultCMcuFunc.mMcuInfoParam.FuseCheckedListBoxTextRefresh(this.cCheckedListBoxEx_FuseText, 2);


					break;
				//---写入熔丝位
				case "button_WriteChipFuse":
					this.defaultCMcuFunc.CMcuFunc_WriteChipFuse(this.textBox_LowFuseValue, this.textBox_HighFuseValue, this.textBox_ExternFuseValue, this.defaultRichTextBoxMsg);
					break;
				//---读取加密位
				case "button_ReadChipLock":
					this.defaultCMcuFunc.CMcuFunc_ReadChipLock(this.textBox_LockFuseValue, this.defaultRichTextBoxMsg);
					break;
				//---写入加密位
				case "button_WriteChipLock":
					this.defaultCMcuFunc.CMcuFunc_WriteChipLock(this.textBox_LockFuseValue, this.defaultRichTextBoxMsg);
					break;
				default:
					break;
			}
			//---任务结束
			this.defaultTaskIdle = false;
		}
		#endregion
		
		#endregion

		#region 事件定义

		/// <summary>
		/// CheckedListBox_SelectedIndexChanged变化事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			//---检验当前任务空闲
			if ((sender == null) || (this.defaultTaskIdle == true))
			{
				return;
			}
			CheckedListBox clb = (CheckedListBox)sender;
			//---这里是为防止双击操作，如果没有，快速双击会导致状态解析错误
			CGenFuncDelay.GenFuncDelayms(150);
			//clb.Enabled = false;
			//---设置输入焦点
			//clb.Focus();
			if (clb.SelectedItem.ToString() == "NC")
			{
				clb.SetItemCheckState(clb.SelectedIndex, CheckState.Checked);
				clb.SetItemCheckState(clb.SelectedIndex, CheckState.Indeterminate);
			}
			else
			{
				//---后台线程执行函数
				Thread t = new Thread
				(delegate ()
					{
						if (clb.InvokeRequired)
						{
							clb.BeginInvoke((EventHandler)
								 (delegate
								 {
									 this.UI_CheckedListBox_SelectedIndexChanged(clb);
								 }));
						}
						else
						{
							this.UI_CheckedListBox_SelectedIndexChanged(clb);
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
				//this.UI_CheckedListBox_SelectedIndexChanged(clb);
			}
			//clb.Enabled = true;
		}

		/// <summary>
		/// TextBox_TextChanged变化事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TextBox_TextChanged(object sender, EventArgs e)
		{
			//---检验当前任务空闲
			if ((sender == null) || (this.defaultTaskIdle == true))
			{
				return;
			}
			TextBox tb = (TextBox)sender;
			//---检查内容是否为空
			if (string.IsNullOrEmpty(tb.Text))
			{
				return;
			}
			tb.Text = Convert.ToByte(tb.Text,16).ToString("X2").ToUpper();
			//tb.Enabled = false;
			//---后台线程执行函数
			Thread t = new Thread
			(delegate ()
				{
					if (tb.InvokeRequired)
					{
						tb.BeginInvoke((EventHandler)
							 (delegate
							 {
								 this.UI_TextBox_TextChanged(tb);
							 }));
					}
					else
					{
						this.UI_TextBox_TextChanged(tb);
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
			//this.UI_TextBox_TextChanged(tb);
			//tb.Enabled = true;
			//tb.Focus();
			//---光标显示在文本末尾
			tb.Select(tb.Text.Length, 0);
		}

		/// <summary>
		/// 按键点击事件
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
			//---校验通讯端口
			if ((this.defaultCMcuFunc.mCCOMM==null) ||(this.defaultCMcuFunc.mCCOMM.mCOMMOpen == false))
			{
				MessageBox.Show("通讯端口初始化异常!", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			Button bt = (Button)sender;
			//---任务执行中
			this.defaultTaskIdle = true;
			//bt.Enabled = false;
			//bt.Focus();
			//---带参数的线程
			//ParameterizedThreadStart threadStart = delegate
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
			//bt.Focus();
		}

		#endregion
	}
}
