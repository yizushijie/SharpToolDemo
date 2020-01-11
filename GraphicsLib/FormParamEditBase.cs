using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TestAgent.GraphicsLib
{
    public partial class FormParamEditBase : Form
    {
        /// <summary>
        /// 窗体使用的对象
        /// </summary>
        protected ParamEditEnable _usedObj = null;

        /// <summary>
        /// 本窗体使用的对象的读写属性
        /// </summary>
        public ParamEditEnable UsedObj { get { return this._usedObj; } set { if (value is ParamEditEnable) this._usedObj = value; } }

        /// <summary>
        /// 默认构造函数
        /// </summary>
        public FormParamEditBase()
            : this(null)
        {
        }

        /// <summary>
        /// 给定对象的构造函数
        /// </summary>
        /// <param name="usedObj"></param>
        public FormParamEditBase(ParamEditEnable usedObj)
        {
            if (usedObj != null)
                this._usedObj = usedObj;
            InitializeComponent();
        }

        protected virtual void ObjParamToView()
        {
        }

        protected virtual void ViewToObjParam()
        {
        }

        // 显示窗体事件
        private void FormParamEditBase_Load(object sender, EventArgs e)
        {
            if (this._usedObj != null)
                this.ObjParamToView();
        }

        // 单击OK按钮事件
        private void button_OK_Click(object sender, EventArgs e)
        {
            if (this._usedObj != null)
                this.ViewToObjParam();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        // 单击Cancel按钮事件
        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

    }
}
