using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kurs
{
    public partial class Form1 : Form
    {
        public bool Prava;
        public Form1(bool prava)
        {
            InitializeComponent();
            Prava = prava;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(Prava); 
            f.ShowDialog(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3(Prava);
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4(Prava);
            f.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 f = new Form5(Prava);
            f.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form6 f = new Form6(Prava);
            f.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form7 f = new Form7(Prava);
            f.ShowDialog();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox1 = new AboutBox1();
            aboutBox1.ShowDialog();
        }
    }
}
