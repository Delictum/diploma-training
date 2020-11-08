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
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string IDIndex;
        public string sConnectionString = "server=localhost;user=mysql;database=Practica;port=3306;password=mysql;";

        private void Form1_Load(object sender, EventArgs e)
        {
            SelectDataFromDB();
        }

        public void RefreshSQL()
        {
            SelectDataFromDB();
        }

        private void SelectDataFromDB()
        {
            String SQLMachineTypes = GetSQLStringMachineTypes();
            String SQLRepairType = GetSQLStringRepairType();
            String SQLRepair = GetSQLStringRepair();

            MySqlConnection Connection = new MySqlConnection(sConnectionString);

            MySqlDataAdapter AdapterMachineTypes = new MySqlDataAdapter(SQLMachineTypes, Connection);
            MySqlDataAdapter AdapterRepairType = new MySqlDataAdapter(SQLRepairType, Connection);
            MySqlDataAdapter AdapterRepair = new MySqlDataAdapter(SQLRepair, Connection);
            Connection.Open();

            DataSet ds = new DataSet();
            AdapterMachineTypes.Fill(ds, "MachineTypes");
            dataGridView1.DataSource = ds.Tables["MachineTypes"];
            AdapterRepairType.Fill(ds, "RepairType");
            dataGridView2.DataSource = ds.Tables["RepairType"];
            AdapterRepair.Fill(ds, "Repair");
            dataGridView3.DataSource = ds.Tables["Repair"];
            Connection.Close();

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Код";
            dataGridView1.Columns[2].HeaderText = "Страна";
            dataGridView1.Columns[3].HeaderText = "Год";
            dataGridView1.Columns[4].HeaderText = "Марка";

            dataGridView2.Columns[0].HeaderText = "ID";
            dataGridView2.Columns[1].HeaderText = "Код";
            dataGridView2.Columns[2].HeaderText = "Название";
            dataGridView2.Columns[3].HeaderText = "Продолжительность";
            dataGridView2.Columns[4].HeaderText = "Цена";
            dataGridView2.Columns[5].HeaderText = "Примечание";

            dataGridView3.Columns[0].HeaderText = "ID";
            dataGridView3.Columns[1].HeaderText = "Код станка";
            dataGridView3.Columns[2].HeaderText = "Марка";
            dataGridView3.Columns[3].HeaderText = "Код ремонта";
            dataGridView3.Columns[4].HeaderText = "Цена";
            dataGridView3.Columns[5].HeaderText = "Начало работ";
            dataGridView3.Columns[6].HeaderText = "Примечание";
        }

        private string GetSQLStringMachineTypes()
        {
            string sSQL = "SELECT ID, CodeMachine, Country, Year, Mark FROM MachineTypes";
            return sSQL;
        }

        private string GetSQLStringRepairType()
        {
            string sSQL = "SELECT ID, CodeRepair, Name, Duration, Price, Notes FROM RepairType";
            return sSQL;
        }

        private string GetSQLStringRepair()
        {
            string sSQL = "SELECT Repair.ID, Repair.CodeMachine, MachineTypes.Mark, Repair.CodeRepair, RepairType.Price, DateStart, Repair.Notes FROM MachineTypes, RepairType, Repair WHERE Repair.CodeMachine = MachineTypes.CodeMachine AND Repair.CodeRepair = RepairType.CodeRepair";
            return sSQL;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddChangeForm addForm = new AddChangeForm();
            addForm.iIdRecordMachineTypes = 0;
            addForm.iIdRecordRepairType = 0;
            addForm.iIdRecordRepair = 0;
            if (addForm.ShowDialog() == DialogResult.OK)
                SelectDataFromDB();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ///если выделена не пустая ячейка
            if (dataGridView1.CurrentCell != null)
            {
                AddChangeForm addForm = new AddChangeForm();
                addForm.iIdRecordMachineTypes = Convert.ToInt32(dataGridView1.CurrentCell.Value);
                addForm.iIdRecordRepairType = Convert.ToInt32(dataGridView2.CurrentCell.Value);
                addForm.iIdRecordRepair = Convert.ToInt32(dataGridView3.CurrentCell.Value);
                if (addForm.ShowDialog() == DialogResult.OK)
                    SelectDataFromDB();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection ConnectionSQL = new MySqlConnection(sConnectionString);
            MySqlCommand cmd = new MySqlCommand("DELETE FROM MachineTypes WHERE ID=" + dataGridView1.CurrentCell.Value.ToString(), ConnectionSQL);
            ConnectionSQL.Open();
            cmd.ExecuteNonQuery();
            ConnectionSQL.Close();
            SelectDataFromDB();
            MessageBox.Show("Удалено.");
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            IDIndex = dataGridView1.CurrentCell.Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlConnection ConnectionSQL = new MySqlConnection(sConnectionString);
            MySqlCommand cmd = new MySqlCommand("DELETE FROM RepairType WHERE ID = " + dataGridView2.CurrentCell.Value.ToString(), ConnectionSQL);
            ConnectionSQL.Open();
            cmd.ExecuteNonQuery();
            ConnectionSQL.Close();
            SelectDataFromDB();
            MessageBox.Show("Удалено.");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MySqlConnection ConnectionSQL = new MySqlConnection(sConnectionString);
            MySqlCommand cmd = new MySqlCommand("DELETE FROM Repair WHERE ID = " + dataGridView3.CurrentCell.Value.ToString(), ConnectionSQL);
            ConnectionSQL.Open();
            cmd.ExecuteNonQuery();
            ConnectionSQL.Close();
            SelectDataFromDB();
            MessageBox.Show("Удалено.");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            String SQLMachineTypes = "SELECT ID, CodeMachine, Country, Year, Mark FROM MachineTypes WHERE Mark like '%" + textBox2.Text + "%'";
            SelectDataFromDB();
            MySqlConnection Connection = new MySqlConnection(sConnectionString);
            MySqlDataAdapter AdapterMachineTypes = new MySqlDataAdapter(SQLMachineTypes, Connection);
            Connection.Open();
            DataSet ds = new DataSet();
            AdapterMachineTypes.Fill(ds, "MachineTypes");
            dataGridView1.DataSource = ds.Tables["MachineTypes"];
            Connection.Close();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Код";
            dataGridView1.Columns[2].HeaderText = "Страна";
            dataGridView1.Columns[3].HeaderText = "Год";
            dataGridView1.Columns[4].HeaderText = "Марка";

            String SQLRepairTypes = "SELECT Repair.ID, Repair.CodeMachine, MachineTypes.Mark, Repair.CodeRepair, RepairType.Price, DateStart, Repair.Notes FROM MachineTypes, RepairType, Repair WHERE Repair.CodeMachine = MachineTypes.CodeMachine AND Repair.CodeRepair = RepairType.CodeRepair AND MachineTypes.Mark like '%" + textBox2.Text + "%'";
            MySqlConnection Connection1 = new MySqlConnection(sConnectionString);
            MySqlDataAdapter AdapterMachineTypes1 = new MySqlDataAdapter(SQLRepairTypes, Connection1);
            Connection1.Open();
            DataSet ds1 = new DataSet();
            AdapterMachineTypes1.Fill(ds1, "Repair");
            dataGridView3.DataSource = ds1.Tables["Repair"];
            Connection1.Close();
            dataGridView3.Columns[0].HeaderText = "ID";
            dataGridView3.Columns[1].HeaderText = "Код станка";
            dataGridView3.Columns[2].HeaderText = "Марка";
            dataGridView3.Columns[3].HeaderText = "Код ремонта";
            dataGridView3.Columns[4].HeaderText = "Цена";
            dataGridView3.Columns[5].HeaderText = "Начало работ";
            dataGridView3.Columns[6].HeaderText = "Примечание";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int CodeRepair = 0;
            double Days = 0;
            DateTime StartWorks = new DateTime(2018, 1, 1);
            MySqlConnection Connection = new MySqlConnection(sConnectionString);
            MySqlCommand command = new MySqlCommand("SELECT DateStart FROM Repair WHERE ID = " + dataGridView3.CurrentCell.Value.ToString(), Connection);
            Connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                StartWorks = Convert.ToDateTime(reader.GetValue(0));
            }
            reader.Close();
            Connection.Close();

            command = new MySqlCommand("SELECT CodeRepair FROM Repair WHERE ID = " + dataGridView3.CurrentCell.Value.ToString(), Connection);
            Connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                CodeRepair = Convert.ToInt32(reader.GetValue(0));
            }
            reader.Close();
            Connection.Close();

            command = new MySqlCommand("SELECT Duration FROM RepairType WHERE CodeRepair = " + CodeRepair.ToString(), Connection);
            Connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Days = Convert.ToDouble(reader.GetValue(0));
            }
            reader.Close();
            Connection.Close();

            textBox1.Text = Convert.ToString(StartWorks.AddDays(Days));
        }
    }
}
