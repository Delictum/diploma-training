using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Mat
    {
        public double x1;
        public double x2;
        public double x3;
        public double x4;
        public double x5;
        public double[] mas = new double[5];

        public Mat(double x1, double x2, double x3, double x4, double x5)
        {
            this.x1 = x1;            
            this.x2 = x2;
            this.x3 = x3;
            this.x4 = x4;
            this.x5 = x5;
        }        

        public double[] IniMas()
        {
            mas[0] = x1; mas[1] = x2; mas[2] = x3; mas[3] = x4; mas[4] = x5;
            return (mas);
        }

        public void IniVector()
        {            
            Console.WriteLine("Координаты вектора: ");
            for (int i = 0; i < 5; i++)
                Console.Write(mas[i] + "; ");
            Console.WriteLine();
        }         
        
        public double[] SortP()
        {
            Array.Sort(mas);
            IniVector();
            return mas;
        }

        public double[] SortM()
        {
            Array.Sort(mas);
            Array.Reverse(mas);
            IniVector();
            return mas;
        }
    }

    //Заданы два вектора А(0.052; 0.9; 0.15; 0.84; 0.67) и  В(0.948; 0.1; 0.33; 0.16; 0.85). 
    //Написать программу, позволяющую расположить элементы одного вектора по возрастанию, 
    //а другого - по убыванию. Вычислить сумму полученных векторов.
    class Program
    {
        static void Main(string[] args)
        {      
            Mat v1 = new Mat(0.052, 0.9, 0.15, 0.84, 0.67);
            Mat v2 = new Mat(0.948, 0.1, 0.33, 0.16, 0.85);

            v1.IniMas();
            v1.IniVector();

            v2.IniMas();
            v2.IniVector();

            v1.SortP();
            v2.SortM();

            Console.WriteLine("Координаты нового вектора ({0}; {1}; {2}; {3}; {4})", v1.mas[0] + v2.mas[0], v1.mas[1] + v2.mas[1], v1.mas[2] + v2.mas[2], v1.mas[3] + v2.mas[3], v1.mas[4] + v2.mas[4]);
        }
    }
}
