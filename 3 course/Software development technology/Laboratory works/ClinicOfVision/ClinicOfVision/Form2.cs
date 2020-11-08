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

namespace ClinicOfVision
{
    public partial class Form2 : Form
    {
        public MySqlConnection connection = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=");
        public MySqlDataAdapter adapter;
        public MySqlCommand command;
        public int id = 0;

        public void MedicalRecord()
        {
            adapter = new MySqlDataAdapter("SELECT * FROM ClinicOfVision.MedicalRecord", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "MedicalRecord");
            connection.Close();
            dataGridView1.DataSource = ds.Tables["MedicalRecord"];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Серия паспорта";
            dataGridView1.Columns[2].HeaderText = "Номер паспорта";
            dataGridView1.Columns[3].HeaderText = "Адрес";
            dataGridView1.Columns[4].HeaderText = "Диагнозы";
            dataGridView1.Columns[5].HeaderText = "Консультации";
            dataGridView1.Columns[6].HeaderText = "Лечения";
            dataGridView1.Columns[7].HeaderText = "Осмотры";
            dataGridView1.Columns[0].Visible = false;            
        }

        public void Client()
        {
            adapter = new MySqlDataAdapter("SELECT id_client, last_name, first_name, sure_name, passport_series, " +
                "passport_numbers, adress FROM ClinicOfVision.Client, ClinicOfVision.MedicalRecord" +
                " WHERE Client.id_med_record = MedicalRecord.id_med_record", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Client");
            connection.Close();
            dataGridView1.DataSource = ds.Tables["Client"];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Фамилия";
            dataGridView1.Columns[2].HeaderText = "Имя";
            dataGridView1.Columns[3].HeaderText = "Отчество";
            dataGridView1.Columns[4].HeaderText = "Серия паспорта";
            dataGridView1.Columns[5].HeaderText = "Номер паспорта";
            dataGridView1.Columns[6].HeaderText = "Адрес";
            dataGridView1.Columns[0].Visible = false;            
        }

        public void Diagnosis()
        {
            adapter = new MySqlDataAdapter("SELECT Client.last_name, Client.first_name, Client.sure_name, " +
                "Doctor.last_name, Doctor.first_name, Doctor.sure_name, disease, abbreviation, name, date, " +
                " code FROM ClinicOfVision.Client, ClinicOfVision.Doctor, ClinicOfVision.Diagnosis" +
                " WHERE Client.id_client = Diagnosis.id_client AND Doctor.id_doctor = Diagnosis.id_doctor", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Diagnosis");
            connection.Close();
            dataGridView1.DataSource = ds.Tables["Diagnosis"];
            dataGridView1.Columns[0].HeaderText = "Фамилия клиента";
            dataGridView1.Columns[1].HeaderText = "Имя клиента";
            dataGridView1.Columns[2].HeaderText = "Отчество клиента";
            dataGridView1.Columns[3].HeaderText = "Фамилия врача";
            dataGridView1.Columns[4].HeaderText = "Имя врача";
            dataGridView1.Columns[5].HeaderText = "Отчество врача";
            dataGridView1.Columns[6].HeaderText = "Заболевание";
            dataGridView1.Columns[7].HeaderText = "Аббревиатура";
            dataGridView1.Columns[8].HeaderText = "Наименование";
            dataGridView1.Columns[9].HeaderText = "Дата постановления";
            dataGridView1.Columns[10].HeaderText = "Код";
        }

        public void Doctor()
        {
            adapter = new MySqlDataAdapter("SELECT * FROM ClinicOfVision.Doctor", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Doctor");
            connection.Close();
            dataGridView1.DataSource = ds.Tables["Doctor"];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Фамилия";
            dataGridView1.Columns[2].HeaderText = "Имя";
            dataGridView1.Columns[3].HeaderText = "Отчество";
            dataGridView1.Columns[4].HeaderText = "Должность";
            dataGridView1.Columns[5].HeaderText = "Зарплата";
            dataGridView1.Columns[6].HeaderText = "Кабинет";
            dataGridView1.Columns[0].Visible = false;
        }

        public void Treatment()
        {
            adapter = new MySqlDataAdapter("SELECT Client.last_name, Client.first_name, Client.sure_name, " +
                "Doctor.last_name, Doctor.first_name, Doctor.sure_name, disease, abbreviation, code, drugs, " +
                "classification, type, analyzes FROM ClinicOfVision.Treatment, ClinicOfVision.Diagnosis, " +
                "ClinicOfVision.Client, ClinicOfVision.Doctor WHERE Client.id_client = Diagnosis.id_client " +
                "AND Doctor.id_doctor = Diagnosis.id_doctor AND Diagnosis.id_diagnosis = Treatment.id_diagnosis", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Treatment");
            connection.Close();
            dataGridView1.DataSource = ds.Tables["Treatment"];
            dataGridView1.Columns[0].HeaderText = "Фамилия клиента";
            dataGridView1.Columns[1].HeaderText = "Имя клиента";
            dataGridView1.Columns[2].HeaderText = "Отчество клиента";
            dataGridView1.Columns[3].HeaderText = "Фамилия врача";
            dataGridView1.Columns[4].HeaderText = "Имя врача";
            dataGridView1.Columns[5].HeaderText = "Отчество врача";
            dataGridView1.Columns[6].HeaderText = "Заболевание";
            dataGridView1.Columns[7].HeaderText = "Аббревиатура";
            dataGridView1.Columns[8].HeaderText = "Код";
            dataGridView1.Columns[9].HeaderText = "Препараты";
            dataGridView1.Columns[10].HeaderText = "Классификация";
            dataGridView1.Columns[11].HeaderText = "Тип";
            dataGridView1.Columns[12].HeaderText = "Анализы";
        }

        public void Equipment()
        {
            adapter = new MySqlDataAdapter("SELECT disease, classification, Treatment.type, Equipment.name, Equipment.type, " +
                "appointment, count, state FROM ClinicOfVision.Treatment, ClinicOfVision.Diagnosis, ClinicOfVision.Equipment " +
                "WHERE Diagnosis.id_diagnosis = Treatment.id_diagnosis AND Treatment.id_treatment = Equipment.id_treatment", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Equipment");
            connection.Close();
            dataGridView1.DataSource = ds.Tables["Equipment"];
            dataGridView1.Columns[0].HeaderText = "Заболевание";
            dataGridView1.Columns[1].HeaderText = "Классификация лечения";
            dataGridView1.Columns[2].HeaderText = "Тип лечения";
            dataGridView1.Columns[3].HeaderText = "Название оборудования";
            dataGridView1.Columns[4].HeaderText = "Тип оборудования";
            dataGridView1.Columns[5].HeaderText = "Назначение оборудования";
            dataGridView1.Columns[6].HeaderText = "Количество оборудования";
            dataGridView1.Columns[7].HeaderText = "Состояние оборудования";
        }

        public void Cost()
        {
            adapter = new MySqlDataAdapter("SELECT  Client.last_name, Client.first_name, Client.sure_name, " +
                "Doctor.last_name, Doctor.first_name, Doctor.sure_name, classification, Treatment.type, Equipment.name, " +
                "total_cost FROM ClinicOfVision.Treatment, ClinicOfVision.Diagnosis, ClinicOfVision.Client, " +
                "ClinicOfVision.Doctor, ClinicOfVision.Equipment, ClinicOfVision.Cost WHERE Client.id_client = Diagnosis.id_client " +
                "AND Doctor.id_doctor = Diagnosis.id_doctor AND Diagnosis.id_diagnosis = Treatment.id_diagnosis " +
                "AND Treatment.id_treatment = Equipment.id_treatment AND Treatment.id_treatment = Cost.id_treatment", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Cost");
            connection.Close();
            dataGridView1.DataSource = ds.Tables["Cost"];
            dataGridView1.Columns[0].HeaderText = "Фамилия клиента";
            dataGridView1.Columns[1].HeaderText = "Имя клиента";
            dataGridView1.Columns[2].HeaderText = "Отчество клиента";
            dataGridView1.Columns[3].HeaderText = "Фамилия врача";
            dataGridView1.Columns[4].HeaderText = "Имя врача";
            dataGridView1.Columns[5].HeaderText = "Отчество врача";
            dataGridView1.Columns[6].HeaderText = "Классификация лечения";
            dataGridView1.Columns[7].HeaderText = "Тип лечения";
            dataGridView1.Columns[8].HeaderText = "Название оборудования";
            dataGridView1.Columns[9].HeaderText = "Общая стоимость";
        }

        public void Service()
        {
            adapter = new MySqlDataAdapter("SELECT  Client.last_name, Client.first_name, Client.sure_name, " +
                "Doctor.last_name, Doctor.first_name, Doctor.sure_name, Treatment.type, Equipment.name, " +
                "total_cost, cost, description FROM ClinicOfVision.Treatment, ClinicOfVision.Diagnosis, " +
                "ClinicOfVision.Client, ClinicOfVision.Doctor, ClinicOfVision.Equipment, ClinicOfVision.Cost, " +
                "ClinicOfVision.Service WHERE Client.id_client = Diagnosis.id_client AND " +
                "Doctor.id_doctor = Diagnosis.id_doctor AND Diagnosis.id_diagnosis = Treatment.id_diagnosis " +
                "AND Treatment.id_treatment = Equipment.id_treatment AND Treatment.id_treatment = Cost.id_treatment " +
                "AND Cost.id_cost = Service.id_cost", connection);
            connection.Open();
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Service");
            connection.Close();
            dataGridView1.DataSource = ds.Tables["Service"];
            dataGridView1.Columns[0].HeaderText = "Фамилия клиента";
            dataGridView1.Columns[1].HeaderText = "Имя клиента";
            dataGridView1.Columns[2].HeaderText = "Отчество клиента";
            dataGridView1.Columns[3].HeaderText = "Фамилия врача";
            dataGridView1.Columns[4].HeaderText = "Имя врача";
            dataGridView1.Columns[5].HeaderText = "Отчество врача";
            dataGridView1.Columns[6].HeaderText = "Тип лечения";
            dataGridView1.Columns[7].HeaderText = "Название оборудования";
            dataGridView1.Columns[8].HeaderText = "Общая стоимость";
            dataGridView1.Columns[9].HeaderText = "Стоимость услуги";
            dataGridView1.Columns[10].HeaderText = "Описание услуги";
        }

        public Form2(ClinicOfVision.Form1 parent, string caption)
        {
            InitializeComponent();
            this.MdiParent = parent;
            this.Text = caption;

            if (this.Text == "Мед. карта" || this.Text == "Клиент")
                dataGridView1.ContextMenuStrip = contextMenuStrip1;
            else
                dataGridView1.ContextMenuStrip = null;

            switch (this.Text)
            {
                case "Мед. карта":
                    {
                        MedicalRecord();
                        break;
                    }
                case "Клиент":
                    {
                        Client();
                        break;
                    }
                case "Диагноз":
                    {
                        Diagnosis();
                        break;
                    }
                case "Врач":
                    {
                        Doctor();
                        break;
                    }
                case "Лечение":
                    {
                        Treatment();
                        break;
                    }
                case "Оборудование":
                    {
                        Equipment();
                        break;
                    }
                case "Стоимость":
                    {
                        Cost();
                        break;
                    }
                case "Услуга":
                    {
                        Service();
                        break;
                    }
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

        private void wordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Word Documents (*.docx)|*.docx";
            sfd.FileName = "export.docx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (dataGridView1.Rows.Count != 0)
                {
                    int RowCount = dataGridView1.Rows.Count;
                    int ColumnCount = dataGridView1.Columns.Count;
                    Object[,] DataArray = new object[RowCount + 1, ColumnCount + 1];

                    int r = 0;
                    for (int c = 0; c <= ColumnCount - 1; c++)
                        for (r = 0; r <= RowCount - 1; r++)
                            DataArray[r, c] = dataGridView1.Rows[r].Cells[c].Value;

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
                        oDoc.Application.Selection.Tables[1].Cell(1, c + 1).Range.Text = dataGridView1.Columns[c].HeaderText;
                    }

                    oDoc.Application.Selection.Tables[1].Rows[1].Select();
                    oDoc.Application.Selection.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

                    foreach (Word.Section section in oDoc.Application.ActiveDocument.Sections)
                    {
                        Word.Range headerRange = section.Headers[Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range;
                        headerRange.Fields.Add(headerRange, Word.WdFieldType.wdFieldPage);
                        headerRange.Text = this.Text;
                        headerRange.Font.Size = 16;
                        headerRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    }

                    oDoc.SaveAs(this.Text, ref oMissing, ref oMissing, ref oMissing,
                        ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                        ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                        ref oMissing, ref oMissing);
                }
            }
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            }
            catch (Exception)
            {

            }
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3(id);
            f3.Text = "Добавление ";
            if (this.Text == "Мед. карта")
                f3.Text += "мед. карты";                
            else
                f3.Text += "клиента";
            f3.ShowDialog();
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3(id);
            f3.Text = "Редактирование ";
            if (this.Text == "Мед. карта")
                f3.Text += "мед. карты";
            else
                f3.Text += "клиента";
            f3.ShowDialog();
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (this.Text)
            {
                case "Мед. карта":
                    {
                        MedicalRecord();
                        break;
                    }
                case "Клиент":
                    {
                        Client();
                        break;
                    }
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id == 0)
                MessageBox.Show("Вы ничего не выбрали!");
            else
            {
                if (this.Text == "Мед. карта")                
                    command = new MySqlCommand("DELETE FROM ClinicOfVision.MedicalRecord WHERE id_med_record = " + id, connection);
                else
                    command = new MySqlCommand("DELETE FROM ClinicOfVision.Client WHERE id_client = " + id, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
                id = 0;
                MessageBox.Show("Запись удалена!", "Успешно!", MessageBoxButtons.OK);
                обновитьToolStripMenuItem_Click(sender, e);
            }
        }
    }
}
