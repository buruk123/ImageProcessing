using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class PowerContrastForm : Form
    {
        public PowerContrastForm()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
            numericUpDown1.Increment = 0.1M;
        }

        public float GammaValue
        {
            get { return (float) numericUpDown1.Value; }
        }
    }
}
