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
    public partial class Form2 : Form
    {
        public bool Prava;
        public Form2(bool prava)
        {
            InitializeComponent();
            Prava = prava;
        }

        public MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=mysql;password=mysql;database=Kursach");
        public MySqlCommand command;
        public MySqlDataAdapter adapter;

        public int id_Client = 0;
        bool so;

        private void Form2_Load(object sender, EventArgs e)
        {
            tabl_Client();
            if (Prava)
                groupBox1.Visible = false;
        }

        public void tabl_Client()
        {
            try
            {
                connection.Close();
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM `Client`", connection);
                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Client");
                dataGridView1.DataSource = ds.Tables["Client"];
                connection.Close();
                dataGridView1.Columns[0].HeaderText = "ID Клиента";
                dataGridView1.Columns[1].HeaderText = "Фамилия";
                dataGridView1.Columns[2].HeaderText = "Имя";
                dataGridView1.Columns[3].HeaderText = "Отчество";
                dataGridView1.Columns[4].HeaderText = "Адрес";
                dataGridView1.Columns[5].HeaderText = "Телефон";
                dataGridView1.Columns[0].Visible = false;
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
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
                    MessageBox.Show("Заполните поля!");
                else
                {
                    command = new MySqlCommand("INSERT INTO Client (Familiya,Name,Otchestvo,Adress,Telephone) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    connection.Close();
                    tabl_Client();
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
                if (id_Client == 0)
                    MessageBox.Show("Вы ничего не выбрали!");
                else
                {
                    if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
                        MessageBox.Show("Заполните поля!");
                    else
                    {
                        command = new MySqlCommand("UPDATE Client SET Familiya = '" + textBox1.Text + "',Name = '" + textBox2.Text + "',Otchestvo = '" + textBox3.Text + "',Adress = '" + textBox4.Text + "',Telephone = '" + textBox5.Text + "' WHERE id = '" + id_Client + "'", connection);
                        connection.Open();
                        command.ExecuteNonQuery();
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        connection.Close();
                        id_Client = 0;
                        tabl_Client();
                        MessageBox.Show("Запись изменена!", "Сообщение!", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            id_Client = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (id_Client == 0)
                    MessageBox.Show("Вы ничего не выбрали!");
                else
                {
                    command = new MySqlCommand("DELETE FROM Client WHERE id = '" + id_Client + "'", connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    connection.Close();
                    id_Client = 0;
                    tabl_Client();
                    MessageBox.Show("Запись удалена!", "Сообщение!", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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
            rangeWidth1.EntireColumn.ColumnWidth = 11;
            Excel1.Range rangeWidth2 = ws_New.Range["B1", System.Type.Missing];
            rangeWidth2.EntireColumn.ColumnWidth = 12;
            Excel1.Range rangeWidth3 = ws_New.Range["C1", System.Type.Missing];
            rangeWidth3.EntireColumn.ColumnWidth = 12;
            Excel1.Range rangeWidth4 = ws_New.Range["D1", System.Type.Missing];
            rangeWidth4.EntireColumn.ColumnWidth = 14;
            Excel1.Range rangeWidth5 = ws_New.Range["E1", System.Type.Missing];
            rangeWidth5.EntireColumn.ColumnWidth = 23;
            Excel1.Range rangeWidth6 = ws_New.Range["F1", System.Type.Missing];
            rangeWidth6.EntireColumn.ColumnWidth = 14;

            //Шапка таблицы
            Excel1.Range rangeHeader1 = ws_New.get_Range("A5", "F5").Cells;
            rangeHeader1.Font.Name = "Times New Roman";
            rangeHeader1.Font.Size = 10;
            rangeHeader1.HorizontalAlignment = Excel1.XlHAlign.xlHAlignCenter;
            rangeHeader1.VerticalAlignment = Excel1.XlVAlign.xlVAlignCenter;
            rangeHeader1.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            rangeHeader1.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
            ws_New.Cells[5, 1] = "ID Клиента";
            ws_New.Cells[5, 2] = "Фамилия";
            ws_New.Cells[5, 3] = "Имя";
            ws_New.Cells[5, 4] = "Отчество";
            ws_New.Cells[5, 5] = "Адрес";
            ws_New.Cells[5, 6] = "Телефон";

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
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM `Client` WHERE Client.Familiya='" + textBox6.Text + "' ", connection);
                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Client");
                dataGridView1.DataSource = ds.Tables["Client"];
                connection.Close();
                dataGridView1.Columns[0].HeaderText = "ID Клиента";
                dataGridView1.Columns[1].HeaderText = "Фамилия";
                dataGridView1.Columns[2].HeaderText = "Имя";
                dataGridView1.Columns[3].HeaderText = "Отчество";
                dataGridView1.Columns[4].HeaderText = "Адрес";
                dataGridView1.Columns[5].HeaderText = "Телефон";
                dataGridView1.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
