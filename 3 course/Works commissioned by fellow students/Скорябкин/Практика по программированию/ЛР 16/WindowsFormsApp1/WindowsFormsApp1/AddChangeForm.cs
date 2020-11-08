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
        public int iIdRecordMachineTypes { get; set; }
        public int iIdRecordRepairType { get; set; }
        public int iIdRecordRepair { get; set; }
        public String sConnectionString = "server=localhost;user=mysql;database=Practica;port=3306;password=mysql;";

        public AddChangeForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            string sSQL = "";
            MySqlConnection ConnectionSQL = new MySqlConnection(sConnectionString);

            if (iIdRecordMachineTypes == 0)
                sSQL = GetInsertSQLMachineTypes();
            else
            {
                sSQL = GetUpdateSQLMachineTypes(iIdRecordMachineTypes);
            }

            MySqlCommand cmd = new MySqlCommand(sSQL, ConnectionSQL);
            ConnectionSQL.Open();
            cmd.ExecuteNonQuery();
            f1.RefreshSQL();
            ConnectionSQL.Close();
        }

        private string GetInsertSQLMachineTypes()
        {
            string sSQL = "INSERT INTO MachineTypes (CodeMachine, Country, Year, Mark) VALUES (";
            sSQL += textBox1.Text + ",";
            sSQL += "'" + textBox2.Text + "', ";
            sSQL += textBox3.Text + ", ";
            sSQL += "'" + textBox4.Text + "')";
            return sSQL;
        }

        private string GetUpdateSQLMachineTypes(int ID_MachineTypes)
        {
            string sSQL = "UPDATE MachineTypes SET CodeMachine = ";
            sSQL += textBox1.Text + ",";
            sSQL += " Country = '" + textBox2.Text + "',";
            sSQL += " Year = " + textBox3.Text + ",";
            sSQL += " Mark = '" + textBox4.Text + "' ";
            sSQL += "WHERE ID = " + ID_MachineTypes;
            return sSQL;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            string sSQL = "";
            MySqlConnection ConnectionSQL = new MySqlConnection(sConnectionString);


            if (iIdRecordRepairType == 0)
                sSQL = GetInsertSQLRepairType();
            else
            {
                sSQL = GetUpdateSQLRepairType(iIdRecordRepairType);
            }

            MySqlCommand cmd = new MySqlCommand(sSQL, ConnectionSQL);
            ConnectionSQL.Open();
            cmd.ExecuteNonQuery();
            f1.RefreshSQL();
            ConnectionSQL.Close();
        }

        private string GetInsertSQLRepairType()
        {
            string sSQL = "INSERT INTO RepairType (CodeRepair, Name, Duration, Price, Notes) VALUES (";
            sSQL += textBox6.Text + ",";
            sSQL += "'" + textBox7.Text + "', ";
            sSQL += textBox8.Text + ",";
            sSQL += textBox5.Text + ", ";
            sSQL += "'" + textBox9.Text + "')";
            return sSQL;
        }

        private string GetUpdateSQLRepairType(int ID_MachineTypes)
        {
            string sSQL = "UPDATE RepairType SET CodeRepair = ";
            sSQL += textBox6.Text + ", ";
            sSQL += "Name = '" + textBox7.Text + "', ";
            sSQL += "Duration = " + textBox8.Text + ", ";
            sSQL += "Price = " + textBox5.Text + ", ";
            sSQL += "Notes = '" + textBox9.Text + "' ";
            sSQL += "WHERE ID = " + ID_MachineTypes;
            return sSQL;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            string sSQL = "";
            MySqlConnection ConnectionSQL = new MySqlConnection(sConnectionString);

            if (iIdRecordRepairType == 0)
                sSQL = GetInsertSQLRepair();
            else
            {
                sSQL = GetUpdateSQLRepair(iIdRecordRepair);
            }

            MySqlCommand cmd = new MySqlCommand(sSQL, ConnectionSQL);
            ConnectionSQL.Open();
            cmd.ExecuteNonQuery();
            f1.RefreshSQL();
            ConnectionSQL.Close();
        }

        private string GetInsertSQLRepair()
        {
            string sSQL = "INSERT INTO Repair (CodeMachine, CodeRepair, DateStart, Notes) VALUES (";
            sSQL += textBox10.Text + ",";
            sSQL += textBox11.Text + ",";
            sSQL += "'" + textBox12.Text + "', ";
            sSQL += "'" + textBox13.Text + "')";
            return sSQL;
        }

        private string GetUpdateSQLRepair(int ID_MachineTypes)
        {
            Form1 f1 = new Form1();
            string sSQL = "UPDATE Repair SET CodeMachine = ";
            sSQL += textBox10.Text + ", ";
            sSQL += "CodeRepairType = " + textBox11.Text + ", ";
            sSQL += "DateStart = '" + textBox12.Text + "', ";
            sSQL += "Notes = '" + textBox13.Text + "' ";
            sSQL += "WHERE ID = " + ID_MachineTypes;
            return sSQL;
        }

        private void AddChangeForm_Load(object sender, EventArgs e)
        {

        }
    }
}
