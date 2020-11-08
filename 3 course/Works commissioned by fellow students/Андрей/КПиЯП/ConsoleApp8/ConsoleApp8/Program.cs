using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConsoleApp3
{
    struct Train
    {
        /*
         * № поезда Пункт и время отправления Пункт и время прибытия 
         */
        public int Number;
        public string Punkt1;
        public string Punkt2;
        public double Time1;
        public double Time2;

        public Train(int Number, string Punkt1, string Punkt2, double Time1, double Time2)
        {
            this.Number = Number;
            this.Punkt1 = Punkt1;
            this.Punkt2 = Punkt2;
            this.Time1 = Time1;
            this.Time2 = Time2;
        }

    }

    class Program
    {
        static void Main()
        {
            /*
             * Вывести все сведения о поездах, время пребывания в пути которых превышает 7 часов 20 минут. 
             */
            Console.Write("Введите количество поездов: ");
            int n = int.Parse(Console.ReadLine());
            Train[] Trains = new Train[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Заполнение данных {0} поезда.", i + 1);
                Console.Write("Номер: ");
                int Number = int.Parse(Console.ReadLine());
                Console.Write("Пункт отправления: ");
                string Punkt1 = Console.ReadLine();
                Console.Write("Пункт назначения: ");
                string Punkt2 = Console.ReadLine();
                Console.Write("Время отправления: ");
                double Time1 = double.Parse(Console.ReadLine());
                Console.Write("Время прибытия: ");
                double Time2 = double.Parse(Console.ReadLine());
                Console.WriteLine();
                Trains[i] = new Train(Number, Punkt1, Punkt2, Time1, Time2);
            }

            double buf = 0;
            Console.WriteLine("Информация о поездах с длительностью более 7:20:00:");
            foreach (Train a in Trains)
            {
                if (a.Time2 > a.Time1)
                     buf = a.Time2 - a.Time1;
                else
                     buf = 24 + a.Time2 - a.Time1;
                if (buf > 7.2)
                {
                    Console.WriteLine("Номер: {0}", a.Number);
                    Console.WriteLine("Пункт отправления: {0}", a.Punkt1);
                    Console.WriteLine("Пункт назначения: {0}", a.Punkt2);
                    Console.WriteLine("Время отправления: {0}", a.Time1);
                    Console.WriteLine("Время прибытия: {0}", a.Time2);
                    Console.WriteLine();
                }
            }
            Console.ReadKey();
        }
    }
}
