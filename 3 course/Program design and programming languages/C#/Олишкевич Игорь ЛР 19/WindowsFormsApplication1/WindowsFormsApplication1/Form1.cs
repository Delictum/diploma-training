using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        int time, hms;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hms = comboBox1.SelectedIndex;
            if (hms == 0)
                time = (int)(numericUpDown1.Value) + 1;
            else if (hms == 1)
                time = 60 * (int)(numericUpDown1.Value) + 1;
            else if (hms == 2)
                time = 3600 * (int)(numericUpDown1.Value) + 1;
            progressBar1.Maximum = time;
            progressBar1.Value = 1;
            timer1.Enabled = true;
            button2.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            timer1.Enabled = false;
            hms = 0;
            time = 0;
            this.Text = "Таймер";
            button2.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value++;
            time--; 
            this.Text = Convert.ToString(time) + " с";                        
            if (time == 0)
                Application.Exit();
        }
    }
}
