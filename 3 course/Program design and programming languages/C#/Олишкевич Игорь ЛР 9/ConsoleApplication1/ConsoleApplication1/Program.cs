using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Goods
    {
        string Name;
        DateTime DateO;
        int Price, Count, NumerN;

        public Goods(string Name, DateTime DateO, int Price, int Count, int NumerN)
        {
            this.Name = Name;
            this.DateO = DateO;
            this.Price = Price;            
            this.Count = Count;
            this.NumerN = NumerN;
        }

        public double DisPrice(int n)
        {
            return Price += n;
        }

        public double DisCount(int n)
        {            
                return Count += n;
        }

        public void ResPrice()
        {
            double n = Price * Count;
            Console.WriteLine("Общая стоимость товара: {0}", n);           
        }

        public void ToString()
        {
            Console.WriteLine("Стоимость товара: {0}", Price);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Goods g = new Goods("Йогурт", DateTime.Today, 89, 73, 124235);
            g.ToString();
            Console.Write("Введите на какую сумму изменить цену. Для уменьшения ввод отрицательного числа, иначе - положительного: ");
            int buf = int.Parse(Console.ReadLine());
            g.DisPrice(buf);
            g.ToString();
            Console.Write("Введите на какое количество изменить товары. Для уменьшения ввод отрицательного числа, иначе - положительного: ");
            buf = int.Parse(Console.ReadLine());
            g.DisCount(buf);
            g.ResPrice();

            Console.ReadKey();
        }
    }
}
