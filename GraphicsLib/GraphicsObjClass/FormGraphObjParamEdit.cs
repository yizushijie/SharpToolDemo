using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TestAgent.GraphicsLib
{
    public partial class FormGraphObjParamEdit : FormParamEditBase
    {
        public FormGraphObjParamEdit(GraphObj usedObj)
            : base(usedObj)
        {
            InitializeComponent();
        }
    }
}
