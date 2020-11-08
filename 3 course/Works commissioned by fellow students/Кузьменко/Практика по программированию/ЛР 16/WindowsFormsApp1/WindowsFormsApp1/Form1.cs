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
        public string sConnectionString = "server=localhost;user=mysql;database=MyPractica;port=3306;password=mysql;";

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
            String SQLStudents = GetSQLStringStudents();
            String SQLObjects = GetSQLStringObjects();
            String SQLPlan = GetSQLStringPlan();

            MySqlConnection Connection = new MySqlConnection(sConnectionString);

            MySqlDataAdapter AdapterStudents = new MySqlDataAdapter(SQLStudents, Connection);
            MySqlDataAdapter AdapterObjects = new MySqlDataAdapter(SQLObjects, Connection);
            MySqlDataAdapter AdapterPlan = new MySqlDataAdapter(SQLPlan, Connection);
            Connection.Open();

            DataSet ds = new DataSet();
            AdapterStudents.Fill(ds, "Students");
            dataGridView1.DataSource = ds.Tables["Students"];
            AdapterObjects.Fill(ds, "Objects");
            dataGridView2.DataSource = ds.Tables["Objects"];
            AdapterPlan.Fill(ds, "Plan");
            dataGridView3.DataSource = ds.Tables["Plan"];
            Connection.Close();

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Код";
            dataGridView1.Columns[2].HeaderText = "ФИО";
            dataGridView1.Columns[3].HeaderText = "Адрес";
            dataGridView1.Columns[4].HeaderText = "Телефон";

            dataGridView2.Columns[0].HeaderText = "ID";
            dataGridView2.Columns[1].HeaderText = "Код";
            dataGridView2.Columns[2].HeaderText = "Название";
            dataGridView2.Columns[3].HeaderText = "Лекции";
            dataGridView2.Columns[4].HeaderText = "Практика";
            dataGridView2.Columns[5].HeaderText = "Лабы";

            dataGridView3.Columns[0].HeaderText = "ID";
            dataGridView3.Columns[1].HeaderText = "ФИО студента";
            dataGridView3.Columns[2].HeaderText = "Название предмета";
            dataGridView3.Columns[3].HeaderText = "Оценка";
        }

        private string GetSQLStringStudents()
        {
            string sSQL = "SELECT ID, CodeS , FIO, Adress, Telephone FROM Students";
            return sSQL;
        }

        private string GetSQLStringObjects()
        {
            string sSQL = "SELECT ID, CodeO, Name, Lections, Practics, Labs FROM Objects";
            return sSQL;
        }

        private string GetSQLStringPlan()
        {
            string sSQL = "SELECT Plan.ID, Students.FIO, Objects.Name, Ocenka FROM Students, Objects, Plan WHERE Plan.CodeS = Students.CodeS AND Plan.CodeO = Objects.CodeO";
            return sSQL;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddChangeForm addForm = new AddChangeForm();
            addForm.iIdRecordStudents = 0;
            addForm.iIdRecordObjects = 0;
            addForm.iIdRecordPlan = 0;            
            if (addForm.ShowDialog() == DialogResult.OK)
                SelectDataFromDB();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ///если выделена не пустая ячейка
            if (dataGridView1.CurrentCell != null)
            {
                AddChangeForm addForm = new AddChangeForm();
                addForm.iIdRecordStudents = Convert.ToInt32(dataGridView1.CurrentCell.Value);
                addForm.iIdRecordObjects = Convert.ToInt32(dataGridView2.CurrentCell.Value);
                addForm.iIdRecordPlan = Convert.ToInt32(dataGridView3.CurrentCell.Value);
                if (addForm.ShowDialog() == DialogResult.OK)
                    SelectDataFromDB();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection ConnectionSQL = new MySqlConnection(sConnectionString);
            MySqlCommand cmd = new MySqlCommand("DELETE FROM Students WHERE ID=" + dataGridView1.CurrentCell.Value.ToString(), ConnectionSQL);
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
            MySqlCommand cmd = new MySqlCommand("DELETE FROM Objects WHERE ID = " + dataGridView2.CurrentCell.Value.ToString(), ConnectionSQL);
            ConnectionSQL.Open();
            cmd.ExecuteNonQuery();
            ConnectionSQL.Close();
            SelectDataFromDB();
            MessageBox.Show("Удалено.");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MySqlConnection ConnectionSQL = new MySqlConnection(sConnectionString);
            MySqlCommand cmd = new MySqlCommand("DELETE FROM Plan WHERE ID = " + dataGridView3.CurrentCell.Value.ToString(), ConnectionSQL);
            ConnectionSQL.Open();
            cmd.ExecuteNonQuery();
            ConnectionSQL.Close();
            SelectDataFromDB();
            MessageBox.Show("Удалено.");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            String SQLStudents = "SELECT ID, CodeS , FIO, Adress, Telephone FROM Students WHERE FIO like '%" + textBox2.Text + "%'";
            SelectDataFromDB();
            MySqlConnection Connection = new MySqlConnection(sConnectionString);
            MySqlDataAdapter AdapterStudents = new MySqlDataAdapter(SQLStudents, Connection);
            Connection.Open();
            DataSet ds = new DataSet();
            AdapterStudents.Fill(ds, "Students");
            dataGridView1.DataSource = ds.Tables["Students"];
            Connection.Close();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Код";
            dataGridView1.Columns[2].HeaderText = "ФИО";
            dataGridView1.Columns[3].HeaderText = "Адрес";
            dataGridView1.Columns[4].HeaderText = "Телефон";

            String SQLObjectss = "SELECT Plan.ID, Students.FIO, Objects.Name, Ocenka FROM Students, Objects, Plan WHERE Plan.CodeS = Students.CodeS AND Plan.CodeO = Objects.CodeO AND Students.FIO like '%" + textBox2.Text + "%'";
            MySqlConnection Connection1 = new MySqlConnection(sConnectionString);
            MySqlDataAdapter AdapterStudents1 = new MySqlDataAdapter(SQLObjectss, Connection1);
            Connection1.Open();
            DataSet ds1 = new DataSet();
            AdapterStudents1.Fill(ds1, "Plan");
            dataGridView3.DataSource = ds1.Tables["Plan"];
            Connection1.Close();
            dataGridView3.Columns[0].HeaderText = "ID";
            dataGridView3.Columns[1].HeaderText = "ФИО студента";
            dataGridView3.Columns[2].HeaderText = "Название предмета";
            dataGridView3.Columns[3].HeaderText = "Оценка";
        }        
    }
}
