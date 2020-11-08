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
            Detali();
            Postavshik();
            Postavki();
        }

        public void Detali()
        {
            adapter = new MySqlDataAdapter("SELECT * FROM Firma.Detali", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Detali");
            connection.Close();
        }

        public void Postavshik()
        {
            adapter = new MySqlDataAdapter("SELECT * FROM Firma.Postavshik", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Postavshik");
            connection.Close();
        }

        public void Postavki()
        {
            adapter = new MySqlDataAdapter("SELECT Postavki.id, Postavshik.name, Detali.name FROM Firma.Postavki, " +
                "Firma.Detali, Firma.Postavshik WHERE Postavki.id = Detali.id AND Postavki.id = Postavshik.id", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Postavki");
            connection.Close();
        }
    }
}
