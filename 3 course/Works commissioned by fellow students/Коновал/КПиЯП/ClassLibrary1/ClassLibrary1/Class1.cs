using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Mat
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
}
