using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL1;

namespace ConsoleApplication1
{
    public class Sorted
    {
        public Sorted(int[] a, double[] b, string[] c)
        {
            this.a = new int[a.GetLength(0)];
            this.a = a;
            this.b = new double[b.GetLength(0)];
            this.b = b;
            this.c = new string[c.GetLength(0)];
            this.c = c;
        }

        public virtual void SW()
        {
            CompareTo();
            Console.WriteLine("Массив a: {0}", a);
            for (int i = 0; i < a.Length; i++)
                Console.Write("{0} ", a[i]);
            Console.WriteLine();

            Console.WriteLine("Массив b: {0}", b);
            for (int i = 0; i < b.Length; i++)
                Console.Write("{0} ", b[i]);
            Console.WriteLine();

            Console.WriteLine("Массив c: {0}", c);
            for (int i = 0; i < c.Length; i++)
                Console.Write("{0} ", c[i]);
            Console.WriteLine();
        }

        private int CompareTo()
        {
            Array.Sort(a);
            Array.Sort(b);
            Array.Sort(c);
            return (0);
        }

        int[] a;
        double[] b;
        string[] c;
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Monster> mas = new List<Monster>();
            mas.Add(new Monster(2, 1, "Здельгас"));
            mas.Add(new Daemon(3, 5, "Гернун", 7));
            foreach (Monster x in mas)
                x.Passport();

            List<BD> mas1 = new List<BD>();
            mas1.Add(new BD(28, 10, 1997));
            foreach (BD x in mas1)
                x.BDW();

            List<FIO> mas2 = new List<FIO>();
            mas2.Add(new FIO("Олишкевич", "Игорь", "Русланович"));
            foreach (FIO x in mas2)
                x.FIOW();

            int[] a = { 1, 6, 4, 2, 7, 5, 3 };
            double[] b = { 1.1, 6.6, 4.4, 2.4, 7.6, 5.5, 3.3 };
            string[] c =  { "sdef", "sd", "sdfsd", "sdf" };

            List<Sorted> mas3 = new List<Sorted>();
            mas3.Add(new Sorted(a, b, c));
            foreach (Sorted x in mas3)
                x.SW();
        }
    }
}
