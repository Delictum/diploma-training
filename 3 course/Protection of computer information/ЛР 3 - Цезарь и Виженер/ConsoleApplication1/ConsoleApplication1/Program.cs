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
            string Alphavit = "abcdefghijklmnopqrstuvwxyz ";
            Console.Write("Введите строку: ");
            string WordIn = Console.ReadLine();
            Console.Write("Количество подстановок: ");
            int Position = Int32.Parse(Console.ReadLine());
            string WordOut = "";

            for (int i = 0; i < WordIn.Length; i++)
            {
                int buf = Alphavit.IndexOf(WordIn[i]);
                int temp = buf + Position;
                if (temp > 26)
                    temp = temp - 27;
                WordOut += Alphavit[temp];                               
            }

            Console.WriteLine(WordOut);
            Console.ReadKey();
        }
    }
}
