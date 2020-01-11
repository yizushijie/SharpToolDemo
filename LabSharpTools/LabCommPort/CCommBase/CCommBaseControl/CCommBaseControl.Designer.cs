namespace Harry.LabTools.LabCommType
{
    partial class CCommBaseControl
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CCommBaseControl));
			this.groupBox_COMM = new System.Windows.Forms.GroupBox();
			this.panel_COMM = new System.Windows.Forms.Panel();
			this.pictureBox_COMM = new System.Windows.Forms.PictureBox();
			this.button_COMM = new System.Windows.Forms.Button();
			this.label_COMM = new System.Windows.Forms.Label();
			this.comboBox_COMM = new System.Windows.Forms.ComboBox();
			this.groupBox_COMM.SuspendLayout();
			this.panel_COMM.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_COMM)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox_COMM
			// 
			this.groupBox_COMM.Controls.Add(this.panel_COMM);
			this.groupBox_COMM.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox_COMM.Location = new System.Drawing.Point(0, 4);
			this.groupBox_COMM.Name = "groupBox_COMM";
			this.groupBox_COMM.Size = new System.Drawing.Size(262, 52);
			this.groupBox_COMM.TabIndex = 7;
			this.groupBox_COMM.TabStop = false;
			this.groupBox_COMM.Text = "通信端口";
			// 
			// panel_COMM
			// 
			this.panel_COMM.Controls.Add(this.pictureBox_COMM);
			this.panel_COMM.Controls.Add(this.button_COMM);
			this.panel_COMM.Controls.Add(this.label_COMM);
			this.panel_COMM.Controls.Add(this.comboBox_COMM);
			this.panel_COMM.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel_COMM.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.panel_COMM.Location = new System.Drawing.Point(3, 17);
			this.panel_COMM.Name = "panel_COMM";
			this.panel_COMM.Size = new System.Drawing.Size(256, 32);
			this.panel_COMM.TabIndex = 1;
			// 
			// pictureBox_COMM
			// 
			this.pictureBox_COMM.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_COMM.Image")));
			this.pictureBox_COMM.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.pictureBox_COMM.Location = new System.Drawing.Point(146, 3);
			this.pictureBox_COMM.Name = "pictureBox_COMM";
			this.pictureBox_COMM.Size = new System.Drawing.Size(25, 25);
			this.pictureBox_COMM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox_COMM.TabIndex = 3;
			this.pictureBox_COMM.TabStop = false;
			this.pictureBox_COMM.Tag = "1";
			// 
			// button_COMM
			// 
			this.button_COMM.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.button_COMM.Location = new System.Drawing.Point(177, 3);
			this.button_COMM.Name = "button_COMM";
			this.button_COMM.Size = new System.Drawing.Size(74, 25);
			this.button_COMM.TabIndex = 2;
			this.button_COMM.Text = "打开设备";
			this.button_COMM.UseVisualStyleBackColor = true;
			// 
			// label_COMM
			// 
			this.label_COMM.AutoSize = true;
			this.label_COMM.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label_COMM.Location = new System.Drawing.Point(6, 9);
			this.label_COMM.Margin = new System.Windows.Forms.Padding(6, 3, 1, 3);
			this.label_COMM.Name = "label_COMM";
			this.label_COMM.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
			this.label_COMM.Size = new System.Drawing.Size(49, 12);
			this.label_COMM.TabIndex = 0;
			this.label_COMM.Text = "端口名:";
			// 
			// comboBox_COMM
			// 
			this.comboBox_COMM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_COMM.FormattingEnabled = true;
			this.comboBox_COMM.IntegralHeight = false;
			this.comboBox_COMM.Location = new System.Drawing.Point(57, 5);
			this.comboBox_COMM.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
			this.comboBox_COMM.Name = "comboBox_COMM";
			this.comboBox_COMM.Size = new System.Drawing.Size(83, 20);
			this.comboBox_COMM.TabIndex = 1;
			// 
			// CCommBaseControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox_COMM);
			this.Name = "CCommBaseControl";
			this.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
			this.Size = new System.Drawing.Size(262, 56);
			this.groupBox_COMM.ResumeLayout(false);
			this.panel_COMM.ResumeLayout(false);
			this.panel_COMM.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox_COMM)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox groupBox_COMM;
        public System.Windows.Forms.Panel panel_COMM;
        public System.Windows.Forms.PictureBox pictureBox_COMM;
        public System.Windows.Forms.Button button_COMM;
        private System.Windows.Forms.Label label_COMM;
        private System.Windows.Forms.ComboBox comboBox_COMM;
    }
}
