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
    public partial class Form5 : Form
    {
        bool Prava;
        bool so;
        public Form5(bool prava)
        {
            InitializeComponent();
            Prava = prava;
        }

        public MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=mysql;password=mysql;database=Kursach");
        public MySqlCommand command;
        public MySqlDataAdapter adapter;

        private void Form5_Load(object sender, EventArgs e)
        {
            tabl_Telephone();
            LoadMtelephone();
            LoadClient();
            if (Prava)
                groupBox1.Visible = false;
        }

        public int id_Telephone = 0;

        public void tabl_Telephone()
        {
            try
            {   
                connection.Close();
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT Telephone.id_telephone, Mtelephone.Model, Client.Familiya, Sale FROM Kursach.Telephone, Kursach.Mtelephone, Kursach.Client WHERE Kursach.Telephone.id_modeli=Kursach.Mtelephone.id_modelitelephone AND Kursach.Telephone.id_client=Kursach.Client.id", connection);
                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Telephone");
                dataGridView1.DataSource = ds.Tables["Telephone"];
                connection.Close();
                dataGridView1.Columns[0].HeaderText = "ID Телефона";
                dataGridView1.Columns[1].HeaderText = "Модель телефона";
                dataGridView1.Columns[2].HeaderText = "Фамилия клиента";
                dataGridView1.Columns[3].HeaderText = "Стоимость";
                dataGridView1.Columns[0].Visible = false;
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
                adapter = new MySqlDataAdapter("SELECT * FROM Mtelephone", connection);
                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "tabl_Telephone");
                comboBox1.DataSource = ds.Tables[0];
                comboBox1.ValueMember = "id_modelitelephone";
                comboBox1.DisplayMember = "Model";
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LoadClient()
        {
            try
            {
                adapter = new MySqlDataAdapter("SELECT * FROM Client", connection);
                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "tabl_Telephone");
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text == "" || comboBox2.Text == "" || textBox1.Text == "")
                    MessageBox.Show("Заполните поля!");
                else
                {
                    adapter = new MySqlDataAdapter("SELECT id_modelitelephone FROM Kursach.Mtelephone WHERE Model  = '" + comboBox1.Text + "'", connection);
                    connection.Open();
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "Mtelephone");
                    connection.Close();
                    dataGridView1.DataSource = ds.Tables["Mtelephone"];
                    int temp1 = Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value);

                    adapter = new MySqlDataAdapter("SELECT id FROM Kursach.Client WHERE Familiya  = '" + comboBox2.Text + "'", connection);
                    connection.Open();
                    DataSet ds1 = new DataSet();
                    adapter.Fill(ds, "Client");
                    connection.Close();
                    dataGridView1.DataSource = ds.Tables["Client"];
                    int temp2 = Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value);

                    command = new MySqlCommand("INSERT INTO Kursach.Telephone (id_modeli,id_client,Sale) VALUES (" + temp1 + ", " + temp2 + ", " + textBox1.Text + ")", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    tabl_Telephone();
                    MessageBox.Show("Запись добавлена!", "Сообщение!", MessageBoxButtons.OK);
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
                if (id_Telephone == 0)
                    MessageBox.Show("Вы ничего не выбрали!");
                else
                {
                    if (comboBox1.Text == "" || textBox1.Text == "")
                        MessageBox.Show("Заполните все поля!");
                    else
                    {
                        adapter = new MySqlDataAdapter("SELECT id_modelitelephone FROM Kursach.Mtelephone WHERE Model  = '" + comboBox1.Text + "'", connection);
                        connection.Open();
                        DataSet ds = new DataSet();
                        adapter.Fill(ds, "Mtelephone");
                        connection.Close();
                        dataGridView1.DataSource = ds.Tables["Mtelephone"];
                        int temp1 = Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value);

                        adapter = new MySqlDataAdapter("SELECT id FROM Kursach.Client WHERE Familiya  = '" + comboBox2.Text + "'", connection);
                        connection.Open();
                        DataSet ds1 = new DataSet();
                        adapter.Fill(ds, "Client");
                        connection.Close();
                        dataGridView1.DataSource = ds.Tables["Client"];
                        int temp2 = Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value);


                        command = new MySqlCommand("UPDATE Kursach.Telephone SET id_modeli = " + temp1 + ", id_client = " + temp2 + ", Sale = '" + textBox1.Text + "' WHERE id_telephone = '" + id_Telephone + "'", connection);
                        connection.Open();
                        command.ExecuteNonQuery();
                        connection.Close();
                        id_Telephone = 0;
                        tabl_Telephone();
                        MessageBox.Show("Запись изменена!", "Сообщение!", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView4_Click(object sender, EventArgs e)
        {
            id_Telephone = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (id_Telephone == 0)
                    MessageBox.Show("Вы ничего не выбрали!");
                else
                {
                    command = new MySqlCommand("DELETE FROM Kursach.Telephone WHERE id_telephone = '" + id_Telephone + "'", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    comboBox1.Text = "1";
                    comboBox1.SelectedIndex = 0;
                    comboBox2.Text = "1";
                    comboBox2.SelectedIndex = 0;
                    connection.Close();
                    id_Telephone = 0;
                    tabl_Telephone();
                    MessageBox.Show("Запись удалена!", "Сообщение!", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView4_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (so)
            {
                so = false;
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
                    so = true;
                }
            }
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
            rangeWidth1.EntireColumn.ColumnWidth = 12;
            Excel1.Range rangeWidth2 = ws_New.Range["B1", System.Type.Missing];
            rangeWidth2.EntireColumn.ColumnWidth = 14;
            Excel1.Range rangeWidth3 = ws_New.Range["C1", System.Type.Missing];
            rangeWidth3.EntireColumn.ColumnWidth = 14;
            Excel1.Range rangeWidth4 = ws_New.Range["D1", System.Type.Missing];
            rangeWidth4.EntireColumn.ColumnWidth = 13;

            //Шапка таблицы
            Excel1.Range rangeHeader1 = ws_New.get_Range("A5", "D5").Cells;
            rangeHeader1.Font.Name = "Times New Roman";
            rangeHeader1.Font.Size = 10;
            rangeHeader1.HorizontalAlignment = Excel1.XlHAlign.xlHAlignCenter;
            rangeHeader1.VerticalAlignment = Excel1.XlVAlign.xlVAlignCenter;
            rangeHeader1.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            rangeHeader1.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
            ws_New.Cells[5, 1] = "ID Телефона";
            ws_New.Cells[5, 2] = "Название модели";
            ws_New.Cells[5, 3] = "Фамилия клиента";
            ws_New.Cells[5, 4] = "Стоимость";

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

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Close();
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT Telephone.id_telephone, Mtelephone.Model, Client.Familiya, Sale FROM Kursach.Telephone, Kursach.Mtelephone, Kursach.Client WHERE Kursach.Telephone.id_modeli=Kursach.Mtelephone.id_modelitelephone AND Kursach.Telephone.id_client=Kursach.Client.id AND Mtelephone.Model='" + textBox2.Text + "'", connection);
                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Telephone");
                dataGridView1.DataSource = ds.Tables["Telephone"];
                connection.Close();
                dataGridView1.Columns[0].HeaderText = "ID Телефона";
                dataGridView1.Columns[1].HeaderText = "Модель телефона";
                dataGridView1.Columns[2].HeaderText = "Фамилия клиента";
                dataGridView1.Columns[3].HeaderText = "Стоимость";
                dataGridView1.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
