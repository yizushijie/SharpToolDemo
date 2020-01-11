using AhDung.PopupDemos;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AhDung
{
    public class ColorPicker : ComboBox
    {
        readonly ColorDemo cp;

        public Color SelectedColor
        {
            get { return this.BackColor; }
        }

        public ColorPicker()
        {
            cp = new ColorDemo
            {
                BorderType = BorderStyle.FixedSingle,
            };

            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.DropDownHeight = 1;
        }

        protected override void OnClick(EventArgs e)
        {
            if (cp.ShowDialog(this) != DialogResult.OK) { return; }

            this.BackColor = cp.SelectedColor;

            base.OnClick(e);
        }
    }
}
