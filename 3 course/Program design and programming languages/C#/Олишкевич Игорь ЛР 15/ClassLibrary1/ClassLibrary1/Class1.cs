using System;

namespace Goods
{
    public class Goods
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
}