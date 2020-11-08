using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1.");
            double A = 0.00035;
            int I = 1989;
            double C = -380.08;
            bool L = true;
            string Name = "Отчество";

            Console.WriteLine("Результаты форматирования: \nName = {0:6}, l = {1:4}", Name, L);
            Console.WriteLine("a = {0:4}, c = {1:5}, i = {2:e8}", A, C, I);
            Console.WriteLine();

            Console.WriteLine("Задание 2.");
            string xmin, xmax, x; double y;
            StreamWriter f = new StreamWriter("LAB2.res");
            StreamReader f1 = new StreamReader("LAB2.txt");
            f.WriteLine("Таблица значений функции: ");
            xmin = f1.ReadLine();
            xmax = f1.ReadLine();
            x = f1.ReadLine();
            Console.WriteLine("Xmin = {0}, Xmax = {1}, X = {2}", xmin, xmax, x);
            f.WriteLine("| Аргумент x | Функция y |");
            Console.WriteLine("| Аргумент x | Функция y |");
            f.WriteLine("__________________________");
            Console.WriteLine("__________________________");
            for (double i = Convert.ToDouble(xmin); i <= Convert.ToDouble(xmax); i += Convert.ToDouble(x))
            {
                y = (Math.Pow(i, 2) - 5 * i +4) / (Math.Pow(i, 2) + 1);
                f.WriteLine("|   {0:F3}   | {1:e3} |\n", i, y);
                Console.WriteLine("|   {0:F3}   | {1:e3} |", i, y);
            }
            f.Close();
            f1.Close();

            Console.ReadKey();           
        }
    }
}
