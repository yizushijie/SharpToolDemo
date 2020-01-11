using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TestAgent.GraphicsLib
{
    public partial class FormGraphPaneParamEdit : TestAgent.GraphicsLib.FormGraphicsParamEditBase
    {

        public GraphPane UsedGraphPane
        { get { return (GraphPane)base._usedObj; } set { base._usedObj = value; } }

        public FormGraphPaneParamEdit()
            : this(null)
        {
        }

        public FormGraphPaneParamEdit(GraphPane usedPane)
            : base(usedPane)
        {
            InitializeComponent();
        }

        protected override void ViewToObjParam()
        {
            base.ViewToObjParam();
            this.UsedGraphPane.IsBoundedRanges = this.checkBox_isBoundedRanges.Checked;
            this.UsedGraphPane.IsIgnoreInitial = this.checkBox_isIgnoreInitial.Checked;
            if (this.radioButton_LineTypeNormal.Checked)
                this.UsedGraphPane.LineType = LineType.Normal;
            else
                this.UsedGraphPane.LineType = LineType.Stack;
            this.UsedGraphPane.MarkCount = (int)this.num_MarkCount.Value;
            this.UsedGraphPane.EnableMark = this.checkBox_MarkEnable.Checked;
            this.UsedGraphPane.ShowMark = this.checkBox_MarkVisible.Checked;
        }

        protected override void ObjParamToView()
        {
            base.ObjParamToView();
            this.checkBox_isBoundedRanges.Checked = this.UsedGraphPane.IsBoundedRanges;
            this.checkBox_isIgnoreInitial.Checked = this.UsedGraphPane.IsIgnoreInitial;
            this.radioButton_LineTypeNormal.Checked = (this.UsedGraphPane.LineType == LineType.Normal);
            this.radioButton_LineTypeStack.Checked = (this.UsedGraphPane.LineType == LineType.Stack);
            this.num_MarkCount.Value = (decimal)this.UsedGraphPane.MarkCount;
            this.checkBox_MarkEnable.Checked = this.UsedGraphPane.EnableMark;
            this.checkBox_MarkVisible.Checked = this.UsedGraphPane.ShowMark;
        }
    }
}
