using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Vector
    {
        public double x;
        public double y;

        public Vector(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public Vector(double value, Vector direction)
        {
            double k = value / direction.Length;
            this.x = k * direction.x;
            this.y = k * direction.y;
        }

        public static Vector operator +(Vector v, int p)
        {
            return new Vector(v.x + p, v.y + p);
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.x - v2.x, v1.y - v2.y);
        }


        public static bool operator ==(Vector v1, Vector v2)
        {
            if (v1.x != v2.x && v1.y != v2.y)
                return true;
            else
                return false;
        }

        public static bool operator !=(Vector v1, Vector v2)
        {
            if (v1.x != v2.x && v1.y != v2.y)
                return true;
            else
                return false;
        }

        public static Vector operator *(double k, Vector v)
        {
            return new Vector(v.x * k, v.y * k);
        }

        public static Vector operator +(double k, Vector v)
        {
            return new Vector(v.x + k, v.y + k);
        }

        public double Length
        {
            get
            {
                return Math.Sqrt(x * x + y * y);
            }
        }

        public static Vector Zero
        {
            get { return new Vector(0, 0); }
        }

        public void print()
        {
            Console.WriteLine("X={0}, Y={1}", x, y);
        }
        public double test(Vector[] ass, int n)
        {
            return ass[n].x;
        }

        public int test(Vector[] ass, double n)
        {
            int foo = Convert.ToInt32(ass[(int)Math.Round(n)].y);
            return foo;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Vector v1 = new Vector(14, 3);
            Vector v2 = new Vector(11, 5);
            Vector[] nnn = new Vector[3];
            Random rand = new Random();
            for (int i = 0; i < 3; i++)
            {
                int x = rand.Next(10);
                int y = rand.Next(7);
                nnn[i] = new Vector(x, y);
                Console.WriteLine("x {0}, y {1} - i{2} ", nnn[i].x, nnn[i].y, i);
            }
            v1.print();
            v2.print();
            v1 -= v2;
            v1.print();
            v2 += 12;
            v2.print();
            if (v1 != v2)
                Console.WriteLine("!=");
            else
                Console.WriteLine("=");
            Console.WriteLine("Ответ {0}", v1.test(nnn, 2));
            Console.WriteLine("Ответ {0}", v2.test(nnn, 1.45));
            Console.ReadKey();            
        }
    }
}
