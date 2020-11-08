using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Mat
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
}
