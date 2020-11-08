using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        /*
         * Описать функцию PowerA(x,a,eps) вещественного типа 
         * (параметры x, a, eps — вещественные, |x| < 1, a > 0, eps > 0), 
         * находящую приближенное значение функции 
         * (1+x)a: (1+x)a = 1 + a·x + a·(a–1)·x2 / 2! + ... + a·(a–1)·...·(a–n+1)·xn / n! + ... . 
         * В сумме учитывать все слагаемые, большие по модулю eps. 
         * С помощью PowerA найти приближенное значение (1+x)a для данных x и a при шести различных значениях eps. 
         */
        static double PowerA(double x, double a, double eps)
        {
            double n = 1, result = 0;
            for (int i = 1; i < 7; i++)
            {
                eps += 0.19;
                n *= i;
                if (Math.Abs(a) > eps && Math.Abs(x) > eps)
                    result = (a - i + 1) * x * i / n;
                else if (Math.Abs(a) > eps && Math.Abs(x) < eps)
                    result = (a - i + 1) * i / n;
                else if (Math.Abs(a) < eps && Math.Abs(x) > eps)
                    result = (- i + 1) * i / n;
                Console.WriteLine(result);
            }
            return (0);
        }

        static void Main(string[] args)
        {
            Console.Write("Введите x: ");
            back1: double x = double.Parse(Console.ReadLine());
            if (Math.Abs(x) >= 1)
                goto back1;
            Console.Write("Введите a: ");            
            back2: double a = double.Parse(Console.ReadLine());
            if (a <= 1)
                goto back2;
            double eps = 0.01;
            PowerA(x, a, eps);
        }
    }
}
