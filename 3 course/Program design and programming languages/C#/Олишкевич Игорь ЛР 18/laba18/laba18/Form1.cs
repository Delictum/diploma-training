using System;
using System.Xml;
using System.Data;
using System.Xml.Linq;
using System.Windows.Forms;

namespace laba18
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Load1();
        }

        public void Load1()
        {
            XmlReader xmlFile;
            xmlFile = XmlReader.Create("XMLFile1.xml", new XmlReaderSettings());
            DataSet ds = new DataSet();
            ds.ReadXml(xmlFile);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].HeaderText = "Медицинская услуга";
            xmlFile.Close();
        }

        public void add(string str)
        {
            var doc = new XmlDocument();
            doc.Load("XMLFile1.xml");
            XmlNode root = doc.DocumentElement;
            XmlElement elem = doc.CreateElement("Medical");
            elem.InnerText = str;
            root.AppendChild(elem);
            doc.Save("XMLFile1.xml");
            Load1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                add(textBox1.Text);
                

                XmlWriterSettings SettingsXML = new XmlWriterSettings();
                SettingsXML.Indent = true; // Включаем отступ для элементов XML-документа
                SettingsXML.IndentChars = "    "; // Задаём отступ (пробелами)
                SettingsXML.NewLineChars = "\n"; // Задаём переход на новую строку
                // Нужно ли опустить строку декларации формата XML документа
                // Речь идёт о строке вида "<?xml version="1.0" encoding="utf-8"?>"
                SettingsXML.OmitXmlDeclaration = false;

                using (XmlWriter OutputXML = XmlWriter.Create("XMLFile1.xml", SettingsXML))
                {
                    
                    OutputXML.WriteStartElement("MedicalService");
                    //for (int i = 0; i < dataGridView1.ColumnCount; i++)
                        //OutputXML.WriteElementString("Medical", dataGridView1.Columns[i].ToString);

                    
                    OutputXML.WriteEndElement();
                    // Сбрасываем буфферизированные данные
                    OutputXML.Flush();
                    // Закрываем фаил, с которым связан output
                    OutputXML.Close();
                    MessageBox.Show("Документ успешно создан!", "Работа с базами данных (C#) :: XML");

                }
                textBox1.Text = "";
            }
        }
    }
}



