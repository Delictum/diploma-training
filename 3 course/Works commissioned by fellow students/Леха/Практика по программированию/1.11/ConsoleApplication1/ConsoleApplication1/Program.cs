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
            Console.WriteLine("Введите n: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите число: ");
            int nn = int.Parse(Console.ReadLine());

            FileStream f = new FileStream("Numbers_text.txt", FileMode.Create);
            BinaryWriter fOut = new BinaryWriter(f);

            for (int i = 0; i <= n; i++)
            {
                if (i % nn != 0)
                    fOut.Write(i);
            }
            fOut.Close();

            Console.WriteLine("Вывод из файла: ");
            f = new FileStream("Numbers_text.txt", FileMode.Open);
            BinaryReader fIn = new BinaryReader(f);
            long m = f.Length; 
            for (long i = 0; i < m; i += 4)
            {
                f.Seek(i, SeekOrigin.Begin);
                int foo = fIn.ReadInt32();
                if (foo > 0)
                    Console.Write("{0} ", foo);
            }
            fIn.Close();
            f.Close();

            Console.ReadKey();            
        }
    }
}
