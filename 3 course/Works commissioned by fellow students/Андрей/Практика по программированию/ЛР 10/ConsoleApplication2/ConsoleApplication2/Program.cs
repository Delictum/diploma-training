using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace ConsoleApp5
{
    public delegate void info_print();

    class Ship
    {
        public event info_print event_print;

        public string name, color, appointment;
        public int weight, crew;
        private int year;

        public Ship()
        {
            name = "Элизабет";
            color = "Коричневый";
            appointment = "Торговый";
            crew = 48;
            weight = 13;
            year = 1997;
        }

        public Ship(string name, string color, string appointment, int crew, int weight, int year)
        {
            this.name = name;
            this.color = color;
            this.appointment = appointment;
            this.crew = crew;
            this.weight = weight;
            this.year = year;
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public int Weight
        {
            get { return weight; }
            set
            {
                weight = value;
                if ((value <= 100000) && (value >= 30000))
                    Console.WriteLine("Средний вес");
            }
        }

        public void print()
        {
            Console.WriteLine("Корабль:\nНазвание: {0};\nЦвет: {1};\nНазначение: {2};\nЧисленность экипажа: {3};\nВес: {4};\nГод выпуска: {5};\n",
                name, color, appointment, crew, weight, year);
        }

        public static Ship operator ++(Ship obj1)
        {
            obj1.weight += 1;
            return obj1;
        }

        public void Ship_e_p()
        {
            Console.WriteLine("Обработчик события вызван.");
        }

        public void events_now()
        {
            event_print();
        }

        public void events_job()
        {
            Console.WriteLine("Обработчик события.");
        }
    }

    public interface ISort<T>
       where T : struct
    {
        void ReWrite();
    }

    class MyObj<T> : ISort<T> where T : struct
    {
        public int longOb { get; set; }
        T[] myarr;

        public MyObj(int i)
        {
            longOb = i;
        }

        public MyObj(int i, T[] arr)
        {
            longOb = i;
            myarr = new T[i];
            for (int j = 0; j < arr.Length; j++)
                myarr[j] = arr[j];
        }

        public void ReWrite()
        {
            Console.WriteLine("Тип: {0}", typeof(T));
            Console.WriteLine("Распределение кораблей по областям: ");
            foreach (T t in myarr)
                Console.Write("{0}; ", t);
            Console.WriteLine("\n");
        }

        public static int SumInt(int a, int b)
        {
            return a + b;
        }
    }

    delegate T MyDel<T>(T obj1, T obj2);

    public class Program
    {
        public delegate int Del(int DT);

        static int on_date_time(int dt)
        {
            return dt + 1;
        }

        static void ThreadFunction(Object input)
        {
            int flag = (int)input;
            if (flag == 1)
            {
                Console.WriteLine("Это первый поток!");
            }
            else
            {
                Console.WriteLine("Это второй поток!");
            }
        }

        static void EggsFunction()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.Write(" text ");
                Thread.Sleep(15);
            }
        }

        static void Sort<T>(ref T[] a) where T : IComparable<T>
        {
            T buf;
            int n = a.Length;
            for (int i = 0; i < n; i++)
            {
                int im = i;
                for (int j = i + 1; j < n; j++)
                    if (a[j].CompareTo(a[im]) < 0) im = j;
                buf = a[i]; a[i] = a[im]; a[im] = buf;
            }
        }

        static void Main(string[] args)
        {
            MyDel<int> del1 = MyObj<int>.SumInt;
            Console.WriteLine("Количество военных и торговых кораблей = " + del1(136, 74));

            int[] MyArrByte = new int[6] { 41, 50, 183, 566, 87, 65 };
            MyObj<int> ByteConst = new MyObj<int>(MyArrByte.Length, MyArrByte);
            ByteConst.ReWrite();

            Console.WriteLine("Названия кораблей: ");
            string[] a = { "Меркант", "Абильгейт", "Кэрвэт", "Фельхарг", "Тур", "Айлива", "Стонергам" };
            foreach (string x in a) Console.Write(x + "; ");
            Console.WriteLine();
            Console.WriteLine("Упорядочивание названий в алфавитном порядке: ");
            Sort<string>(ref a);
            foreach (string x in a) Console.Write(x + "; ");
            Console.WriteLine();
            Console.WriteLine();

            Thread thread1 = new Thread(ThreadFunction);
            thread1.Start(1);
            Thread thread2 = new Thread(ThreadFunction);
            thread2.Start(2);
            Thread thread3 = new Thread(EggsFunction);
            thread3.Start();

            Del d = new Del(on_date_time);
            Console.WriteLine("Делегат создан {0} числа", d(1));
            Console.WriteLine();

            Ship pp = new Ship();
            pp.print();

            Console.WriteLine("Подписка на событиe активирована: ");
            pp.event_print += new info_print(pp.events_job);
            pp.event_print += new info_print(pp.Ship_e_p);
            pp.events_now();
            Console.WriteLine();

            Console.WriteLine("Подписка на событие  отменена: ");
            pp.event_print -= new info_print(pp.events_job);
            pp.events_now();
            Console.WriteLine();

            string name, color, appointment;
            int weight, year, crew;

            Console.WriteLine("Заполнение данных корабля:");
            Console.Write("Введите название: ");
            name = Console.ReadLine();
            Console.Write("Введите цвет: ");
            color = Console.ReadLine();
            Console.Write("Введите назначение: ");
            appointment = Console.ReadLine();
            Console.Write("Введите численность экипажа: ");
            crew = int.Parse(Console.ReadLine());
            Console.Write("Введите вес: ");
            weight = int.Parse(Console.ReadLine());
            Console.Write("Введите год выпуска: ");
            year = int.Parse(Console.ReadLine());
            Ship p_p = new Ship(name, color, appointment, crew, weight, year);
            Console.WriteLine();

            p_p.print();
            p_p.Color = color;
            p_p.Weight = weight;
            p_p.weight++;
            p_p.print();

            Console.ReadKey();
        }
    }
}
