using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office;
using System.Reflection;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tabl_VidiRabot();
            tabl_Sotrydniki();
            tabl_Raboti();
            tabl_VipolnRaboti();
            LoadVidiRabot();
            LoadSotrydniki();
            LoadRaboti();
        }
        public MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=mysql;password=mysql;database=Laba25");
        public MySqlCommand command;
        public MySqlDataAdapter adapter;

        public int id_Sotrydniki = 0;
        public int id_Raboti = 0;
        public int id_VidiRabot = 0;
        public int id_VipolnRaboti = 0;

        public void tabl_Sotrydniki()
        {
            try
            {
                connection.Close();
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM `Sotrydniki`", connection);
                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Sotrydniki");
                dataGridView1.DataSource = ds.Tables["Sotrydniki"];
                connection.Close();
                dataGridView1.Columns[0].HeaderText = "ID Сотрудника";
                dataGridView1.Columns[1].HeaderText = "Фамилия";
                dataGridView1.Columns[2].HeaderText = "Имя";
                dataGridView1.Columns[3].HeaderText = "Отчество";
                dataGridView1.Columns[4].HeaderText = "Оклад";
                dataGridView1.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void tabl_VidiRabot()
        {
            try
            {
                connection.Close();
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM `VidiRabot`", connection);
                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "VidiRabot");
                dataGridView2.DataSource = ds.Tables["VidiRabot"];
                connection.Close();
                dataGridView2.Columns[0].HeaderText = "ID Вида работ";
                dataGridView2.Columns[1].HeaderText = "Описание";
                dataGridView2.Columns[2].HeaderText = "Оплата за день";
                dataGridView2.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void tabl_Raboti()
        {
            try
            {
                connection.Close();
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT Raboti.id, VidiRabot.Opisanie, Datanachala, Dataokonchaniya FROM Laba25.Raboti, Laba25.VidiRabot WHERE Laba25.Raboti.id1=Laba25.VidiRabot.id", connection);
                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Raboti, VidiRabot");
                dataGridView3.DataSource = ds.Tables["Raboti, VidiRabot"];
                connection.Close();
                dataGridView3.Columns[0].HeaderText = "ID Работы";
                dataGridView3.Columns[1].HeaderText = "Описание вида работ";
                dataGridView3.Columns[2].HeaderText = "Дата Начала";
                dataGridView3.Columns[3].HeaderText = "Дата Окончания";
                dataGridView3.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }
        public void tabl_VipolnRaboti()
        {
            try
            {
                connection.Close();
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT VipolnRaboti.id, Sotrydniki.Familiya, Raboti.Dataokonchaniya, dlitelnost FROM Laba25.VipolnRaboti, Laba25.Sotrydniki, Laba25.Raboti WHERE Laba25.VipolnRaboti.id_sotryd=Laba25.Sotrydniki.id AND Laba25.VipolnRaboti.id_raboti=Laba25.Raboti.id", connection);
                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "VipolnRaboti");
                dataGridView4.DataSource = ds.Tables["VipolnRaboti"];
                connection.Close();
                dataGridView4.Columns[0].HeaderText = "ID Выполнение работы";
                dataGridView4.Columns[1].HeaderText = "Описание сотрудника";
                dataGridView4.Columns[2].HeaderText = "Описание работы";
                dataGridView4.Columns[3].HeaderText = "Длительность (дни)";
                dataGridView4.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox5.Text == "" || textBox8.Text == "" || textBox7.Text == "" || textBox3.Text == "")
                    MessageBox.Show("Заполните поля!");
                else
                {
                    command = new MySqlCommand("INSERT INTO Sotrydniki (Familiya,Name,Otchestvo,Oclad) VALUES ('" + textBox5.Text + "','" + textBox8.Text + "','" + textBox7.Text + "','" + textBox3.Text + "')", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    textBox5.Clear();
                    textBox8.Clear();
                    textBox7.Clear();
                    textBox3.Clear();
                    connection.Close();
                    tabl_Sotrydniki();
                    MessageBox.Show("Запись добавлена!", "Отлично!", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (id_Sotrydniki == 0)
                    MessageBox.Show("Вы ничего не выбрали!");
                else
                {
                    if (textBox5.Text == "" || textBox8.Text == "" || textBox7.Text == "" || textBox3.Text == "")
                        MessageBox.Show("Заполните поля!");
                    else
                    {
                        command = new MySqlCommand("UPDATE Sotrydniki SET Familiya = '" + textBox5.Text + "',Name = '" + textBox8.Text + "',Otchestvo = '" + textBox7.Text + "',Oclad = '" + textBox3.Text + "' WHERE id = '" + id_Sotrydniki + "'", connection);
                        connection.Open();
                        command.ExecuteNonQuery();
                        textBox5.Clear();
                        textBox8.Clear();
                        textBox7.Clear();
                        textBox3.Clear();
                        connection.Close();
                        id_Sotrydniki = 0;
                        tabl_Sotrydniki();
                        MessageBox.Show("Запись изменена!", "Отлично!", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (id_Sotrydniki == 0)
                    MessageBox.Show("Вы ничего не выбрали!");
                else
                {
                    command = new MySqlCommand("DELETE FROM Sotrydniki WHERE id = '" + id_Sotrydniki + "'", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    textBox5.Clear();
                    textBox8.Clear();
                    textBox7.Clear();
                    textBox3.Clear();
                    connection.Close();
                    id_Sotrydniki = 0;
                    tabl_Sotrydniki();
                    MessageBox.Show("Запись удалена!", "Отлично!", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            id_Sotrydniki = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            textBox5.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                    MessageBox.Show("Заполните поля!");
                else
                {
                    command = new MySqlCommand("INSERT INTO VidiRabot (Opisanie,Oplatazaden) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "')", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    textBox1.Clear();
                    textBox2.Clear();
                    connection.Close();
                    tabl_VidiRabot();
                    MessageBox.Show("Запись добавлена!", "Отлично!", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (id_VidiRabot == 0)
                    MessageBox.Show("Вы ничего не выбрали!");
                else
                {
                    if (textBox1.Text == "" || textBox2.Text == "")
                        MessageBox.Show("Заполните поля!");
                    else
                    {
                        command = new MySqlCommand("UPDATE VidiRabot SET Opisanie = '" + textBox1.Text + "',Oplatazaden = '" + textBox2.Text + "' WHERE id = '" + id_VidiRabot + "'", connection);
                        connection.Open();
                        command.ExecuteNonQuery();
                        textBox1.Clear();
                        textBox2.Clear();
                        connection.Close();
                        id_VidiRabot = 0;
                        tabl_VidiRabot();
                        MessageBox.Show("Запись изменена!", "Отлично!", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            id_VidiRabot = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
            textBox1.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (id_VidiRabot == 0)
                    MessageBox.Show("Вы ничего не выбрали!");
                else
                {
                    command = new MySqlCommand("DELETE FROM VidiRabot WHERE id = '" + id_VidiRabot + "'", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    textBox1.Clear();
                    textBox2.Clear();
                    connection.Close();
                    id_VidiRabot = 0;
                    tabl_VidiRabot();
                    MessageBox.Show("Запись удалена!", "Отлично!", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "" || maskedTextBox1.Text == "" || maskedTextBox2.Text == "")
                    MessageBox.Show("Заполните все поля!");
                else
                {                    
                    adapter = new MySqlDataAdapter("SELECT id FROM Laba25.VidiRabot WHERE Opisanie  = '" + comboBox1.Text + "'", connection);
                    connection.Open();
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "VidiRabot");
                    connection.Close();
                    dataGridView3.DataSource = ds.Tables["VidiRabot"];
                    int temp = Convert.ToInt32(dataGridView3.Rows[0].Cells[0].Value);

                    command = new MySqlCommand("INSERT INTO Laba25.Raboti(id1, Datanachala, Dataokonchaniya) VALUES (" + 
                        temp + ", '" + maskedTextBox1.Text + "','" + maskedTextBox2.Text + "')", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    maskedTextBox1.Clear();
                    maskedTextBox2.Clear();                    
                    tabl_Raboti();
                    MessageBox.Show("Запись добавлена!", "Отлично!", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LoadVidiRabot()
        {
            try
            {
                adapter = new MySqlDataAdapter("SELECT * FROM VidiRabot", connection);
                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "tabl_VidiRabot");
                comboBox1.DataSource = ds.Tables[0];
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "Opisanie";
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView3_Click(object sender, EventArgs e)
        {
            id_Raboti = Convert.ToInt32(dataGridView3.CurrentRow.Cells[0].Value);
            comboBox1.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            maskedTextBox1.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
            maskedTextBox2.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (id_Raboti == 0)
                    MessageBox.Show("Вы ничего не выбрали!");
                else
                {
                    if (comboBox1.Text == "" || maskedTextBox1.Text == "" || maskedTextBox2.Text == "")
                        MessageBox.Show("Заполните все поля!");
                    else
                    {
                        adapter = new MySqlDataAdapter("SELECT id FROM Laba25.VidiRabot WHERE Opisanie  = '" + comboBox1.Text + "'", connection);
                        connection.Open();
                        DataSet ds = new DataSet();
                        adapter.Fill(ds, "VidiRabot");
                        connection.Close();
                        dataGridView3.DataSource = ds.Tables["VidiRabot"];
                        int temp = Convert.ToInt32(dataGridView3.Rows[0].Cells[0].Value);

                        command = new MySqlCommand("UPDATE Raboti SET id = '" + temp + "',Datanachala = '" + maskedTextBox1.Text + "',Dataokonchaniya = '" + maskedTextBox2.Text + "' WHERE id = '" + id_Raboti + "'", connection);
                        connection.Open();
                        command.ExecuteNonQuery();
                        maskedTextBox1.Clear();
                        maskedTextBox2.Clear();
                        connection.Close();
                        id_Raboti = 0;
                        tabl_Raboti();
                        MessageBox.Show("Запись изменена!", "Отлично!", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (id_Raboti == 0)
                    MessageBox.Show("Вы ничего не выбрали!");
                else
                {
                    command = new MySqlCommand("DELETE FROM Raboti WHERE id = '" + id_Raboti + "'", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    comboBox1.Text = "1";
                    comboBox1.SelectedIndex = 0;
                    maskedTextBox1.Clear();
                    maskedTextBox2.Clear();
                    connection.Close();
                    id_Raboti = 0;
                    tabl_Raboti();
                    MessageBox.Show("Запись удалена!", "Отлично!", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox2.Text == "" || comboBox3.Text == "" || textBox9.Text == "")
                    MessageBox.Show("Заполните все поля!");
                else
                {
                    adapter = new MySqlDataAdapter("SELECT id FROM Laba25.Sotrydniki WHERE Familiya  = '" + comboBox2.Text + "'", connection);
                    connection.Open();
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Sotrydniki");
                    connection.Close();
                    dataGridView4.DataSource = ds.Tables["Sotrydniki"];
                    int temp1 = Convert.ToInt32(dataGridView4.Rows[0].Cells[0].Value);

                    DateTime dt = Convert.ToDateTime(comboBox3.Text);
                    String format = "yyyy/MM/dd";
                    String str = dt.ToString(format);
                    adapter = new MySqlDataAdapter("SELECT id FROM Laba25.Raboti WHERE Dataokonchaniya  = '" + str + "'", connection);
                    connection.Open();
                    DataSet ds1 = new DataSet();
                    adapter.Fill(ds1, "Raboti");
                    connection.Close();
                    dataGridView4.DataSource = ds1.Tables["Raboti"];
                    int temp2 = Convert.ToInt32(dataGridView4.Rows[0].Cells[0].Value);

                    command = new MySqlCommand("INSERT INTO Laba25.VipolnRaboti(id_sotryd, id_raboti, dlitelnost) VALUES (" + temp1 + ", " + temp2 + ", " + textBox9.Text + ")", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    tabl_VipolnRaboti();
                    MessageBox.Show("Запись добавлена!", "Отлично!", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LoadSotrydniki()
        {
            try
            {
                adapter = new MySqlDataAdapter("SELECT * FROM Sotrydniki", connection);
                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "tabl_VipolnRaboti");
                comboBox2.DataSource = ds.Tables[0];
                comboBox2.ValueMember = "id";
                comboBox2.DisplayMember = "Familiya";
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LoadRaboti()
        {
            try
            {
                adapter = new MySqlDataAdapter("SELECT * FROM Raboti", connection);
                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "tabl_VipolnRaboti");
                comboBox3.DataSource = ds.Tables[0];
                comboBox3.ValueMember = "id";
                comboBox3.DisplayMember = "Dataokonchaniya";
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView4_Click(object sender, EventArgs e)
        {
            id_VipolnRaboti = Convert.ToInt32(dataGridView4.CurrentRow.Cells[0].Value);
            comboBox2.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();
            comboBox3.Text = dataGridView4.CurrentRow.Cells[2].Value.ToString();
            textBox9.Text = dataGridView4.CurrentRow.Cells[3].Value.ToString();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                if (id_VipolnRaboti == 0)
                    MessageBox.Show("Вы ничего не выбрали!");
                else
                {
                    if (comboBox2.Text == "" || comboBox3.Text == "" || textBox9.Text == "")
                        MessageBox.Show("Заполните все поля!");
                    else
                    {
                        adapter = new MySqlDataAdapter("SELECT id FROM Laba25.Sotrydniki WHERE Familiya  = '" + comboBox2.Text + "'", connection);
                        connection.Open();
                        DataSet ds = new DataSet();
                        adapter.Fill(ds, "Sotrydniki");
                        connection.Close();
                        dataGridView4.DataSource = ds.Tables["Sotrydniki"];
                        int temp1 = Convert.ToInt32(dataGridView4.Rows[0].Cells[0].Value);

                        DateTime dt = Convert.ToDateTime(comboBox3.Text);
                        String format = "yyyy/MM/dd";
                        String str = dt.ToString(format);
                        adapter = new MySqlDataAdapter("SELECT id FROM Laba25.Raboti WHERE Dataokonchaniya  = '" + str + "'", connection);
                        connection.Open();
                        DataSet ds1 = new DataSet();
                        adapter.Fill(ds1, "Raboti");
                        connection.Close();
                        dataGridView4.DataSource = ds1.Tables["Raboti"];
                        int temp2 = Convert.ToInt32(dataGridView4.Rows[0].Cells[0].Value);

                        command = new MySqlCommand("UPDATE Laba25.VipolnRaboti SET id_sotryd = " + temp1 + ",id_raboti = " + temp2 + ",dlitelnost = '" + textBox9.Text + "' WHERE id = '" + id_VipolnRaboti + "'", connection);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        id_VipolnRaboti = 0;
                        tabl_VipolnRaboti();
                        MessageBox.Show("Запись изменена!", "Отлично!", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                if (id_VipolnRaboti == 0)
                    MessageBox.Show("Вы ничего не выбрали!");
                else
                {
                    command = new MySqlCommand("DELETE FROM Laba25.VipolnRaboti WHERE id = '" + id_VipolnRaboti + "'", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    comboBox2.Text = "1";
                    comboBox2.SelectedIndex = 0;
                    comboBox3.Text = "1";
                    comboBox3.SelectedIndex = 0;
                    connection.Close();
                    id_VipolnRaboti = 0;
                    tabl_VipolnRaboti();
                    MessageBox.Show("Запись удалена!", "Отлично!", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 ab = new AboutBox1();
            ab.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
            if (tabControl1.SelectedIndex == 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        ExcelApp.Cells[i + 1, j + 1] = dataGridView1.Rows[i].Cells[j].Value;
                    }
                }
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView2.ColumnCount; j++)
                    {
                        ExcelApp.Cells[i + 1, j + 1] = dataGridView2.Rows[i].Cells[j].Value;
                    }
                }
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView3.ColumnCount; j++)
                    {
                        ExcelApp.Cells[i + 1, j + 1] = dataGridView3.Rows[i].Cells[j].Value;
                    }
                }
            }
            ExcelApp.Visible = true;
            ExcelApp.UserControl = true;
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

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
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
            }
        }
    }
}

