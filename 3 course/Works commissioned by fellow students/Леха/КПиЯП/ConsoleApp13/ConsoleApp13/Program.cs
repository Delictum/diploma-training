﻿using System;
namespace Hello
{
    class Program
    {
        static double f(double x)
        {
            try
            {
                //если х не попадает в область определения, то генерируется исключение
            if (x < 0.5)
                    throw new Exception();
                else if (x == 0.5)
                    throw new DivideByZeroException();
            else
                return x / (Math.Sqrt(2 * x - 1));
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("y = Деление на 0");
                return (0);
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
                        Console.WriteLine("y({0})={1:f4}", i, f(i));
                    }
                    catch
                    {
                        Console.WriteLine("y({0})=error", i);
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
