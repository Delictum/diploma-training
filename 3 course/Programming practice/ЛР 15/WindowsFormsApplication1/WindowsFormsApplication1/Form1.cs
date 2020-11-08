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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double xn, xk, xh, x, y, a, ymax, ymin, yt;
            int n, i;
            //Проверка ввода данных в компоненты textBox 
            if ((textBox3.Text != "") && (textBox4.Text != "") && (textBox5.Text != "") && (textBox6.Text != ""))
            { 
                //Преобразование введенных данных в тип double 
                xn = Convert.ToDouble(textBox3.Text);
                xk = Convert.ToDouble(textBox4.Text);
                xh = Convert.ToDouble(textBox5.Text);
                a = Convert.ToDouble(textBox6.Text);
                //Очистка столбцов таблицы 
                dataGridView1.Columns.Clear();
                //Создание двух столбцов в таблице 
                dataGridView1.ColumnCount = 2;
                //Создание в таблице строк 
                dataGridView1.Rows.Add(Math.Ceiling((xk - xn) / xh) + 1); 
                //Занесение в верхнюю строку таблицы в первую ячейку текст «Х», во вторую текст «У» 
                dataGridView1.Columns[0].Name = " X";
                dataGridView1.Columns[1].Name = " Y";
                i = 0; 
                x = xn;
                ymax = -1.8e307; 
                ymin = 1.8e307;

                while (x <= xk)
                {
                    if (x <= 0)
                    {
                        y = 0; 
                    }
                    else if (x <= a) 
                    {
                        try
                        {
                            if (x < 0 || Math.Log10(x) < 0)
                            {
                                throw new Exception();
                            }
                            y = Math.Log(Math.Log10(x));
                        }
                        catch (Exception)
                        {
                            dataGridView1.Rows[i].Cells[0].Value = Convert.ToString(x);
                            dataGridView1.Rows[i].Cells[1].Value = "Область недопустимых значений";
                            x += xh;
                            i++;
                            dataGridView1.Rows.Add(1);
                            continue;
                        }
                    }
                    else
                    { 
                        y = Math.Pow(Math.Sin((Math.Pow(a, 2)* x)), 0.33333333333333); 
                    }
                    //Занесение в первый столбец значений аргумента Х 
                    dataGridView1.Rows[i].Cells[0].Value = Convert.ToString(x);
                    //Переменной yt присваивает округленное до двух знаков после запятой значение у 
                    yt = Math.Ceiling(y * 100) / 100;
                    //Вывод во втором столбце таблицы значение функции У 
                    dataGridView1.Rows[i].Cells[1].Value = Convert.ToString(yt);
                    string str = Convert.ToString(dataGridView1.Rows[i].Cells[1].Value);
                    if (str == "NaN")
                    {
                        dataGridView1.Rows[i].Cells[1].Value = "Требуются доп. исследования";
                    }
                    //находит максимальное и минимальное значение и округляет до двух знаков после запятой 
                    if (y > ymax)
                        ymax = Math.Ceiling(y * 100) / 100;
                    if (y < ymin)
                        ymin = Math.Ceiling(y * 100) / 100;
                    x += xh;
                    i++;
                    dataGridView1.Rows.Add(1);
                }
                //выводит в компоненты textbox максимальное и минимальное значение функции 
                textBox1.Text = Convert.ToString(ymax);
                textBox2.Text = Convert.ToString(ymin);
                dataGridView1.Rows.RemoveAt(i);
            }
            else
            {
                MessageBox.Show("Заполните, пожалуйста, данные", "Ошибка ввода данных",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

    }
}
