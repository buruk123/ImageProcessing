using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class Skew : Form
    {
        public Skew()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
        }

        public int A
        {
            get { return (int) numericUpDown1.Value; }
        }

        public int B
        {
            get { return (int) numericUpDown2.Value; }
        }
    }
}
