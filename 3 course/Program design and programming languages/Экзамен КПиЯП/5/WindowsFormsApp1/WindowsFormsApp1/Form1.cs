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
        public MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=");
        public MySqlDataAdapter adapter;
        public MySqlCommand command;

        public int id;

        public Form1()
        {
            InitializeComponent();
        }

        public void client()
        {
            adapter = new MySqlDataAdapter("SELECT * FROM ИМЯ_БД.СТУДЕНТ", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "client");
            connection.Close();
            dataGridView1.DataSource = ds.Tables["client"];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Фамилия";
            dataGridView1.Columns[2].HeaderText = "Имя";
            dataGridView1.Columns[3].HeaderText = "Отчество";
            dataGridView1.Columns[4].HeaderText = "Дата рождения";
            dataGridView1.Columns[5].HeaderText = "Адрес";
            dataGridView1.Columns[6].HeaderText = "Серия паспорта";
            dataGridView1.Columns[0].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                MessageBox.Show("Заполните поля!");
            else
            {
                command = new MySqlCommand("INSERT INTO ИМЯ_БД.СТУДЕНТ(id, Фамилия, Имя, Отчество, Дата рождения, Адрес, Серия паспорта) " +
                    "VALUES (" + (Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value) + 1).ToString() + ", '" +
                    textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "'" + textBox4.Text + 
                    "'" + textBox5.Text + "'" + textBox6.Text + "')", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (id == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            else
            {
                if (textBox1.Text == "")
                    MessageBox.Show("Заполните поле!");
                else
                {
                    command = new MySqlCommand("UPDATE ИМЯ_БД.СТУДЕНТ SET Фамилия = '" + textBox1.Text +
                        "', Имя = '" + textBox2.Text + "', Отчество = '" + textBox3.Text + "', Дата рождения = '" +
                        textBox4.Text + "', Адрес = '" + textBox5.Text + "', Серия паспорта = '" + textBox6.Text + "'WHERE id = " + id, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    id = 0;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (id == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            else
            {
                command = new MySqlCommand("DELETE FROM ИМЯ_БД.СТУДЕНТ WHERE id = '" + id + "'", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                id = 0;
            }
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            id = int.Parse(dataGridView1.SelectedCells.ToString());
        }
    }
}
