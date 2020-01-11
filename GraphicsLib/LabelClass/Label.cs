using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace TestAgent.GraphicsLib
{
    /// <summary>
    /// Class that handles the data associated with text title and its associated font
    /// properties
    /// </summary>
    /// 
    [Serializable]
    public class Label : ICloneable, ISerializable
    {
        #region 变量定义
        /// <summary>
        /// private field that stores the "string" text for this label
        /// </summary>
        internal string _text;
        /// <summary>
        /// private field that stores the "FontSpec" font properties for this label
        /// </summary>
        internal FontSpec _fontSpec;
        /// <summary>
        /// private field that determines if this label will be displayed.
        /// </summary>
        internal bool _isVisible;
        #endregion

        #region 构造函数

        /// <summary>
        /// Constructor to build an "AxisLabel" from the text and the
        /// associated font properties.
        /// </summary>
        /// <param name="text">The "string" representing the text to be
        /// displayed</param>
        /// <param name="fontFamily">The "String" font family name</param>
        /// <param name="fontSize">The size of the font in points and scaled according
        /// to the "BasePane.CalcScaleFactor" logic.</param>
        /// <param name="color">The "Color" instance representing the color
        /// of the font</param>
        /// <param name="isBold">true for a bold font face</param>
        /// <param name="isItalic">true for an italic font face</param>
        /// <param name="isUnderline">true for an underline font face</param>
        public Label(string text, string fontFamily, float fontSize, Color color, bool isBold,
            bool isItalic, bool isUnderline)
        {
            _text = (text == null) ? string.Empty : text;

            _fontSpec = new FontSpec(fontFamily, fontSize, color, isBold, isItalic, isUnderline);
            _isVisible = true;
        }
        /// <summary>
        /// Constructor that builds a "Label" from a text "string"
        /// and a "FontSpec" instance.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="fontSpec"></param>
        public Label(string text, FontSpec fontSpec)
        {
            _text = (text == null) ? string.Empty : text;

            _fontSpec = fontSpec;
            _isVisible = true;
        }
        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="rhs">the "Label" instance to be copied.</param>
        public Label(Label rhs)
        {
            if (rhs._text != null)
                _text = (string)rhs._text.Clone();
            else
                _text = string.Empty;

            _isVisible = rhs._isVisible;
            if (rhs._fontSpec != null)
                _fontSpec = rhs._fontSpec.Clone();
            else
                _fontSpec = null;
        }
        /// <summary>
        /// Implement the "ICloneable" interface in a typesafe manner by just
        /// calling the typed version of "Clone"
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
        public Label Clone()
        {
            return new Label(this);
        }
        #endregion

        #region 属性定义
        /// <summary>
        /// The "String" text to be displayed
        /// </summary>
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        /// <summary>
        /// A "FontSpec" instance representing the font properties
        /// for the displayed text.
        /// </summary>
        public FontSpec FontSpec
        {
            get { return _fontSpec; }
            set { _fontSpec = value; }
        }

        /// <summary>
        /// Gets or sets a boolean value that determines whether or not this label will be displayed.
        /// </summary>
        public bool IsVisible
        {
            get { return _isVisible; }
            set { _isVisible = value; }
        }

        #endregion

        #region 串行化函数定义
        /// <summary>
        /// Current schema value that defines the version of the serialized file
        /// </summary>
        public const int schema = 10;

        /// <summary>
        /// Constructor for deserializing objects
        /// </summary>
        /// <param name="info">A "SerializationInfo" instance that defines the serialized data
        /// </param>
        /// <param name="context">A "StreamingContext" instance that contains the serialized data
        /// </param>
        protected Label(SerializationInfo info, StreamingContext context)
        {
            // The schema value is just a file version parameter.  You can use it to make future versions
            // backwards compatible as new member variables are added to classes
            int sch = info.GetInt32("schema");

            _text = info.GetString("text");
            _isVisible = info.GetBoolean("isVisible");
            _fontSpec = (FontSpec)info.GetValue("fontSpec", typeof(FontSpec));
        }
        /// <summary>
        /// Populates a "SerializationInfo" instance with the data needed to serialize the target object
        /// </summary>
        /// <param name="info">A "SerializationInfo" instance that defines the serialized data</param>
        /// <param name="context">A "StreamingContext" instance that contains the serialized data</param>
        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("schema", schema);
            info.AddValue("text", _text);
            info.AddValue("isVisible", _isVisible);
            info.AddValue("fontSpec", _fontSpec);
        }
        #endregion
    }
}
