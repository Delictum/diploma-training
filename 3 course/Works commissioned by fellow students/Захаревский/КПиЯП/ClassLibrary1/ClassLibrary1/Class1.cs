using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class matr
    {
        public void Sozm(int[,] arr)
        {
            Random rand = new Random();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = rand.Next(10, 100);
                }
            }
        }

        public void Print(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public void SemM(int[,] arr)
        {
            int k = 0;
            int sum = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] == arr[j, i])
                    {
                        k++;
                    }
                }
            }

            if (k == arr.GetLength(0))
            {
                Console.WriteLine("\nМатрица является симметричной!\n");
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        if (j > i) sum += arr[j, i];
                        Console.Write(arr[j, i] + "\t");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("\nСумма элементов выше главной диагонали: {0}", sum);
            }
            else Console.WriteLine("\nНе симметричная матрица!");
        }
    }
}
