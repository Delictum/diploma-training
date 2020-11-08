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
    public partial class Form2 : Form
    {
        public int n, m;

        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox2.Text != ""))
            {
                m = Convert.ToInt32(textBox1.Text);
                n = Convert.ToInt32(textBox2.Text);
                dataGridView1.Columns.Clear();
                dataGridView1.ColumnCount = n;
                dataGridView1.RowCount = m;
            }
            else
            {
                MessageBox.Show("Заполните, пожалуйста, данные", "Ошибка ввода данных",
               MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 f4 = new Form4();
            f4.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int count = 0;
            double sum = 0, sr = 0;

            int size = Convert.ToInt32(Math.Round(Convert.ToDouble(m) / 4)) + 1;
            double max = -1000000;
            double[,] A = new double[m, n];

            for (int i = 1; i <= m; i++)
                for (int j = 1; j <= n; j++)
                {
                    A[i - 1, j - 1] = Convert.ToDouble(this.dataGridView1.Rows[i - 1].Cells[j - 1].Value);
                    if (A[i - 1, j - 1] % 2 == 0 && j == n)
                    {
                        sum *= Math.Pow(A[i - 1, j - 1], 2);
                        count++;
                    }
                    if ((i == 1) && (A[i - 1, j - 1] != 0) && (max < A[i - 1, j - 1]))
                    {
                        max = Math.Abs(A[i - 1, j - 1]);
                    }
                }
            sr = Math.Pow(sum,  1.0 / count);
            
            if (checkBox1.Checked == true)
            {
                this.textBox3.Text = Convert.ToString(sr);
            }
            else
            if (checkBox1.Checked == true)
            {
                this.textBox3.Text = Convert.ToString("нет элементов");
            }
            
            if (checkBox2.Checked == true)
            {
               this. textBox4.Text = Convert.ToString(max);
            }
            else
            if (checkBox2.Checked == true)
            {
                this.textBox4.Text = Convert.ToString("нет элементов");
            }
            return;
        }
    }
}
