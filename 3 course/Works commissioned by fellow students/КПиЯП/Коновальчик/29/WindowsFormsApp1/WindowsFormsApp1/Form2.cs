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
    public partial class Form2 : Form
    {
        public MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=");
        public MySqlDataAdapter adapter;
        public MySqlCommand command;
        public int id_detali = 0;
        public int id_postavshik = 0;
        public int id_postavki = 0;

        public Form2(Form1 parent, string caption)
        {
            InitializeComponent();

            this.MdiParent = parent;
            this.Text = caption;

            switch (this.Text)
            {
                case "Детали":
                    {
                        Detali();
                        break;
                    }
                case "Поставщик":
                    {
                        Postavshik();
                        break;
                    }
                case "Поставки":
                    {
                        Detali();
                        Postavshik();
                        Postavki();
                        break;
                    }
            }
        }

        public void Detali()
        {
            adapter = new MySqlDataAdapter("SELECT * FROM Firma.Detali", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Detali");
            connection.Close();
            dataGridView1.DataSource = ds.Tables["Detali"];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Название";
            dataGridView1.Columns[2].HeaderText = "Артикул";
            dataGridView1.Columns[3].HeaderText = "Цена";
            dataGridView1.Columns[4].HeaderText = "Примечание";
            dataGridView1.Columns[0].Visible = false;
            comboBox1.DataSource = ds.Tables["Detali"];
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "name";
        }

        public void Postavshik()
        {
            adapter = new MySqlDataAdapter("SELECT * FROM Firma.Postavshik", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Postavshik");
            connection.Close();
            dataGridView1.DataSource = ds.Tables["Postavshik"];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Название";
            dataGridView1.Columns[2].HeaderText = "Адрес";
            dataGridView1.Columns[3].HeaderText = "Телефон";
            dataGridView1.Columns[0].Visible = false;
            comboBox2.DataSource = ds.Tables["Postavshik"];
            comboBox2.DisplayMember = "name";
            comboBox2.ValueMember = "name";
        }

        public void Postavki()
        {
            adapter = new MySqlDataAdapter("SELECT Postavki.id, Postavshik.name, Detali.name, kolichestvo, data FROM Firma.Postavki, " +
                "Firma.Detali, Firma.Postavshik WHERE Postavki.id = Detali.id AND Postavki.id = Postavshik.id", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Postavki");
            connection.Close();
            dataGridView1.DataSource = ds.Tables["Postavki"];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Название поставщика";
            dataGridView1.Columns[2].HeaderText = "Название детали";
            dataGridView1.Columns[3].HeaderText = "Количество";
            dataGridView1.Columns[4].HeaderText = "Дата";
            dataGridView1.Columns[0].Visible = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (this.Text == "Детали")
            {
                comboBox1.Visible = false;
                comboBox2.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                maskedTextBox1.Visible = false;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                label6.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label3.Text = "Название";
                label4.Text = "Артикул";
                label5.Text = "Цена";
                label6.Text = "Примечание";

            }
            else if (this.Text == "Поставщик")
            {
                comboBox1.Visible = false;
                comboBox2.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                maskedTextBox1.Visible = false;
                textBox1.Visible = true;
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = false;
                label6.Visible = false;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                label3.Text = "Название";
                label4.Text = "Адрес";
                label5.Text = "Телефон";
            }
            else
            {
                comboBox1.Visible = true;
                comboBox2.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label6.Visible = true;
                label4.Visible = false;
                label5.Visible = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                maskedTextBox1.Visible = true;
                label3.Text = "Количество";
                label6.Text = "Дата";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.Text == "Детали")
            {
                try
                {
                    if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                        MessageBox.Show("Заполните все поля!");
                    else
                    {
                        command = new MySqlCommand("INSERT INTO Firma.Detali(name, artikul, cena, primechanie) " +
                            "VALUES ('" + textBox1.Text + "', " + textBox2.Text + ", " + textBox3.Text + ", '" + textBox4.Text + "')", connection);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        Detali();
                    }
                }
                catch (Exception) { }
            }
            else if (this.Text == "Поставщик")
            {
                try
                {
                    if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                        MessageBox.Show("Заполните все поля!");
                    else
                    {
                        command = new MySqlCommand("INSERT INTO Firma.Postavshik(name, adress, telephone) " +
                            "VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', " + textBox3.Text + ")", connection);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        Postavshik();
                    }
                }
                catch (Exception) { }
            }
            else
            {
                try
                {
                    if (textBox1.Text == "" || maskedTextBox1.Text == "")
                        MessageBox.Show("Заполните все поля!");
                    else
                    {
                        command = new MySqlCommand("SELECT id FROM Firma.Detali WHERE name  = '" + comboBox2.Text + "')", connection);
                        connection.Open();
                        DataSet ds1 = new DataSet();
                        adapter.Fill(ds1, "Detali");
                        connection.Close();
                        dataGridView1.DataSource = ds1.Tables["Detali"];
                        int temp1 = Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value);

                        command = new MySqlCommand("SELECT id FROM Firma.Postavshik WHERE name  = '" + comboBox1.Text + "')", connection);
                        connection.Open();
                        DataSet ds2 = new DataSet();
                        adapter.Fill(ds2, "Postavshik");
                        connection.Close();
                        dataGridView1.DataSource = ds2.Tables["Postavshik"];
                        int temp2 = Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value);

                        command = new MySqlCommand("INSERT INTO Firma.Postavki(id_postavshik, id_detali, kolichestvo, data) " +
                            "VALUES (" + temp2 + ", " + temp1 + ", " + textBox1.Text + ", '" + maskedTextBox1.Text + "')", connection);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        Detali();
                        Postavshik();
                        Postavki();
                    }
                }
                catch (Exception) { }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.Text == "Детали")
            {
                try
                {
                    if (id_detali == 0)
                        MessageBox.Show("Вы ничего не выбрали!");
                    else
                    {
                        if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                            MessageBox.Show("Заполните все поля!");
                        else
                        {
                            command = new MySqlCommand("UPDATE Firma.Detali SET name = '" + textBox1.Text + "', artikul = " + textBox2.Text +
                                ", cena = " + textBox3.Text + ", primechanie = '" + textBox4.Text + "' WHERE id = " + id_detali, connection);
                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();
                            Detali();
                            id_detali = 0;
                        }
                    }
                }
                catch (Exception) { }
            }
            else if (this.Text == "Поставщик")
            {
                try
                {
                    if (id_postavshik == 0)
                        MessageBox.Show("Вы ничего не выбрали!");
                    else
                    {
                        if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                            MessageBox.Show("Заполните все поля!");
                        else
                        {
                            command = new MySqlCommand("UPDATE Firma.Postavshik SET name = '" + textBox1.Text + "', adress = '" + textBox2.Text +
                                "', telephone = " + textBox3.Text + " WHERE id = " + id_postavshik, connection);
                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();
                            Postavshik();
                            id_postavshik = 0;
                        }
                    }
                }
                catch (Exception) { }
            }
            else
            {
                try
                {
                    if (id_postavki == 0)
                        MessageBox.Show("Вы ничего не выбрали!");
                    else
                    {
                        if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                            MessageBox.Show("Заполните все поля!");
                        else
                        {
                            command = new MySqlCommand("SELECT id FROM Firma.Detali WHERE name  = '" + comboBox2.Text + "')", connection);
                            connection.Open();
                            DataSet ds1 = new DataSet();
                            adapter.Fill(ds1, "Detali");
                            connection.Close();
                            dataGridView1.DataSource = ds1.Tables["Detali"];
                            int temp1 = Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value);

                            command = new MySqlCommand("SELECT id FROM Firma.Postavshik WHERE name  = '" + comboBox1.Text + "')", connection);
                            connection.Open();
                            DataSet ds2 = new DataSet();
                            adapter.Fill(ds2, "Postavshik");
                            connection.Close();
                            dataGridView1.DataSource = ds2.Tables["Postavshik"];
                            int temp2 = Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value);

                            command = new MySqlCommand("UPDATE Firma.Postavki SET id_postavshik = " + temp2 + ", id_detali = " + temp1 +
                                ", kolichestvo = " + textBox1.Text + ", '" + maskedTextBox1.Text + "' WHERE id = " + id_postavki, connection);
                            connection.Open();
                            command.ExecuteNonQuery();
                            connection.Close();
                            Detali();
                            Postavshik();
                            Postavki();
                            id_postavki = 0;
                        }
                    }
                }
                catch (Exception) { }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.Text == "Детали")
            {
                try
                {
                    if (id_detali == 0)
                        MessageBox.Show("Вы ничего не выбрали!");
                    else
                    {
                        command = new MySqlCommand("DELETE FROM Firma.Detali WHERE id = " + id_detali, connection);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        Detali();
                        id_detali = 0;
                    }
                }
                catch (Exception) { }
            }
            else if (this.Text == "Поставщик")
            {
                try
                {
                    if (id_postavshik == 0)
                        MessageBox.Show("Вы ничего не выбрали!");
                    else
                    {
                        command = new MySqlCommand("DELETE FROM Firma.Postavshik WHERE id = " + id_postavshik, connection);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        Postavshik();
                        id_postavshik = 0;
                    }
                }
                catch (Exception) { }
            }
            else
            {
                try
                {
                    if (id_postavki == 0)
                        MessageBox.Show("Вы ничего не выбрали!");
                    else
                    {
                        command = new MySqlCommand("DELETE FROM Firma.Postavki WHERE id = " + id_postavki, connection);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        Postavki();
                        id_postavki = 0;
                    }
                }
                catch (Exception) { }
            }
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.Text == "Детали")
            {
                try
                {
                    id_detali = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                }
                catch (Exception) { }
            }
            else if (this.Text == "Поставщик")
            {
                try
                {
                    id_postavshik = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                }
                catch (Exception) { }
            }
            else
            {
                try
                {
                    id_postavki = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();                    
                }
                catch (Exception) { }
            }
        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    ExcelApp.Cells[i + 1, j + 1] = dataGridView1.Rows[i].Cells[j].Value;
                }
            }
            ExcelApp.Visible = true;
            ExcelApp.UserControl = true;
        }
    }
}
