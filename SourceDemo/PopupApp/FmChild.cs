using System;
using System.Windows.Forms;
using AhDung.WinForm.Controls;

namespace AhDung
{
    public partial class FmChild : Form
    {
        private FmMDI OwnerOrParent
        {
            get
            {
                return (FmMDI)(IsMdiChild ? MdiParent : Owner);
            }
        }

        public FmChild()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OwnerOrParent.PopupLayer(typeof(InputPopDemo), sender);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            OwnerOrParent.PopupLayer(typeof(InputPopDemo), sender);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            using (FloatLayerBase p = OwnerOrParent.CreateLayer(typeof(CalcPopDemo)))
            {
                if (p.ShowDialog(textBox1) != System.Windows.Forms.DialogResult.OK)
                { return; }

                textBox1.Text = ((CalcPopDemo)p).Result.ToString();
            }

        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            if (label1.Tag != null) { return; }

            FloatLayerBase p = OwnerOrParent.CreateLayer(typeof(TipPopDemo));
            label1.Tag = p;
            p.VisibleChanged += (a, b) => { if (!((a as Control).Visible)) { label1.Tag = null; } };
            p.Show(label1, 0, label1.Height + 3);
        }
    }
}
