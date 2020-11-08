using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class Ship
    {
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
    }


    public class Program
    {
        static void Main(string[] args)
        {
            Ship pp = new Ship();
            pp.print();

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
