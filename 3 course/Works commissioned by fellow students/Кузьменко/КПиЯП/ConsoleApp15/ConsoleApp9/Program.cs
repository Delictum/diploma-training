using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace ConsoleApp9
{
    class Program
    {
        static void Main(string[] args)
        {
            Mat v1 = new Mat(0.052, 0.9, 0.15, 0.84, 0.67);
            Mat v2 = new Mat(0.948, 0.1, 0.33, 0.16, 0.85);

            v1.IniMas();
            v1.IniVector();

            v2.IniMas();
            v2.IniVector();

            v1.SortP();
            v2.SortM();

            Console.WriteLine("Координаты нового вектора ({0}; {1}; {2}; {3}; {4})", v1.mas[0] + v2.mas[0], v1.mas[1] + v2.mas[1], v1.mas[2] + v2.mas[2], v1.mas[3] + v2.mas[3], v1.mas[4] + v2.mas[4]);
        }
    }
}
