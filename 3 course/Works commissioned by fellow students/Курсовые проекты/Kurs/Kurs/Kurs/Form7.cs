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
using Microsoft.Office.Interop.Word;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office;
using System.Reflection;
using Excel1 = Microsoft.Office.Interop.Excel;

namespace Kurs
{
    public partial class Form7 : Form
    {
        bool Prava;
        public MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=mysql;password=mysql;database=Kursach");
        public MySqlCommand command;
        public MySqlDataAdapter adapter;
        bool sortedJournalTable;

        public int id_zakaz = 0;

        public Form7(bool prava)
        {
            InitializeComponent();
            Zakaz();
            Sotrydniki();
            LoadMtelephone();
            Prava = prava;
        }

        public void Sotrydniki()
        {
            try
            {
                adapter = new MySqlDataAdapter("SELECT * FROM Sotrydniki", connection);
                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Zakaz");
                comboBox2.DataSource = ds.Tables[0];
                comboBox2.ValueMember = "id_sotrydnika";
                comboBox2.DisplayMember = "Familiya";
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LoadMtelephone()
        {
            try
            {
                adapter = new MySqlDataAdapter("SELECT Telephone.id_telephone, Firma.Naimenovanie, Model, Weight, " +
                    "Screen FROM Kursach.Mtelephone, Kursach.Firma, Kursach.Telephone WHERE Kursach.Mtelephone.id_firma1=Kursach.Firma.id_firma" +
                    " AND Telephone.id_modeli = Mtelephone.id_modelitelephone", connection);
                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "tabl_Telephone");
                comboBox1.DataSource = ds.Tables[0];
                comboBox1.ValueMember = "id_telephone";
                comboBox1.DisplayMember = "Model";
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Zakaz()
        {
            try
            {
                adapter = new MySqlDataAdapter("SELECT id_zakaza, Model, Sotrydniki.Familiya, datazakaza, datavozvrata, " +
                    "problema, Zakaz.sale FROM Kursach.Zakaz, Kursach.Sotrydniki, Kursach.Client, Kursach.Telephone, Kursach.Mtelephone WHERE " +
                    "Zakaz.id_telephone = Telephone.id_telephone AND Telephone.id_modeli = Mtelephone.id_modelitelephone AND " +
                    "Telephone.id_client = Client.id AND Zakaz.id_sotrydnika = Sotrydniki.id_sotrydnika", connection);
                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Zakaz");                
                dataGridView1.DataSource = ds.Tables["Zakaz"];
                connection.Close();
                dataGridView1.Columns[0].HeaderText = "ID Модели телефона";
                dataGridView1.Columns[1].HeaderText = "Модель телефона";
                dataGridView1.Columns[2].HeaderText = "Фамилия сотрудника";
                dataGridView1.Columns[3].HeaderText = "Дата заказа";
                dataGridView1.Columns[4].HeaderText = "Дата возврата";
                dataGridView1.Columns[5].HeaderText = "Проблема";
                dataGridView1.Columns[6].HeaderText = "Стоимость";
                dataGridView1.Columns[0].Visible = false;

                adapter = new MySqlDataAdapter("SELECT DISTINCT Sotrydniki.Familiya FROM Kursach.Zakaz, Kursach.Sotrydniki WHERE " +
                    "Zakaz.id_sotrydnika = Sotrydniki.id_sotrydnika", connection);
                connection.Open();
                ds = new DataSet();
                adapter.Fill(ds, "Zakaz");
                comboBox3.DataSource = ds.Tables["Zakaz"];
                comboBox3.ValueMember = "Familiya";
                comboBox3.DisplayMember = "Familiya";
                connection.Close();
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
                if (id_zakaz == 0)
                    MessageBox.Show("Вы ничего не выбрали!");
                else
                {
                    command = new MySqlCommand("DELETE FROM Kursach.Zakaz WHERE id_zakaza = '" + id_zakaz + "'", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    Zakaz();
                    id_zakaz = 0;
                    MessageBox.Show("Запись удалена!", "Сообщение!", MessageBoxButtons.OK);
                }
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
                if (id_zakaz != 0)
                    if (textBox2.Text == "" || textBox1.Text == "")
                        MessageBox.Show("Заполните поля!");
                    else
                    {
                        adapter = new MySqlDataAdapter("SELECT Telephone.id_telephone FROM Kursach.Telephone, Kursach.Mtelephone " +
                        "WHERE Telephone.id_modeli = Mtelephone.id_modelitelephone AND Mtelephone.Model = '" + comboBox1.Text + "'", connection);
                        connection.Open();
                        DataSet ds = new DataSet();
                        adapter.Fill(ds, "Telephone");
                        connection.Close();
                        dataGridView1.DataSource = ds.Tables["Telephone"];
                        string temp = dataGridView1.Rows[0].Cells[0].Value.ToString();

                        adapter = new MySqlDataAdapter("SELECT id_sotrydnika FROM Kursach.Sotrydniki WHERE Familiya = '" + comboBox2.Text + "'", connection);
                        connection.Open();
                        DataSet ds2 = new DataSet();
                        adapter.Fill(ds2, "Sotrydniki");
                        connection.Close();
                        dataGridView1.DataSource = ds2.Tables["Sotrydniki"];
                        string temp2 = dataGridView1.Rows[0].Cells[0].Value.ToString();

                        command = new MySqlCommand("UPDATE Kursach.Zakaz SET id_telephone = " + temp + ", id_sotrydnika = " + temp2 + ", " +
                            "datazakaza = '" + dateTimePicker1.Text + "', datavozvrata = '" + dateTimePicker2.Text + "', problema = '" + 
                            textBox1.Text + "', sale = " + textBox2.Text + " WHERE id_zakaza = " + id_zakaz, connection);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        Zakaz();
                        id_zakaz = 0;
                        MessageBox.Show("Запись изменена!", "Сообщение!", MessageBoxButtons.OK);
                    }
                else
                    MessageBox.Show("Вы ничего не выбрали!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_zakaz = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text == "" || textBox1.Text == "")
                    MessageBox.Show("Заполните все поля!");
                else
                {
                    adapter = new MySqlDataAdapter("SELECT Telephone.id_telephone FROM Kursach.Telephone, Kursach.Mtelephone " +
                        "WHERE Telephone.id_modeli = Mtelephone.id_modelitelephone AND Mtelephone.Model = '" + comboBox1.Text + "'", connection);
                    connection.Open();
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Telephone");
                    connection.Close();
                    dataGridView1.DataSource = ds.Tables["Telephone"];
                    string temp = dataGridView1.Rows[0].Cells[0].Value.ToString();
                    
                    adapter = new MySqlDataAdapter("SELECT id_sotrydnika FROM Kursach.Sotrydniki WHERE Familiya = '" + comboBox2.Text + "'", connection);
                    connection.Open();
                    DataSet ds2 = new DataSet();
                    adapter.Fill(ds2, "Sotrydniki");
                    connection.Close();
                    dataGridView1.DataSource = ds2.Tables["Sotrydniki"];
                    string temp2 = dataGridView1.Rows[0].Cells[0].Value.ToString();

                    adapter = new MySqlDataAdapter("SELECT id_zakaza FROM Kursach.Zakaz ORDER BY id_zakaza DESC LIMIT 1", connection);
                    connection.Open();
                    DataSet ds1 = new DataSet();
                    adapter.Fill(ds1, "Zakaz");
                    connection.Close();
                    dataGridView1.DataSource = ds1.Tables["Zakaz"];

                    command = new MySqlCommand("INSERT INTO Kursach.Zakaz(id_zakaza, id_telephone, id_sotrydnika, datazakaza, datavozvrata, problema, sale) " +
                        "VALUES (" + (Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value) + 1).ToString() + ", " + temp + ", " + temp2 + ", '" +
                        dateTimePicker1.Text + "', '" + dateTimePicker2.Text + "', '" + textBox1.Text + "', " + textBox2.Text + ")", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    Zakaz();
                    MessageBox.Show("Запись добавлена!", "Сообщение!", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            if (Prava)
                groupBox1.Visible = false;
        }


        private void date()
        {
            DateTime dt1 = dateTimePicker1.Value;
            DateTime dt2 = dateTimePicker2.Value;
            int temp  = Convert.ToInt32((dt2 - dt1).TotalDays);
            if (temp < 0)
                label8.Text = "Неверно задана дата";
            else
                label8.Text = temp.ToString();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            date();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            date();
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (sortedJournalTable)
            {
                sortedJournalTable = false;
                DataGridViewColumn newColumn = dataGridView1.Columns[e.ColumnIndex];
                DataGridViewColumn oldColumn = dataGridView1.SortedColumn;
                ListSortDirection direction;

                // If oldColumn is null, then the DataGridView is not sorted.
                if (oldColumn != null)
                {
                    // Sort the same column again, reversing the SortOrder.
                    if (oldColumn == newColumn &&
                        dataGridView1.SortOrder == SortOrder.Ascending)
                    {
                        direction = ListSortDirection.Descending;
                    }
                    else
                    {
                        // Sort a new column and remove the old SortGlyph.
                        direction = ListSortDirection.Ascending;
                        oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                    }
                }
                else
                {
                    direction = ListSortDirection.Ascending;
                }

                // Sort the selected column.
                dataGridView1.Sort(newColumn, direction);
                newColumn.HeaderCell.SortGlyphDirection =
                    direction == ListSortDirection.Ascending ?
                    SortOrder.Ascending : SortOrder.Descending;
            }
            else
            {
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.Programmatic;
                    sortedJournalTable = true;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox3.Text = (Convert.ToInt32(dataGridView1.CurrentRow.Cells[6].Value.ToString()) * 0.72).ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Word Documents (*.docx)|*.docx";

            sfd.FileName = "export.docx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {

                Export_Data_To_Word(dataGridView1, sfd.FileName);
            }
        }

        public void Export_Data_To_Word(DataGridView DGV, string filename)
        {

            if (DGV.Rows.Count != 0)
            {
                int RowCount = DGV.Rows.Count;
                int ColumnCount = DGV.Columns.Count;
                Object[,] DataArray = new object[RowCount + 1, ColumnCount + 1];

                //add rows
                int r = 0;
                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    for (r = 0; r <= RowCount - 1; r++)
                    {
                        DataArray[r, c] = DGV.Rows[r].Cells[c].Value;
                    } //end row loop
                } //end column loop

                Word.Document oDoc = new Word.Document();
                oDoc.Application.Visible = true;

                //page orintation
                oDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;


                dynamic oRange = oDoc.Content.Application.Selection.Range;
                string oTemp = "";
                for (r = 0; r <= RowCount - 1; r++)
                {
                    for (int c = 0; c <= ColumnCount - 1; c++)
                    {
                        oTemp = oTemp + DataArray[r, c] + "\t";

                    }
                }

                //table format
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

                //header row style
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Bold = 1;
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Name = "Tahoma";
                oDoc.Application.Selection.Tables[1].Rows[1].Range.Font.Size = 14;

                //add header row manually
                for (int c = 0; c <= ColumnCount - 1; c++)
                {
                    oDoc.Application.Selection.Tables[1].Cell(1, c + 1).Range.Text = DGV.Columns[c].HeaderText;
                }

                //table style 
                oDoc.Application.Selection.Tables[1].Rows[1].Select();
                oDoc.Application.Selection.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                //header text
                foreach (Word.Section section in oDoc.Application.ActiveDocument.Sections)
                {
                    Word.Range headerRange = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                    headerRange.Fields.Add(headerRange, Word.WdFieldType.wdFieldPage);
                    headerRange.Text = "your header text";
                    headerRange.Font.Size = 16;
                    headerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                }

                //save the file

                oDoc.SaveAs(filename, ref oMissing, ref oMissing, ref oMissing,
    ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
    ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
    ref oMissing, ref oMissing);

                //NASSIM LOUCHANI
            }
        }

        Excel1.Application exApp_New = new Excel1.Application();
        Excel1.Workbook wb_New = null;
        Excel1.Worksheet ws_New = null;

        private void button4_Click(object sender, EventArgs e)
        {
            wb_New = exApp_New.Workbooks.Add(System.Reflection.Missing.Value);
            ws_New = (Microsoft.Office.Interop.Excel.Worksheet)wb_New.Worksheets.get_Item(1);
            ws_New.Cells.Locked = false;

            //Ширина столбцов
            Excel1.Range rangeWidth1 = ws_New.Range["A1", System.Type.Missing];
            rangeWidth1.EntireColumn.ColumnWidth = 14;
            Excel1.Range rangeWidth2 = ws_New.Range["B1", System.Type.Missing];
            rangeWidth2.EntireColumn.ColumnWidth = 15;
            Excel1.Range rangeWidth3 = ws_New.Range["C1", System.Type.Missing];
            rangeWidth3.EntireColumn.ColumnWidth = 18;
            Excel1.Range rangeWidth4 = ws_New.Range["D1", System.Type.Missing];
            rangeWidth4.EntireColumn.ColumnWidth = 15;
            Excel1.Range rangeWidth5 = ws_New.Range["E1", System.Type.Missing];
            rangeWidth5.EntireColumn.ColumnWidth = 15;
            Excel1.Range rangeWidth6 = ws_New.Range["F1", System.Type.Missing];
            rangeWidth6.EntireColumn.ColumnWidth = 30;
            Excel1.Range rangeWidth7 = ws_New.Range["G1", System.Type.Missing];
            rangeWidth7.EntireColumn.ColumnWidth = 12;

            //Шапка таблицы
            Excel1.Range rangeHeader1 = ws_New.get_Range("A5", "G5").Cells;
            rangeHeader1.Font.Name = "Times New Roman";
            rangeHeader1.Font.Size = 10;
            rangeHeader1.HorizontalAlignment = Excel1.XlHAlign.xlHAlignCenter;
            rangeHeader1.VerticalAlignment = Excel1.XlVAlign.xlVAlignCenter;
            rangeHeader1.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            rangeHeader1.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
            ws_New.Cells[5, 1] = "ID Заказа";
            ws_New.Cells[5, 2] = "Модель телефона";
            ws_New.Cells[5, 3] = "Фамилия сотрудника";
            ws_New.Cells[5, 4] = "Дата заказа";
            ws_New.Cells[5, 5] = "Дата возврата";
            ws_New.Cells[5, 6] = "Проблема";
            ws_New.Cells[5, 7] = "Стоимость";

            //Из dataGridView1 в Excel
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    ws_New.Cells[j + 6, i + 1] = (dataGridView1[i, j].Value).ToString();
                    Excel1.Range rangeBord1 = ws_New.Cells[j + 6, i + 1];
                    rangeBord1.Font.Name = "Times New Roman";
                    rangeBord1.Font.Size = 10;
                    rangeBord1.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                    rangeBord1.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                    Excel1.Range rangeBJ = ws_New.Cells[j + 6, i + 2];
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

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                adapter = new MySqlDataAdapter("SELECT id_zakaza, Model, Sotrydniki.Familiya, datazakaza, datavozvrata, " +
                    "problema, Zakaz.sale FROM Kursach.Zakaz, Kursach.Sotrydniki, Kursach.Client, Kursach.Telephone, Kursach.Mtelephone WHERE " +
                    "Zakaz.id_telephone = Telephone.id_telephone AND Telephone.id_modeli = Mtelephone.id_modelitelephone AND " +
                    "Telephone.id_client = Client.id AND Zakaz.id_sotrydnika = Sotrydniki.id_sotrydnika AND Zakaz.problema='" + textBox4.Text + "'", connection);
                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Zakaz");
                dataGridView1.DataSource = ds.Tables["Zakaz"];
                connection.Close();
                dataGridView1.Columns[0].HeaderText = "ID Модели телефона";
                dataGridView1.Columns[1].HeaderText = "Модель телефона";
                dataGridView1.Columns[2].HeaderText = "Фамилия сотрудника";
                dataGridView1.Columns[3].HeaderText = "Дата заказа";
                dataGridView1.Columns[4].HeaderText = "Дата возврата";
                dataGridView1.Columns[5].HeaderText = "Проблема";
                dataGridView1.Columns[6].HeaderText = "Стоимость";
                dataGridView1.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
            adapter = new MySqlDataAdapter("SELECT id_zakaza, Model, Sotrydniki.Familiya, datazakaza, datavozvrata, " +
                    "problema, Zakaz.sale FROM Kursach.Zakaz, Kursach.Sotrydniki, Kursach.Client, Kursach.Telephone, Kursach.Mtelephone WHERE " +
                    "Zakaz.id_telephone = Telephone.id_telephone AND Telephone.id_modeli = Mtelephone.id_modelitelephone AND " +
                    "Telephone.id_client = Client.id AND Zakaz.id_sotrydnika = Sotrydniki.id_sotrydnika AND Sotrydniki.Familiya = '" +
                     comboBox3.Text + "'", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Zakaz");
            dataGridView1.DataSource = ds.Tables["Zakaz"];
            connection.Close();
            dataGridView1.Columns[0].HeaderText = "ID Модели телефона";
            dataGridView1.Columns[1].HeaderText = "Модель телефона";
            dataGridView1.Columns[2].HeaderText = "Фамилия сотрудника";
            dataGridView1.Columns[3].HeaderText = "Дата заказа";
            dataGridView1.Columns[4].HeaderText = "Дата возврата";
            dataGridView1.Columns[5].HeaderText = "Проблема";
            dataGridView1.Columns[6].HeaderText = "Стоимость";
            dataGridView1.Columns[0].Visible = false;
            checkBox1.Checked = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                adapter = new MySqlDataAdapter("SELECT id_zakaza, Model, Sotrydniki.Familiya, datazakaza, datavozvrata, " +
                    "problema, Zakaz.sale FROM Kursach.Zakaz, Kursach.Sotrydniki, Kursach.Client, Kursach.Telephone, Kursach.Mtelephone WHERE " +
                    "Zakaz.id_telephone = Telephone.id_telephone AND Telephone.id_modeli = Mtelephone.id_modelitelephone AND " +
                    "Telephone.id_client = Client.id AND Zakaz.id_sotrydnika = Sotrydniki.id_sotrydnika", connection);
                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Zakaz");
                dataGridView1.DataSource = ds.Tables["Zakaz"];
                connection.Close();
                dataGridView1.Columns[0].HeaderText = "ID Модели телефона";
                dataGridView1.Columns[1].HeaderText = "Модель телефона";
                dataGridView1.Columns[2].HeaderText = "Фамилия сотрудника";
                dataGridView1.Columns[3].HeaderText = "Дата заказа";
                dataGridView1.Columns[4].HeaderText = "Дата возврата";
                dataGridView1.Columns[5].HeaderText = "Проблема";
                dataGridView1.Columns[6].HeaderText = "Стоимость";
                dataGridView1.Columns[0].Visible = false;
            }
        }
    }
}
