using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        //Написать метод, который у чётных чисел меняет знак, а нечётные числа оставляет без изменения. 
        //С его помощью обработать ряд чисел от 1 до 10.
        static int Method(int x)
        {
            if (x % 2 == 0)
                x = -x;
            return x;
        }

        //Описать процедуру SumDigit(N,S), находящую сумму цифр S целого числа N (N — входной, S — выходной параметр). 
        //Используя эту процедуру, найти суммы цифр пяти данных чисел. 
        static int SumDigit(int N)
        {
            char[] c = N.ToString().ToCharArray();
            int S = 0;

            for (int i = 0; i < c.Length; i++)
            {
                S += int.Parse(c[i].ToString());
            }

            return S;
        }

        static void Main(string[] args)
        {
            for (int i = 1; i <= 10; i++)
                Console.Write(Method(i) + " ");
            Console.WriteLine();

            int[] N = new int[5];
            int S = 0;

            N = new int[] { 12345, 23456, 34567, 45678, 56789 };

            for (int i = 0; i < 5; i++)
            {
                S = SumDigit(N[i]);
                Console.Write("Число = {0}, ", N[i]);
                Console.WriteLine("Сумма цифр = {0}", S);
            }

            Console.ReadKey();
        }
    }
}
