using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class ScaleHistogram : Form
    {
        public ScaleHistogram()
        {
            InitializeComponent();
            btnOK.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
        }

        public int a
        {
            get { return (int) aValue.Value; }
        }

        public int b
        {
            get { return (int) bValue.Value; }
        }
        public int c
        {
            get { return (int) cValue.Value; }
        }
        public int d
        {
            get { return (int) dValue.Value; }
        }
    }
}
