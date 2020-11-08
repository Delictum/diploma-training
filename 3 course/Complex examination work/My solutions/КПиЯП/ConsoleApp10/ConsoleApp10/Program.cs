using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    class Program
    {
        /* Переверните в массиве каждую третью строку; 
         * Используйте подпрограммы для решения каждой частной задачи.
         */
         
        static int InMas(int[,] a, int n)
        {
            Random rand = new Random();
            
            for (int i = 0; i < n; i++)            
                for (int j = 0; j < n; j++)                
                    a[i, j] = rand.Next(10);              
            
            return (0);
        }

        static void OutMas(int[,] a, int n)
        {            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("{0} ", a[i, j]);
                }
                Console.WriteLine();
            }
        }

        static int ReversMas(int[,] a, int n)
        {
            for (int i = 0; i < n; i++)
                if ((i + 1) % 3 == 0)
                {
                    int k = n - 1;
                    for (int j = 0; j < n / 2; j++)
                    {
                        int buf = a[i, j];
                        a[i, j] = a[i, k];
                        a[i, k] = buf;
                        k--;
                    }
                }
            
            return (0);
        }
            

        static void Main(string[] args)
        {
            int n = 6;
            int[,] mas = new int[n, n];

            InMas(mas, n);
            Console.WriteLine("Исходный массив: ");
            OutMas(mas, n);
            ReversMas(mas, n);
            Console.WriteLine("Полученный массив: ");
            OutMas(mas, n);

            Console.ReadKey();
        }
    }
}
