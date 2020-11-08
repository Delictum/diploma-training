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
        static string strcon = "datasource=127.0.0.1;port=3306;username=mysql;password=mysql;database=parikmaher";
        MySqlConnection conn = new MySqlConnection(strcon);

        public Form1()
        {
            InitializeComponent();
            conn.ConnectionString = strcon;

            try
            {
                conn.Close();
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM `client`", conn);
                conn.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "client");
                dataGridView1.DataSource = ds.Tables["client"];
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    listBox1.Items.Add("Соединение закрыто");
                }
                else
                {
                    conn.Open();
                    listBox1.Items.Add("Соединение открыто");
                }
            }
            catch (Exception ex)
            {
                listBox1.Items.Add("Ошибка соединения" + ex);
            }
        }
    }
}
