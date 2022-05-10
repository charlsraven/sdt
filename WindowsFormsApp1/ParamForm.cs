using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class ParamForm : Form
    {
        public Form1 parent;
        public Size rollbackPoint;
        public int rollbackLine;
        public bool bSaved = true;
        public ParamForm(Form1 parentForm)
        {
            InitializeComponent();
            parent = parentForm;
            rollbackPoint = parent.PointSize;
            rollbackLine = parent.lineWidth;
            ptSizeUpDown.Value = parentForm.PointSize.Width;
            lineSizeUpDown.Value = parentForm.lineWidth;
            FormClosing += ParamForm_FormClosing;
            ptSizeUpDown.ValueChanged += ptSizeUpDown_ValueChanged;
            lineSizeUpDown.ValueChanged += lineSizeUpDown_ValueChanged;
            btSave.Click += new EventHandler(btSave_Click);
            btCancel.Click += new EventHandler(btCancel_Click);
        }
        private void ParamForm_FormClosing(object sender, FormClosingEventArgs e) 
        {
            if (bSaved)
                FormClosed += ParamForm_FormClosed_withNoSafe;
            else
            {
                switch (MessageBox.Show(this, "Сохранить введённые данные?",
                              "Данные не сохранятся",
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    case DialogResult.No:
                        e.Cancel = true;
                        break;
                    case DialogResult.Yes:
                        parent.PointSize = new Size((int)ptSizeUpDown.Value, (int)ptSizeUpDown.Value); ;
                        parent.lineWidth = (int)lineSizeUpDown.Value;
                        parent.Refresh();
                        break;
                    default:
                        parent.PointSize = rollbackPoint;
                        parent.lineWidth = rollbackLine;
                        parent.Refresh();
                        break;
                }
            }
        }
        public void ParamForm_FormClosed_withNoSafe(object sender, FormClosedEventArgs e) { }
        void ptSizeUpDown_ValueChanged(object sender, EventArgs e)
        {
            bSaved = false;
            parent.PointSize = new Size((int)ptSizeUpDown.Value, (int)ptSizeUpDown.Value);
            parent.Refresh();
        }
        void lineSizeUpDown_ValueChanged(object sender, EventArgs e)
        {
            bSaved = false;
            parent.lineWidth = (int)lineSizeUpDown.Value;
            parent.Refresh();
        }
        public void btSave_Click(object sender, EventArgs e)
        {
            bSaved = true;
            rollbackPoint = new Size((int)ptSizeUpDown.Value, (int)ptSizeUpDown.Value);
            rollbackLine = (int)lineSizeUpDown.Value;
            parent.Refresh();
        }
        void btCancel_Click(object sender, EventArgs e)
        {
            bSaved = true;
            parent.PointSize = rollbackPoint;
            parent.lineWidth = rollbackLine;
            ptSizeUpDown.Value = rollbackPoint.Width;
            lineSizeUpDown.Value = rollbackLine;
            parent.Refresh();
        }
        private void ParamForm_Load(object sender, EventArgs e) { }
    }
}
