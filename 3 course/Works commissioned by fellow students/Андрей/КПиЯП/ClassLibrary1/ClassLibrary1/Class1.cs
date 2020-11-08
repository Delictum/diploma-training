using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Figura
    {
        public string Name { get; set; }

        public Figura(string name)
        {
            Name = name;
        }

        public void Out()
        {
            Console.WriteLine("Крайние точки " + Name + "а в виде креста прямого положения по: ");
        }
    }

    public class Circle : Figura
    {
        public int X;
        public int Y;
        public int R;

        public Circle(string name, int x, int y, int r) : base(name)
        {
            X = x;
            Y = y;
            R = r;
        }

        public void CreateCircle(int x, int y, int R)
        {
            Console.WriteLine("x и y, -x и -y: {0} и {1}, {2} и {3}", x + R, y + R, x - R, y - R);
        }

        public int MoveCircleX(int a, int x)
        {
            return x + a;
        }

        public int MoveCircleY(int a, int y)
        {
            return y + a;
        }

        public void DoubleCircle(int x, int y, int R)
        {
            Console.WriteLine("x и y, -x и -y: {0} и {1}, {2} и {3}", x + R * 2, y + R * 2, x - R * 2, y - R * 2);
        }
    }

    public class Rectangle : Figura
    {
        public int X1;
        public int Y1;
        public int X2;
        public int Y2;

        public Rectangle(string name, int x1, int y1, int x2, int y2) : base(name)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }

        public void CreateRectangle(int x1, int y1, int x2, int y2)
        {
            Console.WriteLine("x и y, -x и -y: {0} и {1}, {2} и {3}", x1, y1, x2, y2);
        }

        public int MoveRectangleX1(int a, int x1)
        {
            return x1 + a;
        }

        public int MoveRectangleY1(int a, int y1)
        {
            return y1 + a;
        }

        public int MoveRectangleX2(int a, int x2)
        {
            return x2 + a;
        }

        public int MoveRectangleY2(int a, int y2)
        {
            return y2 + a;
        }

        public void DoubleRectangle(int x1, int y1, int x2, int y2)
        {
            int temp1 = Math.Abs(x1) + Math.Abs(x2);
            int temp2 = Math.Abs(y1) + Math.Abs(y2);
            Console.WriteLine("x и y, -x и -y: {0} и {1}, {2} и {3}", x1 + temp1 / 2, y1 + temp2 / 2, x2 + temp1 / 2, y2 + temp2 / 2);
        }
    }

    public class Square : Figura
    {
        public int X1;
        public int Y1;
        public int X2;
        public int Y2;

        public Square(string name, int x1, int y1, int x2, int y2) : base(name)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }

        public void CreateSquare(int x1, int y1, int x2, int y2)
        {
            Console.WriteLine("x и y, -x и -y: {0} и {1}, {2} и {3}", x1, y1, x2, y2);
        }

        public int MoveSquareX1(int a, int x1)
        {
            return x1 + a;
        }

        public int MoveSquareY1(int a, int y1)
        {
            return y1 + a;
        }

        public int MoveSquareX2(int a, int x2)
        {
            return x2 + a;
        }

        public int MoveSquareY2(int a, int y2)
        {
            return y2 + a;
        }

        public void DoubleSquare(int x1, int y1, int x2, int y2)
        {
            int temp = Math.Abs(x1) + Math.Abs(x2);
            Console.WriteLine("x и y, -x и -y: {0} и {1}, {2} и {3}", x1 + temp / 2, y1 + temp / 2, x2 + temp / 2, y2 + temp / 2);
        }
    }
}
