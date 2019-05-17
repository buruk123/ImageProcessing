using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class Interpolation : Form
    {
        public Interpolation()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
        }

        public int Width2
        {
            get { return (int) numericUpDown1.Value; }
        }

        public int Height2
        {
            get { return (int) numericUpDown2.Value; }
        }
    }
}

