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
        }

        public void Grupi()
        {
            adapter = new MySqlDataAdapter("SELECT * FROM KursiKvalifikacii.Grupi", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Grupi");
            connection.Close();            
        }

        public void Nagruzka()
        {
            adapter = new MySqlDataAdapter("SELECT id_nagruzka, familiy, otdelenie, chasi, predmet, tip, oplata FROM KursiKvalifikacii.Nagruzka, " +
                "KursiKvalifikacii.Prepodavateli, KursiKvalifikacii.Grupi WHERE" +
                " Nagruzka.id_prepodavateli = Prepodavateli.id_prepodavateli AND Nagruzka.id_grupi = Grupi.id_grupi ORDER BY id_nagruzka ASC", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Nagruzka");
            connection.Close();            
        }
    }
}
