namespace TestAgent.GraphicsLib
{
    partial class FormMasterPaneParamEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMasterPaneParamEdit));
            this.num_InnerPaneGap = new System.Windows.Forms.NumericUpDown();
            this.label_innerPaneGap = new System.Windows.Forms.Label();
            this.label_paneLayout = new System.Windows.Forms.Label();
            this.comboBox_PaneLayoutType = new System.Windows.Forms.ComboBox();
            this.checkBox_isCommScaleFactor = new System.Windows.Forms.CheckBox();
            this.checkBox_isUniformLegend = new System.Windows.Forms.CheckBox();
            this.checkBox_isAntiAlias = new System.Windows.Forms.CheckBox();
            this.num_MouseSelectedSen = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.num_TitleGap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_InnerPaneGap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_MouseSelectedSen)).BeginInit();
            this.SuspendLayout();
            // 
            // label_Title
            // 
            resources.ApplyResources(this.label_Title, "label_Title");
            // 
            // textBox_Title
            // 
            resources.ApplyResources(this.textBox_Title, "textBox_Title");
            // 
            // groupBox_margin
            // 
            resources.ApplyResources(this.groupBox_margin, "groupBox_margin");
            // 
            // checkBox_isFontScaled
            // 
            resources.ApplyResources(this.checkBox_isFontScaled, "checkBox_isFontScaled");
            // 
            // checkBox_isPenWidthScaled
            // 
            resources.ApplyResources(this.checkBox_isPenWidthScaled, "checkBox_isPenWidthScaled");
            // 
            // label_Tag
            // 
            resources.ApplyResources(this.label_Tag, "label_Tag");
            // 
            // textBox_Tag
            // 
            resources.ApplyResources(this.textBox_Tag, "textBox_Tag");
            // 
            // label_titleGap
            // 
            resources.ApplyResources(this.label_titleGap, "label_titleGap");
            // 
            // num_TitleGap
            // 
            resources.ApplyResources(this.num_TitleGap, "num_TitleGap");
            // 
            // groupBox_BoardParam
            // 
            resources.ApplyResources(this.groupBox_BoardParam, "groupBox_BoardParam");
            // 
            // button_Cancel
            // 
            resources.ApplyResources(this.button_Cancel, "button_Cancel");
            // 
            // button_OK
            // 
            resources.ApplyResources(this.button_OK, "button_OK");
            // 
            // num_InnerPaneGap
            // 
            resources.ApplyResources(this.num_InnerPaneGap, "num_InnerPaneGap");
            this.num_InnerPaneGap.DecimalPlaces = 1;
            this.num_InnerPaneGap.Name = "num_InnerPaneGap";
            this.num_InnerPaneGap.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // label_innerPaneGap
            // 
            resources.ApplyResources(this.label_innerPaneGap, "label_innerPaneGap");
            this.label_innerPaneGap.Name = "label_innerPaneGap";
            // 
            // label_paneLayout
            // 
            resources.ApplyResources(this.label_paneLayout, "label_paneLayout");
            this.label_paneLayout.Name = "label_paneLayout";
            // 
            // comboBox_PaneLayoutType
            // 
            resources.ApplyResources(this.comboBox_PaneLayoutType, "comboBox_PaneLayoutType");
            this.comboBox_PaneLayoutType.FormattingEnabled = true;
            this.comboBox_PaneLayoutType.Name = "comboBox_PaneLayoutType";
            // 
            // checkBox_isCommScaleFactor
            // 
            resources.ApplyResources(this.checkBox_isCommScaleFactor, "checkBox_isCommScaleFactor");
            this.checkBox_isCommScaleFactor.Name = "checkBox_isCommScaleFactor";
            this.checkBox_isCommScaleFactor.UseVisualStyleBackColor = true;
            // 
            // checkBox_isUniformLegend
            // 
            resources.ApplyResources(this.checkBox_isUniformLegend, "checkBox_isUniformLegend");
            this.checkBox_isUniformLegend.Name = "checkBox_isUniformLegend";
            this.checkBox_isUniformLegend.UseVisualStyleBackColor = true;
            // 
            // checkBox_isAntiAlias
            // 
            resources.ApplyResources(this.checkBox_isAntiAlias, "checkBox_isAntiAlias");
            this.checkBox_isAntiAlias.Name = "checkBox_isAntiAlias";
            this.checkBox_isAntiAlias.UseVisualStyleBackColor = true;
            // 
            // num_MouseSelectedSen
            // 
            resources.ApplyResources(this.num_MouseSelectedSen, "num_MouseSelectedSen");
            this.num_MouseSelectedSen.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.num_MouseSelectedSen.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.num_MouseSelectedSen.Name = "num_MouseSelectedSen";
            this.num_MouseSelectedSen.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // FormMasterPaneParamEdit
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.num_MouseSelectedSen);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox_isAntiAlias);
            this.Controls.Add(this.checkBox_isUniformLegend);
            this.Controls.Add(this.checkBox_isCommScaleFactor);
            this.Controls.Add(this.comboBox_PaneLayoutType);
            this.Controls.Add(this.num_InnerPaneGap);
            this.Controls.Add(this.label_paneLayout);
            this.Controls.Add(this.label_innerPaneGap);
            this.Name = "FormMasterPaneParamEdit";
            this.Controls.SetChildIndex(this.button_OK, 0);
            this.Controls.SetChildIndex(this.button_Cancel, 0);
            this.Controls.SetChildIndex(this.label_titleGap, 0);
            this.Controls.SetChildIndex(this.label_Title, 0);
            this.Controls.SetChildIndex(this.label_Tag, 0);
            this.Controls.SetChildIndex(this.textBox_Title, 0);
            this.Controls.SetChildIndex(this.textBox_Tag, 0);
            this.Controls.SetChildIndex(this.num_TitleGap, 0);
            this.Controls.SetChildIndex(this.groupBox_margin, 0);
            this.Controls.SetChildIndex(this.checkBox_isFontScaled, 0);
            this.Controls.SetChildIndex(this.checkBox_isPenWidthScaled, 0);
            this.Controls.SetChildIndex(this.groupBox_BoardParam, 0);
            this.Controls.SetChildIndex(this.label_innerPaneGap, 0);
            this.Controls.SetChildIndex(this.label_paneLayout, 0);
            this.Controls.SetChildIndex(this.num_InnerPaneGap, 0);
            this.Controls.SetChildIndex(this.comboBox_PaneLayoutType, 0);
            this.Controls.SetChildIndex(this.checkBox_isCommScaleFactor, 0);
            this.Controls.SetChildIndex(this.checkBox_isUniformLegend, 0);
            this.Controls.SetChildIndex(this.checkBox_isAntiAlias, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.num_MouseSelectedSen, 0);
            ((System.ComponentModel.ISupportInitialize)(this.num_TitleGap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_InnerPaneGap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_MouseSelectedSen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.NumericUpDown num_InnerPaneGap;
        protected System.Windows.Forms.Label label_innerPaneGap;
        protected System.Windows.Forms.Label label_paneLayout;
        private System.Windows.Forms.ComboBox comboBox_PaneLayoutType;
        protected System.Windows.Forms.CheckBox checkBox_isCommScaleFactor;
        protected System.Windows.Forms.CheckBox checkBox_isUniformLegend;
        protected System.Windows.Forms.CheckBox checkBox_isAntiAlias;
        private System.Windows.Forms.NumericUpDown num_MouseSelectedSen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
    }
}
