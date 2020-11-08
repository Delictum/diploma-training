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

        public Form2(Form1 parent, string caption)
        {
            InitializeComponent();

            this.MdiParent = parent;
            this.Text = caption;

            switch (this.Text)
            {
                case "Детали":
                    {
                        Detali();
                        break;
                    }
                case "Поставщик":
                    {
                        Postavshik();
                        break;
                    }
                case "Поставки":
                    {
                        Postavki();
                        break;
                    }
            }
        }

        public void Detali()
        {
            adapter = new MySqlDataAdapter("SELECT * FROM Firma.Detali", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Detali");
            connection.Close();
            dataGridView1.DataSource = ds.Tables["Detali"];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Название";
            dataGridView1.Columns[2].HeaderText = "Артикул";
            dataGridView1.Columns[3].HeaderText = "Цена";
            dataGridView1.Columns[4].HeaderText = "Примечание";
            dataGridView1.Columns[0].Visible = false;
        }

        public void Postavshik()
        {
            adapter = new MySqlDataAdapter("SELECT * FROM Firma.Postavshik", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Postavshik");
            connection.Close();
            dataGridView1.DataSource = ds.Tables["Postavshik"];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Название";
            dataGridView1.Columns[2].HeaderText = "Адрес";
            dataGridView1.Columns[3].HeaderText = "Телефон";
            dataGridView1.Columns[0].Visible = false;
        }

        public void Postavki()
        {
            adapter = new MySqlDataAdapter("SELECT Postavki.id, Postavshik.name, Detali.name, kolichestvo, data FROM Firma.Postavki, " +
                "Firma.Detali, Firma.Postavshik WHERE Postavki.id = Detali.id AND Postavki.id = Postavshik.id", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Postavki");
            connection.Close();
            dataGridView1.DataSource = ds.Tables["Postavki"];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Название поставщика";
            dataGridView1.Columns[2].HeaderText = "Название детали";
            dataGridView1.Columns[0].Visible = false;
        }
    }
}
