using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        /*Построить программу, которая позволяет пользователю вводить координаты точки (x, y) и определяет, 
         *попадает ли точка в заштрихованную область на рисунке. 
         *Попадание на границу области считать попаданием в область.
        */ 
        static void Main(string[] args)
        {
            Console.Write("Введите x: ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("Введите y: ");
            double y = double.Parse(Console.ReadLine());

            if (x >= -1 && x <= 1 && y >= 0 && y <= 1 || x >= 0 && x <= 1 && y >= -1 && y <= 0)
                Console.WriteLine("Попадание в область.");
        }
    }
}
