using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TestAgent.GraphicsLib
{
    public partial class FormGraphics : Form
    {
        private MasterPane _usedPane = new MasterPane();

        public MasterPane UsedPane { get { return this._usedPane; } set { this._usedPane = value; } }

        public FormGraphics(MasterPane usedPane)
        {
            this._usedPane = usedPane;
            InitializeComponent();
            this._usedPane.WhenDataChange += new PaneBase.DataChangeEventHandler(_usedPane_WhenDataChange);
        }

        void _usedPane_WhenDataChange(PaneBase sender, DataChangeEventArgs args)
        {
            this._usedPane.AxisChange();
            this.panel_Graphics.Refresh();
        }

        private void optionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._usedPane.ShowParamEditDialog();

            using (Graphics g = this.pictureBox_Graphics.CreateGraphics())
            {
                this._usedPane.ReSize(g);
            }
            this.pictureBox_Graphics.Refresh();
        }

        private void pictureBox_Graphics_Resize(object sender, EventArgs e)
        {
            lock (this)
            {
                if (this._usedPane == null)
                    return;

                this._usedPane.ReSize(this.pictureBox_Graphics);
            }
        }

        private void pictureBox_Graphics_Paint(object sender, PaintEventArgs e)
        {
            lock (this)
            {
                if (this._usedPane == null)
                    return;
                base.OnPaint(e);

                try
                {
                    this._usedPane.Draw(e.Graphics);
                }
                catch { }
            }
        }

        public virtual void AxisChange()
        {
            lock (this)
            {
                if (this._usedPane == null)
                    return;
                this._usedPane.AxisChange(this.pictureBox_Graphics);
            }
        }

        private void FormGraphics_Load(object sender, EventArgs e)
        {
            this.ReCaluateSize();
            this._usedPane.InitControl(this.pictureBox_Graphics);
        }

        private void ReCaluateSize()
        {
            this.pictureBox_Graphics.Width = (int)((this.panel_Graphics.Width - 6) * (float)this.num_XScale.Value);
            this.pictureBox_Graphics.Height = (int)((this.panel_Graphics.Height - 6) * (float)this.num_YScale.Value);
        }

        private void num_Scale_ValueChanged(object sender, EventArgs e)
        {
            this.ReCaluateSize();
        }

        private void pictureBox_Graphics_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case System.Windows.Forms.MouseButtons.Left:
                    Location point = this._usedPane.MouseDown(e.Location, this.pictureBox_Graphics.CreateGraphics());
                    if (point != null)
                        this.toolTip_Graphics.SetToolTip(this.pictureBox_Graphics, string.Format("{0}:{1}", point.X, point.Y));
                    this.pictureBox_Graphics.Refresh();
                    break;
                case System.Windows.Forms.MouseButtons.Middle:
                    break;
                case System.Windows.Forms.MouseButtons.Right:
                    break;
            }
        }

        private void pictureBox_Graphics_MouseMove(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case System.Windows.Forms.MouseButtons.Left:
                    Location point = this._usedPane.MouseMove(e.Location, this.pictureBox_Graphics.CreateGraphics());
                    if (point != null)
                        this.toolTip_Graphics.SetToolTip(this.pictureBox_Graphics, string.Format("{0}:{1}", point.X, point.Y));
                    this.pictureBox_Graphics.Refresh();
                    break;
                case System.Windows.Forms.MouseButtons.Middle:
                    break;
                case System.Windows.Forms.MouseButtons.Right:
                    break;
            }
        }

        private void pictureBox_Graphics_MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case System.Windows.Forms.MouseButtons.Left:
                    Location point = this._usedPane.MouseUp(e.Location, this.pictureBox_Graphics.CreateGraphics());
                    this.toolTip_Graphics.SetToolTip(this.pictureBox_Graphics, "");
                    this.pictureBox_Graphics.Refresh();
                    break;
                case System.Windows.Forms.MouseButtons.Middle:
                    break;
                case System.Windows.Forms.MouseButtons.Right:
                    break;
            }
        }

        private void pictureBox_Graphics_MouseHover(object sender, EventArgs e)
        {
            Location point = this._usedPane.GetLocation(Cursor.Position,this.pictureBox_Graphics.CreateGraphics());
            if (point != null)
                this.toolTip_Graphics.SetToolTip(this.pictureBox_Graphics, string.Format("{0}:{1}", point.X, point.Y));
        }

        private void panel_Graphics_SizeChanged(object sender, EventArgs e)
        {
            this.ReCaluateSize();
        }

        private void pictureBox_Graphics_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case System.Windows.Forms.MouseButtons.Left:
                    break;
                case System.Windows.Forms.MouseButtons.Middle:
                    break;
                case System.Windows.Forms.MouseButtons.Right:
                    this._usedPane.ShowSelectObjMenu(this.pictureBox_Graphics, e.Location);
                    break;
            }
        }

    }
}
