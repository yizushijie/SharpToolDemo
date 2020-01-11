using System;

namespace AhDung.WinForm.Controls
{
    public partial class InputPopDemo : FloatLayerBase
    {
        public InputPopDemo()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
