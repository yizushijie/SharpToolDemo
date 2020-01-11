namespace Harry.LabTools.LabCommType
{
    partial class CCommSerialPlusControl
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
			this.label_BaudRate = new System.Windows.Forms.Label();
			this.comboBox_BaudRate = new System.Windows.Forms.ComboBox();
			this.label_StopBits = new System.Windows.Forms.Label();
			this.comboBox_StopBits = new System.Windows.Forms.ComboBox();
			this.label_DataBits = new System.Windows.Forms.Label();
			this.comboBox_DataBits = new System.Windows.Forms.ComboBox();
			this.label_Partity = new System.Windows.Forms.Label();
			this.comboBox_Parity = new System.Windows.Forms.ComboBox();
			this.groupBox_COMM.SuspendLayout();
			this.panel_COMM.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_COMM)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox_COMM
			// 
			this.groupBox_COMM.Size = new System.Drawing.Size(151, 185);
			// 
			// panel_COMM
			// 
			this.panel_COMM.Controls.Add(this.label_Partity);
			this.panel_COMM.Controls.Add(this.comboBox_Parity);
			this.panel_COMM.Controls.Add(this.label_DataBits);
			this.panel_COMM.Controls.Add(this.comboBox_DataBits);
			this.panel_COMM.Controls.Add(this.label_StopBits);
			this.panel_COMM.Controls.Add(this.comboBox_StopBits);
			this.panel_COMM.Controls.Add(this.label_BaudRate);
			this.panel_COMM.Controls.Add(this.comboBox_BaudRate);
			this.panel_COMM.Size = new System.Drawing.Size(145, 165);
			this.panel_COMM.Controls.SetChildIndex(this.button_COMM, 0);
			this.panel_COMM.Controls.SetChildIndex(this.pictureBox_COMM, 0);
			this.panel_COMM.Controls.SetChildIndex(this.comboBox_BaudRate, 0);
			this.panel_COMM.Controls.SetChildIndex(this.label_BaudRate, 0);
			this.panel_COMM.Controls.SetChildIndex(this.comboBox_StopBits, 0);
			this.panel_COMM.Controls.SetChildIndex(this.label_StopBits, 0);
			this.panel_COMM.Controls.SetChildIndex(this.comboBox_DataBits, 0);
			this.panel_COMM.Controls.SetChildIndex(this.label_DataBits, 0);
			this.panel_COMM.Controls.SetChildIndex(this.comboBox_Parity, 0);
			this.panel_COMM.Controls.SetChildIndex(this.label_Partity, 0);
			// 
			// pictureBox_COMM
			// 
			this.pictureBox_COMM.Location = new System.Drawing.Point(30, 135);
			// 
			// button_COMM
			// 
			this.button_COMM.Location = new System.Drawing.Point(66, 135);
			// 
			// label_BaudRate
			// 
			this.label_BaudRate.AutoSize = true;
			this.label_BaudRate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label_BaudRate.Location = new System.Drawing.Point(6, 35);
			this.label_BaudRate.Margin = new System.Windows.Forms.Padding(6, 3, 1, 3);
			this.label_BaudRate.Name = "label_BaudRate";
			this.label_BaudRate.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
			this.label_BaudRate.Size = new System.Drawing.Size(49, 12);
			this.label_BaudRate.TabIndex = 4;
			this.label_BaudRate.Text = "波特率:";
			// 
			// comboBox_BaudRate
			// 
			this.comboBox_BaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_BaudRate.FormattingEnabled = true;
			this.comboBox_BaudRate.IntegralHeight = false;
			this.comboBox_BaudRate.Items.AddRange(new object[] {
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
			this.comboBox_BaudRate.Location = new System.Drawing.Point(57, 31);
			this.comboBox_BaudRate.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
			this.comboBox_BaudRate.Name = "comboBox_BaudRate";
			this.comboBox_BaudRate.Size = new System.Drawing.Size(83, 20);
			this.comboBox_BaudRate.TabIndex = 5;
			// 
			// label_StopBits
			// 
			this.label_StopBits.AutoSize = true;
			this.label_StopBits.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label_StopBits.Location = new System.Drawing.Point(6, 61);
			this.label_StopBits.Margin = new System.Windows.Forms.Padding(6, 3, 1, 3);
			this.label_StopBits.Name = "label_StopBits";
			this.label_StopBits.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
			this.label_StopBits.Size = new System.Drawing.Size(49, 12);
			this.label_StopBits.TabIndex = 6;
			this.label_StopBits.Text = "停止位:";
			// 
			// comboBox_StopBits
			// 
			this.comboBox_StopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_StopBits.FormattingEnabled = true;
			this.comboBox_StopBits.IntegralHeight = false;
			this.comboBox_StopBits.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
			this.comboBox_StopBits.Location = new System.Drawing.Point(57, 57);
			this.comboBox_StopBits.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
			this.comboBox_StopBits.Name = "comboBox_StopBits";
			this.comboBox_StopBits.Size = new System.Drawing.Size(83, 20);
			this.comboBox_StopBits.TabIndex = 7;
			// 
			// label_DataBits
			// 
			this.label_DataBits.AutoSize = true;
			this.label_DataBits.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label_DataBits.Location = new System.Drawing.Point(6, 87);
			this.label_DataBits.Margin = new System.Windows.Forms.Padding(6, 3, 1, 3);
			this.label_DataBits.Name = "label_DataBits";
			this.label_DataBits.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
			this.label_DataBits.Size = new System.Drawing.Size(49, 12);
			this.label_DataBits.TabIndex = 8;
			this.label_DataBits.Text = "数据位:";
			// 
			// comboBox_DataBits
			// 
			this.comboBox_DataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_DataBits.FormattingEnabled = true;
			this.comboBox_DataBits.IntegralHeight = false;
			this.comboBox_DataBits.Items.AddRange(new object[] {
			"9",
            "8",
            "7",
            "6",
            "5"});
			this.comboBox_DataBits.Location = new System.Drawing.Point(57, 83);
			this.comboBox_DataBits.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
			this.comboBox_DataBits.Name = "comboBox_DataBits";
			this.comboBox_DataBits.Size = new System.Drawing.Size(83, 20);
			this.comboBox_DataBits.TabIndex = 9;
			// 
			// label_Partity
			// 
			this.label_Partity.AutoSize = true;
			this.label_Partity.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label_Partity.Location = new System.Drawing.Point(6, 113);
			this.label_Partity.Margin = new System.Windows.Forms.Padding(6, 3, 1, 3);
			this.label_Partity.Name = "label_Partity";
			this.label_Partity.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
			this.label_Partity.Size = new System.Drawing.Size(49, 12);
			this.label_Partity.TabIndex = 10;
			this.label_Partity.Text = "校验位:";
			// 
			// comboBox_Parity
			// 
			this.comboBox_Parity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_Parity.FormattingEnabled = true;
			this.comboBox_Parity.IntegralHeight = false;
			this.comboBox_Parity.Items.AddRange(new object[] {
            "无",
            "奇校验",
            "偶校验"});
			this.comboBox_Parity.Location = new System.Drawing.Point(57, 109);
			this.comboBox_Parity.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
			this.comboBox_Parity.Name = "comboBox_Parity";
			this.comboBox_Parity.Size = new System.Drawing.Size(83, 20);
			this.comboBox_Parity.TabIndex = 11;
			// 
			// CCommSerialPlusControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Name = "CCommSerialPlusControl";
			this.Size = new System.Drawing.Size(151, 189);
			this.groupBox_COMM.ResumeLayout(false);
			this.panel_COMM.ResumeLayout(false);
			this.panel_COMM.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_COMM)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_StopBits;
        private System.Windows.Forms.ComboBox comboBox_StopBits;
        private System.Windows.Forms.Label label_BaudRate;
        private System.Windows.Forms.ComboBox comboBox_BaudRate;
        private System.Windows.Forms.Label label_Partity;
        private System.Windows.Forms.ComboBox comboBox_Parity;
        private System.Windows.Forms.Label label_DataBits;
        private System.Windows.Forms.ComboBox comboBox_DataBits;
    }
}
