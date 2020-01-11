namespace LabMcuForm.CMcuFormAVR8Bits
{
	partial class CMcuControlAVR8BitsFuseAndLock
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

		#region 组件设计器生成的代码

		/// <summary> 
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox_FuseAndLock = new System.Windows.Forms.GroupBox();
			this.tabControl_ChipInfo = new System.Windows.Forms.TabControl();
			this.tabPage_ChipBits = new System.Windows.Forms.TabPage();
			this.tabPage_ChipText = new System.Windows.Forms.TabPage();
			this.groupBox_LowFuseBits = new System.Windows.Forms.GroupBox();
			this.cCheckedListBoxEx_LowFuseBits = new Harry.LabTools.LabControlPlus.CCheckedListBoxEx();
			this.groupBox_HighFuseBits = new System.Windows.Forms.GroupBox();
			this.cCheckedListBoxEx_HighFuseBits = new Harry.LabTools.LabControlPlus.CCheckedListBoxEx();
			this.groupBox_ExternFuseBits = new System.Windows.Forms.GroupBox();
			this.cCheckedListBoxEx_ExternFuseBits = new Harry.LabTools.LabControlPlus.CCheckedListBoxEx();
			this.groupBox_LockFuseBits = new System.Windows.Forms.GroupBox();
			this.cCheckedListBoxEx_LockFuseBits = new Harry.LabTools.LabControlPlus.CCheckedListBoxEx();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.cCheckedListBoxEx_FuseText = new Harry.LabTools.LabControlPlus.CCheckedListBoxEx();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox_FuseAndLock.SuspendLayout();
			this.tabControl_ChipInfo.SuspendLayout();
			this.tabPage_ChipBits.SuspendLayout();
			this.tabPage_ChipText.SuspendLayout();
			this.groupBox_LowFuseBits.SuspendLayout();
			this.groupBox_HighFuseBits.SuspendLayout();
			this.groupBox_ExternFuseBits.SuspendLayout();
			this.groupBox_LockFuseBits.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox_FuseAndLock
			// 
			this.groupBox_FuseAndLock.Controls.Add(this.tabControl_ChipInfo);
			this.groupBox_FuseAndLock.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox_FuseAndLock.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.groupBox_FuseAndLock.Location = new System.Drawing.Point(0, 4);
			this.groupBox_FuseAndLock.Name = "groupBox_FuseAndLock";
			this.groupBox_FuseAndLock.Size = new System.Drawing.Size(662, 397);
			this.groupBox_FuseAndLock.TabIndex = 0;
			this.groupBox_FuseAndLock.TabStop = false;
			this.groupBox_FuseAndLock.Text = "熔丝位&&加密位";
			// 
			// tabControl_ChipInfo
			// 
			this.tabControl_ChipInfo.Alignment = System.Windows.Forms.TabAlignment.Bottom;
			this.tabControl_ChipInfo.Controls.Add(this.tabPage_ChipBits);
			this.tabControl_ChipInfo.Controls.Add(this.tabPage_ChipText);
			this.tabControl_ChipInfo.Dock = System.Windows.Forms.DockStyle.Top;
			this.tabControl_ChipInfo.Location = new System.Drawing.Point(3, 19);
			this.tabControl_ChipInfo.Name = "tabControl_ChipInfo";
			this.tabControl_ChipInfo.Padding = new System.Drawing.Point(8, 4);
			this.tabControl_ChipInfo.SelectedIndex = 0;
			this.tabControl_ChipInfo.Size = new System.Drawing.Size(656, 229);
			this.tabControl_ChipInfo.TabIndex = 0;
			// 
			// tabPage_ChipBits
			// 
			this.tabPage_ChipBits.Controls.Add(this.groupBox4);
			this.tabPage_ChipBits.Controls.Add(this.groupBox_LockFuseBits);
			this.tabPage_ChipBits.Controls.Add(this.groupBox_ExternFuseBits);
			this.tabPage_ChipBits.Controls.Add(this.groupBox_HighFuseBits);
			this.tabPage_ChipBits.Controls.Add(this.groupBox_LowFuseBits);
			this.tabPage_ChipBits.Location = new System.Drawing.Point(4, 4);
			this.tabPage_ChipBits.Name = "tabPage_ChipBits";
			this.tabPage_ChipBits.Padding = new System.Windows.Forms.Padding(3, 4, 3, 3);
			this.tabPage_ChipBits.Size = new System.Drawing.Size(648, 200);
			this.tabPage_ChipBits.TabIndex = 0;
			this.tabPage_ChipBits.Text = "位配置模式";
			this.tabPage_ChipBits.UseVisualStyleBackColor = true;
			// 
			// tabPage_ChipText
			// 
			this.tabPage_ChipText.Controls.Add(this.cCheckedListBoxEx_FuseText);
			this.tabPage_ChipText.Location = new System.Drawing.Point(4, 4);
			this.tabPage_ChipText.Name = "tabPage_ChipText";
			this.tabPage_ChipText.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage_ChipText.Size = new System.Drawing.Size(721, 200);
			this.tabPage_ChipText.TabIndex = 1;
			this.tabPage_ChipText.Text = "向导模式";
			this.tabPage_ChipText.UseVisualStyleBackColor = true;
			// 
			// groupBox_LowFuseBits
			// 
			this.groupBox_LowFuseBits.Controls.Add(this.cCheckedListBoxEx_LowFuseBits);
			this.groupBox_LowFuseBits.Dock = System.Windows.Forms.DockStyle.Left;
			this.groupBox_LowFuseBits.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.groupBox_LowFuseBits.Location = new System.Drawing.Point(3, 4);
			this.groupBox_LowFuseBits.Name = "groupBox_LowFuseBits";
			this.groupBox_LowFuseBits.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
			this.groupBox_LowFuseBits.Size = new System.Drawing.Size(128, 193);
			this.groupBox_LowFuseBits.TabIndex = 0;
			this.groupBox_LowFuseBits.TabStop = false;
			this.groupBox_LowFuseBits.Text = "熔丝低位";
			// 
			// cCheckedListBoxEx_LowFuseBits
			// 
			this.cCheckedListBoxEx_LowFuseBits.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cCheckedListBoxEx_LowFuseBits.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.cCheckedListBoxEx_LowFuseBits.FormattingEnabled = true;
			this.cCheckedListBoxEx_LowFuseBits.Items.AddRange(new object[] {
            "BODLEVEL",
            "BODEN",
            "SUT1",
            "SUT0",
            "CKSEL3",
            "CKSEL2",
            "CKSEL1",
            "CKSEL0"});
			this.cCheckedListBoxEx_LowFuseBits.Location = new System.Drawing.Point(0, 20);
			this.cCheckedListBoxEx_LowFuseBits.Name = "cCheckedListBoxEx_LowFuseBits";
			this.cCheckedListBoxEx_LowFuseBits.Size = new System.Drawing.Size(128, 173);
			this.cCheckedListBoxEx_LowFuseBits.TabIndex = 0;
			// 
			// groupBox_HighFuseBits
			// 
			this.groupBox_HighFuseBits.Controls.Add(this.cCheckedListBoxEx_HighFuseBits);
			this.groupBox_HighFuseBits.Dock = System.Windows.Forms.DockStyle.Left;
			this.groupBox_HighFuseBits.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.groupBox_HighFuseBits.Location = new System.Drawing.Point(131, 4);
			this.groupBox_HighFuseBits.Name = "groupBox_HighFuseBits";
			this.groupBox_HighFuseBits.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
			this.groupBox_HighFuseBits.Size = new System.Drawing.Size(128, 193);
			this.groupBox_HighFuseBits.TabIndex = 1;
			this.groupBox_HighFuseBits.TabStop = false;
			this.groupBox_HighFuseBits.Text = "熔丝高位";
			// 
			// cCheckedListBoxEx_HighFuseBits
			// 
			this.cCheckedListBoxEx_HighFuseBits.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cCheckedListBoxEx_HighFuseBits.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.cCheckedListBoxEx_HighFuseBits.FormattingEnabled = true;
			this.cCheckedListBoxEx_HighFuseBits.Items.AddRange(new object[] {
            "BODLEVEL",
            "BODEN",
            "SUT1",
            "SUT0",
            "CKSEL3",
            "CKSEL2",
            "CKSEL1",
            "CKSEL0"});
			this.cCheckedListBoxEx_HighFuseBits.Location = new System.Drawing.Point(0, 20);
			this.cCheckedListBoxEx_HighFuseBits.Name = "cCheckedListBoxEx_HighFuseBits";
			this.cCheckedListBoxEx_HighFuseBits.Size = new System.Drawing.Size(128, 173);
			this.cCheckedListBoxEx_HighFuseBits.TabIndex = 0;
			// 
			// groupBox_ExternFuseBits
			// 
			this.groupBox_ExternFuseBits.Controls.Add(this.cCheckedListBoxEx_ExternFuseBits);
			this.groupBox_ExternFuseBits.Dock = System.Windows.Forms.DockStyle.Left;
			this.groupBox_ExternFuseBits.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.groupBox_ExternFuseBits.Location = new System.Drawing.Point(259, 4);
			this.groupBox_ExternFuseBits.Name = "groupBox_ExternFuseBits";
			this.groupBox_ExternFuseBits.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
			this.groupBox_ExternFuseBits.Size = new System.Drawing.Size(128, 193);
			this.groupBox_ExternFuseBits.TabIndex = 2;
			this.groupBox_ExternFuseBits.TabStop = false;
			this.groupBox_ExternFuseBits.Text = "熔丝拓展位";
			// 
			// cCheckedListBoxEx_ExternFuseBits
			// 
			this.cCheckedListBoxEx_ExternFuseBits.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cCheckedListBoxEx_ExternFuseBits.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.cCheckedListBoxEx_ExternFuseBits.FormattingEnabled = true;
			this.cCheckedListBoxEx_ExternFuseBits.Items.AddRange(new object[] {
            "BODLEVEL",
            "BODEN",
            "SUT1",
            "SUT0",
            "CKSEL3",
            "CKSEL2",
            "CKSEL1",
            "CKSEL0"});
			this.cCheckedListBoxEx_ExternFuseBits.Location = new System.Drawing.Point(0, 20);
			this.cCheckedListBoxEx_ExternFuseBits.Name = "cCheckedListBoxEx_ExternFuseBits";
			this.cCheckedListBoxEx_ExternFuseBits.Size = new System.Drawing.Size(128, 173);
			this.cCheckedListBoxEx_ExternFuseBits.TabIndex = 0;
			// 
			// groupBox_LockFuseBits
			// 
			this.groupBox_LockFuseBits.Controls.Add(this.cCheckedListBoxEx_LockFuseBits);
			this.groupBox_LockFuseBits.Dock = System.Windows.Forms.DockStyle.Left;
			this.groupBox_LockFuseBits.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.groupBox_LockFuseBits.Location = new System.Drawing.Point(387, 4);
			this.groupBox_LockFuseBits.Name = "groupBox_LockFuseBits";
			this.groupBox_LockFuseBits.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
			this.groupBox_LockFuseBits.Size = new System.Drawing.Size(128, 193);
			this.groupBox_LockFuseBits.TabIndex = 3;
			this.groupBox_LockFuseBits.TabStop = false;
			this.groupBox_LockFuseBits.Text = "加密位";
			// 
			// cCheckedListBoxEx_LockFuseBits
			// 
			this.cCheckedListBoxEx_LockFuseBits.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cCheckedListBoxEx_LockFuseBits.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.cCheckedListBoxEx_LockFuseBits.FormattingEnabled = true;
			this.cCheckedListBoxEx_LockFuseBits.Items.AddRange(new object[] {
            "BODLEVEL",
            "BODEN",
            "SUT1",
            "SUT0",
            "CKSEL3",
            "CKSEL2",
            "CKSEL1",
            "CKSEL0"});
			this.cCheckedListBoxEx_LockFuseBits.Location = new System.Drawing.Point(0, 20);
			this.cCheckedListBoxEx_LockFuseBits.Name = "cCheckedListBoxEx_LockFuseBits";
			this.cCheckedListBoxEx_LockFuseBits.Size = new System.Drawing.Size(128, 173);
			this.cCheckedListBoxEx_LockFuseBits.TabIndex = 0;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.button1);
			this.groupBox4.Controls.Add(this.textBox4);
			this.groupBox4.Controls.Add(this.label4);
			this.groupBox4.Controls.Add(this.textBox3);
			this.groupBox4.Controls.Add(this.label3);
			this.groupBox4.Controls.Add(this.textBox2);
			this.groupBox4.Controls.Add(this.label2);
			this.groupBox4.Controls.Add(this.textBox1);
			this.groupBox4.Controls.Add(this.label1);
			this.groupBox4.Dock = System.Windows.Forms.DockStyle.Left;
			this.groupBox4.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.groupBox4.Location = new System.Drawing.Point(515, 4);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
			this.groupBox4.Size = new System.Drawing.Size(128, 193);
			this.groupBox4.TabIndex = 4;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "时钟校准字";
			// 
			// cCheckedListBoxEx_FuseText
			// 
			this.cCheckedListBoxEx_FuseText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cCheckedListBoxEx_FuseText.FormattingEnabled = true;
			this.cCheckedListBoxEx_FuseText.Location = new System.Drawing.Point(3, 3);
			this.cCheckedListBoxEx_FuseText.Name = "cCheckedListBoxEx_FuseText";
			this.cCheckedListBoxEx_FuseText.Size = new System.Drawing.Size(715, 194);
			this.cCheckedListBoxEx_FuseText.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 36);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(49, 14);
			this.label1.TabIndex = 0;
			this.label1.Text = "1MHz：";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(61, 33);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(48, 23);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "00";
			this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(61, 62);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(48, 23);
			this.textBox2.TabIndex = 3;
			this.textBox2.Text = "00";
			this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 65);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(49, 14);
			this.label2.TabIndex = 2;
			this.label2.Text = "2MHz：";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(61, 91);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(48, 23);
			this.textBox3.TabIndex = 5;
			this.textBox3.Text = "00";
			this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 94);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(49, 14);
			this.label3.TabIndex = 4;
			this.label3.Text = "4MHz：";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(61, 120);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(48, 23);
			this.textBox4.TabIndex = 7;
			this.textBox4.Text = "00";
			this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 123);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(49, 14);
			this.label4.TabIndex = 6;
			this.label4.Text = "8MHz：";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(24, 160);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 8;
			this.button1.Text = "读取";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// CMcuControlAVR8BitsFuseAndLock
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox_FuseAndLock);
			this.Name = "CMcuControlAVR8BitsFuseAndLock";
			this.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
			this.Size = new System.Drawing.Size(662, 401);
			this.groupBox_FuseAndLock.ResumeLayout(false);
			this.tabControl_ChipInfo.ResumeLayout(false);
			this.tabPage_ChipBits.ResumeLayout(false);
			this.tabPage_ChipText.ResumeLayout(false);
			this.groupBox_LowFuseBits.ResumeLayout(false);
			this.groupBox_HighFuseBits.ResumeLayout(false);
			this.groupBox_ExternFuseBits.ResumeLayout(false);
			this.groupBox_LockFuseBits.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox_FuseAndLock;
		private System.Windows.Forms.TabControl tabControl_ChipInfo;
		private System.Windows.Forms.TabPage tabPage_ChipBits;
		private System.Windows.Forms.TabPage tabPage_ChipText;
		private System.Windows.Forms.GroupBox groupBox_LowFuseBits;
		private Harry.LabTools.LabControlPlus.CCheckedListBoxEx cCheckedListBoxEx_LowFuseBits;
		private System.Windows.Forms.GroupBox groupBox_LockFuseBits;
		private Harry.LabTools.LabControlPlus.CCheckedListBoxEx cCheckedListBoxEx_LockFuseBits;
		private System.Windows.Forms.GroupBox groupBox_ExternFuseBits;
		private Harry.LabTools.LabControlPlus.CCheckedListBoxEx cCheckedListBoxEx_ExternFuseBits;
		private System.Windows.Forms.GroupBox groupBox_HighFuseBits;
		private Harry.LabTools.LabControlPlus.CCheckedListBoxEx cCheckedListBoxEx_HighFuseBits;
		private System.Windows.Forms.GroupBox groupBox4;
		private Harry.LabTools.LabControlPlus.CCheckedListBoxEx cCheckedListBoxEx_FuseText;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
	}
}
