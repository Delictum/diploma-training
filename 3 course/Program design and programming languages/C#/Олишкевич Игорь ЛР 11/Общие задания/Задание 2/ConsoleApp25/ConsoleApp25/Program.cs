using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp25
{
    interface IComparable
    {
        int CompareTo(object T);
    }
    class DemoPoint : IComparable<DemoPoint>
    {
        protected int x;
        protected int y;
        public DemoPoint(int x, int y)
        {
            this.x = x; this.y = y;

        }
        public void Show()
        {
            Console.WriteLine("точка на плоскости: ({0}, {1})", x, y);
        }
        public double Dlina()
        {
            return Math.Sqrt(x * x + y * y);
        }
        //реализация метода CompareTo 
        public int CompareTo(DemoPoint obj)
        { 
          //определяем критерии сравнения текущего объекта с параметром в 
          // зависимости от удаленности точки от начала координат 
          if (this.Dlina() == obj.Dlina()) return 0;
          else if (this.Dlina() < obj.Dlina()) return 1;
          else return -1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DemoPoint[] a = new DemoPoint[4];
            a[0] = new DemoPoint(5, -1);
            a[1] = new DemoPoint(-3, 3);
            a[2] = new DemoPoint(3, 4);
            a[3] = new DemoPoint(0, 1);
            Console.WriteLine("Не отсортированный!");
            Console.WriteLine();
            foreach (DemoPoint x in a)
            {
                x.Show();
                Console.WriteLine("Dlina={0:f2} ", x.Dlina());
            }
            Array.Sort(a);
            Console.WriteLine();
            Console.WriteLine("Отсортированный по убыванию");
            Console.WriteLine();
            foreach (DemoPoint x in a)
            {
                x.Show();
                Console.WriteLine("Dlina={0:f2} ", x.Dlina());
            }

            Console.ReadLine();
        }
}
}
