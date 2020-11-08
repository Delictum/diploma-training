using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Kurs
{
    public partial class Form9 : Form
    {
        public MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=mysql;password=mysql;database=Kursach");
        public MySqlCommand command;
        public MySqlDataAdapter adapter;

        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox1.Text == "")
                {
                    MessageBox.Show("Заполните поля");
                    return;
                }
                adapter = new MySqlDataAdapter("SELECT log FROM Kursach.User WHERE User.log = '" + textBox1.Text + "'", connection);
                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "User");
                connection.Close();
                dataGridView1.DataSource = ds.Tables["User"];
                string temp1 = dataGridView1.Rows[0].Cells[0].Value.ToString();

                adapter = new MySqlDataAdapter("SELECT pass FROM Kursach.User WHERE User.log = '" + textBox1.Text +
                    "' AND User.pass = '" + textBox2.Text + "'", connection);
                connection.Open();
                DataSet ds1 = new DataSet();
                adapter.Fill(ds1, "User");
                connection.Close();
                dataGridView1.DataSource = ds1.Tables["User"];
                string temp2 = dataGridView1.Rows[0].Cells[0].Value.ToString();

                bool prava;
                if (textBox1.Text.ToLower() != "Admin".ToLower())                
                    prava = true;
                else
                    prava = false;
                Form1 form1 = new Form1(prava);
                form1.Show();
                this.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("Неверное имя пользователя или пароль");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form10 form10 = new Form10();
            form10.ShowDialog();
        }
    }
}
