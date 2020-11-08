using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    class Program
    {
        /* Заполните одномерный массив положительными элементами, 
         * расположенные на главной диагонали заданного квадратного массива. 
         * Выведите полученный массив на экран и найдите произведение элементов. 
         * Используйте подпрограммы для решения каждой частной задачи.
         */
        static int InMasBox(int[,] a, int n)
        {
            Random rand = new Random();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    a[i, j] = rand.Next(-9, 10);
            return (0);
        }

        static void OutMasBox(int[,] a, int n)
        {
            Console.WriteLine("Квадратная матрица");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)                
                    Console.Write("{0} ", a[i, j]);
                Console.WriteLine();
            }
        }

        static int InMas(int[,] a, int[] b, int n)
        {
            int l = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    if (i == j && a[i, j] > 0)
                    {
                        b[l] = a[i, j];
                        l++;
                    }
            return (0);
        }

        static void OutMas(int[] a, int n)
        {
            Console.WriteLine("Одномерный массив");
            for (int i = 0; i < n; i++)
                if (a[i] > 0)
                    Console.Write("{0} ", a[i]);
                else
                    break;
            Console.WriteLine();
        }

        public static int ProMas(int[] a, int n)
        {
            int pro = 1;
            for (int i = 0; i < n; i++)
                if (a[i] > 0)
                    pro *= a[i];
                else
                    break;
            return pro;
        }

        static void Main(string[] args)
        {
            int n = 5, pro = 1;
            int[,] MasBox = new int[n, n];
            int[] Mas = new int[n];

            InMasBox(MasBox, n);
            OutMasBox(MasBox, n);
            InMas(MasBox, Mas, n);
            OutMas(Mas, n);            
            Console.WriteLine("Произведение элементов: {0}", ProMas(Mas, n));
            Console.ReadKey();
        }
    }
}
