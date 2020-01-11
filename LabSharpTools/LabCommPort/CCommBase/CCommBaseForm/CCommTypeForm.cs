using Harry.LabTools.LabGenForm;
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

	/// <summary>
	/// 修改通讯方式，比如USB或者串口通讯
	/// </summary>
	public partial class CCommTypeForm : FloatPopupBaseForm
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
		public CCommTypeForm()
		{
			InitializeComponent();
			this.Startup();
		}

		/// <summary>
		/// 
		/// </summary>
		public CCommTypeForm(CCOMM_TYPE ccommType)
		{
			InitializeComponent();
			this.defaulCCommType = ccommType;
			this.Startup();
		}

		#endregion

		#region 析构函数

		/// <summary>
		/// 
		/// </summary>
		~CCommTypeForm()
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
			if (defaulCCommType == CCOMM_TYPE.COMM_SERIAL)
			{
				this.radioButton_CCommSerial.Checked = true;
				//this.radioButton_CCommUSB.Checked = false;
			}
			else if (defaulCCommType == CCOMM_TYPE.COMM_USB)
			{
				//this.radioButton_CCommSerial.Checked = false;
				this.radioButton_CCommUSB.Checked = true;
			}
			else
			{
				this.radioButton_CCommSerial.Checked = false;
				this.radioButton_CCommUSB.Checked = false;
			}
			//---注册按键点击函数
			this.button_ConfigCCommType.Click += new EventHandler(this.TypeShowDialog_Click);

			//---注册通讯方式发生改变选项
			this.radioButton_CCommSerial.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
			this.radioButton_CCommUSB.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);

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
		/// 通讯发生变化
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void radioButton_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton rb = (RadioButton)sender;
			switch (rb.Name)
			{
				case "radioButton_CCommSerial":
					if (this.radioButton_CCommSerial.Checked==true)
					{
						this.defaulCCommType = CCOMM_TYPE.COMM_SERIAL;
					}
					break;
				case "radioButton_CCommUSB":
					if (this.radioButton_CCommUSB.Checked == true)
					{
						this.defaulCCommType = CCOMM_TYPE.COMM_USB;
					}
					break;
				default:
					break;
			}
		}

		#endregion

	}
}
