using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{    
    class Program
    {
        static void Main(string[] args)
        {
#line hidden
            ClassPrintPub1.pub_print pp = new ClassPrintPub1.pub_print();
            pp.print();

            string name_print, type_print, name_pub, author_print;
            int pages_print, year_print;

#pragma warning disable 168
            int war;

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
            ClassPrintPub1.pub_print p_p = new ClassPrintPub1.pub_print(name_print, type_print, name_pub, author_print, pages_print, year_print);
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
