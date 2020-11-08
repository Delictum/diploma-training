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

        public int id_prepodavateli = 0;
        public int id_grupi = 0;
        public int id_nagruzka = 0;

        public Form1()
        {
            InitializeComponent();
            Prepodavateli();
            Grupi();
            Nagruzka();
        }

        public void Prepodavateli()
        {
            adapter = new MySqlDataAdapter("SELECT * FROM KursiKvalifikacii.Prepodavateli", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Prepodavateli");
            connection.Close();
            dataGridView1.DataSource = ds.Tables["Prepodavateli"];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Фамилия";
            dataGridView1.Columns[2].HeaderText = "Имя";
            dataGridView1.Columns[3].HeaderText = "Отчество";
            dataGridView1.Columns[4].HeaderText = "Телефон";
            dataGridView1.Columns[4].HeaderText = "Стаж";
            comboBox1.DataSource = ds.Tables["Prepodavateli"];
            comboBox1.DisplayMember = "familiy";
            comboBox1.ValueMember = "familiy";
        }

        public void Grupi()
        {
            adapter = new MySqlDataAdapter("SELECT * FROM KursiKvalifikacii.Grupi", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Grupi");
            connection.Close();
            dataGridView2.DataSource = ds.Tables["Grupi"];
            dataGridView2.Columns[0].HeaderText = "ID";
            dataGridView2.Columns[1].HeaderText = "Специальность";
            dataGridView2.Columns[2].HeaderText = "Отделение";
            dataGridView2.Columns[3].HeaderText = "Количество студентов";
            comboBox2.DataSource = ds.Tables["Grupi"];
            comboBox2.DisplayMember = "cpecialnost";
            comboBox2.ValueMember = "cpecialnost";
        }

        public void Nagruzka()
        {
            adapter = new MySqlDataAdapter("SELECT id_nagruzka, familiy, cpecialnost, chasi, predmet, tip, oplata FROM KursiKvalifikacii.Nagruzka, " +
                "KursiKvalifikacii.Prepodavateli, KursiKvalifikacii.Grupi WHERE" +
                " Nagruzka.id_prepodavateli = Prepodavateli.id_prepodavateli AND Nagruzka.id_grupi = Grupi.id_grupi ORDER BY id_nagruzka ASC", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Nagruzka");
            connection.Close();
            dataGridView3.DataSource = ds.Tables["Nagruzka"];
            dataGridView3.Columns[0].HeaderText = "ID";
            dataGridView3.Columns[1].HeaderText = "Преподаватель";
            dataGridView3.Columns[2].HeaderText = "Специальность";
            dataGridView3.Columns[3].HeaderText = "Часы";
            dataGridView3.Columns[4].HeaderText = "Тип";
            dataGridView3.Columns[5].HeaderText = "Оплата";
            comboBox3.DataSource = ds.Tables["Nagruzka"];
            comboBox3.DisplayMember = "tip";
            comboBox3.ValueMember = "tip";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
                MessageBox.Show("Заполните все поля!");
            else
            {
                command = new MySqlCommand("INSERT INTO KursiKvalifikacii.Prepodavateli(familiy, imy, otchestvo, telphone, stazh) " +
                    "VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', " + textBox4.Text + ", " + textBox5.Text + ")", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                Prepodavateli();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (id_prepodavateli == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            else
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
                    MessageBox.Show("Заполните все поля!");
                else
                {
                    command = new MySqlCommand("UPDATE KursiKvalifikacii.Prepodavateli SET familiy = '" + textBox1.Text + "', imy = '" + textBox2.Text +
                        "', otchestvo = '" + textBox3.Text + "', telphone = " + textBox4.Text + ", stazh = " + textBox5.Text + 
                        " WHERE id_prepodavateli = " + id_prepodavateli, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    Prepodavateli();
                    id_prepodavateli = 0;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (id_prepodavateli == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            else
            {
                command = new MySqlCommand("DELETE FROM KursiKvalifikacii.Prepodavateli WHERE id_prepodavateli = '" + id_prepodavateli + "'", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                Prepodavateli();
                id_prepodavateli = 0;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "")
                MessageBox.Show("Заполните все поля!");
            else
            {
                command = new MySqlCommand("INSERT INTO KursiKvalifikacii.Grupi(cpecialnost, otdelenie, studenti) " +
                    "VALUES ('" + textBox6.Text + "', " + textBox7.Text + ", " + textBox8.Text + ")", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                Grupi();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (id_nagruzka == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            if (textBox9.Text == "" || textBox10.Text == "" || textBox11.Text == "")
                MessageBox.Show("Заполните все поля!");
            else
            {
                command = new MySqlCommand("SELECT id_prepodavateli FROM KursiKvalifikacii.Prepodavateli WHERE familiy  = '" + comboBox1.Text + "')", connection);
                connection.Open();
                DataSet ds1 = new DataSet();
                adapter.Fill(ds1, "Prepodavateli");
                connection.Close();
                dataGridView3.DataSource = ds1.Tables["Prepodavateli"];
                int temp1 = Convert.ToInt32(dataGridView3.Rows[0].Cells[0].Value);

                command = new MySqlCommand("SELECT id_grupi FROM KursiKvalifikacii.Grupi WHERE cpecialnost  = '" + comboBox2.Text + "')", connection);
                connection.Open();
                DataSet ds2 = new DataSet();
                adapter.Fill(ds2, "Grupi");
                connection.Close();
                dataGridView3.DataSource = ds2.Tables["Grupi"];
                int temp2 = Convert.ToInt32(dataGridView3.Rows[0].Cells[0].Value);

                command = new MySqlCommand("UPDATE KursiKvalifikacii.Nagruzka SET id_prepodavateli = " + temp1 + ", id_grupi = " + temp2 +
                    ", chasi = " + textBox9.Text + ", predmet = " + textBox10.Text + ", tip = '" + comboBox3.Text +
                    "', oplata = " + textBox11.Text + " WHERE id_nagruzka = " + id_nagruzka, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                Nagruzka();
                id_nagruzka = 0;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (id_nagruzka == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            else
            {
                command = new MySqlCommand("DELETE FROM KursiKvalifikacii.Nagruzka WHERE id_nagruzka = '" + id_nagruzka + "'", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                Nagruzka();
                id_nagruzka = 0;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (id_grupi == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            else
            {
                if (textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "")
                    MessageBox.Show("Заполните все поля!");
                else
                {
                    command = new MySqlCommand("UPDATE KursiKvalifikacii.Grupi SET cpecialnost = '" + textBox6.Text + "', otdelenie = " + textBox7.Text +
                        ", studenti = " + textBox8.Text + " WHERE id_grupi = " + id_grupi, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    Grupi();
                    id_grupi = 0;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (id_grupi == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            else
            {
                command = new MySqlCommand("DELETE FROM KursiKvalifikacii.Grupi WHERE id_grupi = '" + id_grupi + "'", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                Grupi();
                id_grupi = 0;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_prepodavateli = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_grupi = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
            textBox6.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            textBox7.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            textBox8.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_nagruzka = Convert.ToInt32(dataGridView3.CurrentRow.Cells[0].Value);
            comboBox1.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            comboBox2.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
            textBox9.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString();
            textBox10.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString();
            comboBox3.Text = dataGridView3.CurrentRow.Cells[5].Value.ToString();
            textBox11.Text = dataGridView3.CurrentRow.Cells[6].Value.ToString();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox9.Text == "" || textBox10.Text == "" || textBox11.Text == "")
                MessageBox.Show("Заполните все поля!");
            else
            {
                command = new MySqlCommand("SELECT id_prepodavateli FROM KursiKvalifikacii.Prepodavateli WHERE familiy  = '" + comboBox1.Text + "')", connection);
                connection.Open();
                DataSet ds1 = new DataSet();
                adapter.Fill(ds1, "Prepodavateli");
                connection.Close();
                dataGridView3.DataSource = ds1.Tables["Prepodavateli"];
                int temp1 = Convert.ToInt32(dataGridView3.Rows[0].Cells[0].Value);

                command = new MySqlCommand("SELECT id_grupi FROM KursiKvalifikacii.Grupi WHERE cpecialnost  = '" + comboBox2.Text + "')", connection);
                connection.Open();
                DataSet ds2 = new DataSet();
                adapter.Fill(ds2, "Grupi");
                connection.Close();
                dataGridView3.DataSource = ds2.Tables["Grupi"];
                int temp2 = Convert.ToInt32(dataGridView3.Rows[0].Cells[0].Value);

                command = new MySqlCommand("INSERT INTO KursiKvalifikacii.Nagruzka(id_prepodavateli, id_grupi, chasi, predmet, tip, oplata) " +
                    "VALUES (" + temp1 + ", " + temp2 + ", " + textBox9.Text + ", '" + textBox10.Text + "', '" + comboBox3.Text + "', " + textBox11.Text + ")", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                Nagruzka();
            }
        }
    }
}