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

namespace ClinicOfVision
{
    public partial class Form3 : Form
    {
        public MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=");
        public MySqlDataAdapter adapter;
        public MySqlCommand command;
        public int id;

        public Form3(int id_)
        {
            id = id_;
            InitializeComponent();            
        }

        public void MedicalRecordCB()
        {
            adapter = new MySqlDataAdapter("SELECT * FROM ClinicOfVision.MedicalRecord", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "MedicalRecord");
            connection.Close();
            comboBox1.DataSource = ds.Tables["MedicalRecord"];
            comboBox1.DisplayMember = "passport_series";
            comboBox1.ValueMember = "passport_series";
            comboBox2.DataSource = ds.Tables["MedicalRecord"];
            comboBox2.DisplayMember = "passport_numbers";
            comboBox2.ValueMember = "passport_numbers";
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            if (this.Text == "Добавление мед. карты")
            {
                label1.Text = "Серия паспорта";
                label2.Text = "Номер паспорта";
                label3.Text = "Адрес";
                label4.Text = "Диагнозы";
                label5.Text = "Консультации";
                label6.Text = "Лечения";
                label7.Text = "Осмотры";
                button1.Text = "Добавить";

                label8.Visible = false;
                comboBox1.Visible = false;
                comboBox2.Visible = false;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                Height = 120;
            }
            else if (this.Text == "Добавление клиента")
            {
                label1.Text = "Фамилия";
                label2.Text = "Имя";
                label3.Text = "Отчество";
                button1.Text = "Добавить";
                label8.Text = "Паспортные данные";

                label8.Visible = true;
                comboBox1.Visible = true;
                comboBox2.Visible = true;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                richTextBox1.Visible = false;
                richTextBox2.Visible = false;
                richTextBox3.Visible = false;
                richTextBox4.Visible = false;
                Height = 120;

                MedicalRecordCB();
            }
            else if (this.Text == "Редактирование мед. карты")
            {
                label1.Text = "Серия паспорта";
                label2.Text = "Номер паспорта";
                label3.Text = "Адрес";
                label4.Text = "Диагнозы";
                label5.Text = "Консультации";
                label6.Text = "Лечения";
                label7.Text = "Осмотры";
                button1.Text = "Редактировать";

                label8.Visible = false;
                comboBox1.Visible = false;
                comboBox2.Visible = false;
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                richTextBox1.Visible = true;
                richTextBox2.Visible = true;
                richTextBox3.Visible = true;
                richTextBox4.Visible = true;
                Height = 385;
            }
            else if (this.Text == "Редактирование клиента")
            {
                label1.Text = "Фамилия";
                label2.Text = "Имя";
                label3.Text = "Отчество";
                button1.Text = "Добавить";
                label8.Text = "Паспортные данные";
                button1.Text = "Редактировать";

                label8.Visible = true;
                comboBox1.Visible = true;
                comboBox2.Visible = true;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                richTextBox1.Visible = false;
                richTextBox2.Visible = false;
                richTextBox3.Visible = false;
                richTextBox4.Visible = false;
                Height = 120;

                MedicalRecordCB();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Text == "Добавление мед. карты")
                {
                    if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                        MessageBox.Show("Заполните все поля");
                    else
                    {
                        command = new MySqlCommand("INSERT INTO ClinicOfVision.MedicalRecord(passport_series, passport_numbers, " +
                            "adress, diagnosis, consultation, treatment, inspection) VALUES ('" + textBox1.Text + "', " +
                            textBox2.Text + ", '" + textBox3.Text + "', 'Отсутствуют', 'Отсутствуют', 'Отсутствуют', 'Отсутствуют')", connection);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        MessageBox.Show("Запись добавлена!", "Успешно!", MessageBoxButtons.OK);
                    }
                }
                else if (this.Text == "Добавление клиента")
                {
                    if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                        MessageBox.Show("Заполните все поля");
                    else
                    {
                        adapter = new MySqlDataAdapter("SELECT id_med_record FROM ClinicOfVision.MedicalRecord WHERE passport_series  = '" +
                            comboBox1.Text + "' AND passport_numbers = " + comboBox2.Text + ")", connection);
                        connection.Open();
                        DataSet ds = new DataSet();
                        adapter.Fill(ds, "MedicalRecord");
                        connection.Close();
                        comboBox3.DataSource = ds.Tables["MedicalRecord"];
                        comboBox3.DisplayMember = "id_med_record";
                        comboBox3.ValueMember = "id_med_record";
                        comboBox3.SelectedIndex = 0;
                        id = Convert.ToInt32(comboBox3.Text);

                        command = new MySqlCommand("INSERT INTO ClinicOfVision.Client(id_med_record, last_name, first_name, sure_name) " +
                            "VALUES (" + id + ", '" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "')", connection);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        MessageBox.Show("Запись добавлена!", "Успешно!", MessageBoxButtons.OK);
                    }
                }
                else if (this.Text == "Редактирование мед. карты")
                {
                    if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || richTextBox1.Text == ""
                        || richTextBox2.Text == "" || richTextBox3.Text == "" || richTextBox4.Text == "")
                        MessageBox.Show("Заполните все поля");
                    else
                    {
                        command = new MySqlCommand("UPDATE ClinicOfVision.MedicalRecord SET passport_series = '" + textBox1.Text + 
                            "', passport_numbers = " + textBox2.Text + ", adress = '" + textBox3.Text + "', diagnosis = '" + richTextBox1.Text +
                             "', consultation = '" + richTextBox2.Text + "', treatment = '" + richTextBox3.Text + "', inspection = '" +
                             richTextBox4.Text + "' WHERE id_med_record = " + id, connection);

                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        MessageBox.Show("Запись изменена!", "Успешно!", MessageBoxButtons.OK);
                    }
                }
                else if (this.Text == "Редактирование клиента")
                {
                    if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                        MessageBox.Show("Заполните все поля");
                    else
                    {
                        command = new MySqlCommand("SELECT * FROM ClinicOfVision.MedicalRecord WHERE passport_series  = '" +
                            comboBox1.Text + "' AND passport_numbers = " + comboBox2.Text + ")", connection);                       
                        connection.Open();                        
                        DataSet ds = new DataSet();                        
                        adapter.Fill(ds, "MedicalRecord");                        
                        connection.Close();
                        comboBox3.DataSource = ds.Tables["MedicalRecord"];
                        comboBox3.DisplayMember = "id_med_record";
                        comboBox3.ValueMember = "id_med_record";
                        int temp = Convert.ToInt32(comboBox3.Text);
                        MessageBox.Show(Convert.ToString(temp));  

                        command = new MySqlCommand("UPDATE ClinicOfVision.Client SET id_med_record = " + temp + ", last_name = '" + textBox1.Text +
                            "', first_name = " + textBox2.Text + ", sure_name = '" + textBox3.Text + "' WHERE id_client = " + id, connection);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        MessageBox.Show("Запись изменена!", "Успешно!", MessageBoxButtons.OK);
                    }
                }
                this.Close();
            }
            catch (Exception)
            {
                MedicalRecordCB();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = comboBox2.SelectedIndex;
        }
    }
}
