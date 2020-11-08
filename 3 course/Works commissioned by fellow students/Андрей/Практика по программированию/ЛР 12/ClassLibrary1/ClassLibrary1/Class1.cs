using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
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
}
