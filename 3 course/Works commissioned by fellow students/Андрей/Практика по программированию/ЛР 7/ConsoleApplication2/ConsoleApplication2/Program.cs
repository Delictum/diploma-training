using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
namespace ConsoleApp5
{
    //печатное издание, журнал, книга, учебник
    abstract class Ship
    {
        public string name, color, appointment;
        public int weight, crew, year;

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

        public abstract void print();

        public static Ship operator ++(Ship obj1)
        {
            obj1.weight += 1;
            return obj1;
        }
    }

    class SailingShip : Ship
    {
        public string sail;

        public SailingShip(string sail, string name, string color, string appointment, int crew, int weight, int year) 
            :base (name, color, appointment, crew, weight, year)
        {
            this.sail = sail;
        }

        public override void print()
        {
            Console.WriteLine("Корабль:\nНазвание: {0};\nЦвет: {1};\nНазначение: {2};\nЧисленность экипажа: {3};\nВес: {4};\nГод выпуска: {5};\nВид паруса: {6}.\n",
                name, color, appointment, crew, weight, year, sail);
        }
    }

    class Steamship : Ship
    {
        public string engine;

        public Steamship(string engine, string name, string color, string appointment, int crew, int weight, int year)
            : base(name, color, appointment, crew, weight, year)
        {
            this.engine = engine;
        }

        public override void print()
        {
            
        }

        public void printer()
        {
            Console.WriteLine("Корабль:\nНазвание: {0};\nЦвет: {1};\nНазначение: {2};\nЧисленность экипажа: {3};\nВес: {4};\nГод выпуска: {5};",
                name, color, appointment, crew, weight, year);
            Console.WriteLine("Двигатель: {0};", engine);
        }
    }

    class Corvette : Steamship
    {
        public string country;

        public Corvette(string country, string engine, string name, string color, string appointment, int crew, int weight, int year)
            : base(engine, name, color, appointment, crew, weight, year)
        {
            this.country = "Великобритания";
        }

        public override void print()
        {
            printer();
            Console.WriteLine("Страна: {0}.\n", country);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            string name, color, appointment, sail, engine, country;
            int weight, year, crew;

            Corvette tb = new Corvette("Франция", "UG-1836E", "Изольда", "Серебро", "Военный", 262, 80000, 2012);
            tb.print(); 

            Console.WriteLine("Введите количество парусников: ");
            int n = int.Parse(Console.ReadLine());

            SailingShip[] j = new SailingShip[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Заполнение данных парусника:");
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
                Console.Write("Введите вид паруса: ");
                sail = Console.ReadLine();
                j[i] = new SailingShip(sail, name, color, appointment, crew, weight, year);
                Console.WriteLine();
            }

            j[0].weight++;

            for (int i = 0; i < n; i++)
            {                     
                j[i].print();
            }

            Console.WriteLine("Введите количество пароходов: ");
            int nn = int.Parse(Console.ReadLine());

            Steamship[] jj = new Steamship[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Заполнение данных парохода:");
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
                Console.Write("Введите двигатель: ");
                engine = Console.ReadLine();
                jj[i] = new Steamship(engine, name, color, appointment, crew, weight, year);
                Console.WriteLine();
            }

            for (int i = 0; i < n; i++)
            {
                j[i].print();
            }

            Console.ReadKey();
        }
    }
}
