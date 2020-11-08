﻿using System;
namespace Hello
{
    class Program
    {
        static double f(double x)
        {
            try
            {
                if (x < -1 || x > 1)
                    throw new Exception();
                else
                    return Math.Log10(1 - Math.Pow(x, 2));
            }
            catch
            {
                throw;
            }
        }

        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите a: ");
                double a = double.Parse(Console.ReadLine());
                Console.Write("Введите b: ");
                double b = double.Parse(Console.ReadLine());
                Console.Write("Введите h: ");
                double h = double.Parse(Console.ReadLine());
                for (double i = a; i <= b; i += h)
                    try
                    {
                        Console.WriteLine("y({0}) = {1:f4}", i, f(i));
                    }
                    catch
                    {
                        Console.WriteLine("y({0}) = error", i);
                    }
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверный формат ввода данных");
            }            
            catch
            {
                Console.WriteLine("Неизвестная ошибка");
            }
            Console.ReadKey();
        }
    }
}
