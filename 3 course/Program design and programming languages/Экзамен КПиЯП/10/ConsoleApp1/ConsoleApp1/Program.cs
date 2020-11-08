using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public struct Price
        {
            string name;
            string mag;
            int cost;
            public Price(string name, string mag, int cost)
            {
                this.name = name;
                this.mag = mag;
                this.cost = cost;
            }
        }

        static void Main(string[] args)
        {
            Price[] prices = new Price[9];
            for (int i = 0; i < 9; i++)
            {
                string name = Console.ReadLine();
                string mag = Console.ReadLine();
                int cost = int.Parse(Console.ReadLine());
                prices[i] = new Price(name, mag, cost);
            }
        }
    }
}
