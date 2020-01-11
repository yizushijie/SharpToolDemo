using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace TestAgent.GraphicsLib
{
	/// <summary>
	/// Encapsulates a curve type that is displayed as a line and/or a set of
	/// symbols at each point.
	/// </summary>
	/// 
    [Serializable]
    public class LineItem : CurveItem, ICloneable, ISerializable
    {
        #region 变量定义

        /// <summary>
        /// Private field that stores a reference to the <see cref="Symbol"/>
        /// class defined for this <see cref="LineItem"/>.  Use the public
        /// property <see cref="Symbol"/> to access this value.
        /// </summary>
        protected Symbol _symbol;
        /// <summary>
        /// Private field that stores a reference to the <see cref="Line"/>
        /// class defined for this <see cref="LineItem"/>.  Use the public
        /// property <see cref="Line"/> to access this value.
        /// </summary>
        protected Line _line;

        #endregion

        #region 属性定义

        /// <summary>
        /// Gets or sets the <see cref="Symbol"/> class instance defined
        /// for this <see cref="LineItem"/>.
        /// </summary>
        public Symbol Symbol
        {
            get { return _symbol; }
            set { _symbol = value; }
        }
        /// <summary>
        /// Gets or sets the <see cref="Line"/> class instance defined
        /// for this <see cref="LineItem"/>.
        /// </summary>
        public Line Line
        {
            get { return _line; }
            set { _line = value; }
        }

        /// <summary>
        /// Gets a flag indicating if the Z data range should be included in the axis scaling calculations.
        /// </summary>
        /// <param name="pane">The parent <see cref="GraphPane" /> of this <see cref="CurveItem" />.
        /// </param>
        /// <value>true if the Z data are included, false otherwise</value>
        override internal bool IsZIncluded(GraphPane pane)
        {
            return false;
        }

        /// <summary>
        /// Gets a flag indicating if the X axis is the independent axis for this <see cref="CurveItem" />
        /// </summary>
        /// <param name="pane">The parent <see cref="GraphPane" /> of this <see cref="CurveItem" />.
        /// </param>
        /// <value>true if the X axis is independent, false otherwise</value>
        override internal bool IsXIndependent(GraphPane pane)
        {
            return true;
        }

        #endregion

        #region 构造函数
        /// <summary>
        /// Create a new <see cref="LineItem"/>, specifying only the legend <see cref="CurveItem.Label" />.
        /// </summary>
        /// <param name="label">The _label that will appear in the legend.</param>
        public LineItem(string label)
            : base(label)
        {
            base._objPrefix = "Line Item";
            _symbol = new Symbol();
            _line = new Line();
        }

        /// <summary>
        /// Create a new <see cref="LineItem"/> using the specified properties.
        /// </summary>
        /// <param name="label">The _label that will appear in the legend.</param>
        /// <param name="points">A <see cref="IPointList"/> of double precision value pairs that define
        /// the X and Y values for this curve</param>
        /// <param name="color">A <see cref="Color"/> value that will be applied to
        /// the <see cref="Line"/> and <see cref="Symbol"/> properties.
        /// </param>
        /// <param name="symbolType">A <see cref="SymbolType"/> enum specifying the
        /// type of symbol to use for this <see cref="LineItem"/>.  Use <see cref="SymbolType.None"/>
        /// to hide the symbols.</param>
        /// <param name="lineWidth">The width (in points) to be used for the <see cref="Line"/>.  This
        /// width is scaled based on <see cref="PaneBase.CalcScaleFactor"/>.  Use a value of zero to
        /// hide the line (see <see cref="LineBase.IsVisible"/>).</param>
        public LineItem(string label, IPointList points, Color color, SymbolType symbolType, float lineWidth)
            : base(label, points)
        {
            base._objPrefix = "Line Item";

            _line = new Line(color);
            if (lineWidth == 0)
                _line.IsVisible = false;
            else
                _line.Width = lineWidth;

            _symbol = new Symbol(symbolType, color);
        }

        /// <summary>
        /// Create a new <see cref="LineItem"/> using the specified properties.
        /// </summary>
        /// <param name="label">The _label that will appear in the legend.</param>
        /// <param name="x">An array of double precision values that define
        /// the independent (X axis) values for this curve</param>
        /// <param name="y">An array of double precision values that define
        /// the dependent (Y axis) values for this curve</param>
        /// <param name="color">A <see cref="Color"/> value that will be applied to
        /// the <see cref="Line"/> and <see cref="Symbol"/> properties.
        /// </param>
        /// <param name="symbolType">A <see cref="SymbolType"/> enum specifying the
        /// type of symbol to use for this <see cref="LineItem"/>.  Use <see cref="SymbolType.None"/>
        /// to hide the symbols.</param>
        /// <param name="lineWidth">The width (in points) to be used for the <see cref="Line"/>.  This
        /// width is scaled based on <see cref="PaneBase.CalcScaleFactor"/>.  Use a value of zero to
        /// hide the line (see <see cref="LineBase.IsVisible"/>).</param>
        public LineItem(string label, double[] x, double[] y, Color color, SymbolType symbolType, float lineWidth)
            : this(label, new PointPairList(x, y), color, symbolType, lineWidth)
        {
        }

        /// <summary>
        /// 用给定的Point数组构建本类 <see cref="LineItem"/> .
        /// </summary>
        /// <param name="label">图例中的标识</param>
        /// <param name="points">给定的Point数组</param>
        /// <param name="color">使用的颜色</param>
        /// <param name="symbolType">使用的数据点标记符号</param>
        /// <param name="lineWidth">线宽</param>
        public LineItem(string label, Point[] points, Color color, SymbolType symbolType, float lineWidth)
            : this(label, new PointPairList(points), color, symbolType, lineWidth)
        {
        }

        /// <summary>
        /// 用给定的PointF数组构建本类 <see cref="LineItem"/> .
        /// </summary>
        /// <param name="label">图例中的标识</param>
        /// <param name="points">给定的PointF数组</param>
        /// <param name="color">使用的颜色</param>
        /// <param name="symbolType">使用的数据点标记符号</param>
        /// <param name="lineWidth">线宽</param>
        public LineItem(string label, PointF[] points, Color color, SymbolType symbolType, float lineWidth)
            : this(label, new PointPairList(points), color, symbolType, lineWidth)
        {
        }

        /// <summary>
        /// Create a new <see cref="LineItem"/> using the specified properties.
        /// </summary>
        /// <param name="label">The _label that will appear in the legend.</param>
        /// <param name="points">A <see cref="IPointList"/> of double precision value pairs that define
        /// the X and Y values for this curve</param>
        /// <param name="color">A <see cref="Color"/> value that will be applied to
        /// the <see cref="Line"/> and <see cref="Symbol"/> properties.
        /// </param>
        /// <param name="symbolType">A <see cref="SymbolType"/> enum specifying the
        /// type of symbol to use for this <see cref="LineItem"/>.  Use <see cref="SymbolType.None"/>
        /// to hide the symbols.</param>
        public LineItem(string label, IPointList points, Color color, SymbolType symbolType)
            : this(label, points, color, symbolType, TestAgent.GraphicsLib.LineBase.Default.Width)
        {
        }

        /// <summary>
        /// 用给定的double数组对X，Y数组构新对象 <see cref="LineItem"/> .
        /// </summary>
        /// <param name="label">The _label that will appear in the legend.</param>
        /// <param name="x">An array of double precision values that define
        /// the independent (X axis) values for this curve</param>
        /// <param name="y">An array of double precision values that define
        /// the dependent (Y axis) values for this curve</param>
        /// <param name="color">A <see cref="Color"/> value that will be applied to
        /// the <see cref="Line"/> and <see cref="Symbol"/> properties.
        /// </param>
        /// <param name="symbolType">A <see cref="SymbolType"/> enum specifying the
        /// type of symbol to use for this <see cref="LineItem"/>.  Use <see cref="SymbolType.None"/>
        /// to hide the symbols.</param>
        public LineItem(string label, double[] x, double[] y, Color color, SymbolType symbolType)
            : this(label, new PointPairList(x, y), color, symbolType, TestAgent.GraphicsLib.LineBase.Default.Width)
        {
        }

        /// <summary>
        /// 用给定的Point数组构建本类 <see cref="LineItem"/> .
        /// </summary>
        /// <param name="label">图例中的标识</param>
        /// <param name="points">给定的Point数组</param>
        /// <param name="color">使用的颜色</param>
        /// <param name="symbolType">使用的数据点标记符号</param>
        public LineItem(string label, Point[] points, Color color, SymbolType symbolType)
            : this(label, new PointPairList(points), color, symbolType, TestAgent.GraphicsLib.LineBase.Default.Width)
        {
        }

        /// <summary>
        /// 用给定的PointF数组构建本类 <see cref="LineItem"/> .
        /// </summary>
        /// <param name="label">图例中的标识</param>
        /// <param name="points">给定的PointF数组</param>
        /// <param name="color">使用的颜色</param>
        /// <param name="symbolType">使用的数据点标记符号</param>
        public LineItem(string label, PointF[] points, Color color, SymbolType symbolType)
            : this(label, new PointPairList(points), color, symbolType, TestAgent.GraphicsLib.LineBase.Default.Width)
        {
        }

        /// <summary>
        /// The Copy Constructor
        /// </summary>
        /// <param name="rhs">The <see cref="LineItem"/> object from which to copy</param>
        public LineItem(LineItem rhs)
            : base(rhs)
        {
            _symbol = new Symbol(rhs.Symbol);
            _line = new Line(rhs.Line);
        }

        /// <summary>
        /// Implement the <see cref="ICloneable" /> interface in a typesafe manner by just
        /// calling the typed version of <see cref="Clone" />
        /// </summary>
        /// <returns>A deep copy of this object</returns>
        object ICloneable.Clone()
        {
            return this.Clone();
        }

        /// <summary>
        /// Typesafe, deep-copy clone method.
        /// </summary>
        /// <returns>A new, independent copy of this class</returns>
        public LineItem Clone()
        {
            return new LineItem(this);
        }

        #endregion 构造函数

        #region 串行化函数定义
        /// <summary>
        /// Current schema value that defines the version of the serialized file
        /// </summary>
        public const int schema2 = 10;

        /// <summary>
        /// Constructor for deserializing objects
        /// </summary>
        /// <param name="info">A <see cref="SerializationInfo"/> instance that defines the serialized data
        /// </param>
        /// <param name="context">A <see cref="StreamingContext"/> instance that contains the serialized data
        /// </param>
        protected LineItem(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            // The schema value is just a file version parameter.  You can use it to make future versions
            // backwards compatible as new member variables are added to classes
            int sch = info.GetInt32("schema2");

            _symbol = (Symbol)info.GetValue("symbol", typeof(Symbol));
            _line = (Line)info.GetValue("line", typeof(Line));
        }
        /// <summary>
        /// Populates a <see cref="SerializationInfo"/> instance with the data needed to serialize the target object
        /// </summary>
        /// <param name="info">A <see cref="SerializationInfo"/> instance that defines the serialized data</param>
        /// <param name="context">A <see cref="StreamingContext"/> instance that contains the serialized data</param>
        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("schema2", schema2);
            info.AddValue("symbol", _symbol);
            info.AddValue("line", _line);
        }
        #endregion

        #region 方法定义
        /// <summary>
        /// 用给定的X，Y数组更新线性图表
        /// </summary>
        /// <param name="x">X轴值数组</param>
        /// <param name="y">Y轴值数组</param>
        public void UpdateWith(double[] x, double[] y)
        {
            PointPairList list = new PointPairList(x, y);
            base.UpdatePointsWith(list);
        }

        /// <summary>
        /// 用给定的Point数组更新线性图表
        /// </summary>
        /// <param name="points">Point数组</param>
        public void UpdateWith(Point[] points)
        {
            PointPairList list = new PointPairList(points);
            base.UpdatePointsWith(list);
        }

        /// <summary>
        /// 用给定的PointF数组更新线性图表
        /// </summary>
        /// <param name="points">PointF数组</param>
        public void UpdateWith(PointF[] points)
        {
            PointPairList list = new PointPairList(points);
            base.UpdatePointsWith(list);
        }

        /// <summary>
        /// Do all rendering associated with this <see cref="LineItem"/> to the specified
        /// <see cref="Graphics"/> device.  This method is normally only
        /// called by the Draw method of the parent <see cref="CurveList"/>
        /// collection object.
        /// </summary>
        /// <param name="g">
        /// A graphic device object to be drawn into.  This is normally e.Graphics from the
        /// PaintEventArgs argument to the Paint() method.
        /// </param>
        /// <param name="pane">
        /// A reference to the <see cref="GraphPane"/> object that is the parent or
        /// owner of this object.
        /// </param>
        /// <param name="pos">The ordinal position of the current <see cref="Bar"/>
        /// curve.</param>
        /// <param name="scaleFactor">
        /// The scaling factor to be used for rendering objects.  This is calculated and
        /// passed down by the parent <see cref="GraphPane"/> object using the
        /// <see cref="PaneBase.CalcScaleFactor"/> method, and is used to proportionally adjust
        /// font sizes, etc. according to the actual size of the graph.
        /// </param>
        override public void Draw(Graphics g, GraphPane pane, int pos, float scaleFactor)
        {
            if (_isVisible)
            {
                Line.Draw(g, pane, this, scaleFactor);

                Symbol.Draw(g, pane, this, scaleFactor, IsSelected);
            }
        }

        /// <summary>
        /// 绘制图例Draw a legend key entry for this <see cref="LineItem"/> at the specified location
        /// </summary>
        /// <param name="g">
        /// A graphic device object to be drawn into.  This is normally e.Graphics from the
        /// PaintEventArgs argument to the Paint() method.
        /// </param>
        /// <param name="pane">
        /// A reference to the <see cref="GraphPane"/> object that is the parent or
        /// owner of this object.
        /// </param>
        /// <param name="rect">The <see cref="RectangleF"/> struct that specifies the
        /// location for the legend key</param>
        /// <param name="scaleFactor">
        /// The scaling factor to be used for rendering objects.  This is calculated and
        /// passed down by the parent <see cref="GraphPane"/> object using the
        /// <see cref="PaneBase.CalcScaleFactor"/> method, and is used to proportionally adjust
        /// font sizes, etc. according to the actual size of the graph.
        /// </param>
        override public void DrawLegendKey(Graphics g, GraphPane pane, RectangleF rect, float scaleFactor)
        {
            // Draw a sample curve to the left of the label text
            int xMid = (int)(rect.Left + rect.Width / 2.0F);
            int yMid = (int)(rect.Top + rect.Height / 2.0F);

            _line.Fill.Draw(g, rect);

            _line.DrawSegment(g, pane, rect.Left, yMid, rect.Right, yMid, scaleFactor);

            // Draw a sample symbol to the left of the label text				
            _symbol.DrawSymbol(g, pane, xMid, yMid, scaleFactor, false, null);

        }

        /// <summary>
        /// Determine the coords for the rectangle associated with a specified point for 
        /// this <see cref="CurveItem" />
        /// </summary>
        /// <param name="pane">The <see cref="GraphPane" /> to which this curve belongs</param>
        /// <param name="i">The index of the point of interest</param>
        /// <param name="coords">A list of coordinates that represents the "rect" for
        /// this point (used in an html AREA tag)</param>
        /// <returns>true if it's a valid point, false otherwise</returns>
        override public bool GetCoords(GraphPane pane, int i, out string coords)
        {
            coords = string.Empty;

            if (i < 0 || i >= _points.Count)
                return false;

            PointPair pt = _points[i];
            if (pt.IsInvalid)
                return false;

            double x, y, z;
            ValueHandler valueHandler = new ValueHandler(pane, false);
            valueHandler.GetValues(this, i, out x, out z, out y);

            Axis yAxis = GetYAxis(pane);
            Axis xAxis = GetXAxis(pane);

            PointF pixPt = new PointF(xAxis.Scale.Transform(_isOverrideOrdinal, i, x),
                            yAxis.Scale.Transform(_isOverrideOrdinal, i, y));

            if (!pane.Chart.Rect.Contains(pixPt))
                return false;

            float halfSize = _symbol.Size * pane.CalcScaleFactor();

            coords = String.Format("{0:f0},{1:f0},{2:f0},{3:f0}",
                    pixPt.X - halfSize, pixPt.Y - halfSize,
                    pixPt.X + halfSize, pixPt.Y + halfSize);

            return true;
        }

        #endregion
    }
}
