using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class ColorForm : Form
    {
        public ColorForm()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
        }

        public double GetRed
        {
            get { return redValueScBar.Value; }
        }

        public double GetGreen
        {
            get { return greenValueScBar.Value; }
        }

        public double GetBlue
        {
            get { return blueValueScBar.Value; }
        }
    }



}
