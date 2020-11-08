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
            void MA(string F);
            void MO(string N);
            void ST(string Z);
            void RE(string L);
        }

        class Auto : Realese
        {
            public string ma;
            public string mo;
            public string st;
            public string re;
            public Auto(string ma, string mo, string st, string re)
            {
                this.ma = ma;
                this.mo = mo;
                this.st = st;
                this.re = re;
            }

            public void MA(string F)
            {
                Console.WriteLine(F);
            }
            public void MO(string N)
            {
                Console.WriteLine(N);
            }
            public void ST(string Z)
            {
                Console.WriteLine(Z);
            }
            public void RE(string L)
            {
                Console.WriteLine(L);
            }
        }

        static void Main(string[] args)
        {
            Auto[] a = new Auto[2];
            for (int i = 0; i < 2; i++)
            {
                Console.Write("Введите марку: ");
                string fio = Console.ReadLine();
                Console.Write("Введите мощность: ");
                string name = Console.ReadLine();
                Console.Write("Введите стоимость: ");
                string zanr = Console.ReadLine();
                Console.Write("Введите дату ремонта: ");
                string list = Console.ReadLine();
                a[i] = new Auto(fio, name, zanr, list);
                a[i].MA(a[i].ma);
                a[i].MO(a[i].mo);
                a[i].ST(a[i].st);
                a[i].RE(a[i].re);
            }
            Console.ReadKey();
        }
    }
}
