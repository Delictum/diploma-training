using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Speech.Recognition; //Для работы с голосовым вводом
using Microsoft.Speech.Synthesis;
using System.Globalization;
using System.IO; //Для работы с tsv
using System.Diagnostics; //Для работы открытием программ
using System.Text.RegularExpressions;
using JournalEditableLibrary; //Библиотека для работы с удалением/редактированием
using ParserAndFinderFileTSVLibrary; //Библиотека для работы с tsv
using FastSearchLibrary; //Библиотека поиска файлов

namespace SpeechRecognition
{
    public partial class ElsaForm : Form
    {
        static CultureInfo ci = new CultureInfo("ru-ru"); //Настройка языка
        static SpeechRecognitionEngine sre = new SpeechRecognitionEngine(ci); //Движок распознования речи        

        static int speakWaitingElsaTick = -1; //Отсчет времени и условие для исполнения таймера на восприятие речевых команд
        static int speakCommandElsaTick = 0; //Отсчет времени на восприятие набора слов 
        static string speakCommandElsaPhrase = ""; //Извлечение слов в полноценную команду

        static string pathFileInProject = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location); //Определение директории программы
        static string fileNameTSV = pathFileInProject + "\\doc\\tsv.txt"; //Путь к файлу команд
        static List<List<string>> FileParsedValue = new List<List<string>>(); //Данные файла        
        static int tempCountParsedValueLine = 0; //Количество строк списка данных файла
        static int countParsedValueLine = File.ReadAllLines(pathFileInProject + "\\doc\\tsv.txt", Encoding.GetEncoding(1251)).Length; //Считывание количества команд

        ToolStripMenuItem ElsaMenuIconSettings = new ToolStripMenuItem("Выключить"); //Формат по умолчанию

        Choices fileCommandChoices = new Choices(); //Набор пользователських команд
        Choices actCommandChoices = new Choices(); //Набор команд действий
        GrammarBuilder gb = new GrammarBuilder(); //Грамматический набор команд

        private static object locker = new object(); //Объект поиска директории исполняемого файла

        static private FileSearcherMultiple searcher; //Объект библиотеки поиска файла
        static Label WPBL; //Отображение при поиске директории
        static System.Windows.Forms.Timer PBT = new System.Windows.Forms.Timer(); //Таймер поиска директории
        static ProgressBar SPB; //Прогрузка поиска директории
        static TextBox EPTB; //Текстовое поле для директории исполняющего файла
        static Button SSB; //Кнопка остановки поиска
        static TextBox USTB; //Слова пользователя, воспринятые Эльзой

        static bool SearcherStopButtonIsCanceled = false; //Проверка на отмену поиска директории или естественное завершение

        static Button BLC; //Кнопка переключения между таблицами
        static DataGridView JourTab; //Таблица команд
        static DataGridView HisLog; //Таблица журнала истории
        static public AxWMPLib.AxWindowsMediaPlayer wmp; //Компонент Windows Media Plyer
        static System.Windows.Forms.Timer t = new System.Windows.Forms.Timer(); //Подключение таймера ввода голосовой команды

        static public int selectedLineIndexJouranlTable = -1; //Индекс выбранной строки в таблице
        static public double levelOfPerceptionOfSpeech = 0.3; //Уровень восприятия разпознования речи
        static public string username = "User"; //Имя пользователя
        static public string nameHistoryLog = pathFileInProject + "\\doc\\log\\" + DateTime.Now.ToShortDateString() + ".txt"; //Задание файла журнала истории
        static public List<string[]> playList = new List<string[]>(); //Список музыки
        static WMPForm wmpForm = new WMPForm(); //Форма плейлиста
        private bool WMPstopPause = false; //Условие на проигрывание музыкального файла
        static public Color foreColor = Color.Black; //Цвет шрифта
        static public Color backColor = Color.GhostWhite; //Цвет формы
        public bool sortedHistoryLog = true; //Проверка на возрастающую\убывающую сортировку журнала истории
        public bool sortedJournalTable = true; //Проверка на возрастающую\убывающую сортировку таблицы команд
        static SpeechSynthesizer speechSynth = new SpeechSynthesizer(); //Распознование речи

        public ElsaForm()
        {
            InitializeComponent();

            //Настройка таймера
            t.Interval = 1000;
            t.Tick += new EventHandler(timerSpeakElsa_Tick);
            t.Start();

            //Настройка иконки
            ElsaIcon.Visible = false;
            ElsaIcon.MouseDoubleClick += new MouseEventHandler(ElsaIcon_MouseDoubleClick); //Добавляем событие по двойному клику мышки, вызывая функцию открытия формы            
            Resize += new EventHandler(ElsaForm_Resize); //Добавляем событие на изменение окна            

            //Извлечение содержимого файла в список
            Tuple<List<List<string>>, int> tempTupleData = ParserAndFinderFileTSV.FileParsedReading(fileNameTSV, FileParsedValue, tempCountParsedValueLine);
            FileParsedValue = tempTupleData.Item1;
            tempCountParsedValueLine = tempTupleData.Item2;

            //Создание словаря команд
            string[] GrammarElsa = new string[countParsedValueLine + 2];
            for (int i = 0; i < countParsedValueLine; i++)
                GrammarElsa[i] = String.Join("", FileParsedValue[i][1].ToArray());
            GrammarElsa[GrammarElsa.Length - 1] = "Эльза";
            GrammarElsa[GrammarElsa.Length - 2] = " ";

            sre.SetInputToDefaultAudioDevice(); //Распознования речи с входного устройства по умолчанию
            sre.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized); //Обработчик распознования текста            

            //Подключение словарей            
            fileCommandChoices.Add(GrammarElsa);
            actCommandChoices.Add(new string[] { " ", "открой", "закрой", "включи", "выключи" }); //Словарь действий

            //Построение Microsoft.Speech
            gb.Culture = ci;
            gb.Append(fileCommandChoices);
            gb.Append(actCommandChoices);

            //Подключение Microsoft.Speech
            Grammar g = new Grammar(gb);
            sre.LoadGrammar(g);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                AddHistoryLog("Эльза", "Привет");
                SearcherTypeComboBox.SelectedIndex = 0;
                светлаяToolStripMenuItem_Click(sender, e);
                //Инициализация статических компонентов
                USTB = UserSpeakTextBox;
                wmp = WMP;
                SSB = SearcherStopButton;
                WPBL = WaitProgressBarLabel;
                PBT = ProgressBarTimer;
                SPB = SearchProgressBar;
                EPTB = EditablePerformanceTextBox;
                BLC = buttonListCommand;
                JourTab = JournalTable;
                HisLog = HistoryLog;
                RefreshJournalTableCommand();
                t = timerSpeakElsa;

                JournalTable.RowHeadersWidth = 20;
                checkBoxSpeech.Checked = true;

