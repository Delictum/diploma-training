using System;

namespace ClassPrintPub1
{
    public class pub_print
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
}
