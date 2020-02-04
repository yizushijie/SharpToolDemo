namespace LabMcuForm
{
	partial class CMcuFormAVR8BitsForm
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
			this.menuStrip_ChipMenu = new System.Windows.Forms.MenuStrip();
			this.ToolStripMenuItem_File = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItem_Cmd = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItem_Edit = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItem_About = new System.Windows.Forms.ToolStripMenuItem();
			this.timer_ChipRTCTime = new System.Windows.Forms.Timer(this.components);
			this.toolTip_ChipClock = new System.Windows.Forms.ToolTip(this.components);
			this.tabControl_ChipMenu = new Harry.LabTools.LabControlPlus.CTabControlEx();
			this.tabPage_ChipFunc = new System.Windows.Forms.TabPage();
			this.panel_ChipMsg = new System.Windows.Forms.Panel();
			this.cRichTextBoxEx_ChipMsg = new Harry.LabTools.LabControlPlus.CRichTextBoxEx();
			this.panel_ChipFunc = new System.Windows.Forms.Panel();
			this.cMcuFormAVR8BitsFuseAndLockControl_ChipFuse = new LabMcuForm.CMcuFormAVR8Bits.CMcuFormAVR8BitsFuseAndLockControl();
			this.panel_ChipCheckFunc = new System.Windows.Forms.Panel();
			this.label_EepromSize = new System.Windows.Forms.Label();
			this.label_Eeprom = new System.Windows.Forms.Label();
			this.label_FlashSize = new System.Windows.Forms.Label();
			this.label_Flash = new System.Windows.Forms.Label();
			this.button_AutoChip = new System.Windows.Forms.Button();
			this.button_Erase = new System.Windows.Forms.Button();
			this.cCheckedListBoxEx_FuncMaskStep2 = new Harry.LabTools.LabControlPlus.CCheckedListBoxEx();
			this.cCheckedListBoxEx_FuncMaskStep1 = new Harry.LabTools.LabControlPlus.CCheckedListBoxEx();
			this.panel_ChipButtonFunc = new System.Windows.Forms.Panel();
			this.groupBox_CmdFunc = new System.Windows.Forms.GroupBox();
			this.button_ReadChipROM = new System.Windows.Forms.Button();
			this.button_WriteChipLock = new System.Windows.Forms.Button();
			this.button_WriteChipFuse = new System.Windows.Forms.Button();
			this.button_CheckChipEeprom = new System.Windows.Forms.Button();
			this.button_WriteChipEeprom = new System.Windows.Forms.Button();
			this.button_ReadChipEeprom = new System.Windows.Forms.Button();
			this.button_CheckChipFlash = new System.Windows.Forms.Button();
			this.button_WriteChipFlash = new System.Windows.Forms.Button();
			this.button_ReadChipFlash = new System.Windows.Forms.Button();
			this.button_ReadIDChip = new System.Windows.Forms.Button();
			this.button_CheckChipEmpty = new System.Windows.Forms.Button();
			this.button_EraseChip = new System.Windows.Forms.Button();
			this.button_ChipAuto = new System.Windows.Forms.Button();
			this.groupBox_FileFunc = new System.Windows.Forms.GroupBox();
			this.button_SaveEepromFile = new System.Windows.Forms.Button();
			this.button_SaveFlashFile = new System.Windows.Forms.Button();
			this.button_LoadEepromFile = new System.Windows.Forms.Button();
			this.button_LoadFlashFile = new System.Windows.Forms.Button();
			this.toolStrip_ChipTool = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel_ChipRTCTimerName = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator_ChipRTCTimerName = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel_ChipRTCTimer = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator_ChipRTCTimer = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel_VersionName = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator_VersionName = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel_Version = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator_Version = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel_ChipStateName = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator_ChipStateName = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel_ChipState = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator_ChipState = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel_ChipTimeName = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator_ChipTimeName = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel_ChipTime = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator_ChipTime = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripProgressBar_ChipBar = new System.Windows.Forms.ToolStripProgressBar();
			this.panel_ChipID = new System.Windows.Forms.Panel();
			this.groupBox_ChipClock = new System.Windows.Forms.GroupBox();
			this.label_ChipClockUnite = new System.Windows.Forms.Label();
			this.textBox_ChipClock = new System.Windows.Forms.TextBox();
			this.button_SetChipClock = new System.Windows.Forms.Button();
			this.trackBar_ChipClock = new System.Windows.Forms.TrackBar();
			this.groupBox_ChipInterfaceAndPWR = new System.Windows.Forms.GroupBox();
			this.checkBox_ChipPWR = new System.Windows.Forms.CheckBox();
			this.button_ReadChipPWR = new System.Windows.Forms.Button();
			this.label_ChipPWRUnite = new System.Windows.Forms.Label();
			this.textBox_ChipPWR = new System.Windows.Forms.TextBox();
			this.button_SetChipPWR = new System.Windows.Forms.Button();
			this.label_ChipPWR = new System.Windows.Forms.Label();
			this.label_ChipInterface = new System.Windows.Forms.Label();
			this.button_SetChipInterface = new System.Windows.Forms.Button();
			this.comboBox_ChipInterface = new System.Windows.Forms.ComboBox();
			this.groupBox_ChipType = new System.Windows.Forms.GroupBox();
			this.comboBox_ChipType = new System.Windows.Forms.ComboBox();
			this.button_ReadChipID = new System.Windows.Forms.Button();
			this.textBox_ChipID = new System.Windows.Forms.TextBox();
			this.label_ChipID = new System.Windows.Forms.Label();
			this.cCommBaseControl_ChipCOMM = new Harry.LabTools.LabCommPort.CCommPortControl();
			this.tabPage_ChipEdit = new System.Windows.Forms.TabPage();
			this.tabControl_ChipMemery = new Harry.LabTools.LabControlPlus.CTabControlEx();
			this.tabPage_Flash = new System.Windows.Forms.TabPage();
			this.cHexBox_Flash = new Harry.LabTools.LabHexEdit.CHexBox();
			this.tabPage_Eeprom = new System.Windows.Forms.TabPage();
			this.cHexBox_Eeprom = new Harry.LabTools.LabHexEdit.CHexBox();
			this.tabPage_ROM = new System.Windows.Forms.TabPage();
			this.cHexBox_ROM = new Harry.LabTools.LabHexEdit.CHexBox();
			this.menuStrip_ChipMenu.SuspendLayout();
			this.tabControl_ChipMenu.SuspendLayout();
			this.tabPage_ChipFunc.SuspendLayout();
			this.panel_ChipMsg.SuspendLayout();
			this.panel_ChipFunc.SuspendLayout();
			this.panel_ChipCheckFunc.SuspendLayout();
			this.panel_ChipButtonFunc.SuspendLayout();
			this.groupBox_CmdFunc.SuspendLayout();
			this.groupBox_FileFunc.SuspendLayout();
			this.toolStrip_ChipTool.SuspendLayout();
			this.panel_ChipID.SuspendLayout();
			this.groupBox_ChipClock.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_ChipClock)).BeginInit();
			this.groupBox_ChipInterfaceAndPWR.SuspendLayout();
			this.groupBox_ChipType.SuspendLayout();
			this.tabPage_ChipEdit.SuspendLayout();
			this.tabControl_ChipMemery.SuspendLayout();
			this.tabPage_Flash.SuspendLayout();
			this.tabPage_Eeprom.SuspendLayout();
			this.tabPage_ROM.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip_ChipMenu
			// 
			this.menuStrip_ChipMenu.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.menuStrip_ChipMenu.GripMargin = new System.Windows.Forms.Padding(2);
			this.menuStrip_ChipMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_File,
            this.ToolStripMenuItem_Cmd,
            this.ToolStripMenuItem_Edit,
            this.ToolStripMenuItem_About});
			this.menuStrip_ChipMenu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
			this.menuStrip_ChipMenu.Location = new System.Drawing.Point(2, 2);
			this.menuStrip_ChipMenu.Margin = new System.Windows.Forms.Padding(3);
			this.menuStrip_ChipMenu.Name = "menuStrip_ChipMenu";
			this.menuStrip_ChipMenu.Padding = new System.Windows.Forms.Padding(3);
			this.menuStrip_ChipMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.menuStrip_ChipMenu.Size = new System.Drawing.Size(1218, 26);
			this.menuStrip_ChipMenu.TabIndex = 3;
			this.menuStrip_ChipMenu.Text = "menuStrip1";
			// 
			// ToolStripMenuItem_File
			// 
			this.ToolStripMenuItem_File.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.ToolStripMenuItem_File.Name = "ToolStripMenuItem_File";
			this.ToolStripMenuItem_File.Padding = new System.Windows.Forms.Padding(2);
			this.ToolStripMenuItem_File.Size = new System.Drawing.Size(55, 20);
			this.ToolStripMenuItem_File.Text = "文件(&Z)";
			// 
			// ToolStripMenuItem_Cmd
			// 
			this.ToolStripMenuItem_Cmd.Name = "ToolStripMenuItem_Cmd";
			this.ToolStripMenuItem_Cmd.Padding = new System.Windows.Forms.Padding(2);
			this.ToolStripMenuItem_Cmd.Size = new System.Drawing.Size(55, 20);
			this.ToolStripMenuItem_Cmd.Text = "命令(&Y)";
			// 
			// ToolStripMenuItem_Edit
			// 
			this.ToolStripMenuItem_Edit.Name = "ToolStripMenuItem_Edit";
			this.ToolStripMenuItem_Edit.Padding = new System.Windows.Forms.Padding(2);
			this.ToolStripMenuItem_Edit.Size = new System.Drawing.Size(55, 20);
			this.ToolStripMenuItem_Edit.Text = "编辑(&X)";
			// 
			// ToolStripMenuItem_About
			// 
			this.ToolStripMenuItem_About.Name = "ToolStripMenuItem_About";
			this.ToolStripMenuItem_About.Padding = new System.Windows.Forms.Padding(2);
			this.ToolStripMenuItem_About.Size = new System.Drawing.Size(55, 20);
			this.ToolStripMenuItem_About.Text = "关于(&W)";
			// 
			// timer_ChipRTCTime
			// 
			this.timer_ChipRTCTime.Enabled = true;
			this.timer_ChipRTCTime.Interval = 1000;
			this.timer_ChipRTCTime.Tag = "timer_ChipRTCTime";
			// 
			// tabControl_ChipMenu
			// 
			this.tabControl_ChipMenu.Controls.Add(this.tabPage_ChipFunc);
			this.tabControl_ChipMenu.Controls.Add(this.tabPage_ChipEdit);
			this.tabControl_ChipMenu.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl_ChipMenu.ItemSize = new System.Drawing.Size(56, 18);
			this.tabControl_ChipMenu.Location = new System.Drawing.Point(2, 28);
			this.tabControl_ChipMenu.Name = "tabControl_ChipMenu";
			this.tabControl_ChipMenu.SelectedIndex = 0;
			this.tabControl_ChipMenu.Size = new System.Drawing.Size(1218, 693);
			this.tabControl_ChipMenu.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			this.tabControl_ChipMenu.TabIndex = 2;
			// 
			// tabPage_ChipFunc
			// 
			this.tabPage_ChipFunc.BackColor = System.Drawing.Color.WhiteSmoke;
			this.tabPage_ChipFunc.Controls.Add(this.panel_ChipMsg);
			this.tabPage_ChipFunc.Controls.Add(this.panel_ChipFunc);
			this.tabPage_ChipFunc.Controls.Add(this.panel_ChipButtonFunc);
			this.tabPage_ChipFunc.Controls.Add(this.toolStrip_ChipTool);
			this.tabPage_ChipFunc.Controls.Add(this.panel_ChipID);
			this.tabPage_ChipFunc.Location = new System.Drawing.Point(4, 22);
			this.tabPage_ChipFunc.Name = "tabPage_ChipFunc";
			this.tabPage_ChipFunc.Padding = new System.Windows.Forms.Padding(2);
			this.tabPage_ChipFunc.Size = new System.Drawing.Size(1210, 667);
			this.tabPage_ChipFunc.TabIndex = 0;
			this.tabPage_ChipFunc.Text = "编程";
			this.tabPage_ChipFunc.UseVisualStyleBackColor = true;
			// 
			// panel_ChipMsg
			// 
			this.panel_ChipMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel_ChipMsg.Controls.Add(this.cRichTextBoxEx_ChipMsg);
			this.panel_ChipMsg.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel_ChipMsg.Location = new System.Drawing.Point(2, 365);
			this.panel_ChipMsg.Name = "panel_ChipMsg";
			this.panel_ChipMsg.Padding = new System.Windows.Forms.Padding(4);
			this.panel_ChipMsg.Size = new System.Drawing.Size(1094, 275);
			this.panel_ChipMsg.TabIndex = 7;
			// 
			// cRichTextBoxEx_ChipMsg
			// 
			this.cRichTextBoxEx_ChipMsg.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cRichTextBoxEx_ChipMsg.Location = new System.Drawing.Point(4, 4);
			this.cRichTextBoxEx_ChipMsg.Name = "cRichTextBoxEx_ChipMsg";
			this.cRichTextBoxEx_ChipMsg.Size = new System.Drawing.Size(1084, 265);
			this.cRichTextBoxEx_ChipMsg.TabIndex = 0;
			this.cRichTextBoxEx_ChipMsg.Text = "";
			// 
			// panel_ChipFunc
			// 
			this.panel_ChipFunc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel_ChipFunc.Controls.Add(this.cMcuFormAVR8BitsFuseAndLockControl_ChipFuse);
			this.panel_ChipFunc.Controls.Add(this.panel_ChipCheckFunc);
			this.panel_ChipFunc.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel_ChipFunc.Location = new System.Drawing.Point(2, 81);
			this.panel_ChipFunc.Name = "panel_ChipFunc";
			this.panel_ChipFunc.Size = new System.Drawing.Size(1094, 284);
			this.panel_ChipFunc.TabIndex = 6;
			// 
			// cMcuFormAVR8BitsFuseAndLockControl_ChipFuse
			// 
			this.cMcuFormAVR8BitsFuseAndLockControl_ChipFuse.Dock = System.Windows.Forms.DockStyle.Left;
			this.cMcuFormAVR8BitsFuseAndLockControl_ChipFuse.Location = new System.Drawing.Point(0, 0);
			this.cMcuFormAVR8BitsFuseAndLockControl_ChipFuse.MaximumSize = new System.Drawing.Size(515, 278);
			this.cMcuFormAVR8BitsFuseAndLockControl_ChipFuse.mCMcuFunc = null;
			this.cMcuFormAVR8BitsFuseAndLockControl_ChipFuse.MinimumSize = new System.Drawing.Size(515, 278);
			this.cMcuFormAVR8BitsFuseAndLockControl_ChipFuse.Name = "cMcuFormAVR8BitsFuseAndLockControl_ChipFuse";
			this.cMcuFormAVR8BitsFuseAndLockControl_ChipFuse.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
			this.cMcuFormAVR8BitsFuseAndLockControl_ChipFuse.Size = new System.Drawing.Size(515, 278);
			this.cMcuFormAVR8BitsFuseAndLockControl_ChipFuse.TabIndex = 2;
			// 
			// panel_ChipCheckFunc
			// 
			this.panel_ChipCheckFunc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel_ChipCheckFunc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel_ChipCheckFunc.Controls.Add(this.label_EepromSize);
			this.panel_ChipCheckFunc.Controls.Add(this.label_Eeprom);
			this.panel_ChipCheckFunc.Controls.Add(this.label_FlashSize);
			this.panel_ChipCheckFunc.Controls.Add(this.label_Flash);
			this.panel_ChipCheckFunc.Controls.Add(this.button_AutoChip);
			this.panel_ChipCheckFunc.Controls.Add(this.button_Erase);
			this.panel_ChipCheckFunc.Controls.Add(this.cCheckedListBoxEx_FuncMaskStep2);
			this.panel_ChipCheckFunc.Controls.Add(this.cCheckedListBoxEx_FuncMaskStep1);
			this.panel_ChipCheckFunc.Location = new System.Drawing.Point(518, 8);
			this.panel_ChipCheckFunc.Name = "panel_ChipCheckFunc";
			this.panel_ChipCheckFunc.Size = new System.Drawing.Size(569, 271);
			this.panel_ChipCheckFunc.TabIndex = 1;
			// 
			// label_EepromSize
			// 
			this.label_EepromSize.AutoSize = true;
			this.label_EepromSize.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label_EepromSize.Location = new System.Drawing.Point(213, 196);
			this.label_EepromSize.Name = "label_EepromSize";
			this.label_EepromSize.Size = new System.Drawing.Size(40, 12);
			this.label_EepromSize.TabIndex = 7;
			this.label_EepromSize.Text = "0/512";
			// 
			// label_Eeprom
			// 
			this.label_Eeprom.AutoSize = true;
			this.label_Eeprom.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label_Eeprom.Location = new System.Drawing.Point(160, 196);
			this.label_Eeprom.Name = "label_Eeprom";
			this.label_Eeprom.Size = new System.Drawing.Size(60, 12);
			this.label_Eeprom.TabIndex = 6;
			this.label_Eeprom.Text = "Eeprom：";
			// 
			// label_FlashSize
			// 
			this.label_FlashSize.AutoSize = true;
			this.label_FlashSize.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label_FlashSize.Location = new System.Drawing.Point(65, 196);
			this.label_FlashSize.Name = "label_FlashSize";
			this.label_FlashSize.Size = new System.Drawing.Size(47, 12);
			this.label_FlashSize.TabIndex = 5;
			this.label_FlashSize.Text = "0/8192";
			// 
			// label_Flash
			// 
			this.label_Flash.AutoSize = true;
			this.label_Flash.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label_Flash.Location = new System.Drawing.Point(16, 196);
			this.label_Flash.Name = "label_Flash";
			this.label_Flash.Size = new System.Drawing.Size(53, 12);
			this.label_Flash.TabIndex = 4;
			this.label_Flash.Text = "Flash：";
			// 
			// button_AutoChip
			// 
			this.button_AutoChip.Location = new System.Drawing.Point(159, 166);
			this.button_AutoChip.Name = "button_AutoChip";
			this.button_AutoChip.Size = new System.Drawing.Size(120, 27);
			this.button_AutoChip.TabIndex = 3;
			this.button_AutoChip.Text = "自动";
			this.button_AutoChip.UseVisualStyleBackColor = true;
			// 
			// button_Erase
			// 
			this.button_Erase.Location = new System.Drawing.Point(16, 166);
			this.button_Erase.Name = "button_Erase";
			this.button_Erase.Size = new System.Drawing.Size(120, 27);
			this.button_Erase.TabIndex = 2;
			this.button_Erase.Text = "擦除";
			this.button_Erase.UseVisualStyleBackColor = true;
			// 
			// cCheckedListBoxEx_FuncMaskStep2
			// 
			this.cCheckedListBoxEx_FuncMaskStep2.BackColor = System.Drawing.Color.WhiteSmoke;
			this.cCheckedListBoxEx_FuncMaskStep2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.cCheckedListBoxEx_FuncMaskStep2.CheckOnClick = true;
			this.cCheckedListBoxEx_FuncMaskStep2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.cCheckedListBoxEx_FuncMaskStep2.FormattingEnabled = true;
			this.cCheckedListBoxEx_FuncMaskStep2.Items.AddRange(new object[] {
            "数据自动重载",
            "校验Flash",
            "校验EEPROM",
            "编程熔丝位",
            "编程加密位",
            "校验熔丝位",
            "校验加密位"});
			this.cCheckedListBoxEx_FuncMaskStep2.Location = new System.Drawing.Point(159, 11);
			this.cCheckedListBoxEx_FuncMaskStep2.Name = "cCheckedListBoxEx_FuncMaskStep2";
			this.cCheckedListBoxEx_FuncMaskStep2.Size = new System.Drawing.Size(120, 146);
			this.cCheckedListBoxEx_FuncMaskStep2.TabIndex = 1;
			// 
			// cCheckedListBoxEx_FuncMaskStep1
			// 
			this.cCheckedListBoxEx_FuncMaskStep1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.cCheckedListBoxEx_FuncMaskStep1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.cCheckedListBoxEx_FuncMaskStep1.CheckOnClick = true;
			this.cCheckedListBoxEx_FuncMaskStep1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.cCheckedListBoxEx_FuncMaskStep1.FormattingEnabled = true;
			this.cCheckedListBoxEx_FuncMaskStep1.Items.AddRange(new object[] {
            "数据改变下载",
            "比较识别字",
            "芯片擦除",
            "空片检查",
            "编程Flash",
            "编程Eeprom"});
			this.cCheckedListBoxEx_FuncMaskStep1.Location = new System.Drawing.Point(16, 11);
			this.cCheckedListBoxEx_FuncMaskStep1.Name = "cCheckedListBoxEx_FuncMaskStep1";
			this.cCheckedListBoxEx_FuncMaskStep1.Size = new System.Drawing.Size(120, 146);
			this.cCheckedListBoxEx_FuncMaskStep1.TabIndex = 0;
			// 
			// panel_ChipButtonFunc
			// 
			this.panel_ChipButtonFunc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel_ChipButtonFunc.Controls.Add(this.groupBox_CmdFunc);
			this.panel_ChipButtonFunc.Controls.Add(this.groupBox_FileFunc);
			this.panel_ChipButtonFunc.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel_ChipButtonFunc.Location = new System.Drawing.Point(1096, 81);
			this.panel_ChipButtonFunc.Name = "panel_ChipButtonFunc";
			this.panel_ChipButtonFunc.Padding = new System.Windows.Forms.Padding(2, 4, 2, 2);
			this.panel_ChipButtonFunc.Size = new System.Drawing.Size(112, 559);
			this.panel_ChipButtonFunc.TabIndex = 5;
			// 
			// groupBox_CmdFunc
			// 
			this.groupBox_CmdFunc.Controls.Add(this.button_ReadChipROM);
			this.groupBox_CmdFunc.Controls.Add(this.button_WriteChipLock);
			this.groupBox_CmdFunc.Controls.Add(this.button_WriteChipFuse);
			this.groupBox_CmdFunc.Controls.Add(this.button_CheckChipEeprom);
			this.groupBox_CmdFunc.Controls.Add(this.button_WriteChipEeprom);
			this.groupBox_CmdFunc.Controls.Add(this.button_ReadChipEeprom);
			this.groupBox_CmdFunc.Controls.Add(this.button_CheckChipFlash);
			this.groupBox_CmdFunc.Controls.Add(this.button_WriteChipFlash);
			this.groupBox_CmdFunc.Controls.Add(this.button_ReadChipFlash);
			this.groupBox_CmdFunc.Controls.Add(this.button_ReadIDChip);
			this.groupBox_CmdFunc.Controls.Add(this.button_CheckChipEmpty);
			this.groupBox_CmdFunc.Controls.Add(this.button_EraseChip);
			this.groupBox_CmdFunc.Controls.Add(this.button_ChipAuto);
			this.groupBox_CmdFunc.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox_CmdFunc.Location = new System.Drawing.Point(2, 132);
			this.groupBox_CmdFunc.Name = "groupBox_CmdFunc";
			this.groupBox_CmdFunc.Padding = new System.Windows.Forms.Padding(2);
			this.groupBox_CmdFunc.Size = new System.Drawing.Size(106, 423);
			this.groupBox_CmdFunc.TabIndex = 1;
			this.groupBox_CmdFunc.TabStop = false;
			this.groupBox_CmdFunc.Text = "命令操作";
			// 
			// button_ReadChipROM
			// 
			this.button_ReadChipROM.Dock = System.Windows.Forms.DockStyle.Top;
			this.button_ReadChipROM.Location = new System.Drawing.Point(2, 340);
			this.button_ReadChipROM.Name = "button_ReadChipROM";
			this.button_ReadChipROM.Padding = new System.Windows.Forms.Padding(1);
			this.button_ReadChipROM.Size = new System.Drawing.Size(102, 27);
			this.button_ReadChipROM.TabIndex = 13;
			this.button_ReadChipROM.Text = "读取ROM页";
			this.button_ReadChipROM.UseVisualStyleBackColor = true;
			// 
			// button_WriteChipLock
			// 
			this.button_WriteChipLock.Dock = System.Windows.Forms.DockStyle.Top;
			this.button_WriteChipLock.Location = new System.Drawing.Point(2, 313);
			this.button_WriteChipLock.Name = "button_WriteChipLock";
			this.button_WriteChipLock.Padding = new System.Windows.Forms.Padding(1);
			this.button_WriteChipLock.Size = new System.Drawing.Size(102, 27);
			this.button_WriteChipLock.TabIndex = 12;
			this.button_WriteChipLock.Text = "编程加密位";
			this.button_WriteChipLock.UseVisualStyleBackColor = true;
			// 
			// button_WriteChipFuse
			// 
			this.button_WriteChipFuse.Dock = System.Windows.Forms.DockStyle.Top;
			this.button_WriteChipFuse.Location = new System.Drawing.Point(2, 286);
			this.button_WriteChipFuse.Name = "button_WriteChipFuse";
			this.button_WriteChipFuse.Padding = new System.Windows.Forms.Padding(1);
			this.button_WriteChipFuse.Size = new System.Drawing.Size(102, 27);
			this.button_WriteChipFuse.TabIndex = 11;
			this.button_WriteChipFuse.Text = "编程熔丝位";
			this.button_WriteChipFuse.UseVisualStyleBackColor = true;
			// 
			// button_CheckChipEeprom
			// 
			this.button_CheckChipEeprom.Dock = System.Windows.Forms.DockStyle.Top;
			this.button_CheckChipEeprom.Location = new System.Drawing.Point(2, 259);
			this.button_CheckChipEeprom.Name = "button_CheckChipEeprom";
			this.button_CheckChipEeprom.Padding = new System.Windows.Forms.Padding(1);
			this.button_CheckChipEeprom.Size = new System.Drawing.Size(102, 27);
			this.button_CheckChipEeprom.TabIndex = 10;
			this.button_CheckChipEeprom.Text = "校验Eeprom";
			this.button_CheckChipEeprom.UseVisualStyleBackColor = true;
			// 
			// button_WriteChipEeprom
			// 
			this.button_WriteChipEeprom.Dock = System.Windows.Forms.DockStyle.Top;
			this.button_WriteChipEeprom.Location = new System.Drawing.Point(2, 232);
			this.button_WriteChipEeprom.Name = "button_WriteChipEeprom";
			this.button_WriteChipEeprom.Padding = new System.Windows.Forms.Padding(1);
			this.button_WriteChipEeprom.Size = new System.Drawing.Size(102, 27);
			this.button_WriteChipEeprom.TabIndex = 9;
			this.button_WriteChipEeprom.Text = "写入Eeprom";
			this.button_WriteChipEeprom.UseVisualStyleBackColor = true;
			// 
			// button_ReadChipEeprom
			// 
			this.button_ReadChipEeprom.Dock = System.Windows.Forms.DockStyle.Top;
			this.button_ReadChipEeprom.Location = new System.Drawing.Point(2, 205);
			this.button_ReadChipEeprom.Name = "button_ReadChipEeprom";
			this.button_ReadChipEeprom.Padding = new System.Windows.Forms.Padding(1);
			this.button_ReadChipEeprom.Size = new System.Drawing.Size(102, 27);
			this.button_ReadChipEeprom.TabIndex = 8;
			this.button_ReadChipEeprom.Text = "读出Eeprom";
			this.button_ReadChipEeprom.UseVisualStyleBackColor = true;
			// 
			// button_CheckChipFlash
			// 
			this.button_CheckChipFlash.Dock = System.Windows.Forms.DockStyle.Top;
			this.button_CheckChipFlash.Location = new System.Drawing.Point(2, 178);
			this.button_CheckChipFlash.Name = "button_CheckChipFlash";
			this.button_CheckChipFlash.Padding = new System.Windows.Forms.Padding(1);
			this.button_CheckChipFlash.Size = new System.Drawing.Size(102, 27);
			this.button_CheckChipFlash.TabIndex = 7;
			this.button_CheckChipFlash.Text = "校验Flash";
			this.button_CheckChipFlash.UseVisualStyleBackColor = true;
			// 
			// button_WriteChipFlash
			// 
			this.button_WriteChipFlash.Dock = System.Windows.Forms.DockStyle.Top;
			this.button_WriteChipFlash.Location = new System.Drawing.Point(2, 151);
			this.button_WriteChipFlash.Name = "button_WriteChipFlash";
			this.button_WriteChipFlash.Padding = new System.Windows.Forms.Padding(1);
			this.button_WriteChipFlash.Size = new System.Drawing.Size(102, 27);
			this.button_WriteChipFlash.TabIndex = 6;
			this.button_WriteChipFlash.Text = "写入Flash";
			this.button_WriteChipFlash.UseVisualStyleBackColor = true;
			// 
			// button_ReadChipFlash
			// 
			this.button_ReadChipFlash.Dock = System.Windows.Forms.DockStyle.Top;
			this.button_ReadChipFlash.Location = new System.Drawing.Point(2, 124);
			this.button_ReadChipFlash.Name = "button_ReadChipFlash";
			this.button_ReadChipFlash.Padding = new System.Windows.Forms.Padding(1);
			this.button_ReadChipFlash.Size = new System.Drawing.Size(102, 27);
			this.button_ReadChipFlash.TabIndex = 5;
			this.button_ReadChipFlash.Text = "读取Flash";
			this.button_ReadChipFlash.UseVisualStyleBackColor = true;
			// 
			// button_ReadIDChip
			// 
			this.button_ReadIDChip.Dock = System.Windows.Forms.DockStyle.Top;
			this.button_ReadIDChip.Location = new System.Drawing.Point(2, 97);
			this.button_ReadIDChip.Name = "button_ReadIDChip";
			this.button_ReadIDChip.Padding = new System.Windows.Forms.Padding(1);
			this.button_ReadIDChip.Size = new System.Drawing.Size(102, 27);
			this.button_ReadIDChip.TabIndex = 4;
			this.button_ReadIDChip.Text = "读出识别字";
			this.button_ReadIDChip.UseVisualStyleBackColor = true;
			// 
			// button_CheckChipEmpty
			// 
			this.button_CheckChipEmpty.Dock = System.Windows.Forms.DockStyle.Top;
			this.button_CheckChipEmpty.Location = new System.Drawing.Point(2, 70);
			this.button_CheckChipEmpty.Name = "button_CheckChipEmpty";
			this.button_CheckChipEmpty.Padding = new System.Windows.Forms.Padding(1);
			this.button_CheckChipEmpty.Size = new System.Drawing.Size(102, 27);
			this.button_CheckChipEmpty.TabIndex = 3;
			this.button_CheckChipEmpty.Text = "查空";
			this.button_CheckChipEmpty.UseVisualStyleBackColor = true;
			// 
			// button_EraseChip
			// 
			this.button_EraseChip.Dock = System.Windows.Forms.DockStyle.Top;
			this.button_EraseChip.Location = new System.Drawing.Point(2, 43);
			this.button_EraseChip.Name = "button_EraseChip";
			this.button_EraseChip.Padding = new System.Windows.Forms.Padding(1);
			this.button_EraseChip.Size = new System.Drawing.Size(102, 27);
			this.button_EraseChip.TabIndex = 2;
			this.button_EraseChip.Text = "擦除";
			this.button_EraseChip.UseVisualStyleBackColor = true;
			// 
			// button_ChipAuto
			// 
			this.button_ChipAuto.Dock = System.Windows.Forms.DockStyle.Top;
			this.button_ChipAuto.Location = new System.Drawing.Point(2, 16);
			this.button_ChipAuto.Name = "button_ChipAuto";
			this.button_ChipAuto.Padding = new System.Windows.Forms.Padding(1);
			this.button_ChipAuto.Size = new System.Drawing.Size(102, 27);
			this.button_ChipAuto.TabIndex = 1;
			this.button_ChipAuto.Text = "自动";
			this.button_ChipAuto.UseVisualStyleBackColor = true;
			// 
			// groupBox_FileFunc
			// 
			this.groupBox_FileFunc.Controls.Add(this.button_SaveEepromFile);
			this.groupBox_FileFunc.Controls.Add(this.button_SaveFlashFile);
			this.groupBox_FileFunc.Controls.Add(this.button_LoadEepromFile);
			this.groupBox_FileFunc.Controls.Add(this.button_LoadFlashFile);
			this.groupBox_FileFunc.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox_FileFunc.Location = new System.Drawing.Point(2, 4);
			this.groupBox_FileFunc.Name = "groupBox_FileFunc";
			this.groupBox_FileFunc.Padding = new System.Windows.Forms.Padding(2);
			this.groupBox_FileFunc.Size = new System.Drawing.Size(106, 128);
			this.groupBox_FileFunc.TabIndex = 0;
			this.groupBox_FileFunc.TabStop = false;
			this.groupBox_FileFunc.Text = "文件操作";
			// 
			// button_SaveEepromFile
			// 
			this.button_SaveEepromFile.Dock = System.Windows.Forms.DockStyle.Top;
			this.button_SaveEepromFile.Location = new System.Drawing.Point(2, 97);
			this.button_SaveEepromFile.Name = "button_SaveEepromFile";
			this.button_SaveEepromFile.Padding = new System.Windows.Forms.Padding(1);
			this.button_SaveEepromFile.Size = new System.Drawing.Size(102, 27);
			this.button_SaveEepromFile.TabIndex = 3;
			this.button_SaveEepromFile.Text = "保存Eeprom文件";
			this.button_SaveEepromFile.UseVisualStyleBackColor = true;
			// 
			// button_SaveFlashFile
			// 
			this.button_SaveFlashFile.Dock = System.Windows.Forms.DockStyle.Top;
			this.button_SaveFlashFile.Location = new System.Drawing.Point(2, 70);
			this.button_SaveFlashFile.Name = "button_SaveFlashFile";
			this.button_SaveFlashFile.Padding = new System.Windows.Forms.Padding(1);
			this.button_SaveFlashFile.Size = new System.Drawing.Size(102, 27);
			this.button_SaveFlashFile.TabIndex = 2;
			this.button_SaveFlashFile.Text = "保存Flash文件";
			this.button_SaveFlashFile.UseVisualStyleBackColor = true;
			// 
			// button_LoadEepromFile
			// 
			this.button_LoadEepromFile.Dock = System.Windows.Forms.DockStyle.Top;
			this.button_LoadEepromFile.Location = new System.Drawing.Point(2, 43);
			this.button_LoadEepromFile.Name = "button_LoadEepromFile";
			this.button_LoadEepromFile.Padding = new System.Windows.Forms.Padding(1);
			this.button_LoadEepromFile.Size = new System.Drawing.Size(102, 27);
			this.button_LoadEepromFile.TabIndex = 1;
			this.button_LoadEepromFile.Text = "调入Eeprom文件";
			this.button_LoadEepromFile.UseVisualStyleBackColor = true;
			// 
			// button_LoadFlashFile
			// 
			this.button_LoadFlashFile.Dock = System.Windows.Forms.DockStyle.Top;
			this.button_LoadFlashFile.Location = new System.Drawing.Point(2, 16);
			this.button_LoadFlashFile.Name = "button_LoadFlashFile";
			this.button_LoadFlashFile.Padding = new System.Windows.Forms.Padding(1);
			this.button_LoadFlashFile.Size = new System.Drawing.Size(102, 27);
			this.button_LoadFlashFile.TabIndex = 0;
			this.button_LoadFlashFile.Text = "调入Flash文件";
			this.button_LoadFlashFile.UseVisualStyleBackColor = true;
			// 
			// toolStrip_ChipTool
			// 
			this.toolStrip_ChipTool.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.toolStrip_ChipTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_ChipRTCTimerName,
            this.toolStripSeparator_ChipRTCTimerName,
            this.toolStripLabel_ChipRTCTimer,
            this.toolStripSeparator_ChipRTCTimer,
            this.toolStripLabel_VersionName,
            this.toolStripSeparator_VersionName,
            this.toolStripLabel_Version,
            this.toolStripSeparator_Version,
            this.toolStripLabel_ChipStateName,
            this.toolStripSeparator_ChipStateName,
            this.toolStripLabel_ChipState,
            this.toolStripSeparator_ChipState,
            this.toolStripLabel_ChipTimeName,
            this.toolStripSeparator_ChipTimeName,
            this.toolStripLabel_ChipTime,
            this.toolStripSeparator_ChipTime,
            this.toolStripProgressBar_ChipBar});
			this.toolStrip_ChipTool.Location = new System.Drawing.Point(2, 640);
			this.toolStrip_ChipTool.Name = "toolStrip_ChipTool";
			this.toolStrip_ChipTool.Size = new System.Drawing.Size(1206, 25);
			this.toolStrip_ChipTool.TabIndex = 4;
			this.toolStrip_ChipTool.Text = "toolStrip1";
			// 
			// toolStripLabel_ChipRTCTimerName
			// 
			this.toolStripLabel_ChipRTCTimerName.Name = "toolStripLabel_ChipRTCTimerName";
			this.toolStripLabel_ChipRTCTimerName.Size = new System.Drawing.Size(56, 22);
			this.toolStripLabel_ChipRTCTimerName.Text = "当前时间";
			// 
			// toolStripSeparator_ChipRTCTimerName
			// 
			this.toolStripSeparator_ChipRTCTimerName.Name = "toolStripSeparator_ChipRTCTimerName";
			this.toolStripSeparator_ChipRTCTimerName.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripLabel_ChipRTCTimer
			// 
			this.toolStripLabel_ChipRTCTimer.AutoSize = false;
			this.toolStripLabel_ChipRTCTimer.Name = "toolStripLabel_ChipRTCTimer";
			this.toolStripLabel_ChipRTCTimer.Size = new System.Drawing.Size(146, 22);
			this.toolStripLabel_ChipRTCTimer.Text = "0000-00-00-00-00-00";
			// 
			// toolStripSeparator_ChipRTCTimer
			// 
			this.toolStripSeparator_ChipRTCTimer.Name = "toolStripSeparator_ChipRTCTimer";
			this.toolStripSeparator_ChipRTCTimer.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripLabel_VersionName
			// 
			this.toolStripLabel_VersionName.AutoSize = false;
			this.toolStripLabel_VersionName.Name = "toolStripLabel_VersionName";
			this.toolStripLabel_VersionName.Size = new System.Drawing.Size(36, 22);
			this.toolStripLabel_VersionName.Text = "版本";
			// 
			// toolStripSeparator_VersionName
			// 
			this.toolStripSeparator_VersionName.Name = "toolStripSeparator_VersionName";
			this.toolStripSeparator_VersionName.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripLabel_Version
			// 
			this.toolStripLabel_Version.AutoSize = false;
			this.toolStripLabel_Version.Name = "toolStripLabel_Version";
			this.toolStripLabel_Version.Size = new System.Drawing.Size(88, 22);
			this.toolStripLabel_Version.Text = "00-00-00-00";
			// 
			// toolStripSeparator_Version
			// 
			this.toolStripSeparator_Version.Name = "toolStripSeparator_Version";
			this.toolStripSeparator_Version.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripLabel_ChipStateName
			// 
			this.toolStripLabel_ChipStateName.Name = "toolStripLabel_ChipStateName";
			this.toolStripLabel_ChipStateName.Size = new System.Drawing.Size(32, 22);
			this.toolStripLabel_ChipStateName.Text = "状态";
			// 
			// toolStripSeparator_ChipStateName
			// 
			this.toolStripSeparator_ChipStateName.Name = "toolStripSeparator_ChipStateName";
			this.toolStripSeparator_ChipStateName.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripLabel_ChipState
			// 
			this.toolStripLabel_ChipState.AutoSize = false;
			this.toolStripLabel_ChipState.Name = "toolStripLabel_ChipState";
			this.toolStripLabel_ChipState.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.toolStripLabel_ChipState.Size = new System.Drawing.Size(100, 22);
			this.toolStripLabel_ChipState.Text = "空闲";
			// 
			// toolStripSeparator_ChipState
			// 
			this.toolStripSeparator_ChipState.Name = "toolStripSeparator_ChipState";
			this.toolStripSeparator_ChipState.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripLabel_ChipTimeName
			// 
			this.toolStripLabel_ChipTimeName.Name = "toolStripLabel_ChipTimeName";
			this.toolStripLabel_ChipTimeName.Size = new System.Drawing.Size(56, 22);
			this.toolStripLabel_ChipTimeName.Text = "使用时间";
			// 
			// toolStripSeparator_ChipTimeName
			// 
			this.toolStripSeparator_ChipTimeName.Name = "toolStripSeparator_ChipTimeName";
			this.toolStripSeparator_ChipTimeName.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripLabel_ChipTime
			// 
			this.toolStripLabel_ChipTime.AutoSize = false;
			this.toolStripLabel_ChipTime.Name = "toolStripLabel_ChipTime";
			this.toolStripLabel_ChipTime.Size = new System.Drawing.Size(74, 22);
			this.toolStripLabel_ChipTime.Text = "00:00:00";
			// 
			// toolStripSeparator_ChipTime
			// 
			this.toolStripSeparator_ChipTime.Name = "toolStripSeparator_ChipTime";
			this.toolStripSeparator_ChipTime.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripProgressBar_ChipBar
			// 
			this.toolStripProgressBar_ChipBar.AutoSize = false;
			this.toolStripProgressBar_ChipBar.Margin = new System.Windows.Forms.Padding(3);
			this.toolStripProgressBar_ChipBar.Name = "toolStripProgressBar_ChipBar";
			this.toolStripProgressBar_ChipBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.toolStripProgressBar_ChipBar.Size = new System.Drawing.Size(524, 18);
			this.toolStripProgressBar_ChipBar.Step = 1;
			// 
			// panel_ChipID
			// 
			this.panel_ChipID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel_ChipID.Controls.Add(this.groupBox_ChipClock);
			this.panel_ChipID.Controls.Add(this.groupBox_ChipInterfaceAndPWR);
			this.panel_ChipID.Controls.Add(this.groupBox_ChipType);
			this.panel_ChipID.Controls.Add(this.cCommBaseControl_ChipCOMM);
			this.panel_ChipID.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel_ChipID.Location = new System.Drawing.Point(2, 2);
			this.panel_ChipID.Name = "panel_ChipID";
			this.panel_ChipID.Padding = new System.Windows.Forms.Padding(4, 3, 3, 3);
			this.panel_ChipID.Size = new System.Drawing.Size(1206, 79);
			this.panel_ChipID.TabIndex = 1;
			// 
			// groupBox_ChipClock
			// 
			this.groupBox_ChipClock.Controls.Add(this.label_ChipClockUnite);
			this.groupBox_ChipClock.Controls.Add(this.textBox_ChipClock);
			this.groupBox_ChipClock.Controls.Add(this.button_SetChipClock);
			this.groupBox_ChipClock.Controls.Add(this.trackBar_ChipClock);
			this.groupBox_ChipClock.Dock = System.Windows.Forms.DockStyle.Left;
			this.groupBox_ChipClock.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.groupBox_ChipClock.Location = new System.Drawing.Point(461, 3);
			this.groupBox_ChipClock.Name = "groupBox_ChipClock";
			this.groupBox_ChipClock.Size = new System.Drawing.Size(472, 71);
			this.groupBox_ChipClock.TabIndex = 4;
			this.groupBox_ChipClock.TabStop = false;
			this.groupBox_ChipClock.Text = "时钟配置";
			// 
			// label_ChipClockUnite
			// 
			this.label_ChipClockUnite.AutoSize = true;
			this.label_ChipClockUnite.Dock = System.Windows.Forms.DockStyle.Left;
			this.label_ChipClockUnite.Location = new System.Drawing.Point(441, 17);
			this.label_ChipClockUnite.Margin = new System.Windows.Forms.Padding(3);
			this.label_ChipClockUnite.Name = "label_ChipClockUnite";
			this.label_ChipClockUnite.Padding = new System.Windows.Forms.Padding(3, 4, 3, 3);
			this.label_ChipClockUnite.Size = new System.Drawing.Size(29, 19);
			this.label_ChipClockUnite.TabIndex = 11;
			this.label_ChipClockUnite.Text = "KHz";
			// 
			// textBox_ChipClock
			// 
			this.textBox_ChipClock.Dock = System.Windows.Forms.DockStyle.Left;
			this.textBox_ChipClock.Location = new System.Drawing.Point(396, 17);
			this.textBox_ChipClock.Name = "textBox_ChipClock";
			this.textBox_ChipClock.Size = new System.Drawing.Size(45, 21);
			this.textBox_ChipClock.TabIndex = 10;
			this.textBox_ChipClock.Text = "200";
			this.textBox_ChipClock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// button_SetChipClock
			// 
			this.button_SetChipClock.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.button_SetChipClock.Location = new System.Drawing.Point(396, 45);
			this.button_SetChipClock.Name = "button_SetChipClock";
			this.button_SetChipClock.Size = new System.Drawing.Size(73, 23);
			this.button_SetChipClock.TabIndex = 9;
			this.button_SetChipClock.Text = "时钟设置";
			this.button_SetChipClock.UseVisualStyleBackColor = true;
			// 
			// trackBar_ChipClock
			// 
			this.trackBar_ChipClock.Dock = System.Windows.Forms.DockStyle.Left;
			this.trackBar_ChipClock.LargeChange = 1;
			this.trackBar_ChipClock.Location = new System.Drawing.Point(3, 17);
			this.trackBar_ChipClock.Maximum = 17;
			this.trackBar_ChipClock.Name = "trackBar_ChipClock";
			this.trackBar_ChipClock.Size = new System.Drawing.Size(393, 51);
			this.trackBar_ChipClock.TabIndex = 0;
			this.trackBar_ChipClock.TickStyle = System.Windows.Forms.TickStyle.Both;
			// 
			// groupBox_ChipInterfaceAndPWR
			// 
			this.groupBox_ChipInterfaceAndPWR.Controls.Add(this.checkBox_ChipPWR);
			this.groupBox_ChipInterfaceAndPWR.Controls.Add(this.button_ReadChipPWR);
			this.groupBox_ChipInterfaceAndPWR.Controls.Add(this.label_ChipPWRUnite);
			this.groupBox_ChipInterfaceAndPWR.Controls.Add(this.textBox_ChipPWR);
			this.groupBox_ChipInterfaceAndPWR.Controls.Add(this.button_SetChipPWR);
			this.groupBox_ChipInterfaceAndPWR.Controls.Add(this.label_ChipPWR);
			this.groupBox_ChipInterfaceAndPWR.Controls.Add(this.label_ChipInterface);
			this.groupBox_ChipInterfaceAndPWR.Controls.Add(this.button_SetChipInterface);
			this.groupBox_ChipInterfaceAndPWR.Controls.Add(this.comboBox_ChipInterface);
			this.groupBox_ChipInterfaceAndPWR.Dock = System.Windows.Forms.DockStyle.Left;
			this.groupBox_ChipInterfaceAndPWR.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.groupBox_ChipInterfaceAndPWR.Location = new System.Drawing.Point(185, 3);
			this.groupBox_ChipInterfaceAndPWR.Name = "groupBox_ChipInterfaceAndPWR";
			this.groupBox_ChipInterfaceAndPWR.Size = new System.Drawing.Size(276, 71);
			this.groupBox_ChipInterfaceAndPWR.TabIndex = 2;
			this.groupBox_ChipInterfaceAndPWR.TabStop = false;
			this.groupBox_ChipInterfaceAndPWR.Text = "接口与电源";
			// 
			// checkBox_ChipPWR
			// 
			this.checkBox_ChipPWR.AutoSize = true;
			this.checkBox_ChipPWR.Location = new System.Drawing.Point(183, 19);
			this.checkBox_ChipPWR.Name = "checkBox_ChipPWR";
			this.checkBox_ChipPWR.Size = new System.Drawing.Size(84, 16);
			this.checkBox_ChipPWR.TabIndex = 9;
			this.checkBox_ChipPWR.Text = "使能自供电";
			this.checkBox_ChipPWR.UseVisualStyleBackColor = true;
			// 
			// button_ReadChipPWR
			// 
			this.button_ReadChipPWR.Location = new System.Drawing.Point(114, 42);
			this.button_ReadChipPWR.Name = "button_ReadChipPWR";
			this.button_ReadChipPWR.Size = new System.Drawing.Size(46, 23);
			this.button_ReadChipPWR.TabIndex = 8;
			this.button_ReadChipPWR.Text = "读取";
			this.button_ReadChipPWR.UseVisualStyleBackColor = true;
			// 
			// label_ChipPWRUnite
			// 
			this.label_ChipPWRUnite.AutoSize = true;
			this.label_ChipPWRUnite.Location = new System.Drawing.Point(93, 46);
			this.label_ChipPWRUnite.Name = "label_ChipPWRUnite";
			this.label_ChipPWRUnite.Size = new System.Drawing.Size(11, 12);
			this.label_ChipPWRUnite.TabIndex = 7;
			this.label_ChipPWRUnite.Text = "V";
			// 
			// textBox_ChipPWR
			// 
			this.textBox_ChipPWR.Location = new System.Drawing.Point(42, 42);
			this.textBox_ChipPWR.MaxLength = 32768;
			this.textBox_ChipPWR.Name = "textBox_ChipPWR";
			this.textBox_ChipPWR.Size = new System.Drawing.Size(45, 21);
			this.textBox_ChipPWR.TabIndex = 6;
			this.textBox_ChipPWR.Text = "3.30";
			this.textBox_ChipPWR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// button_SetChipPWR
			// 
			this.button_SetChipPWR.Location = new System.Drawing.Point(205, 40);
			this.button_SetChipPWR.Name = "button_SetChipPWR";
			this.button_SetChipPWR.Size = new System.Drawing.Size(46, 23);
			this.button_SetChipPWR.TabIndex = 4;
			this.button_SetChipPWR.Text = "设置";
			this.button_SetChipPWR.UseVisualStyleBackColor = true;
			// 
			// label_ChipPWR
			// 
			this.label_ChipPWR.AutoSize = true;
			this.label_ChipPWR.Location = new System.Drawing.Point(6, 48);
			this.label_ChipPWR.Name = "label_ChipPWR";
			this.label_ChipPWR.Size = new System.Drawing.Size(29, 12);
			this.label_ChipPWR.TabIndex = 5;
			this.label_ChipPWR.Text = "电压";
			// 
			// label_ChipInterface
			// 
			this.label_ChipInterface.AutoSize = true;
			this.label_ChipInterface.Location = new System.Drawing.Point(6, 23);
			this.label_ChipInterface.Name = "label_ChipInterface";
			this.label_ChipInterface.Size = new System.Drawing.Size(29, 12);
			this.label_ChipInterface.TabIndex = 2;
			this.label_ChipInterface.Text = "接口";
			// 
			// button_SetChipInterface
			// 
			this.button_SetChipInterface.Location = new System.Drawing.Point(114, 15);
			this.button_SetChipInterface.Name = "button_SetChipInterface";
			this.button_SetChipInterface.Size = new System.Drawing.Size(46, 23);
			this.button_SetChipInterface.TabIndex = 4;
			this.button_SetChipInterface.Text = "应用";
			this.button_SetChipInterface.UseVisualStyleBackColor = true;
			// 
			// comboBox_ChipInterface
			// 
			this.comboBox_ChipInterface.FormattingEnabled = true;
			this.comboBox_ChipInterface.IntegralHeight = false;
			this.comboBox_ChipInterface.Items.AddRange(new object[] {
            "ISP",
            "JTAG",
            "HVPP",
            "HVSP"});
			this.comboBox_ChipInterface.Location = new System.Drawing.Point(41, 18);
			this.comboBox_ChipInterface.Name = "comboBox_ChipInterface";
			this.comboBox_ChipInterface.Size = new System.Drawing.Size(67, 20);
			this.comboBox_ChipInterface.TabIndex = 2;
			// 
			// groupBox_ChipType
			// 
			this.groupBox_ChipType.Controls.Add(this.comboBox_ChipType);
			this.groupBox_ChipType.Controls.Add(this.button_ReadChipID);
			this.groupBox_ChipType.Controls.Add(this.textBox_ChipID);
			this.groupBox_ChipType.Controls.Add(this.label_ChipID);
			this.groupBox_ChipType.Dock = System.Windows.Forms.DockStyle.Left;
			this.groupBox_ChipType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.groupBox_ChipType.Location = new System.Drawing.Point(4, 3);
			this.groupBox_ChipType.Name = "groupBox_ChipType";
			this.groupBox_ChipType.Size = new System.Drawing.Size(181, 71);
			this.groupBox_ChipType.TabIndex = 1;
			this.groupBox_ChipType.TabStop = false;
			this.groupBox_ChipType.Text = "芯片类型";
			// 
			// comboBox_ChipType
			// 
			this.comboBox_ChipType.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.comboBox_ChipType.FormattingEnabled = true;
			this.comboBox_ChipType.IntegralHeight = false;
			this.comboBox_ChipType.Location = new System.Drawing.Point(6, 18);
			this.comboBox_ChipType.Name = "comboBox_ChipType";
			this.comboBox_ChipType.Size = new System.Drawing.Size(118, 21);
			this.comboBox_ChipType.TabIndex = 2;
			// 
			// button_ReadChipID
			// 
			this.button_ReadChipID.Location = new System.Drawing.Point(131, 42);
			this.button_ReadChipID.Name = "button_ReadChipID";
			this.button_ReadChipID.Size = new System.Drawing.Size(46, 23);
			this.button_ReadChipID.TabIndex = 3;
			this.button_ReadChipID.Text = "读取";
			this.button_ReadChipID.UseVisualStyleBackColor = true;
			// 
			// textBox_ChipID
			// 
			this.textBox_ChipID.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.textBox_ChipID.Location = new System.Drawing.Point(29, 43);
			this.textBox_ChipID.Name = "textBox_ChipID";
			this.textBox_ChipID.Size = new System.Drawing.Size(96, 21);
			this.textBox_ChipID.TabIndex = 1;
			this.textBox_ChipID.Text = "1E:93:07";
			this.textBox_ChipID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label_ChipID
			// 
			this.label_ChipID.AutoSize = true;
			this.label_ChipID.Location = new System.Drawing.Point(6, 46);
			this.label_ChipID.Name = "label_ChipID";
			this.label_ChipID.Size = new System.Drawing.Size(17, 12);
			this.label_ChipID.TabIndex = 0;
			this.label_ChipID.Text = "ID";
			// 
			// cCommBaseControl_ChipCOMM
			// 
			this.cCommBaseControl_ChipCOMM.Dock = System.Windows.Forms.DockStyle.Right;
			this.cCommBaseControl_ChipCOMM.Location = new System.Drawing.Point(939, 3);
			this.cCommBaseControl_ChipCOMM.mCCOMM = null;
			this.cCommBaseControl_ChipCOMM.mCCommRichTextBox = null;
			this.cCommBaseControl_ChipCOMM.mLimitedControlSize = false;
			this.cCommBaseControl_ChipCOMM.mPerPackageMaxSize = 64;
			this.cCommBaseControl_ChipCOMM.mShowCommParam = true;
			this.cCommBaseControl_ChipCOMM.Name = "cCommBaseControl_ChipCOMM";
			this.cCommBaseControl_ChipCOMM.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
			this.cCommBaseControl_ChipCOMM.Size = new System.Drawing.Size(262, 71);
			this.cCommBaseControl_ChipCOMM.TabIndex = 0;
			// 
			// tabPage_ChipEdit
			// 
			this.tabPage_ChipEdit.BackColor = System.Drawing.Color.WhiteSmoke;
			this.tabPage_ChipEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tabPage_ChipEdit.Controls.Add(this.tabControl_ChipMemery);
			this.tabPage_ChipEdit.Location = new System.Drawing.Point(4, 22);
			this.tabPage_ChipEdit.Margin = new System.Windows.Forms.Padding(0);
			this.tabPage_ChipEdit.Name = "tabPage_ChipEdit";
			this.tabPage_ChipEdit.Size = new System.Drawing.Size(1210, 667);
			this.tabPage_ChipEdit.TabIndex = 1;
			this.tabPage_ChipEdit.Text = "编辑";
			this.tabPage_ChipEdit.UseVisualStyleBackColor = true;
			// 
			// tabControl_ChipMemery
			// 
			this.tabControl_ChipMemery.Alignment = System.Windows.Forms.TabAlignment.Bottom;
			this.tabControl_ChipMemery.Controls.Add(this.tabPage_Flash);
			this.tabControl_ChipMemery.Controls.Add(this.tabPage_Eeprom);
			this.tabControl_ChipMemery.Controls.Add(this.tabPage_ROM);
			this.tabControl_ChipMemery.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl_ChipMemery.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.tabControl_ChipMemery.ItemSize = new System.Drawing.Size(56, 20);
			this.tabControl_ChipMemery.Location = new System.Drawing.Point(0, 0);
			this.tabControl_ChipMemery.Margin = new System.Windows.Forms.Padding(0);
			this.tabControl_ChipMemery.Name = "tabControl_ChipMemery";
			this.tabControl_ChipMemery.SelectedIndex = 0;
			this.tabControl_ChipMemery.Size = new System.Drawing.Size(1208, 665);
			this.tabControl_ChipMemery.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			this.tabControl_ChipMemery.TabIndex = 0;
			// 
			// tabPage_Flash
			// 
			this.tabPage_Flash.BackColor = System.Drawing.Color.WhiteSmoke;
			this.tabPage_Flash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tabPage_Flash.Controls.Add(this.cHexBox_Flash);
			this.tabPage_Flash.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.tabPage_Flash.Location = new System.Drawing.Point(4, 4);
			this.tabPage_Flash.Margin = new System.Windows.Forms.Padding(0);
			this.tabPage_Flash.Name = "tabPage_Flash";
			this.tabPage_Flash.Size = new System.Drawing.Size(1200, 637);
			this.tabPage_Flash.TabIndex = 0;
			this.tabPage_Flash.Text = "FLASH";
			this.tabPage_Flash.UseVisualStyleBackColor = true;
			// 
			// cHexBox_Flash
			// 
			this.cHexBox_Flash.BackColor = System.Drawing.Color.White;
			this.cHexBox_Flash.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cHexBox_Flash.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.cHexBox_Flash.Location = new System.Drawing.Point(0, 0);
			this.cHexBox_Flash.Margin = new System.Windows.Forms.Padding(0);
			this.cHexBox_Flash.mDataFontColorA = System.Drawing.SystemColors.MenuHighlight;
			this.cHexBox_Flash.mDataFontColorB = System.Drawing.Color.MidnightBlue;
			this.cHexBox_Flash.mExternalLineColor = System.Drawing.Color.DarkGray;
			this.cHexBox_Flash.mExternalLineWidth = 2;
			this.cHexBox_Flash.mFirstRowOffset = 4;
			this.cHexBox_Flash.mFont = new System.Drawing.Font("楷体", 12F);
			this.cHexBox_Flash.mFontBackGroundColor = System.Drawing.Color.White;
			this.cHexBox_Flash.mNewDataChange = false;
			this.cHexBox_Flash.mNowData = new byte[] {
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255))};
			this.cHexBox_Flash.mRowDisplayNum = 16;
			this.cHexBox_Flash.mRowStaffWidth = 8;
			this.cHexBox_Flash.mShowChangeBackGroundColor = System.Drawing.Color.Yellow;
			this.cHexBox_Flash.mShowChangeFlag = false;
			this.cHexBox_Flash.mXScaleBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.cHexBox_Flash.mXScaleBackGroundRectangleShow = true;
			this.cHexBox_Flash.mXScaleFontColor = System.Drawing.Color.Black;
			this.cHexBox_Flash.mXScaleHeight = 24;
			this.cHexBox_Flash.mXScaleHeightOffset = 2;
			this.cHexBox_Flash.mXScaleShow = true;
			this.cHexBox_Flash.mXScaleShowBit8 = Harry.LabTools.LabHexEdit.CHexBox.XScaleShowBit8.BIT8X16;
			this.cHexBox_Flash.mXScaleStringShow = true;
			this.cHexBox_Flash.mXScaleStringStartWidth = 579;
			this.cHexBox_Flash.mYScaleBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.cHexBox_Flash.mYScaleBackGroundRectangleShow = true;
			this.cHexBox_Flash.mYScaleFontColor = System.Drawing.Color.Black;
			this.cHexBox_Flash.mYScaleOffsetWidth = 32;
			this.cHexBox_Flash.mYScaleShow = true;
			this.cHexBox_Flash.mYScaleShowBit4 = Harry.LabTools.LabHexEdit.CHexBox.YScaleShowBit4.BIT4X4;
			this.cHexBox_Flash.mYScaleWidth = 86;
			this.cHexBox_Flash.Name = "cHexBox_Flash";
			this.cHexBox_Flash.Size = new System.Drawing.Size(1198, 635);
			this.cHexBox_Flash.TabIndex = 0;
			this.cHexBox_Flash.Text = "Flash";
			// 
			// tabPage_Eeprom
			// 
			this.tabPage_Eeprom.BackColor = System.Drawing.Color.WhiteSmoke;
			this.tabPage_Eeprom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tabPage_Eeprom.Controls.Add(this.cHexBox_Eeprom);
			this.tabPage_Eeprom.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.tabPage_Eeprom.Location = new System.Drawing.Point(4, 4);
			this.tabPage_Eeprom.Margin = new System.Windows.Forms.Padding(0);
			this.tabPage_Eeprom.Name = "tabPage_Eeprom";
			this.tabPage_Eeprom.Size = new System.Drawing.Size(1200, 637);
			this.tabPage_Eeprom.TabIndex = 1;
			this.tabPage_Eeprom.Text = "EEPROM";
			this.tabPage_Eeprom.UseVisualStyleBackColor = true;
			// 
			// cHexBox_Eeprom
			// 
			this.cHexBox_Eeprom.BackColor = System.Drawing.Color.White;
			this.cHexBox_Eeprom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cHexBox_Eeprom.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.cHexBox_Eeprom.Location = new System.Drawing.Point(0, 0);
			this.cHexBox_Eeprom.mDataFontColorA = System.Drawing.SystemColors.MenuHighlight;
			this.cHexBox_Eeprom.mDataFontColorB = System.Drawing.Color.MidnightBlue;
			this.cHexBox_Eeprom.mExternalLineColor = System.Drawing.Color.DarkGray;
			this.cHexBox_Eeprom.mExternalLineWidth = 2;
			this.cHexBox_Eeprom.mFirstRowOffset = 4;
			this.cHexBox_Eeprom.mFont = new System.Drawing.Font("楷体", 12F);
			this.cHexBox_Eeprom.mFontBackGroundColor = System.Drawing.Color.White;
			this.cHexBox_Eeprom.mNewDataChange = false;
			this.cHexBox_Eeprom.mNowData = new byte[] {
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255))};
			this.cHexBox_Eeprom.mRowDisplayNum = 16;
			this.cHexBox_Eeprom.mRowStaffWidth = 8;
			this.cHexBox_Eeprom.mShowChangeBackGroundColor = System.Drawing.Color.Yellow;
			this.cHexBox_Eeprom.mShowChangeFlag = false;
			this.cHexBox_Eeprom.mXScaleBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.cHexBox_Eeprom.mXScaleBackGroundRectangleShow = true;
			this.cHexBox_Eeprom.mXScaleFontColor = System.Drawing.Color.Black;
			this.cHexBox_Eeprom.mXScaleHeight = 24;
			this.cHexBox_Eeprom.mXScaleHeightOffset = 2;
			this.cHexBox_Eeprom.mXScaleShow = true;
			this.cHexBox_Eeprom.mXScaleShowBit8 = Harry.LabTools.LabHexEdit.CHexBox.XScaleShowBit8.BIT8X16;
			this.cHexBox_Eeprom.mXScaleStringShow = true;
			this.cHexBox_Eeprom.mXScaleStringStartWidth = 579;
			this.cHexBox_Eeprom.mYScaleBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.cHexBox_Eeprom.mYScaleBackGroundRectangleShow = true;
			this.cHexBox_Eeprom.mYScaleFontColor = System.Drawing.Color.Black;
			this.cHexBox_Eeprom.mYScaleOffsetWidth = 32;
			this.cHexBox_Eeprom.mYScaleShow = true;
			this.cHexBox_Eeprom.mYScaleShowBit4 = Harry.LabTools.LabHexEdit.CHexBox.YScaleShowBit4.BIT4X4;
			this.cHexBox_Eeprom.mYScaleWidth = 86;
			this.cHexBox_Eeprom.Name = "cHexBox_Eeprom";
			this.cHexBox_Eeprom.Size = new System.Drawing.Size(1198, 635);
			this.cHexBox_Eeprom.TabIndex = 1;
			this.cHexBox_Eeprom.Text = "Eeprom";
			// 
			// tabPage_ROM
			// 
			this.tabPage_ROM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tabPage_ROM.Controls.Add(this.cHexBox_ROM);
			this.tabPage_ROM.Location = new System.Drawing.Point(4, 4);
			this.tabPage_ROM.Margin = new System.Windows.Forms.Padding(0);
			this.tabPage_ROM.Name = "tabPage_ROM";
			this.tabPage_ROM.Size = new System.Drawing.Size(1200, 637);
			this.tabPage_ROM.TabIndex = 2;
			this.tabPage_ROM.Text = "ROM";
			this.tabPage_ROM.UseVisualStyleBackColor = true;
			// 
			// cHexBox_ROM
			// 
			this.cHexBox_ROM.BackColor = System.Drawing.Color.White;
			this.cHexBox_ROM.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cHexBox_ROM.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.cHexBox_ROM.Location = new System.Drawing.Point(0, 0);
			this.cHexBox_ROM.mDataFontColorA = System.Drawing.SystemColors.MenuHighlight;
			this.cHexBox_ROM.mDataFontColorB = System.Drawing.Color.MidnightBlue;
			this.cHexBox_ROM.mExternalLineColor = System.Drawing.Color.DarkGray;
			this.cHexBox_ROM.mExternalLineWidth = 2;
			this.cHexBox_ROM.mFirstRowOffset = 4;
			this.cHexBox_ROM.mFont = new System.Drawing.Font("楷体", 12F);
			this.cHexBox_ROM.mFontBackGroundColor = System.Drawing.Color.White;
			this.cHexBox_ROM.mNewDataChange = false;
			this.cHexBox_ROM.mNowData = new byte[] {
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255)),
        ((byte)(255))};
			this.cHexBox_ROM.mRowDisplayNum = 16;
			this.cHexBox_ROM.mRowStaffWidth = 8;
			this.cHexBox_ROM.mShowChangeBackGroundColor = System.Drawing.Color.Yellow;
			this.cHexBox_ROM.mShowChangeFlag = false;
			this.cHexBox_ROM.mXScaleBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.cHexBox_ROM.mXScaleBackGroundRectangleShow = true;
			this.cHexBox_ROM.mXScaleFontColor = System.Drawing.Color.Black;
			this.cHexBox_ROM.mXScaleHeight = 24;
			this.cHexBox_ROM.mXScaleHeightOffset = 2;
			this.cHexBox_ROM.mXScaleShow = true;
			this.cHexBox_ROM.mXScaleShowBit8 = Harry.LabTools.LabHexEdit.CHexBox.XScaleShowBit8.BIT8X16;
			this.cHexBox_ROM.mXScaleStringShow = true;
			this.cHexBox_ROM.mXScaleStringStartWidth = 579;
			this.cHexBox_ROM.mYScaleBackGroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.cHexBox_ROM.mYScaleBackGroundRectangleShow = true;
			this.cHexBox_ROM.mYScaleFontColor = System.Drawing.Color.Black;
			this.cHexBox_ROM.mYScaleOffsetWidth = 32;
			this.cHexBox_ROM.mYScaleShow = true;
			this.cHexBox_ROM.mYScaleShowBit4 = Harry.LabTools.LabHexEdit.CHexBox.YScaleShowBit4.BIT4X4;
			this.cHexBox_ROM.mYScaleWidth = 86;
			this.cHexBox_ROM.Name = "cHexBox_ROM";
			this.cHexBox_ROM.Size = new System.Drawing.Size(1198, 635);
			this.cHexBox_ROM.TabIndex = 1;
			this.cHexBox_ROM.Text = "ROM";
			// 
			// CMcuFormAVR8BitsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1222, 723);
			this.Controls.Add(this.tabControl_ChipMenu);
			this.Controls.Add(this.menuStrip_ChipMenu);
			this.DoubleBuffered = true;
			this.MainMenuStrip = this.menuStrip_ChipMenu;
			this.Name = "CMcuFormAVR8BitsForm";
			this.Padding = new System.Windows.Forms.Padding(2);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "CMcuFormAVR8Bits";
			this.menuStrip_ChipMenu.ResumeLayout(false);
			this.menuStrip_ChipMenu.PerformLayout();
			this.tabControl_ChipMenu.ResumeLayout(false);
			this.tabPage_ChipFunc.ResumeLayout(false);
			this.tabPage_ChipFunc.PerformLayout();
			this.panel_ChipMsg.ResumeLayout(false);
			this.panel_ChipFunc.ResumeLayout(false);
			this.panel_ChipCheckFunc.ResumeLayout(false);
			this.panel_ChipCheckFunc.PerformLayout();
			this.panel_ChipButtonFunc.ResumeLayout(false);
			this.groupBox_CmdFunc.ResumeLayout(false);
			this.groupBox_FileFunc.ResumeLayout(false);
			this.toolStrip_ChipTool.ResumeLayout(false);
			this.toolStrip_ChipTool.PerformLayout();
			this.panel_ChipID.ResumeLayout(false);
			this.groupBox_ChipClock.ResumeLayout(false);
			this.groupBox_ChipClock.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar_ChipClock)).EndInit();
			this.groupBox_ChipInterfaceAndPWR.ResumeLayout(false);
			this.groupBox_ChipInterfaceAndPWR.PerformLayout();
			this.groupBox_ChipType.ResumeLayout(false);
			this.groupBox_ChipType.PerformLayout();
			this.tabPage_ChipEdit.ResumeLayout(false);
			this.tabControl_ChipMemery.ResumeLayout(false);
			this.tabPage_Flash.ResumeLayout(false);
			this.tabPage_Eeprom.ResumeLayout(false);
			this.tabPage_ROM.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Harry.LabTools.LabCommPort.CCommPortControl cCommBaseControl_ChipCOMM;
		private System.Windows.Forms.Panel panel_ChipID;
		private System.Windows.Forms.GroupBox groupBox_ChipType;
		private System.Windows.Forms.ComboBox comboBox_ChipType;
		private System.Windows.Forms.TextBox textBox_ChipID;
		private System.Windows.Forms.Label label_ChipID;
		private System.Windows.Forms.GroupBox groupBox_ChipInterfaceAndPWR;
		private System.Windows.Forms.Button button_SetChipInterface;
		private System.Windows.Forms.ComboBox comboBox_ChipInterface;
		private System.Windows.Forms.Button button_ReadChipID;
        //private Harry.LabTools.LabControlPlus.CTabControlEx tabControl_ChipProgram;
        private System.Windows.Forms.TabPage tabPage_ChipFunc;
		private System.Windows.Forms.TabPage tabPage_ChipEdit;
		private System.Windows.Forms.Button button_ReadChipPWR;
		private System.Windows.Forms.Label label_ChipPWRUnite;
		private System.Windows.Forms.TextBox textBox_ChipPWR;
		private System.Windows.Forms.Label label_ChipPWR;
		private System.Windows.Forms.Label label_ChipInterface;
		private System.Windows.Forms.CheckBox checkBox_ChipPWR;
		private System.Windows.Forms.Button button_SetChipPWR;
        //private System.Windows.Forms.TabControl tabControl_ChipMemery;
        private Harry.LabTools.LabControlPlus.CTabControlEx tabControl_ChipMemery;
        private System.Windows.Forms.TabPage tabPage_Flash;
		private System.Windows.Forms.TabPage tabPage_Eeprom;
		private System.Windows.Forms.MenuStrip menuStrip_ChipMenu;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_File;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Cmd;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Edit;
		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_About;
		private System.Windows.Forms.GroupBox groupBox_ChipClock;
		private System.Windows.Forms.Button button_SetChipClock;
		private System.Windows.Forms.TrackBar trackBar_ChipClock;
		private System.Windows.Forms.Label label_ChipClockUnite;
		private System.Windows.Forms.TextBox textBox_ChipClock;
		private Harry.LabTools.LabHexEdit.CHexBox cHexBox_Flash;
		private Harry.LabTools.LabHexEdit.CHexBox cHexBox_Eeprom;
		private System.Windows.Forms.ToolStrip toolStrip_ChipTool;
		private System.Windows.Forms.Panel panel_ChipMsg;
		private System.Windows.Forms.Panel panel_ChipFunc;
		private System.Windows.Forms.Panel panel_ChipCheckFunc;
		private System.Windows.Forms.Panel panel_ChipButtonFunc;
		private Harry.LabTools.LabControlPlus.CRichTextBoxEx cRichTextBoxEx_ChipMsg;
		private System.Windows.Forms.ToolStripLabel toolStripLabel_ChipStateName;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator_ChipStateName;
		private System.Windows.Forms.ToolStripLabel toolStripLabel_ChipState;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator_ChipState;
		private System.Windows.Forms.ToolStripLabel toolStripLabel_ChipTimeName;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator_ChipTimeName;
		private System.Windows.Forms.ToolStripLabel toolStripLabel_ChipTime;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator_VersionName;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator_ChipTime;
		private System.Windows.Forms.ToolStripLabel toolStripLabel_ChipRTCTimerName;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator_ChipRTCTimerName;
		private System.Windows.Forms.ToolStripLabel toolStripLabel_ChipRTCTimer;
		private System.Windows.Forms.Timer timer_ChipRTCTime;
		private System.Windows.Forms.TabPage tabPage_ROM;
		private Harry.LabTools.LabHexEdit.CHexBox cHexBox_ROM;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator_ChipRTCTimer;
		private System.Windows.Forms.ToolStripLabel toolStripLabel_VersionName;
		private System.Windows.Forms.ToolStripLabel toolStripLabel_Version;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator_Version;
		private System.Windows.Forms.GroupBox groupBox_CmdFunc;
		private System.Windows.Forms.GroupBox groupBox_FileFunc;
		private System.Windows.Forms.Button button_SaveEepromFile;
		private System.Windows.Forms.Button button_SaveFlashFile;
		private System.Windows.Forms.Button button_LoadEepromFile;
		private System.Windows.Forms.Button button_LoadFlashFile;
		private System.Windows.Forms.Button button_ChipAuto;
		private System.Windows.Forms.Button button_ReadChipROM;
		private System.Windows.Forms.Button button_WriteChipLock;
		private System.Windows.Forms.Button button_WriteChipFuse;
		private System.Windows.Forms.Button button_CheckChipEeprom;
		private System.Windows.Forms.Button button_WriteChipEeprom;
		private System.Windows.Forms.Button button_ReadChipEeprom;
		private System.Windows.Forms.Button button_CheckChipFlash;
		private System.Windows.Forms.Button button_WriteChipFlash;
		private System.Windows.Forms.Button button_ReadChipFlash;
		private System.Windows.Forms.Button button_ReadIDChip;
		private System.Windows.Forms.Button button_CheckChipEmpty;
		private System.Windows.Forms.Button button_EraseChip;
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar_ChipBar;
		private Harry.LabTools.LabControlPlus.CCheckedListBoxEx cCheckedListBoxEx_FuncMaskStep2;
		private Harry.LabTools.LabControlPlus.CCheckedListBoxEx cCheckedListBoxEx_FuncMaskStep1;
		private System.Windows.Forms.Button button_AutoChip;
		private System.Windows.Forms.Button button_Erase;
		private System.Windows.Forms.Label label_Flash;
		private System.Windows.Forms.Label label_FlashSize;
		private System.Windows.Forms.Label label_EepromSize;
		private System.Windows.Forms.Label label_Eeprom;
        private CMcuFormAVR8Bits.CMcuFormAVR8BitsFuseAndLockControl cMcuFormAVR8BitsFuseAndLockControl_ChipFuse;
        private Harry.LabTools.LabControlPlus.CTabControlEx tabControl_ChipMenu;
        private System.Windows.Forms.ToolTip toolTip_ChipClock;
    }
}