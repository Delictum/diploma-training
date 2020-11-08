using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("x=");
            float x = float.Parse(Console.ReadLine());
            Console.Write("y=");
            float y = float.Parse(Console.ReadLine());
            if (Math.Pow(x, 2) + Math.Pow(y, 2) == 25 | Math.Pow(x, 2) + Math.Pow(y, 2) == 100) //задаём границы -5 до -10
                Console.WriteLine("На границе");
            else if (Math.Pow(x, 2) + Math.Pow(y, 2) > 25 && Math.Pow(x, 2) + Math.Pow(y, 2) < 100) // границы положительной стороны 5-10
                Console.WriteLine("Да");
            else Console.WriteLine("Нет");

            Console.ReadKey();
        }
    }
}
