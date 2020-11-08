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

        public int id_client = 0;
        public int id_agent = 0;
        public int id_dogovor = 0;
        public int id_strahovka = 0;
        public int id_max = 0;

        public Form1()
        {
            InitializeComponent();
            all();
        }

        public void client()
        {
            adapter = new MySqlDataAdapter("SELECT * FROM strahovanie.client", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "client");
            connection.Close();
            dataGridView1.DataSource = ds.Tables["client"];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Фамилия";
            dataGridView1.Columns[2].HeaderText = "Паспорт";
            dataGridView1.Columns[3].HeaderText = "Адрес";
            comboBox1.DataSource = ds.Tables["client"];
            comboBox1.DisplayMember = "Фамилия";
            comboBox1.ValueMember = "familiy";
            dataGridView1.Columns[0].Visible = false;
        }

        public void agent()
        {
            adapter = new MySqlDataAdapter("SELECT * FROM strahovanie.agent", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "agent");
            connection.Close();
            dataGridView2.DataSource = ds.Tables["agent"];
            dataGridView2.Columns[0].HeaderText = "ID";
            dataGridView2.Columns[1].HeaderText = "Фамилия";
            dataGridView2.Columns[2].HeaderText = "Фирма";
            dataGridView2.Columns[3].HeaderText = "Стаж";
            comboBox2.DataSource = ds.Tables["agent"];
            comboBox2.DisplayMember = "familiy";
            comboBox2.ValueMember = "familiy";
            dataGridView2.Columns[0].Visible = false;
        }

        public void strahovka()
        {
            adapter = new MySqlDataAdapter("SELECT * FROM strahovanie.strahovka", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "strahovka");
            connection.Close();
            dataGridView3.DataSource = ds.Tables["strahovka"];
            dataGridView3.Columns[0].HeaderText = "ID";
            dataGridView3.Columns[1].HeaderText = "Название";
            dataGridView3.Columns[2].HeaderText = "Стоимость";
            dataGridView3.Columns[3].HeaderText = "Описание";
            comboBox3.DataSource = ds.Tables["strahovka"];
            comboBox3.DisplayMember = "stoimost";
            comboBox3.ValueMember = "stoimost";
            dataGridView3.Columns[0].Visible = false;
        }

        public void dogovor()
        {
            adapter = new MySqlDataAdapter("SELECT dogovor.id, client.familiy, agent.familiy, stoimost " +
                "FROM strahovanie.dogovor, strahovanie.client, strahovanie.agent, strahovanie.strahovka WHERE " +
                "dogovor.id_client  = client.id AND dogovor.id_agent = agent.id AND dogovor.id_strahovka = strahovka.id", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "dogovor");
            connection.Close();
            dataGridView4.DataSource = ds.Tables["dogovor"];
            dataGridView4.Columns[0].HeaderText = "ID";
            dataGridView4.Columns[1].HeaderText = "Фамилия клиента";
            dataGridView4.Columns[2].HeaderText = "Фамилия агента";
            dataGridView4.Columns[3].HeaderText = "Цена";
            dataGridView4.Columns[0].Visible = false;
        }

        public void all()
        {
            client();
            agent();
            strahovka();
            dogovor();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                MessageBox.Show("Заполните поля!");
            else
            {
                adapter = new MySqlDataAdapter("SELECT id FROM strahovanie.client ORDER BY id DESC LIMIT 1", connection);
                connection.Open();
                DataSet ds = new DataSet();
                adapter.Fill(ds, "client");
                connection.Close();
                dataGridView1.DataSource = ds.Tables["client"];

                command = new MySqlCommand("INSERT INTO strahovanie.client(id, familiy, passport, adress) " +
                    "VALUES (" + (Convert.ToInt32(dataGridView1.Rows[0].Cells[0].Value) + 1).ToString() + ", '" + 
                    textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "')", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                all();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (id_client == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            else
            {
                if (textBox1.Text == "")
                    MessageBox.Show("Заполните поле!");
                else
                {
                    command = new MySqlCommand("UPDATE strahovanie.client SET familiy = '" + textBox1.Text +
                        "', passport = '" + textBox2.Text + "', adress = '" + textBox3.Text + "' WHERE id = " + id_client, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    id_client = 0;
                    all();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (id_client == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            else
            {
                command = new MySqlCommand("DELETE FROM strahovanie.client WHERE id = '" + id_client + "'", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();                
                id_client = 0;
                all();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
                MessageBox.Show("Заполните все поля!");
            else
            {
                adapter = new MySqlDataAdapter("SELECT id FROM strahovanie.agent ORDER BY id DESC LIMIT 1", connection);
                connection.Open();
                DataSet ds1 = new DataSet();
                adapter.Fill(ds1, "obl");
                connection.Close();
                dataGridView2.DataSource = ds1.Tables["obl"];

                command = new MySqlCommand("INSERT INTO strahovanie.agent(id, familiy, firma, stazh) " +
                    "VALUES (" + (Convert.ToInt32(dataGridView2.Rows[0].Cells[0].Value) + 1).ToString() + ", '" +
                    textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "')", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                all();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (id_strahovka == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            if (textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "")
                MessageBox.Show("Заполните все поля!");
            else
            {
                command = new MySqlCommand("UPDATE strahovanie.strahovka SET nazvanie = '" + textBox7.Text + "', stoimost = '" + textBox8.Text +
                    "', opisanie = '" + textBox9.Text + "' WHERE id = " + id_strahovka, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                id_strahovka = 0;
                all();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (id_strahovka == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            else
            {
                command = new MySqlCommand("DELETE FROM strahovanie.strahovka WHERE id = '" + id_strahovka + "'", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                id_strahovka = 0;
                all();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (id_agent == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            else
            {
                if (textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
                    MessageBox.Show("Заполните все поля!");
                else
                {
                    command = new MySqlCommand("UPDATE strahovanie.agent SET familiy = '" + textBox4.Text +
                        "', firma = '" + textBox5.Text + "', stazh = '" + textBox6.Text + "' WHERE id = " + id_agent, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    id_agent = 0;
                    all();
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (id_agent == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            else
            {
                command = new MySqlCommand("DELETE FROM strahovanie.agent WHERE id = '" + id_agent + "'", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                id_agent = 0;
                all();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_client = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_agent = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
            textBox4.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            textBox5.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            textBox6.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_strahovka = Convert.ToInt32(dataGridView3.CurrentRow.Cells[0].Value);
            textBox7.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            textBox8.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
            textBox9.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "")
                MessageBox.Show("Заполните все поля!");
            else
            {
                adapter = new MySqlDataAdapter("SELECT id FROM strahovanie.strahovka ORDER BY id DESC LIMIT 1", connection);
                connection.Open();
                DataSet ds1 = new DataSet();
                adapter.Fill(ds1, "strahovka");
                connection.Close();
                dataGridView3.DataSource = ds1.Tables["strahovka"];

                command = new MySqlCommand("INSERT INTO strahovanie.strahovka(id, nazvanie, stoimost, opisanie) " +
                    "VALUES (" + (Convert.ToInt32(dataGridView3.Rows[0].Cells[0].Value) + 1).ToString() + ", '" +
                    textBox7.Text + "', '" + textBox8.Text + "', '" + textBox9.Text + "')", connection);
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
            id_dogovor = Convert.ToInt32(dataGridView4.CurrentRow.Cells[0].Value);
            comboBox1.Text = dataGridView4.CurrentRow.Cells[1].Value.ToString();
            comboBox2.Text = dataGridView4.CurrentRow.Cells[2].Value.ToString();
            comboBox3.Text = dataGridView4.CurrentRow.Cells[3].Value.ToString();
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
            if (id_dogovor == 0)
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
                    ", id_strahovka = " + temp3 + " WHERE id = " + id_dogovor, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                id_dogovor = 0;
                all();
            }            
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            if (id_dogovor == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            else
            {
                command = new MySqlCommand("DELETE FROM strahovanie.dogovor WHERE id = '" + id_dogovor + "'", connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                id_dogovor = 0;
                all();
            }
        }
    }
}