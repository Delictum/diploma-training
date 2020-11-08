using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace ConsoleApp9_
{
    class Program
    {      
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
            var c = new Circle("круг", x, y, R);
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
