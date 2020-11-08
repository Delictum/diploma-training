using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace hyin9
{
    class Journal
    {
        public int Kurs;
        public int Code;
        public string LastName;
        public DateTime Data;
        public int Number;
        public string Discipline;
        public int Ocenka;
        public int Key;
        public Journal Next;

        public Journal()
        {
            this.Next = null;
        }

        public Journal(int Kurs, int Code, string LastName,
        DateTime Data, int Number, string Discipline, int Ocenka,
        int Key)
        {
            this.Kurs = Kurs;
            this.Code = Code;
            this.LastName = LastName;
            this.Data = Data;
            this.Number = Number;
            this.Discipline = Discipline;
            this.Ocenka = Ocenka;
            this.Key = Key;
            this.Next = null;
        }
    }

    class LineList
    {
        public int Kurs;
        public int Code;
        public string LastName;
        public DateTime Data;
        public int Number;
        public string Discipline;
        public int Ocenka;
        public int Key;

        public Journal head = null; // заголовок списка 
        public Journal current = null; // текущий элемент списка 
        public LineList() { } // пустой конструктор 

        public void Menu() // вставка элемента в начало списка 
        {
            Console.Clear();
            Console.WriteLine("Главное меню:\n");
            Console.WriteLine(" 1. Заполнить список.");
            Console.WriteLine(" 2. Просмотреть список.");
            Console.WriteLine(" 3. Добавить новый элемент справа.");
            Console.WriteLine(" 4. Добавить новый элемент слева.");
            Console.WriteLine(" 5. Поиск элемента.");
            Console.WriteLine(" 6. Удалить элемент.");
            Console.WriteLine(" 7. Очистить список.");
            Console.WriteLine(" 8. Выход.\n");
            Console.WriteLine("\nВЫБЕРИТЕ НОМЕР НУЖНОГО ЗАДАНИЯ!\n");
        }

        public void FirstElem() // вставка элемента в начало списка 
        {
            Console.Clear();
            Console.Write("Введите количество журналов: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Заполнение {0} журнала: \n");

                Console.Write("Введите ключ: ");
                Key = int.Parse(Console.ReadLine());
                Console.Write("Введите курс: ");
                Kurs = int.Parse(Console.ReadLine());
                Console.Write("Введите код группы: ");
                Code = int.Parse(Console.ReadLine());
                Console.Write("Введите фамилию студента: ");
                LastName = Console.ReadLine();
                Console.Write("Введите дату поступления: ");
                Data = DateTime.Parse(Console.ReadLine());
                Console.Write("Введите номер зачетной книжки: ");
                Number = int.Parse(Console.ReadLine());
                Console.Write("Введите дисциплину: ");
                Discipline = Console.ReadLine();
                Console.Write("Введите оценку за экзамен по дисциплине: ");
                Ocenka = int.Parse(Console.ReadLine());

                string text = Convert.ToString(Key) + " " + Convert.ToString(Kurs) + " " +
                Convert.ToString(Code) + " " + LastName +
                " " + Convert.ToString(Data) + " " + Convert.ToString(Number) + " " +
                Discipline + " " + Convert.ToString(Ocenka);
                Regex theReg = new Regex(@"(?<key>\d\b\s)" +
                @"(?<lnots>\^[А-ЯЁ][а-яё]+ [А-ЯЁ][а-яё]+$)" +
                @"(?<sac>\^[А-ЯЁ][а-яё]+ [А-ЯЁ][а-яё]+$)" +
                @"(?<kosa>\^[А-ЯЁ][а-яё]+[А-ЯЁ][а-яё]+$)" +
                @"(?<lnot>\^[А-ЯЁ][а-яё]+ [А-ЯЁ][а-яё]+$)" +
                @"(?<dot>\d([0-9]{1,4}).\d([0-9]{1,2}).\d([0-9]{1,2}))\b\s" +
                @"(?<stot>\d([0-9]{1,2}):\d([0-9]{1,2}):\d([0-9]{1,2}))\b\s" +
                @"(?<nom>\d\b\s)");
                MatchCollection thematches1 = theReg.Matches(text);
                foreach (Match sss in thematches1)
                {
                    if (!theReg.IsMatch(Convert.ToString(sss))) { Console.WriteLine("ошибка"); };
                    Console.WriteLine("\ntheMatch: {0}", sss.ToString());
                    Console.WriteLine("key: {0}", sss.Groups["key"]);
                    Console.WriteLine("lnots: {0}", sss.Groups["lnots"]);
                    Console.WriteLine("sac: {0}", sss.Groups["sac"]);
                    Console.WriteLine("kosa: {0}", sss.Groups["kosa"]);
                    Console.WriteLine("lnot: {0}", sss.Groups["lnot"]);
                    Console.WriteLine("dot: {0}", sss.Groups["dot"]);
                    Console.WriteLine("stot: {0}", sss.Groups["stot"]);
                    Console.WriteLine("nom: {0}", sss.Groups["nom"]);
                }

                Journal temp = new Journal(Kurs, Code,
                LastName, Data, Number, Discipline,
                Ocenka, Key); // создание нового элемента списка и заполнение его значениями 
                if (head == null) // если список пуст 
                    head = temp; // новый элемент становится первым 
                else
                {
                    temp.Next = head; // добавление в новый элемент ссылки на первый элемент 
                    head = temp; // перезапись первого элемента 
                }
            }
        }

        public void Show() // метод просмотра списка 
        {
            Console.Clear();
            Console.WriteLine("Однонаправленный список: ");
            if (head == null) // если список пуст 
                Console.WriteLine("список пуст!");
            else
            {
                Journal temp = head; // создание нового элемента и запись в него первого 
                while (temp != null) // цикл до конца списка 
                {
                    Console.Write("Ключ - {0}, курс - {1}, код группы - {2}, фамилия студента - {3}, " +
                        "дата поступления - {4}, номер зачетной книжки - {5}, дисциплина - {6}, оценка за экзамен по дисциплине - {7}\n",
                    temp.Key, temp.Kurs, temp.Code, temp.LastName,
                    temp.Data, temp.Number,
                    temp.Discipline,
                    temp.Ocenka); // вернуть найденный элемент
                    temp = temp.Next; // переход к след. элементу 
                }
                Console.WriteLine("");
            }
        }

        public void FindElem() // метод поиска элемента по значению 
        {
            Console.WriteLine("Введите курс для поиска: ");
            Kurs = int.Parse(Console.ReadLine());
            Journal temp = head; // запись первого элемента в новый 
            Console.WriteLine("Результаты поиска: ");
            while (temp != null) // цикл пока не дошли до конца списка 
            {
                if (temp.Kurs == Kurs) // если элемент найден 
                    Console.Write("Ключ - {0}, курс - {1}, код группы - {2}, фамилия студента - {3}, " +
                        "дата поступления - {4}, номер зачетной книжки - {5}, дисциплина - {6}, оценка за экзамен по дисциплине - {7}\n",
                    temp.Key, temp.Kurs, temp.Code, temp.LastName,
                    temp.Data, temp.Number,
                    temp.Discipline,
                    temp.Ocenka); // вернуть найденный элемент 
                temp = temp.Next; // переход к след. элементу 
            }
        }

        public void Right_Element()
        {
            Console.Clear();
            if (head == null)
            {
                Console.WriteLine("Заполните список!");
            }
            else
            {
                Console.WriteLine("После какого элемента вставить новый? ");
                int m = int.Parse(Console.ReadLine());
                current = head;
                for (int i = 1; i < m; i++)
                    current = current.Next;
                Console.WriteLine("Заполнение {0} журнала: \n");
                Console.Write("Введите ключ: ");
                Key = int.Parse(Console.ReadLine());
                Console.Write("Введите курс: ");
                Kurs = int.Parse(Console.ReadLine());
                Console.Write("Введите код группы: ");
                Code = int.Parse(Console.ReadLine());
                Console.Write("Введите фамилию студента: ");
                LastName = Console.ReadLine();
                Console.Write("Введите дату поступления: ");
                Data = DateTime.Parse(Console.ReadLine());
                Console.Write("Введите номер зачетной книжки: ");
                Number = int.Parse(Console.ReadLine());
                Console.Write("Введите дисциплину: ");
                Discipline = Console.ReadLine();
                Console.Write("Введите оценку за экзамен по дисциплине: ");
                Ocenka = int.Parse(Console.ReadLine());

                Journal temp = new Journal(Kurs, Code,
                LastName, Data, Number, Discipline,
                Ocenka, Key);
                temp.Next = current.Next;
                current.Next = temp;
                current = temp;
            }
        }

        public void Left_Element()
        {
            Console.Clear();
            if (head == null)
            {
                Console.WriteLine("Заполните список!");
            }
            else
            {
                Console.WriteLine("Перед каким элементом вставить новый? ");
                int m = int.Parse(Console.ReadLine());
                current = head;
                for (int i = 1; i < m - 1; i++)
                    current = current.Next;
                Console.WriteLine("Заполнение {0} журнала: \n");
                Console.Write("Введите ключ: ");
                Key = int.Parse(Console.ReadLine());
                Console.Write("Введите курс: ");
                Kurs = int.Parse(Console.ReadLine());
                Console.Write("Введите код группы: ");
                Code = int.Parse(Console.ReadLine());
                Console.Write("Введите фамилию студента: ");
                LastName = Console.ReadLine();
                Console.Write("Введите дату поступления: ");
                Data = DateTime.Parse(Console.ReadLine());
                Console.Write("Введите номер зачетной книжки: ");
                Number = int.Parse(Console.ReadLine());
                Console.Write("Введите дисциплину: ");
                Discipline = Console.ReadLine();
                Console.Write("Введите оценку за экзамен по дисциплине: ");
                Ocenka = int.Parse(Console.ReadLine());

                Journal temp = new Journal(Kurs, Code,
                LastName, Data, Number, Discipline,
                Ocenka, Key);
                temp.Next = current.Next;
                current.Next = temp;
                current = temp;
            }
        }

        public void Delete_Elements()
        {
            Console.Clear();
            if (head != null)
            {
                Show();
                Journal temp = head;
                Journal prev = head;
                int i = 1;
                Console.WriteLine("Введите позицию в списке (число): ");
                int pos = int.Parse(Console.ReadLine());
                while (pos != i)
                {
                    prev = temp;
                    temp = temp.Next;
                    i++;
                }
                if (head == temp)
                    head = head.Next;
                else
                    prev.Next = temp.Next;
            }
            else
                Console.WriteLine("Список и так пустой! Удалять нечего.");
        }

        public void Clear_list()//метод очистки списка 
        {
            Journal temp;
            while (head != null)
            {
                temp = head.Next;
                head = temp;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            LineList List = new LineList();
            List.Menu();
            int c = int.Parse(Console.ReadLine());
            while (c != 8)
            {
                switch (c)
                {
                    case 1: List.FirstElem(); break;//заполнить список 
                    case 2: List.Show(); break;//просмотреть список 
                    case 3: List.Right_Element(); break;//добавить новый элемент 
                    case 4: List.Left_Element(); break;//добавить новый элемент 
                    case 5: List.FindElem(); break;//поиск элемента 
                    case 6: List.Delete_Elements(); break;//удалить элемент 
                    case 7: List.Clear_list(); break;//очистить список 
                    case 8: break;//выход 
                    default: Console.Write("Команды с таким номером нет!"); break;
                }
                do Console.Write("\nДля продолжения нажмите клавишу Enter....");
                while (Console.ReadKey().Key !=
                ConsoleKey.Enter);

                List.Menu();
                c = int.Parse(Console.ReadLine());
            }
        }
    }
}