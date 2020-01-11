using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TestAgent.GraphicsLib
{

    public partial class FormGraphicsParamEditBase : FormParamEditBase
    {
        #region 变量定义
        #endregion 变量定义

        #region 属性定义
        /// <summary>
        /// 本窗体使用的绘图对象读写属性
        /// </summary>
        public PaneBase UsedPane { get { return (PaneBase)base._usedObj; } set { if (value != null) { base._usedObj = value; } } }
        #endregion 属性定义

        #region 构造函数
        public FormGraphicsParamEditBase(PaneBase pane)
            : base(pane)
        {
            InitializeComponent();
        }

        public FormGraphicsParamEditBase()
            : this(null)
        {
        }
        #endregion 构造函数

        #region 基本虚拟函数
        /// <summary>
        /// 将对象参数显示到窗体
        /// </summary>
        protected override void ObjParamToView()
        {
            if (this.UsedPane != null)
            {
                this.textBox_Title.Text = this.UsedPane.Title.Text;
                this.textBox_Tag.Text = (string)this.UsedPane.Tag;

                this.num_BoardFactor.Value = (decimal)this.UsedPane.Border.InflateFactor;
                this.pictureBox_BoardColor.BackColor = this.UsedPane.Border.Color;
                this.checkBox_isBoardVisible.Checked = this.UsedPane.Border.IsVisible;

                this.num_Margin_Left.Value = (decimal)this.UsedPane.Margin.Left;
                this.num_Margin_Right.Value = (decimal)this.UsedPane.Margin.Right;
                this.num_Margin_Top.Value = (decimal)this.UsedPane.Margin.Top;
                this.num_Margin_Bottom.Value = (decimal)this.UsedPane.Margin.Bottom;

                this.checkBox_isFontScaled.Checked = this.UsedPane.IsFontsScaled;
                this.checkBox_isPenWidthScaled.Checked = this.UsedPane.IsPenWidthScaled;
            }
        }

        /// <summary>
        /// 将窗体的变量回存到对象
        /// </summary>
        protected override void ViewToObjParam()
        {
            if (this.UsedPane != null)
            {
                this.UsedPane.Title.Text = this.textBox_Title.Text;
                this.UsedPane.Tag = this.textBox_Tag.Text;

                this.UsedPane.Border.InflateFactor = (float)this.num_BoardFactor.Value;
                this.UsedPane.Border.Color = this.pictureBox_BoardColor.BackColor;
                this.UsedPane.Border.IsVisible = this.checkBox_isBoardVisible.Checked;

                this.UsedPane.Margin.Left = (float)this.num_Margin_Left.Value;
                this.UsedPane.Margin.Right = (float)this.num_Margin_Right.Value;
                this.UsedPane.Margin.Top = (float)this.num_Margin_Top.Value;
                this.UsedPane.Margin.Bottom = (float)this.num_Margin_Bottom.Value;

                this.UsedPane.IsFontsScaled = this.checkBox_isFontScaled.Checked;
                this.UsedPane.IsPenWidthScaled = this.checkBox_isPenWidthScaled.Checked;
            }
        }
        #endregion 基本虚拟函数

        #region 按钮响应函数

        #endregion 按钮响应函数

        private void pictureBox_BoardColor_Click(object sender, EventArgs e)
        {
            if (this.UsedPane != null)
            {
                this.colorDialog_ParamEdit.Color = this.UsedPane.Border.Color;
            }
            if (this.colorDialog_ParamEdit.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                this.pictureBox_BoardColor.BackColor = this.colorDialog_ParamEdit.Color;
        }
    }
}
