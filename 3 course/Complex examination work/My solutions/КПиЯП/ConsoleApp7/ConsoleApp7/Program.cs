using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    /*
         * Описать структуру с именем PRICE, содержащую следующие поля:
           •	Название товара;
           •	Название магазина, в котором продается товар;
           •	Стоимость товара в рублях.
           Написать программу, выполняющую следующие действия: 
           ввод с клавиатуры данных в массив, состоящий из девяти структур типа PRICE;
           записи должны быть размещены в алфавитном порядке по названиям магазинов;
        */
    struct PRICE
    {
        public string Name;
        public string Shop;
        public int Price;

        public PRICE(string Name, string Shop, int Price)
        {
            this.Name = Name;
            this.Shop = Shop;
            this.Price = Price;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            PRICE[] tovar = new PRICE[9];
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine("Товар номер {0}", i + 1);
                Console.Write("Введите название товара: ");
                string Name = Console.ReadLine();
                Console.Write("Введите название магазина: ");
                string Shop = Console.ReadLine();
                Console.Write("Введите стоимость товара: ");
                int Price = int.Parse(Console.ReadLine());
                Console.WriteLine();
                tovar[i] = new PRICE(Name, Shop, Price);
            }

            foreach(PRICE a in tovar.OrderBy(itm => itm.Shop))
            {
                Console.WriteLine("Название товара: {0}", a.Name);
                Console.WriteLine("Название магазина: {0}", a.Shop);
                Console.WriteLine("Стоимость товара: {0}", a.Price);
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
