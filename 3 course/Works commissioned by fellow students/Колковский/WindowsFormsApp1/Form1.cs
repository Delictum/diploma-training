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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=");
        public MySqlDataAdapter adapter;
        public MySqlCommand command;

        public int id_lico = 0;
        public int id_pravonarushenie = 0;
        public int id_svidetel = 0;
        public int id_proisshestvie = 0;
        public int id_predstavitel = 0;
        public int id_max = 0;

        public Form1()
        {
            InitializeComponent();
            all();
        }

        public void lico()
        {
            adapter = new MySqlDataAdapter("SELECT * FROM PracticaTRPO.lico", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "lico");
            connection.Close();
            dataGridView1.DataSource = ds.Tables["lico"];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Фамилия";
            dataGridView1.Columns[2].HeaderText = "Имя";
            dataGridView1.Columns[3].HeaderText = "Отчество";
            dataGridView1.Columns[4].HeaderText = "Паспорт";
            comboBox1.DataSource = ds.Tables["lico"];
            comboBox1.DisplayMember = "Фамилия";
            comboBox1.ValueMember = "familiy";
            dataGridView1.Columns[0].Visible = false;
        }

        public void pravonarushenie()
        {
            adapter = new MySqlDataAdapter("SELECT * FROM PracticaTRPO.pravonarushenie", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "pravonarushenie");
            connection.Close();
            dataGridView2.DataSource = ds.Tables["pravonarushenie"];
            dataGridView2.Columns[0].HeaderText = "ID";
            dataGridView2.Columns[1].HeaderText = "название";
            comboBox2.DataSource = ds.Tables["pravonarushenie"];
            comboBox2.DisplayMember = "nazvanie";
            comboBox2.ValueMember = "nazvanie";
            dataGridView2.Columns[0].Visible = false;
        }

        public void predstavitel()
        {
            adapter = new MySqlDataAdapter("SELECT * FROM PracticaTRPO.predstavitel", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "predstavitel");
            connection.Close();
            dataGridView3.DataSource = ds.Tables["predstavitel"];
            dataGridView3.Columns[0].HeaderText = "ID";
            dataGridView3.Columns[1].HeaderText = "Фамилия";
            dataGridView3.Columns[2].HeaderText = "Имя";
            dataGridView3.Columns[3].HeaderText = "Отчество";
            dataGridView3.Columns[4].HeaderText = "Должность";
            comboBox3.DataSource = ds.Tables["predstavitel"];
            comboBox3.DisplayMember = "familiy";
            comboBox3.ValueMember = "familiy";
            dataGridView3.Columns[0].Visible = false;
        }

        public void svidetel()
        {
            adapter = new MySqlDataAdapter("SELECT * FROM PracticaTRPO.svidetel", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "svidetel");
            connection.Close();
            dataGridView4.DataSource = ds.Tables["svidetel"];
            dataGridView4.Columns[0].HeaderText = "ID";
            dataGridView4.Columns[1].HeaderText = "Фамилия";
            dataGridView4.Columns[2].HeaderText = "Имя";
            dataGridView4.Columns[3].HeaderText = "Отчество";
            dataGridView4.Columns[4].HeaderText = "Паспорт";
            dataGridView4.Columns[5].HeaderText = "Место";
            comboBox4.DataSource = ds.Tables["svidetel"];
            comboBox4.DisplayMember = "familiy";
            comboBox4.ValueMember = "familiy";
            dataGridView4.Columns[0].Visible = false;
        }

        public void proisshestvie()
        {
            adapter = new MySqlDataAdapter("SELECT proisshestvie.id, predstavitel.familiy, pravonarushenie.nazvanie, " +
                "lico.familiy, svidetel.familiy, data, nomer FROM PracticaTRPO.proisshestvie, PracticaTRPO.predstavitel, " +
                "PracticaTRPO.pravonarushenie, PracticaTRPO.lico, PracticaTRPO.svidetel WHERE " +
                "proisshestvie.id_predstavitel  = predstavitel.id AND proisshestvie.id_pravonarushenie = " +
                "pravonarushenie.id AND proisshestvie.id_lico = lico.id AND proisshestvie.id_svidetel = " +
                "svidetel.id", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "proisshestvie");
            connection.Close();
            dataGridView5.DataSource = ds.Tables["proisshestvie"];
            dataGridView5.Columns[0].HeaderText = "ID";
            dataGridView5.Columns[1].HeaderText = "Фамилия представителя";
            dataGridView5.Columns[2].HeaderText = "Правонарушение";
            dataGridView5.Columns[3].HeaderText = "Фамилия лица";
            dataGridView5.Columns[4].HeaderText = "Фамилия свидетеля";
            dataGridView5.Columns[5].HeaderText = "Дата";
            dataGridView5.Columns[6].HeaderText = "Номер";
            dataGridView5.Columns[0].Visible = false;
        }

        public void all()
        {
            lico();
            pravonarushenie();
            predstavitel();
            svidetel();
            proisshestvie();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox10.Text == "")
                MessageBox.Show("Заполните поля!");
            else
            {
                adapter = new MySqlDataAdapter("SELECT id FROM PracticaTRPO.lico ORDER BY id DESC LIMIT 1", connection);
                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "lico");
                connection.Close();
                dataGridView1.DataSource = ds.Tables["lico"];

                command = new MySqlCommand("INSERT INTO PracticaTRPO.lico(id, familiy, imy, otchestvo, passport) " +
                    "VALUES (" + (Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value) + 1).ToString() + ", '" + 
                    textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox10.Text + "')", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                all();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (id_lico == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            else
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox10.Text == "")
                    MessageBox.Show("Заполните поле!");
                else
                {
                    command = new MySqlCommand("UPDATE PracticaTRPO.lico SET familiy = '" + textBox1.Text +
                        "', imy = '" + textBox2.Text + "', otchestvo = '" + textBox3.Text + "', passport = '" + 
                        textBox10.Text + "' WHERE id = " + id_lico, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    id_lico = 0;
                    all();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (id_lico == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            else
            {
                command = new MySqlCommand("DELETE FROM PracticaTRPO.lico WHERE id = '" + id_lico + "'", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                id_lico = 0;
                all();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
                MessageBox.Show("Заполните все поля!");
            else
            {
                adapter = new MySqlDataAdapter("SELECT id FROM PracticaTRPO.pravonarushenie ORDER BY id DESC LIMIT 1", connection);
                connection.Open();
                DataSet ds1 = new DataSet();
                adapter.Fill(ds1, "pravonarushenie");
                connection.Close();
                dataGridView2.DataSource = ds1.Tables["pravonarushenie"];

                command = new MySqlCommand("INSERT INTO PracticaTRPO.pravonarushenie(id, nazvanie) " +
                    "VALUES (" + (Convert.ToInt32(dataGridView2.Rows[0].Cells[0].Value) + 1).ToString() + ", '" +
                    textBox4.Text + "')", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                all();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (id_predstavitel == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            if (textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "" || textBox5.Text == "")
                MessageBox.Show("Заполните все поля!");
            else
            {
                command = new MySqlCommand("UPDATE PracticaTRPO.predstavitel SET familiy = '" + textBox7.Text +
                        "', imy = '" + textBox8.Text + "', otchestvo = '" + textBox9.Text + "', doljnost = '" +
                        textBox5.Text + "' WHERE id = " + id_predstavitel, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                id_predstavitel = 0;
                all();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (id_predstavitel == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            else
            {
                command = new MySqlCommand("DELETE FROM PracticaTRPO.predstavitel WHERE id = '" + id_predstavitel + "'", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                id_predstavitel = 0;
                all();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (id_pravonarushenie == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            else
            {
                if (textBox4.Text == "")
                    MessageBox.Show("Заполните все поля!");
                else
                {
                    command = new MySqlCommand("UPDATE PracticaTRPO.pravonarushenie SET nazvanie = '" + textBox4.Text +
                        "' WHERE id = " + id_pravonarushenie, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    id_pravonarushenie = 0;
                    all();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (id_pravonarushenie == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            else
            {
                command = new MySqlCommand("DELETE FROM PracticaTRPO.pravonarushenie WHERE id = '" + id_pravonarushenie + "'", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                id_pravonarushenie = 0;
                all();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id_lico = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                textBox10.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            }
            catch (Exception) { }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id_pravonarushenie = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
                textBox4.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            }
            catch (Exception) { }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id_predstavitel = Convert.ToInt32(dataGridView3.CurrentRow.Cells[0].Value);
                textBox7.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
                textBox8.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
                textBox9.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString();
                textBox5.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString();
            }
            catch (Exception) { }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "" || textBox5.Text == "")
                MessageBox.Show("Заполните все поля!");
            else
            {
                adapter = new MySqlDataAdapter("SELECT id FROM PracticaTRPO.predstavitel ORDER BY id DESC LIMIT 1", connection);
                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "predstavitel");
                connection.Close();
                dataGridView3.DataSource = ds.Tables["predstavitel"];

                command = new MySqlCommand("INSERT INTO PracticaTRPO.predstavitel(id, familiy, imy, otchestvo, doljnost) " +
                    "VALUES (" + (Convert.ToInt32(dataGridView3.Rows[0].Cells[0].Value) + 1).ToString() + ", '" +
                    textBox7.Text + "', '" + textBox8.Text + "', '" + textBox9.Text + "', '" + textBox5.Text + "')", connection);
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
            try
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
                else if (tabControl1.SelectedIndex == 3)
                {
                    for (int i = 0; i < dataGridView4.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView4.ColumnCount; j++)
                        {
                            ExcelApp.Cells[i + 1, j + 1] = dataGridView4.Rows[i].Cells[j].Value;
                        }
                    }
                }                
                ExcelApp.Visible = true;
                ExcelApp.UserControl = true;
            }
            catch (Exception) { }
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id_svidetel = Convert.ToInt32(dataGridView4.CurrentRow.Cells[0].Value);
                textBox11.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();
                textBox12.Text = dataGridView4.CurrentRow.Cells[2].Value.ToString();
                textBox13.Text = dataGridView4.CurrentRow.Cells[3].Value.ToString();
                textBox6.Text = dataGridView4.CurrentRow.Cells[4].Value.ToString();
                textBox14.Text = dataGridView4.CurrentRow.Cells[5].Value.ToString();
            }
            catch (Exception) { }
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            adapter = new MySqlDataAdapter("SELECT id FROM strahovanie.client WHERE familiy = '" + comboBox1.Text + "'", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "client");
            connection.Close();
            dataGridView4.DataSource = ds.Tables["client"];
            string temp1 = dataGridView4.Rows[0].Cells[0].Value.ToString();

            adapter = new MySqlDataAdapter("SELECT id FROM strahovanie.agent WHERE familiy = '" + comboBox2.Text + "'", connection);
            connection.Open();
            DataSet ds2 = new DataSet();
            adapter.Fill(ds2, "agent");
            connection.Close();
            dataGridView4.DataSource = ds2.Tables["agent"];
            string temp2 = dataGridView4.Rows[0].Cells[0].Value.ToString();

            adapter = new MySqlDataAdapter("SELECT id FROM strahovanie.strahovka WHERE stoimost = '" + comboBox3.Text + "'", connection);
            connection.Open();
            DataSet ds3 = new DataSet();
            adapter.Fill(ds3, "strahovka");
            connection.Close();
            dataGridView4.DataSource = ds3.Tables["strahovka"];
            string temp3 = dataGridView4.Rows[0].Cells[0].Value.ToString();

            adapter = new MySqlDataAdapter("SELECT id FROM strahovanie.dogovor ORDER BY id DESC LIMIT 1", connection);
            connection.Open();
            DataSet ds1 = new DataSet();
            adapter.Fill(ds1, "dogovor");
            connection.Close();
            dataGridView4.DataSource = ds1.Tables["dogovor"];

            command = new MySqlCommand("INSERT INTO strahovanie.dogovor(id, id_client, id_agent, id_strahovka) " +
                "VALUES (" + (Convert.ToInt32(dataGridView4.Rows[0].Cells[0].Value) + 1).ToString() + ", " +
                temp1 + ", " + temp2 + ", " + temp3 + ")", connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            all();
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

        private void button11_Click_1(object sender, EventArgs e)
        {
            if (id_proisshestvie == 0)
                MessageBox.Show("Вы ничего не выбрали!");            
            else
            {
                adapter = new MySqlDataAdapter("SELECT id FROM strahovanie.client WHERE familiy = '" + comboBox1.Text + "'", connection);
                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "client");
                connection.Close();
                dataGridView4.DataSource = ds.Tables["client"];
                string temp1 = dataGridView4.Rows[0].Cells[0].Value.ToString();

                adapter = new MySqlDataAdapter("SELECT id FROM strahovanie.agent WHERE familiy = '" + comboBox2.Text + "'", connection);
                connection.Open();
                DataSet ds2 = new DataSet();
                adapter.Fill(ds2, "agent");
                connection.Close();
                dataGridView4.DataSource = ds2.Tables["agent"];
                string temp2 = dataGridView4.Rows[0].Cells[0].Value.ToString();

                adapter = new MySqlDataAdapter("SELECT id FROM strahovanie.strahovka WHERE stoimost = '" + comboBox3.Text + "'", connection);
                connection.Open();
                DataSet ds3 = new DataSet();
                adapter.Fill(ds3, "strahovka");
                connection.Close();
                dataGridView4.DataSource = ds3.Tables["strahovka"];
                string temp3 = dataGridView4.Rows[0].Cells[0].Value.ToString();

                command = new MySqlCommand("UPDATE strahovanie.dogovor SET id_client = " + temp1 + ", id_agent = " + temp2 +
                    ", id_strahovka = " + temp3 + " WHERE id = " + id_proisshestvie, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                id_proisshestvie = 0;
                all();
            }            
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            if (id_proisshestvie == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            else
            {
                command = new MySqlCommand("DELETE FROM strahovanie.dogovor WHERE id = '" + id_proisshestvie + "'", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                id_proisshestvie = 0;
                all();
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (textBox11.Text == "" || textBox12.Text == "" || textBox13.Text == "" || textBox6.Text == "" || textBox14.Text == "")
                MessageBox.Show("Заполните все поля!");
            else
            {
                adapter = new MySqlDataAdapter("SELECT id FROM PracticaTRPO.svidetel ORDER BY id DESC LIMIT 1", connection);
                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "svidetel");
                connection.Close();
                dataGridView4.DataSource = ds.Tables["svidetel"];

                command = new MySqlCommand("INSERT INTO PracticaTRPO.svidetel(id, familiy, imy, otchestvo, passport, mesto) " +
                    "VALUES (" + (Convert.ToInt32(dataGridView4.Rows[0].Cells[0].Value) + 1).ToString() + ", '" +
                    textBox11.Text + "', '" + textBox12.Text + "', '" + textBox13.Text + "', '" + textBox6.Text + "', '" + 
                    textBox14.Text + "')", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                all();
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (id_svidetel == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            if (textBox11.Text == "" || textBox12.Text == "" || textBox13.Text == "" || textBox6.Text == "" || textBox14.Text == "")
                MessageBox.Show("Заполните все поля!");
            else
            {
                command = new MySqlCommand("UPDATE PracticaTRPO.svidetel SET familiy = '" + textBox11.Text +
                        "', imy = '" + textBox12.Text + "', otchestvo = '" + textBox13.Text + "', passport = '" +
                        textBox6.Text + "', mesto = '" + textBox14.Text + "' WHERE id = " + id_svidetel, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                id_svidetel = 0;
                all();
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (id_svidetel == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            else
            {
                command = new MySqlCommand("DELETE FROM PracticaTRPO.svidetel WHERE id = '" + id_svidetel + "'", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                id_svidetel = 0;
                all();
            }
        }

        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                id_proisshestvie = Convert.ToInt32(dataGridView5.CurrentRow.Cells[0].Value);
                comboBox1.Text = dataGridView5.CurrentRow.Cells[1].Value.ToString();
                comboBox2.Text = dataGridView5.CurrentRow.Cells[2].Value.ToString();
                comboBox3.Text = dataGridView5.CurrentRow.Cells[3].Value.ToString();
                comboBox4.Text = dataGridView5.CurrentRow.Cells[4].Value.ToString();
                textBox15.Text = dataGridView5.CurrentRow.Cells[5].Value.ToString();
                textBox16.Text = dataGridView5.CurrentRow.Cells[6].Value.ToString();
            }
            catch (Exception) { }
        }

        private void button12_Click_2(object sender, EventArgs e)
        {
            if (textBox15.Text == "" || textBox16.Text == "")
                MessageBox.Show("Заполните все поля!");
            else
            {
                adapter = new MySqlDataAdapter("SELECT id FROM PracticaTRPO.proisshestvie ORDER BY id DESC LIMIT 1", connection);
                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "proisshestvie");
                connection.Close();
                dataGridView5.DataSource = ds.Tables["proisshestvie"];
                string temp = (Convert.ToInt32(dataGridView5.Rows[0].Cells[0].Value) + 1).ToString();

                adapter = new MySqlDataAdapter("SELECT id FROM PracticaTRPO.predstavitel WHERE familiy = '" + comboBox1.Text + "'", connection);
                connection.Open();
                ds = new DataSet();
                adapter.Fill(ds, "predstavitel");
                connection.Close();
                dataGridView5.DataSource = ds.Tables["predstavitel"];
                string temp1 = (dataGridView5.Rows[0].Cells[0].Value).ToString();

                adapter = new MySqlDataAdapter("SELECT id FROM PracticaTRPO.pravonarushenie WHERE nazvanie = '" + comboBox2.Text + "'", connection);
                connection.Open();
                ds = new DataSet();
                adapter.Fill(ds, "pravonarushenie");
                connection.Close();
                dataGridView5.DataSource = ds.Tables["pravonarushenie"];
                string temp2 = (dataGridView5.Rows[0].Cells[0].Value).ToString();

                adapter = new MySqlDataAdapter("SELECT id FROM PracticaTRPO.lico WHERE familiy = '" + comboBox3.Text + "'", connection);
                connection.Open();
                ds = new DataSet();
                adapter.Fill(ds, "lico");
                connection.Close();
                dataGridView5.DataSource = ds.Tables["lico"];
                string temp3 = (dataGridView5.Rows[0].Cells[0].Value).ToString();

                adapter = new MySqlDataAdapter("SELECT id FROM PracticaTRPO.svidetel WHERE familiy = '" + comboBox4.Text + "'", connection);
                connection.Open();
                ds = new DataSet();
                adapter.Fill(ds, "svidetel");
                connection.Close();
                dataGridView5.DataSource = ds.Tables["svidetel"];
                string temp4 = (dataGridView5.Rows[0].Cells[0].Value).ToString();

                command = new MySqlCommand("INSERT INTO PracticaTRPO.proisshestvie(id, id_predstavitel, id_pravonarushenie, " +
                    "id_lico, id_svidetel, data, nomer) VALUES (" + temp + ", '" + temp1 + "', '" + temp2 + "', '" + 
                    temp3 + "', '" + temp4 + "', '" + textBox15.Text + "', '" + textBox16.Text + "')", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                all();
            }
        }

        private void button11_Click_2(object sender, EventArgs e)
        {
            if (id_proisshestvie == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            if (textBox15.Text == "" || textBox16.Text == "")
                MessageBox.Show("Заполните все поля!");
            else
            {
                adapter = new MySqlDataAdapter("SELECT id FROM PracticaTRPO.predstavitel WHERE familiy = '" + comboBox1.Text + "'", connection);
                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "predstavitel");
                connection.Close();
                dataGridView5.DataSource = ds.Tables["predstavitel"];
                string temp1 = (dataGridView5.Rows[0].Cells[0].Value).ToString();

                adapter = new MySqlDataAdapter("SELECT id FROM PracticaTRPO.pravonarushenie WHERE nazvanie = '" + comboBox2.Text + "'", connection);
                connection.Open();
                ds = new DataSet();
                adapter.Fill(ds, "pravonarushenie");
                connection.Close();
                dataGridView5.DataSource = ds.Tables["pravonarushenie"];
                string temp2 = (dataGridView5.Rows[0].Cells[0].Value).ToString();

                adapter = new MySqlDataAdapter("SELECT id FROM PracticaTRPO.lico WHERE familiy = '" + comboBox3.Text + "'", connection);
                connection.Open();
                ds = new DataSet();
                adapter.Fill(ds, "lico");
                connection.Close();
                dataGridView5.DataSource = ds.Tables["lico"];
                string temp3 = (dataGridView5.Rows[0].Cells[0].Value).ToString();

                adapter = new MySqlDataAdapter("SELECT id FROM PracticaTRPO.svidetel WHERE familiy = '" + comboBox4.Text + "'", connection);
                connection.Open();
                ds = new DataSet();
                adapter.Fill(ds, "svidetel");
                connection.Close();
                dataGridView5.DataSource = ds.Tables["svidetel"];
                string temp4 = (dataGridView5.Rows[0].Cells[0].Value).ToString();

                command = new MySqlCommand("UPDATE PracticaTRPO.proisshestvie SET id_predstavitel = '" + temp1 +
                        "', id_pravonarushenie = '" + temp2 + "', id_lico = '" + temp3 + "', id_svidetel = '" +
                        temp4 + "', data = '" + textBox15.Text + "', nomer = '" + textBox16.Text + "' WHERE id = " + id_proisshestvie, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                id_proisshestvie = 0;
                all();
            }
        }

        private void button10_Click_2(object sender, EventArgs e)
        {
            if (id_proisshestvie == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            else
            {
                command = new MySqlCommand("DELETE FROM PracticaTRPO.proisshestvie WHERE id = '" + id_proisshestvie + "'", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                id_proisshestvie = 0;
                all();
            }
        }
    }
}