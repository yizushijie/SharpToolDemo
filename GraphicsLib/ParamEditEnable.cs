using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace TestAgent.GraphicsLib
{
    [Serializable()]
    abstract public class ParamEditEnable: ICloneable, ISerializable
    {
        #region 变量定义
        /// <summary>
        /// 对象的前缀
        /// </summary>
        protected string _objPrefix = "";
        /// <summary>
        /// true:允许编辑
        /// </summary>
        private bool _enableParamEdit = false;
        #endregion 变量定义

        #region 属性定义
        /// <summary>
        /// 对象前缀字符串只读属性
        /// </summary>
        public virtual string ObjPrefix { get { return this._objPrefix; } }
        /// <summary>
        /// 使能参数编辑
        /// </summary>
        public bool EnableEditParam { get { return this._enableParamEdit; } set { this._enableParamEdit = value; } }
        #endregion 属性定义

        #region 构造函数
        /// <summary>
        /// 无参数构造函数
        /// </summary>
        public ParamEditEnable()
        {
        }

        /// <summary>
        /// 根据给定的对象创建本类对象构造函数
        /// </summary>
        /// <param name="rhs"></param>
        public ParamEditEnable(ParamEditEnable rhs)
        {
            this._objPrefix = rhs._objPrefix;
        }
        #endregion 构造函数

        #region ICloneable 成员

        object ICloneable.Clone()
        {
            throw new NotImplementedException("Can't clone an abstract base type -- child types must implement ICloneable");
        }
        #endregion ICloneable 成员

        #region 参数编辑函数
        /// <summary>
        /// 虚拟函数创建对象参数编辑窗体
        /// </summary>
        /// <returns></returns>
        protected virtual FormParamEditBase CreatParamEditForm()
        {
            return new FormParamEditBase(this);
        }
        /// <summary>
        /// 本类定义的显示编辑参数窗体
        /// </summary>
        public void ShowParamEditDialog()
        {
            if (this._enableParamEdit)
            {
                FormParamEditBase form = this.CreatParamEditForm();
                form.ShowDialog();
            }
        }
        #endregion 参数编辑函数

        #region ISerializable 成员
        /// <summary>
        /// 版本常数
        /// </summary>
        public const int schema111 = 12;

        protected ParamEditEnable(SerializationInfo info, StreamingContext context)
        {
            // schema 的值是版本参数，你可以用它来制作向后兼容的新版本，以便在类中加入新的变量
            int sch = info.GetInt32("schema");
            // 从串行化数据中获取变量值
            this._objPrefix =  info.GetString("objPrefix");
        }

        /// <summary>
        /// 本类对象串行化定义
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("schema", schema111);
            info.AddValue("objPrefix", this._objPrefix);
        }

        #endregion
    }
}
