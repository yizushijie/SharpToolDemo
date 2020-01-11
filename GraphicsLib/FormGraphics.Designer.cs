namespace TestAgent.GraphicsLib
{
    partial class FormGraphics
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGraphics));
            this.toolTip_Graphics = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip_Graphics = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_Graphics = new System.Windows.Forms.Panel();
            this.pictureBox_Graphics = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.num_XScale = new System.Windows.Forms.NumericUpDown();
            this.num_YScale = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip_Graphics.SuspendLayout();
            this.panel_Graphics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Graphics)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_XScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_YScale)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip_Graphics
            // 
            this.menuStrip_Graphics.AllowMerge = false;
            this.menuStrip_Graphics.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip_Graphics.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip_Graphics.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_Graphics.Name = "menuStrip_Graphics";
            this.menuStrip_Graphics.Size = new System.Drawing.Size(785, 24);
            this.menuStrip_Graphics.TabIndex = 0;
            this.menuStrip_Graphics.Text = "menuStrip_Graphics";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.openToolStripMenuItem.Text = "&Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(101, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setupToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // setupToolStripMenuItem
            // 
            this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
            this.setupToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.setupToolStripMenuItem.Text = "&Option";
            this.setupToolStripMenuItem.Click += new System.EventHandler(this.optionToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // panel_Graphics
            // 
            this.panel_Graphics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Graphics.AutoScroll = true;
            this.panel_Graphics.Controls.Add(this.pictureBox_Graphics);
            this.panel_Graphics.Location = new System.Drawing.Point(12, 27);
            this.panel_Graphics.Name = "panel_Graphics";
            this.panel_Graphics.Size = new System.Drawing.Size(761, 457);
            this.panel_Graphics.TabIndex = 1;
            this.panel_Graphics.SizeChanged += new System.EventHandler(this.panel_Graphics_SizeChanged);
            // 
            // pictureBox_Graphics
            // 
            this.pictureBox_Graphics.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox_Graphics.Location = new System.Drawing.Point(3, 3);
            this.pictureBox_Graphics.Name = "pictureBox_Graphics";
            this.pictureBox_Graphics.Size = new System.Drawing.Size(755, 451);
            this.pictureBox_Graphics.TabIndex = 0;
            this.pictureBox_Graphics.TabStop = false;
            this.pictureBox_Graphics.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Graphics_Paint);
            this.pictureBox_Graphics.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_Graphics_MouseClick);
            this.pictureBox_Graphics.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_Graphics_MouseDown);
            this.pictureBox_Graphics.MouseHover += new System.EventHandler(this.pictureBox_Graphics_MouseHover);
            this.pictureBox_Graphics.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_Graphics_MouseMove);
            this.pictureBox_Graphics.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_Graphics_MouseUp);
            this.pictureBox_Graphics.Resize += new System.EventHandler(this.pictureBox_Graphics_Resize);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(12, 490);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Scale X:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // num_XScale
            // 
            this.num_XScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.num_XScale.DecimalPlaces = 1;
            this.num_XScale.Increment = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.num_XScale.Location = new System.Drawing.Point(89, 490);
            this.num_XScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.num_XScale.Name = "num_XScale";
            this.num_XScale.Size = new System.Drawing.Size(64, 21);
            this.num_XScale.TabIndex = 3;
            this.num_XScale.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num_XScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_XScale.ValueChanged += new System.EventHandler(this.num_Scale_ValueChanged);
            // 
            // num_YScale
            // 
            this.num_YScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.num_YScale.DecimalPlaces = 1;
            this.num_YScale.Increment = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.num_YScale.Location = new System.Drawing.Point(233, 491);
            this.num_YScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.num_YScale.Name = "num_YScale";
            this.num_YScale.Size = new System.Drawing.Size(57, 21);
            this.num_YScale.TabIndex = 5;
            this.num_YScale.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.num_YScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_YScale.ValueChanged += new System.EventHandler(this.num_Scale_ValueChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(159, 490);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Scale Y:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // FormGraphics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 519);
            this.Controls.Add(this.num_YScale);
            this.Controls.Add(this.num_XScale);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel_Graphics);
            this.Controls.Add(this.menuStrip_Graphics);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip_Graphics;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormGraphics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FormGraphics";
            this.Load += new System.EventHandler(this.FormGraphics_Load);
            this.menuStrip_Graphics.ResumeLayout(false);
            this.menuStrip_Graphics.PerformLayout();
            this.panel_Graphics.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Graphics)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_XScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_YScale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip_Graphics;
        private System.Windows.Forms.MenuStrip menuStrip_Graphics;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem;
        private System.Windows.Forms.Panel panel_Graphics;
        private System.Windows.Forms.PictureBox pictureBox_Graphics;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown num_XScale;
        private System.Windows.Forms.NumericUpDown num_YScale;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}