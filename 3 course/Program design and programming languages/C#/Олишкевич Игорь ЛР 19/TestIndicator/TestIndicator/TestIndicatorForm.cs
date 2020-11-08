using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestIndicator
{
    public partial class TestIndicatorForm : Form
    {
        public TestIndicatorForm()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int Value = trackBar1.Value;
            numericUpDown1.Value = Value;
            progressBar1.Value = Value;

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int Value = (int)numericUpDown1.Value;
            trackBar1.Value = Value;
            progressBar1.Value = Value;

        }
    }
}
