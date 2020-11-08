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
                //Чистка столбцов компонента DataGridView, если они не пусты
                dataGridView1.Columns.Clear();
                //Заполнение компонента DataGridView столбцами
                dataGridView1.ColumnCount = n;
                //Заполнение компонента DataGridView строками
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int count = 0;
            double sum = 0, sr = 0;

            double[,] A = new double[m, n];

            A[0, n - 1] = Convert.ToDouble(this.dataGridView1.Rows[0].Cells[n - 1].Value);
            double max = A[0, n - 1];

            for (int i = 1; i <= m; i++)
                for (int j = 1; j <= n; j++)
                {
                    A[i - 1, j - 1] = Convert.ToDouble(this.dataGridView1.Rows[i - 1].Cells[j - 1].Value);
                    if (i == m)
                    {
                        sum += A[i - 1, j - 1];
                        count++;
                    }

                    if ((j == n) && ((i + 4) % 5 == 0) && (Math.Abs(max) < Math.Abs(A[i - 1, n - 1])))                    
                        max = A[i - 1, n - 1];                    
                }

            sr = sum / count;
            
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
               this.textBox4.Text = Convert.ToString(max);
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
