using System;
namespace Hello
{
    class Program
    {
        static double f(double x)
        {
            try
            {
                //если х не попадает в область определения, то генерируется исключение
            if (x == -1)
                    throw new DivideByZeroException();
            else
                return (4 * x + 4) / (Math.Sqrt(Math.Pow(x, 2) + 2 * x + 1));
            }
            catch (DivideByZeroException)
            {                
                Console.WriteLine("y({0}) = Деление на 0", x);
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
