using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp24
{
    //определение интерфейса
    interface IDemo
    {
        void Show(); //объявление метода 
        double Dlina(); //объявление метода 
        int X { get; } //объявление свойства, доступного только для чтения 
        int Y { get; }
        int Z { get; }
        int this[int i] { get; set; } //объявление индексатора, доступного для чтения-записи 
    }
    //класс DemoPoint наследует интерфейс IDemo 
    class DemoPoint : IDemo
    {
        protected int x;
        protected int y;
        protected int z = 0;
        public int Z
        {
            get
            {
                return z;
            }
        }
        public DemoPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void Show() //реализация метода, объявленного в интерфейсе 
        {
            Console.WriteLine("точка на плоскости: ({0}, {1})", x, y);
        }
        public double Dlina() //реализация метода, объявленного в интерфейсе 
        {
            return Math.Sqrt(x * x + y * y);
        }
        public int X //реализация свойства, объявленного в интерфейсе 
        {
            get
            {
                return x;
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
        }

        public int this[int i] //реализация индексатора, объявленного в интерфейсе 
        {
            get
            {
                if (i == 0) return x;
                else if (i == 1) return y;
                else throw new Exception("недопустимое значение индекса");
            }
            set
            {
                if (i == 0) x = value;
                else if (i == 1) y = value;
                else throw new Exception("недопустимое значение индекса");
            }
        }
    }

    //класс DemoShape наследует класс DemoPoint и интерфейс IDemo 
    class DemoShape : DemoPoint, IDemo
    {
        protected int z;
        public DemoShape(int x, int y, int z) : base(x, y)
        {
            this.z = z;
        }
        // реализация метода, объявленного в интерфейсе, с сокрытием одноименного метода из 
        //базового класса 
        public new void Show()
        {
            Console.WriteLine("точка в пространстве: ({0}, {1}, {2})", x, y, z);
        }
        // реализация метода, объявленного в интерфейсе, с сокрытием одноименного метода из 
        //базового класса 
        public new double Dlina()
        {
            return Math.Sqrt(x * x + y * y + z * z);
        }
        // реализация индексатора, объявленного в интерфейсе, с сокрытием одноименного 
        // индексатора из базового класса 
        public int Z
        {
            get
            {
                return z;
            }
        }
        public new int this[int i]
        {
            get
            {
                if (i == 0) return x;
                else if (i == 1) return y;
                else if (i == 2) return z;
                else throw new Exception("недопустимое значение индекса");
            }
            set
            {
                if (i == 0) x = value;
                else if (i == 1) y = value;
                else if (i == 2) z = value;
                else throw new Exception("недопустимое значение индекса");
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            //создание массива интерфейсных ссылок 
            IDemo[] a = new IDemo[4];
            //заполнение массива 
            a[0] = new DemoPoint(0, 1);
            a[1] = new DemoPoint(-3, 0);
            a[2] = new DemoShape(3, 4, 0);
            a[3] = new DemoShape(0, 5, 6);
            //просмотр массива 
            foreach (IDemo x in a)
            {
                x.Show();
                Console.WriteLine("Dlina={0:f2}", x.Dlina());
                Console.WriteLine("x=" + x.X);
                x[1] += x[0];
                Console.WriteLine("y=" + x.Y);
                Console.WriteLine("z=" + x.Z);
                Console.Write("новые координаты - ");
                x.Show();
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
