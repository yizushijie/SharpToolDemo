namespace LabSerialPortTools
{
	partial class Form1
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			Harry.LabTools.LabCommType.CCommBase cCommBase1 = new Harry.LabTools.LabCommType.CCommBase();
			this.cCommSerialPlusControl1 = new Harry.LabTools.LabCommType.CCommSerialPlusControl();
			this.SuspendLayout();
			// 
			// cCommSerialPlusControl1
			// 
			this.cCommSerialPlusControl1.Location = new System.Drawing.Point(12, 12);
			cCommBase1.mCCommComBox = null;
			cCommBase1.mCCommForm = null;
			cCommBase1.mCCommRichTextBox = null;
			cCommBase1.mChanged = false;
			cCommBase1.mFullParam = false;
			cCommBase1.mIndex = -1;
			cCommBase1.mMultiCMD = false;
			cCommBase1.mName = "";
			cCommBase1.mPerPackageMaxSize = 64;
			cCommBase1.mReceData = null;
			cCommBase1.mSendData = null;
			cCommBase1.mSerialParam = null;
			cCommBase1.mTimeout = 200;
			cCommBase1.mType = Harry.LabTools.LabCommType.CCOMM_TYPE.COMM_SERIAL;
			cCommBase1.mUSBParam = null;
			this.cCommSerialPlusControl1.mCCOMM = cCommBase1;
			this.cCommSerialPlusControl1.mCCommRichTextBox = null;
			this.cCommSerialPlusControl1.mIsShowCommParam = true;
			this.cCommSerialPlusControl1.mPerPackageMaxSize = 64;
			this.cCommSerialPlusControl1.Name = "cCommSerialPlusControl1";
			this.cCommSerialPlusControl1.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
			this.cCommSerialPlusControl1.Size = new System.Drawing.Size(151, 189);
			this.cCommSerialPlusControl1.TabIndex = 0;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(832, 601);
			this.Controls.Add(this.cCommSerialPlusControl1);
			this.Name = "Form1";
			this.Text = "串口调试助手";
			this.ResumeLayout(false);

		}

		#endregion

		private Harry.LabTools.LabCommType.CCommSerialPlusControl cCommSerialPlusControl1;
	}
}

