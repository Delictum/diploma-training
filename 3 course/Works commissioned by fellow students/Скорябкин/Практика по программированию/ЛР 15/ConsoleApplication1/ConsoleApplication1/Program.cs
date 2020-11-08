using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace hyin9
{
    class Flight
    {
        public int Number;
        public DateTime Departure;
        public string Destination;
        public string LastName;
        public int Count;
        public double Weight;
        public int Key;
        public Flight Next;

        public Flight()
        {
            this.Next = null;
        }

        public Flight(int Number, DateTime Departure, string Destination, string LastName,
            int Count, double Weight, int Key)
        {
            this.Number = Number;
            this.Departure = Departure;
            this.Destination = Destination;
            this.Weight = Weight;
            this.LastName = LastName;
            this.Count = Count;
            this.Key = Key;
            this.Next = null;
        }
    }

    class LineList
    {
        public int Number;
        public DateTime Departure;
        public string Destination;
        public string LastName;
        public int Count;
        public double Weight;
        public int Key;

        public Flight head = null;
        public Flight current = null;
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
            Console.WriteLine("\nВыберите пункт меню!\n");
        }

        public void FirstElem()
        {
            Console.Clear();
            Console.Write("Введите количество авиарейсов: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Заполнение {0} авиарейса: \n");

                Console.Write("Введите ключ: ");
                Key = int.Parse(Console.ReadLine());
                Console.Write("Введите номер рейса: ");
                Number = int.Parse(Console.ReadLine());
                Console.Write("Введите дату и время вылета: ");
                Departure = DateTime.Parse(Console.ReadLine());
                Console.Write("Введите пункт назначения: ");
                Destination = Console.ReadLine();
                Console.Write("Введите фамилию пассажира: ");
                LastName = Console.ReadLine();
                Console.Write("Введите количество мест багажа: ");
                Count = int.Parse(Console.ReadLine());
                Console.Write("Введите суммарный вес багажа: ");
                Weight = double.Parse(Console.ReadLine());

                Flight temp = new Flight(Number, Departure, Destination, LastName, Count, Weight, Key);
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
                Flight temp = head;
                while (temp != null)
                {
                    Console.Write("Ключ - {0}, номер рейса - {1}, дата и время вылета - {2}, пункт назначения - {3}, фамилия пассажира - {4}, количество мест багажа - {5}, суммарный вес багажа - {6};\n",
                    temp.Key, temp.Number, temp.Departure, temp.Destination, temp.Count, temp.LastName, temp.Weight);
                    temp = temp.Next;
                }
                Console.WriteLine("");
            }
        }

        public void FindElem()
        {
            Console.WriteLine("Введите дату и время вылета для поиска: ");
            Departure = DateTime.Parse(Console.ReadLine());
            Flight temp = head;
            Console.WriteLine("Результаты поиска: ");
            while (temp != null)
            {
                if (temp.Number == Number)
                {
                    Console.Write("Ключ - {0}, номер рейса - {1}, дата и время вылета - {2}, пункт назначения - {3}, фамилия пассажира - {4}, количество мест багажа - {5}, суммарный вес багажа - {6};\n",
                    temp.Key, temp.Number, temp.Departure, temp.Destination, temp.Count, temp.LastName, temp.Weight);
                    temp = temp.Next;
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
                Console.WriteLine("Заполнение {0} авиарейса: \n");

                Console.Write("Введите ключ: ");
                Key = int.Parse(Console.ReadLine());
                Console.Write("Введите номер рейса: ");
                Number = int.Parse(Console.ReadLine());
                Console.Write("Введите дату и время вылета: ");
                Departure = DateTime.Parse(Console.ReadLine());
                Console.Write("Введите пункт назначения: ");
                Destination = Console.ReadLine();
                Console.Write("Введите фамилию пассажира: ");
                LastName = Console.ReadLine();
                Console.Write("Введите количество мест багажа: ");
                Count = int.Parse(Console.ReadLine());
                Console.Write("Введите суммарный вес багажа: ");
                Weight = double.Parse(Console.ReadLine());

                Flight temp = new Flight(Number, Departure, Destination, LastName, Count,
                    Weight, Key);
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
                Console.WriteLine("Заполнение {0} авиарейса: \n");

                Console.Write("Введите ключ: ");
                Key = int.Parse(Console.ReadLine());
                Console.Write("Введите номер рейса: ");
                Number = int.Parse(Console.ReadLine());
                Console.Write("Введите дату и время вылета: ");
                Departure = DateTime.Parse(Console.ReadLine());
                Console.Write("Введите пункт назначения: ");
                Destination = Console.ReadLine();
                Console.Write("Введите фамилию пассажира: ");
                LastName = Console.ReadLine();
                Console.Write("Введите количество мест багажа: ");
                Count = int.Parse(Console.ReadLine());
                Console.Write("Введите суммарный вес багажа: ");
                Weight = double.Parse(Console.ReadLine());

                Flight temp = new Flight(Number, Departure, Destination, LastName, Count,
                    Weight, Key);
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
                Flight temp = head;
                Flight prev = head;
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
            Flight temp;
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