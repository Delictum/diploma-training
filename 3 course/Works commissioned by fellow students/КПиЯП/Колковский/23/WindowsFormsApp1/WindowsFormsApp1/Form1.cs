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
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void objektToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Пункт меню Объект");
        }

        private void сотрудникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormEmployee FEmployee = new FormEmployee();
            FEmployee.MdiParent = this;
            FEmployee.Show();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox = new AboutBox1();
            aboutBox.ShowDialog(this);
        }
    }
}
