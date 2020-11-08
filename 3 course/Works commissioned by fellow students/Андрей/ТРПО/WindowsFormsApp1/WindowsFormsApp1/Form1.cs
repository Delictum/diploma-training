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
        public int id_master = 0;
        public int id_usluga = 0;

        public Form1()
        {
            InitializeComponent();
            Client();
            Master();
            Usluga();
            Zapis();
            Svyz();
        }

        public void Client()
        {
            adapter = new MySqlDataAdapter("SELECT * FROM Parikmaher.Client", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Client");
            connection.Close();
            dataGridView1.DataSource = ds.Tables["Client"];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Фамилия";
            dataGridView1.Columns[2].HeaderText = "Имя";
            dataGridView1.Columns[3].HeaderText = "Отчество";
        }

        public void Master()
        {
            adapter = new MySqlDataAdapter("SELECT * FROM Parikmaher.Master", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Master");
            connection.Close();
            dataGridView2.DataSource = ds.Tables["Master"];
            dataGridView2.Columns[0].HeaderText = "ID";
            dataGridView2.Columns[1].HeaderText = "Фамилия";
            dataGridView2.Columns[2].HeaderText = "Имя";
            dataGridView2.Columns[3].HeaderText = "Отчество";
            dataGridView2.Columns[4].HeaderText = "Стаж";
        }

        public void Usluga()
        {
            adapter = new MySqlDataAdapter("SELECT * FROM Parikmaher.Usluga", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Usluga");
            connection.Close();
            dataGridView3.DataSource = ds.Tables["Usluga"];
            dataGridView3.Columns[0].HeaderText = "ID";
            dataGridView3.Columns[1].HeaderText = "Название";
            dataGridView3.Columns[2].HeaderText = "Стоимость";
            dataGridView3.Columns[3].HeaderText = "Описание";
        }

        public void Zapis()
        {
            adapter = new MySqlDataAdapter("SELECT Zapis.id, Client.familiy, Master.familiy, nazvanie, data FROM Parikmaher.Zapis, " +
                "Parikmaher.Master, Parikmaher.Client, Parikmaher.Svyz, Parikmaher.Usluga WHERE Zapis.id_client = Client.id AND " +
                "Zapis.id_master = Master.id AND Zapis.id_svyz = Svyz.id AND Svyz.id_usluga = Usluga.id", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Zapis");
            connection.Close();
            dataGridView4.DataSource = ds.Tables["Zapis"];
            dataGridView4.Columns[0].HeaderText = "ID";
            dataGridView4.Columns[1].HeaderText = "Фамилия клиента";
            dataGridView4.Columns[2].HeaderText = "Фамилия мастера";
            dataGridView4.Columns[3].HeaderText = "Название услуги";
            dataGridView4.Columns[4].HeaderText = "Дата записи";
        }

        public void Svyz()
        {
            adapter = new MySqlDataAdapter("SELECT * FROM Parikmaher.Svyz", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Svyz");
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                    MessageBox.Show("Заполните все поля!");
                else
                {
                    command = new MySqlCommand("INSERT INTO Parikmaher.Client(familiy, imy, otchestvo) " +
                        "VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "')", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    Client();
                    MessageBox.Show("Добавлено");
                }
            }
            catch(Exception) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (id_client == 0)
                    MessageBox.Show("Вы ничего не выбрали!");
                else
                {
                    if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                        MessageBox.Show("Заполните все поля!");
                    else
                    {
                        command = new MySqlCommand("UPDATE Parikmaher.Client SET familiy = '" + textBox1.Text + "', imy = '" + textBox2.Text +
                            "', otchestvo = '" + textBox3.Text + "' WHERE id = " + id_client, connection);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        Client();
                        id_client = 0;
                        MessageBox.Show("Изменено");
                    }
                }
            }
            catch(Exception) { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (id_client == 0)
                    MessageBox.Show("Вы ничего не выбрали!");
                else
                {
                    command = new MySqlCommand("DELETE FROM Parikmaher.Client WHERE id = " + id_client, connection);
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
                if (textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
                    MessageBox.Show("Заполните все поля!");
                else
                {
                    command = new MySqlCommand("INSERT INTO Parikmaher.Master(familiy, imy, otchestvo, stazh) " +
                        "VALUES ('" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "', " + textBox6.Text + ")", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    Master();
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
            }
            catch (Exception) { }
        }

        private void dataGridView2_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                id_master = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
                textBox4.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                textBox5.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                textBox6.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
                textBox7.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
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
            }
            catch(Exception) { }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (id_master == 0)
                    MessageBox.Show("Вы ничего не выбрали!");
                else
                {
                    if (textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
                        MessageBox.Show("Заполните все поля!");
                    else
                    {
                        command = new MySqlCommand("UPDATE Parikmaher.Master SET familiy = '" + textBox4.Text + "', imy = '" + textBox5.Text +
                            "', otchestvo = '" + textBox6.Text + "', stazh = " + textBox7.Text + " WHERE id = " + id_master, connection);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        Master();
                        id_master = 0;
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
                if (id_master == 0)
                    MessageBox.Show("Вы ничего не выбрали!");
                else
                {
                    command = new MySqlCommand("DELETE FROM Parikmaher.Master WHERE id = " + id_master, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    Master();
                    id_client = 0;
                    MessageBox.Show("Удалено");
                }
            }
            catch (Exception) { }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox8.Text == "" || textBox9.Text == "" || textBox10.Text == "")
                    MessageBox.Show("Заполните все поля!");
                else
                {
                    command = new MySqlCommand("INSERT INTO Parikmaher.Usluga(nazvanie, stoimost, opisanie) " +
                        "VALUES ('" + textBox8.Text + "', " + textBox9.Text + ", '" + textBox10.Text + "')", connection);
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
                    MessageBox.Show("Вы ничего не выбрали!");
                else
                {
                    if (textBox8.Text == "" || textBox9.Text == "" || textBox10.Text == "")
                        MessageBox.Show("Заполните все поля!");
                    else
                    {
                        command = new MySqlCommand("UPDATE Parikmaher.Usluga SET nazvanie = '" + textBox8.Text + "', stoimost = " + 
                            textBox9.Text + ", opisanie = '" + textBox10.Text + "' WHERE id = " + id_usluga, connection);
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
                    MessageBox.Show("Вы ничего не выбрали!");
                else
                {
                    command = new MySqlCommand("DELETE FROM Parikmaher.Usluga WHERE id = " + id_usluga, connection);
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