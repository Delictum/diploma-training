using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace hyin9
{
    class Tur
    {
        public string Name;
        public string PriceDay;
        public double FIO;
        public double Date;
        public double Days;
        public double PriceTravel;
        public double Course;
        public DateTime Counter;
        public int Key;
        public Tur Next;
        public Tur()
        {
            this.Next = null;
        }
        public Tur(string Name, string PriceDay, double FIO, double Date,
            double Days, double PriceTravel, double Course, DateTime Counter, int Key)
        {
            this.Name = Name;
            this.PriceDay = PriceDay;
            this.FIO = FIO;
            this.PriceTravel = PriceTravel;
            this.Date = Date;
            this.Course = Course;
            this.Days = Days;
            this.Counter = Counter;
            this.Key = Key;
            this.Next = null;
        }
    }
    class LineList
    {
        public string Name;
        public string PriceDay;
        public double FIO;
        public double Date;
        public double Days;
        public double PriceTravel;
        public double Course;
        public DateTime Counter;
        public int Key;
        public Tur head = null;
        public Tur current = null;
        public LineList() { }
        public void Menu()
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
            Console.Write("Введите количество сельскохозяйственных продуктов: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Заполнение {0} сельскохозяйственного продукта: \n");
                Console.Write("Введите ключ: ");
                Key = int.Parse(Console.ReadLine());
                Console.Write("Введите наименование района: ");
                Name = Console.ReadLine();
                Console.Write("Введите наименование продукта: ");
                PriceDay = Console.ReadLine();
                Console.Write("Введите площадь: ");
                FIO = double.Parse(Console.ReadLine());
                Console.Write("Введите урожайность: ");
                Days = double.Parse(Console.ReadLine());
                Console.Write("Введите цену: ");
                Date = double.Parse(Console.ReadLine());
                Console.Write("Введите потери при транспартировке: ");
                PriceTravel = double.Parse(Console.ReadLine());
                Console.Write("Введите стоимость продукта: ");
                Course = double.Parse(Console.ReadLine());
                Console.Write("Введите предполагаемую дату сбора: ");
                Counter = DateTime.Parse(Console.ReadLine());
                string text = Convert.ToString(Key) + " " + Name + " " +
                Convert.ToString(PriceDay) + " " + FIO +
                " " + Convert.ToString(Days) + " " + Convert.ToString(Date) + " " +
                Convert.ToString(PriceTravel) + " " + Convert.ToString(Counter) + " " + Convert.ToString(Course);
                Regex theReg = new Regex(@"(?<key>\d\b\s)" +
                @"(?<lnots>\^[А-ЯЁ][а-яё]+ [А-ЯЁ][а-яё]+$)" +
                @"(?<sac>\^d+\b\s)" +
                @"(?<kosa>\^[А-ЯЁ][а-яё]+[А-ЯЁ][а-яё]+$)" +
                @"(?<lnot>\^d\b\s)" +
                @"(?<dot>\d([0-9]{1,4}).\d([0-9]{1,2}).\d([0-9]{1,2})\b\s)" +
                @"(?<stot>\d+\b\s)" +
                @"(?<nom>\d+\b\s)" +
                @"(?<rate>\d+\b)");
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
                    Console.WriteLine("rate: {0}", sss.Groups["rate"]);
                }
                Tur temp = new Tur(Name, PriceDay, FIO, Date, Days,
                    PriceTravel, Course, Counter, Key);
                if (head == null)
                    head = temp;
                else
                {
                    temp.Next = head;
                    head = temp;
                }
            }
        }
        public void Show()
        {
            Console.Clear();
            Console.WriteLine("Однонаправленный список: ");
            if (head == null)
                Console.WriteLine("список пуст!");
            else
            {
                Tur temp = head;
                while (temp != null)
                {
                    Console.Write("Ключ - {0}, наименование района - {1} (где выращивают), наименование продукта - {2}, площадь - {3} (га), урожайность - {4} (кг/га), цена за 1 кг - {5}, потери при транспортировке - {6}%, стоимость продукта - {7}р., предполагаемая дата сбора - {8}\n",
                    temp.Key, temp.Name, temp.PriceDay, temp.FIO,
                    temp.Days, temp.Date, temp.PriceTravel,
                    temp.Course, temp.Counter); // вернуть найденный элемент 
                    temp = temp.Next; // переход к след. элементу 
                }
                Console.WriteLine("");
            }
        }
        public void FindElem()
        {
            Console.WriteLine("Введите наименование района для поиска: ");
            Name = Console.ReadLine();
            Tur temp = head;
            Console.WriteLine("Результаты поиска: ");
            while (temp != null)
            {
                if (temp.Name == Name)
                {
                    Console.Write("Ключ - {0}, наименование района - {1} (где выращивают), наименование продукта - {2}, площадь - {3} (га), урожайность - {4} (кг/га), цена за 1 кг - {5}, потери при транспортировке - {6}%, стоимость продукта - {7}р., предполагаемая дата сбора - {8}\n",
                    temp.Key, temp.Name, temp.PriceDay, temp.FIO,
                    temp.Days, temp.Date, temp.PriceTravel,
                    temp.Course, temp.Counter); // вернуть найденный элемент 
                    temp = temp.Next; // переход к след. элементу 
                }
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
                Console.WriteLine("Заполнение {0} сельскохозяйственного продукта: \n");
                Console.Write("Введите ключ: ");
                Key = int.Parse(Console.ReadLine());
                Console.Write("Введите наименование района: ");
                Name = Console.ReadLine();
                Console.Write("Введите наименование продукта: ");
                PriceDay = Console.ReadLine();
                Console.Write("Введите площадь: ");
                FIO = double.Parse(Console.ReadLine());
                Console.Write("Введите урожайность: ");
                Days = double.Parse(Console.ReadLine());
                Console.Write("Введите цену: ");
                Date = double.Parse(Console.ReadLine());
                Console.Write("Введите потери при транспартировке: ");
                PriceTravel = double.Parse(Console.ReadLine());
                Console.Write("Введите стоимость продукта: ");
                Course = double.Parse(Console.ReadLine());
                Console.Write("Введите предполагаемую дату сбора: ");
                Counter = DateTime.Parse(Console.ReadLine());
                Tur temp = new Tur(Name, PriceDay, FIO, Date, Days,
                    PriceTravel, Course, Counter, Key);
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
                Console.WriteLine("Заполнение {0} сельскохозяйственного продукта: \n");
                Console.Write("Введите ключ: ");
                Key = int.Parse(Console.ReadLine());
                Console.Write("Введите наименование района: ");
                Name = Console.ReadLine();
                Console.Write("Введите наименование продукта: ");
                PriceDay = Console.ReadLine();
                Console.Write("Введите площадь: ");
                FIO = double.Parse(Console.ReadLine());
                Console.Write("Введите урожайность: ");
                Days = double.Parse(Console.ReadLine());
                Console.Write("Введите цену: ");
                Date = double.Parse(Console.ReadLine());
                Console.Write("Введите потери при транспартировке: ");
                PriceTravel = double.Parse(Console.ReadLine());
                Console.Write("Введите стоимость продукта: ");
                Course = double.Parse(Console.ReadLine());
                Console.Write("Введите предполагаемую дату сбора: ");
                Counter = DateTime.Parse(Console.ReadLine());
                Tur temp = new Tur(Name, PriceDay, FIO, Date, Days,
                    PriceTravel, Course, Counter, Key);
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
                Tur temp = head;
                Tur prev = head;
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
        public void Clear_list()
        {
            Tur temp;
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
                    case 1: List.FirstElem(); break;
                    case 2: List.Show(); break;
                    case 3: List.Right_Element(); break;
                    case 4: List.Left_Element(); break;
                    case 5: List.FindElem(); break;
                    case 6: List.Delete_Elements(); break;
                    case 7: List.Clear_list(); break;
                    case 8: break;
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
