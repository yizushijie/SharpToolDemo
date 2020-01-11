using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TestAgent.GraphicsLib
{
    public partial class FormMasterPaneParamEdit : TestAgent.GraphicsLib.FormGraphicsParamEditBase
    {
        public FormMasterPaneParamEdit(MasterPane pane)
        {
            base.UsedPane = pane;
            InitializeComponent();
            this.comboBox_PaneLayoutType.Items.AddRange(Enum.GetNames(typeof(PaneLayout)));
        }

        protected override void ViewToObjParam()
        {
            base.ViewToObjParam();
            if (base.UsedPane != null)
            {
                ((MasterPane)base.UsedPane).InnerPaneGap = (float)this.num_InnerPaneGap.Value;
                ((MasterPane)base.UsedPane).PaneLayoutType = (PaneLayout)Enum.Parse(typeof(PaneLayout), this.comboBox_PaneLayoutType.Text);
                ((MasterPane)base.UsedPane).IsCommonScaleFactor = this.checkBox_isCommScaleFactor.Checked;
                ((MasterPane)base.UsedPane).IsUniformLegendEntries = this.checkBox_isUniformLegend.Checked;
                ((MasterPane)base.UsedPane).IsAntiAlias = this.checkBox_isAntiAlias.Checked;

                //if (((MasterPane)base._usedPane).PaneList.Count > 0)
                //{
                //    double x, y;
                //    ((MasterPane)base._usedPane)[0].ReverseTransform(
                //        new PointF((float)this.num_MouseSelectedSen.Value, (float)this.num_MouseSelectedSen.Value), out x, out y);
                //    GraphPane.Default.NearestTol = x;
                //}
            }
        }
        protected override void ObjParamToView()
        {
            base.ObjParamToView();
            if (base.UsedPane != null)
            {
                this.num_InnerPaneGap.Value = (decimal)((MasterPane)base.UsedPane).InnerPaneGap;
                this.comboBox_PaneLayoutType.Text = ((MasterPane)base.UsedPane).PaneLayoutType.ToString();
                this.checkBox_isCommScaleFactor.Checked = ((MasterPane)base.UsedPane).IsCommonScaleFactor;
                this.checkBox_isUniformLegend.Checked = ((MasterPane)base.UsedPane).IsUniformLegendEntries;
                this.checkBox_isAntiAlias.Checked = ((MasterPane)base.UsedPane).IsAntiAlias;
                //if (((MasterPane)base._usedPane).PaneList.Count > 0)
                //{
                //    PointF point = ((MasterPane)base._usedPane)[0].GeneralTransform(GraphPane.Default.NearestTol, GraphPane.Default.NearestTol,CoordType.AxisXYScale);
                //    if (point.X > (float)this.num_MouseSelectedSen.Maximum)
                //        this.num_MouseSelectedSen.Value = this.num_MouseSelectedSen.Maximum;
                //    else
                //        this.num_MouseSelectedSen.Value = (decimal)point.X;
                //}
            }
        }
    }
}
