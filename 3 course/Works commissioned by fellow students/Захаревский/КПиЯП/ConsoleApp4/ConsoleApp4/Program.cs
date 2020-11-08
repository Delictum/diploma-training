using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        //Написать метод, вычисляющий значение sin(x) + cos(2 * x). С его помощью определить в какой из точек a, b или с значение будет минимальным.
        static double Method(double x)
        {
            return Math.Sin(x) + Math.Cos(2 * x);
        }

        //Описать функцию FactR(N) вещественного типа, позволяющую вычислять приближенное значение факториала 
        //N! = 1·2·...·N для целых N (> 0). С помощью этой функции вычислить факториалы пяти данных чисел. 
        static double FactR(double N)
        {
            int n = 1;
            for (int i = 1; i <= Math.Round(N); i++)
                n *= i;
            return Convert.ToDouble(n);
        }

        static void Main(string[] args)
        {
            Console.Write("Введите a: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Введите b: ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("Введите c: ");
            double c = double.Parse(Console.ReadLine());

            double A = Method(a);
            double B = Method(b);
            double C = Method(c);

            Console.WriteLine("Значаения A, B и C соответственно: {0}, {1} и {2}", A, B, C);

            if (A < B && A < C)
                Console.WriteLine("Минимальным будет 'a'.");
            if (B < A && B < C)
                Console.WriteLine("Минимальным будет 'b'.");
            if (C < A && C < B)
                Console.WriteLine("Минимальным будет 'c'.");

            for (int i = 0; i < 5; i++)
            {
                Console.Write("Введите число: ");
                double buf = double.Parse(Console.ReadLine());
                double temp = FactR(buf);
                Console.WriteLine("Факториал: " + temp);
            }
            Console.ReadKey();
        }
    }
}
