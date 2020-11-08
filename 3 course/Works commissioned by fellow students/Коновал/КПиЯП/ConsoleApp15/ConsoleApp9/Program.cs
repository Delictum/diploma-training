using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace ConsoleApp9
{
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

