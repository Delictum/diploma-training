using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    struct BOOK 
    {
        public string author, name, pub;
        public int year, pages;
    }

    public class Program
    {
        static void Main(string[] args)
        {
            BOOK[] book = new BOOK[6];
            Console.WriteLine("Заполнение данных:");
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine("Книга №{0}:", i + 1);
                Console.Write("Введите автора: ");
                book[i].author = Console.ReadLine();
                Console.Write("Введите название книги: ");
                book[i].name = Console.ReadLine();
                Console.Write("Введите издательство: ");
                book[i].pub = Console.ReadLine();
                Console.Write("Введите год издания: ");
                book[i].year = int.Parse(Console.ReadLine());
                Console.Write("Введите количество страниц: ");
                book[i].pages = int.Parse(Console.ReadLine());
                Console.WriteLine();
            }

            Console.Write("Введите автора: ");
            string vvod = Console.ReadLine();
            int count = 0;

            bool b = false;            
            for (int i = 0; i < 6; i++)
            {
                if (book[i].author == vvod)
                {
                    count++;
                    Console.WriteLine("{0}) название книги '{1}', издательство '{2}', год издания {3} и количество страниц {4}", count, book[i].name, book[i].pub, book[i].year, book[i].pages);
                    b = true;
                }
            }

            if (b == false)
            {
                Console.WriteLine("Нет книг данного автора.");
            }

            Console.ReadKey();
        }
    }
} 
