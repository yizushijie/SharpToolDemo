namespace Harry.LabTools.LabCommType
{
	partial class CCommSerialFullForm
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
			this.cCommSerial = new Harry.LabTools.LabCommType.CCommSerialFullControl();
			this.SuspendLayout();
			// 
			// cCommSerial
			// 
			this.cCommSerial.Location = new System.Drawing.Point(2, 3);
			this.cCommSerial.mCCOMM = null;
			this.cCommSerial.mCCommRichTextBox = null;
			this.cCommSerial.mIsShowCommParam = true;
			this.cCommSerial.Name = "cCommSerial";
			this.cCommSerial.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
			this.cCommSerial.Size = new System.Drawing.Size(291, 160);
			this.cCommSerial.TabIndex = 0;
			// 
			// CCommSerialFullForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(296, 166);
			this.Controls.Add(this.cCommSerial);
			this.Name = "CCommSerialFullForm";
			this.Text = "CCommSerialFullForm";
			this.ResumeLayout(false);

		}

		#endregion

		private CCommSerialFullControl cCommSerial;
	}
}