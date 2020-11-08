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
            String SQLWorkers = GetSQLStringWorkers();
            String SQLTypeOfWork = GetSQLStringTypeOfWork();
            String SQLWorks = GetSQLStringWorks();

            string sConnectionString = "server=localhost;user=mysql;database=MyCompanyPractica;port=3303;password=mysql;";
            MySqlConnection Connection = new MySqlConnection(sConnectionString);

            MySqlDataAdapter AdapterWorkers = new MySqlDataAdapter(SQLWorkers, Connection);
            MySqlDataAdapter AdapterTypeOfWork = new MySqlDataAdapter(SQLTypeOfWork, Connection);
            MySqlDataAdapter AdapterWorks = new MySqlDataAdapter(SQLWorks, Connection);
            Connection.Open();

            DataSet ds = new DataSet();
            AdapterWorkers.Fill(ds, "Workers");
            dataGridView1.DataSource = ds.Tables["Workers"];
            AdapterTypeOfWork.Fill(ds, "TypeOfWork");
            dataGridView2.DataSource = ds.Tables["TypeOfWork"];
            AdapterWorks.Fill(ds, "Works");
            dataGridView3.DataSource = ds.Tables["Works"];
            Connection.Close();

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Код";
            dataGridView1.Columns[2].HeaderText = "Фамилия";
            dataGridView1.Columns[3].HeaderText = "Имя";
            dataGridView1.Columns[4].HeaderText = "Отчество";
            dataGridView1.Columns[5].HeaderText = "Оклад";

            dataGridView2.Columns[0].HeaderText = "ID";
            dataGridView2.Columns[1].HeaderText = "Код";
            dataGridView2.Columns[2].HeaderText = "Описание";
            dataGridView2.Columns[3].HeaderText = "Оплата за день";

            dataGridView3.Columns[0].HeaderText = "ID";
            dataGridView3.Columns[1].HeaderText = "Код работника";
            dataGridView3.Columns[2].HeaderText = "Фамилия";
            dataGridView3.Columns[3].HeaderText = "Оклад";
            dataGridView3.Columns[4].HeaderText = "Код работы";
            dataGridView3.Columns[5].HeaderText = "Оплата за день";
            dataGridView3.Columns[6].HeaderText = "Начало работ";
            dataGridView3.Columns[7].HeaderText = "Окончание работ";
        }

        private string GetSQLStringWorkers()
        {
            string sSQL = "SELECT ID_Workers, Code_Workers, LastName_Wrokers, FirstName_Workers, Patronymic_Workers, Salary_Workers FROM Workers";
            return sSQL;
        }

        private string GetSQLStringTypeOfWork()
        {
            string sSQL = "SELECT ID_TypeOfWork, Code_TypeOfWork, Description_TypeOfWork, Payment_TypeOfWork FROM TypeOfWork";
            return sSQL;
        }

        private string GetSQLStringWorks()
        {
            string sSQL = "SELECT ID_Works, Workers.Code_Workers, Workers.LastName_Wrokers, Workers.Salary_Workers, TypeOfWork.Code_TypeOfWork, TypeOfWork.Payment_TypeOfWork, StartDate_Works, EndDate_Works FROM Works, Workers, TypeOfWork WHERE Works.Code_Workers = Workers.Code_Workers AND Works.Code_TypeOfWork = TypeOfWork.Code_TypeOfWork";
            return sSQL;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ///создаем объект формы добавления записи
            AddChangeForm addForm = new AddChangeForm();
            ///т.к. мы СОЗДАЕМ,то св-во iIdRecord нулевое
            addForm.iIdRecordWorkers = 0;
            addForm.iIdRecordTypeOfWork = 0;
            addForm.iIdRecordWorks = 0;
            ///показываем форму в режиме диалога
            if (addForm.ShowDialog() == DialogResult.OK)
                ///если нажали ОК (именно для этого мы
                ///и заполняли св-ва кнопок DialogResult),
                ///значит обновляем содержимое таблицы
                SelectDataFromDB();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ///если выделена не пустая ячейка
            if (dataGridView1.CurrentCell != null)
            {
                AddChangeForm addForm = new AddChangeForm();
                addForm.iIdRecordWorkers = Convert.ToInt32(dataGridView1.CurrentCell.Value);
                addForm.iIdRecordTypeOfWork = Convert.ToInt32(dataGridView2.CurrentCell.Value);
                addForm.iIdRecordWorks = Convert.ToInt32(dataGridView3.CurrentCell.Value);
                if (addForm.ShowDialog() == DialogResult.OK)
                    SelectDataFromDB();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sConnectionString = "server=localhost;user=mysql;database=MyCompanyPractica;port=3303;password=mysql;";
            MySqlConnection ConnectionSQL = new MySqlConnection(sConnectionString);
            MySqlCommand cmd = new MySqlCommand("DELETE FROM Workers WHERE ID_Workers=" + dataGridView1.CurrentCell.Value.ToString(), ConnectionSQL);            
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
            string sConnectionString = "server=localhost;user=mysql;database=MyCompanyPractica;port=3303;password=mysql;";
            MySqlConnection ConnectionSQL = new MySqlConnection(sConnectionString);
            MySqlCommand cmd = new MySqlCommand("DELETE FROM TypeOfWork WHERE ID_TypeOfWork = " + dataGridView2.CurrentCell.Value.ToString(), ConnectionSQL);
            ConnectionSQL.Open();
            cmd.ExecuteNonQuery();
            ConnectionSQL.Close();
            SelectDataFromDB();
            MessageBox.Show("Удалено.");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sConnectionString = "server=localhost;user=mysql;database=MyCompanyPractica;port=3303;password=mysql;";
            MySqlConnection ConnectionSQL = new MySqlConnection(sConnectionString);
            MySqlCommand cmd = new MySqlCommand("DELETE FROM Works WHERE ID_Works = " + dataGridView3.CurrentCell.Value.ToString(), ConnectionSQL);
            ConnectionSQL.Open();
            cmd.ExecuteNonQuery();
            ConnectionSQL.Close();
            SelectDataFromDB();
            MessageBox.Show("Удалено.");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            String SQLWorkers = "SELECT ID_Workers, Code_Workers, LastName_Wrokers, FirstName_Workers, Patronymic_Workers, Salary_Workers FROM Workers WHERE LastName_Wrokers like '%" + textBox2.Text + "%'";
            SelectDataFromDB();
            string sConnectionString = "server=localhost;user=mysql;database=MyCompanyPractica;port=3303;password=mysql;";
            MySqlConnection Connection = new MySqlConnection(sConnectionString);
            MySqlDataAdapter AdapterWorkers = new MySqlDataAdapter(SQLWorkers, Connection);
            Connection.Open();
            DataSet ds = new DataSet();
            AdapterWorkers.Fill(ds, "Workers");
            dataGridView1.DataSource = ds.Tables["Workers"];
            Connection.Close();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Код";
            dataGridView1.Columns[2].HeaderText = "Фамилия";
            dataGridView1.Columns[3].HeaderText = "Имя";
            dataGridView1.Columns[4].HeaderText = "Отчество";
            dataGridView1.Columns[5].HeaderText = "Оклад";

            String SQLTypeOfWorks = "SELECT ID_Works, Workers.Code_Workers, Workers.LastName_Wrokers, Workers.Salary_Workers, TypeOfWork.Code_TypeOfWork, TypeOfWork.Payment_TypeOfWork, StartDate_Works, EndDate_Works FROM Works, Workers, TypeOfWork WHERE Works.Code_Workers = Workers.Code_Workers AND Works.Code_TypeOfWork = TypeOfWork.Code_TypeOfWork AND Workers.LastName_Wrokers like '%" + textBox2.Text + "%'";
            MySqlConnection Connection1 = new MySqlConnection(sConnectionString);
            MySqlDataAdapter AdapterWorkers1 = new MySqlDataAdapter(SQLTypeOfWorks, Connection1);
            Connection1.Open();
            DataSet ds1 = new DataSet();
            AdapterWorkers1.Fill(ds1, "Works");
            dataGridView3.DataSource = ds1.Tables["Works"];
            Connection1.Close();
            dataGridView3.Columns[0].HeaderText = "ID";
            dataGridView3.Columns[1].HeaderText = "Код работника";
            dataGridView3.Columns[2].HeaderText = "Фамилия";
            dataGridView3.Columns[3].HeaderText = "Оклад";
            dataGridView3.Columns[4].HeaderText = "Код работы";
            dataGridView3.Columns[5].HeaderText = "Оплата за день";
            dataGridView3.Columns[6].HeaderText = "Начало работ";
            dataGridView3.Columns[7].HeaderText = "Окончание работ";
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            String SQLWorkers = "SELECT ID_Workers, Code_Workers, LastName_Wrokers, FirstName_Workers, Patronymic_Workers, Salary_Workers FROM Workers WHERE Code_Workers like '%" + textBox6.Text + "%'";
            SelectDataFromDB();
            string sConnectionString = "server=localhost;user=mysql;database=MyCompanyPractica;port=3303;password=mysql;";
            MySqlConnection Connection = new MySqlConnection(sConnectionString);
            MySqlDataAdapter AdapterWorkers = new MySqlDataAdapter(SQLWorkers, Connection);
            Connection.Open();
            DataSet ds = new DataSet();
            AdapterWorkers.Fill(ds, "Workers");
            dataGridView1.DataSource = ds.Tables["Workers"];
            Connection.Close();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Код";
            dataGridView1.Columns[2].HeaderText = "Фамилия";
            dataGridView1.Columns[3].HeaderText = "Имя";
            dataGridView1.Columns[4].HeaderText = "Отчество";
            dataGridView1.Columns[5].HeaderText = "Оклад";

            String SQLTypeOfWorks = "SELECT ID_Works, Workers.Code_Workers, Workers.LastName_Wrokers, Workers.Salary_Workers, TypeOfWork.Code_TypeOfWork, TypeOfWork.Payment_TypeOfWork, StartDate_Works, EndDate_Works FROM Works, Workers, TypeOfWork WHERE Works.Code_Workers = Workers.Code_Workers AND Works.Code_TypeOfWork = TypeOfWork.Code_TypeOfWork AND Workers.Code_Workers like '%" + textBox6.Text + "%'";
            MySqlConnection Connection1 = new MySqlConnection(sConnectionString);
            MySqlDataAdapter AdapterWorkers1 = new MySqlDataAdapter(SQLTypeOfWorks, Connection1);
            Connection1.Open();
            DataSet ds1 = new DataSet();
            AdapterWorkers1.Fill(ds1, "Works");
            dataGridView3.DataSource = ds1.Tables["Works"];
            Connection1.Close();
            dataGridView3.Columns[0].HeaderText = "ID";
            dataGridView3.Columns[1].HeaderText = "Код работника";
            dataGridView3.Columns[2].HeaderText = "Фамилия";
            dataGridView3.Columns[3].HeaderText = "Оклад";
            dataGridView3.Columns[4].HeaderText = "Код работы";
            dataGridView3.Columns[5].HeaderText = "Оплата за день";
            dataGridView3.Columns[6].HeaderText = "Начало работ";
            dataGridView3.Columns[7].HeaderText = "Окончание работ";
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            String SQLWorkers = "SELECT ID_Workers, Code_Workers, LastName_Wrokers, FirstName_Workers, Patronymic_Workers, Salary_Workers FROM Workers WHERE FirstName_Workers like '%" + textBox3.Text + "%'";
            SelectDataFromDB();
            string sConnectionString = "server=localhost;user=mysql;database=MyCompanyPractica;port=3303;password=mysql;";
            MySqlConnection Connection = new MySqlConnection(sConnectionString);
            MySqlDataAdapter AdapterWorkers = new MySqlDataAdapter(SQLWorkers, Connection);
            Connection.Open();
            DataSet ds = new DataSet();
            AdapterWorkers.Fill(ds, "Workers");
            dataGridView1.DataSource = ds.Tables["Workers"];
            Connection.Close();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Код";
            dataGridView1.Columns[2].HeaderText = "Фамилия";
            dataGridView1.Columns[3].HeaderText = "Имя";
            dataGridView1.Columns[4].HeaderText = "Отчество";
            dataGridView1.Columns[5].HeaderText = "Оклад";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            String SQLWorkers = "SELECT ID_Workers, Code_Workers, LastName_Wrokers, FirstName_Workers, Patronymic_Workers, Salary_Workers FROM Workers WHERE Patronymic_Workers like '%" + textBox4.Text + "%'";
            SelectDataFromDB();
            string sConnectionString = "server=localhost;user=mysql;database=MyCompanyPractica;port=3303;password=mysql;";
            MySqlConnection Connection = new MySqlConnection(sConnectionString);
            MySqlDataAdapter AdapterWorkers = new MySqlDataAdapter(SQLWorkers, Connection);
            Connection.Open();
            DataSet ds = new DataSet();
            AdapterWorkers.Fill(ds, "Workers");
            dataGridView1.DataSource = ds.Tables["Workers"];
            Connection.Close();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Код";
            dataGridView1.Columns[2].HeaderText = "Фамилия";
            dataGridView1.Columns[3].HeaderText = "Имя";
            dataGridView1.Columns[4].HeaderText = "Отчество";
            dataGridView1.Columns[5].HeaderText = "Оклад";
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            String SQLWorkers = "SELECT ID_Workers, Code_Workers, LastName_Wrokers, FirstName_Workers, Patronymic_Workers, Salary_Workers FROM Workers WHERE Salary_Workers like '%" + textBox5.Text + "%'";
            SelectDataFromDB();
            string sConnectionString = "server=localhost;user=mysql;database=MyCompanyPractica;port=3303;password=mysql;";
            MySqlConnection Connection = new MySqlConnection(sConnectionString);
            MySqlDataAdapter AdapterWorkers = new MySqlDataAdapter(SQLWorkers, Connection);
            Connection.Open();
            DataSet ds = new DataSet();
            AdapterWorkers.Fill(ds, "Workers");
            dataGridView1.DataSource = ds.Tables["Workers"];
            Connection.Close();
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Код";
            dataGridView1.Columns[2].HeaderText = "Фамилия";
            dataGridView1.Columns[3].HeaderText = "Имя";
            dataGridView1.Columns[4].HeaderText = "Отчество";
            dataGridView1.Columns[5].HeaderText = "Оклад";

            String SQLTypeOfWorks = "SELECT ID_Works, Workers.Code_Workers, Workers.LastName_Wrokers, Workers.Salary_Workers, TypeOfWork.Code_TypeOfWork, TypeOfWork.Payment_TypeOfWork, StartDate_Works, EndDate_Works FROM Works, Workers, TypeOfWork WHERE Works.Code_Workers = Workers.Code_Workers AND Works.Code_TypeOfWork = TypeOfWork.Code_TypeOfWork AND Workers.Salary_Workers like '%" + textBox5.Text + "%'";
            MySqlConnection Connection1 = new MySqlConnection(sConnectionString);
            MySqlDataAdapter AdapterWorkers1 = new MySqlDataAdapter(SQLTypeOfWorks, Connection1);
            Connection1.Open();
            DataSet ds1 = new DataSet();
            AdapterWorkers1.Fill(ds1, "Works");
            dataGridView3.DataSource = ds1.Tables["Works"];
            Connection1.Close();
            dataGridView3.Columns[0].HeaderText = "ID";
            dataGridView3.Columns[1].HeaderText = "Код работника";
            dataGridView3.Columns[2].HeaderText = "Фамилия";
            dataGridView3.Columns[3].HeaderText = "Оклад";
            dataGridView3.Columns[4].HeaderText = "Код работы";
            dataGridView3.Columns[5].HeaderText = "Оплата за день";
            dataGridView3.Columns[6].HeaderText = "Начало работ";
            dataGridView3.Columns[7].HeaderText = "Окончание работ";
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            String SQLTypeOfWorks = "SELECT ID_TypeOfWork, Code_TypeOfWork, Description_TypeOfWork, Payment_TypeOfWork FROM TypeOfWork WHERE Code_TypeOfWork like '%" + textBox7.Text + "%'";
            SelectDataFromDB();
            string sConnectionString = "server=localhost;user=mysql;database=MyCompanyPractica;port=3303;password=mysql;";
            MySqlConnection Connection = new MySqlConnection(sConnectionString);
            MySqlDataAdapter AdapterWorkers = new MySqlDataAdapter(SQLTypeOfWorks, Connection);
            Connection.Open();
            DataSet ds = new DataSet();
            AdapterWorkers.Fill(ds, "TypeOfWorks");
            dataGridView2.DataSource = ds.Tables["TypeOfWorks"];
            Connection.Close();
            dataGridView2.Columns[0].HeaderText = "ID";
            dataGridView2.Columns[1].HeaderText = "Код";
            dataGridView2.Columns[2].HeaderText = "Описание";
            dataGridView2.Columns[3].HeaderText = "Оплата за день";

            String SQLWorks = "SELECT ID_Works, Workers.Code_Workers, Workers.LastName_Wrokers, Workers.Salary_Workers, TypeOfWork.Code_TypeOfWork, TypeOfWork.Payment_TypeOfWork, StartDate_Works, EndDate_Works FROM Works, Workers, TypeOfWork WHERE Works.Code_Workers = Workers.Code_Workers AND Works.Code_TypeOfWork = TypeOfWork.Code_TypeOfWork AND TypeOfWork.Code_TypeOfWork like '%" + textBox7.Text + "%'";
            MySqlConnection Connection1 = new MySqlConnection(sConnectionString);
            MySqlDataAdapter AdapterWorkers1 = new MySqlDataAdapter(SQLWorks, Connection1);
            Connection1.Open();
            DataSet ds1 = new DataSet();
            AdapterWorkers1.Fill(ds1, "Works");
            dataGridView3.DataSource = ds1.Tables["Works"];
            Connection1.Close();
            dataGridView3.Columns[0].HeaderText = "ID";
            dataGridView3.Columns[1].HeaderText = "Код работника";
            dataGridView3.Columns[2].HeaderText = "Фамилия";
            dataGridView3.Columns[3].HeaderText = "Оклад";
            dataGridView3.Columns[4].HeaderText = "Код работы";
            dataGridView3.Columns[5].HeaderText = "Оплата за день";
            dataGridView3.Columns[6].HeaderText = "Начало работ";
            dataGridView3.Columns[7].HeaderText = "Окончание работ";
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            String SQLTypeOfWorks = "SELECT ID_TypeOfWork, Code_TypeOfWork, Description_TypeOfWork, Payment_TypeOfWork FROM TypeOfWork WHERE Description_TypeOfWork like '%" + textBox8.Text + "%'";
            SelectDataFromDB();
            string sConnectionString = "server=localhost;user=mysql;database=MyCompanyPractica;port=3303;password=mysql;";
            MySqlConnection Connection = new MySqlConnection(sConnectionString);
            MySqlDataAdapter AdapterWorkers = new MySqlDataAdapter(SQLTypeOfWorks, Connection);
            Connection.Open();
            DataSet ds = new DataSet();
            AdapterWorkers.Fill(ds, "TypeOfWorks");
            dataGridView2.DataSource = ds.Tables["TypeOfWorks"];
            Connection.Close();
            dataGridView2.Columns[0].HeaderText = "ID";
            dataGridView2.Columns[1].HeaderText = "Код";
            dataGridView2.Columns[2].HeaderText = "Описание";
            dataGridView2.Columns[3].HeaderText = "Оплата за день";
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            String SQLTypeOfWorks = "SELECT ID_TypeOfWork, Code_TypeOfWork, Description_TypeOfWork, Payment_TypeOfWork FROM TypeOfWork WHERE Payment_TypeOfWork like '%" + textBox9.Text + "%'";
            SelectDataFromDB();
            string sConnectionString = "server=localhost;user=mysql;database=MyCompanyPractica;port=3303;password=mysql;";
            MySqlConnection Connection = new MySqlConnection(sConnectionString);
            MySqlDataAdapter AdapterWorkers = new MySqlDataAdapter(SQLTypeOfWorks, Connection);
            Connection.Open();
            DataSet ds = new DataSet();
            AdapterWorkers.Fill(ds, "TypeOfWorks");
            dataGridView2.DataSource = ds.Tables["TypeOfWorks"];
            Connection.Close();
            dataGridView2.Columns[0].HeaderText = "ID";
            dataGridView2.Columns[1].HeaderText = "Код";
            dataGridView2.Columns[2].HeaderText = "Описание";
            dataGridView2.Columns[3].HeaderText = "Оплата за день";

            String SQLWorks = "SELECT ID_Works, Workers.Code_Workers, Workers.LastName_Wrokers, Workers.Salary_Workers, TypeOfWork.Code_TypeOfWork, TypeOfWork.Payment_TypeOfWork, StartDate_Works, EndDate_Works FROM Works, Workers, TypeOfWork WHERE Works.Code_Workers = Workers.Code_Workers AND Works.Code_TypeOfWork = TypeOfWork.Code_TypeOfWork AND TypeOfWork.Payment_TypeOfWork like '%" + textBox9.Text + "%'";
            MySqlConnection Connection1 = new MySqlConnection(sConnectionString);
            MySqlDataAdapter AdapterWorkers1 = new MySqlDataAdapter(SQLWorks, Connection1);
            Connection1.Open();
            DataSet ds1 = new DataSet();
            AdapterWorkers1.Fill(ds1, "Works");
            dataGridView3.DataSource = ds1.Tables["Works"];
            Connection1.Close();
            dataGridView3.Columns[0].HeaderText = "ID";
            dataGridView3.Columns[1].HeaderText = "Код работника";
            dataGridView3.Columns[2].HeaderText = "Фамилия";
            dataGridView3.Columns[3].HeaderText = "Оклад";
            dataGridView3.Columns[4].HeaderText = "Код работы";
            dataGridView3.Columns[5].HeaderText = "Оплата за день";
            dataGridView3.Columns[6].HeaderText = "Начало работ";
            dataGridView3.Columns[7].HeaderText = "Окончание работ";
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            String SQLTypeOfWorks = "SELECT ID_Works, Workers.Code_Workers, Workers.LastName_Wrokers, Workers.Salary_Workers, TypeOfWork.Code_TypeOfWork, TypeOfWork.Payment_TypeOfWork, StartDate_Works, EndDate_Works FROM Works, Workers, TypeOfWork WHERE Works.Code_Workers = Workers.Code_Workers AND Works.Code_TypeOfWork = TypeOfWork.Code_TypeOfWork AND StartDate_Works like '%" + textBox12.Text + "%'";
            SelectDataFromDB();
            string sConnectionString = "server=localhost;user=mysql;database=MyCompanyPractica;port=3303;password=mysql;";
            MySqlConnection Connection = new MySqlConnection(sConnectionString);
            MySqlDataAdapter AdapterWorkers = new MySqlDataAdapter(SQLTypeOfWorks, Connection);
            Connection.Open();
            DataSet ds = new DataSet();
            AdapterWorkers.Fill(ds, "Works");
            dataGridView3.DataSource = ds.Tables["Works"];
            Connection.Close();
            dataGridView3.Columns[0].HeaderText = "ID";
            dataGridView3.Columns[1].HeaderText = "Код работника";
            dataGridView3.Columns[2].HeaderText = "Фамилия";
            dataGridView3.Columns[3].HeaderText = "Оклад";
            dataGridView3.Columns[4].HeaderText = "Код работы";
            dataGridView3.Columns[5].HeaderText = "Оплата за день";
            dataGridView3.Columns[6].HeaderText = "Начало работ";
            dataGridView3.Columns[7].HeaderText = "Окончание работ";
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            String SQLTypeOfWorks = "SELECT ID_Works, Workers.Code_Workers, Workers.LastName_Wrokers, Workers.Salary_Workers, TypeOfWork.Code_TypeOfWork, TypeOfWork.Payment_TypeOfWork, StartDate_Works, EndDate_Works FROM Works, Workers, TypeOfWork WHERE Works.Code_Workers = Workers.Code_Workers AND Works.Code_TypeOfWork = TypeOfWork.Code_TypeOfWork AND EndDate_Works like '%" + textBox13.Text + "%'";
            SelectDataFromDB();
            string sConnectionString = "server=localhost;user=mysql;database=MyCompanyPractica;port=3303;password=mysql;";
            MySqlConnection Connection = new MySqlConnection(sConnectionString);
            MySqlDataAdapter AdapterWorkers = new MySqlDataAdapter(SQLTypeOfWorks, Connection);
            Connection.Open();
            DataSet ds = new DataSet();
            AdapterWorkers.Fill(ds, "Works");
            dataGridView3.DataSource = ds.Tables["Works"];
            Connection.Close();
            dataGridView3.Columns[0].HeaderText = "ID";
            dataGridView3.Columns[1].HeaderText = "Код работника";
            dataGridView3.Columns[2].HeaderText = "Фамилия";
            dataGridView3.Columns[3].HeaderText = "Оклад";
            dataGridView3.Columns[4].HeaderText = "Код работы";
            dataGridView3.Columns[5].HeaderText = "Оплата за день";
            dataGridView3.Columns[6].HeaderText = "Начало работ";
            dataGridView3.Columns[7].HeaderText = "Окончание работ";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double Oklad = 0, Payment = 0, AllSalary = 0;
            int StrCount = 0, StrCountAll = 0, ii = 0;
            DateTime StartWorks;
            DateTime EndWorks = new DateTime(2000, 1, 1);

            MySqlConnection Connection = new MySqlConnection("server=localhost;user=mysql;database=MyCompanyPractica;port=3303;password=mysql;");
            object Code_Workers = "";
            MySqlCommand command = new MySqlCommand("SELECT Code_Workers FROM Works WHERE Code_Workers = " + textBox1.Text, Connection);
            Connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Code_Workers = reader.GetValue(0);
            }
            reader.Close();
            Connection.Close();
            if (Code_Workers == "")
            {
                MessageBox.Show("У работника нет сверхурочных");                
            }
            else
            {
                //Нахождение оклада
                command = new MySqlCommand("SELECT Salary_Workers FROM Workers WHERE Code_Workers = " + Code_Workers, Connection);
                Connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Oklad = Convert.ToDouble(reader.GetValue(0));
                }
                reader.Close();
                Connection.Close();
                MessageBox.Show("Oklad = " + Convert.ToString(Oklad));                

                //Нахождение количества работ
                command = new MySqlCommand("SELECT count(*) FROM Works WHERE Code_Workers = " + Code_Workers, Connection);
                Connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    StrCount = Convert.ToInt32(reader.GetValue(0));                    
                }
                reader.Close();
                Connection.Close();
                MessageBox.Show("Количество работ = " + Convert.ToString(StrCount));

                //Нахождение количества всех записей
                command = new MySqlCommand("select * from Works where ID_Works=(select max(ID_Works) from Works) ", Connection);
                Connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    StrCountAll = Convert.ToInt32(reader.GetValue(0));
                }
                reader.Close(); 
                MessageBox.Show("Количество всех работ = " + Convert.ToString(StrCountAll));

                double[] SumPayment = new double[StrCount];
                int IndexPayment = 0;
                //Сумма оплаты
                while (ii  < StrCountAll)
                {
                    int foo = 0;
                    next: if (foo == 1)
                    {
                        ii++;
                        continue;
                    }
                    ii++;
                    //Connection.Close();
                    command = new MySqlCommand("SELECT StartDate_Works FROM Works WHERE ID_Works = " + (ii + 1) + 
                        " AND Code_Workers = " + Code_Workers, Connection);
                    //Connection.Open();

                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        //Нахождение дат работ
                        if (reader.GetValue(0) != "")
                        {
                            foo = 0;
                            //Получение начальной даты
                            StartWorks = Convert.ToDateTime(reader.GetValue(0));
                            Connection.Close();
                            MessageBox.Show("Начальная дата = " + Convert.ToString(StartWorks));

                            //Получение конечной даты
                            command = new MySqlCommand("SELECT EndDate_Works FROM Works WHERE ID_Works = " + (ii + 1) +
                                " AND Code_Workers = " + Code_Workers, Connection);
                            Connection.Open();
                            MySqlDataReader reader2 = command.ExecuteReader();
                            while (reader2.Read())
                            {
                                EndWorks = Convert.ToDateTime(reader2.GetValue(0));
                            }
                            reader2.Close();
                            MessageBox.Show("Конечная дата = " + Convert.ToString(EndWorks));

                            //Получение дней
                            int TotalDays = ((TimeSpan)(EndWorks - StartWorks)).Days + 1;
                            MessageBox.Show("Итого дней = " + Convert.ToString(TotalDays));

                            //Connection.Close();
                            //Нахождение оплаты за день
                            command = new MySqlCommand("SELECT TypeOfWork.Payment_TypeOfWork FROM Works, TypeOfWork WHERE Works.Code_TypeOfWork = TypeOfWork.Code_TypeOfWork AND ID_Works = " + (ii + 1) +
                                " AND Code_Workers = " + Code_Workers, Connection);
                            //Connection.Open();
                            reader2 = command.ExecuteReader();
                            while (reader2.Read())
                            {
                                Payment = Convert.ToDouble(reader2.GetValue(0));
                            }
                            reader2.Close();
                            MessageBox.Show("Оплата за день = " + Convert.ToString(Payment));

                            //Получение начислений за все дни
                            SumPayment[IndexPayment] = Convert.ToDouble(TotalDays) * Payment;
                            MessageBox.Show("Оплата за все дни работы = " + Convert.ToString(SumPayment[IndexPayment]));
                            IndexPayment++;
                            goto next;
                        }
                        else
                        {
                            foo = 1;
                            goto next;
                        }
                    }
                    reader.Close(); 
                }
                Connection.Close();

                AllSalary += Oklad;
                for (int i = 0; i < StrCount; i++)
                    AllSalary += + SumPayment[i];
                MessageBox.Show("Общие начисления = " + AllSalary);
                textBox1.Text = Convert.ToString(AllSalary);
            }

        }
    }
}
