using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class AddChangeForm : Form
    {
        public int iIdRecordWorkers { get; set; }
        public int iIdRecordTypeOfWork { get; set; }
        public int iIdRecordWorks { get; set; }

        public AddChangeForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            string sSQL = "";
            String sConnectionString = "server=localhost;user=mysql;database=MyCompanyPractica;port=3303;password=mysql;";
            MySqlConnection ConnectionSQL = new MySqlConnection(sConnectionString);            

            if (iIdRecordWorkers == 0)
                sSQL = GetInsertSQLWorkers();
            else
            {                               
                sSQL = GetUpdateSQLWorkers(iIdRecordWorkers);
            }
                        
            MySqlCommand cmd = new MySqlCommand(sSQL, ConnectionSQL);
            ConnectionSQL.Open();
            cmd.ExecuteNonQuery();
            f1.RefreshSQL();
            ConnectionSQL.Close();
        }

        private string GetInsertSQLWorkers()
        {            
            string sSQL = "INSERT INTO Workers (Code_Workers, LastName_Wrokers, FirstName_Workers, Patronymic_Workers, Salary_Workers) VALUES (";
            sSQL += textBox1.Text + ",";
            sSQL += "'" + textBox2.Text + "', ";
            sSQL += "'" + textBox3.Text + "', ";
            sSQL += "'" + textBox4.Text + "', ";
            sSQL += textBox5.Text + ")";
            return sSQL;
        }

        private string GetUpdateSQLWorkers(int ID_Workers)
        {           
            string sSQL = "UPDATE Workers SET Code_Workers = ";
            sSQL += textBox1.Text + ",";
            sSQL += "LastName_Wrokers = '" + textBox2.Text + "',";
            sSQL += "FirstName_Workers = '" + textBox3.Text + "',";
            sSQL += "Patronymic_Workers = '" + textBox4.Text + "',";
            sSQL += "Salary_Workers = " + textBox5.Text + " ";
            sSQL += "WHERE ID_Workers = " + ID_Workers;
            return sSQL;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            string sSQL = "";
            String sConnectionString = "server=localhost;user=mysql;database=MyCompanyPractica;port=3303;password=mysql;";
            MySqlConnection ConnectionSQL = new MySqlConnection(sConnectionString);


            if (iIdRecordTypeOfWork == 0)
                sSQL = GetInsertSQLTypeOfWork();
            else
            {
                sSQL = GetUpdateSQLTypeOfWork(iIdRecordTypeOfWork);
            }

            MySqlCommand cmd = new MySqlCommand(sSQL, ConnectionSQL);
            ConnectionSQL.Open();
            cmd.ExecuteNonQuery();
            f1.RefreshSQL();
            ConnectionSQL.Close();
        }

        private string GetInsertSQLTypeOfWork()
        {
            string sSQL = "INSERT INTO TypeOfWork (Code_TypeOfWork , Description_TypeOfWork, Payment_TypeOfWork) VALUES (";
            sSQL += textBox6.Text + ",";
            sSQL += "'" + textBox7.Text + "', ";
            sSQL += textBox8.Text + ")";
            return sSQL;
        }

        private string GetUpdateSQLTypeOfWork(int ID_Workers)
        {
            string sSQL = "UPDATE TypeOfWork SET Code_TypeOfWork = ";
            sSQL += textBox6.Text + ", ";
            sSQL += "Description_TypeOfWork = '" + textBox7.Text + "',";
            sSQL += "Payment_TypeOfWork = " + textBox8.Text + " ";
            sSQL += "WHERE ID_TypeOfWork = " + ID_Workers;
            return sSQL;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            string sSQL = "";
            String sConnectionString = "server=localhost;user=mysql;database=MyCompanyPractica;port=3303;password=mysql;";
            MySqlConnection ConnectionSQL = new MySqlConnection(sConnectionString);

            if (iIdRecordTypeOfWork == 0)
                sSQL = GetInsertSQLWorks();
            else
            {
                sSQL = GetUpdateSQLWorks(iIdRecordWorks);
            }

            MySqlCommand cmd = new MySqlCommand(sSQL, ConnectionSQL);
            ConnectionSQL.Open();
            cmd.ExecuteNonQuery();
            f1.RefreshSQL();
            ConnectionSQL.Close();
        }

        private string GetInsertSQLWorks()
        {
            string sSQL = "INSERT INTO Works (Code_Workers, Code_TypeOfWork, StartDate_Works, EndDate_Works) VALUES (";
            sSQL += textBox10.Text + ",";
            sSQL += textBox11.Text + ",";
            sSQL += "'" + textBox12.Text + "', ";
            sSQL += "'" + textBox13.Text + "')";
            return sSQL;
        }

        private string GetUpdateSQLWorks(int ID_Workers)
        {
            Form1 f1 = new Form1();
            string sSQL = "UPDATE Works SET Code_Workers = ";
            sSQL += textBox10.Text + ", ";
            sSQL += "Code_TypeOfWork = " + textBox11.Text + ", ";
            sSQL += "StartDate_Works = '" + textBox12.Text + "', ";
            sSQL += "EndDate_Works = '" + textBox13.Text + "' ";
            sSQL += "WHERE ID_Works = " + ID_Workers;
            return sSQL;
        }

        private void AddChangeForm_Load(object sender, EventArgs e)
        {

        }
    }
}
