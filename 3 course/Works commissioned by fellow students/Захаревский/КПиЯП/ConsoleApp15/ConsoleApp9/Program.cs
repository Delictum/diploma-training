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
            int[,] mass1 = new int[4, 4];
            int[,] mass2 = new int[3, 3];
            matr mm = new matr();
            Console.WriteLine("Матрица 1:\n");
            mm.Sozm(mass1);
            mm.Print(mass1);
            mm.SemM(mass1);
            Console.WriteLine("\nМатрица 2:\n");
            mm.Sozm(mass2);
            mm.Print(mass2);
            mm.SemM(mass2);
            Console.ReadKey();
        }
    }
}
