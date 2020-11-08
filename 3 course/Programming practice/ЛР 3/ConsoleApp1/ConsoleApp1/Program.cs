using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static double Func(double x, int count)
        {
            return Math.Pow(x - 1, count) / (count * Math.Pow(x, count));
        }

        static void Main(string[] args)
        {
            /*
             Вычислить и вывести на экран значение функции f(x) на отрезке [a, b] c шагом h = 0.1 с точностью e.
             Результат работы программы представить в виде следующей таблицы:
             №	Значение x	Значение функции F(x). Количество просуммированных слагаемых n		
             Замечание. При решении задачи использовать вспомогательную функцию.
             */
            int count = 1, number = 1;
            double F = 0, F1 = 0, F2 = 0;
            Console.WriteLine("Введите значения a и b: ");
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            Console.Write("Введите точность вычислений e в степени -...: ");
            double e = double.Parse(Console.ReadLine());
            Console.WriteLine("e = " + 1 / Math.Pow(10, e));
            Console.WriteLine("_______________________________________________________________________________");
            Console.WriteLine("| № |\tЗначение x|Значение функции F(x)|Кол-во просуммированных слагаемых n |");
            Console.WriteLine("_______________________________________________________________________________");
            for (double i = a; i < b; i += 0.1)
            {                   
                F1 = Func(i, count); //Текущее F
                F = F2 - F1; //Разность предыдущего F с новым
                F2 = F1; //Предыдущее F
                if (count == 1)
                {
                    Console.WriteLine("| {0:00}\t|\t{1:0.0}\t|\t{2:0.000000000}\t|\t{3:00}\t|", number, i, F1, count);
                    number++;
                }
                count++;
                if (count > 2 && Math.Abs(F) > Math.Pow(1, -10 * e))
                {
                    Console.WriteLine("| {0:00}\t|\t{1:0.0}\t|\t{2:0.000000000}\t|\t{3:00}\t|", number, i, F1, count);
                    number++;
                }
            }
            Console.WriteLine("_______________________________________________________________________________");
            Console.ReadKey();
        }
    }
}
