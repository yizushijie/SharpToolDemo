namespace Harry.LabTools.LabCommType
{
	partial class CCommTypeForm
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
			this.radioButton_CCommSerial = new System.Windows.Forms.RadioButton();
			this.radioButton_CCommUSB = new System.Windows.Forms.RadioButton();
			this.button_ConfigCCommType = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// radioButton_CCommSerial
			// 
			this.radioButton_CCommSerial.AutoSize = true;
			this.radioButton_CCommSerial.Checked = true;
			this.radioButton_CCommSerial.Location = new System.Drawing.Point(12, 12);
			this.radioButton_CCommSerial.Name = "radioButton_CCommSerial";
			this.radioButton_CCommSerial.Size = new System.Drawing.Size(71, 16);
			this.radioButton_CCommSerial.TabIndex = 0;
			this.radioButton_CCommSerial.TabStop = true;
			this.radioButton_CCommSerial.Text = "串口通讯";
			this.radioButton_CCommSerial.UseVisualStyleBackColor = true;
			// 
			// radioButton_CCommUSB
			// 
			this.radioButton_CCommUSB.AutoSize = true;
			this.radioButton_CCommUSB.Location = new System.Drawing.Point(12, 34);
			this.radioButton_CCommUSB.Name = "radioButton_CCommUSB";
			this.radioButton_CCommUSB.Size = new System.Drawing.Size(65, 16);
			this.radioButton_CCommUSB.TabIndex = 1;
			this.radioButton_CCommUSB.Text = "USB通讯";
			this.radioButton_CCommUSB.UseVisualStyleBackColor = true;
			// 
			// button_ConfigCCommType
			// 
			this.button_ConfigCCommType.Location = new System.Drawing.Point(12, 56);
			this.button_ConfigCCommType.Name = "button_ConfigCCommType";
			this.button_ConfigCCommType.Size = new System.Drawing.Size(75, 23);
			this.button_ConfigCCommType.TabIndex = 2;
			this.button_ConfigCCommType.Text = "通讯方式";
			this.button_ConfigCCommType.UseVisualStyleBackColor = true;
			// 
			// CCommBasePlusForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(96, 85);
			this.Controls.Add(this.button_ConfigCCommType);
			this.Controls.Add(this.radioButton_CCommUSB);
			this.Controls.Add(this.radioButton_CCommSerial);
			this.Name = "CCommBasePlusForm";
			this.Text = "通讯方式";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RadioButton radioButton_CCommSerial;
		private System.Windows.Forms.RadioButton radioButton_CCommUSB;
		private System.Windows.Forms.Button button_ConfigCCommType;
	}
}