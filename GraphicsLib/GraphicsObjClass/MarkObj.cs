using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace TestAgent.GraphicsLib
{
    public class MarkObj : LineObj, ICloneable, ISerializable
    {
        #region 变量定义
        /// <summary>
        /// 目标曲线
        /// </summary>
        private CurveItem _targetCurve = null;
        /// <summary>
        /// 当前指向的数据点序
        /// </summary>
        private int _dataIndex = 0;
        #endregion 变量定义

        #region 属性定义
        /// <summary>
        /// 目标曲线读写属性
        /// </summary>
        public CurveItem TargetCurve { get { return this._targetCurve; } set { this._targetCurve = value; } }
        /// <summary>
        /// 指向的数据点序号
        /// </summary>
        public int DataIndex { get { return this._dataIndex; } set { this._dataIndex = value; } }
        #endregion 属性定义

        #region 构造函数

        /// <summary>
        /// 根据给定的对象，创建新对象
        /// </summary>
        /// <param name="obj"></param>
        public MarkObj(MarkObj obj)
            : base()
        {
            base._objPrefix = "Mark";

            if (obj != null)
            {
                this._targetCurve = obj._targetCurve;
                this._dataIndex = obj._dataIndex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public MarkObj()
            : this(null)
        {
        }
        #endregion 构造函数

        #region 函数定义

        /// <summary>
		/// 在给定的<see cref="Graphics"/> 上绘制 本对象.
		/// </summary>
		/// <remarks>
		/// 通常情况下，此方法只由父类集合<see cref="GraphObjList"/>的Darw方法调用
		/// </remarks>
		/// <param name="g">
		/// 被绘制的设备，通常是从Paint()方法的参数中获得
		/// </param>
		/// <param name="pane">
		/// 父类 <see cref="PaneBase"/> 此对象的引用
		/// </param>
		/// <param name="scaleFactor">
		/// 绘制对象的比例尺，由父类的<see cref="GraphPane"/>对象
        /// 在<see cref="PaneBase.CalcScaleFactor"/>方法计算中使用
        /// 用于根据图像大小，调整字体等的尺寸
		/// </param>
        public override void Draw(Graphics g, PaneBase pane, float scaleFactor)
        {
            PointF point = this.Location.Transform(pane);
            RectangleF rect = this.Location.TransformRect(pane);
            
            using (Pen pen = base._line.GetPen(pane, scaleFactor))
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                g.DrawLine(pen, point.X, ((GraphPane) pane).Chart.Rect.X, point.X, ((GraphPane) pane).Chart.Rect.Bottom);
                g.DrawLine(pen, ((GraphPane) pane).Chart.Rect.Left, point.Y, ((GraphPane) pane).Chart.Rect.Right, point.Y);
            }
        }

        public override void GetCoords(PaneBase pane, Graphics g, float scaleFactor, out string shape, out string coords)
        {
            base.GetCoords(pane, g, scaleFactor, out shape, out coords);
        }

        public override bool PointInBox(PointF pt, PaneBase pane, Graphics g, float scaleFactor)
        {
            return base.PointInBox(pt, pane, g, scaleFactor);
        }
        #endregion 函数定义

        #region ICloneable 成员

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        /// <summary>
        /// Typesafe, deep-copy clone method.
        /// </summary>
        /// <returns>A new, independent copy of this class</returns>
        public new MarkObj Clone()
        {
            return new MarkObj(this);
        }
        #endregion ICloneable 成员

        #region ISerializable 成员

        /// <summary>
        /// Current schema value that defines the version of the serialized file
        /// </summary>
        public const int schema3 = 10;

        /// <summary>
		/// Constructor for deserializing objects
		/// </summary>
		/// <param name="info">A "SerializationInfo" instance that defines the serialized data
		/// </param>
		/// <param name="context">A <see cref="StreamingContext"/> instance that contains the serialized data
		/// </param>
        protected MarkObj(SerializationInfo info, StreamingContext context)
			: base( info, context )
		{
			// The schema value is just a file version parameter.  You can use it to make future versions
			// backwards compatible as new member variables are added to classes
			int sch = info.GetInt32( "schema3" );

		}

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("schema3", schema2);
        }
        #endregion ISerializable 成员
    }
}
