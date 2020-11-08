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
        }
    }
}
