using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        /*Вычислить и вывести на экран в виде таблицы значения функции F 
          на интервале Xнач до Xкон с шагом dX. 
          Описание функции оформить в виде пользовательской функции. 
          При решении использовать циклы.
          Значения a, b, c , Xнач , Xкон , dX вводятся с клавиатуры.  
                {a * Math.Pow(x, 2) - при x < 0 и b != 0 
            F = {(x - a) / (x - c) - при x > 0 и b = 0
                {x / c - в остальных случаях
          Предусмотреть исключительные ситуации.
        */
        static void F(int Xs, int Xe, int dX, double a, double b, double c)
        {
            if (Xs < Xe)
            {
                for (int x = Xs; x < Xe; x += dX)
                {
                    if (x < 0 && b != 0)
                    {
                        Console.WriteLine("| {0:00.00} | {1:00} |", a * Math.Pow(x, 2), x);
                        continue;
                    }

                    if (x > 0 && b == 0)
                    {
                        if (x - c != 0)
                            Console.WriteLine("|  {0:00.00}  |   {1:00}   |", (x - a) / (x - c), x);
                        else
                            Console.WriteLine("|   -   | {0:00} |", x);
                        continue;
                    }

                    Console.WriteLine("|  {0:00.00}  |   {1:00}   |", x / c, x);
                }
            }
            else
            {
                for (int x = Xs; x > Xe; x -= dX)
                {
                    if (x < 0 && b != 0)
                    {
                        Console.WriteLine("| {0:00.00} | {1:00} |", a * Math.Pow(x, 2), x);
                        continue;
                    }

                    if (x > 0 && b == 0)
                    {
                        if (x - c != 0)
                            Console.WriteLine("|  {0:00.00}  |   {1:00}   |", (x - a) / (x - c), x);
                        else
                            Console.WriteLine("|   -   | {0:00} |", x);
                        continue;
                    }

                    Console.WriteLine("|  {0:00.00}  |   {1:00}   |", x / c, x);
                }
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Введите Xs: ");
            int Xs = int.Parse(Console.ReadLine());
            Console.Write("Введите Xe: ");
            int Xe = int.Parse(Console.ReadLine());
            Console.Write("Введите шаг dX: ");
            int dX = int.Parse(Console.ReadLine());

            Console.Write("Введите a: ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("Введите b: ");
            double b = double.Parse(Console.ReadLine());
            BackC: Console.Write("Введите c не равное нулю: ");
            double c = double.Parse(Console.ReadLine());

            if (c == 0)
                goto BackC;

            Console.WriteLine("____________________");
            Console.WriteLine("|    F    |    X   |");
            Console.WriteLine("____________________");
            F(Xs, Xe, dX, a, b, c);
            Console.WriteLine("____________________");
            Console.ReadKey();
        }
    }
}
