using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        interface Realese 
        { 
            void FIO(string F);
            void Name(string N);
            void Zanr(string Z);
            void List(string L);
        }

        class Picture : Realese
        {
            public string fio;
            public string name;
            public string zanr;
            public string list;
            public Picture(string fio, string name, string zanr, string list)
            {
                this.fio = fio;
                this.name = name;
                this.zanr = zanr;
                this.list = list;
            }

            public void FIO(string F)
            {
                Console.WriteLine(F);
            }
            public void Name(string N)
            {
                Console.WriteLine(N);
            }
            public void Zanr(string Z)
            {
                Console.WriteLine(Z);
            }
            public void List(string L)
            {
                Console.WriteLine(L);
            }
        }

        static void Main(string[] args)
        {
            Picture[] pic = new Picture[2];
            for (int i = 0; i < 2; i++)
            {
                Console.Write("Введите ФИО автора: ");
                string fio = Console.ReadLine();
                Console.Write("Введите название: ");
                string name = Console.ReadLine();
                Console.Write("Введите жанр: ");
                string zanr = Console.ReadLine();
                Console.Write("Введите список владельцев: ");
                string list = Console.ReadLine();
                pic[i] = new Picture(fio, name, zanr, list);
                pic[i].FIO(pic[i].fio);
                pic[i].Name(pic[i].name);
                pic[i].Zanr(pic[i].zanr);
                pic[i].List(pic[i].list);
            }
            Console.ReadKey();
        }
    }
}
