using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    /* Заданы три вектора X, Y, Z. 
     * Написать программу вычисления S(от 1 до n) = C * D 
     * соответственно равны С = X + У; D = X - Z
     */
    class Garic
    {
        public double X;
        public double Y;
        public double Z;
        public int n;

        public Garic(double X, double Y, double Z, int n)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
            this.n = n;
        }

        public double C()
        {
            return X + Y;
        }

        public double D()
        {
            return X - Z;
        }

        public double arifmetic()
        {
            double S = 0;
            for (int i = 1; i < n; i++)
                S += C() * D();
            return S;
        }
    }

        class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите X: ");
            double X = double.Parse(Console.ReadLine());
            Console.Write("Введите Y: ");
            double Y = double.Parse(Console.ReadLine());
            Console.Write("Введите Z: ");
            double Z = double.Parse(Console.ReadLine());
            Console.Write("Введите n: ");
            int n = int.Parse(Console.ReadLine());

            Garic g = new Garic(X, Y, Z, n);
            Console.WriteLine(g.arifmetic());
            Console.ReadKey();
        }
    }
}
