using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int[] mas = new int[10];
            int min = 10, max = -10, mi = 0, ma = 0;
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                mas[i] = rand.Next(-9, 10);
                if (mas[i] < min)
                {
                    mi = i;
                    min = mas[i];
                }
                if (mas[i] > max)
                {
                    ma = i;
                    max = mas[i];
                }
            }
            int temp = 1;
            for (int i = a; i <= b; i++)
                temp *= mas[i];
            Console.WriteLine(temp);
            temp = 1;
            if (mi < ma)
                for (int i = mi; i <= ma; i++)
                    temp *= mas[i];
            else
                for (int i = ma; i <= mi; i++)
                    temp *= mas[i];
            Console.WriteLine(temp);
            int[] mass = new int[10];
            mass = mas.Reverse().ToArray();
            Console.WriteLine(mass);
        }
    }
}
