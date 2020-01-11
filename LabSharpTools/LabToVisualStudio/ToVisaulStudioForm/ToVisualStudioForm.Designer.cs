namespace Harry.LabTools.LabToVisualStudio
{
	partial class ToVisualStudioForm
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
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.TextBox_SrcProjectPath = new System.Windows.Forms.TextBox();
			this.button_SelectSourceProject = new System.Windows.Forms.Button();
			this.label_SrcProjectName = new System.Windows.Forms.Label();
			this.label_ProjectIDE = new System.Windows.Forms.Label();
			this.comboBox_ProjectIDE = new System.Windows.Forms.ComboBox();
			this.label_VSVersion = new System.Windows.Forms.Label();
			this.comboBox_VSVersion = new System.Windows.Forms.ComboBox();
			this.button_ToVisualStudioProject = new System.Windows.Forms.Button();
			this.checkBox_CloseApplication = new System.Windows.Forms.CheckBox();
			this.checkBox_OpenVSProject = new System.Windows.Forms.CheckBox();
			this.groupBox_DesProject = new System.Windows.Forms.GroupBox();
			this.groupBox_SrcProject = new System.Windows.Forms.GroupBox();
			this.groupBox_Note = new System.Windows.Forms.GroupBox();
			this.label_Note2 = new System.Windows.Forms.Label();
			this.label_Note1 = new System.Windows.Forms.Label();
			this.groupBox_DesProject.SuspendLayout();
			this.groupBox_SrcProject.SuspendLayout();
			this.groupBox_Note.SuspendLayout();
			this.SuspendLayout();
			// 
			// TextBox_SrcProjectPath
			// 
			this.TextBox_SrcProjectPath.Location = new System.Drawing.Point(80, 17);
			this.TextBox_SrcProjectPath.Name = "TextBox_SrcProjectPath";
			this.TextBox_SrcProjectPath.Size = new System.Drawing.Size(310, 21);
			this.TextBox_SrcProjectPath.TabIndex = 2;
			// 
			// button_SelectSourceProject
			// 
			this.button_SelectSourceProject.Location = new System.Drawing.Point(396, 15);
			this.button_SelectSourceProject.Name = "button_SelectSourceProject";
			this.button_SelectSourceProject.Size = new System.Drawing.Size(75, 23);
			this.button_SelectSourceProject.TabIndex = 3;
			this.button_SelectSourceProject.Text = "选择项目";
			this.button_SelectSourceProject.UseVisualStyleBackColor = true;
			// 
			// label_SrcProjectName
			// 
			this.label_SrcProjectName.AutoSize = true;
			this.label_SrcProjectName.Location = new System.Drawing.Point(12, 22);
			this.label_SrcProjectName.Name = "label_SrcProjectName";
			this.label_SrcProjectName.Size = new System.Drawing.Size(65, 12);
			this.label_SrcProjectName.TabIndex = 4;
			this.label_SrcProjectName.Text = "项目路劲：";
			// 
			// label_ProjectIDE
			// 
			this.label_ProjectIDE.AutoSize = true;
			this.label_ProjectIDE.Location = new System.Drawing.Point(12, 26);
			this.label_ProjectIDE.Name = "label_ProjectIDE";
			this.label_ProjectIDE.Size = new System.Drawing.Size(47, 12);
			this.label_ProjectIDE.TabIndex = 5;
			this.label_ProjectIDE.Text = "项目IDE";
			// 
			// comboBox_ProjectIDE
			// 
			this.comboBox_ProjectIDE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_ProjectIDE.FormattingEnabled = true;
			this.comboBox_ProjectIDE.Items.AddRange(new object[] {
            "Keil",
            "IAR"});
			this.comboBox_ProjectIDE.Location = new System.Drawing.Point(11, 41);
			this.comboBox_ProjectIDE.Name = "comboBox_ProjectIDE";
			this.comboBox_ProjectIDE.Size = new System.Drawing.Size(70, 20);
			this.comboBox_ProjectIDE.TabIndex = 6;
			// 
			// label_VSVersion
			// 
			this.label_VSVersion.AutoSize = true;
			this.label_VSVersion.Location = new System.Drawing.Point(98, 26);
			this.label_VSVersion.Name = "label_VSVersion";
			this.label_VSVersion.Size = new System.Drawing.Size(41, 12);
			this.label_VSVersion.TabIndex = 7;
			this.label_VSVersion.Text = "VS版本";
			// 
			// comboBox_VSVersion
			// 
			this.comboBox_VSVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_VSVersion.FormattingEnabled = true;
			this.comboBox_VSVersion.Items.AddRange(new object[] {
            "vs2019",
            "vs2017",
            "vs2015",
            "vs2013",
            "vs2012",
            "vs2010",
            "vs2008",
            "vs2005"});
			this.comboBox_VSVersion.Location = new System.Drawing.Point(100, 41);
			this.comboBox_VSVersion.Name = "comboBox_VSVersion";
			this.comboBox_VSVersion.Size = new System.Drawing.Size(76, 20);
			this.comboBox_VSVersion.TabIndex = 8;
			// 
			// button_ToVisualStudioProject
			// 
			this.button_ToVisualStudioProject.Location = new System.Drawing.Point(396, 19);
			this.button_ToVisualStudioProject.Name = "button_ToVisualStudioProject";
			this.button_ToVisualStudioProject.Size = new System.Drawing.Size(75, 23);
			this.button_ToVisualStudioProject.TabIndex = 9;
			this.button_ToVisualStudioProject.Text = "工程转换";
			this.button_ToVisualStudioProject.UseVisualStyleBackColor = true;
			// 
			// checkBox_CloseApplication
			// 
			this.checkBox_CloseApplication.AutoSize = true;
			this.checkBox_CloseApplication.Checked = true;
			this.checkBox_CloseApplication.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox_CloseApplication.Location = new System.Drawing.Point(192, 22);
			this.checkBox_CloseApplication.Name = "checkBox_CloseApplication";
			this.checkBox_CloseApplication.Size = new System.Drawing.Size(96, 16);
			this.checkBox_CloseApplication.TabIndex = 10;
			this.checkBox_CloseApplication.Text = "自动关闭应用";
			this.checkBox_CloseApplication.UseVisualStyleBackColor = true;
			// 
			// checkBox_OpenVSProject
			// 
			this.checkBox_OpenVSProject.AutoSize = true;
			this.checkBox_OpenVSProject.Location = new System.Drawing.Point(192, 44);
			this.checkBox_OpenVSProject.Name = "checkBox_OpenVSProject";
			this.checkBox_OpenVSProject.Size = new System.Drawing.Size(84, 16);
			this.checkBox_OpenVSProject.TabIndex = 11;
			this.checkBox_OpenVSProject.Text = "打开VS工程";
			this.checkBox_OpenVSProject.UseVisualStyleBackColor = true;
			// 
			// groupBox_DesProject
			// 
			this.groupBox_DesProject.Controls.Add(this.comboBox_ProjectIDE);
			this.groupBox_DesProject.Controls.Add(this.label_ProjectIDE);
			this.groupBox_DesProject.Controls.Add(this.comboBox_VSVersion);
			this.groupBox_DesProject.Controls.Add(this.label_VSVersion);
			this.groupBox_DesProject.Controls.Add(this.button_ToVisualStudioProject);
			this.groupBox_DesProject.Controls.Add(this.checkBox_OpenVSProject);
			this.groupBox_DesProject.Controls.Add(this.checkBox_CloseApplication);
			this.groupBox_DesProject.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox_DesProject.Location = new System.Drawing.Point(0, 60);
			this.groupBox_DesProject.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox_DesProject.Name = "groupBox_DesProject";
			this.groupBox_DesProject.Padding = new System.Windows.Forms.Padding(2);
			this.groupBox_DesProject.Size = new System.Drawing.Size(476, 69);
			this.groupBox_DesProject.TabIndex = 15;
			this.groupBox_DesProject.TabStop = false;
			this.groupBox_DesProject.Text = "工程转换";
			// 
			// groupBox_SrcProject
			// 
			this.groupBox_SrcProject.Controls.Add(this.label_SrcProjectName);
			this.groupBox_SrcProject.Controls.Add(this.TextBox_SrcProjectPath);
			this.groupBox_SrcProject.Controls.Add(this.button_SelectSourceProject);
			this.groupBox_SrcProject.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox_SrcProject.Location = new System.Drawing.Point(0, 6);
			this.groupBox_SrcProject.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox_SrcProject.Name = "groupBox_SrcProject";
			this.groupBox_SrcProject.Padding = new System.Windows.Forms.Padding(2);
			this.groupBox_SrcProject.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.groupBox_SrcProject.Size = new System.Drawing.Size(476, 54);
			this.groupBox_SrcProject.TabIndex = 14;
			this.groupBox_SrcProject.TabStop = false;
			this.groupBox_SrcProject.Text = "项目工程";
			// 
			// groupBox_Note
			// 
			this.groupBox_Note.Controls.Add(this.label_Note2);
			this.groupBox_Note.Controls.Add(this.label_Note1);
			this.groupBox_Note.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox_Note.Location = new System.Drawing.Point(0, 129);
			this.groupBox_Note.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox_Note.Name = "groupBox_Note";
			this.groupBox_Note.Padding = new System.Windows.Forms.Padding(2);
			this.groupBox_Note.Size = new System.Drawing.Size(476, 69);
			this.groupBox_Note.TabIndex = 16;
			this.groupBox_Note.TabStop = false;
			this.groupBox_Note.Text = "注意事项";
			// 
			// label_Note2
			// 
			this.label_Note2.AutoSize = true;
			this.label_Note2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label_Note2.ForeColor = System.Drawing.Color.Red;
			this.label_Note2.Location = new System.Drawing.Point(23, 32);
			this.label_Note2.Name = "label_Note2";
			this.label_Note2.Size = new System.Drawing.Size(143, 12);
			this.label_Note2.TabIndex = 1;
			this.label_Note2.Text = "2. 建议使用英文路劲；";
			// 
			// label_Note1
			// 
			this.label_Note1.AutoSize = true;
			this.label_Note1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label_Note1.ForeColor = System.Drawing.Color.Red;
			this.label_Note1.Location = new System.Drawing.Point(23, 16);
			this.label_Note1.Name = "label_Note1";
			this.label_Note1.Size = new System.Drawing.Size(429, 12);
			this.label_Note1.TabIndex = 0;
			this.label_Note1.Text = "1. 本工具不支持工程或者路劲有特殊字符，比如空格，下划线，中文等；";
			// 
			// ToVisualStudioForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(476, 179);
			this.Controls.Add(this.groupBox_Note);
			this.Controls.Add(this.groupBox_DesProject);
			this.Controls.Add(this.groupBox_SrcProject);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ToVisualStudioForm";
			this.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "创建VisualStudio工程";
			this.groupBox_DesProject.ResumeLayout(false);
			this.groupBox_DesProject.PerformLayout();
			this.groupBox_SrcProject.ResumeLayout(false);
			this.groupBox_SrcProject.PerformLayout();
			this.groupBox_Note.ResumeLayout(false);
			this.groupBox_Note.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TextBox TextBox_SrcProjectPath;
		private System.Windows.Forms.Button button_SelectSourceProject;
		private System.Windows.Forms.Label label_SrcProjectName;
		private System.Windows.Forms.Label label_ProjectIDE;
		private System.Windows.Forms.ComboBox comboBox_ProjectIDE;
		private System.Windows.Forms.Label label_VSVersion;
		private System.Windows.Forms.ComboBox comboBox_VSVersion;
		private System.Windows.Forms.Button button_ToVisualStudioProject;
		private System.Windows.Forms.CheckBox checkBox_CloseApplication;
		private System.Windows.Forms.CheckBox checkBox_OpenVSProject;
		private System.Windows.Forms.GroupBox groupBox_DesProject;
		private System.Windows.Forms.GroupBox groupBox_SrcProject;
		private System.Windows.Forms.GroupBox groupBox_Note;
		private System.Windows.Forms.Label label_Note1;
		private System.Windows.Forms.Label label_Note2;
	}
}

