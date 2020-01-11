namespace Harry.LabTools.LabCommType
{
    partial class CCommUSBPlusControl
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
			this.label_PID = new System.Windows.Forms.Label();
			this.comboBox_PID = new System.Windows.Forms.ComboBox();
			this.label_VID = new System.Windows.Forms.Label();
			this.comboBox_VID = new System.Windows.Forms.ComboBox();
			this.groupBox_COMM.SuspendLayout();
			this.panel_COMM.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_COMM)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox_COMM
			// 
			this.groupBox_COMM.Size = new System.Drawing.Size(151, 130);
			// 
			// panel_COMM
			// 
			this.panel_COMM.Controls.Add(this.label_PID);
			this.panel_COMM.Controls.Add(this.comboBox_PID);
			this.panel_COMM.Controls.Add(this.label_VID);
			this.panel_COMM.Controls.Add(this.comboBox_VID);
			this.panel_COMM.Size = new System.Drawing.Size(145, 110);
			this.panel_COMM.Controls.SetChildIndex(this.button_COMM, 0);
			this.panel_COMM.Controls.SetChildIndex(this.pictureBox_COMM, 0);
			this.panel_COMM.Controls.SetChildIndex(this.comboBox_VID, 0);
			this.panel_COMM.Controls.SetChildIndex(this.label_VID, 0);
			this.panel_COMM.Controls.SetChildIndex(this.comboBox_PID, 0);
			this.panel_COMM.Controls.SetChildIndex(this.label_PID, 0);
			// 
			// pictureBox_COMM
			// 
			this.pictureBox_COMM.Location = new System.Drawing.Point(30, 79);
			// 
			// button_COMM
			// 
			this.button_COMM.Location = new System.Drawing.Point(66, 79);
			// 
			// label_PID
			// 
			this.label_PID.AutoSize = true;
			this.label_PID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label_PID.Location = new System.Drawing.Point(6, 57);
			this.label_PID.Margin = new System.Windows.Forms.Padding(6, 3, 1, 3);
			this.label_PID.Name = "label_PID";
			this.label_PID.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
			this.label_PID.Size = new System.Drawing.Size(49, 12);
			this.label_PID.TabIndex = 10;
			this.label_PID.Text = "   PID:";
			// 
			// comboBox_PID
			// 
			this.comboBox_PID.FormattingEnabled = true;
			this.comboBox_PID.IntegralHeight = false;
			this.comboBox_PID.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
			this.comboBox_PID.Location = new System.Drawing.Point(57, 53);
			this.comboBox_PID.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
			this.comboBox_PID.Name = "comboBox_PID";
			this.comboBox_PID.Size = new System.Drawing.Size(83, 20);
			this.comboBox_PID.TabIndex = 11;
			// 
			// label_VID
			// 
			this.label_VID.AutoSize = true;
			this.label_VID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label_VID.Location = new System.Drawing.Point(6, 31);
			this.label_VID.Margin = new System.Windows.Forms.Padding(6, 3, 1, 3);
			this.label_VID.Name = "label_VID";
			this.label_VID.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
			this.label_VID.Size = new System.Drawing.Size(49, 12);
			this.label_VID.TabIndex = 8;
			this.label_VID.Text = "   VID:";
			// 
			// comboBox_VID
			// 
			this.comboBox_VID.FormattingEnabled = true;
			this.comboBox_VID.IntegralHeight = false;
			this.comboBox_VID.Items.AddRange(new object[] {
            "自定义",
            "1382400",
            "921600",
            "460800",
            "256000",
            "230400",
            "128000",
            "115200",
            "76800",
            "57600",
            "43000",
            "38400",
            "19200",
            "9600",
            "4800",
            "2400",
            "1200"});
			this.comboBox_VID.Location = new System.Drawing.Point(57, 27);
			this.comboBox_VID.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
			this.comboBox_VID.Name = "comboBox_VID";
			this.comboBox_VID.Size = new System.Drawing.Size(83, 20);
			this.comboBox_VID.TabIndex = 9;
			// 
			// CCommUSBPlusControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Name = "CCommUSBPlusControl";
			this.Size = new System.Drawing.Size(151, 134);
			this.groupBox_COMM.ResumeLayout(false);
			this.panel_COMM.ResumeLayout(false);
			this.panel_COMM.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_COMM)).EndInit();
			this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.Label label_PID;
		private System.Windows.Forms.ComboBox comboBox_PID;
		private System.Windows.Forms.Label label_VID;
		private System.Windows.Forms.ComboBox comboBox_VID;
	}
}
