namespace AhDung
{
    partial class FmMDI
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmMDI));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnNewChild = new System.Windows.Forms.ToolStripButton();
            this.btnNewNormal = new System.Windows.Forms.ToolStripButton();
            this.btnPopupFromItem = new System.Windows.Forms.ToolStripButton();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripLabel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txbResult = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rbSingle = new System.Windows.Forms.RadioButton();
            this.rb3D = new System.Windows.Forms.RadioButton();
            this.rbNone = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rbShowDialog = new System.Windows.Forms.RadioButton();
            this.rbShow = new System.Windows.Forms.RadioButton();
            this.cmbColor = new System.Windows.Forms.ComboBox();
            this.cmbSingleStyle = new System.Windows.Forms.ComboBox();
            this.cmb3DStyle = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbPopupFromTextBox = new System.Windows.Forms.TextBox();
            this.btnPopupFromButton = new System.Windows.Forms.Button();
            this.colorPicker1 = new AhDung.ColorPicker();
            this.label7 = new System.Windows.Forms.Label();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewChild,
            this.btnNewNormal,
            this.btnPopupFromItem,
            this.helpToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(774, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "ToolStrip";
            // 
            // btnNewChild
            // 
            this.btnNewChild.Image = ((System.Drawing.Image)(resources.GetObject("btnNewChild.Image")));
            this.btnNewChild.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnNewChild.Name = "btnNewChild";
            this.btnNewChild.Size = new System.Drawing.Size(100, 22);
            this.btnNewChild.Text = "开子窗体测试";
            this.btnNewChild.Click += new System.EventHandler(this.btnNewChild_Click);
            // 
            // btnNewNormal
            // 
            this.btnNewNormal.Image = ((System.Drawing.Image)(resources.GetObject("btnNewNormal.Image")));
            this.btnNewNormal.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnNewNormal.Name = "btnNewNormal";
            this.btnNewNormal.Size = new System.Drawing.Size(112, 22);
            this.btnNewNormal.Text = "开普通窗体测试";
            this.btnNewNormal.Click += new System.EventHandler(this.btnNewNormal_Click);
            // 
            // btnPopupFromItem
            // 
            this.btnPopupFromItem.Image = ((System.Drawing.Image)(resources.GetObject("btnPopupFromItem.Image")));
            this.btnPopupFromItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnPopupFromItem.Name = "btnPopupFromItem";
            this.btnPopupFromItem.Size = new System.Drawing.Size(112, 22);
            this.btnPopupFromItem.Text = "从工具栏项弹出";
            this.btnPopupFromItem.Click += new System.EventHandler(this.btnPopupFromItem_Click);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Black;
            this.helpToolStripButton.IsLink = true;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(115, 22);
            this.helpToolStripButton.Text = "written by AhDung";
            this.helpToolStripButton.Click += new System.EventHandler(this.helpToolStripButton_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 532);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(774, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(32, 17);
            this.toolStripStatusLabel.Text = "状态";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.colorPicker1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.txbPopupFromTextBox);
            this.panel1.Controls.Add(this.btnPopupFromButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(774, 180);
            this.panel1.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "悬停此处显示Tip";
            this.label6.MouseHover += new System.EventHandler(this.label6_MouseHover);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txbResult);
            this.groupBox2.Location = new System.Drawing.Point(553, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(209, 165);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "DialogResult";
            // 
            // txbResult
            // 
            this.txbResult.Location = new System.Drawing.Point(6, 20);
            this.txbResult.Multiline = true;
            this.txbResult.Name = "txbResult";
            this.txbResult.Size = new System.Drawing.Size(197, 139);
            this.txbResult.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.cmbColor);
            this.groupBox1.Controls.Add(this.cmbSingleStyle);
            this.groupBox1.Controls.Add(this.cmb3DStyle);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(237, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(310, 165);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "弹出窗体选项";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rbSingle);
            this.panel3.Controls.Add(this.rb3D);
            this.panel3.Controls.Add(this.rbNone);
            this.panel3.Location = new System.Drawing.Point(87, 43);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(201, 27);
            this.panel3.TabIndex = 4;
            // 
            // rbSingle
            // 
            this.rbSingle.AutoSize = true;
            this.rbSingle.Location = new System.Drawing.Point(128, 6);
            this.rbSingle.Name = "rbSingle";
            this.rbSingle.Size = new System.Drawing.Size(59, 16);
            this.rbSingle.TabIndex = 1;
            this.rbSingle.Tag = "FixedSingle";
            this.rbSingle.Text = "Single";
            this.rbSingle.UseVisualStyleBackColor = true;
            this.rbSingle.CheckedChanged += new System.EventHandler(this.rbNone_CheckedChanged);
            // 
            // rb3D
            // 
            this.rb3D.AutoSize = true;
            this.rb3D.Checked = true;
            this.rb3D.Location = new System.Drawing.Point(70, 6);
            this.rb3D.Name = "rb3D";
            this.rb3D.Size = new System.Drawing.Size(35, 16);
            this.rb3D.TabIndex = 1;
            this.rb3D.TabStop = true;
            this.rb3D.Tag = "Fixed3D";
            this.rb3D.Text = "3D";
            this.rb3D.UseVisualStyleBackColor = true;
            this.rb3D.CheckedChanged += new System.EventHandler(this.rbNone_CheckedChanged);
            // 
            // rbNone
            // 
            this.rbNone.AutoSize = true;
            this.rbNone.Location = new System.Drawing.Point(8, 6);
            this.rbNone.Name = "rbNone";
            this.rbNone.Size = new System.Drawing.Size(47, 16);
            this.rbNone.TabIndex = 1;
            this.rbNone.Text = "None";
            this.rbNone.UseVisualStyleBackColor = true;
            this.rbNone.CheckedChanged += new System.EventHandler(this.rbNone_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rbShowDialog);
            this.panel2.Controls.Add(this.rbShow);
            this.panel2.Location = new System.Drawing.Point(87, 18);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(186, 22);
            this.panel2.TabIndex = 3;
            // 
            // rbShowDialog
            // 
            this.rbShowDialog.AutoSize = true;
            this.rbShowDialog.Location = new System.Drawing.Point(70, 4);
            this.rbShowDialog.Name = "rbShowDialog";
            this.rbShowDialog.Size = new System.Drawing.Size(83, 16);
            this.rbShowDialog.TabIndex = 1;
            this.rbShowDialog.Text = "ShowDialog";
            this.rbShowDialog.UseVisualStyleBackColor = true;
            // 
            // rbShow
            // 
            this.rbShow.AutoSize = true;
            this.rbShow.Checked = true;
            this.rbShow.Location = new System.Drawing.Point(8, 4);
            this.rbShow.Name = "rbShow";
            this.rbShow.Size = new System.Drawing.Size(47, 16);
            this.rbShow.TabIndex = 1;
            this.rbShow.TabStop = true;
            this.rbShow.Text = "Show";
            this.rbShow.UseVisualStyleBackColor = true;
            this.rbShow.CheckedChanged += new System.EventHandler(this.rbShow_CheckedChanged);
            // 
            // cmbColor
            // 
            this.cmbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbColor.Enabled = false;
            this.cmbColor.FormattingEnabled = true;
            this.cmbColor.Location = new System.Drawing.Point(134, 135);
            this.cmbColor.Name = "cmbColor";
            this.cmbColor.Size = new System.Drawing.Size(165, 20);
            this.cmbColor.Sorted = true;
            this.cmbColor.TabIndex = 2;
            // 
            // cmbSingleStyle
            // 
            this.cmbSingleStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSingleStyle.Enabled = false;
            this.cmbSingleStyle.FormattingEnabled = true;
            this.cmbSingleStyle.Location = new System.Drawing.Point(134, 105);
            this.cmbSingleStyle.Name = "cmbSingleStyle";
            this.cmbSingleStyle.Size = new System.Drawing.Size(165, 20);
            this.cmbSingleStyle.Sorted = true;
            this.cmbSingleStyle.TabIndex = 2;
            // 
            // cmb3DStyle
            // 
            this.cmb3DStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb3DStyle.FormattingEnabled = true;
            this.cmb3DStyle.Location = new System.Drawing.Point(134, 76);
            this.cmb3DStyle.Name = "cmb3DStyle";
            this.cmb3DStyle.Size = new System.Drawing.Size(165, 20);
            this.cmb3DStyle.Sorted = true;
            this.cmb3DStyle.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "BorderColor：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "BorderSingleStyle：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "Border3DStyle：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "BorderType：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "弹出行为：";
            // 
            // txbPopupFromTextBox
            // 
            this.txbPopupFromTextBox.Location = new System.Drawing.Point(115, 15);
            this.txbPopupFromTextBox.Name = "txbPopupFromTextBox";
            this.txbPopupFromTextBox.Size = new System.Drawing.Size(116, 21);
            this.txbPopupFromTextBox.TabIndex = 1;
            this.txbPopupFromTextBox.Text = "从控件弹出";
            this.txbPopupFromTextBox.Click += new System.EventHandler(this.txbPopupFromTextBox_Click);
            // 
            // btnPopupFromButton
            // 
            this.btnPopupFromButton.Location = new System.Drawing.Point(12, 13);
            this.btnPopupFromButton.Name = "btnPopupFromButton";
            this.btnPopupFromButton.Size = new System.Drawing.Size(97, 23);
            this.btnPopupFromButton.TabIndex = 0;
            this.btnPopupFromButton.Text = "从控件弹出";
            this.btnPopupFromButton.UseVisualStyleBackColor = true;
            this.btnPopupFromButton.Click += new System.EventHandler(this.btnPopupFromButton_Click);
            // 
            // colorPicker1
            // 
            this.colorPicker1.FormattingEnabled = true;
            this.colorPicker1.Location = new System.Drawing.Point(110, 109);
            this.colorPicker1.Name = "colorPicker1";
            this.colorPicker1.Size = new System.Drawing.Size(74, 20);
            this.colorPicker1.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "颜色选择器Demo:";
            // 
            // FmMDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 554);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.IsMdiContainer = true;
            this.Name = "FmMDI";
            this.Text = "PopupFormTester";
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripButton btnNewChild;
        private System.Windows.Forms.ToolStripButton btnPopupFromItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripLabel helpToolStripButton;
        private System.Windows.Forms.ToolStripButton btnNewNormal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbSingle;
        private System.Windows.Forms.RadioButton rb3D;
        private System.Windows.Forms.RadioButton rbShowDialog;
        private System.Windows.Forms.RadioButton rbNone;
        private System.Windows.Forms.RadioButton rbShow;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbPopupFromTextBox;
        private System.Windows.Forms.Button btnPopupFromButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbSingleStyle;
        private System.Windows.Forms.ComboBox cmb3DStyle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbColor;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txbResult;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private ColorPicker colorPicker1;
        private System.Windows.Forms.Label label7;
    }
}



