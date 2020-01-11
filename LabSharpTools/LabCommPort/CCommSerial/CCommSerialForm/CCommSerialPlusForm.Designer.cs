namespace Harry.LabTools.LabCommType
{
    partial class CCommSerialPlusForm
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
			this.cCommSerial = new Harry.LabTools.LabCommType.CCommSerialPlusControl();
			this.SuspendLayout();
			// 
			// cCommSerial
			// 
			this.cCommSerial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cCommSerial.Location = new System.Drawing.Point(4, 4);
			this.cCommSerial.Margin = new System.Windows.Forms.Padding(0);
			this.cCommSerial.mCCOMM = null;
			this.cCommSerial.mCCommRichTextBox = null;
			this.cCommSerial.MinimumSize = new System.Drawing.Size(151, 189);
			this.cCommSerial.mIsShowCommParam = true;
			this.cCommSerial.Name = "cCommSerial";
			this.cCommSerial.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
			this.cCommSerial.Size = new System.Drawing.Size(151, 189);
			this.cCommSerial.TabIndex = 1;
			// 
			// CCommSerialPlusForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(159, 197);
			this.Controls.Add(this.cCommSerial);
			this.DoubleBuffered = true;
			this.Name = "CCommSerialPlusForm";
			this.Text = "CCommSerialPlusForm";
			this.ResumeLayout(false);

        }

		#endregion

		private CCommSerialPlusControl cCommSerial;
	}
}