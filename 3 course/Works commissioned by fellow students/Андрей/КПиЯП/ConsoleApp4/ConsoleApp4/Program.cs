using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        //Написать метод max(x, y), находящий максимальное значение из двух чисел. С его помощью найти максимальное значение из четырёх чисел a, b, c, d.
        static int max(int x, int y)
        {
            if (x > y)
            {
                Console.WriteLine(x);
                return (x);
            }
            else
            {
                Console.WriteLine(y);
                return (y);
            }
        }
        //Описать процедуру Minmax(A,B), 
        //записывающую в переменную A минимальное из значений A и B, а в переменную B — максимальное из этих значений 
        //(A и B — вещественные параметры, являющиеся одновременно входными и выходными). 
        //Используя четыре вызова этой процедуры, найти минимальное и максимальное из ·исел A, B, C, D. 

        static void Minmax(double A, double B)
        {
            if (B < A)
            {
                double buf = B;
                B = A;
                A = buf;
            }
            Console.WriteLine("Min: {0}, max: {1}", A, B);
        }

        static void Main(string[] args)
        {
            Console.Write("Введите a: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Введите b: ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("Введите c: ");
            int c = int.Parse(Console.ReadLine());
            Console.Write("Введите d: ");
            int d = int.Parse(Console.ReadLine());
            int max1 = max(a, b);
            int max2 = max(c, d);
            Console.WriteLine("Максимальное из 4 чисел: ");
            max(max1, max2);

            Console.Write("Введите A: ");
            int A = int.Parse(Console.ReadLine());
            Console.Write("Введите B: ");
            int B = int.Parse(Console.ReadLine());
            Console.Write("Введите C: ");
            int C = int.Parse(Console.ReadLine());
            Console.Write("Введите D: ");
            int D = int.Parse(Console.ReadLine());
            Minmax(A, B);
            Minmax(A, C);
            Minmax(A, D);
            Minmax(B, C);
            Minmax(B, D);
            Minmax(C, D);
        }
    }
}
