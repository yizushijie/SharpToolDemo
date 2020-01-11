namespace TestAgent.GraphicsLib
{
    partial class FormGraphPaneParamEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGraphPaneParamEdit));
            this.checkBox_isIgnoreInitial = new System.Windows.Forms.CheckBox();
            this.checkBox_isBoundedRanges = new System.Windows.Forms.CheckBox();
            this.groupBox_LineType = new System.Windows.Forms.GroupBox();
            this.radioButton_LineTypeStack = new System.Windows.Forms.RadioButton();
            this.radioButton_LineTypeNormal = new System.Windows.Forms.RadioButton();
            this.checkBox_MarkVisible = new System.Windows.Forms.CheckBox();
            this.groupBox_MarkSet = new System.Windows.Forms.GroupBox();
            this.num_MarkCount = new System.Windows.Forms.NumericUpDown();
            this.checkBox_MarkEnable = new System.Windows.Forms.CheckBox();
            this.label_markcount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.num_TitleGap)).BeginInit();
            this.groupBox_LineType.SuspendLayout();
            this.groupBox_MarkSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_MarkCount)).BeginInit();
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
            // checkBox_isIgnoreInitial
            // 
            resources.ApplyResources(this.checkBox_isIgnoreInitial, "checkBox_isIgnoreInitial");
            this.checkBox_isIgnoreInitial.Name = "checkBox_isIgnoreInitial";
            this.checkBox_isIgnoreInitial.UseVisualStyleBackColor = true;
            // 
            // checkBox_isBoundedRanges
            // 
            resources.ApplyResources(this.checkBox_isBoundedRanges, "checkBox_isBoundedRanges");
            this.checkBox_isBoundedRanges.Name = "checkBox_isBoundedRanges";
            this.checkBox_isBoundedRanges.UseVisualStyleBackColor = true;
            // 
            // groupBox_LineType
            // 
            resources.ApplyResources(this.groupBox_LineType, "groupBox_LineType");
            this.groupBox_LineType.Controls.Add(this.radioButton_LineTypeStack);
            this.groupBox_LineType.Controls.Add(this.radioButton_LineTypeNormal);
            this.groupBox_LineType.Name = "groupBox_LineType";
            this.groupBox_LineType.TabStop = false;
            // 
            // radioButton_LineTypeStack
            // 
            resources.ApplyResources(this.radioButton_LineTypeStack, "radioButton_LineTypeStack");
            this.radioButton_LineTypeStack.Name = "radioButton_LineTypeStack";
            this.radioButton_LineTypeStack.TabStop = true;
            this.radioButton_LineTypeStack.UseVisualStyleBackColor = true;
            // 
            // radioButton_LineTypeNormal
            // 
            resources.ApplyResources(this.radioButton_LineTypeNormal, "radioButton_LineTypeNormal");
            this.radioButton_LineTypeNormal.Name = "radioButton_LineTypeNormal";
            this.radioButton_LineTypeNormal.TabStop = true;
            this.radioButton_LineTypeNormal.UseVisualStyleBackColor = true;
            // 
            // checkBox_MarkVisible
            // 
            resources.ApplyResources(this.checkBox_MarkVisible, "checkBox_MarkVisible");
            this.checkBox_MarkVisible.Name = "checkBox_MarkVisible";
            this.checkBox_MarkVisible.UseVisualStyleBackColor = true;
            // 
            // groupBox_MarkSet
            // 
            resources.ApplyResources(this.groupBox_MarkSet, "groupBox_MarkSet");
            this.groupBox_MarkSet.Controls.Add(this.num_MarkCount);
            this.groupBox_MarkSet.Controls.Add(this.checkBox_MarkEnable);
            this.groupBox_MarkSet.Controls.Add(this.checkBox_MarkVisible);
            this.groupBox_MarkSet.Controls.Add(this.label_markcount);
            this.groupBox_MarkSet.Name = "groupBox_MarkSet";
            this.groupBox_MarkSet.TabStop = false;
            // 
            // num_MarkCount
            // 
            resources.ApplyResources(this.num_MarkCount, "num_MarkCount");
            this.num_MarkCount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.num_MarkCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_MarkCount.Name = "num_MarkCount";
            this.num_MarkCount.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // checkBox_MarkEnable
            // 
            resources.ApplyResources(this.checkBox_MarkEnable, "checkBox_MarkEnable");
            this.checkBox_MarkEnable.Name = "checkBox_MarkEnable";
            this.checkBox_MarkEnable.UseVisualStyleBackColor = true;
            // 
            // label_markcount
            // 
            resources.ApplyResources(this.label_markcount, "label_markcount");
            this.label_markcount.Name = "label_markcount";
            // 
            // FormGraphPaneParamEdit
            // 
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.checkBox_isIgnoreInitial);
            this.Controls.Add(this.checkBox_isBoundedRanges);
            this.Controls.Add(this.groupBox_LineType);
            this.Controls.Add(this.groupBox_MarkSet);
            this.Name = "FormGraphPaneParamEdit";
            this.Controls.SetChildIndex(this.groupBox_MarkSet, 0);
            this.Controls.SetChildIndex(this.groupBox_LineType, 0);
            this.Controls.SetChildIndex(this.checkBox_isBoundedRanges, 0);
            this.Controls.SetChildIndex(this.checkBox_isIgnoreInitial, 0);
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
            this.Controls.SetChildIndex(this.button_OK, 0);
            this.Controls.SetChildIndex(this.button_Cancel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.num_TitleGap)).EndInit();
            this.groupBox_LineType.ResumeLayout(false);
            this.groupBox_MarkSet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.num_MarkCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_isIgnoreInitial;
        private System.Windows.Forms.CheckBox checkBox_isBoundedRanges;
        private System.Windows.Forms.GroupBox groupBox_LineType;
        private System.Windows.Forms.RadioButton radioButton_LineTypeStack;
        private System.Windows.Forms.RadioButton radioButton_LineTypeNormal;
        private System.Windows.Forms.CheckBox checkBox_MarkVisible;
        private System.Windows.Forms.GroupBox groupBox_MarkSet;
        protected System.Windows.Forms.NumericUpDown num_MarkCount;
        protected System.Windows.Forms.Label label_markcount;
        private System.Windows.Forms.CheckBox checkBox_MarkEnable;

    }
}
