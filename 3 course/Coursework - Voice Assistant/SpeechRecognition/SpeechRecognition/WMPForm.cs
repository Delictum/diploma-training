using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ParserAndFinderFileTSVLibrary;

namespace SpeechRecognition
{
    public partial class WMPForm : Form
    {
        public WMPForm()
        {
            InitializeComponent();            
        }

        //Добавление аудиофайлов 
        public void AddFilesButton_Click(object sender, EventArgs e)
        {
            //Открытие диалога с фильтрацией музыкальных файлов
            var sourceFileOpenFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Filter = @"(*.mp3; *.wav; *.3gp; *.flv; *.ifo; *.vob;)|*.mp3; *.wav; *.3gp; *.flv; *.ifo; *.vob;",
                RestoreDirectory = true,
                Multiselect = true,
                Title = @"Пожалуйста, " + ElsaForm.username + ", выберите музыкальные файлы.",
            };
            ElsaForm.AddHistoryLog("Эльза", "Пожалуйста, " + ElsaForm.username + ", выберите музыкальные файлы");
            if (sourceFileOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //Загрузка файлов в тип списка и компонент отображения плейлиста
                    foreach (string fileName in sourceFileOpenFileDialog.FileNames)
                    {
                        //Получения полного и короткого наименования файла
                        string shortPath = Path.GetFileName(fileName);
                        shortPath = shortPath.Substring(0, shortPath.Length - 4);

                        //Добавление файлов в тип списка и компонент отображения плейлиста
                        string[] pathElements = new string[2];
                        pathElements[0] = shortPath;
                        pathElements[1] = fileName;
                        ElsaForm.playList.Add(pathElements);
                        PlayListBox.Items.Add(shortPath);

                        ElsaForm.AddHistoryLog("Эльза", "Файл " + shortPath + " выбран");
                    }
                }
                catch (Exception)
                {
                    ElsaForm.AddHistoryLog("Эльза", "Файл не может быть открыт");
                }
            }
        }

		//Сохранение плейлиста
        public void SaveListButton_Click(object sender, EventArgs e)
        {
            //Открытие диалога с фильтрацией плейлистов
            var sourceFileSaveFileDialog = new SaveFileDialog
            {
                InitialDirectory = @"C:\",
                Filter = @"Playlist Files (*.pls)|*.pls",
                RestoreDirectory = true,
                Title = @"Пожалуйста, " + ElsaForm.username + ", выберите имя плейлиста"
            };
            ElsaForm.AddHistoryLog("Эльза", "Пожалуйста, " + ElsaForm.username + ", выберите имя плейлиста");
            if (sourceFileSaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var fs = new FileStream(sourceFileSaveFileDialog.FileName, FileMode.Create, FileAccess.Write))
                    {
                        using (var sw = new StreamWriter(fs, Encoding.GetEncoding(1251)))
                        {
                            //Сохранение плейлиста
                            foreach (var song in ElsaForm.playList)
                            {
                                string outputString = song[1];
                                sw.WriteLine(outputString);
                            }
                            ElsaForm.AddHistoryLog("Эльза", "Плейлист сохранен");
                        }
                    }
                }
                catch (Exception)
                {
                    ElsaForm.AddHistoryLog("Эльза", "Файл не может быть сохранен");
                }
            }
        }

		//Загрузка плейлиста
        public void LoadListButton_Click(object sender, EventArgs e)
        {
            ClearListButton_Click(sender, e);
            //Открытие диалога с фильтрацией музыкальных файлов
            var sourceFileOpenFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Filter = @"Playlist Files (*.pls)|*.pls",
                RestoreDirectory = true,
                Multiselect = false,
                Title = @"Пожалуйста, " + ElsaForm.username + ", выберите плейлист"
            };
            ElsaForm.AddHistoryLog("Эльза", "Пожалуйста, " + ElsaForm.username + ", выберите плейлист");
            if (sourceFileOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //Отображение имени плейлиста
                    string fileName = sourceFileOpenFileDialog.FileName;
                    string temp = sourceFileOpenFileDialog.SafeFileName;
                    playListLabel.Text = temp.Substring(0, temp.Length - 4);

                    using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                    {
                        using (var sr = new StreamReader(fs, Encoding.GetEncoding(1251)))
                        {
                            //Очищение прошлого плейлиста
                            ElsaForm.playList.Clear();
                            PlayListBox.Items.Clear();
                            //Загрузка плейлиста
                            while (!sr.EndOfStream)
                            {
                                string[] pathElements = sr.ReadLine().Split('|');
                                ElsaForm.playList.Add(pathElements);
                                PlayListBox.Items.Add(ParserData.ExeParsed(pathElements[0]));
                            }
                            ElsaForm.AddHistoryLog("Эльза", "Плейлист загружен");
                        }
                    }
                    //Открытие плейлиста
                    ElsaForm.wmp.currentPlaylist = ElsaForm.wmp.newPlaylist("ListWMP", "");
                    foreach (string[] f in ElsaForm.playList)
                        foreach (string fn in f)
                            if (File.Exists(fn))
                                ElsaForm.wmp.currentPlaylist.appendItem(ElsaForm.wmp.newMedia(fn));
                    ElsaForm.AddHistoryLog("Эльза", "Плейлист открыт");

                    ElsaForm.wmp.Ctlcontrols.play(); //Воспроизведение плейлиста
                }
                catch (Exception)
                {
                    ElsaForm.AddHistoryLog("Эльза", "Файл не может быть загружен");
                }
            }
        }

        //Очищение плейлиста
        public void ClearListButton_Click(object sender, EventArgs e)
        {
            ElsaForm.wmp.Ctlcontrols.stop();
            ElsaForm.wmp.currentPlaylist.clear();
            PlayListBox.Items.Clear();
            playListLabel.Text = "Плейлист";
            ElsaForm.AddHistoryLog("Эльза", "Плейлист очищен");
        }

        //Включение музыкального файла из компонента отображения плейлиста при изменении позиции
        public void PlayListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string outputString = ElsaForm.playList[PlayListBox.SelectedIndex][1];
            ElsaForm.wmp.URL = outputString;
            ElsaForm.wmp.Ctlcontrols.play();
            ElsaForm.AddHistoryLog("Эльза", "Трек " + outputString + " включен");
        }

        private void WMPForm_Load(object sender, EventArgs e)
        {
            if (ElsaForm.foreColor == Color.WhiteSmoke)
            {
                AddFilesButton.ForeColor = Color.Black;
                ClearListButton.ForeColor = Color.Black;
                LoadListButton.ForeColor = Color.Black;
                SaveListButton.ForeColor = Color.Black;
            }
            BackColor = ElsaForm.backColor;
            ForeColor = ElsaForm.foreColor;
        }
    }
}
