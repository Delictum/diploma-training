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
        public MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=");
        public MySqlDataAdapter adapter;
        public MySqlCommand command;

        public Form1()
        {
            InitializeComponent();
            Teachers();
            Subjects();
            StudyLoad();
        }

        public void Teachers()
        {
            adapter = new MySqlDataAdapter("SELECT * FROM DistributionOfTrainingLoad.Teachers", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Teachers");
            connection.Close();
            dataGridView1.DataSource = ds.Tables["Teachers"];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Код";
            dataGridView1.Columns[2].HeaderText = "Фамилия";
            dataGridView1.Columns[3].HeaderText = "Имя";
            dataGridView1.Columns[4].HeaderText = "Отчество";
            dataGridView1.Columns[5].HeaderText = "Ученая степень";
            dataGridView1.Columns[6].HeaderText = "Должность";
            dataGridView1.Columns[7].HeaderText = "Стаж";
        }

        public void Subjects()
        {
            adapter = new MySqlDataAdapter("SELECT * FROM DistributionOfTrainingLoad.Subjects", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Subjects");
            connection.Close();
            dataGridView2.DataSource = ds.Tables["Subjects"];
            dataGridView2.Columns[0].HeaderText = "ID";
            dataGridView2.Columns[1].HeaderText = "Код";
            dataGridView2.Columns[2].HeaderText = "Название";
            dataGridView2.Columns[3].HeaderText = "Тип";
            dataGridView2.Columns[4].HeaderText = "Часы";
        }

        public void StudyLoad()
        {
            adapter = new MySqlDataAdapter("SELECT ID_StudyLoad, Name, Hours, NumberGroups FROM DistributionOfTrainingLoad.StudyLoad, " +
                "DistributionOfTrainingLoad.Subjects, DistributionOfTrainingLoad.Teachers WHERE" +
                " StudyLoad.CodeTeachers = Teachers.CodeTeachers AND StudyLoad.CodeSubjects = Subjects.CodeSubjects ORDER BY ID_StudyLoad ASC", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "StudyLoad");
            connection.Close();
            dataGridView3.DataSource = ds.Tables["StudyLoad"];
            dataGridView3.Columns[0].HeaderText = "ID";
            dataGridView3.Columns[1].HeaderText = "Предмет";
            dataGridView3.Columns[2].HeaderText = "Часы";
            dataGridView3.Columns[3].HeaderText = "Номер группы";
        }
    }
}
