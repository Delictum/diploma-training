using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class pub_print
    {
        public string name_print, type_print, name_pub, author_print;
        public int pages_print;
        private int year_print;

        public pub_print()
        {
            name_print = "Цветы для Элджернона";
            type_print = "Книга";
            name_pub = "Эксмо";            
            pages_print = 382;
            year_print = 2016;
            author_print = "Дэниел Киз";
        }

        public pub_print(string name_print, string type_print, string name_pub, string author_print, int pages_print, int year_print)
        {
            this.name_print = name_print;
            this.type_print = type_print;
            this.name_pub = name_pub;
            this.author_print = author_print;
            this.pages_print = pages_print;
            this.year_print = year_print;
        }

        public string Name_print
        {
            get { return name_print; }
            set { name_print = value; }
        }

        public int Pages_print
        {
            get { return pages_print; }
            set
            {
                if ((value >= 150) && (value <= 500))
                {
                    Console.WriteLine("Усредненный размер типа 'книга'.");
                }
                else if ((value >= 10) && (value <= 20))
                {
                    Console.WriteLine("Усредненный размер типа 'газета'.");
                }
            }
        }

        public void print()
        {
            Console.WriteLine("Печатное издание:\nИздатель: {0}\nТип издания: {2}\nНазвание издания: {1}\nАвтор издания: {5}\nКоличество страниц: {3}\nГод издания: {4}\n", name_pub, name_print, type_print, pages_print, year_print, author_print);
        }

        public static pub_print operator ++(pub_print obj1)
        {
            obj1.pages_print += 1;
            return obj1;
        }
    }


    public class Program
    {
        static void Main(string[] args)
        {
            pub_print pp = new pub_print();
            pp.print();

            string name_print, type_print, name_pub, author_print;
            int pages_print, year_print;

            Console.Write("Введите издательство: ");
            name_pub = Console.ReadLine();
            Console.Write("Введите тип издания: ");
            type_print = Console.ReadLine();
            Console.Write("Введите название издания: ");
            name_print = Console.ReadLine();
            Console.Write("Введите автора издания: ");
            author_print = Console.ReadLine();
            Console.Write("Введите количество страниц: ");
            pages_print = int.Parse(Console.ReadLine());
            Console.Write("Введите год издания: ");
            year_print = int.Parse(Console.ReadLine());
            pub_print p_p = new pub_print(name_print, type_print, name_pub, author_print, pages_print, year_print);
            Console.WriteLine();

            p_p.print();
            p_p.Pages_print = pages_print;
            p_p.pages_print++;
            Console.WriteLine("-----------------------------------");
            p_p.print();

            Console.ReadKey();
        }
    }
}
