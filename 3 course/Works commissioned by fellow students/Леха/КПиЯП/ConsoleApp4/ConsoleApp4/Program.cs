using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        //Написать метод, вычисляющий значение x2 + y2. С его помощью определить с какой парой чисел (a, b) или (с, d) значение будет максимальным. 
        static void MP(double x1, double y1, double x2, double y2)
        {
            double para1 = Math.Pow(x1, 2) + Math.Pow(y1, 2);
            double para2 = Math.Pow(x2, 2) + Math.Pow(y2, 2);
            if (para1 > para2)
                Console.WriteLine("Пара a и b больше.");
            else
                Console.WriteLine("Пара c и d больше.");
        }

        /* Proc7.Описать функцию Fact2(N) целого типа, 
         * вычисляющую значение "двойного факториала": 
         * N!! = 1·3·5·...·N, если N — нечетное, N!! = 2·4·6·...·N, 
         * если N — четное(N > 0 — параметр целого типа). 
         * С помощью этой функции вычислить двойные факториалы десяти данных чисел.
         */
         static int Fact2(int N)
        {
            int n = 1;
            if (N % 2 == 0)
                for (int i = 2; i <= N; i += 2)
                    n *= i;
            else
                for (int i = 1; i <= N; i += 2)
                    n *= i;
            return n;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1.");
            Console.WriteLine("Введите a, b, c и d: ");
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());
            double d = double.Parse(Console.ReadLine());
            MP(a, b, c, d);
            Console.WriteLine();

            Console.WriteLine("Задание 2.");
            Console.WriteLine("Введите 10 чисел: ");
            for (int i = 0; i < 10; i++)
            {
                int N = int.Parse(Console.ReadLine());
                int NewN = Fact2(N);
                Console.WriteLine("Факториал = " + NewN);
            }
        }
    }
}
