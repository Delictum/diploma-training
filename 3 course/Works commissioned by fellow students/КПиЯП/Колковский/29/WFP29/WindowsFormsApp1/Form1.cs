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
        public int id_sdelki = 0;
        public int id_svyz = 0;
        public int id_uslugi = 0;

        public Form1()
        {
            InitializeComponent();
            Client();
            Sdelki();
            Svyz();
            Uslugi();
        }

        public void Client()
        {
            adapter = new MySqlDataAdapter("SELECT * FROM KOL.Client", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Client");
            connection.Close();
            dataGridView1.DataSource = ds.Tables["Client"];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Наименование";
            dataGridView1.Columns[2].HeaderText = "Вид работы";
            dataGridView1.Columns[3].HeaderText = "Адресс";
            dataGridView1.Columns[4].HeaderText = "Телефон";
            dataGridView1.Columns[0].Visible = false;
            comboBox1.DataSource = ds.Tables["Client"];
            comboBox1.DisplayMember = "id";
            comboBox1.ValueMember = "id";
        }

        public void Sdelki()
        {
            adapter = new MySqlDataAdapter("SELECT Sdelki.id, Client.name, Uslugi.name, sum, komis, Sdelki.opis FROM KOL.Sdelki, " +
                "KOL.Client, KOL.Uslugi, KOL.Svyz WHERE Sdelki.id = Client.id AND Sdelki.id = Svyz.id AND Uslugi.id = Svyz.id", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Sdelki");
            connection.Close();
            dataGridView2.DataSource = ds.Tables["Sdelki"];
            dataGridView2.Columns[0].HeaderText = "ID";
            dataGridView2.Columns[1].HeaderText = "Наименование клиента";
            dataGridView2.Columns[2].HeaderText = "Наименование услуги";
            dataGridView2.Columns[3].HeaderText = "Сумма";
            dataGridView2.Columns[4].HeaderText = "Комиссия";
            dataGridView2.Columns[5].HeaderText = "Описание";
            dataGridView2.Columns[0].Visible = false;
            comboBox3.DataSource = ds.Tables["Sdelki"];
            comboBox3.DisplayMember = "id";
            comboBox3.ValueMember = "id";
            comboBox4.DataSource = ds.Tables["Sdelki"];
            comboBox4.DisplayMember = "id";
            comboBox4.ValueMember = "id";
        }

        public void Svyz()
        {
            adapter = new MySqlDataAdapter("SELECT Svyz.id, Client.name, Uslugi.name FROM KOL.Sdelki, KOL.Uslugi, KOL.Svyz, KOL.Client " +
                "WHERE Sdelki.id = Svyz.id AND Uslugi.id = Svyz.id AND Sdelki.id = Client.id", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Svyz");
            connection.Close();
            dataGridView4.DataSource = ds.Tables["Svyz"];
            dataGridView4.Columns[0].HeaderText = "ID";
            dataGridView4.Columns[1].HeaderText = "Наименование клиента";
            dataGridView4.Columns[2].HeaderText = "Наименование услуги";
            dataGridView4.Columns[0].Visible = false;
            comboBox2.DataSource = ds.Tables["Svyz"];
            comboBox2.DisplayMember = "id";
            comboBox2.ValueMember = "id";
        }

        public void Uslugi()
        {
            adapter = new MySqlDataAdapter("SELECT Uslugi.id, Sdelki.opis, Uslugi.name, Uslugi.opis FROM KOL.Uslugi, KOL.Svyz, KOL.Sdelki " +
                "WHERE Svyz.id = Uslugi.id AND Svyz.id = Sdelki.id", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Uslugi");
            dataGridView3.DataSource = ds.Tables["Uslugi"];
            dataGridView3.Columns[0].HeaderText = "ID";
            dataGridView3.Columns[1].HeaderText = "Описание сделки";
            dataGridView3.Columns[2].HeaderText = "Наименование услуги";
            dataGridView3.Columns[3].HeaderText = "Описание услуги";
            dataGridView3.Columns[0].Visible = false;
            connection.Close();
            comboBox5.DataSource = ds.Tables["Uslugi"];
            comboBox5.DisplayMember = "id";
            comboBox5.ValueMember = "id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                MessageBox.Show("Заполните все поля!");
            else
            {
                command = new MySqlCommand("INSERT INTO KOL.Client(name, vid, adress, telphone) " +
                    "VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', " + textBox4.Text + ")", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                Client();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (id_client == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            else
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                    MessageBox.Show("Заполните все поля!");
                else
                {
                    command = new MySqlCommand("UPDATE KOL.Client SET name = '" + textBox1.Text + "', vid = '" + textBox2.Text +
                        "', adress = '" + textBox3.Text + "', telphone = " + textBox4.Text + " WHERE id = " + id_client, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    Client();
                    id_client = 0;
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_client = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (id_client == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            else
            {
                command = new MySqlCommand("DELETE FROM KOL.Client WHERE id = " + id_client, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                Client();
                id_client = 0;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
                MessageBox.Show("Заполните все поля!");
            else
            {
                command = new MySqlCommand("INSERT INTO KOL.Sdelki(id_client, id_svyz, sum, komis, opis) " +
                    "VALUES (" + comboBox1.Text + ", " + comboBox2.Text + ", " + textBox5.Text + ", " + 
                    textBox6.Text + ", '" + textBox7.Text + "')", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                Sdelki();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (id_sdelki == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            else
            {
                if (textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
                    MessageBox.Show("Заполните все поля!");
                else
                {
                    command = new MySqlCommand("UPDATE KOL.Sdelki SET id_client = " + comboBox1.Text + ", id_svyz = " + 
                        comboBox2.Text + ", sum = " + textBox5.Text + ", komis = " + textBox6.Text + ", opis = '" + 
                        textBox4.Text + "' WHERE id = " + id_sdelki, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    Sdelki();
                    id_sdelki = 0;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (id_sdelki == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            else
            {
                command = new MySqlCommand("DELETE FROM KOL.Client WHERE id = " + id_sdelki, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                Sdelki();
                id_sdelki = 0;
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_sdelki = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
            textBox5.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            textBox6.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            textBox7.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_uslugi = Convert.ToInt32(dataGridView3.CurrentRow.Cells[0].Value);
            textBox8.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            textBox9.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox8.Text == "" || textBox9.Text == "")
                MessageBox.Show("Заполните все поля!");
            else
            {
                command = new MySqlCommand("INSERT INTO KOL.Uslugi(id_svyz, name, opis) VALUES (" + 
                    comboBox3.Text + ", '" + textBox8.Text + "', '" + textBox9.Text + "')", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                Uslugi();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox8.Text == "" || textBox9.Text == "")
                MessageBox.Show("Заполните все поля!");
            if (id_uslugi == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            else
            {
                command = new MySqlCommand("UPDATE KOL.Uslugi SET id_svyz = " + comboBox3.Text + ", name = '" +
                        textBox8.Text + "', sum = '" + textBox9.Text + "' WHERE id = " + id_uslugi, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                Uslugi();
                id_uslugi = 0;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (id_uslugi == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            else
            {
                command = new MySqlCommand("DELETE FROM KOL.Uslugi WHERE id = " + id_uslugi, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                Uslugi();
                id_uslugi = 0;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            command = new MySqlCommand("INSERT INTO KOL.Svyz(id_sdelki, id_uslugi) VALUES (" +
                comboBox4.Text + ", " + comboBox5.Text + ")", connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            Svyz();
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_svyz = Convert.ToInt32(dataGridView4.CurrentRow.Cells[0].Value);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (id_svyz == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            else
            {
                command = new MySqlCommand("UPDATE KOL.Svyz SET id_sdelki = " + comboBox4.Text + 
                    ", id_uslugi = " + comboBox5.Text + " WHERE id = " + id_svyz, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                Svyz();
                id_svyz = 0;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (id_svyz == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            else
            {
                command = new MySqlCommand("DELETE FROM KOL.Svyz WHERE id = " + id_svyz, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                Svyz();
                id_svyz = 0;
            }
        }

        private void опрограммеToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.ShowDialog();
        }

        private void эксэльToolStripMenuItem_Click(object sender, EventArgs e)
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
    }
}
