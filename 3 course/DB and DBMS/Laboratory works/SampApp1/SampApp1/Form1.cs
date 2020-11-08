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
        }

        MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=mysql;password=mysql;database=sampapp1");


        public void Table()
        {
            try
            {
                connection.Close();
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM `testsampapp`", connection);
                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "TestSampApp");
                dataGridView1.DataSource = ds.Tables["TestSampApp"];
                connection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            Microsoft.Data.ConnectionUI.DataConnectionDialog dlg =
            new Microsoft.Data.ConnectionUI.DataConnectionDialog();
            Microsoft.Data.ConnectionUI.DataSource.AddStandardDataSources(dlg);
            Microsoft.Data.ConnectionUI.DataConnectionDialog.Show(dlg);
            listBoxTest.Items.Add("Строка соединения:" + dlg.ConnectionString);
            connection.ConnectionString = dlg.ConnectionString;
            try
            {
                listBoxTest.Items.Add("Соединение открыто");
                connection.Open();
            }
            catch (Exception ex)
            {
                listBoxTest.Items.Add("Ошибка соединения");
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
                listBoxTest.Items.Add("Соединение закрыто");
            }

        }
    }
}
