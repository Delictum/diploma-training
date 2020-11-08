using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public ClickButton CB = new ClickButton();

        public Form1()
        {
            InitializeComponent();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CB.openFileDialog1 = openFileDialog1;
            CB.richTextBox1 = richTextBox1;
            CB.Button_Click(sender, e);            
        }
    }
}
