using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyControl;

namespace MyControlTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();         
        }

        private void buttonControl1_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            textBox1.Text = Convert.ToString(rand.Next(-99, 100));
        }
    }    
}
