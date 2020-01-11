using AhDung.WinForm.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace AhDung
{
    public partial class FmMDI : Form
    {
        readonly LayerFormOption _layerOption;
        private int childFormNumber;

        private LayerFormOption LayerOption
        {
            get
            {
                //不能用SelectedValue
                _layerOption.Border3DStyle = (Border3DStyle)(((KeyValuePair<string, object>)(cmb3DStyle.SelectedItem)).Value);
                _layerOption.BorderSingleStyle = (ButtonBorderStyle)(((KeyValuePair<string, object>)(cmbSingleStyle.SelectedItem)).Value);
                _layerOption.BorderColor = (Color)(((KeyValuePair<string, object>)(cmbColor.SelectedItem)).Value);
                return _layerOption;
            }
        }

        public FmMDI()
        {
            InitializeComponent();
            _layerOption = new LayerFormOption();
        }

        protected override void OnLoad(EventArgs e)
        {
            FillComboBox(cmb3DStyle, typeof(Border3DStyle));
            FillComboBox(cmbSingleStyle, typeof(ButtonBorderStyle));
            FillComboBox(cmbColor, typeof(Color));

            cmb3DStyle.SelectedIndex = cmb3DStyle.FindStringExact(Border3DStyle.RaisedInner.ToString());
            cmbSingleStyle.SelectedIndex = cmbSingleStyle.FindStringExact(ButtonBorderStyle.Solid.ToString());
            cmbColor.SelectedIndex = cmbColor.FindStringExact(Color.DarkGray.Name);

            base.OnLoad(e);
        }

        /// <summary>
        /// 填充下拉列表
        /// </summary>
        private static void FillComboBox(ComboBox cmb, Type type)
        {
            cmb.Items.Clear();
            cmb.DisplayMember = "Key";
            cmb.ValueMember = "Value";
            IEnumerable en = type.IsEnum ? type.GetFields(BindingFlags.Static | BindingFlags.Public) : (IEnumerable)type.GetProperties(BindingFlags.Static | BindingFlags.Public);
            foreach (MemberInfo m in en)
            {
                object val;
                if (m is PropertyInfo)
                {
                    PropertyInfo p = (PropertyInfo)m;
                    if (p.PropertyType != type) { continue; }
                    val = p.GetValue(null, null);
                }
                else
                {
                    val = ((FieldInfo)m).GetValue(null);
                }
                cmb.Items.Add(new KeyValuePair<string, object>(m.Name, val));
            }
        }

        private void btnNewChild_Click(object sender, EventArgs e)
        {
            Form childForm = new FmChild { Name = "窗口 " + childFormNumber++ };
            childForm.MdiParent = this;
            childForm.Text = childForm.Name;
            childForm.Show();
        }

        private void btnNewNormal_Click(object sender, EventArgs e)
        {
            new FmChild().Show(this);
        }

        public FloatLayerBase CreateLayer(Type type)
        {
            bool flag;
            return CreateLayer(type, out flag);
        }

        public FloatLayerBase CreateLayer(Type type, out bool isShow)
        {
            //考虑到初始化体验爽滑，不用反射
            FloatLayerBase layer = null;
            if (type == typeof(InputPopDemo)) { layer = new InputPopDemo(); }
            else if (type == typeof(CalcPopDemo)) { layer = new CalcPopDemo(); }
            else if (type == typeof(TipPopDemo)) { layer = new TipPopDemo(); }

            LayerFormOption opts = LayerOption;
            isShow = opts.IsShow;
            layer.BorderType = opts.BorderType;
            layer.Border3DStyle = opts.Border3DStyle;
            layer.BorderSingleStyle = opts.BorderSingleStyle;
            layer.BorderColor = opts.BorderColor;
            return layer;
        }

        public void PopupLayer(Type type, object sender)
        {
            Control c = sender as Control;
            ToolStripItem item = sender as ToolStripItem;

            bool isShow;
            FloatLayerBase p = CreateLayer(type, out isShow);
            if (isShow)
            {
                if (c != null) { p.Show(c); }
                else { p.Show(item); }
            }
            else
            {
                var result = c != null ? p.ShowDialog(c) : p.ShowDialog(item);
                txbResult.AppendText(result + "\r\n");
            }
        }

        private void btnPopupFromItem_Click(object sender, EventArgs e)
        {
            PopupLayer(typeof(InputPopDemo), sender);
        }

        private void btnPopupFromButton_Click(object sender, EventArgs e)
        {
            PopupLayer(typeof(InputPopDemo), sender);
        }

        private void txbPopupFromTextBox_Click(object sender, EventArgs e)
        {
            using (FloatLayerBase p = CreateLayer(typeof(CalcPopDemo)))
            {
                if (p.ShowDialog(txbPopupFromTextBox) != System.Windows.Forms.DialogResult.OK)
                { return; }

                txbPopupFromTextBox.Text = ((CalcPopDemo)p).Result.ToString();
            }
        }

        private void label6_MouseHover(object sender, EventArgs e)
        {
            if (label6.Tag != null) { return; }

            FloatLayerBase p = CreateLayer(typeof(TipPopDemo));
            label6.Tag = p;
            p.VisibleChanged += (a, b) => { if (!((a as Control).Visible)) { label6.Tag = null; } };
            p.Show(label6, 0, label6.Height + 3);
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.cnblogs.com/ahdung/");
        }

        private void rbShow_CheckedChanged(object sender, EventArgs e)
        {
            _layerOption.IsShow = rbShow.Checked;
        }

        private void rbNone_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb;
            if (!(rb = (RadioButton)sender).Checked) { return; }
            _layerOption.BorderType = (BorderStyle)Enum.Parse(typeof(BorderStyle), rb.Tag == null ? rb.Text : rb.Tag.ToString());
            if (rb == rbNone)
            {
                cmb3DStyle.Enabled = false;
                cmbSingleStyle.Enabled = false;
                cmbColor.Enabled = false;
            }
            else if (rb == rb3D)
            {
                cmb3DStyle.Enabled = true;
                cmbSingleStyle.Enabled = false;
                cmbColor.Enabled = false;
            }
            else
            {
                cmb3DStyle.Enabled = false;
                cmbSingleStyle.Enabled = true;
                cmbColor.Enabled = true;
            }
        }

        /// <summary>
        /// 弹出选项容器类
        /// </summary>
        private class LayerFormOption
        {
            public bool IsShow;
            public BorderStyle BorderType;
            public Border3DStyle Border3DStyle;
            public ButtonBorderStyle BorderSingleStyle;
            public Color BorderColor;

            public LayerFormOption()
            {
                IsShow = true;
                BorderType = BorderStyle.Fixed3D;
                Border3DStyle = System.Windows.Forms.Border3DStyle.RaisedInner;
                BorderSingleStyle = ButtonBorderStyle.Solid;
                BorderColor = Color.DarkGray;
            }
        }

    }
}
