namespace Harry.LabTools.LabCommPort
{
	partial class CCommPortTypeForm
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
			this.button_ConfigCCommType = new System.Windows.Forms.Button();
			this.cCheckedListBoxEx_CommType = new Harry.LabTools.LabControlPlus.CCheckedListBoxEx();
			this.SuspendLayout();
			// 
			// button_ConfigCCommType
			// 
			this.button_ConfigCCommType.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.button_ConfigCCommType.Location = new System.Drawing.Point(4, 58);
			this.button_ConfigCCommType.Name = "button_ConfigCCommType";
			this.button_ConfigCCommType.Size = new System.Drawing.Size(88, 23);
			this.button_ConfigCCommType.TabIndex = 2;
			this.button_ConfigCCommType.Text = "通讯方式";
			this.button_ConfigCCommType.UseVisualStyleBackColor = true;
			// 
			// cCheckedListBoxEx_CommType
			// 
			this.cCheckedListBoxEx_CommType.BackColor = System.Drawing.SystemColors.MenuBar;
			this.cCheckedListBoxEx_CommType.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.cCheckedListBoxEx_CommType.CheckOnClick = true;
			this.cCheckedListBoxEx_CommType.Dock = System.Windows.Forms.DockStyle.Top;
			this.cCheckedListBoxEx_CommType.FormattingEnabled = true;
			this.cCheckedListBoxEx_CommType.Items.AddRange(new object[] {
            "串口通讯",
            "USB通讯"});
			this.cCheckedListBoxEx_CommType.Location = new System.Drawing.Point(4, 16);
			this.cCheckedListBoxEx_CommType.Name = "cCheckedListBoxEx_CommType";
			this.cCheckedListBoxEx_CommType.Size = new System.Drawing.Size(88, 32);
			this.cCheckedListBoxEx_CommType.TabIndex = 3;
			// 
			// CCommPortTypeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(96, 85);
			this.Controls.Add(this.cCheckedListBoxEx_CommType);
			this.Controls.Add(this.button_ConfigCCommType);
			this.Name = "CCommPortTypeForm";
			this.Padding = new System.Windows.Forms.Padding(4, 16, 4, 4);
			this.Text = "通讯方式";
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button button_ConfigCCommType;
		private LabControlPlus.CCheckedListBoxEx cCheckedListBoxEx_CommType;
	}
}