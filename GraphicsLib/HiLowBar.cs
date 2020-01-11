using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace TestAgent.GraphicsLib
{
    /// <summary>
    /// This class handles the drawing of the curve <see cref="HiLowBar"/> objects.
    /// The Hi-Low Bars are the "floating" bars that have a lower and upper value and
    /// appear at each defined point.
    /// </summary>
    /// 
    [Serializable]
    public class HiLowBar : Bar, ICloneable, ISerializable
    {

        #region 变量定义
        /// <summary>
        /// Private field that stores the size (width) of this
        /// <see cref="HiLowBar"/> in points (1/72 inch).  Use the public
        /// property <see cref="Size"/> to access this value.
        /// </summary>
        private float _size;

        /// <summary>
        /// Private field that determines whether the bar width will be based on
        /// the <see cref="Size"/> value, or it will be based on available
        /// space similar to <see cref="BarItem"/> objects.  Use the public property
        /// <see cref="IsAutoSize"/> to access this value.
        /// </summary>
        private bool _isAutoSize;

        /// <summary>
        /// The result of the autosize calculation, which is the size of the bars in
        /// user scale units.  This is converted to pixels at draw time.
        /// </summary>
        internal double _userScaleSize = 1.0;

        #endregion

        #region 默认值定义
        /// <summary>
        /// A simple struct that defines the
        /// default property values for the <see cref="HiLowBar"/> class.
        /// </summary>
        new public struct Default
        {
            // Default HiLowBar properties
            /// <summary>
            /// The default size (width) for the bars (<see cref="HiLowBar.Size"/> property),
            /// in units of points.
            /// </summary>
            public static float Size = 7;

            /// <summary>
            /// Default value for the <see cref="HiLowBar.IsAutoSize" /> property.
            /// </summary>
            public static bool IsAutoSize = true;
        }
        #endregion

        #region 构造函数
        /// <summary>
        /// Default constructor that sets all <see cref="HiLowBar"/> properties to default
        /// values as defined in the <see cref="Bar.Default"/> class.
        /// </summary>
        public HiLowBar()
            : this(Color.Empty)
        {
        }

        /// <summary>
        /// Default constructor that sets the 
        /// <see cref="Color"/> as specified, and the remaining
        /// <see cref="HiLowBar"/> properties to default
        /// values as defined in the <see cref="Bar.Default"/> class.
        /// The specified color is only applied to the
        /// <see cref="Fill.Color"/>, and the <see cref="LineBase.Color"/>
        /// will be defaulted.
        /// </summary>
        /// <param name="color">A <see cref="Color"/> value indicating
        /// the <see cref="Fill.Color"/>
        /// of the Bar.
        /// </param>
        public HiLowBar(Color color)
            : this(color, Default.Size)
        {
        }

        /// <summary>
        /// Default constructor that sets the 
        /// <see cref="Color"/> and <see cref="Size"/> as specified, and the remaining
        /// <see cref="HiLowBar"/> properties to default
        /// values as defined in the <see cref="Bar.Default"/> class.
        /// The specified color is only applied to the
        /// <see cref="Fill.Color"/>, and the <see cref="LineBase.Color"/>
        /// will be defaulted.
        /// </summary>
        /// <param name="color">A <see cref="Color"/> value indicating
        /// the <see cref="Fill.Color"/>
        /// of the Bar.
        /// </param>
        /// <param name="size">The size (width) of the <see cref="HiLowBar"/>'s, in points
        /// (1/72nd inch)</param>
        public HiLowBar(Color color, float size)
            : base(color)
        {
            _size = size;
            _isAutoSize = Default.IsAutoSize;
        }

        /// <summary>
        /// The Copy Constructor
        /// </summary>
        /// <param name="rhs">The <see cref="HiLowBar"/> object from which to copy</param>
        public HiLowBar(HiLowBar rhs)
            : base(rhs)
        {
            _size = rhs._size;
            _isAutoSize = rhs._isAutoSize;
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
        new public HiLowBar Clone()
        {
            return new HiLowBar(this);
        }

        #endregion

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
        protected HiLowBar(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            // The schema value is just a file version parameter.  You can use it to make future versions
            // backwards compatible as new member variables are added to classes
            int sch = info.GetInt32("schema2");

            _size = info.GetSingle("size");
            _isAutoSize = info.GetBoolean("isAutoSize");
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
            info.AddValue("size", _size);
            info.AddValue("isAutoSize", _isAutoSize);
        }
        #endregion

        #region 属性定义
        /// <summary>
        /// Gets or sets the size of the <see cref="HiLowBar"/>
        /// </summary>
        /// <remarks>The size of the bars can be set by this value, which
        /// is then scaled according to the scaleFactor (see
        /// <see cref="PaneBase.CalcScaleFactor"/>).  Alternatively,
        /// if <see cref="IsAutoSize"/> is true, the bar width will
        /// be set according to the maximum available cluster width less
        /// the cluster gap (see <see cref="BarSettings.GetClusterWidth"/>
        /// and <see cref="BarSettings.MinClusterGap"/>).  That is, if
        /// <see cref="IsAutoSize"/> is true, then the value of
        /// <see cref="Size"/> will be ignored.  If you modify the value of Size,
        /// then <see cref="IsAutoSize" /> will be automatically set to false.
        /// </remarks>
        /// <value>Size in points (1/72 inch)</value>
        /// <seealso cref="Default.Size"/>
        public float Size
        {
            get { return _size; }
            set { _size = value; _isAutoSize = false; }
        }

        /// <summary>
        /// Determines whether the bar width will be based on
        /// the <see cref="Size"/> value, or it will be based on available
        /// space similar to <see cref="BarItem"/> objects.
        /// </summary>
        /// <remarks>If true, then the value of <see cref="Size"/> is ignored. 
        /// If this value is true, then <see cref="BarSettings.MinClusterGap"/> will be used to
        /// determine the total space between each bar.  If the base axis is non-ordinal, then
        /// <see cref="BarSettings.ClusterScaleWidth" /> will be active.  In this case, you may
        /// want to make sure that <see cref="BarSettings.ClusterScaleWidthAuto" /> is true.
        /// </remarks>
        public bool IsAutoSize
        {
            get { return _isAutoSize; }
            set { _isAutoSize = value; }
        }
        #endregion

        #region 方法定义
        /// <summary>
        /// Returns the width of the bar, in pixels, based on the settings for
        /// <see cref="Size"/> and <see cref="IsAutoSize"/>.
        /// </summary>
        /// <param name="pane">The parent <see cref="GraphPane"/> object.</param>
        /// <param name="baseAxis">The <see cref="Axis"/> object that
        /// represents the bar base (independent axis).</param>
        /// <param name="scaleFactor">
        /// The scaling factor to be used for rendering objects.  This is calculated and
        /// passed down by the parent <see cref="GraphPane"/> object using the
        /// <see cref="PaneBase.CalcScaleFactor"/> method, and is used to proportionally adjust
        /// font sizes, etc. according to the actual size of the graph.
        /// </param>
        /// <returns>The width of each bar, in pixel units</returns>
        public float GetBarWidth(GraphPane pane, Axis baseAxis, float scaleFactor)
        {
            float width;

            if (_isAutoSize)
                width = baseAxis._scale.GetClusterWidth(_userScaleSize) /
                                (1.0F + pane._barSettings.MinClusterGap);
            else
                width = (float)(_size * scaleFactor);

            // use integral size
            return (int)(width + 0.5f);
        }


        #endregion

    }
}
