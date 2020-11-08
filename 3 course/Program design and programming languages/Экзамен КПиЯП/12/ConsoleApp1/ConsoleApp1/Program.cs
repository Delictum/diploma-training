using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class krug
    {
        public int r;
        public int x;
        public int y;

        public krug()
        {
            r = 5;
            x = 0;
            y = 0;
        }

        public void peremestit(int a, int b)
        {
            this.x += a;
            this.y += b;
        }

        public void razmer(int c)
        {
            this.r = c;
        }

        public void info()
        {
            Console.WriteLine("Координаты x и y: {0} и {1}. Размер: {2}", x, y, r);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            krug k = new krug();
            k.info();
            k.peremestit(1, -1);
            k.razmer(3);
            k.info();
        }
    }
}
