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

        private void button3_Click(object sender, EventArgs e)
        {
            //переменную kol и kol2 обнуляем, а переменную р присваиваем единице
            int count = 0, index = 0;
            double sum = 0, sr = 0;

            int size = Convert.ToInt32(Math.Round(Convert.ToDouble(n) / 4)) + 1;
            double[] max = new double[size];
            double[,] A = new double[m, n];

            //Производим считывание из ячеек таблицы и вносим данные в массив
            for (int i = 1; i <= m; i++)
                for (int j = 1; j <= n; j++)
                {
                    A[i - 1, j - 1] = Convert.ToDouble(this.dataGridView1.Rows[i - 1].Cells[j - 1].Value);
                    if (A[i - 1, j - 1] > 0)
                    {
                        sum += A[i - 1, j - 1];
                        count++;
                    }
                    if ((i == 2) && (j % 4 == 0))
                    {
                        max[index] = A[i - 1, j - 1];
                        index++;
                    }
                }
            sr = sum / count;
            //Вывод данных нахождения произведения отрицательных элементов матрицы
            if (checkBox1.Checked == true)
            {
                this.textBox3.Text = Convert.ToString(sr);
            }
            else
            if (checkBox1.Checked == true)
            {
                this.textBox3.Text = Convert.ToString("нет элементов");
            }
            //Вывод данных нахождения количество четных элементов матрицы
            if (checkBox2.Checked == true)
            {
               this. textBox4.Text = Convert.ToString(max.Max());
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
