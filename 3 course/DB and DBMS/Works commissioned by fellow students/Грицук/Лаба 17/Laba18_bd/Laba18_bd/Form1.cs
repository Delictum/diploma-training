using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba18_bd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabl1();
            tabl2();
            tabl3();
        }

        MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3303;username=mysql;password=mysql;database=Laba25");
        public void tabl1()
        {
            try
            {
                connection.Close();
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM `Pokupateli`", connection);
                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Pokupateli");
                dataGridView1.DataSource = ds.Tables["Pokupateli"];
                connection.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void tabl2()
        {
            try
            {
                connection.Close();
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM `Sdelki`", connection);
                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Sdelki");
                dataGridView1.DataSource = ds.Tables["Sdelki"];
                connection.Close();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void tabl3()
        {
            try
            {
                connection.Close();
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM `Tovar`", connection);
                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Tovar");
                dataGridView1.DataSource = ds.Tables["Tovar"];
                connection.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
