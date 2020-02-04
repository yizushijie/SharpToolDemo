using Harry.LabTools.LabGenForm;
using Harry.LabTools.LabGenFunc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Harry.LabTools.LabCommPort
{

	/// <summary>
	/// 修改通讯方式，比如USB或者串口通讯
	/// </summary>
	public partial class CCommPortTypeForm : CFloatPopupBaseForm
	{
		#region 变量定义

		/// <summary>
		/// 使用的通讯方式
		/// </summary>
		CCOMM_TYPE defaulCCommType = CCOMM_TYPE.COMM_SERIAL;

		#endregion

		#region 属性定义

		/// <summary>
		/// 通讯方式读写为只读属性
		/// </summary>
		public virtual CCOMM_TYPE mCCommType
		{
			get
			{
				return this.defaulCCommType;
			}
		}

		#endregion

		#region 构造函数

		/// <summary>
		/// 
		/// </summary>
		public CCommPortTypeForm()
		{
			InitializeComponent();
			this.Startup();
		}

		/// <summary>
		/// 
		/// </summary>
		public CCommPortTypeForm(CCOMM_TYPE ccommType,bool isLockFrame=false)
		{
			this.defaulCCommType = ccommType;
			InitializeComponent();			
			base.mLockFrame = isLockFrame;
			this.Startup();
		}

		#endregion

		#region 析构函数

		/// <summary>
		/// 
		/// </summary>
		~CCommPortTypeForm()
		{
			this.FreeResource();
		}
		/// <summary>
		/// 
		/// </summary>
		public virtual void FreeResource()
		{
			GC.SuppressFinalize(this);
		}

		#endregion

		#region 函数定义

		/// <summary>
		/// 启动初始化
		/// </summary>
		private void Startup()
		{
			int index = 0;
			//---配置端口
			if (this.defaulCCommType == CCOMM_TYPE.COMM_SERIAL)
			{
				index = this.cCheckedListBoxEx_CommType.Items.IndexOf("串口通讯");
			}
			else if (this.defaulCCommType == CCOMM_TYPE.COMM_USB)
			{
				index = this.cCheckedListBoxEx_CommType.Items.IndexOf("USB通讯");
			}
			else
			{
				index = 0;
			}
			if (index<0)
			{
				index = 0;
			}
			this.cCheckedListBoxEx_CommType.SetItemCheckState(index, CheckState.Checked);
			//---注册按键点击函数
			this.button_ConfigCCommType.Click += new EventHandler(this.TypeShowDialog_Click);
			// ---注册通讯方式发生改变选项
			this.cCheckedListBoxEx_CommType.SelectedIndexChanged += new EventHandler(this.CheckedListBox_SelectedIndexChanged);
			//---限制窗体的大小
			this.MinimumSize = this.Size;
			this.MaximumSize = this.Size;
		}

		#endregion

		#region 事件定义

		/// <summary>
		/// 通讯类型返回结果
		/// </summary>
		public virtual void TypeShowDialog_Click(object sender, System.EventArgs e)
		{			
			//---返回操作完成状态
			this.DialogResult = System.Windows.Forms.DialogResult.OK;
		}

		/// <summary>
		/// CheckedListBox_SelectedIndexChanged变化事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			//---检验当前任务空闲
			if ((sender == null))
			{
				return;
			}
			CheckedListBox clb = (CheckedListBox)sender;
			int index = clb.SelectedIndex;
			for (int i = 0; i < clb.Items.Count; i++)
			{
				if (index != i)
				{
					clb.SetItemCheckState(i, CheckState.Unchecked);
				}
				else
				{
					clb.SetItemCheckState(i, CheckState.Checked);
					if (clb.Items[i].ToString()=="串口通讯")
					{
						this.defaulCCommType = CCOMM_TYPE.COMM_SERIAL;
					}
					else if (clb.Items[i].ToString() == "USB通讯")
					{
						this.defaulCCommType = CCOMM_TYPE.COMM_USB;
					}
				}
			}
			//---这里是为防止双击操作，如果没有，快速双击会导致状态解析错误
			CGenFuncDelay.GenFuncDelayms(150);
		}

		#endregion

	}
}
