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
        }

        public void Sdelki()
        {
            adapter = new MySqlDataAdapter("SELECT Sdelki.id, Client.name, Uslugi.name, sum, komis, Sdelki.opis FROM KOL.Sdelki, " +
                "KOL.Client, KOL.Uslugi, KOL.Svyz WHERE Sdelki.id = Client.id AND Sdelki.id = Svyz.id AND Uslugi.id = Svyz.id", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Sdelki");
            connection.Close();            
        }

        public void Svyz()
        {
            adapter = new MySqlDataAdapter("SELECT Svyz.id, Client.name, Uslugi.name FROM KOL.Sdelki, KOL.Uslugi, KOL.Svyz, KOL.Client " +
                "WHERE Sdelki.id = Svyz.id AND Uslugi.id = Svyz.id AND Sdelki.id = Client.id", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Svyz");
            connection.Close();            
        }

        public void Uslugi()
        {
            adapter = new MySqlDataAdapter("SELECT Uslugi.id, Uslugi.name, Sdelki.opis FROM KOL.Uslugi, KOL.Svyz, KOL.Sdelki " +
                "WHERE Svyz.id = Uslugi.id AND Svyz.id = Sdelki.id", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Uslugi");
            connection.Close();
        }
    }
}
