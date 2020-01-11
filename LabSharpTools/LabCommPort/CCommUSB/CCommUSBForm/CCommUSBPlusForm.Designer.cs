namespace Harry.LabTools.LabCommType
{
	partial class CCommUSBPlusForm
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
			this.cCommUSB = new Harry.LabTools.LabCommType.CCommUSBPlusControl();
			this.SuspendLayout();
			// 
			// cCommUSB
			// 
			this.cCommUSB.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cCommUSB.Location = new System.Drawing.Point(0, 0);
			this.cCommUSB.mCCOMM = null;
			this.cCommUSB.mCCommRichTextBox = null;
			this.cCommUSB.mIsShowCommParam = true;
			this.cCommUSB.Name = "cCommUSB";
			this.cCommUSB.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
			this.cCommUSB.Size = new System.Drawing.Size(151, 132);
			this.cCommUSB.TabIndex = 0;
			// 
			// CCommUSBPlusForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(151, 132);
			this.Controls.Add(this.cCommUSB);
			this.Name = "CCommUSBPlusForm";
			this.Text = "CCommUSBPlusForm";
			this.ResumeLayout(false);

		}

		#endregion

		private CCommUSBPlusControl cCommUSB;
	}
}