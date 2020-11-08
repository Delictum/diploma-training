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
            void NA(string N);
            void FI(string F);
            void ST(string S);
            void OG(string O);
        }

        class STRANA : Realese
        {
            public string na;
            public string fp;
            public string pl;
            public string so;
            public STRANA(string na, string fp, string pl, string so)
            {
                this.na = na;
                this.fp = fp;
                this.pl = pl;
                this.so = so;
            }

            public void NA(string N)
            {
                Console.WriteLine(N);
            }
            public void FI(string F)
            {
                Console.WriteLine(F);
            }
            public void ST(string S)
            {
                Console.WriteLine(S);
            }
            public void OG(string O)
            {
                Console.WriteLine(O);
            }
        }

        static void Main(string[] args)
        {
            STRANA[] a = new STRANA[2];
            for (int i = 0; i < 2; i++)
            {
                Console.Write("Введите название: ");
                string na = Console.ReadLine();
                Console.Write("Введите форму правления: ");
                string fp = Console.ReadLine();
                Console.Write("Введите площадь: ");
                string pl = Console.ReadLine();
                Console.Write("Введите список областей: ");
                string so = Console.ReadLine();
                a[i] = new STRANA(na, fp, pl, so);
                a[i].NA(a[i].na);
                a[i].FI(a[i].fp);
                a[i].ST(a[i].pl);
                a[i].OG(a[i].so);
            }
            Console.ReadKey();
        }
    }
}
