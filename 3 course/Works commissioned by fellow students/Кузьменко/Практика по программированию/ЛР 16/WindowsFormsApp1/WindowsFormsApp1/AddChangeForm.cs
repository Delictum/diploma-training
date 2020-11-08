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
        public int iIdRecordStudents { get; set; }
        public int iIdRecordObjects { get; set; }
        public int iIdRecordPlan { get; set; }
        public String sConnectionString = "server=localhost;user=mysql;database=MyPractica;port=3306;password=mysql;";

        public AddChangeForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            string sSQL = "";
            MySqlConnection ConnectionSQL = new MySqlConnection(sConnectionString);

            if (iIdRecordStudents == 0)
                sSQL = GetInsertSQLStudents();
            else
            {
                sSQL = GetUpdateSQLStudents(iIdRecordStudents);
            }

            MySqlCommand cmd = new MySqlCommand(sSQL, ConnectionSQL);
            ConnectionSQL.Open();
            cmd.ExecuteNonQuery();
            f1.RefreshSQL();
            ConnectionSQL.Close();
        }

        private string GetInsertSQLStudents()
        {
            string sSQL = "INSERT INTO Students (CodeS, FIO, Adress, Telephone) VALUES (";
            sSQL += textBox1.Text + ",";
            sSQL += "'" + textBox2.Text + "', ";
            sSQL += "'" + textBox3.Text + "', ";
            sSQL += "'" + textBox4.Text + "')";
            return sSQL;
        }

        private string GetUpdateSQLStudents(int ID_Students)
        {
            string sSQL = "UPDATE Students SET CodeS = ";
            sSQL += textBox1.Text + ",";
            sSQL += " FIO = '" + textBox2.Text + "',";
            sSQL += " Adress = '" + textBox3.Text + "',";
            sSQL += " Telephone = '" + textBox4.Text + "' ";
            sSQL += "WHERE ID = " + ID_Students;
            return sSQL;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            string sSQL = "";
            MySqlConnection ConnectionSQL = new MySqlConnection(sConnectionString);


            if (iIdRecordObjects == 0)
                sSQL = GetInsertSQLObjects();
            else
            {
                sSQL = GetUpdateSQLObjects(iIdRecordObjects);
            }

            MySqlCommand cmd = new MySqlCommand(sSQL, ConnectionSQL);
            ConnectionSQL.Open();
            cmd.ExecuteNonQuery();
            f1.RefreshSQL();
            ConnectionSQL.Close();
        }

        private string GetInsertSQLObjects()
        {
            string sSQL = "INSERT INTO Objects (CodeO, Name, Lections, Practics, Labs) VALUES (";
            sSQL += textBox6.Text + ",";
            sSQL += "'" + textBox7.Text + "', ";
            sSQL += textBox8.Text + ",";
            sSQL += textBox5.Text + ", ";
            sSQL += textBox9.Text + ")";
            return sSQL;
        }

        private string GetUpdateSQLObjects(int ID_Students)
        {
            string sSQL = "UPDATE Objects SET CodeO = ";
            sSQL += textBox6.Text + ", ";
            sSQL += "Name = '" + textBox7.Text + "', ";
            sSQL += "Lections = " + textBox8.Text + ", ";
            sSQL += "Practics = " + textBox5.Text + ", ";
            sSQL += "Labs = '" + textBox9.Text + "' ";
            sSQL += "WHERE ID = " + ID_Students;
            return sSQL;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            string sSQL = "";
            MySqlConnection ConnectionSQL = new MySqlConnection(sConnectionString);

            if (iIdRecordObjects == 0)
                sSQL = GetInsertSQLPlan();
            else
            {
                sSQL = GetUpdateSQLPlan(iIdRecordPlan);
            }

            MySqlCommand cmd = new MySqlCommand(sSQL, ConnectionSQL);
            ConnectionSQL.Open();
            cmd.ExecuteNonQuery();
            f1.RefreshSQL();
            ConnectionSQL.Close();
        }

        private string GetInsertSQLPlan()
        {
            string sSQL = "INSERT INTO Plan (CodeS, CodeO, Ocenka) VALUES (";
            sSQL += comboBox1.Text + ",";
            sSQL += comboBox2.Text + ",";
            sSQL += textBox12.Text + ")";
            return sSQL;
        }

        private string GetUpdateSQLPlan(int ID_Students)
        {
            Form1 f1 = new Form1();
            string sSQL = "UPDATE Plan SET CodeS = ";
            sSQL += comboBox1.Text + ", ";
            sSQL += "CodeO = " + comboBox2.Text + ", ";
            sSQL += "Ocenka = " + textBox12.Text + " ";
            sSQL += "WHERE ID = " + ID_Students;
            return sSQL;
        }

        private void AddChangeForm_Load(object sender, EventArgs e)
        {
            MySqlConnection ConnectionSQL = new MySqlConnection(sConnectionString);
            MySqlDataAdapter adap = new MySqlDataAdapter("SELECT CodeS From Students", ConnectionSQL);
            DataTable tbl = new DataTable();
            adap.Fill(tbl);
            comboBox1.DataSource = tbl;
            comboBox1.DisplayMember = "CodeS";
            comboBox1.ValueMember = "CodeS";

            MySqlDataAdapter adap1 = new MySqlDataAdapter("SELECT CodeO From Objects", ConnectionSQL);
            DataTable tbl1 = new DataTable();
            adap1.Fill(tbl1);
            comboBox2.DataSource = tbl1;
            comboBox2.DisplayMember = "CodeO";
            comboBox2.ValueMember = "CodeO";
        }
    }
}
