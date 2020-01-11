namespace Harry.LabCOMMPort
{
    partial class COMMBasePortPlus
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
            this.groupBox_COMMPortName = new System.Windows.Forms.GroupBox();
            this.panel_COMMPortName = new System.Windows.Forms.Panel();
            this.pictureBox_COMMPortState = new System.Windows.Forms.PictureBox();
            this.button_COMMPortInit = new System.Windows.Forms.Button();
            this.label_COMMPortName = new System.Windows.Forms.Label();
            this.comboBox_COMMPortName = new System.Windows.Forms.ComboBox();
            this.groupBox_COMMPortName.SuspendLayout();
            this.panel_COMMPortName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_COMMPortState)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_COMMPortName
            // 
            this.groupBox_COMMPortName.Controls.Add(this.panel_COMMPortName);
            this.groupBox_COMMPortName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_COMMPortName.Location = new System.Drawing.Point(0, 2);
            this.groupBox_COMMPortName.Name = "groupBox_COMMPortName";
            this.groupBox_COMMPortName.Size = new System.Drawing.Size(259, 51);
            this.groupBox_COMMPortName.TabIndex = 6;
            this.groupBox_COMMPortName.TabStop = false;
            this.groupBox_COMMPortName.Text = "通信端口";
            // 
            // panel_COMMPortName
            // 
            this.panel_COMMPortName.Controls.Add(this.pictureBox_COMMPortState);
            this.panel_COMMPortName.Controls.Add(this.button_COMMPortInit);
            this.panel_COMMPortName.Controls.Add(this.label_COMMPortName);
            this.panel_COMMPortName.Controls.Add(this.comboBox_COMMPortName);
            this.panel_COMMPortName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_COMMPortName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.panel_COMMPortName.Location = new System.Drawing.Point(3, 17);
            this.panel_COMMPortName.Name = "panel_COMMPortName";
            this.panel_COMMPortName.Size = new System.Drawing.Size(253, 31);
            this.panel_COMMPortName.TabIndex = 1;
            // 
            // pictureBox_COMMPortState
            // 
            this.pictureBox_COMMPortState.Image = global::Harry.LabUserControlPlus.Properties.Resources.lost;
            this.pictureBox_COMMPortState.Location = new System.Drawing.Point(146, 3);
            this.pictureBox_COMMPortState.Name = "pictureBox_COMMPortState";
            this.pictureBox_COMMPortState.Size = new System.Drawing.Size(25, 25);
            this.pictureBox_COMMPortState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_COMMPortState.TabIndex = 3;
            this.pictureBox_COMMPortState.TabStop = false;
            this.pictureBox_COMMPortState.Tag = "1";
            // 
            // button_COMMPortInit
            // 
            this.button_COMMPortInit.Location = new System.Drawing.Point(177, 3);
            this.button_COMMPortInit.Name = "button_COMMPortInit";
            this.button_COMMPortInit.Size = new System.Drawing.Size(74, 25);
            this.button_COMMPortInit.TabIndex = 2;
            this.button_COMMPortInit.Text = "打开端口";
            this.button_COMMPortInit.UseVisualStyleBackColor = true;
            // 
            // label_COMMPortName
            // 
            this.label_COMMPortName.AutoSize = true;
            this.label_COMMPortName.Location = new System.Drawing.Point(6, 9);
            this.label_COMMPortName.Margin = new System.Windows.Forms.Padding(6, 3, 1, 3);
            this.label_COMMPortName.Name = "label_COMMPortName";
            this.label_COMMPortName.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.label_COMMPortName.Size = new System.Drawing.Size(49, 12);
            this.label_COMMPortName.TabIndex = 0;
            this.label_COMMPortName.Text = "端口号:";
            // 
            // comboBox_COMMPortName
            // 
            this.comboBox_COMMPortName.FormattingEnabled = true;
            this.comboBox_COMMPortName.Location = new System.Drawing.Point(57, 5);
            this.comboBox_COMMPortName.Margin = new System.Windows.Forms.Padding(1, 3, 3, 3);
            this.comboBox_COMMPortName.Name = "comboBox_COMMPortName";
            this.comboBox_COMMPortName.Size = new System.Drawing.Size(83, 20);
            this.comboBox_COMMPortName.TabIndex = 1;
            // 
            // COMMBasePortPlus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox_COMMPortName);
            this.Name = "COMMBasePortPlus";
            this.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.Size = new System.Drawing.Size(259, 53);
            this.groupBox_COMMPortName.ResumeLayout(false);
            this.panel_COMMPortName.ResumeLayout(false);
            this.panel_COMMPortName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_COMMPortState)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_COMMPortName;
        private System.Windows.Forms.Panel panel_COMMPortName;
        private System.Windows.Forms.PictureBox pictureBox_COMMPortState;
        private System.Windows.Forms.Button button_COMMPortInit;
        private System.Windows.Forms.Label label_COMMPortName;
        private System.Windows.Forms.ComboBox comboBox_COMMPortName;
    }
}
