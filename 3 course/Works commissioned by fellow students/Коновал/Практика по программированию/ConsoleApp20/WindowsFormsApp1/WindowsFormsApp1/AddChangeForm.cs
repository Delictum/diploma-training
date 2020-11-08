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
        public int iIdRecordGroups { get; set; }
        public int iIdRecordTeachers { get; set; }
        public int iIdRecordBurden { get; set; }
        public String sConnectionString = "server=localhost;user=mysql;database=Practic;port=3306;password=mysql;";

        public AddChangeForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            string sSQL = "";
            MySqlConnection ConnectionSQL = new MySqlConnection(sConnectionString);

            if (iIdRecordGroups == 0)
                sSQL = GetInsertSQLGroups();
            else
            {
                sSQL = GetUpdateSQLGroups(iIdRecordGroups);
            }

            MySqlCommand cmd = new MySqlCommand(sSQL, ConnectionSQL);
            ConnectionSQL.Open();
            cmd.ExecuteNonQuery();
            f1.RefreshSQL();
            ConnectionSQL.Close();
        }

        private string GetInsertSQLGroups()
        {
            string sSQL = "INSERT INTO Groups (number, cpecialization , secession, count) VALUES (";
            sSQL += textBox1.Text + ",";
            sSQL += "'" + textBox2.Text + "', ";
            sSQL += "'" + textBox3.Text + "', ";
            sSQL += "'" + textBox4.Text + "')";
            return sSQL;
        }

        private string GetUpdateSQLGroups(int ID_Groups)
        {
            string sSQL = "UPDATE Groups SET number = ";
            sSQL += textBox1.Text + ",";
            sSQL += " cpecialization  = '" + textBox2.Text + "',";
            sSQL += " secession = " + textBox3.Text + ",";
            sSQL += " count = " + textBox4.Text + " ";
            sSQL += "WHERE id_groups = " + ID_Groups;
            return sSQL;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            string sSQL = "";
            MySqlConnection ConnectionSQL = new MySqlConnection(sConnectionString);


            if (iIdRecordTeachers == 0)
                sSQL = GetInsertSQLTeachers();
            else
            {
                sSQL = GetUpdateSQLTeachers(iIdRecordTeachers);
            }

            MySqlCommand cmd = new MySqlCommand(sSQL, ConnectionSQL);
            ConnectionSQL.Open();
            cmd.ExecuteNonQuery();
            f1.RefreshSQL();
            ConnectionSQL.Close();
        }

        private string GetInsertSQLTeachers()
        {
            string sSQL = "INSERT INTO Teachers (code, surname, name, patronymic, telphone, experience) VALUES (";
            sSQL += textBox6.Text + ",";
            sSQL += "'" + textBox7.Text + "', ";
            sSQL += "'" + textBox8.Text + "',";
            sSQL += "'" + textBox5.Text + "', ";
            sSQL += textBox9.Text + ", ";
            sSQL += textBox11.Text + ")";

            return sSQL;
        }

        private string GetUpdateSQLTeachers(int ID_Groups)
        {
            string sSQL = "UPDATE Teachers SET code = ";
            sSQL += textBox6.Text + ", ";
            sSQL += "surname = '" + textBox7.Text + "', ";
            sSQL += "name = '" + textBox8.Text + "', ";
            sSQL += "patronymic = '" + textBox5.Text + "', ";
            sSQL += "telphone = " + textBox9.Text + ", ";
            sSQL += "experience = " + textBox9.Text + " ";
            sSQL += "WHERE id_teachers = " + ID_Groups;
            return sSQL;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            string sSQL = "";
            MySqlConnection ConnectionSQL = new MySqlConnection(sConnectionString);

            if (iIdRecordTeachers == 0)
                sSQL = GetInsertSQLBurden();
            else
            {
                sSQL = GetUpdateSQLBurden(iIdRecordBurden);
            }

            MySqlCommand cmd = new MySqlCommand(sSQL, ConnectionSQL);
            ConnectionSQL.Open();
            cmd.ExecuteNonQuery();
            f1.RefreshSQL();
            ConnectionSQL.Close();
        }

        private string GetInsertSQLBurden()
        {
            string sSQL = "INSERT INTO Burden (code, number, hours, subject, type, payment) VALUES (";
            sSQL += comboBox1.Text + ",";
            sSQL += comboBox2.Text + ",";
            sSQL += textBox12.Text + ",";
            sSQL += "'" + textBox13.Text + "',";
            sSQL += "'" + textBox14.Text + "',";
            sSQL += textBox15.Text + ")";
            return sSQL;
        }

        private string GetUpdateSQLBurden(int ID_Groups)
        {
            Form1 f1 = new Form1();
            string sSQL = "UPDATE Burden SET code = ";
            sSQL += comboBox1.Text + ", ";
            sSQL += "number = " + comboBox2.Text + ", ";
            sSQL += "hours = " + textBox12.Text + ", ";
            sSQL += "subject = '" + textBox12.Text + "', ";
            sSQL += "type = '" + textBox12.Text + "', ";
            sSQL += "payment = " + textBox12.Text + " ";
            sSQL += "WHERE id_load = " + ID_Groups;
            return sSQL;
        }

        private void AddChangeForm_Load(object sender, EventArgs e)
        {
            MySqlConnection ConnectionSQL = new MySqlConnection(sConnectionString);
            MySqlDataAdapter adap = new MySqlDataAdapter("SELECT number From Groups", ConnectionSQL);
            DataTable tbl = new DataTable();
            adap.Fill(tbl);
            comboBox2.DataSource = tbl;
            comboBox2.DisplayMember = "number";
            comboBox2.ValueMember = "number";

            MySqlDataAdapter adap1 = new MySqlDataAdapter("SELECT code From Teachers", ConnectionSQL);
            DataTable tbl1 = new DataTable();
            adap1.Fill(tbl1);
            comboBox1.DataSource = tbl1;
            comboBox1.DisplayMember = "code";
            comboBox1.ValueMember = "code";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
