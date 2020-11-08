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
        public MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=");
        public MySqlDataAdapter adapter;
        public MySqlCommand command;

        public int id_client = 0;
        public int id_sotrudniki = 0;
        public int id_usluga = 0;

        public Form1()
        {
            InitializeComponent();
            Client();
            Sotrudniki();
            Usluga();
            Nomera();
        }

        public void Client()
        {
            adapter = new MySqlDataAdapter("SELECT * FROM Gostinica.Client", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Client");
            connection.Close();
            dataGridView1.DataSource = ds.Tables["Client"];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Фамилия";
            dataGridView1.Columns[2].HeaderText = "Имя";
            dataGridView1.Columns[3].HeaderText = "Отчество";
            dataGridView1.Columns[4].HeaderText = "Телефон";
            dataGridView1.Columns[5].HeaderText = "Почта";
            dataGridView1.Columns[6].HeaderText = "Паспорт";
        }

        public void Sotrudniki()
        {
            adapter = new MySqlDataAdapter("SELECT * FROM Gostinica.Sotrudniki", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Sotrudniki");
            connection.Close();
            dataGridView2.DataSource = ds.Tables["Sotrudniki"];
            dataGridView2.Columns[0].HeaderText = "ID";
            dataGridView2.Columns[1].HeaderText = "Должность";
            dataGridView2.Columns[2].HeaderText = "Зарплата";
            dataGridView2.Columns[3].HeaderText = "Стаж";
        }

        public void Usluga()
        {
            adapter = new MySqlDataAdapter("SELECT * FROM Gostinica.Uslugi", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Uslugi");
            connection.Close();
            dataGridView3.DataSource = ds.Tables["Uslugi"];
            dataGridView3.Columns[0].HeaderText = "ID";
            dataGridView3.Columns[1].HeaderText = "Описание";
            dataGridView3.Columns[2].HeaderText = "Стоимость";
            dataGridView3.Columns[3].HeaderText = "Длительность";
            dataGridView3.Columns[4].HeaderText = "Доп. услуги";
        }

        public void Nomera()
        {
            adapter = new MySqlDataAdapter("SELECT Nomera.id, familiy, opisanie, nomer, klas, status FROM " +
                "Gostinica.Client, Gostinica.Uslugi, Gostinica.Nomera WHERE Nomera.id_client = Client.id AND " +
                "Nomera.id_uslugi = Uslugi.id", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Nomera");
            connection.Close();
            dataGridView4.DataSource = ds.Tables["Nomera"];
            dataGridView4.Columns[0].HeaderText = "ID";
            dataGridView4.Columns[1].HeaderText = "Фамилия клиента";
            dataGridView4.Columns[2].HeaderText = "Описание услуги";
            dataGridView4.Columns[3].HeaderText = "Номер";
            dataGridView4.Columns[4].HeaderText = "Класс";
            dataGridView4.Columns[5].HeaderText = "Статус";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox11.Text == "" || textBox12.Text == "" || textBox13.Text == "")
                    MessageBox.Show("Заполните все поля!");
                else
                {
                    command = new MySqlCommand("INSERT INTO Gostinica.Client(familiy, imy, otchestvo, telephone, pochta, passport) " +
                        "VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', " + textBox11.Text + ", '" +
                        textBox13.Text + "', '" + textBox12.Text + "')", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    Client();
                    MessageBox.Show("Добавлено");
                }
            }
            catch (Exception) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (id_client == 0)
                {
                    MessageBox.Show("Вы ничего не выбрали!");
                    return;
                }
                else
                {
                    if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox11.Text == "" || textBox12.Text == "" || textBox13.Text == "")
                        MessageBox.Show("Заполните все поля!");
                    else
                    {
                        command = new MySqlCommand("UPDATE Gostinica.Client SET familiy = '" + textBox1.Text + "', imy = '" + textBox2.Text +
                            "', otchestvo = '" + textBox3.Text + "', telephone = " + textBox11.Text + ", pochta = '" + textBox13.Text +
                            "', passport = " + textBox12.Text + " WHERE id = " + id_client, connection);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        Client();
                        id_client = 0;
                        MessageBox.Show("Изменено");
                    }
                }
            }
            catch (Exception) { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (id_client == 0)
                {
                    MessageBox.Show("Вы ничего не выбрали!");
                    return;
                }
                else
                {
                    command = new MySqlCommand("DELETE FROM Gostinica.Client WHERE id = " + id_client, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    Client();
                    id_client = 0;
                    MessageBox.Show("Удалено");
                }
            }
            catch(Exception) { }
        }       

        private void опрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.ShowDialog(this);
        }

        private void отчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
            if (tabControl1.SelectedIndex == 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        ExcelApp.Cells[i + 1, j + 1] = dataGridView1.Rows[i].Cells[j].Value;
                    }
                }
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView2.ColumnCount; j++)
                    {
                        ExcelApp.Cells[i + 1, j + 1] = dataGridView2.Rows[i].Cells[j].Value;
                    }
                }
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView3.ColumnCount; j++)
                    {
                        ExcelApp.Cells[i + 1, j + 1] = dataGridView3.Rows[i].Cells[j].Value;
                    }
                }
            }
            ExcelApp.Visible = true;
            ExcelApp.UserControl = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
                    MessageBox.Show("Заполните все поля!");
                else
                {
                    command = new MySqlCommand("INSERT INTO Gostinica.Sotrudniki(doljnost, zp, stazh) " +
                        "VALUES ('" + textBox4.Text + "', " + textBox5.Text + ", " + textBox6.Text + ")", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    Sotrudniki();
                    MessageBox.Show("Добавлено");
                }
            }
            catch(Exception) { }
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                id_client = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox11.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                textBox13.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                textBox12.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            }
            catch (Exception) { }
        }

        private void dataGridView2_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                id_sotrudniki = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
                textBox4.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                textBox5.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                textBox6.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();                
            }
            catch (Exception) { }
        }

        private void dataGridView3_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                id_usluga = Convert.ToInt32(dataGridView3.CurrentRow.Cells[0].Value);
                textBox8.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
                textBox9.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
                textBox10.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString();
                textBox7.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString();
            }
            catch(Exception) { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (id_sotrudniki == 0)
                {
                    MessageBox.Show("Вы ничего не выбрали!");
                    return;
                }
                else
                {
                    if (textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
                        MessageBox.Show("Заполните все поля!");
                    else
                    {
                        command = new MySqlCommand("UPDATE Gostinica.Sotrudniki SET doljnost = '" + textBox4.Text + "', zp = " + textBox5.Text +
                            ", stazh = " + textBox6.Text + " WHERE id = " + id_sotrudniki, connection);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        Sotrudniki();
                        id_sotrudniki = 0;
                        MessageBox.Show("Изменено");
                    }
                }
            }
            catch (Exception) { }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (id_sotrudniki == 0)
                {
                    MessageBox.Show("Вы ничего не выбрали!");
                    return;
                }
                else
                {
                    command = new MySqlCommand("DELETE FROM Gostinica.Sotrudniki WHERE id = " + id_sotrudniki, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    Sotrudniki();
                    id_sotrudniki = 0;
                    MessageBox.Show("Удалено");
                }
            }
            catch (Exception) { }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox8.Text == "" || textBox9.Text == "" || textBox10.Text == "" || textBox7.Text == "")
                    MessageBox.Show("Заполните все поля!");
                else
                {
                    command = new MySqlCommand("INSERT INTO Gostinica.Uslugi(opisanie, stoimost, dlitelnost, dop_uslugi) " +
                        "VALUES ('" + textBox8.Text + "', " + textBox9.Text + ", " + textBox10.Text + ", '" + textBox7.Text + "')", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    Usluga();
                    MessageBox.Show("Добавлено");
                }
            }
            catch (Exception) { }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (id_usluga == 0)
                {
                    MessageBox.Show("Вы ничего не выбрали!");
                    return;
                }
                else
                {
                    if (textBox8.Text == "" || textBox9.Text == "" || textBox10.Text == "" || textBox7.Text == "")
                        MessageBox.Show("Заполните все поля!");
                    else
                    {
                        command = new MySqlCommand("UPDATE Gostinica.Uslugi SET opisanie = '" + textBox8.Text + "', stoimost = " +
                            textBox9.Text + ", dlitelnost = " + textBox10.Text + ", dop_uslugi = '" + textBox10.Text + "' WHERE id = " + id_usluga, connection);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        Usluga();
                        id_usluga = 0;
                        MessageBox.Show("Изменено");
                    }
                }
            }
            catch (Exception) { }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (id_usluga == 0)
                {
                    MessageBox.Show("Вы ничего не выбрали!");
                    return;
                }
                else
                {
                    command = new MySqlCommand("DELETE FROM Gostinica.Uslugi WHERE id = " + id_usluga, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    Usluga();
                    id_usluga = 0;
                    MessageBox.Show("Удалено");
                }
            }
            catch (Exception) { }
        }
    }
}