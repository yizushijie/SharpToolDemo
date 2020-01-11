using System.Diagnostics;
using System.Windows.Forms;

namespace AhDung.WinForm.Controls
{
    public partial class TipPopDemo : FloatLayerBase
    {
        public TipPopDemo()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.cnblogs.com/ahdung/");
        }
    }
}
