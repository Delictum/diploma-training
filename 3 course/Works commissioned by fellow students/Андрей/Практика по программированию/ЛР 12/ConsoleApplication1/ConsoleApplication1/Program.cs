using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1;

namespace ConsoleApp5
{ 
    public class Program
    {
        static void Main(string[] args)
        {
#line hidden
            Ship pp = new Ship();
            pp.print();
#pragma warning disable 168
            string name, color, appointment;
            int weight, year, crew;

            Console.WriteLine("Заполнение данных корабля:");
            Console.Write("Введите название: ");
            name = Console.ReadLine();
            Console.Write("Введите цвет: ");
            color = Console.ReadLine();
            Console.Write("Введите назначение: ");
            appointment = Console.ReadLine();
            Console.Write("Введите численность экипажа: ");
            crew = int.Parse(Console.ReadLine());
            Console.Write("Введите вес: ");
            weight = int.Parse(Console.ReadLine());
            Console.Write("Введите год выпуска: ");
            year = int.Parse(Console.ReadLine());
            Ship p_p = new Ship(name, color, appointment, crew, weight, year);
            Console.WriteLine();

            p_p.print();
            p_p.Color = color;
            p_p.Weight = weight;
            p_p.weight++;
            p_p.print();

            Console.ReadKey();
        }
    }
}
