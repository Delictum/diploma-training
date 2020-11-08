using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9_
{
    class Program
    {
        abstract class Figura
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

        class Circle : Figura
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

        class Rectangle : Figura
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

        class Square : Figura
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

        static void Main(string[] args)
        {
            /*
             * Построить систему классов для описания плоских геометрических фигур: 
             * круг, прямоугольник, квадрат. 
             * Предусмотреть методы для создания объектов, перемещения их на плоскости, изменения размеров. 
             * Написать программу, демонстрирующую работу с этими классами. 
             * Программа должна содержать специальный метод – меню, позволяющий осуществить проверку всех других методов класса. 
             */
            int x = 0, y = 0, R = 5, a = 5;
            Circle c = new Circle("круг", x, y, R);
            c.Out();
            c.CreateCircle(x, y, R);
            x = c.MoveCircleX(a, x);
            y = c.MoveCircleY(a, y);
            Console.WriteLine("После смещения: ");
            c.CreateCircle(x, y, R);
            Console.WriteLine("После увеличения в 2 раза: ");
            c.DoubleCircle(x, y, R);
            Console.WriteLine();

            int x1 = 10, y1 = 20, x2 = 30, y2 = 25;
            Rectangle r = new Rectangle("прямоугольник", x1, y1, x2, y2);
            r.Out();
            r.CreateRectangle(x1, y1, x2, y2);
            x1 = r.MoveRectangleX1(a, x1);
            x2 = r.MoveRectangleX2(a, x2);
            y1 = r.MoveRectangleY1(a, y1);
            y2 = r.MoveRectangleY2(a, y2);
            Console.WriteLine("После смещения: ");
            r.CreateRectangle(x1, y1, x2, y2);
            Console.WriteLine("После увеличения в 2 раза: ");
            r.DoubleRectangle(x1, y1, x2, y2);
            Console.WriteLine();

            int x1s = -10, y1s = -20, x2s = -20, y2s = -30;
            Square s = new Square("квадрат", x1s, y1s, x2s, y2s);
            s.Out();
            s.CreateSquare(x1s, y1s, x2s, y2s);
            x1s = s.MoveSquareX1(a, x1s);
            x2s = s.MoveSquareX2(a, x2s);
            y1s = s.MoveSquareY1(a, y1s);
            y2s = s.MoveSquareY2(a, y2s);
            Console.WriteLine("После смещения: ");
            s.CreateSquare(x1s, y1s, x2s, y2s);
            Console.WriteLine("После увеличения в 2 раза: ");
            s.DoubleSquare(x1s, y1s, x2s, y2s);

            Console.ReadKey();
        }
    }
}
