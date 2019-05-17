using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class GammaForm : Form
    {
        public GammaForm()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
        }

        public double RedComponent
        {
            get { return redScrollBar.Value; }
        }

        public double GreenComponent
        {
            get { return greenScrollBar.Value; }
        }

        public double BlueComponent
        {
            get { return greenScrollBar.Value; }
        }
    }
}