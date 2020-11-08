using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Mat
    {
        public double a;
        public double b;
        public double c;
        public double x;
        public double d;
        public double x1;
        public double x2;

        public Mat(double a, double b, double c, double x, double d, double x1, double x2)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.x = x;
        }

        public double IniD()
        {
            double x1;
            d = Math.Pow(b, 2) - 4 * a * c;
            if (d > 0)
            {
                IniX1();
                IniX2();
            }
            return (0);
        }

        private double IniX1()
        {
            return x1 = (-b + d) / (2 * a);
        }

        private double IniX2()
        {
            return x1 = (-b - d) / (2 * a);
        }

        public void Vyv()
        {
            Console.WriteLine("Дискриминант: " + d);
            if (d > 0)
            {
                Console.WriteLine("Корень x1: " + x1);
                Console.WriteLine("Корень x2: " + x2);
            }
            else
                Console.WriteLine("Действительных корней нет");

            Console.WriteLine();
        }        
    }

    //Заданы три квадратных уравнения АХ2 + BX + С = 0; DX2 + FX + E = 0 и ZX2 + YX + S = 0. 
    //Написать программу нахождения максимального значения корня среди действительных корней этих уравнений.
    class Program
    {
        static void Main(string[] args)
        {
            double X = 3;
            double A = 1, D = 2, Z = -2;
            double B = 5, F = 4, Y = 3;
            double C = 2, E = 3, S = 4;            

            Mat m1 = new Mat(A, B, C, X, 0, 0, 0);
            Mat m2 = new Mat(D, F, E, X, 0, 0, 0);
            Mat m3 = new Mat(Z, Y, S, X, 0, 0, 0);

            m1.IniD();
            m1.Vyv();

            m2.IniD();
            m2.Vyv();

            m3.IniD();
            m3.Vyv();

            if (m3.d > 0)
            {
                if (m3.x1 > m3.x2 && m3.x1 > m2.x1 && m3.x1 > m2.x2 && m3.x1 > m1.x2 && m3.x1 > m1.x1)
                    Console.WriteLine("Наибольший корень: {0}", m3.x1);
                if (m3.x2 > m3.x1 && m3.x1 > m2.x1 && m3.x1 > m2.x2 && m3.x1 > m1.x2 && m3.x1 > m1.x1)
                    Console.WriteLine("Наибольший корень: {0}", m3.x1);
            }
            if (m2.d > 0)
            {
                if (m2.x1 > m3.x2 && m2.x1 > m3.x1 && m2.x1 > m2.x2 && m2.x1 > m1.x2 && m2.x1 > m1.x1)
                    Console.WriteLine("Наибольший корень: {0}", m2.x1);
                if (m2.x2 > m3.x2 && m2.x2 > m3.x1 && m2.x2 > m2.x1 && m2.x2 > m1.x2 && m2.x2 > m1.x1)
                    Console.WriteLine("Наибольший корень: {0}", m2.x1);
            }
            if (m1.d > 0)
            {
                if (m1.x1 > m3.x2 && m1.x1 > m3.x1 && m1.x1 > m2.x2 && m1.x1 > m2.x1 && m1.x1 > m1.x2)
                    Console.WriteLine("Наибольший корень: {0}", m1.x1);
                if (m1.x2 > m3.x2 && m1.x2 > m3.x1 && m1.x2 > m2.x1 && m1.x2 > m2.x2 && m1.x2 > m1.x1)
                    Console.WriteLine("Наибольший корень: {0}", m1.x1);
            }
        }
    }
}
