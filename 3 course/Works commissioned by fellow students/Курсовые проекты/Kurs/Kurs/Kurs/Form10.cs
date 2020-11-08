using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Kurs
{
    public partial class Form10 : Form
    {
        public MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=mysql;password=mysql;database=Kursach");
        public MySqlCommand command;
        public MySqlDataAdapter adapter;

        public int pass;
        public string log;
        public Form10()
        {
            InitializeComponent();
        }

        public void SendMail()
        {
            try
            {
                // отправитель - устанавливаем адрес и отображаемое в письме имя
                MailAddress from = new MailAddress("thedrakoneragoni@gmail.com", "Zakazi");
                // кому отправляем
                MailAddress to = new MailAddress(textBox2.Text);
                // создаем объект сообщения
                MailMessage m = new MailMessage(from, to);
                // тема письма
                m.Subject = "Авторизация";
                // текст письма
                m.Body = "<h2>Ваш логин: " + textBox1.Text + ". Ваш пароль: " + pass.ToString() + "</h2>";
                // письмо представляет код html
                m.IsBodyHtml = true;
                // адрес smtp-сервера и порт, с которого будем отправлять письмо
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                // логин и пароль
                smtp.Credentials = new NetworkCredential("thedrakoneragoni@gmail.com", "asd3Foxe26ie");
                smtp.EnableSsl = true;
                smtp.Send(m);
            }
            catch (Exception e)
            {
                throw new Exception("Mail.Send: " + e.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Заполните поля!");
                return;
            }
            Random rand = new Random();
            pass = rand.Next(100000, 1000000);
            log = textBox1.Text;
            SendMail();
            MessageBox.Show("Письмо выслано!", "Сообщение!", MessageBoxButtons.OK);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox3.Text == "")
                MessageBox.Show("Введите код из письма");
            else
            {
                try
                {
                    command = new MySqlCommand("INSERT INTO User(log, pass) VALUES ('" + log + "','" + textBox3.Text + "')", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Пользователь создан!", "Сообщение!", MessageBoxButtons.OK);
                    Form1 form1 = new Form1(true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
