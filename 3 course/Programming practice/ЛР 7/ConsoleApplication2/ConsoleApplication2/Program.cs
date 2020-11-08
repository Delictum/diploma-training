using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
namespace ConsoleApp5
{
    //печатное издание, журнал, книга, учебник
    abstract class pub_print
    {
        public string name_print, name_pub, author_print;
        public int pages_print, year_print;

        public pub_print(string name_print, string name_pub, string author_print, int pages_print, int year_print)
        {
            this.name_print = name_print;
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
        
        public abstract void print();

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


        public static pub_print operator ++(pub_print obj1)
        {
            obj1.pages_print += 1;
            return obj1;
        }
    }

    class journal : pub_print
    {
        public string style;

        public journal(string style, string name_print, string name_pub, string author_print, int pages_print, int year_print) :base (name_print, name_pub, author_print, pages_print, year_print)
        {
            this.style = style;
        }

        public override void print()
        {
            Console.WriteLine("Печатное издание: журнал;\nИздатель: {0};\nНазвание журнала: {1};\nАвтор: {4};\nНаправление журнала: {5};\nКоличество страниц: {2};\nГод издания: {3}.\n", name_pub, name_print, pages_print, year_print, author_print, style);
        }
    }

    class book : pub_print
    {
        public string binding;

        public book(string binding, string name_print, string name_pub, string author_print, int pages_print, int year_print) :base (name_print, name_pub, author_print, pages_print, year_print)
        {
            this.binding = binding;
        }

        public override void print()
        {
            
        }

        public void printer()
        {            
            Console.WriteLine("Печатное издание: книга;\nИздатель: {0};\nНазвание: {1};\nАвтор: {4};\nКоличество страниц: {2};\nГод издания: {3};", name_pub, name_print, pages_print, year_print, author_print);
            Console.WriteLine("Переплёт: {0};", binding);
        }
    }

    class textbook : book 
    {
        public string discipline;

        public textbook(string binding, string name_print, string name_pub, string author_print, int pages_print, int year_print) :base (binding, name_print, name_pub, author_print, pages_print, year_print)
        {            
            discipline = "Биология";
        }

        public override void print()
        {
            printer();
            Console.WriteLine("Дисциплина: {0}.\n", discipline);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {            
            string b, n_print, n_pub, a_print;
            int N, p_print, y_print;

            StreamReader sr = new StreamReader("text.txt");
            N = int.Parse(sr.ReadLine());
            textbook[] t = new textbook[N];

            for (int i = 0; i < N; i++)
            {
                b = sr.ReadLine();
                n_print = sr.ReadLine();
                n_pub = sr.ReadLine();
                a_print = sr.ReadLine();
                p_print = int.Parse(sr.ReadLine());
                y_print = int.Parse(sr.ReadLine());
                t[i] = new textbook(b, n_print, n_pub, a_print, p_print, y_print);
            }

            for (int i = 0; i < N; i++)                            
                t[i].print();            

            textbook tb = new textbook("Твердый", "Sapiens. Краткая история человечества", "Синдбад", "Юваль Ной Харари", 512, 2017);
            tb.print(); 

            Console.WriteLine("Введите количество заполняемых журналов: ");
            int n = int.Parse(Console.ReadLine());

            journal[] j = new journal[n];
            string name_print, name_pub, author_print, style;
            int pages_print, year_print;

            for (int i = 0; i < n; i++)
            {                
                Console.Write("Введите издательство: ");
                name_pub = Console.ReadLine();
                Console.Write("Введите название издания: ");
                name_print = Console.ReadLine();
                Console.Write("Введите автора издания: ");
                author_print = Console.ReadLine();
                Console.Write("Введите количество страниц: ");
                pages_print = int.Parse(Console.ReadLine());
                Console.Write("Введите год издания: ");
                year_print = int.Parse(Console.ReadLine());
                Console.Write("Введите направление журнала: ");
                style = Console.ReadLine();
                j[i] = new journal(style, name_print, name_pub, author_print, pages_print, year_print);
                Console.WriteLine();
                j[0].Pages_print = pages_print;
            }

            j[0].pages_print++;

            for (int i = 0; i < n; i++)
            {                     
                j[i].print();
            }            

            Console.ReadKey();
        }
    }
}
