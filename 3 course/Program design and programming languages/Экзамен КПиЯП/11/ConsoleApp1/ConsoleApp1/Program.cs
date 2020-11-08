using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static public int[,] vvod(int[,] mas)
        {
            Random rand = new Random();
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    mas[i, j] = rand.Next(10);
                }
            return mas;
        }

        static public void vivod(int[,] mas)
        {
            Random rand = new Random();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                    Console.Write(mas[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static public int[,] rev(int[,] mas)
        {
            int[] temp = new int[5];
            for (int i = 0; i < 5; i++)
            {
                temp[i] = mas[0, i];
                mas[0, i] = mas[4, i];
                mas[4, i] = temp[i];
            }                
            return mas;
        }

        static void Main(string[] args)
        {
            int[,] mas = new int[5, 5];
            vvod(mas);
            vivod(mas);
            rev(mas);
            vivod(mas);
        }
    }
}
