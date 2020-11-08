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
using Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office;
using System.Reflection;
using Excel1 = Microsoft.Office.Interop.Excel;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=");
        public MySqlDataAdapter adapter;
        public MySqlCommand command;

        public int id_strana = 0;
        public int id_obl = 0;
        public int id_gorod = 0;
        public int id_campony = 0;
        public int id_typetovar = 0;
        public int id_tovar = 0;
        public int id_transport = 0;
        public int id_transportirovka = 0;
        public int id_max = 0;

        public Form1()
        {
            InitializeComponent();
            all();
        }

        public void strana()
        {
            adapter = new MySqlDataAdapter("SELECT * FROM kursproject.strana", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "strana");
            connection.Close();
            dataGridView1.DataSource = ds.Tables["strana"];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Название";
            comboBox1.DataSource = ds.Tables["strana"];
            comboBox1.DisplayMember = "Название";
            comboBox1.ValueMember = "Название";
            dataGridView1.Columns[0].Visible = false;
        }

        public void obl()
        {
            adapter = new MySqlDataAdapter("SELECT id_obl, Название, nazvanie FROM kursproject.obl, kursproject.strana WHERE obl.id_strana = " +
                "strana.id_strana", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "obl");
            connection.Close();
            dataGridView2.DataSource = ds.Tables["obl"];
            dataGridView2.Columns[0].HeaderText = "ID";
            dataGridView2.Columns[1].HeaderText = "Страна";
            dataGridView2.Columns[2].HeaderText = "Область";
            comboBox2.DataSource = ds.Tables["obl"];
            comboBox2.DisplayMember = "nazvanie";
            comboBox2.ValueMember = "nazvanie";
            dataGridView2.Columns[0].Visible = false;
        }

        public void gorod()
        {
            adapter = new MySqlDataAdapter("SELECT id_gorod, Название, gorod.nazvanie, obl.nazvanie FROM kursproject.obl, " +
                "kursproject.strana, kursproject.gorod WHERE obl.id_strana = strana.id_strana AND gorod.id_obl = obl.id_obl", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "gorod");
            connection.Close();
            dataGridView3.DataSource = ds.Tables["gorod"];
            dataGridView3.Columns[0].HeaderText = "ID";
            dataGridView3.Columns[1].HeaderText = "Страна";
            dataGridView3.Columns[2].HeaderText = "Город";
            dataGridView3.Columns[3].HeaderText = "Область";
            comboBox3.DataSource = ds.Tables["gorod"];
            comboBox3.DisplayMember = "nazvanie";
            comboBox3.ValueMember = "nazvanie";
            dataGridView3.Columns[0].Visible = false;
        }

        public void campony()
        {
            adapter = new MySqlDataAdapter("SELECT id_campony, Название, campony.nazvanie, gorod.nazvanie, obl.nazvanie, " +
                "adress FROM kursproject.obl, kursproject.strana, kursproject.gorod, kursproject.campony WHERE " +
                "obl.id_strana = strana.id_strana AND gorod.id_obl = obl.id_obl AND campony.id_gorod = gorod.id_gorod", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "campony");
            connection.Close();
            dataGridView4.DataSource = ds.Tables["campony"];
            dataGridView4.Columns[0].HeaderText = "ID";
            dataGridView4.Columns[1].HeaderText = "Страна";
            dataGridView4.Columns[2].HeaderText = "Компания";
            dataGridView4.Columns[3].HeaderText = "Город";
            dataGridView4.Columns[4].HeaderText = "Область";
            dataGridView4.Columns[5].HeaderText = "Адрес";
            comboBox5.DataSource = ds.Tables["campony"];
            comboBox5.DisplayMember = "nazvanie";
            comboBox5.ValueMember = "nazvanie";
            dataGridView4.Columns[0].Visible = false;
        }

        public void typetovar()
        {
            adapter = new MySqlDataAdapter("SELECT * FROM kursproject.typetovar", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "typetovar");
            connection.Close();
            dataGridView5.DataSource = ds.Tables["typetovar"];
            dataGridView5.Columns[0].HeaderText = "ID";
            dataGridView5.Columns[1].HeaderText = "Наименование";
            comboBox4.DataSource = ds.Tables["typetovar"];
            comboBox4.DisplayMember = "naimenovanietipa";
            comboBox4.ValueMember = "naimenovanietipa";
            dataGridView5.Columns[0].Visible = false;
        }

        public void tovar()
        {
            adapter = new MySqlDataAdapter("SELECT id_tovar, naimenovanietipa, nazvanietovara, dataizg, kolichest, cena " +
                "FROM kursproject.tovar, kursproject.typetovar WHERE tovar.id_typetovar = typetovar.id_typetovar", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "tovar");
            connection.Close();
            dataGridView6.DataSource = ds.Tables["tovar"];
            dataGridView6.Columns[0].HeaderText = "ID";
            dataGridView6.Columns[1].HeaderText = "Тип";
            dataGridView6.Columns[2].HeaderText = "Название";
            dataGridView6.Columns[3].HeaderText = "Дата изготовления";
            dataGridView6.Columns[4].HeaderText = "Количество";
            dataGridView6.Columns[5].HeaderText = "Цена";
            comboBox7.DataSource = ds.Tables["tovar"];
            comboBox7.DisplayMember = "nazvanietovara";
            comboBox7.ValueMember = "nazvanietovara";
            dataGridView6.Columns[0].Visible = false;
        }

        public void transport()
        {
            adapter = new MySqlDataAdapter("SELECT * FROM kursproject.transport", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "transport");
            connection.Close();
            dataGridView7.DataSource = ds.Tables["transport"];
            dataGridView7.Columns[0].HeaderText = "ID";
            dataGridView7.Columns[1].HeaderText = "Марка";
            dataGridView7.Columns[2].HeaderText = "Модель";
            dataGridView7.Columns[3].HeaderText = "Грузоподъемность";
            dataGridView7.Columns[4].HeaderText = "Номер";
            comboBox6.DataSource = ds.Tables["transport"];
            comboBox6.DisplayMember = "gosnumber";
            comboBox6.ValueMember = "gosnumber";
            dataGridView7.Columns[0].Visible = false;
        }

        public void transportirovka()
        {
            adapter = new MySqlDataAdapter("SELECT id_transportirovka, Название, gorod.nazvanie, obl.nazvanie, campony.nazvanie, " +
                "adress, gryzopod, gosnumber, nazvanietovara, naimenovanietipa, kolichest, cena FROM kursproject.obl, kursproject.strana, " +
                "kursproject.gorod, kursproject.campony, kursproject.tovar, kursproject.typetovar, kursproject.transport," +
                "kursproject.transportirovka WHERE obl.id_strana = strana.id_strana AND gorod.id_obl = obl.id_obl AND " +
                "campony.id_gorod = gorod.id_gorod AND tovar.id_typetovar = typetovar.id_typetovar AND " +
                "transportirovka.id_campony = campony.id_campony AND transportirovka.id_tovar = tovar.id_tovar AND " +
                "transportirovka.id_transport = transport.id_transport", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "transportirovka");
            connection.Close();
            dataGridView8.DataSource = ds.Tables["transportirovka"];
            dataGridView8.Columns[0].HeaderText = "ID";
            dataGridView8.Columns[1].HeaderText = "Страна";
            dataGridView8.Columns[2].HeaderText = "Город";
            dataGridView8.Columns[3].HeaderText = "Область";
            dataGridView8.Columns[4].HeaderText = "Компания";
            dataGridView8.Columns[5].HeaderText = "Адрес";
            dataGridView8.Columns[6].HeaderText = "Грузоподъемность";
            dataGridView8.Columns[7].HeaderText = "Номер авто";
            dataGridView8.Columns[8].HeaderText = "Название товара";
            dataGridView8.Columns[9].HeaderText = "Тип товара";
            dataGridView8.Columns[10].HeaderText = "Количество товара";
            dataGridView8.Columns[11].HeaderText = "Цена";
            dataGridView8.Columns[0].Visible = false;
            dataGridView8.Columns[11].Visible = false;
        }

        public void all()
        {
            strana();
            obl();
            gorod();
            campony();
            typetovar();
            tovar();
            transport();
            transportirovka();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("Заполните поле!");
            else
            {
                adapter = new MySqlDataAdapter("SELECT id_strana FROM kursproject.strana ORDER BY id_strana DESC LIMIT 1", connection);
                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "strana");
                connection.Close();
                dataGridView1.DataSource = ds.Tables["strana"];
                command = new MySqlCommand("INSERT INTO kursproject.strana(id_strana, Название) " +
                    "VALUES (" + (Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value) + 1).ToString() + ", '" + textBox1.Text + "')", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                all();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (id_strana == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            else
            {
                if (textBox1.Text == "")
                    MessageBox.Show("Заполните поле!");
                else
                {
                    command = new MySqlCommand("UPDATE kursproject.strana SET Название = '" + textBox1.Text + "'" +
                        "WHERE id_strana = " + id_strana, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    id_strana = 0;
                    all();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (id_strana == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            else
            {
                command = new MySqlCommand("DELETE FROM kursproject.strana WHERE id_strana = '" + id_strana + "'", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                id_strana = 0;
                all();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
                MessageBox.Show("Заполните все поля!");
            else
            {
                adapter = new MySqlDataAdapter("SELECT id_strana FROM kursproject.strana WHERE Название = '" + comboBox1.Text + "'", connection);
                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "strana");
                connection.Close();
                dataGridView2.DataSource = ds.Tables["strana"];
                string temp = dataGridView2.Rows[0].Cells[0].Value.ToString();

                adapter = new MySqlDataAdapter("SELECT id_obl FROM kursproject.obl ORDER BY id_obl DESC LIMIT 1", connection);
                connection.Open();
                DataSet ds1 = new DataSet();
                adapter.Fill(ds1, "obl");
                connection.Close();
                dataGridView2.DataSource = ds1.Tables["obl"];

                command = new MySqlCommand("INSERT INTO kursproject.obl(id_obl, id_strana, nazvanie) " +
                    "VALUES (" + (Convert.ToInt32(dataGridView2.Rows[0].Cells[0].Value) + 1).ToString() + ", " +
                    temp + ", '" + textBox2.Text + "')", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                all();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (id_gorod == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            if (textBox3.Text == "")
                MessageBox.Show("Заполните все поля!");
            else
            {
                adapter = new MySqlDataAdapter("SELECT id_obl FROM kursproject.obl WHERE nazvanie = '" + comboBox2.Text + "'", connection);
                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "obl");
                connection.Close();
                dataGridView2.DataSource = ds.Tables["obl"];
                string temp = dataGridView2.Rows[0].Cells[0].Value.ToString();

                command = new MySqlCommand("UPDATE kursproject.gorod SET id_obl = " + temp + ", nazvanie = '" + textBox3.Text +
                    "' WHERE id_gorod = " + id_gorod, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                id_gorod = 0;
                all();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (id_gorod == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            else
            {
                command = new MySqlCommand("DELETE FROM kursproject.gorod WHERE id_gorod = '" + id_gorod + "'", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                id_gorod = 0;
                all();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (id_obl == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            else
            {
                if (textBox2.Text == "")
                    MessageBox.Show("Заполните все поля!");
                else
                {
                    adapter = new MySqlDataAdapter("SELECT id_strana FROM kursproject.strana WHERE Название = '" + comboBox1.Text + "'", connection);
                    connection.Open();
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "strana");
                    connection.Close();
                    dataGridView2.DataSource = ds.Tables["strana"];
                    string temp = dataGridView2.Rows[0].Cells[0].Value.ToString();

                    command = new MySqlCommand("UPDATE kursproject.obl SET id_strana = " + temp + ", nazvanie = '" + textBox2.Text +
                        "' WHERE id_obl = " + id_obl, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    id_obl = 0;
                    all();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (id_obl == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            else
            {
                command = new MySqlCommand("DELETE FROM kursproject.obl WHERE id_obl = '" + id_obl + "'", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                id_obl = 0;
                all();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_strana = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_obl = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
            textBox2.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            comboBox1.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_gorod = Convert.ToInt32(dataGridView3.CurrentRow.Cells[0].Value);
            comboBox2.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString();
            textBox3.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
                MessageBox.Show("Заполните все поля!");
            else
            {
                adapter = new MySqlDataAdapter("SELECT id_obl FROM kursproject.obl WHERE nazvanie = '" + comboBox2.Text + "'", connection);
                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "obl");
                connection.Close();
                dataGridView3.DataSource = ds.Tables["obl"];
                string temp = dataGridView3.Rows[0].Cells[0].Value.ToString();

                adapter = new MySqlDataAdapter("SELECT id_gorod FROM kursproject.gorod ORDER BY id_gorod DESC LIMIT 1", connection);
                connection.Open();
                DataSet ds1 = new DataSet();
                adapter.Fill(ds1, "gorod");
                connection.Close();
                dataGridView3.DataSource = ds1.Tables["gorod"];

                command = new MySqlCommand("INSERT INTO kursproject.gorod(id_gorod, id_obl, nazvanie) " +
                    "VALUES (" + (Convert.ToInt32(dataGridView3.Rows[0].Cells[0].Value) + 1).ToString() + ", " +
                    temp + ", '" + textBox3.Text + "')", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                all();
            }
        }

        private void опрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.ShowDialog(this);
        }

        private void отчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
                Export_Data_To_Excel(dataGridView1);
            else if (tabControl1.SelectedIndex == 1)
                Export_Data_To_Excel(dataGridView2);
            else if (tabControl1.SelectedIndex == 2)
                Export_Data_To_Excel(dataGridView3);
            else if (tabControl1.SelectedIndex == 3)
                Export_Data_To_Excel(dataGridView4);
            else if (tabControl1.SelectedIndex == 4)
                Export_Data_To_Excel(dataGridView5);
            else if (tabControl1.SelectedIndex == 5)
                Export_Data_To_Excel(dataGridView6);
            else if (tabControl1.SelectedIndex == 6)
                Export_Data_To_Excel(dataGridView7);
            else if (tabControl1.SelectedIndex == 7)
                Export_Data_To_Excel(dataGridView8);
        }        

        public void Export_Data_To_Excel(DataGridView DGV)
        {
            try
            {
                Excel1.Application exApp_New = new Excel1.Application();
                Excel1.Workbook wb_New = null;
                Excel1.Worksheet ws_New = null;

                wb_New = exApp_New.Workbooks.Add(System.Reflection.Missing.Value);
                ws_New = (Microsoft.Office.Interop.Excel.Worksheet)wb_New.Worksheets.get_Item(1);
                ws_New.Cells.Locked = false;

                //Ширина столбцов
                Excel1.Range rangeWidth1 = ws_New.Range["A1", System.Type.Missing];
                rangeWidth1.EntireColumn.ColumnWidth = 20;
                Excel1.Range rangeWidth2 = ws_New.Range["B1", System.Type.Missing];
                rangeWidth2.EntireColumn.ColumnWidth = 20;
                Excel1.Range rangeWidth3 = ws_New.Range["C1", System.Type.Missing];
                rangeWidth3.EntireColumn.ColumnWidth = 20;
                Excel1.Range rangeWidth4 = ws_New.Range["D1", System.Type.Missing];
                rangeWidth4.EntireColumn.ColumnWidth = 20;
                Excel1.Range rangeWidth5 = ws_New.Range["E1", System.Type.Missing];
                rangeWidth5.EntireColumn.ColumnWidth = 20;
                Excel1.Range rangeWidth6 = ws_New.Range["F1", System.Type.Missing];
                rangeWidth6.EntireColumn.ColumnWidth = 20;
                Excel1.Range rangeWidth7 = ws_New.Range["G1", System.Type.Missing];
                rangeWidth7.EntireColumn.ColumnWidth = 20;
                Excel1.Range rangeWidth8 = ws_New.Range["H1", System.Type.Missing];
                rangeWidth8.EntireColumn.ColumnWidth = 20;
                Excel1.Range rangeWidth9 = ws_New.Range["I1", System.Type.Missing];
                rangeWidth9.EntireColumn.ColumnWidth = 20;
                Excel1.Range rangeWidth10 = ws_New.Range["J1", System.Type.Missing];
                rangeWidth10.EntireColumn.ColumnWidth = 20;

                Excel1.Range rangeHeader1 = null;
                //Шапка таблицы
                for (int i = 1; i < DGV.Columns.Count; i++)
                    rangeHeader1 = ws_New.Cells[1, i];
                rangeHeader1.Font.Name = "Times New Roman";
                rangeHeader1.Font.Size = 10;
                rangeHeader1.HorizontalAlignment = Excel1.XlHAlign.xlHAlignCenter;
                rangeHeader1.VerticalAlignment = Excel1.XlVAlign.xlVAlignCenter;
                rangeHeader1.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                rangeHeader1.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                for (int i = 1; i < DGV.Columns.Count; i++)                
                    ws_New.Cells[1, i] = DGV.Columns[i].HeaderText;

                //Из dataGridView в Excel
                for (int i = 1; i < DGV.ColumnCount; i++)
                {
                    for (int j = 0; j < DGV.RowCount - 1; j++)
                    {
                        ws_New.Cells[j + 2, i] = DGV[i, j].Value.ToString();
                        Excel1.Range rangeBord1 = ws_New.Cells[j + 2, i];
                        rangeBord1.Font.Name = "Times New Roman";
                        rangeBord1.Font.Size = 10;
                        rangeBord1.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                        rangeBord1.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                        Excel1.Range rangeBJ = ws_New.Cells[j + 1, i + 2];
                        rangeBJ.HorizontalAlignment = Excel1.XlHAlign.xlHAlignRight;
                        rangeBJ.VerticalAlignment = Excel1.XlVAlign.xlVAlignCenter;

                    }
                }

                exApp_New.Visible = true;

                System.Runtime.InteropServices.Marshal.ReleaseComObject(exApp_New);
                exApp_New = null;
                wb_New = null;
                ws_New = null;
                System.GC.Collect();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }    
        
        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_campony = Convert.ToInt32(dataGridView4.CurrentRow.Cells[0].Value);
            textBox5.Text = dataGridView4.CurrentRow.Cells[5].Value.ToString();
            textBox4.Text = dataGridView4.CurrentRow.Cells[2].Value.ToString();
            comboBox3.Text = dataGridView4.CurrentRow.Cells[3].Value.ToString();
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            if (textBox4.Text == "" || textBox5.Text == "")
                MessageBox.Show("Заполните все поля!");
            else
            {
                adapter = new MySqlDataAdapter("SELECT id_gorod FROM kursproject.gorod WHERE nazvanie = '" + comboBox3.Text + "'", connection);
                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "gorod");
                connection.Close();
                dataGridView4.DataSource = ds.Tables["gorod"];
                string temp = dataGridView4.Rows[0].Cells[0].Value.ToString();

                adapter = new MySqlDataAdapter("SELECT id_campony FROM kursproject.campony ORDER BY id_campony DESC LIMIT 1", connection);
                connection.Open();
                DataSet ds1 = new DataSet();
                adapter.Fill(ds1, "campony");
                connection.Close();
                dataGridView4.DataSource = ds1.Tables["campony"];

                command = new MySqlCommand("INSERT INTO kursproject.campony(id_campony, id_gorod, nazvanie, adress) " +
                    "VALUES (" + (Convert.ToInt32(dataGridView4.Rows[0].Cells[0].Value) + 1).ToString() + ", " +
                    temp + ", '" + textBox4.Text + "', '" + textBox5.Text + "')", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                all();
            }
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            if (id_campony == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            if (textBox4.Text == "" || textBox5.Text == "")
                MessageBox.Show("Заполните все поля!");
            else
            {
                adapter = new MySqlDataAdapter("SELECT id_gorod FROM kursproject.gorod WHERE nazvanie = '" + comboBox3.Text + "'", connection);
                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "gorod");
                connection.Close();
                dataGridView4.DataSource = ds.Tables["gorod"];
                string temp = dataGridView4.Rows[0].Cells[0].Value.ToString();

                command = new MySqlCommand("UPDATE kursproject.campony SET id_gorod = " + temp + ", nazvanie = '" + textBox4.Text +
                    "', adress = '" + textBox5.Text + "' WHERE id_campony = " + id_campony, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                id_campony = 0;
                all();
            }
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            if (id_campony == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            else
            {
                command = new MySqlCommand("DELETE FROM kursproject.campony WHERE id_campony = '" + id_campony + "'", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                id_campony = 0;
                all();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
                MessageBox.Show("Заполните поле!");
            else
            {
                adapter = new MySqlDataAdapter("SELECT id_typetovar FROM kursproject.typetovar ORDER BY id_typetovar DESC LIMIT 1", connection);
                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "typetovar");
                connection.Close();
                dataGridView5.DataSource = ds.Tables["typetovar"];
                command = new MySqlCommand("INSERT INTO kursproject.typetovar(id_typetovar, naimenovanietipa) " +
                    "VALUES (" + (Convert.ToInt32(dataGridView5.Rows[0].Cells[0].Value) + 1).ToString() + ", '" + textBox6.Text + "')", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                all();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (id_typetovar == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            if (textBox6.Text == "")
                MessageBox.Show("Заполните поле!");
            else
            {
                command = new MySqlCommand("UPDATE kursproject.typetovar SET naimenovanietipa = '" + textBox6.Text +
                    "' WHERE id_typetovar = " + id_typetovar, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                id_typetovar = 0;
                all();
            }
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_typetovar = Convert.ToInt32(dataGridView5.CurrentRow.Cells[0].Value);
            textBox6.Text = dataGridView5.CurrentRow.Cells[1].Value.ToString();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (id_typetovar == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            else
            {
                command = new MySqlCommand("DELETE FROM kursproject.typetovar WHERE id_typetovar = '" + id_typetovar + "'", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                id_typetovar = 0;
                all();
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "" || maskedTextBox1.Text == "")
                MessageBox.Show("Заполните все поля!");
            else
            {
                adapter = new MySqlDataAdapter("SELECT id_typetovar FROM kursproject.typetovar WHERE naimenovanietipa = '" + comboBox4.Text + "'", connection);
                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "typetovar");
                connection.Close();
                dataGridView6.DataSource = ds.Tables["typetovar"];
                string temp = dataGridView6.Rows[0].Cells[0].Value.ToString();

                adapter = new MySqlDataAdapter("SELECT id_tovar FROM kursproject.tovar ORDER BY id_tovar DESC LIMIT 1", connection);
                connection.Open();
                DataSet ds1 = new DataSet();
                adapter.Fill(ds1, "tovar");
                connection.Close();
                dataGridView6.DataSource = ds1.Tables["tovar"];

                command = new MySqlCommand("INSERT INTO kursproject.tovar(id_tovar, id_typetovar, nazvanietovara, dataizg, kolichest, cena) " +
                    "VALUES (" + (Convert.ToInt32(dataGridView6.Rows[0].Cells[0].Value) + 1).ToString() + ", " +
                    temp + ", '" + textBox7.Text + "', '" + maskedTextBox1.Text + "', '" + textBox8.Text +
                    "', '" + textBox9.Text + "')", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                all();
            }
        }

        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_tovar = Convert.ToInt32(dataGridView6.CurrentRow.Cells[0].Value);
            textBox7.Text = dataGridView6.CurrentRow.Cells[2].Value.ToString();
            textBox8.Text = dataGridView6.CurrentRow.Cells[4].Value.ToString();
            textBox9.Text = dataGridView6.CurrentRow.Cells[5].Value.ToString();
            comboBox4.Text = dataGridView6.CurrentRow.Cells[1].Value.ToString();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (id_tovar == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            else
            {
                if (textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "" || maskedTextBox1.Text == "")
                    MessageBox.Show("Заполните все поля!");
                else
                {
                    adapter = new MySqlDataAdapter("SELECT id_typetovar FROM kursproject.typetovar WHERE naimenovanietipa = '" + comboBox4.Text + "'", connection);
                    connection.Open();
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "typetovar");
                    connection.Close();
                    dataGridView6.DataSource = ds.Tables["typetovar"];
                    string temp = dataGridView6.Rows[0].Cells[0].Value.ToString();

                    command = new MySqlCommand("UPDATE kursproject.tovar SET id_typetovar = " + temp + ", nazvanietovara = '" + textBox7.Text +
                        "', dataizg = '" + maskedTextBox1.Text + "', kolichest = '" + textBox8.Text + "', cena = '" +
                        textBox9.Text + "' WHERE id_tovar = " + id_tovar, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    id_tovar = 0;
                    all();
                }
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (id_tovar == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            else
            {
                command = new MySqlCommand("DELETE FROM kursproject.tovar WHERE id_tovar = '" + id_tovar + "'", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                id_tovar = 0;
                all();
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (textBox10.Text == "" || textBox11.Text == "" || textBox12.Text == "" || textBox13.Text == "")
                MessageBox.Show("Заполните все поля!");
            else
            {
                adapter = new MySqlDataAdapter("SELECT id_transport FROM kursproject.transport ORDER BY id_transport DESC LIMIT 1", connection);
                connection.Open();
                DataSet ds1 = new DataSet();
                adapter.Fill(ds1, "transport");
                connection.Close();
                dataGridView7.DataSource = ds1.Tables["transport"];

                command = new MySqlCommand("INSERT INTO kursproject.transport(id_transport, marka, model, gryzopod, gosnumber) " +
                    "VALUES (" + (Convert.ToInt32(dataGridView7.Rows[0].Cells[0].Value) + 1).ToString() + ", '" +
                    textBox10.Text + "', '" + textBox11.Text + "', '" + textBox12.Text +
                    "', '" + textBox13.Text + "')", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                all();
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (id_transport == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            else
            {
                if (textBox10.Text == "" || textBox11.Text == "" || textBox12.Text == "" || textBox13.Text == "")
                    MessageBox.Show("Заполните все поля!");
                else
                {
                    command = new MySqlCommand("UPDATE kursproject.transport SET marka = '" + textBox10.Text +
                        "', model = '" + textBox11.Text + "', gryzopod = '" + textBox12.Text + "', gosnumber = '" +
                        textBox13.Text + "' WHERE id_transport = " + id_transport, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    id_transport = 0;
                    all();
                }
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (id_transport == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            else
            {
                command = new MySqlCommand("DELETE FROM kursproject.transport WHERE id_transport = '" + id_transport + "'", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                id_transport = 0;
                all();
            }
        }

        private void dataGridView7_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_transport = Convert.ToInt32(dataGridView7.CurrentRow.Cells[0].Value);
            textBox10.Text = dataGridView7.CurrentRow.Cells[1].Value.ToString();
            textBox11.Text = dataGridView7.CurrentRow.Cells[2].Value.ToString();
            textBox12.Text = dataGridView7.CurrentRow.Cells[3].Value.ToString();
            textBox13.Text = dataGridView7.CurrentRow.Cells[4].Value.ToString();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            adapter = new MySqlDataAdapter("SELECT id_campony FROM kursproject.campony WHERE nazvanie = '" + comboBox5.Text + "'", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "typetovar");
            connection.Close();
            dataGridView8.DataSource = ds.Tables["typetovar"];
            string temp = dataGridView8.Rows[0].Cells[0].Value.ToString();

            adapter = new MySqlDataAdapter("SELECT id_transport FROM kursproject.transport WHERE gosnumber = '" + comboBox6.Text + "'", connection);
            connection.Open();
            DataSet ds2 = new DataSet();
            adapter.Fill(ds2, "transport");
            connection.Close();
            dataGridView8.DataSource = ds2.Tables["transport"];
            string temp2 = dataGridView8.Rows[0].Cells[0].Value.ToString();

            adapter = new MySqlDataAdapter("SELECT id_tovar FROM kursproject.tovar WHERE nazvanietovara = '" + comboBox7.Text + "'", connection);
            connection.Open();
            DataSet ds3 = new DataSet();
            adapter.Fill(ds3, "tovar");
            connection.Close();
            dataGridView8.DataSource = ds3.Tables["tovar"];
            string temp3 = dataGridView8.Rows[0].Cells[0].Value.ToString();

            adapter = new MySqlDataAdapter("SELECT id_transportirovka FROM kursproject.transportirovka ORDER BY id_transportirovka DESC LIMIT 1", connection);
            connection.Open();
            DataSet ds1 = new DataSet();
            adapter.Fill(ds1, "id_transportirovka");
            connection.Close();
            dataGridView8.DataSource = ds1.Tables["id_transportirovka"];

            command = new MySqlCommand("INSERT INTO kursproject.transportirovka(id_transportirovka, id_campony, id_transport, id_tovar) " +
                "VALUES (" + (Convert.ToInt32(dataGridView8.Rows[0].Cells[0].Value) + 1).ToString() + ", " +
                temp + ", " + temp2 + ", " + temp3 + ")", connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            all();
        }        

        private void dataGridView8_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_transportirovka = Convert.ToInt32(dataGridView8.CurrentRow.Cells[0].Value);
            comboBox5.Text = dataGridView8.CurrentRow.Cells[4].Value.ToString();
            comboBox6.Text = dataGridView8.CurrentRow.Cells[7].Value.ToString();
            comboBox7.Text = dataGridView8.CurrentRow.Cells[8].Value.ToString();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (id_transportirovka == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            else
            {
                adapter = new MySqlDataAdapter("SELECT id_campony FROM kursproject.campony WHERE nazvanie = '" + comboBox5.Text + "'", connection);
                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "typetovar");
                connection.Close();
                dataGridView8.DataSource = ds.Tables["typetovar"];
                string temp = dataGridView8.Rows[0].Cells[0].Value.ToString();

                adapter = new MySqlDataAdapter("SELECT id_transport FROM kursproject.transport WHERE gosnumber = '" + comboBox6.Text + "'", connection);
                connection.Open();
                DataSet ds2 = new DataSet();
                adapter.Fill(ds2, "transport");
                connection.Close();
                dataGridView8.DataSource = ds2.Tables["transport"];
                string temp2 = dataGridView8.Rows[0].Cells[0].Value.ToString();

                adapter = new MySqlDataAdapter("SELECT id_tovar FROM kursproject.tovar WHERE nazvanietovara = '" + comboBox7.Text + "'", connection);
                connection.Open();
                DataSet ds3 = new DataSet();
                adapter.Fill(ds3, "tovar");
                connection.Close();
                dataGridView8.DataSource = ds3.Tables["tovar"];
                string temp3 = dataGridView8.Rows[0].Cells[0].Value.ToString();

                command = new MySqlCommand("UPDATE kursproject.transportirovka SET id_campony = " + temp + ", id_transport = " + temp2 +
                    ", id_tovar = " + temp3 + " WHERE id_transportirovka = " + id_transportirovka, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                id_transportirovka = 0;
                all();
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            if (id_transportirovka == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            else
            {
                command = new MySqlCommand("DELETE FROM kursproject.transportirovka WHERE id_transportirovka = '" + id_transportirovka + "'", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                id_transportirovka = 0;
                all();
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void wordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Word Documents (*.docx)|*.docx";
            sfd.FileName = "export.docx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (tabControl1.SelectedIndex == 0)
                    Export_Data_To_Word(dataGridView1, sfd.FileName);
                else if (tabControl1.SelectedIndex == 1)
                    Export_Data_To_Word(dataGridView2, sfd.FileName);
                else if (tabControl1.SelectedIndex == 2)
                    Export_Data_To_Word(dataGridView3, sfd.FileName);
                else if (tabControl1.SelectedIndex == 3)
                    Export_Data_To_Word(dataGridView4, sfd.FileName);
                else if (tabControl1.SelectedIndex == 4)
                    Export_Data_To_Word(dataGridView5, sfd.FileName);
                else if (tabControl1.SelectedIndex == 5)
                    Export_Data_To_Word(dataGridView6, sfd.FileName);
                else if (tabControl1.SelectedIndex == 6)
                    Export_Data_To_Word(dataGridView7, sfd.FileName);
                else if (tabControl1.SelectedIndex == 7)
                    Export_Data_To_Word(dataGridView8, sfd.FileName);
            }
        }        

        public void Export_Data_To_Word(DataGridView DGV, string filename)
        {

            if (DGV.Rows.Count != 0)
            {
                int RowCount = DGV.Rows.Count;
                int ColumnCount = DGV.Columns.Count;
                Object[,] DataArray = new object[RowCount + 1, ColumnCount + 1];

                int r = 0;
                for (int c = 0; c <= ColumnCount - 1; c++)
                    for (r = 0; r <= RowCount - 1; r++)
                        DataArray[r, c] = DGV.Rows[r].Cells[c].Value;

                Word.Document oDoc = new Word.Document();
                oDoc.Application.Visible = true;

                oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;

                dynamic oRange = oDoc.Content.Application.Selection.Range;
                string oTemp = "";
                for (r = 0; r <= RowCount - 1; r++)
                    for (int c = 0; c <= ColumnCount - 1; c++)
                        oTemp = oTemp + DataArray[r, c] + "\t";

                oRange.Text = oTemp;
                object oMissing = Missing.Value;
                object Separator = Word.WdTableFieldSeparator.wdSeparateByTabs;
                object ApplyBorders = true;
                object AutoFit = true;
                object AutoFitBehavior = Word.WdAutoFitBehavior.wdAutoFitContent;

                oRange.ConvertToTable(ref Separator, ref RowCount, ref ColumnCount,
                                      Type.Missing, Type.Missing, ref ApplyBorders,
                                      Type.Missing, Type.Missing, Type.Missing,
                                      Type.Missing, Type.Missing, Type.Missing,
                                      Type.Missing, ref AutoFit, ref AutoFitBehavior, Type.Missing);
                oRange.Select();

                oDoc.Application.Selection.Tables[1].Select();
                oDoc.Application.Selection.Tables[1].Rows.AllowBreakAcrossPages = 0;
                oDoc.Application.Selection.Tables[1].Rows.Alignment = 0;
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.InsertRowsAbove(1);
                oDoc.Application.Selection.Tables[1].Rows[1].Select();

                oDoc.Application.Selection.Tables[1].Rows[1].Range.Bold = 1;
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Name = "Tahoma";
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 14;

                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    oDoc.Application.Selection.Tables[1].Cell(1, c + 1).Range.Text = DGV.Columns[c].HeaderText;
                }

                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                foreach (Word.Section section in oDoc.Application.ActiveDocument.Sections)
                {
                    Word.Range headerRange = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, Word.WdFieldType.wdFieldPage);
                    headerRange.Text = tabControl1.SelectedTab.Text;
                    headerRange.Font.Size = 16;
                    headerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                }

                oDoc.SaveAs(filename, ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing);
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            adapter = new MySqlDataAdapter("SELECT kolichest, cena FROM kursproject.obl, kursproject.strana, " +
                "kursproject.gorod, kursproject.campony, kursproject.tovar, kursproject.typetovar, kursproject.transport," +
                "kursproject.transportirovka WHERE obl.id_strana = strana.id_strana AND gorod.id_obl = obl.id_obl AND " +
                "campony.id_gorod = gorod.id_gorod AND tovar.id_typetovar = typetovar.id_typetovar AND " +
                "transportirovka.id_campony = campony.id_campony AND transportirovka.id_tovar = tovar.id_tovar AND " +
                "transportirovka.id_transport = transport.id_transport AND id_transportirovka = " + id_transportirovka, connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "transportirovka");
            connection.Close();
            dataGridView8.DataSource = ds.Tables["transportirovka"];
            dataGridView8.Columns[0].Visible = false;
            double temp = Convert.ToDouble(dataGridView8.Rows[0].Cells[0].Value) * 
                Convert.ToDouble(dataGridView8.Rows[0].Cells[1].Value);
            textBox14.Text = temp.ToString();
            id_transportirovka = 0;
            transportirovka();
        }
    }
}