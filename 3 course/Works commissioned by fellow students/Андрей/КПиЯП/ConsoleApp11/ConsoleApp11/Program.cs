using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication11
{
    class Program
    {
        // ИЗДЕЛИЕ: название, шифр, количество, комплектация.
        interface Realese
        {
            void Shifr(string F);
            void Name(string N);
            void Count(string Z);
            void Complect(string L);
        }

        class Izdelie : Realese
        {
            public string shifr;
            public string name;
            public string count;
            public string complect;
            public Izdelie(string shifr, string name, string count, string complect)
            {
                this.shifr = shifr;
                this.name = name;
                this.count = count;
                this.complect = complect;
            }

            public void Shifr(string F)
            {
                Console.WriteLine(F);
            }
            public void Name(string N)
            {
                Console.WriteLine(N);
            }
            public void Count(string Z)
            {
                Console.WriteLine(Z);
            }
            public void Complect(string L)
            {
                Console.WriteLine(L);
            }
        }

        static void Main(string[] args)
        {
            Izdelie[] pic = new Izdelie[2];
            for (int i = 0; i < 2; i++)
            {
                Console.Write("Введите шифр: ");
                string fio = Console.ReadLine();
                Console.Write("Введите название: ");
                string name = Console.ReadLine();
                Console.Write("Введите количество: ");
                string zanr = Console.ReadLine();
                Console.Write("Введите комплектацию: ");
                string list = Console.ReadLine();
                pic[i] = new Izdelie(fio, name, zanr, list);
                pic[i].Shifr(pic[i].shifr);
                pic[i].Name(pic[i].name);
                pic[i].Count(pic[i].count);
                pic[i].Complect(pic[i].complect);
            }
            Console.ReadKey();
        }
    }
}
