using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp39
{
    class Trungle
    {
        double[] xABCD, yABCD;   
        int n;
        double AB, BC, CA, BD, DA, AC, CD, ABC, ABD, ACD;

        public Trungle(int n)
        {
            this.xABCD = new double[n];
            this.yABCD = new double[n];
            this.n = n;
        }

        public double TrIn()
        {
            Console.WriteLine("Задайте координаты точек A, B, C и D по x: ");
            for (int i = 0; i < 4; i++)
                xABCD[i] = double.Parse(Console.ReadLine());
            Console.WriteLine("Задайте координаты точек A, B, C и D по y: ");
            for (int i = 0; i < 4; i++)
                yABCD[i] = double.Parse(Console.ReadLine());
            return (0);
        }

        public double TrOut()
        {
            Console.Write("Вершины AB, BC, CA: {0}, {1} и {2}. Периметр треугольника ABC: {3}", AB, BC, CA, ABC);
            Console.WriteLine();
            Console.Write("Вершины AB, BC, CA: {0}, {1} и {2}. Периметр треугольника ABD: {3}", AB, BD, DA, ABD);
            Console.WriteLine();
            Console.Write("Вершины AB, BC, CA: {0}, {1} и {2}. Периметр треугольника ACD: {3}", AC, CD, DA, ACD);
            Console.WriteLine();
            return (0);
        }

        private double Vershina(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt((Math.Pow((x1 - x2), 2)) + (Math.Pow((y1 - y2), 2)));
        }

        private double Perimetr(double AB, double BC, double CA)
        {
            return AB + BC + CA;
        }

        public double Strata()
        {
            AB = Vershina(xABCD[0], yABCD[0], xABCD[1], yABCD[1]);
            BC = Vershina(xABCD[1], yABCD[1], xABCD[2], yABCD[2]);
            CA = Vershina(xABCD[2], yABCD[2], xABCD[0], yABCD[0]);
            BD = Vershina(xABCD[1], yABCD[1], xABCD[3], yABCD[3]);
            DA = Vershina(xABCD[3], yABCD[3], xABCD[0], yABCD[0]);
            CD = Vershina(xABCD[2], yABCD[2], xABCD[3], yABCD[3]);
            ABC = Perimetr(AB, BC, CA);
            ABD = Perimetr(AB, BD, DA);
            ACD = Perimetr(AC, CD, DA);
            return (0);
        }
    }

    public class Program
    {
        //Заданы координаты четырёх точек A, B, C, D на плоскости. 
        //Определить наибольший из периметров треугольников ABC, ABD, ACD.                  
        static void Main(string[] args)
        {
            Trungle tr = new Trungle(5);            
            tr.TrIn();
            tr.Strata();
            tr.TrOut();           
            Console.ReadKey();
        }
    }
}
