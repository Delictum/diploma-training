using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    class Program
    {
        /* Поменяйте местами последние и первые строки массива. 
         * Используйте подпрограммы для решения каждой частной задачи.
         */
        static int InMas(int[,] a, int n)
        {
            Random rand = new Random();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    a[i, j] = rand.Next(-9, 10);
            return (0);
        }

        static void OutMas(int[,] a, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write("{0} ", a[i, j]);
                Console.WriteLine();
            }

        }

        static int ReverseMas(int [,] a, int n)
        {
            int l = n - 1, k = 0;
            for (int i = 0; i < n / 2; i++)
            {
                k = 0;
                for (int j = 0; j < n; j++)
                {
                    int buf = a[i, j];
                    a[i, j] = a[l, k];
                    a[l, k] = buf;
                    k++;
                }
                l--;
            }

            return (0);
        }

        static void Main(string[] args)
        {
            int n = 4;
            int[,] mas = new int[n, n];
            InMas(mas, n);
            Console.WriteLine("Исходный массив: ");
            OutMas(mas, n);
            ReverseMas(mas, n);
            Console.WriteLine("Полученный массив: ");
            OutMas(mas, n);
        }
    }
}
