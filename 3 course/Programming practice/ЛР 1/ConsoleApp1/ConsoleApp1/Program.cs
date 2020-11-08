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
            /* 
            Дан угол в радианах. Написать программу, переводящую его в градусы, минуты и секунды 
            (градусы и минуты — целые числа). Ответ вывести в виде: «Угол a рад равен d° m′ s′′». 
            Вместо буквенных обозначений должны стоять конкретные числа с точностью до 2-го знака после запятой. 
            Перед запросом ввода с клавиатуры выводить подсказку. (Код символа градуса в Unicode — 00B0.) 
            */
            Console.Write("Введите угол a в радианах. Для ввода можно использовать число pi (значения вводятся без пробелов, pi - если есть - указывается как 'p' латинское; пример ввода - p*3; 4,35/p; 25): ");
            back1: string UgolRad = Console.ReadLine();
            double MathUgolRad = 0, Seconds = 0;
            int UgolGrad = 0, Minutes = 0;

            if (UgolRad.Length > 0)
            {               
                //Нахождение pi
                if (UgolRad.IndexOf("p") > -1)
                {
                    if (UgolRad.Length > 1 && UgolRad.IndexOf("p") == 0)
                    {
                        if (UgolRad.Substring(1, 1) == "*")
                            MathUgolRad = Math.PI * Convert.ToDouble(UgolRad.Substring(2, UgolRad.Length - 2));
                        else if (UgolRad.Substring(1, 1) == "/")
                            MathUgolRad = Math.PI / Convert.ToDouble(UgolRad.Substring(2, UgolRad.Length - 2));
                        else if (UgolRad.Substring(1, 1) == "+")
                            MathUgolRad = Math.PI + Convert.ToDouble(UgolRad.Substring(2, UgolRad.Length - 2));
                        else if (UgolRad.Substring(1, 1) == "-")
                            MathUgolRad = Math.PI - Convert.ToDouble(UgolRad.Substring(2, UgolRad.Length - 2));
                    }
                    else if (UgolRad == "-p")
                        MathUgolRad = -Math.PI;
                    else if (UgolRad.Length > 1 && UgolRad.IndexOf("p") == 1)
                    {
                        if (UgolRad.Substring(2, 1) == "*")
                            MathUgolRad = -Math.PI * Convert.ToDouble(UgolRad.Substring(3, UgolRad.Length - 3));
                        else if (UgolRad.Substring(2, 1) == "/")
                            MathUgolRad = -Math.PI / Convert.ToDouble(UgolRad.Substring(3, UgolRad.Length - 3));
                        else if (UgolRad.Substring(2, 1) == "+")
                            MathUgolRad = -Math.PI + Convert.ToDouble(UgolRad.Substring(3, UgolRad.Length - 3));
                        else if (UgolRad.Substring(2, 1) == "-")
                            MathUgolRad = -Math.PI - Convert.ToDouble(UgolRad.Substring(3, UgolRad.Length - 3));
                    }
                    else if (UgolRad.Length > 1 && UgolRad.IndexOf("p") == UgolRad.Length - 1)
                    {
                        if (UgolRad.Substring(UgolRad.Length - 2, 1) == "*")
                            MathUgolRad = Math.PI * Convert.ToDouble(UgolRad.Substring(0, UgolRad.Length - 2));
                        else if (UgolRad.Substring(UgolRad.Length - 2, 1) == "/")
                            MathUgolRad = Convert.ToDouble(UgolRad.Substring(0, UgolRad.Length - 2)) / Math.PI;
                        else if (UgolRad.Substring(UgolRad.Length - 2, 1) == "+")
                            MathUgolRad = Convert.ToDouble(UgolRad.Substring(0, UgolRad.Length - 2)) + Math.PI;
                        else if (UgolRad.Substring(UgolRad.Length - 2, 1) == "-")
                            MathUgolRad = Convert.ToDouble(UgolRad.Substring(0, UgolRad.Length - 2)) - Math.PI;
                    }
                    else if (UgolRad.Length > 1 && UgolRad.IndexOf("p") == UgolRad.Length - 2)
                    {
                        if (UgolRad.Substring(UgolRad.Length - 3, 1) == "*")
                            MathUgolRad = Convert.ToDouble(UgolRad.Substring(0, UgolRad.Length - 4)) * -Math.PI;
                        else if (UgolRad.Substring(UgolRad.Length - 3, 1) == "/")
                            MathUgolRad = Convert.ToDouble(UgolRad.Substring(0, UgolRad.Length - 4)) / -Math.PI;
                        else if (UgolRad.Substring(UgolRad.Length - 3, 1) == "+")
                            MathUgolRad = Convert.ToDouble(UgolRad.Substring(0, UgolRad.Length - 4)) + -Math.PI;
                        else if (UgolRad.Substring(UgolRad.Length - 3, 1) == "-")
                            MathUgolRad = Convert.ToDouble(UgolRad.Substring(0, UgolRad.Length - 4)) - -Math.PI;
                    }                   
                    else
                        MathUgolRad = Math.PI;
                }
                else
                    MathUgolRad = Convert.ToDouble(UgolRad);
            }
            else
            {
                Console.WriteLine("Повторите ввод.");
                goto back1;
            }

            //Вычисления в градусах, минутах и секундах
            UgolGrad = Convert.ToInt32(MathUgolRad * (180 / Math.PI));
            Minutes = Convert.ToInt32(Math.Round(Math.Abs(MathUgolRad * (180 / Math.PI) - UgolGrad) * 60));
            Seconds = Math.Abs((MathUgolRad * (180 / Math.PI) - UgolGrad) * 3600 - Minutes * 60);
            Console.WriteLine("Угол a рад равен {0:0}°, {1:0} мин, {2:0.00} с", UgolGrad, Minutes, Seconds);
            Console.ReadKey();

        }
    }
}
