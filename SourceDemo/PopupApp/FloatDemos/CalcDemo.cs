using System;
using System.Windows.Forms;

namespace AhDung.WinForm.Controls
{
    public partial class CalcPopDemo : FloatLayerBase
    {
        int? num1, num2;
        bool isAdd, computed;

        public int Result { get; private set; }

        public CalcPopDemo()
        {
            InitializeComponent();
            Reset();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (num1.HasValue || computed)
            {
                txbMonitor.Clear();
                computed = false;
            }
            txbMonitor.Text = Convert.ToInt32(txbMonitor.Text + (sender as Control).Text).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            num1 = Convert.ToInt32(txbMonitor.Text);
            isAdd = (sender as Control).Text == "+";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            int crrNum = Convert.ToInt32(txbMonitor.Text);
            if (!num2.HasValue) { num2 = crrNum; }
            txbMonitor.Text = ((num1 ?? crrNum) + (num1.HasValue ? crrNum : num2) * (isAdd ? 1 : -1)).ToString();
            num1 = null;
            computed = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            num1 = null;
            num2 = null;
            isAdd = true;
            computed = false;
            txbMonitor.Text = "0";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Result = Convert.ToInt32(txbMonitor.Text);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
