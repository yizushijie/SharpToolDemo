using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace TestAgent.GraphicsLib
{
    public class VictorScale : Scale, ISerializable
    {
        #region 构造函数

        /// <summary>
        /// 给定拥有者的构造函数
        /// </summary>
        /// <param name="owner"></param>
        public VictorScale(Axis owner)
            : base(owner)
        {
        }

        /// <summary>
        /// 拷贝型构造函数
        /// </summary>
        /// <param name="rhs">The <see cref="LinearScale" /> object from which to copy</param>
        /// <param name="owner">The <see cref="Axis" /> object that will own the
        /// new instance of <see cref="LinearScale" /></param>
        public VictorScale(Scale rhs, Axis owner)
            : base(rhs, owner)
        {
        }


        /// <summary>
        /// Create a new clone of the current item, with a new owner assignment
        /// </summary>
        /// <param name="owner">The new <see cref="Axis" /> instance that will be
        /// the owner of the new Scale</param>
        /// <returns>A new <see cref="Scale" /> clone.</returns>
        public override Scale Clone(Axis owner)
        {
            return new VictorScale(this, owner);
        }
        #endregion 构造函数

        #region 属性定义
        /// <summary>
        /// Return the <see cref="AxisType" /> for this <see cref="Scale" />, which is
        /// <see cref="AxisType.Linear" />.
        /// </summary>
        public override AxisType Type
        {
            get { return AxisType.Vectors; }
        }
        #endregion 属性定义

        #region 函数定义

        #endregion 函数定义
    }
}
