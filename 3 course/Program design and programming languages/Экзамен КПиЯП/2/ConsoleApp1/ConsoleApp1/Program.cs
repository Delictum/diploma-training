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
            try
            {
                double x = double.Parse(Console.ReadLine());
                if (x < 0)
                    Console.WriteLine((Math.Pow(x + 1, 2)).ToString());
                else
                    Console.WriteLine((Math.Sin(3 * x)).ToString());

                if (x < 1)
                    Console.WriteLine((Math.Tan(2 * x)).ToString());
                else
                    Console.WriteLine((Math.Pow(2 * x + 10, 3)).ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.ReadKey();
        }
    }
}
