using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TestAgent.GraphicsLib
{

    public partial class FormExample : Form
    {

        #region 变量定义

        private MasterPane _masterPane;
        #endregion

        #region 属性定义

        public GraphPane GraphPane
        {
            get
            {
                //Just return the first GraphPane in the list
                lock (this)
                {
                    if (_masterPane != null && _masterPane.PaneList.Count > 0)
                        return _masterPane[0];
                    else
                        return null;
                }
            }
            set
            {
                lock (this)
                {
                    //Clear the list, and replace it with the specified Graphpane
                    if (_masterPane != null)
                    {
                        _masterPane.PaneList.Clear();
                        _masterPane.Add(value);
                    }
                }
            }
        }

        public MasterPane MasterPane
        {
            get { lock (this) return _masterPane; }
            set { lock (this) _masterPane = value; }
        }
        #endregion

        #region 构造函数

        public FormExample()
        {
            InitializeComponent();

            this.Resize += new System.EventHandler(this.formResize);
            //Use double-buffering for flicker-free updating:
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint
                 | ControlStyles.DoubleBuffer | ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            Rectangle rect = new Rectangle(0, 0, this.Size.Width - 15, this.Size.Height - 30);
            _masterPane = new MasterPane("", rect);
            _masterPane.Margin.All = 0;
            _masterPane.Title.IsVisible = false;
            _masterPane.InnerPaneGap = 10;// 设置两个图像之间的间距
            _masterPane.PaneLayoutType = PaneLayout.SingleColumn;   // 设置多个图的排列方式

            string titleStr = "Title";
            string xStr = "X Axis";
            string yStr = "Y Axis";

            // 第一个
            rect = new Rectangle(0, 0, this.Size.Width - 15, (this.Size.Height - 60) / 2);
            GraphPane graphPane = new GraphPane(rect, titleStr, xStr, yStr);
            using (Graphics g = this.CreateGraphics())
            {
                graphPane.AxisChange(g);
            }
            _masterPane.Add(graphPane);

            // 第二个
            rect = new Rectangle(0, (this.Size.Height - 60) / 2, this.Size.Width - 15, (this.Size.Height - 60) / 2);
            GraphPane graphPane2 = new GraphPane(rect, titleStr, xStr, yStr);
            using (Graphics g = this.CreateGraphics())
            {
                graphPane2.AxisChange(g);
            }
            _masterPane.Add(graphPane2);

        }
        #endregion

        #region 方法定义

        // Call this method from the Form_Load method
        public void CreateChartComb()
        {
            GraphPane myPane = this.GraphPane;

            // Set the titles and axis labels
            myPane.Title.Text = "Wacky Widget Company\nProduction Report";
            myPane.XAxis.Title.Text = "Time, Days\n(Since Plant Construction Startup)";
            myPane.YAxis.Title.Text = "Widget Production\n(units/hour)";

            LineItem curve;

            // Set up curve "Larry"
            double[] x = { 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000 };
            double[] y = { 20, 10, 50, 25, 35, 75, 94, 40, 33, 50 };
            // Use green, with circle symbols
            curve = myPane.AddCurve("Larry", x, y, Color.Green, SymbolType.Circle);
            curve.Line.Width = 1.5F;
            // Fill the area under the curve with a white-green gradient
            curve.Line.Fill = new Fill(Color.White, Color.FromArgb(60, 190, 50), 90F);
            // Make it a smooth line
            curve.Line.IsSmooth = true;
            curve.Line.SmoothTension = 0.6F;
            // Fill the symbols with white
            curve.Symbol.Fill = new Fill(Color.White);
            curve.Symbol.Size = 10;

            // Second curve is "moe"
            double[] x3 = { 150, 250, 400, 520, 780, 940 };
            double[] y3 = { 5.2, 49.0, 33.8, 88.57, 99.9, 36.8 };
            // Use a red color with triangle symbols
            curve = myPane.AddCurve("Moe", x3, y3, Color.FromArgb(200, 55, 135), SymbolType.Triangle);
            curve.Line.Width = 1.5F;
            // Fill the area under the curve with semi-transparent pink using the alpha value
            curve.Line.Fill = new Fill(Color.White, Color.FromArgb(160, 230, 145, 205), 90F);
            // Fill the symbols with white
            curve.Symbol.Fill = new Fill(Color.White);
            curve.Symbol.Size = 10;

            // Third Curve is a bar, called "Wheezy"
            double[] x4 = { 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000 };
            double[] y4 = { 30, 45, 53, 60, 75, 83, 84, 79, 71, 57 };

            BarItem bar = myPane.AddBar("Wheezy", x4, y4, Color.SteelBlue);
            // Fill the bars with a RosyBrown-White-RosyBrown gradient
            bar.Bar.Fill = new Fill(Color.RosyBrown, Color.White, Color.RosyBrown);

            // Fourth curve is a bar
            double[] x2 = { 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000 };
            double[] y2 = { 10, 15, 17, 20, 25, 27, 29, 26, 24, 18 };
            bar = myPane.AddBar("Curly", x2, y2, Color.RoyalBlue);
            // Fill the bars with a RoyalBlue-White-RoyalBlue gradient
            bar.Bar.Fill = new Fill(Color.RoyalBlue, Color.White, Color.RoyalBlue);

            // Fill the pane background with a gradient
            myPane.Fill = new Fill(Color.WhiteSmoke, Color.Lavender, 0F);
            // Fill the axis background with a gradient
            myPane.Chart.Fill = new Fill(Color.FromArgb(255, 255, 245),
                     Color.FromArgb(255, 255, 190), 90F);


            // Make each cluster 100 user scale units wide.  This is needed because the X Axis
            // type is Linear rather than Text or Ordinal
            myPane.BarSettings.ClusterScaleWidth = 100;
            // 堆叠柱状图 Bars are stacked
            myPane.BarSettings.Type = BarType.Stack;

            // 显示X轴Y轴栅格
            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.MajorGrid.IsVisible = true;

            // 设置X和Y轴的最大值,最小值
            //myPane.XAxis.Scale.Max = 1400;
            //myPane.YAxis.Scale.Max = 120;
            //myPane.XAxis.Scale.Min = -100;

            // 加入文本标识
            TextObj text = new TextObj("First Prod\n21-Oct-93", 175F, 80.0F);
            // Align the text such that the Bottom-Center is at (175, 80) in user scale coordinates
            text.Location.AlignH = AlignH.Center;
            text.Location.AlignV = AlignV.Bottom;
            text.FontSpec.Fill = new Fill(Color.White, Color.PowderBlue, 45F);
            text.FontSpec.StringAlignment = StringAlignment.Near;
            myPane.GraphObjList.Add(text);

            // 为上面的文本加箭头
            ArrowObj arrow = new ArrowObj(Color.Black, 12F, 175F, 77F, 100F, 45F);
            arrow.Location.CoordinateFrame = CoordType.AxisXYScale;
            myPane.GraphObjList.Add(arrow);

            // 再加一个文本
            text = new TextObj("Upgrade", 700F, 50.0F);
            // 旋转90度
            text.FontSpec.Angle = 90;
            // 修改对齐方式 Align the text such that the Right-Center is at (700, 50) in user scale coordinates
            text.Location.AlignH = AlignH.Right;
            text.Location.AlignV = AlignV.Center;
            // 去掉文本框的填充和外框
            text.FontSpec.Fill.IsVisible = false;
            text.FontSpec.Border.IsVisible = false;
            myPane.GraphObjList.Add(text);

            // 再为上面的文本加入一个箭头
            arrow = new ArrowObj(Color.Black, 15, 700, 53, 700, 80);
            arrow.Location.CoordinateFrame = CoordType.AxisXYScale;
            //arrow.PenWidth = 2.0F;
            myPane.GraphObjList.Add(arrow);

            // 添加文本
            text = new TextObj("内部资料", 0.85F, -0.03F);
            // 使用 ChartFraction coordinates，以便文本和图形矩形坐标相关
            text.Location.CoordinateFrame = CoordType.ChartFraction;
            // 旋转15度
            text.FontSpec.Angle = 15.0F;
            // 设置文本特性
            text.FontSpec.FontColor = Color.Red;
            text.FontSpec.IsBold = true;
            text.FontSpec.Size = 16;
            // 去除填充和外框显示
            text.FontSpec.Border.IsVisible = false;
            text.FontSpec.Fill.IsVisible = false;
            // 设置对齐方式
            text.Location.AlignH = AlignH.Left;
            text.Location.AlignV = AlignV.Bottom;
            myPane.GraphObjList.Add(text);

            // 增加 BoxObj 在数据上部显示一个颜色条
            BoxObj box = new BoxObj(0, 110, 1200, 10,
                  Color.Empty, Color.FromArgb(225, 245, 225));
            box.Location.CoordinateFrame = CoordType.AxisXYScale;
            // 对齐到  left-top of the box to (0, 110)
            box.Location.AlignH = AlignH.Left;
            box.Location.AlignV = AlignV.Top;
            // 设置Z方向的次序 place the box behind the axis items, so the grid is drawn on top of it
            box.ZOrder = ZOrder.F_BehindGrid;
            myPane.GraphObjList.Add(box);

            // Add some text inside the above box to indicate "Peak Range"
            TextObj myText = new TextObj("Peak Range", 1170, 105);
            myText.Location.CoordinateFrame = CoordType.AxisXYScale;
            myText.Location.AlignH = AlignH.Right;
            myText.Location.AlignV = AlignV.Center;
            myText.FontSpec.IsItalic = true;
            myText.FontSpec.IsBold = false;
            myText.FontSpec.Fill.IsVisible = false;
            myText.FontSpec.Border.IsVisible = false;
            myPane.GraphObjList.Add(myText);

            // Calculate the Axis Scale Ranges
            this.AxisChange();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            lock (this)
            {
                if (_masterPane == null)
                    return;
                base.OnPaint(e);

                try { _masterPane.Draw(e.Graphics); }
                catch { }
            }
        }

        protected void formResize(object sender, EventArgs e)
        {
            lock (this)
            {
                if (_masterPane == null)
                    return;
                //  Size newSize = this.ClientSize;

                using (Graphics g = this.CreateGraphics())
                {
                    //_masterPane.ReSize(g, new RectangleF(0, 0, newSize.Width-10, newSize.Height-10));
                    _masterPane.ReSize(g, this.ClientRectangle);
                }
                this.Invalidate();
            }
        }

        public virtual void AxisChange()
        {
            lock (this)
            {
                if (_masterPane == null)
                    return;
                using (Graphics g = this.CreateGraphics())
                {
                    _masterPane.AxisChange(g);
                }

            }
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            this.CreateChartComb();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._masterPane.ShowParamEditDialog();
        }

    }
}