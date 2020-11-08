using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }        

        private void медКартаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 child = new Form2(this, "Поставщик");
            child.Show();
        }

        private void клиентToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 child = new Form2(this, "Детали");
            child.Show();
        }

        private void диагнозToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 child = new Form2(this, "Поставки");
            child.Show();
        }

        private void плиткаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void каскадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.ShowDialog();
        }
    }
}