                string[] HeaderTable = { "Спикер", "Сообщение", "Время" };
                for (int i = 0; i < HeaderTable.Length; i++)
                    HisLog.Columns.Add("Журнал", HeaderTable[i]);
            }
            catch (Exception)
            {
                AddHistoryLog("Эльза", "Программа включена c ошибкой");
            }
        }

        //Переход в трей
        private void ElsaForm_Resize(object sender, EventArgs e)
        {
            try
            {
                if (WindowState == FormWindowState.Minimized) //Проверяем окно, и если оно было свернуто, делаем событие  
                {
                    this.ShowInTaskbar = false; //Прячет окно из панели                
                    ElsaIcon.Visible = true; //Активация иконки в трее
                    this.FormBorderStyle = FormBorderStyle.FixedToolWindow; //Скрытие из деспетчера раздела приложений
                    ShowInTaskbar = false;
                }
            }
            catch (Exception) { }
        }

        //Разворот окна
        private void ElsaIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                ElsaIcon.Visible = false; //Сокрытие иконки
                this.ShowInTaskbar = true; //Отображение окна в панели
                WindowState = FormWindowState.Normal; //Разворачивание окна
                this.FormBorderStyle = FormBorderStyle.FixedSingle; //Отображение в деспетчере раздела приложений
            }
            catch (Exception) { }
        }

        //Функция обработки речи
        static void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            try
            {
                //Если произошло обращение, активация таймера для распознования команд
                if (e.Result.Text == "Эльза")
                {
                    AddHistoryLog("Эльза", "Да?");
                    speakCommandElsaTick = 3;
                    speakWaitingElsaTick = 10;
                    t.Enabled = true;
                    t.Start();
                }
                //Если таймер не активен, отключить распознование
                if (speakWaitingElsaTick == -1)
                    return;
                //Если таймер включен и сходство соответсвует - запоминание команд
                if (e.Result.Confidence > levelOfPerceptionOfSpeech && t.Enabled == true) //степень сходства      
                {
                    if (speakCommandElsaTick != 0 && e.Result.Text != "Эльза")
                    {
                        speakCommandElsaPhrase += e.Result.Text + " ";
                        USTB.Text += e.Result.Text + " ";
                    }
                    speakCommandElsaTick += 2; //Увеличение времени на голосовой ввод                
                }
            }
            catch (Exception) { }
        }

        //Поиск исполняющего файла с возвращением полной директории
        static private void FileSearcherDirectoryName(string exeName)
        {
            try
            {
                MessageBox.Show("Поиск файла начался, ожидайте", "Сообщение", MessageBoxButtons.OK);
                AddHistoryLog("Эльза", "Поиск файла начался, ожидайте");
                SearcherStopButtonIsCanceled = false; //Проверка на отмену поиска директории или естественное завершение
                CancellationTokenSource tokenSource = new CancellationTokenSource();
                //Поиск всех накопительных устройств с добавлением в список
                List<string> folders = new List<string>();
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    if (drive.IsReady) //Если диск доступен
                    {
                        string driveRoot = drive.RootDirectory.FullName;
                        folders.Add(driveRoot); //Добавление устройства
                    }
                }
                searcher = new FileSearcherMultiple(folders, exeName, tokenSource); //Критерии поиска файла
                List<FileInfo> files = new List<FileInfo>(); //Список для найденных файлов (предусмотреть с обновлением)

                //Поиск совпадений файла; при первом найденном - закончить
                searcher.FilesFound += (sender, arg) =>
                {
                    lock (locker)
                    {
                        arg.Files.ForEach((f) =>
                        {
                            files.Add(f);
                            EPTB.Text = f.FullName;
                            SPB.Value = 300;
                        });

                        if (files.Count == 1)
                            searcher.StopSearch();
                    }
                };
                //Результат события
                searcher.SearchCompleted += (sender, arg) =>
                {
                    PBT.Stop();
                    PBT.Enabled = false;
                    if (arg.IsCanceled)
                    {
                        if (SearcherStopButtonIsCanceled)
                            AddHistoryLog("Эльза", "Поиск остановлен");
                        else
                            AddHistoryLog("Эльза", "Файл найден");
                    }
                    else
                        AddHistoryLog("Эльза", "Файл не найден");
                    //Отключение ожидания поиска                
                    WPBL.Visible = false;
                    SPB.Visible = false;
                    SSB.Visible = false;

                };
                searcher.StartSearchAsync(); //Приостановка потоков программов для начала исполнения функции
            }
            catch (Exception) { }
        }

        //Перегрузка поиска исполняющего файла с изменением директории на действующую
        static private void FileSearcherDirectoryName(string exeName, List<List<string>> list, int numLine, string fileName)
        {
            try
            {
                string directory = null; //Переменная для хранения новой директории
                MessageBox.Show("Поиск файла начался, ожидайте", "Сообщение", MessageBoxButtons.OK);
                AddHistoryLog("Эльза", "Поиск файла начался, ожидайте");
                SearcherStopButtonIsCanceled = false; //Проверка на отмену поиска директории или естественное завершение
                CancellationTokenSource tokenSource = new CancellationTokenSource();
                //Поиск всех накопительных устройств с добавлением в список
                List<string> folders = new List<string>();
                foreach (DriveInfo drive in DriveInfo.GetDrives())
                {
                    if (drive.IsReady) //Если диск доступен
                    {
                        string driveRoot = drive.RootDirectory.FullName;
                        folders.Add(driveRoot); //Добавление устройства
                    }
                }
                searcher = new FileSearcherMultiple(folders, exeName, tokenSource); //Критерии поиска файла
                List<FileInfo> files = new List<FileInfo>(); //Список для найденных файлов (предусмотреть с обновлением)

                //Поиск совпадений файла; при первом найденном - закончить
                searcher.FilesFound += (sender, arg) =>
                {
                    lock (locker)
                    {
                        arg.Files.ForEach((f) =>
                        {
                            files.Add(f);
                            directory = f.FullName; //Сохранение новой директории
                            SPB.Value = 300;
                        });

                        if (files.Count == 1)
                            searcher.StopSearch();
                    }
                };
                //Результат события
                searcher.SearchCompleted += (sender, arg) =>
                {
                    PBT.Stop();
                    PBT.Enabled = false;
                    if (arg.IsCanceled)
                    {
                        if (SearcherStopButtonIsCanceled)
                            AddHistoryLog("Эльза", "Поиск остановлен");
                        else
                        {
                            FileReplaceLineDirectory(list, numLine, fileName, directory); //Замена директории
                            AddHistoryLog("Эльза", "Файл найден, директория изменена");
                        }
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Файл не найден. Удалить команду?", "Сообщение", MessageBoxButtons.YesNo);
                        AddHistoryLog("Эльза", "Файл не найден. Удалить команду?");
                        if (dialogResult == DialogResult.Yes)
                        {
                            AddHistoryLog(username, "Да");
                            FileDelCommand(FileParsedValue, tempCountParsedValueLine, numLine, fileName, exeName);
                        }
                        else if (dialogResult == DialogResult.Cancel)
                        {
                            AddHistoryLog(username, "Нет");
                            AddHistoryLog("Эльза", "Команда отменена");
                            WPBL.Visible = false;
                            SPB.Visible = false;
                            SSB.Visible = false;
                        }
                    }
                    //Отключение ожидания поиска                
                    WPBL.Visible = false;
                    SPB.Visible = false;
                    SSB.Visible = false;

                };
                searcher.StartSearchAsync(); //Приостановка потоков программов для начала исполнения функции
            }
            catch (Exception) { }
        }

        //Поиск команды в списке tsv
        static private int SpeechLineFinder(string exeName)
        {
            for (int i = 0; i < tempCountParsedValueLine; i++)
                if (exeName.IndexOf(FileParsedValue[i][1]) > -1)
                    return i;
            return (0);
        }

        //Замена директории
        static private List<List<string>> FileReplaceLineDirectory(List<List<string>> list, int numLine, string fileName, string directory)
        {
            list[numLine][2] = directory; //Изменение директории в списке команд
            string temp = "";
            for (int i = 0; i < 3; i++)
                temp += list[numLine][i] + '\t'; //Сохранение новых данных строки в tsv формат
            string[] strs = File.ReadAllLines(fileName, Encoding.GetEncoding(1251)); //Считывание файла
            strs[numLine] = temp; //Перезапись строки
            //***Буферный файл позволит избежать столкновения считывания и записи одного и того же файла***
            File.WriteAllLines(fileName + ".temp", strs, Encoding.GetEncoding(1251)); //Запись нового файла
            File.Delete(fileName); //Удаление предыдущего файла
            File.Move(fileName + ".temp", fileName); //Переименование в исходный файл
            AddHistoryLog("Эльза", "Директория заменена");
            return list;
        }

        //Открытие файла/сайта
        static private bool OpenFuncSpeechCommandExcution(string howToDoCommand, string whatToDoType)
        {
            try
            {
                string temp;
                if ((File.Exists(howToDoCommand) && whatToDoType == "2") || whatToDoType == "1") //Открытие файла, если он существует по указанной директории, или сайта
                {
                    Process.Start(howToDoCommand);
                    if (whatToDoType == "1")
                    {
                        temp = ParserData.SiteParsed(howToDoCommand);
                        AddHistoryLog("Эльза", temp + " открыт");
                    }
                    else
                    {
                        temp = ParserData.ExeParsed(howToDoCommand);
                        AddHistoryLog("Эльза", temp + " открыт");
                    }
                    return false;
                }
                else //Иначе условие на предложение начать поиск директории
                    return true;
            }
            catch (InvalidOperationException)
            {
                AddHistoryLog("Эльза", "Что-то пошло не так...");
                return false;
            }
        }

        //Исполение/отмена поиска директории
        static private void SettingsFileSearcherDirectory(string exeName, string fileName, int numLine)
        {
            AddHistoryLog("Эльза", "Приложение по заданному пути не найдено, выполнить поиск на компьютере?");
            DialogResult dialogResult = MessageBox.Show("Приложение по заданному пути не найдено, выполнить поиск на компьютере?",
                "Файл не обнаружен", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                AddHistoryLog(username, "Да");
                //Настройка ожидания поиска
                WPBL.Visible = true;
                SPB.Visible = true;
                SSB.Visible = true;
                SPB.Value = 0;
                PBT.Enabled = true;
                PBT.Start();
                FileSearcherDirectoryName(ParserData.ExeParsed(exeName) + ".exe", FileParsedValue, numLine, fileName); //Запуск поиска
            }
            else if (dialogResult == DialogResult.No)
            {
                AddHistoryLog(username, "Нет");
                AddHistoryLog("Эльза", "Команда отменена");
            }
        }

        //Исполнение голосовой команды
        static private void SpeechCommandExcution(string whatToDoCommand)
        {
            whatToDoCommand = string.Join(" ", whatToDoCommand.Split(' ').Distinct()); //Удаление дубликатов из фразы
            if ((whatToDoCommand.IndexOf("открой") > -1 || whatToDoCommand.IndexOf("включи") > -1) &&
                (whatToDoCommand.IndexOf("закрой") > -1 || whatToDoCommand.IndexOf("выключи") > -1))
            {
                AddHistoryLog("Эльза", username + ", определись, что открыть или закрыть");
                return;
            }
            int whatToDoLine = SpeechLineFinder(whatToDoCommand);
            string howToDoCommand = FileParsedValue[whatToDoLine][2];
            string whatToDoType = FileParsedValue[whatToDoLine][0];
            if (whatToDoCommand.IndexOf("открой") > -1 || whatToDoCommand.IndexOf("включи") > -1)
            {
                if (howToDoCommand == null) //Если команда не задана
                {
                    AddHistoryLog("Эльза", "А что открыть?");
                    return;
                }
                if (OpenFuncSpeechCommandExcution(howToDoCommand, whatToDoType))
                {
                    SettingsFileSearcherDirectory(howToDoCommand, fileNameTSV, whatToDoLine);
                }
            }
            else if (whatToDoCommand.IndexOf("закрой") > -1 || whatToDoCommand.IndexOf("выключи") > -1)
            {
                if (howToDoCommand == null) //Если команда не задана
                {
                    AddHistoryLog("Эльза", "А что закрыть?");
                    return;
                }
                Process[] allProcess = Process.GetProcesses(); //Получение списка всех процессов
                try //При найденном закрыть
                {
                    string nameKillProcesses = ParserData.ExeParsed(howToDoCommand);
                    int nameKillProcess = nameKillProcesses.Length - 4;
                    string foo = nameKillProcesses.Remove(nameKillProcess);
                    Process targetProcess = allProcess.First(p => p.ProcessName == foo);
                    targetProcess.Kill();
                }
                catch (InvalidOperationException)
                {

                    string temp = ParserData.ExeParsed(howToDoCommand);
                    AddHistoryLog("Эльза", "Процесс " + temp + " не найден");
                }
            }
            else
            {
                if (howToDoCommand == null) //Если команда не задана
                    return;
                if (OpenFuncSpeechCommandExcution(howToDoCommand, whatToDoType))
                    SettingsFileSearcherDirectory(howToDoCommand, fileNameTSV, whatToDoLine);
            }
            speakCommandElsaPhrase = "";
        }

        //Обновление таблицы журнала команд
        static private void RefreshJournalTableCommand()
        {
            try
            {
                JourTab.Columns.Clear();
                JourTab.ClearSelection();
                if (BLC.Text == "Список команд")
                {
                    HisLog.Visible = false;
                    //Настройка колонок таблицы
                    string[] HeaderTable = { "Тип", "Команда", "Исполнение" };
                    for (int i = 0; i < HeaderTable.Length; i++)
                        JourTab.Columns.Add("Журнал", HeaderTable[i]);
                    JourTab.Columns[0].Width = 80;
                    JourTab.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    JourTab.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    //Построчное заполнение таблицы
                    for (int i = 0; i < tempCountParsedValueLine; i++)
                    {
                        string tempName = null;
                        //Представление чисел в пользовательский вид
                        switch (FileParsedValue[i][0])
                        {
                            case "1":
                                tempName += "Интернет\t";
                                break;
                            case "2":
                                tempName += "Приложение\t";
                                break;
                            case "3":
                                tempName += "Система\t";
                                break;
                        }
                        tempName += FileParsedValue[i][1] + "\t";
                        if (FileParsedValue[i][0] == "2" && Regex.IsMatch(FileParsedValue[i][2], @"^\D:{1}\\{1}")) //Указание исполняющего файла
                            tempName += ParserData.ExeParsed(FileParsedValue[i][2]) + "\t";
                        else if (FileParsedValue[i][0] == "1" && Uri.IsWellFormedUriString(FileParsedValue[i][2], UriKind.RelativeOrAbsolute)) //Указание сайта
                            tempName += ParserData.SiteParsed(FileParsedValue[i][2]) + "\t";
                        else
                            tempName += FileParsedValue[i][2] + "\t";
                        JourTab.Rows.Add(tempName.Split('\t'));
                    }
                    BLC.Text = "Журнал";
                }
                else //Переключение на журнал действий
                {
                    HisLog.Visible = true;
                    HisLog.Columns[0].Width = 100;
                    HisLog.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    HisLog.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    BLC.Text = "Список команд";
                }
            }
            catch (Exception) { }
        }

        //Отображение журнала команд/действий
        private void btnCommand_Click(object sender, EventArgs e)
        {
            RefreshJournalTableCommand();
        }

        //Включение\выключение постоянного прослушивания
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSpeech.Checked == true)
            {
                AddHistoryLog("Эльза", "Микрофон включен");
                onOffMicroIconCMS.Text = "Выключить";
                вклВыклToolStripMenuItem.Text = "Выключить";
                sre.RecognizeAsync(RecognizeMode.Multiple);
            }
            else if (checkBoxSpeech.Checked == false)
            {
                AddHistoryLog("Эльза", "Микрофон выключен");
                onOffMicroIconCMS.Text = "Включить";
                вклВыклToolStripMenuItem.Text = "Включить";
                sre.RecognizeAsyncCancel();
            }
        }

        //Таймер на обработку команд после обращения к программе
        private void timerSpeakElsa_Tick(object sender, EventArgs e)
        {
            try
            {
                //При активации таймера и окончании речевого ввода исполнять команду
                if (speakWaitingElsaTick > 0)
                {
                    speakWaitingElsaTick -= 1;
                    speakCommandElsaTick -= 1;
                    //Если речевой ввод окончен - приступать к исполнению
                    if (speakCommandElsaTick == 0)
                    {
                        if (speakCommandElsaPhrase.Length > 1)
                        {
                            AddHistoryLog(username, speakCommandElsaPhrase);
                            SpeechCommandExcution(speakCommandElsaPhrase);
                            USTB.Text = "";
                        }
                        else
                        {
                            speakCommandElsaPhrase = "";
                            AddHistoryLog("Эльза", "Не услышала");
                            USTB.Text = "";
                            t.Enabled = false;
                        }
                    }
                }
                else //При естественном окончании отсчета отключать таймер
                {
                    USTB.Text = "";
                    speakWaitingElsaTick = -1;
                    t.Stop();
                    t.Enabled = false;
                }
            }
            catch (Exception) { }
        }

        //Отображение/сокрытие компонентов для возможности редактирования
        private void EditableButton_Click(object sender, EventArgs e)
        {
            if (EditableButton.Text == "...")
            {
                if (buttonListCommand.Text == "Список команд")
                    btnCommand_Click(sender, e);
                EditableButton.Text = "Скрыть";
                EditableCommandTextBox.Text = null;
                EditablePerformanceTextBox.Text = null;
                EditableGroupBox.Visible = true;
                EditableAddButton.Visible = true;
                EditableDelButton.Visible = true;
                EditableEditButton.Visible = true;
                JournalTable.ClearSelection();
            }
            else
            {
                EditableButton.Text = "...";
                EditableGroupBox.Visible = false;
                EditableAddButton.Visible = false;
                EditableDelButton.Visible = false;
                EditableEditButton.Visible = false;
                EditableTypeComboBox.SelectedIndex = -1;
            }
        }

        //Добавление новой команды в файл и программу
        private void EditableAddButton_Click(object sender, EventArgs e)
        {
            if (EditableTypeComboBox.SelectedIndex != -1 && EditableCommandTextBox.Text != null && EditablePerformanceTextBox.Text != null)
            {
                //Запрос на подтверждение добавления
                DialogResult dialogResult = MessageBox.Show("Вы действительно хотите добавить команду " + EditableCommandTextBox.Text + "?",
                "Добавить?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                AddHistoryLog("Эльза", "Вы действительно хотите добавить команду " + EditableCommandTextBox.Text + "?");
                if (dialogResult == DialogResult.Cancel)
                {
                    AddHistoryLog(username, "Нет");
                    return;
                }
                else if (dialogResult == DialogResult.Yes)
                {
                    AddHistoryLog(username, "Да");
                    if (EditableTypeComboBox.Text == "Приложение")
                    {
                        //Проверка на указание пути исполняющего файла
                        if (Regex.IsMatch(EditablePerformanceTextBox.Text, @"^\w{1}:{1}\\{1}") == false)
                        {
                            AddHistoryLog("Эльза", "Неверно задан путь к файлу");
                            return;
                        }
                    }
                    else if (EditableTypeComboBox.Text == "Интернет")
                    {
                        //Проверка на указание пути исполняющего файла
                        if (Regex.IsMatch(EditablePerformanceTextBox.Text, @"^\w+.+([.][a-z]+)$") == false)
                        {
                            AddHistoryLog("Эльза", "Неверно задан URL");
                            return;
                        }
                    }
                    //Добавление в список данных новой команды
                    Tuple<List<List<string>>, int> bufTupleData = JournalEditable.FileParsedWritingList(fileNameTSV, Convert.ToString(EditableTypeComboBox.SelectedIndex + 1),
                        EditableCommandTextBox.Text, EditablePerformanceTextBox.Text, FileParsedValue, tempCountParsedValueLine);
                    FileParsedValue = bufTupleData.Item1;
                    tempCountParsedValueLine = bufTupleData.Item2;

                    //Обновление словаря
                    actCommandChoices.Add(new string[] { " ", "открой", "закрой", "включи", "выключи" }); //Словарь действий
                    fileCommandChoices.Add(EditableCommandTextBox.Text);
                    gb.Append(EditableCommandTextBox.Text);
                    gb.Append(actCommandChoices);
                    Grammar g = new Grammar(gb);
                    sre.LoadGrammar(g);
                    //Обновление таблицы                    
                    buttonListCommand.Text = "Список команд";
                    btnCommand_Click(sender, e);
                    AddHistoryLog("Эльза", "Добавление успешно выполненно");
                }
            }
            else
                AddHistoryLog("Эльза", "Не вышло");
        }

        //При выборе типа "программа" отобразить кнопку пути расположения и поиска директории.
        //Отобразить текст для необходимого заполнения типа команды
        private void EditableComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            EditableWayLabel.Visible = true;
            if (EditableTypeComboBox.SelectedIndex == 1)
            {
                EditableWayLabel.Text = "Путь / название.exe файла";
                WayButton.Visible = true;
                SearchWayButton.Visible = true;
            }
            else if (EditableTypeComboBox.SelectedIndex == 0)
            {
                EditableWayLabel.Text = "URL сайта";
                WayButton.Visible = false;
                SearchWayButton.Visible = false;
            }
            else if (EditableTypeComboBox.SelectedIndex == 2)
            {
                EditableWayLabel.Text = "Системная команда";
                WayButton.Visible = false;
                SearchWayButton.Visible = false;
            }
        }

        //Выбор исполняемого файла пользователем
        private void WayButton_Click(object sender, EventArgs e)
        {
            WayOpenFileDialog.Filter = "Файлы Exe (*.exe) | *.exe"; //Только формат .exe
            WayOpenFileDialog.ShowDialog();
            EditablePerformanceTextBox.Text = WayOpenFileDialog.FileName;
        }

        //Таймер прогресса ожидания поиска
        private void ProgressBarTimer_Tick(object sender, EventArgs e)
        {
            if (SPB.Value >= 299)
                SPB.Value = 0;
            SearchProgressBar.Value += 1;
            SearchProgressBar.Refresh();
            if (SearchProgressBar.Value == 299)
                SearchProgressBar.Value = 0;
        }

        //Поиск директории исполняющего файла
        private void SearchWayButton_Click(object sender, EventArgs e)
        {
            if (Regex.IsMatch(EditablePerformanceTextBox.Text, @"^\D:{1}\\{1}") == false)
            {
                //Настройка ожидания поиска
                SearcherStopButton.Visible = true;
                WaitProgressBarLabel.Visible = true;
                SearchProgressBar.Visible = true;
                SearchProgressBar.Value = 0;
                ProgressBarTimer.Enabled = true;
                ProgressBarTimer.Start();

                AddHistoryLog("Эльза", "Поиск исполняющего файла запущен");

                //Проверка на указание формата .exe в названии
                if (Regex.IsMatch(EditablePerformanceTextBox.Text, @".exe$") == false)
                    FileSearcherDirectoryName(EditablePerformanceTextBox.Text + ".exe");
                else
                    FileSearcherDirectoryName(EditablePerformanceTextBox.Text);
            }
        }

        //Остановка поиска исполняющего файла
        private void SearcherStopButton_Click(object sender, EventArgs e)
        {
            SearcherStopButtonIsCanceled = true;
            searcher.StopSearch();
            AddHistoryLog("Эльза", "Поиск исполняющего файла остановлен");
        }

        //Удаление команды из журнала и файла
        private void EditableDelButton_Click(object sender, EventArgs e)
        {
            string valueLine = Convert.ToString(JournalTable.CurrentRow.Cells[2].Value); //Значение ячейки команды
            //Если ничего не выбрано
            if (selectedLineIndexJouranlTable == -1)
            {
                AddHistoryLog("Эльза", "Вы ничего не выбрали!");
                return;
            }
            //Запрос на подтверждение удаления
            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить команду " + JournalTable.CurrentRow.Cells[2].Value + "?",
                "Удалить?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            AddHistoryLog("Эльза", "Вы действительно хотите удалить команду " + JournalTable.CurrentRow.Cells[2].Value + "?");
            if (dialogResult == DialogResult.Cancel) //Нет - конец действий
            {
                AddHistoryLog(username, "Нет");
                return;
            }
            else if (dialogResult == DialogResult.Yes) //Да - удаляем
            {
                AddHistoryLog(username, "Да");
                FileDelCommand(FileParsedValue, tempCountParsedValueLine, selectedLineIndexJouranlTable, fileNameTSV, valueLine);
            }
        }

        //Добавление в журнал команд
        static public void AddHistoryLog(string str1, string str2)
        {
            try
            {
                if (str1 == "Эльза")
                {
                    speechSynth.SetOutputToDefaultAudioDevice(); //Установка голосовой речи по умолчанию (Elena)
                    speechSynth.Volume = 100; // устанавливаем уровень звука
                    speechSynth.SpeakAsync(str2); // озвучиваем переданный текст
                }
                string str3;
                str3 = DateTime.Now.ToLongTimeString();
                HistoryLogEditable.FileWritingHistoryLog(nameHistoryLog, str1, str2, str3);
                HisLog.Rows.Add(str1, str2, str3);
            }
            catch (Exception) { }
        }

        //Считывание команды из журнала при изменении строки
        private void JournalTable_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                selectedLineIndexJouranlTable = Convert.ToInt32(JournalTable.CurrentRow.Index);
            }
            catch (Exception)
            {
                selectedLineIndexJouranlTable = -1;
            }
        }

		//Редактирование команды
        private void EditableEditButton_Click(object sender, EventArgs e)
        {
            if (EditableTypeComboBox.SelectedIndex != -1 && EditableCommandTextBox.Text != null && EditablePerformanceTextBox.Text != null)
            {
                //Запрос на подтверждение редактирования
                DialogResult dialogResult = MessageBox.Show("Вы действительно хотите изменить команду " + JournalTable.CurrentRow.Cells[2].Value + "?",
                "Изменить?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                AddHistoryLog("Эльза", "Вы действительно хотите изменить команду " + JournalTable.CurrentRow.Cells[2].Value + "?");
                if (dialogResult == DialogResult.Cancel)
                {
                    AddHistoryLog(username, "Нет");
                    return;
                }
                else if (dialogResult == DialogResult.Yes)
                {
                    AddHistoryLog(username, "Да");
                    if (EditableTypeComboBox.Text == "Приложение")
                    {
                        //Проверка на указание пути исполняющего файла
                        if (Regex.IsMatch(EditablePerformanceTextBox.Text, @"^\w{1}:{1}\\{1}") == false)
                        {
                            AddHistoryLog("Эльза", "Неверно задан путь к файлу");
                            return;
                        }
                    }
                    else if (EditableTypeComboBox.Text == "Интернет")
                    {
                        //Проверка на указание пути исполняющего файла
                        if (Regex.IsMatch(EditablePerformanceTextBox.Text, @"^\w+.+([.][a-z]+)$") == false)
                        {
                            AddHistoryLog("Эльза", "Неверно задан URL");
                            return;
                        }
                    }

                    string[] valueLine = new string[3];
                    valueLine[0] = Convert.ToString(EditableTypeComboBox.SelectedIndex + 1);
                    valueLine[1] = EditableCommandTextBox.Text;
                    if (EditableTypeComboBox.Text == "Интернет")
                        valueLine[2] = "https://" + EditablePerformanceTextBox.Text;
                    else if (EditableTypeComboBox.Text == "Приложение")
                        valueLine[2] = EditablePerformanceTextBox.Text;
                    JournalEditable.FileReplaceLineTSV(FileParsedValue, countParsedValueLine, selectedLineIndexJouranlTable, fileNameTSV, valueLine);                    
                    //Обновление таблицы
                    buttonListCommand.Text = "Список команд";
                    btnCommand_Click(sender, e);
                    AddHistoryLog("Эльза", "Изменение успешно выполненно");
                }
            }
            else
                AddHistoryLog("Эльза", "Не вышло");
        }

        //Удаление команды из файла
        static private void FileDelCommand(List<List<string>> list, int tempCountList, int numLine, string fileName, string value)
        {
            JournalEditable.FileDelLineTSV(list, tempCountList, numLine, fileName, value); //Вызов функции библиотеки
            //Извлечение содержимого файла в список
            Tuple<List<List<string>>, int> tempTupleData = JournalEditable.FileDelLineTSV(FileParsedValue, tempCountParsedValueLine, selectedLineIndexJouranlTable, fileNameTSV, value);
            FileParsedValue = tempTupleData.Item1;
            tempCountParsedValueLine = tempTupleData.Item2;
            tempCountParsedValueLine--;

            BLC.Text = "Список команд";
            RefreshJournalTableCommand();
            AddHistoryLog("Эльза", "Удаление успешно выполненно");
        }

        //Открытие формы информации о программе из меню
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutProgram aboutProgram = new AboutProgram("\"Голосовой ассистент\"", "Голосовой ассистент - Эльза", "Олишкевич И.Р.", BackColor, ForeColor);
            aboutProgram.ShowDialog();
        }

        //Настройка уровня восприятия речи из меню с вызовом формы ползунка
        private void уровеньВосприятияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LevelPerceptionForm levelPerceptionForm = new LevelPerceptionForm(BackColor, ForeColor);
            levelPerceptionForm.ShowDialog();
        }

        //Включение/выключение микрофона из меню
        private void вклВыклToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (вклВыклToolStripMenuItem.Text == "Включить")
                checkBoxSpeech.Checked = true;
            else
                checkBoxSpeech.Checked = false;
        }

        //Выход из приложения
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ElsaIcon.Visible = false;
            Application.Exit();
        }

        //Разворачивание окна из трея
        private void openIconCMS_Click(object sender, EventArgs e)
        {
            try
            {
                ElsaIcon.Visible = false; //Сокрытие иконки
                this.ShowInTaskbar = true; //Отображение окна в панели
                WindowState = FormWindowState.Normal; //Разворачивание окна
                this.FormBorderStyle = FormBorderStyle.FixedSingle; //Отображение в деспетчере раздела приложений
            }
            catch (Exception) { }
        }

        //Открытие формы настройки уровня звука
        private void уровеньЗвукаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LevelSoundForm levelSoundForm = new LevelSoundForm(BackColor, ForeColor);
            levelSoundForm.ShowDialog();
        }

        //Воспроизведение Windows Media Player
        private void игратьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wmp.Ctlcontrols.play();
        }

        //Пауза в Windows Media Player
        private void паузаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WMP.Ctlcontrols.pause();
        }

        //Стоп в Windows Media Player
        private void стопToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WMP.Ctlcontrols.stop();
        }

        //Следующий трек в Windows Media Player
        private void следующийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WMP.Ctlcontrols.next();
        }

        //Предыдущий трек в Windows Media Player
        private void предыдущийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WMP.Ctlcontrols.previous();
        }

        //Загрузка плейлиста в Windows Media Player
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wmpForm.ClearListButton_Click(sender, e);
            wmpForm.LoadListButton_Click(sender, e);
        }

        //Настройка плейлиста Windows Media Player
        private void создатьПлейлистToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wmpForm.ShowDialog();
        }

        //Очищение плейлиста Windows Media Player
        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wmpForm.ClearListButton_Click(sender, e);
        }

        //Закрытие программы
        private void ElsaForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                AddHistoryLog("Эльза", "Программа успешно выключена");
            }
            catch (Exception)
            {
                AddHistoryLog("Эльза", "Аварийное завершение программы");
            }
        }

        //При окончании - включать следующую
        private void WMP_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            //Если ожидание и не плейлист
            if (e.newState == 8 && WMP.settings.playCount < 2)
            {
                //Если не последний трек, вкл. следующего, иначе - возрат на нулевой
                if (wmpForm.PlayListBox.SelectedIndex != wmpForm.PlayListBox.Items.Count - 1)
                    wmpForm.PlayListBox.SetSelected(++wmpForm.PlayListBox.SelectedIndex, true);
                else
                    wmpForm.PlayListBox.SetSelected(0, true);
                WMPstopPause = false; //Определение стопа
            }
            if (WMPstopPause == true) //Если трек включился - выход из функции
                return;
            WMP.Ctlcontrols.play(); //Пробовать включать трек
            if (e.newState == 3) //Если включился - определяем
                WMPstopPause = true;
        }

        //Задание светлого фона на всех формах
        private void светлаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreColor = Color.Black;
            backColor = Color.GhostWhite;
            EditableGroupBox.ForeColor = Color.Black;
            SearcherGroupBox.ForeColor = Color.Black;
            UserSpeakTextBox.ForeColor = Color.Black;
            BackColor = Color.GhostWhite;
            mainMenuStrip.BackColor = Color.AliceBlue;            
            ForeColor = Color.Black;
            for (int i = 0; i < 4; i++)
                mainMenuStrip.Items[i].ForeColor = Color.Black;
        }

        //Задание фиолетового фона на всех формах
        private void фиолетоваяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreColor = Color.BlueViolet;
            backColor = Color.DarkViolet;
            EditableGroupBox.ForeColor = Color.Indigo;
            SearcherGroupBox.ForeColor = Color.Indigo;
            UserSpeakTextBox.ForeColor = Color.Indigo;
            BackColor = Color.DarkViolet;
            mainMenuStrip.BackColor = Color.BlueViolet;
            ForeColor = Color.Indigo;
            for (int i = 0; i < 4; i++)
                mainMenuStrip.Items[i].ForeColor = Color.Indigo;
        }

        //Задание синего фона на всех формах
        private void синяяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreColor = Color.DarkBlue;
            backColor = Color.CornflowerBlue;
            EditableGroupBox.ForeColor = Color.DarkBlue;
            SearcherGroupBox.ForeColor = Color.DarkBlue;
            UserSpeakTextBox.ForeColor = Color.DarkBlue;
            BackColor = Color.CornflowerBlue;
            mainMenuStrip.BackColor = Color.RoyalBlue;
            ForeColor = Color.DarkBlue;
            for (int i = 0; i < 4; i++)
                mainMenuStrip.Items[i].ForeColor = Color.DarkBlue;
        }

        //Задание голубого фона на всех формах
        private void голубаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreColor = Color.SkyBlue;
            backColor = Color.LightBlue;
            EditableGroupBox.ForeColor = Color.SteelBlue;
            SearcherGroupBox.ForeColor = Color.SteelBlue;
            UserSpeakTextBox.ForeColor = Color.SteelBlue;
            BackColor = Color.LightBlue;
            mainMenuStrip.BackColor = Color.SkyBlue;
            ForeColor = Color.SteelBlue;
            for (int i = 0; i < 4; i++)
                mainMenuStrip.Items[i].ForeColor = Color.SteelBlue;
        }

        //Задание темного фона на всех формах
        private void темнаяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreColor = Color.WhiteSmoke;
            backColor = Color.FromArgb(20, 20, 20);
            BackColor = Color.FromArgb(20, 20, 20);
            mainMenuStrip.BackColor = Color.Black;
            ForeColor = Color.WhiteSmoke;
            JournalTable.ForeColor = Color.Black;
            buttonListCommand.ForeColor = Color.Black;
            buttonListCommandToolTip.ForeColor = Color.Black;
            EditableAddButton.ForeColor = Color.Black;
            EditableButton.ForeColor = Color.Black;
            WayButton.ForeColor = Color.Black;
            EditableDelButton.ForeColor = Color.Black;
            EditableGroupBox.ForeColor = Color.WhiteSmoke;
            SearcherGroupBox.ForeColor = Color.WhiteSmoke;
            UserSpeakTextBox.ForeColor = Color.WhiteSmoke;
            HistoryLog.ForeColor = Color.Black;
            for (int i = 0; i < 4; i++)
                mainMenuStrip.Items[i].ForeColor = Color.WhiteSmoke;
        }

        //Поиск среди таблицы команд
        private void SearcherJournalTable(string str)
        {
            for (int i = 0; i < JournalTable.RowCount; i++)
            {
                JournalTable.Rows[i].Selected = false;
                if (JournalTable.Rows[i].Cells[1].Value != null)
                {
                    if (str == JournalTable.Rows[i].Cells[0].Value.ToString() || str == "Все")
                    {
                        JournalTable.Rows[i].Visible = true;
                        if (SearcherPerformanceTextBox.Text == "")
                        {
                            if (JournalTable.Rows[i].Cells[1].Value.ToString().ToLower().Contains(SearcherCommandTextBox.Text.ToLower()))
                            {
                                JournalTable.FirstDisplayedScrollingRowIndex = i;
                                JournalTable.Rows[i].Selected = true;
                                break;
                            }
                        }
                        else if (SearcherCommandTextBox.Text == "")
                        {
                            if (JournalTable.Rows[i].Cells[2].Value.ToString().ToLower().Contains(SearcherPerformanceTextBox.Text.ToLower()))
                            {
                                JournalTable.FirstDisplayedScrollingRowIndex = i;
                                JournalTable.Rows[i].Selected = true;
                                break;
                            }
                        }
                        else if (SearcherPerformanceTextBox.Text != "" && SearcherCommandTextBox.Text != "")
                        {
                            if (JournalTable.Rows[i].Cells[2].Value.ToString().ToLower().Contains(SearcherPerformanceTextBox.Text.ToLower()) &&
                                JournalTable.Rows[i].Cells[1].Value.ToString().ToLower().Contains(SearcherCommandTextBox.Text.ToLower()))
                            {
                                JournalTable.FirstDisplayedScrollingRowIndex = i;
                                JournalTable.Rows[i].Selected = true;
                                break;
                            }
                        }
                    }
                    else
                        JournalTable.Rows[i].Visible = false;
                }
            }
        }

        //Поиск среди таблицы журнала истории
        private void SearcherHistoryLog(string str)
        {
            for (int i = 0; i < HistoryLog.RowCount; i++)
            {
                HistoryLog.Rows[i].Selected = false;
                if (HistoryLog.Rows[i].Cells[1].Value != null)
                {
                    if (str == HistoryLog.Rows[i].Cells[0].Value.ToString() || str == "Диалог")
                    {
                        HistoryLog.Rows[i].Visible = true;
                        if (SearcherPerformanceTextBox.Text == "")
                        {
                            if (HistoryLog.Rows[i].Cells[1].Value.ToString().ToLower().Contains(SearcherCommandTextBox.Text.ToLower()))
                            {
                                HistoryLog.FirstDisplayedScrollingRowIndex = i;
                                HistoryLog.Rows[i].Selected = true;
                                break;
                            }
                        }
                        else if (SearcherCommandTextBox.Text == "")
                        {
                            if (HistoryLog.Rows[i].Cells[2].Value.ToString().ToLower().Contains(SearcherPerformanceTextBox.Text.ToLower()))
                            {
                                HistoryLog.FirstDisplayedScrollingRowIndex = i;
                                HistoryLog.Rows[i].Selected = true;
                                break;
                            }
                        }
                        else if (SearcherPerformanceTextBox.Text != "" && SearcherCommandTextBox.Text != "")
                        {
                            if (HistoryLog.Rows[i].Cells[2].Value.ToString().ToLower().Contains(SearcherPerformanceTextBox.Text.ToLower()) &&
                                HistoryLog.Rows[i].Cells[1].Value.ToString().ToLower().Contains(SearcherCommandTextBox.Text.ToLower()))
                            {
                                HistoryLog.FirstDisplayedScrollingRowIndex = i;
                                HistoryLog.Rows[i].Selected = true;
                                break;
                            }
                        }
                    }
                    else
                        JournalTable.Rows[i].Visible = false;
                }
            }
        }

        //Поиск среди значений таблиц по выбранному типу
        private void SearcherCommandTextBox_TextChanged(object sender, EventArgs e)
        {
            //Ничего не введенно - возврат к первой строке
            if (SearcherCommandTextBox.Text == "" && SearcherPerformanceTextBox.Text == "" && JournalTable.Visible == true)
            {
                for (int i = 0; i < JournalTable.RowCount; i++)
                    JournalTable.Rows[i].Visible = true;
                JournalTable.FirstDisplayedScrollingRowIndex = 0;
                return;
            }
            else if (SearcherCommandTextBox.Text == "" && SearcherPerformanceTextBox.Text == "" && HistoryLog.Visible == true)
            {
                for (int i = 0; i < HistoryLog.RowCount; i++)
                    HistoryLog.Rows[i].Visible = true;
                HistoryLog.FirstDisplayedScrollingRowIndex = 0;
                return;
            }
            //Если активна таблица команд
            if (JournalTable.Visible == true)
                SearcherJournalTable(SearcherTypeComboBox.Text);
            else
                SearcherHistoryLog(SearcherTypeComboBox.Text);
        }

        //Выделение всей строки в таблице команд по нажатию ячейки
        private void JournalTable_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = JournalTable.CurrentCell.RowIndex;
            JournalTable.Rows[index].Selected = true;
            JournalTable.RowsDefaultCellStyle.SelectionForeColor = Color.AliceBlue;
        }

        //Выделение всей строки в таблице журнала истории по нажатию ячейки
        private void HistoryLog_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = HistoryLog.CurrentCell.RowIndex;
            HistoryLog.Rows[index].Selected = true;
            HistoryLog.RowsDefaultCellStyle.SelectionForeColor = Color.AliceBlue;
        }

        //Поиск по критериям при изменении значения выпадающего списка типа команд
        private void SearcherTypeComboBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Если текст введен - поиск по новому типу, иначе - только видимость выбранного типа
                if (SearcherCommandTextBox.Text != "" || SearcherPerformanceTextBox.Text != "" && SearcherTypeComboBox.Text == "Все")
                {
                    SearcherJournalTable(SearcherTypeComboBox.Text);
                    return;
                }
                else if (SearcherCommandTextBox.Text != "" || SearcherPerformanceTextBox.Text != "" && SearcherTypeComboBox.Text == "Диалог")
                {
                    SearcherHistoryLog(SearcherTypeComboBox.Text);
                    return;
                }
                //Если таблица команд - поиск в ней, иначе в журнале истории
                if (buttonListCommand.Text == "Журнал")
                {
                    for (int i = 0; i < JournalTable.RowCount; i++)
                    {
                        if (JournalTable.Rows[i].Cells[0].Value.ToString() != SearcherTypeComboBox.Text && SearcherTypeComboBox.Text != "Все")
                            JournalTable.Rows[i].Visible = false;
                        else
                            JournalTable.Rows[i].Visible = true;
                    }
                }
                else
                {
                    //Если текст введен - поиск по новому спикеру, иначе - только видимость выбранного спикера
                    for (int i = 0; i < HistoryLog.RowCount; i++)
                    {
                        if (HistoryLog.Rows[i].Cells[0].Value.ToString() != SearcherTypeComboBox.Text && SearcherTypeComboBox.Text != "Диалог")
                            HistoryLog.Rows[i].Visible = false;
                        else
                            HistoryLog.Rows[i].Visible = true;
                    }
                }
            }
            catch (Exception) { }
        }

        //Изменение текстовых свйоств компонентов поиска при изменении активной таблицы
        private void buttonListCommand_TextChanged(object sender, EventArgs e)
        {
            if (buttonListCommand.Text == "Журнал")
            {
                JournalTable.Visible = true;
                SearcherGroupBox.Text = "Поиск команд";
                SearcherCommandLabel.Text = "Голосовой ввод";
                SearcherPerformanceLabel.Text = "Исполнение";
                SearcherTypeLabel.Text = "Тип";
                SearcherTypeComboBox.Items.Clear();
                SearcherTypeComboBox.Items.Add("Все");
                SearcherTypeComboBox.Items.Add("Интернет");
                SearcherTypeComboBox.Items.Add("Приложение");
                SearcherTypeComboBox.Items.Add("Система");
                SearcherTypeComboBox.Text = "Все";
            }
            else
            {
                SearcherGroupBox.Text = "Поиск действия";
                SearcherCommandLabel.Text = "Сообщение";
                SearcherPerformanceLabel.Text = "Время";
                SearcherTypeLabel.Text = "Спикер";
                SearcherTypeComboBox.Items.Clear();
                SearcherTypeComboBox.Items.Add("Диалог");
                SearcherTypeComboBox.Items.Add(username);
                SearcherTypeComboBox.Items.Add("Эльза");
                SearcherTypeComboBox.Text = "Диалог";
                JournalTable.Visible = false;
            }
            SearcherCommandTextBox.Clear();
            SearcherPerformanceTextBox.Clear();
        }

        //Маска для ввода времени
        private void SearcherPerformanceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (SearcherPerformanceLabel.Text == "Время")
            {
                //Активация бэкспэйс
                if (e.KeyChar == (char)8 && SearcherPerformanceTextBox.Text.Length > 0)
                {
                    SearcherPerformanceTextBox.Text.Remove(SearcherPerformanceTextBox.Text.Length - 1);
                    return;
                }
                char ch = e.KeyChar;
                if (SearcherPerformanceTextBox.Text == "" && ch > 50)
                {
                    e.Handled = true;
                    return;
                }
                //Блокировка ввода при 2 подряд введенном нуле или длине в 8 символов, или при первой цифре равной 2 и второй больше 3,
                //или при вводе более 5* секунд или минут
                if (SearcherPerformanceTextBox.Text.Length > 0)
                    if ((Convert.ToChar(SearcherPerformanceTextBox.Text.Substring(SearcherPerformanceTextBox.Text.Length - 1, 1)) == '0'
                        && e.KeyChar == '0') || SearcherPerformanceTextBox.Text.Length == 8 || (ch > 51 && SearcherPerformanceTextBox.Text == "2")
                        || ((SearcherPerformanceTextBox.Text.Length == 2 || SearcherPerformanceTextBox.Text.Length == 3 ||
                        SearcherPerformanceTextBox.Text.Length == 5 || SearcherPerformanceTextBox.Text.Length == 6) && ch > 53))
                    {
                        e.Handled = true;
                        return;
                    }
                //При длине строки равной 2 и 5, добавлять двоеточие
                if (SearcherPerformanceTextBox.Text.Length == 2)
                {
                    SearcherPerformanceTextBox.Text += ":";
                    SearcherPerformanceTextBox.SelectionStart = SearcherPerformanceTextBox.Text.Length; //Перенос курсора в конец текстового поля
                }
                if (SearcherPerformanceTextBox.Text.Length == 5)
                {
                    SearcherPerformanceTextBox.Text += ":";
                    SearcherPerformanceTextBox.SelectionStart = SearcherPerformanceTextBox.Text.Length; //Перенос курсора в конец текстового поля
                }
                // ввод в texBox только цифр                
                if (SearcherPerformanceTextBox.Text.Length == 1 && ch == ':')
                {
                    SearcherPerformanceTextBox.Text = "0" + SearcherPerformanceTextBox.Text + ':';
                    SearcherPerformanceTextBox.SelectionStart = SearcherPerformanceTextBox.Text.Length;
                }
                if (SearcherPerformanceTextBox.Text.Length == 4 && ch == ':')
                {
                    SearcherPerformanceTextBox.Text = SearcherPerformanceTextBox.Text.Remove(SearcherPerformanceTextBox.Text.Length - 1)
                        + '0' + SearcherPerformanceTextBox.Text.Substring(SearcherPerformanceTextBox.Text.Length - 1) + ':';
                    SearcherPerformanceTextBox.SelectionStart = SearcherPerformanceTextBox.Text.Length;
                }
                if (!Char.IsDigit(ch) && ch != 8)
                    e.Handled = true;
            }
        }

        //Сортировка по убыванию
        private void SortedAscColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e, DataGridView dataGridView)
        {
            DataGridViewColumn newColumn = dataGridView.Columns[e.ColumnIndex];
            DataGridViewColumn oldColumn = dataGridView.SortedColumn;
            ListSortDirection direction;

            if (oldColumn != null)
            {
                if (oldColumn == newColumn && dataGridView.SortOrder == SortOrder.Ascending)
                    direction = ListSortDirection.Descending;
                else
                {
                    direction = ListSortDirection.Ascending;
                    oldColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                }
            }
            else
                direction = ListSortDirection.Ascending;

            dataGridView.Sort(newColumn, direction);
            newColumn.HeaderCell.SortGlyphDirection =
                direction == ListSortDirection.Ascending ?
                SortOrder.Ascending : SortOrder.Descending;


            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Programmatic;
                sortedJournalTable = true;
            }
        }
        //Сортировка по возрастанию
        private void SortedDescColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e, DataGridView dataGridView)
        {
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Programmatic;
                sortedJournalTable = true;
            }
        }

		//Сортировка журнала истории по нажатию заглавия столбцов;
        private void HistoryLog_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (sortedHistoryLog)
            {
                sortedHistoryLog = false;
                SortedAscColumnHeaderMouseClick(sender, e, HistoryLog);
            }
            else
            {
                sortedHistoryLog = true;
                SortedDescColumnHeaderMouseClick(sender, e, HistoryLog);
            }
        }

		//Сортировка таблицы команд по нажатию заглавия столбцов;
        private void JournalTable_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (sortedJournalTable)
            {
                sortedJournalTable = false;
                SortedAscColumnHeaderMouseClick(sender, e, JournalTable);
            }
            else
            {
                sortedJournalTable = true;
                SortedDescColumnHeaderMouseClick(sender, e, JournalTable);
            }
        }

		//Вызов справочной информации;
        private void помощьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process SysInfo = new Process();
                SysInfo.StartInfo.ErrorDialog = true;
                SysInfo.StartInfo.FileName = "HelpElsa.chm";
                SysInfo.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}