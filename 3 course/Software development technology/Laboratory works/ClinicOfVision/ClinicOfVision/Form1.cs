using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Deployment;

namespace ClinicOfVision
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void медКартаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClinicOfVision.Form2 child = new ClinicOfVision.Form2(this, "Мед. карта");
            child.Show();
        }

        private void клиентToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClinicOfVision.Form2 child = new ClinicOfVision.Form2(this, "Клиент");            
            child.Show();
        }

        private void диагнозToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClinicOfVision.Form2 child = new ClinicOfVision.Form2(this, "Диагноз");
            child.Show();
        }

        private void врачToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClinicOfVision.Form2 child = new ClinicOfVision.Form2(this, "Врач");
            child.Show();
        }

        private void лечениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClinicOfVision.Form2 child = new ClinicOfVision.Form2(this, "Лечение");
            child.Show();
        }

        private void оборудованиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClinicOfVision.Form2 child = new ClinicOfVision.Form2(this, "Оборудование");
            child.Show();
        }

        private void стоимостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClinicOfVision.Form2 child = new ClinicOfVision.Form2(this, "Стоимость");
            child.Show();
        }

        private void услугаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClinicOfVision.Form2 child = new ClinicOfVision.Form2(this, "Услуга");
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
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.ShowDialog(this);
        }
    }
}
