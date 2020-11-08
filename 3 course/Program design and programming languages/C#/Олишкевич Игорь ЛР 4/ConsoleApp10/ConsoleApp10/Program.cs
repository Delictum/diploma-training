using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    class Program
    {
        static void Method1(double a)
        {
            double x = Math.Pow(Math.Sin(a), 2);
            double y = Math.Pow(Math.Cos(a), 2);
            Console.WriteLine("Значение x = {0}, y = {1}", x, y);
            double pi = 3.14, piStep = -pi;
            while (piStep <= pi)
            {
                Console.Write("{0} ", piStep);
                for (int i = 0; i < 3; i++)
                {
                    piStep = piStep + pi / 4;
                    if (piStep <= pi + pi / 4)
                        Console.Write("{0} ", piStep);
                }                    
                Console.WriteLine();
            }
        }

        static int NOD2(int A, int B)
        {
            int NOD;
            while (A != B)
            {
                if (A > B)
                    A = A - B;
                else
                    B = B - A;
            }
            NOD = A;            
            return NOD;
        }

        static void Frac(int a, int b)
        {            
            int p, q;            
            p = Math.Abs(a) / NOD2(Math.Abs(a), Math.Abs(b));
            q = Math.Abs(b) / NOD2(Math.Abs(a), Math.Abs(b));
            if (a * b < 0)
                p = -p;
            Console.WriteLine("{0}/{1}", p, q);
        }

        static void Main(string[] args)
        {
            /*
            Задание 1.
            Написать метод, который вычисляет значения x=sin2(a) и y=cos2(a). 
            Напечатать таблицу значений от –π до π с шагом π/4.
            */
            Console.WriteLine("Задание 1.");
            Console.Write("Введите a: ");
            double a1 = double.Parse(Console.ReadLine());
            Method1(a1);

            /*
            Задание 2.
            Используя функцию NOD2 из задания Proc10, описать процедуру Frac(a,b,p,q), 
            преобразующую дробь a/b к несократимому виду p/q (все параметры процедуры — целого типа). 
            Знак результирующей дроби p/q приписывается числителю (т.е. q > 0). 
            С помощью этой процедуры найти несократимые дроби, равные a/b + c/d, a/b + e/f, a/b + g/h (числа a, b, c, d, e, f, g, h даны). 

            NOD2 из задания Proc 10 - Описать нерекурсивную функцию NOD2(A,B) целого типа, 
            находящую наибольший общий делитель (НОД) двух натуральных чисел A и B, 
            используя алгоритм Евклида: НОД(A,B) = НОД(B mod A,A), если A <> 0; НОД(0,B) = B. 
            */
            Console.WriteLine("Задание 2.");
            Console.Write("Введите a: ");
            int a2 = Int32.Parse(Console.ReadLine());
            Console.Write("Введите b: ");
            int b2 = Int32.Parse(Console.ReadLine());
            Console.Write("Введите c: ");
            int c2 = Int32.Parse(Console.ReadLine());
            Console.Write("Введите d: ");
            int d2 = Int32.Parse(Console.ReadLine());
            Console.Write("Введите e: ");
            int e2 = Int32.Parse(Console.ReadLine());
            Console.Write("Введите f: ");
            int f2 = Int32.Parse(Console.ReadLine());
            Console.Write("Введите g: ");
            int g2 = Int32.Parse(Console.ReadLine());
            Console.Write("Введите h: ");
            int h2 = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Результат: ");
            Console.Write("{0}/{1} + {2}/{3} = ", a2, b2, c2, d2);
            Frac(a2 * d2 + b2 * c2, b2 * d2);
            Console.Write("{0}/{1} + {2}/{3} = ", a2, b2, e2, f2);
            Frac(a2 * f2 + b2 * e2, b2 * f2);
            Console.Write("{0}/{1} + {2}/{3} = ", a2, b2, g2, h2);
            Frac(a2 * h2 + b2 * g2, b2 * h2);
        }
    }
}
