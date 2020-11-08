using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Form2 child = new Form2(this, "Клиент");
            child.Show();
            Form2 child1 = new Form2(this, "Заказ");
            child1.Show();
            Form2 child2 = new Form2(this, "Вид товара");
            child2.Show();
            Form2 child3 = new Form2(this, "Маршрут");
            child3.Show();
            Form2 child4 = new Form2(this, "Водитель");
            child4.Show();            
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void клиентToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 child = new Form2(this, "Клиент");
            child.Show();
        }

        private void заказToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 child = new Form2(this, "Заказ");
            child.Show();
        }

        private void видТовараToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 child = new Form2(this, "Вид товара");
            child.Show();
        }

        private void маршрутToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 child = new Form2(this, "Маршрут");
            child.Show();
        }

        private void водительToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 child = new Form2(this, "Водитель");
            child.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            плиткаToolStripMenuItem_Click(sender, e);
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
            AboutBox1 about = new AboutBox1();
            about.ShowDialog();
        }
    }
}
