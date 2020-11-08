using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            int min = 32767;
            Console.Write("Введите N: ");
            int N = int.Parse(Console.ReadLine());
            int i = 0;
            
            back: if (i < N)
            {
                int a = rand.Next(100);
                Console.WriteLine("a = {0}", a);

                if (a % 2 == 1 && min > a)
                    min = a;
                i++;
                goto back;
            }
            else
                Console.WriteLine("min = {0}", min);
            Console.ReadKey();
        }
    }
}
