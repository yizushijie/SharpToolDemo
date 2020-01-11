using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace TestAgent.GraphicsLib
{
    public partial class Praphics2DControl : UserControl
    {
        private MasterPane _usedPane = new MasterPane();
        /// <summary>
        /// X方向的缩放比例尺
        /// </summary>
        private float _xZoomScale = 1;
        /// <summary>
        /// Y方向的缩放比例尺
        /// </summary>
        private float _yZoomScale = 1;
        /// <summary>
        /// 本控件使用的绘图类对象读写属性
        /// </summary>
        public MasterPane UsedPane { get { return this._usedPane; } set { this._usedPane = value; } }
        /// <summary>
        /// X方向的缩放比例尺读写属性
        /// </summary>
        public float XZoomScale { get { return this._xZoomScale; } set { this._xZoomScale = value; } }
        /// <summary>
        /// Y方向的缩放比例尺读写属性
        /// </summary>
        public float YZoomScale { get { return this._yZoomScale; } set { this._yZoomScale = value; } }

        public Praphics2DControl()
        {
            InitializeComponent();
        }

    }
}
