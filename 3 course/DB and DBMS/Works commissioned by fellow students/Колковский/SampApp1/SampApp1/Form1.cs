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

namespace SampApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Table();
            conn.ConnectionString = strcon;
        }
        static string strcon = "datasource=127.0.0.1;port=3306;username=mysql;password=mysql;database=sampapp1";
        MySqlConnection conn = new MySqlConnection(strcon);


        public void Table()
        {
            try
            {
                conn.Close();
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM `testsampapp`", conn);
                conn.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "TestSampApp");
                dataGridView1.DataSource = ds.Tables["TestSampApp"];
                conn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ConnectToSql()
        {
            try
            {
                listBoxTest.Items.Add("Соединение открыто");
                conn.Open();
            }
            catch (Exception ex)
            {
                listBoxTest.Items.Add("Ошибка соединения");
                MessageBox.Show(ex.Message);
                listBoxTest.Items.Add("Сообщение :" + ex.Message);
                listBoxTest.Items.Add("Код ошибки:" + ex);
                conn.Close();
                listBoxTest.Items.Add("Соединение закрыто");
            }
            finally
            {
                conn.Close();
                listBoxTest.Items.Add("Соединение закрыто");
            }
        }


        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    listBoxTest.Items.Add("Соединение закрыто");
                }
                else
                {
                    conn.Open();
                    listBoxTest.Items.Add("Соединение открыто");
                }
            }
            catch (Exception ex)
            {
                listBoxTest.Items.Add("Ошибка соединения" + ex);
            }

        }
    }
}
