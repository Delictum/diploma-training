using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace hyin9
{
    class Auto
    {
        /*Один элемент (автомобиль) представляет собой структуру с полями: 
        фамилия владельца, марка автомобиля, требуемая марка бензина, 
        мощность двигателя, объем бака, остаток бензина, объем масла, дата техосмотра. 
        Дана фиксированная цена литра бензина и заливки масла. Поиск - по марке автомобиля.
        */

        public string LastName;
        public string MarkaAuto;
        public string MarkaPetrol;
        public int PowerDigital;
        public int VolumeOfTheTank;
        public int ResidueOfGasoline;
        public int VolumeOfOil;
        public DateTime VehicleInspectionDate;
        public double PricePetrol;
        public double PriceOil;
        public int Key;
        public Auto Next;

        public Auto()
        {
            this.Next = null;
        }

        public Auto(string LastName, string MarkaAuto, string MarkaPetrol,
        int PowerDigital, int VolumeOfTheTank, int ResidueOfGasoline, int VolumeOfOil,
        DateTime VehicleInspectionDate, int Key)
        {
            this.LastName = LastName;
            this.MarkaAuto = MarkaAuto;
            this.MarkaPetrol = MarkaPetrol;
            this.PowerDigital = PowerDigital;
            this.VolumeOfTheTank = VolumeOfTheTank;
            this.ResidueOfGasoline = ResidueOfGasoline;
            this.VolumeOfOil = VolumeOfOil;
            this.VehicleInspectionDate = VehicleInspectionDate;
            this.Key = Key;
            this.Next = null;
            PricePetrol = 2.11;
            PriceOil = 6.86;
        }
    }

    class LineList
    {
        public string LastName;
        public string MarkaAuto;
        public string MarkaPetrol;
        public int PowerDigital;
        public int VolumeOfTheTank;
        public int ResidueOfGasoline;
        public int VolumeOfOil;
        public DateTime VehicleInspectionDate;
        public int Key;

        public Auto head = null;
        public Auto current = null;
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

        public void FirstElem()
        {
            Console.Clear();
            Console.Write("Введите количество автомобилей: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Заполнение {0} автомобиля: \n");

                Console.Write("Введите ключ: ");
                Key = int.Parse(Console.ReadLine());
                Console.Write("Введите фамилию владельца: ");
                LastName = Console.ReadLine();
                Console.Write("Введите марку автомобиля: ");
                MarkaAuto = Console.ReadLine();
                Console.Write("Введите марку бензина: ");
                MarkaPetrol = Console.ReadLine();
                Console.Write("Введите мощность двигателя: ");
                PowerDigital = int.Parse(Console.ReadLine());
                Console.Write("Введите объем бака: ");
                VolumeOfTheTank = int.Parse(Console.ReadLine());
                Console.Write("Введите остаток бензина: ");
                ResidueOfGasoline = int.Parse(Console.ReadLine());
                Console.Write("Введите объем масла: ");
                VolumeOfOil = int.Parse(Console.ReadLine());
                Console.Write("Введите дату техосмотра: ");
                VehicleInspectionDate = DateTime.Parse(Console.ReadLine());

                string text = Convert.ToString(Key) + " " + LastName + " " +
                MarkaAuto + " " + MarkaPetrol +
                " " + Convert.ToString(PowerDigital) + " " + Convert.ToString(VolumeOfTheTank) + " " +
                Convert.ToString(ResidueOfGasoline) + " " + Convert.ToString(VolumeOfOil) + " " + Convert.ToString(VehicleInspectionDate);
                Regex theReg = new Regex(@"(?<key>\d\b\s)" +
                @"(?<lnots>\^[А-ЯЁ][а-яё]+ [А-ЯЁ][а-яё]+$)" +
                @"(?<sac>\^[А-ЯЁ][а-яё]+ [А-ЯЁ][а-яё]+$)" +
                @"(?<kosa>\^[А-ЯЁ][а-яё]+[А-ЯЁ][а-яё]+$)" +
                @"(?<lnot>\^[А-ЯЁ][а-яё]+ [А-ЯЁ][а-яё]+$)" +
                @"(?<dot>\d([0-9]{1,4}).\d([0-9]{1,2}).\d([0-9]{1,2}))\b\s" +
                @"(?<stot>\d([0-9]{1,2}):\d([0-9]{1,2}):\d([0-9]{1,2}))\b\s" +
                @"(?<nom>\d\b\s)" +
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

                Auto temp = new Auto(LastName, MarkaAuto,
                MarkaPetrol, PowerDigital, VolumeOfTheTank, ResidueOfGasoline,
                VolumeOfOil, VehicleInspectionDate, Key); 
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
                Auto temp = head; 
                while (temp != null)
                {
                    Console.Write("{0}) фамилия владельца - {1}, марка автомобиля - {2}, требуемая марка бензина - {3}, " +
                        "мощность двигателя - {4}, объем бака - {5}, остаток бензина - {6}, объем масла - {7}, дата техосмотра - {8}, " +
                        "цена литра бензина - {9}, цена заливки масла - {10}\n",
                    temp.Key, temp.LastName, temp.MarkaAuto, temp.MarkaPetrol,
                    temp.PowerDigital, temp.VolumeOfTheTank, temp.ResidueOfGasoline,
                    temp.VolumeOfOil, temp.VehicleInspectionDate, temp.PricePetrol, temp.PriceOil);
                    temp = temp.Next;
                }
                Console.WriteLine("");
            }
        }

        public void FindElem() 
        {
            Console.WriteLine("Введите марку автомобиля для поиска: ");
            MarkaAuto = Console.ReadLine();
            Auto temp = head; 
            Console.WriteLine("Результаты поиска: ");
            while (temp != null) 
            {
                if (temp.MarkaAuto == MarkaAuto) 
                    Console.Write("{0}) фамилия владельца - {1}, марка автомобиля - {2}, требуемая марка бензина - {3}, " +
                       "мощность двигателя - {4}, объем бака - {5}, остаток бензина - {6}, объем масла - {7}, дата техосмотра - {8}, " +
                       "цена литра бензина - {9}, цена заливки масла - {10}\n",
                   temp.Key, temp.LastName, temp.MarkaAuto, temp.MarkaPetrol,
                   temp.PowerDigital, temp.VolumeOfTheTank, temp.ResidueOfGasoline,
                   temp.VolumeOfOil, temp.VehicleInspectionDate, temp.PricePetrol, temp.PriceOil); 
                temp = temp.Next; 
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
                Console.WriteLine("Заполнение {0} автомобиля: \n");
                Console.Write("Введите ключ: ");
                Key = int.Parse(Console.ReadLine());
                Console.Write("Введите фамилию владельца: ");
                LastName = Console.ReadLine();
                Console.Write("Введите марку автомобиля: ");
                MarkaAuto = Console.ReadLine();
                Console.Write("Введите марку бензина: ");
                MarkaPetrol = Console.ReadLine();
                Console.Write("Введите мощность двигателя: ");
                PowerDigital = int.Parse(Console.ReadLine());
                Console.Write("Введите объем бака: ");
                VolumeOfTheTank = int.Parse(Console.ReadLine());
                Console.Write("Введите остаток бензина: ");
                ResidueOfGasoline = int.Parse(Console.ReadLine());
                Console.Write("Введите объем масла: ");
                VolumeOfOil = int.Parse(Console.ReadLine());
                Console.Write("Введите дату техосмотра: ");
                VehicleInspectionDate = DateTime.Parse(Console.ReadLine());

                Auto temp = new Auto(LastName, MarkaAuto,
                MarkaPetrol, PowerDigital, VolumeOfTheTank, ResidueOfGasoline,
                VolumeOfOil, VehicleInspectionDate, Key);
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
                Console.WriteLine("Заполнение {0} автомобиля: \n");
                Console.Write("Введите ключ: ");
                Key = int.Parse(Console.ReadLine());
                Console.Write("Введите фамилию владельца: ");
                LastName = Console.ReadLine();
                Console.Write("Введите марку автомобиля: ");
                MarkaAuto = Console.ReadLine();
                Console.Write("Введите марку бензина: ");
                MarkaPetrol = Console.ReadLine();
                Console.Write("Введите мощность двигателя: ");
                PowerDigital = int.Parse(Console.ReadLine());
                Console.Write("Введите объем бака: ");
                VolumeOfTheTank = int.Parse(Console.ReadLine());
                Console.Write("Введите остаток бензина: ");
                ResidueOfGasoline = int.Parse(Console.ReadLine());
                Console.Write("Введите объем масла: ");
                VolumeOfOil = int.Parse(Console.ReadLine());
                Console.Write("Введите дату техосмотра: ");
                VehicleInspectionDate = DateTime.Parse(Console.ReadLine());

                Auto temp = new Auto(LastName, MarkaAuto,
                MarkaPetrol, PowerDigital, VolumeOfTheTank, ResidueOfGasoline,
                VolumeOfOil, VehicleInspectionDate, Key);
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
                Auto temp = head;
                Auto prev = head;
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
            Auto temp;
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