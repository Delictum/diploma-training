using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Program
    {
        /* Составить программу вывода всех трёхзначных чисел, 
         * сумма цифр которых равна данному целому числу. 
         * Программа должна печатать именно числа, а не набор цифр.
         */
        static void Main(string[] args)
        {
            Console.Write("Введите n: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i < 10; i++)
                for (int j = 1; j < 10; j++)
                    for (int k = 1; k < 10; k++)
                        if (i + j + k == n)
                            Console.WriteLine(i * 100 + j * 10 + k);
        }
    }
}
