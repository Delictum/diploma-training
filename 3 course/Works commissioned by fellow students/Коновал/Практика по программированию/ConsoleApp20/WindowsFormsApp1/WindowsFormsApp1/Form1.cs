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
        public string sConnectionString = "server=localhost;user=mysql;database=Practic;port=3306;password=mysql;";

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
            String SQLGroups = GetSQLStringGroups();
            String SQLTeachers = GetSQLStringTeachers();
            String SQLBurden = GetSQLStringBurden();

            MySqlConnection Connection = new MySqlConnection(sConnectionString);

            MySqlDataAdapter AdapterGroups = new MySqlDataAdapter(SQLGroups, Connection);
            MySqlDataAdapter AdapterTeachers = new MySqlDataAdapter(SQLTeachers, Connection);
            MySqlDataAdapter AdapterBurden = new MySqlDataAdapter(SQLBurden, Connection);
            Connection.Open();

            DataSet ds = new DataSet();
            AdapterGroups.Fill(ds, "Groups");
            dataGridView1.DataSource = ds.Tables["Groups"];
            AdapterTeachers.Fill(ds, "Teachers");
            dataGridView2.DataSource = ds.Tables["Teachers"];
            AdapterBurden.Fill(ds, "Burden");
            dataGridView3.DataSource = ds.Tables["Burden"];
            Connection.Close();

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Номер";
            dataGridView1.Columns[2].HeaderText = "Специальность";
            dataGridView1.Columns[3].HeaderText = "Отдел";
            dataGridView1.Columns[4].HeaderText = "Количество студентов";

            dataGridView2.Columns[0].HeaderText = "ID";
            dataGridView2.Columns[1].HeaderText = "Код";
            dataGridView2.Columns[2].HeaderText = "Фамилия";
            dataGridView2.Columns[3].HeaderText = "Имя";
            dataGridView2.Columns[4].HeaderText = "Отчество";
            dataGridView2.Columns[5].HeaderText = "Телефон";
            dataGridView2.Columns[6].HeaderText = "Стаж";

            dataGridView3.Columns[0].HeaderText = "ID";
            dataGridView3.Columns[1].HeaderText = "Фамилия преподавателя";
            dataGridView3.Columns[2].HeaderText = "Телефон";
            dataGridView3.Columns[3].HeaderText = "Специальность";
            dataGridView3.Columns[4].HeaderText = "Отдел";
            dataGridView3.Columns[5].HeaderText = "Количество часов";
            dataGridView3.Columns[6].HeaderText = "Предмет";
            dataGridView3.Columns[7].HeaderText = "Тип";
            dataGridView3.Columns[8].HeaderText = "Оплата";
        }

        private string GetSQLStringGroups()
        {
            string sSQL = "SELECT id_groups, number, cpecialization, secession, count FROM Groups";
            return sSQL;
        }

        private string GetSQLStringTeachers()
        {
            string sSQL = "SELECT id_teachers, code, surname, name, patronymic, telphone, experience FROM Teachers";
            return sSQL;
        }

        private string GetSQLStringBurden()
        {
            string sSQL = "SELECT Burden.id_load, Teachers.surname, Teachers.telphone, Groups.cpecialization, Groups.secession, " +
                "Burden.hours, Burden.subject, Burden.type, Burden.payment FROM Groups, Teachers, " +
                "Burden WHERE Burden.number = Groups.number AND Burden.code = Teachers.code";
            return sSQL;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddChangeForm addForm = new AddChangeForm();
            addForm.iIdRecordGroups = 0;
            addForm.iIdRecordTeachers = 0;
            addForm.iIdRecordBurden = 0;
            if (addForm.ShowDialog() == DialogResult.OK)
                SelectDataFromDB();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ///если выделена не пустая ячейка
            if (dataGridView1.CurrentCell != null)
            {
                AddChangeForm addForm = new AddChangeForm();
                addForm.iIdRecordGroups = Convert.ToInt32(dataGridView1.CurrentCell.Value);
                addForm.iIdRecordTeachers = Convert.ToInt32(dataGridView2.CurrentCell.Value);
                addForm.iIdRecordBurden = Convert.ToInt32(dataGridView3.CurrentCell.Value);
                if (addForm.ShowDialog() == DialogResult.OK)
                    SelectDataFromDB();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection ConnectionSQL = new MySqlConnection(sConnectionString);
            MySqlCommand cmd = new MySqlCommand("DELETE FROM Groups WHERE id_groups =" + dataGridView1.CurrentCell.Value.ToString(), ConnectionSQL);
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
            MySqlCommand cmd = new MySqlCommand("DELETE FROM Teachers WHERE id_teachers = " + dataGridView2.CurrentCell.Value.ToString(), ConnectionSQL);
            ConnectionSQL.Open();
            cmd.ExecuteNonQuery();
            ConnectionSQL.Close();
            SelectDataFromDB();
            MessageBox.Show("Удалено.");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MySqlConnection ConnectionSQL = new MySqlConnection(sConnectionString);
            MySqlCommand cmd = new MySqlCommand("DELETE FROM Burden WHERE id_load = " + dataGridView3.CurrentCell.Value.ToString(), ConnectionSQL);
            ConnectionSQL.Open();
            cmd.ExecuteNonQuery();
            ConnectionSQL.Close();
            SelectDataFromDB();
            MessageBox.Show("Удалено.");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            String SQLGroups = "SELECT id_groups, number, cpecialization, secession, count FROM Groups WHERE cpecialization like '%" + textBox2.Text + "%'";
            SelectDataFromDB();
            MySqlConnection Connection = new MySqlConnection(sConnectionString);
            MySqlDataAdapter AdapterGroups = new MySqlDataAdapter(SQLGroups, Connection);
            Connection.Open();
            DataSet ds = new DataSet();
            AdapterGroups.Fill(ds, "Groups");
            dataGridView1.DataSource = ds.Tables["Groups"];
            Connection.Close();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Номер";
            dataGridView1.Columns[2].HeaderText = "Специальность";
            dataGridView1.Columns[3].HeaderText = "Отдел";
            dataGridView1.Columns[4].HeaderText = "Количество студентов";

            String SQLTeacherss = "SELECT Burden.id_load, Teachers.surname, Teachers.telphone, Groups.cpecialization, Groups.secession, " +
                "Burden.hours, Burden.subject, Burden.type, Burden.payment FROM Groups, Teachers, " +
                "Burden WHERE Burden.number = Groups.number AND Burden.code = Teachers.code AND cpecialization like '%" + textBox2.Text + "%'";
            MySqlConnection Connection1 = new MySqlConnection(sConnectionString);
            MySqlDataAdapter AdapterGroups1 = new MySqlDataAdapter(SQLTeacherss, Connection1);
            Connection1.Open();
            DataSet ds1 = new DataSet();
            AdapterGroups1.Fill(ds1, "Burden");
            dataGridView3.DataSource = ds1.Tables["Burden"];
            Connection1.Close();
            dataGridView3.Columns[0].HeaderText = "ID";
            dataGridView3.Columns[1].HeaderText = "Фамилия преподавателя";
            dataGridView3.Columns[2].HeaderText = "Телефон";
            dataGridView3.Columns[3].HeaderText = "Специальность";
            dataGridView3.Columns[4].HeaderText = "Отдел";
            dataGridView3.Columns[5].HeaderText = "Количество часов";
            dataGridView3.Columns[6].HeaderText = "Предмет";
            dataGridView3.Columns[7].HeaderText = "Тип";
            dataGridView3.Columns[8].HeaderText = "Оплата";
        }
    }
}
