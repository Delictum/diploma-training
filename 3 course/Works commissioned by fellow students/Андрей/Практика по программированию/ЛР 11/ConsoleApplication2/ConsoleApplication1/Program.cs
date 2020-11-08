using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {            
            int max = 0;
            string strmax = "";

            Console.WriteLine("Вывод из файла: ");
            FileStream fSymb = new FileStream("Symbol_text.txt", FileMode.Open);
            StreamReader fO = new StreamReader(fSymb);
            String lines;
            while ((lines = fO.ReadLine()) != null)
            {
                if (lines.Length > max)
                {
                    strmax = lines;
                    max = lines.Length;
                }                    
            }
            Console.WriteLine("Строка: " + strmax);
            Console.WriteLine("Длина: " + max);
        }
    }
}
