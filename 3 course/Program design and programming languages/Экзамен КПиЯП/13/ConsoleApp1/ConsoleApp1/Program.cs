using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class FRIDGE
    {
        private string name;
        private string firma;
        private int count;
        private double price;

        public FRIDGE()
        {
            name = "NULL";
            firma = "NULL";
            count = 0;
            price = 0;
        }

        public FRIDGE(string name, string firma, int count, double price)
        {
            this.name = name;
            this.firma = firma;
            this.count = count;
            this.price = price;
        }

        public FRIDGE(FRIDGE previousFRIDGE)
        {
            this.name = previousFRIDGE.name;
            this.firma = previousFRIDGE.firma;
            this.count = previousFRIDGE.count;
            this.price = previousFRIDGE.price;
        }

        public void info()
        {
            Console.WriteLine("Наименование {0}, фирма-изготовитель {1}, количество на складе {2}, цена {3}", name, firma, count, price);
        }

        public void vvod(string name, string firma, int count, double price)
        {
            this.name = name;
            this.firma = firma;
            this.count = count;
            this.price = price;
            info();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            FRIDGE[] f = new FRIDGE[3];
            f[0] = new FRIDGE();
            f[1] = new FRIDGE("Б", "А", 1, 0.1);
            f[2] = new FRIDGE(f[1]);
            for (int i = 0; i < 3; i++)
                f[i].info();
        }
    }
}
