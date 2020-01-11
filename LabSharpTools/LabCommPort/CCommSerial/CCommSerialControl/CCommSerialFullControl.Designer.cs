namespace Harry.LabTools.LabCommType
{
	partial class CCommSerialFullControl
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
			this.label_RxCRC = new System.Windows.Forms.Label();
			this.comboBox_RxCRC = new System.Windows.Forms.ComboBox();
			this.label_TxCRC = new System.Windows.Forms.Label();
			this.comboBox_TxCRC = new System.Windows.Forms.ComboBox();
			this.label_AddrID = new System.Windows.Forms.Label();
			this.textBox_AddrID = new System.Windows.Forms.TextBox();
			this.textBox_PackageSize = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox_COMM.SuspendLayout();
			this.panel_COMM.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_COMM)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox_COMM
			// 
			this.groupBox_COMM.Size = new System.Drawing.Size(291, 156);
			// 
			// panel_COMM
			// 
			this.panel_COMM.Controls.Add(this.textBox_PackageSize);
			this.panel_COMM.Controls.Add(this.label1);
			this.panel_COMM.Controls.Add(this.textBox_AddrID);
			this.panel_COMM.Controls.Add(this.label_AddrID);
			this.panel_COMM.Controls.Add(this.label_TxCRC);
			this.panel_COMM.Controls.Add(this.comboBox_TxCRC);
			this.panel_COMM.Controls.Add(this.label_RxCRC);
			this.panel_COMM.Controls.Add(this.comboBox_RxCRC);
			this.panel_COMM.Size = new System.Drawing.Size(285, 136);
			this.panel_COMM.Controls.SetChildIndex(this.button_COMM, 0);
			this.panel_COMM.Controls.SetChildIndex(this.pictureBox_COMM, 0);
			this.panel_COMM.Controls.SetChildIndex(this.comboBox_RxCRC, 0);
			this.panel_COMM.Controls.SetChildIndex(this.label_RxCRC, 0);
			this.panel_COMM.Controls.SetChildIndex(this.comboBox_TxCRC, 0);
			this.panel_COMM.Controls.SetChildIndex(this.label_TxCRC, 0);
			this.panel_COMM.Controls.SetChildIndex(this.label_AddrID, 0);
			this.panel_COMM.Controls.SetChildIndex(this.textBox_AddrID, 0);
			this.panel_COMM.Controls.SetChildIndex(this.label1, 0);
			this.panel_COMM.Controls.SetChildIndex(this.textBox_PackageSize, 0);
			// 
			// pictureBox_COMM
			// 
			this.pictureBox_COMM.Location = new System.Drawing.Point(148, 106);
			this.pictureBox_COMM.Size = new System.Drawing.Size(32, 25);
			// 
			// button_COMM
			// 
			this.button_COMM.Location = new System.Drawing.Point(197, 106);
			this.button_COMM.Size = new System.Drawing.Size(83, 25);
			// 
			// label_RxCRC
			// 
			this.label_RxCRC.AutoSize = true;
			this.label_RxCRC.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label_RxCRC.Location = new System.Drawing.Point(146, 61);
			this.label_RxCRC.Margin = new System.Windows.Forms.Padding(6, 3, 1, 3);
			this.label_RxCRC.Name = "label_RxCRC";
			this.label_RxCRC.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
			this.label_RxCRC.Size = new System.Drawing.Size(49, 12);
			this.label_RxCRC.TabIndex = 12;
			this.label_RxCRC.Text = "收校验:";
			// 
			// comboBox_RxCRC
			// 
			this.comboBox_RxCRC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_RxCRC.FormattingEnabled = true;
			this.comboBox_RxCRC.IntegralHeight = false;
			this.comboBox_RxCRC.Items.AddRange(new object[] {
            "CRC_NONE",
            "CRC_SUM",
            "CRC_CRC8",
            "CRC_CRC16",
            "CRC_CRC32"});
			this.comboBox_RxCRC.Location = new System.Drawing.Point(197, 58);
			this.comboBox_RxCRC.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
			this.comboBox_RxCRC.Name = "comboBox_RxCRC";
			this.comboBox_RxCRC.Size = new System.Drawing.Size(83, 20);
			this.comboBox_RxCRC.TabIndex = 13;
			// 
			// label_TxCRC
			// 
			this.label_TxCRC.AutoSize = true;
			this.label_TxCRC.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label_TxCRC.Location = new System.Drawing.Point(146, 88);
			this.label_TxCRC.Margin = new System.Windows.Forms.Padding(6, 3, 1, 3);
			this.label_TxCRC.Name = "label_TxCRC";
			this.label_TxCRC.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
			this.label_TxCRC.Size = new System.Drawing.Size(49, 12);
			this.label_TxCRC.TabIndex = 14;
			this.label_TxCRC.Text = "发校验:";
			// 
			// comboBox_TxCRC
			// 
			this.comboBox_TxCRC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_TxCRC.FormattingEnabled = true;
			this.comboBox_TxCRC.IntegralHeight = false;
			this.comboBox_TxCRC.Items.AddRange(new object[] {
            "CRC_NONE",
            "CRC_SUM",
            "CRC_CRC8",
            "CRC_CRC16",
            "CRC_CRC32"});
			this.comboBox_TxCRC.Location = new System.Drawing.Point(197, 83);
			this.comboBox_TxCRC.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
			this.comboBox_TxCRC.Name = "comboBox_TxCRC";
			this.comboBox_TxCRC.Size = new System.Drawing.Size(83, 20);
			this.comboBox_TxCRC.TabIndex = 15;
			// 
			// label_AddrID
			// 
			this.label_AddrID.AutoSize = true;
			this.label_AddrID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label_AddrID.Location = new System.Drawing.Point(146, 33);
			this.label_AddrID.Margin = new System.Windows.Forms.Padding(6, 3, 1, 3);
			this.label_AddrID.Name = "label_AddrID";
			this.label_AddrID.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
			this.label_AddrID.Size = new System.Drawing.Size(49, 12);
			this.label_AddrID.TabIndex = 16;
			this.label_AddrID.Text = "设备ID:";
			// 
			// textBox_AddrID
			// 
			this.textBox_AddrID.Location = new System.Drawing.Point(197, 30);
			this.textBox_AddrID.Name = "textBox_AddrID";
			this.textBox_AddrID.Size = new System.Drawing.Size(83, 21);
			this.textBox_AddrID.TabIndex = 17;
			this.textBox_AddrID.Text = "-1";
			this.textBox_AddrID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// textBox_PackageSize
			// 
			this.textBox_PackageSize.Location = new System.Drawing.Point(197, 4);
			this.textBox_PackageSize.Name = "textBox_PackageSize";
			this.textBox_PackageSize.Size = new System.Drawing.Size(83, 21);
			this.textBox_PackageSize.TabIndex = 19;
			this.textBox_PackageSize.Text = "64";
			this.textBox_PackageSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label1.Location = new System.Drawing.Point(146, 9);
			this.label1.Margin = new System.Windows.Forms.Padding(6, 3, 1, 3);
			this.label1.Name = "label1";
			this.label1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
			this.label1.Size = new System.Drawing.Size(49, 12);
			this.label1.TabIndex = 18;
			this.label1.Text = "缓存区:";
			// 
			// CCommSerialFullControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Name = "CCommSerialFullControl";
			this.Size = new System.Drawing.Size(291, 160);
			this.groupBox_COMM.ResumeLayout(false);
			this.panel_COMM.ResumeLayout(false);
			this.panel_COMM.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_COMM)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label_TxCRC;
		private System.Windows.Forms.ComboBox comboBox_TxCRC;
		private System.Windows.Forms.Label label_RxCRC;
		private System.Windows.Forms.ComboBox comboBox_RxCRC;
		private System.Windows.Forms.TextBox textBox_AddrID;
		private System.Windows.Forms.Label label_AddrID;
		private System.Windows.Forms.TextBox textBox_PackageSize;
		private System.Windows.Forms.Label label1;
	}
}
