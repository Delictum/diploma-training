using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, b, c;

            Console.WriteLine("Введите a: ");
            a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите b: ");
            b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите c: ");
            c = Convert.ToDouble(Console.ReadLine());

            double D = b * b - 4 * a * c;
            if (D > 0)
            {
                D = Math.Sqrt(D);
                double k1 = (-b + D) / 2 * a;
                double k2 = (-b - D) / 2 * a;
                Console.WriteLine("(D = {0}) Первый корень {1}, второй корень {2}", D, k1, k2);
            }
            else if (D == 0)
            {
                double k1 = -b / 2 * a;
                Console.WriteLine("(D = {0}) Корень уравнения {1}", D, k1);
            }
            else
            {
                Console.WriteLine("кореней нет (D = {0})", D);
            }
        }
    }
}
