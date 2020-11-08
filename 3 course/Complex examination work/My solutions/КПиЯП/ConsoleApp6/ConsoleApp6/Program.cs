using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Program
    {
        /* Вычислить и вывести на экран в виде таблицы значения функции w
         * на интервале [-1;1] с заданным шагом Δt=0.2. 
         * Описание функции оформить в виде пользовательской функции. 
         * При решении использовать циклы. 
         * Организовать вывод значения аргумента t и вычисленного значения функции w в виде таблицы.
         * Значения a, b вводятся с клавиатуры.
 
               { Math.Sqrt(a * Math.Pow(t, 2) + b * Math.Sin(t) + 1) | t < 0.1 | a=2.5 | t E [-1; 1]
           w = { a * t + b                                           | t = 0.1 | b=0.4 | /\t = 0.2
               { Math.Sqrt(a * Math.Pow(t, 2) + b * Math.Cos(t) + 1) | t > 0.1 |	      |                    
         */
        static void WF(double a, double b)
        {
            for (double t = -1; t <= 1; t += 0.2)
            {
                double W = 0;
                if (t < 0.1)
                {
                    W = Math.Sqrt(a * Math.Pow(t, 2) + b * Math.Sin(t) + 1);
                    Console.WriteLine("| {0:0.00} | {1:0.00} |", W, t);
                    continue;
                }
                else if (t == 0.1)
                {
                    W = a * t + b;
                    Console.WriteLine("| {0:0.00} | {1:0.00} |", W, t);
                    continue;
                }
                else
                {
                    W = Math.Sqrt(a * Math.Pow(t, 2) + b * Math.Cos(t) + 1);
                    Console.WriteLine("| {0:0.00} | {1:0.00} |", W, t);
                }
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Введите a: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Введите b: ");
            double b = double.Parse(Console.ReadLine());

            Console.WriteLine("_______________");
            Console.WriteLine("|  W  |   t   |");
            WF(a, b);
            Console.WriteLine("______________");
            Console.ReadKey();
        }
    }
}
