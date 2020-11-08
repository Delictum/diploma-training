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
    public partial class Form2 : Form
    {
        public MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=");
        public MySqlDataAdapter adapter;
        public MySqlCommand command;

        public int id_client = 0;
        public int id_marsh = 0;

        public Form2(Form1 parent, string caption)
        {
            InitializeComponent();

            this.MdiParent = parent;
            this.Text = caption;

            switch (this.Text)
            {
                case "Клиент":
                    {
                        klient();
                        break;
                    }
                case "Заказ":
                    {
                        zakaz();
                        break;
                    }
                case "Маршрут":
                    {
                        marsh();
                        break;
                    }
                case "Вид товара":
                    {
                        tovar();
                        break;
                    }
                case "Водитель":
                    {
                        voditel();
                        break;
                    }
            }
        }

        public void klient()
        {
            adapter = new MySqlDataAdapter("SELECT * FROM TRPO.klient", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "klient");
            connection.Close();
            dataGridView1.DataSource = ds.Tables["klient"];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Фамилия";
            dataGridView1.Columns[2].HeaderText = "Имя";
            dataGridView1.Columns[3].HeaderText = "Отчество";
            dataGridView1.Columns[4].HeaderText = "Номер";
            dataGridView1.Columns[5].HeaderText = "Адрес";
            dataGridView1.Columns[0].Visible = false;
        }

        public void klient(string poisk)
        {
            try
            {
                adapter = new MySqlDataAdapter("SELECT * FROM TRPO.klient WHERE fam LIKE '" + poisk + "%' OR im LIKE '" + poisk +
                    "%' OR och LIKE '" + poisk + "%' OR nomer LIKE '" + poisk + "%' OR adres LIKE '" + poisk + "%'", connection);
                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "klient");
                connection.Close();
                dataGridView1.DataSource = ds.Tables["klient"];
                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[1].HeaderText = "Фамилия";
                dataGridView1.Columns[2].HeaderText = "Имя";
                dataGridView1.Columns[3].HeaderText = "Отчество";
                dataGridView1.Columns[4].HeaderText = "Номер";
                dataGridView1.Columns[5].HeaderText = "Адрес";
                dataGridView1.Columns[0].Visible = false;
            }
            catch(Exception) { }
        }

        public void zakaz()
        {
            adapter = new MySqlDataAdapter("SELECT id_zakaz, fam, adres, zakaz.nomer, data, podr FROM TRPO.zakaz, " +
                "TRPO.klient WHERE zakaz.id_klient = klient.id_klient", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "zakaz");
            connection.Close();
            dataGridView1.DataSource = ds.Tables["zakaz"];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Фамилия";
            dataGridView1.Columns[2].HeaderText = "Адрес";
            dataGridView1.Columns[3].HeaderText = "Номер";
            dataGridView1.Columns[4].HeaderText = "Дата";
            dataGridView1.Columns[5].HeaderText = "Объем";
            dataGridView1.Columns[0].Visible = false;
        }

        public void marsh()
        {
            adapter = new MySqlDataAdapter("SELECT * FROM TRPO.marsh", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "marsh");
            connection.Close();
            dataGridView1.DataSource = ds.Tables["marsh"];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Название";
            dataGridView1.Columns[2].HeaderText = "Продолжительность";
            dataGridView1.Columns[3].HeaderText = "Локальность";
            dataGridView1.Columns[0].Visible = false;
        }

        public void tovar()
        {
            adapter = new MySqlDataAdapter("SELECT * FROM TRPO.tovar", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "tovar");
            connection.Close();
            dataGridView1.DataSource = ds.Tables["tovar"];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Название";
            dataGridView1.Columns[2].HeaderText = "Изготовитель";
            dataGridView1.Columns[3].HeaderText = "Дизайн";
            dataGridView1.Columns[4].HeaderText = "Цена";
            dataGridView1.Columns[5].HeaderText = "Гарантия";
            dataGridView1.Columns[0].Visible = false;
        }

        public void voditel()
        {
            adapter = new MySqlDataAdapter("SELECT * FROM TRPO.voditel", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "voditel");
            connection.Close();
            dataGridView1.DataSource = ds.Tables["voditel"];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Фамилия";
            dataGridView1.Columns[2].HeaderText = "Имя";
            dataGridView1.Columns[3].HeaderText = "Отчество";
            dataGridView1.Columns[4].HeaderText = "Возраст";
            dataGridView1.Columns[5].HeaderText = "Стаж";
            dataGridView1.Columns[0].Visible = false;
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    ExcelApp.Cells[i + 1, j + 1] = dataGridView1.Rows[i].Cells[j].Value;
                }
            }
            ExcelApp.Visible = true;
            ExcelApp.UserControl = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            klient(textBox1.Text);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (this.Text == "Клиент")
            {
                textBox1.Visible = true;
                label1.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
            }
            if (this.Text == "Маршрут")
            {
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label2.Text = "Название";
                label3.Text = "Продолжительность";
                label4.Text = "Локальность";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Text == "Клиент")
                {
                    command = new MySqlCommand("INSERT INTO TRPO.klient(fam, im, och, nomer, adres) " +
                        "VALUES ('" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "')", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    klient();
                    MessageBox.Show("Добавлено");

                }
                else if (this.Text == "Маршрут")
                {
                    command = new MySqlCommand("INSERT INTO TRPO.marsh(naz, prodol, lokal) " +
                        "VALUES ('" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "')", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    marsh();
                    MessageBox.Show("Добавлено");
                }
            }
            catch(Exception) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Text == "Клиент")
                {
                    if (id_client == 0)
                    {
                        MessageBox.Show("Вы ничего не выбрали!");
                        return;
                    }
                    command = new MySqlCommand("UPDATE TRPO.klient SET fam = '" + textBox2.Text + "', im = '" + textBox3.Text +
                            "', och = '" + textBox4.Text + "', nomer = '" + textBox5.Text + "', adres = '" + textBox6.Text +
                            "' WHERE id_klient = " + id_client, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    klient();
                    id_client = 0;
                    MessageBox.Show("Изменено");
                }
                else if (this.Text == "Маршрут")
                {
                    if (id_marsh == 0)
                    {
                        MessageBox.Show("Вы ничего не выбрали!");
                        return;
                    }
                    command = new MySqlCommand("UPDATE TRPO.marsh SET naz = '" + textBox2.Text + "', prodol = '" + textBox3.Text +
                            "', lokal = '" + textBox4.Text + "' WHERE id_marshПервичный = " + id_marsh, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    marsh();
                    id_marsh = 0;
                    MessageBox.Show("Изменено");
                }
            }
            catch (Exception) { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Text == "Клиент")
                {
                    if (id_client == 0)
                    {
                        MessageBox.Show("Вы ничего не выбрали!");
                        return;
                    }
                    command = new MySqlCommand("DELETE FROM TRPO.klient WHERE id_klient = " + id_client, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    klient();
                    id_client = 0;
                    MessageBox.Show("Удалено");
                }
                else if (this.Text == "Маршрут")
                {
                    if (id_marsh == 0)
                    {
                        MessageBox.Show("Вы ничего не выбрали!");
                        return;
                    }
                    command = new MySqlCommand("DELETE FROM TRPO.marsh WHERE id_marsh = " + id_marsh, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    marsh();
                    id_marsh = 0;
                    MessageBox.Show("Удалено");
                }
            }
            catch (Exception) { }
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Text == "Клиент")
                {
                    id_client = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                }
                else if (this.Text == "Маршрут")
                {
                    id_marsh = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                }
            }
            catch(Exception) { }
        }
    }
}
