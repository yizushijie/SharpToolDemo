using System;
using System.Drawing;
using System.Windows.Forms;

namespace AhDung.PopupDemos
{
    public partial class ColorDemo : AhDung.WinForm.Controls.FloatLayerBase
    {
        public Color SelectedColor { get; private set; }

        public ColorDemo()
        {
            InitializeComponent();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            SelectedColor = ((Button)sender).BackColor;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
