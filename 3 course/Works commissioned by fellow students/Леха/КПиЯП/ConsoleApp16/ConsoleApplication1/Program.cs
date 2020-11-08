using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class BD
    {
        public BD(int d, int m, int y)
        {
            this.d = d;
            this.m = m;
            this.y = y;
        }

        public virtual void BDW()
        {
            Console.WriteLine("Дата рождения:\n{0} {1} {2}", d, m, y);
        }

        public int D
        {
            get { return d; }
            set
            {
                if (value > 0)
                    d = value;
                else
                    d = 0;
            }
        }

        public int M
        {
            get { return m; }
            set
            {
                if (value > 0)
                    m = value;
                else
                    m = 0;
            }
        }

        public int Y
        {
            get { return y; }
            set
            {
                if (value > 0)
                    y = value;
                else
                    y = 0;
            }
        }

        int d, m, y;
    }

    public class FIO
    {
        public FIO(string f, string i, string o)
        {
            this.f = f;
            this.i = i;
            this.o = o;
        }

        public virtual void FIOW()
        {
            Console.WriteLine("ФИО:\n{0} {1} {2}", f, i, o);
        }

        public string F
        {
            get { return f; }
            set
            {
                if (value != null)
                    f = value;
                else
                    f = "";
            }
        }

        public string I
        {
            get { return i; }
            set
            {
                if (value != null)
                    i = value;
                else
                    i = "";
            }
        }

        public string O
        {
            get { return o; }
            set
            {
                if (value != null)
                    o = value;
                else
                    o = "";
            }
        }

        string f, i, o;
    }

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
            Console.WriteLine("Массив a:");
            for (int i = 0; i < a.Length; i++)
                Console.Write("{0} ", a[i]);
            Console.WriteLine();

            Console.WriteLine("Массив b:");
            for (int i = 0; i < b.Length; i++)
                Console.Write("{0} ", b[i]);
            Console.WriteLine();

            Console.WriteLine("Массив c:");
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
            List<BD> mas1 = new List<BD>();
            mas1.Add(new BD(0, 0, 0));
            foreach (BD x in mas1)
                x.BDW();

            List<FIO> mas2 = new List<FIO>();
            mas2.Add(new FIO("Колковский", "Алексей", "-"));
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
