using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConsoleApp3
{
    struct Product
    {
        public string Name;
        public int Price;
        public DateTime Manufactured;
        public DateTime Expires;
        public int Quantity;
        public string Company;

        public Product(string Name, int Price, DateTime Manufactured,
            DateTime Expires, int Quantity, string Company)
        {
            this.Name = Name;
            this.Price = Price;
            this.Manufactured = Manufactured;
            this.Expires = Expires;
            this.Quantity = Quantity;
            this.Company = Company;
        }

    }

    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("Кол-во товаров: ");
                int n = int.Parse(Console.ReadLine());
                Product[] Products = new Product[n];
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Заполнение данных {0} товара.", i + 1);
                    Console.Write("Наименование: ");
                    string Name = Console.ReadLine();
                    Console.Write("Цена: ");
                    int Price = Int32.Parse(Console.ReadLine());
                    Console.Write("Дата изготовления: ");
                    DateTime Manufactured = DateTime.Parse(Console.ReadLine());
                    Console.Write("Срок годности: ");
                    DateTime Expires = DateTime.Parse(Console.ReadLine());                                   
                    Console.Write("Количество: ");
                    int Quantity = Int32.Parse(Console.ReadLine());
                    Console.Write("Производитель: ");
                    string Company = Console.ReadLine();
                    Console.WriteLine();
                    Products[i] = new Product(Name, Price, Manufactured, Expires, Quantity, Company);
                }

                Console.WriteLine("Информация о просроченных товарах:");
                foreach (Product a in Products)
                {
                    if (a.Expires < DateTime.Today)
                    {
                        Console.WriteLine("Наименование: {0}", a.Name);
                        Console.WriteLine("Цена:{0}", a.Price);
                        Console.WriteLine("Дата изготовления: {0}", a.Manufactured);
                        Console.WriteLine("Срок годности: {0}", a.Expires);
                        Console.WriteLine("Количество: {0}", a.Quantity);
                        Console.WriteLine("Производитель: {0}", a.Company);
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
