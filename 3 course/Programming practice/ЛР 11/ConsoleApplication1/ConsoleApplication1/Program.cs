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
            Console.WriteLine("Введите начальную позицию последовательности: ");
            double begin_num = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите конечную позицию последовательности: ");
            double end_num = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите шаг последовательности: ");
            double step_num = double.Parse(Console.ReadLine());

            FileStream f = new FileStream("Numbers_text.txt", FileMode.Create);
            BinaryWriter fOut = new BinaryWriter(f);
            for (double i = begin_num; i <= end_num; i += step_num)
            {
                fOut.Write(i);
            }
            fOut.Close();

            Console.WriteLine("Вывод из файла: ");
            f = new FileStream("Numbers_text.txt", FileMode.Open);
            BinaryReader fIn = new BinaryReader(f);
            long m = f.Length; //определяем количество байт в потоке
            //Читаем данные из файла t.dat начиная с элемента с номером 1, т.е с 8 байта,
            //перемещая внутренний указатель на 16 байт, т.е. на два вещественных числа
            for (long i = 0; i < m; i += 8)
            {
                f.Seek(i, SeekOrigin.Begin);
                double foo = fIn.ReadDouble();
                if (foo > 0)
                    Console.Write("{0:f2} ", foo);
            }
            fIn.Close();
            f.Close();

            Console.WriteLine();

            Console.WriteLine("*****");

            Console.WriteLine("Задайте целое число: ");
            int len_num = int.Parse(Console.ReadLine());               

            Console.WriteLine("Вывод из файла: ");
            FileStream fSymb = new FileStream("Symbol_text.txt", FileMode.Open);
            StreamReader fO = new StreamReader(fSymb);
            String lines;
            while ((lines = fO.ReadLine()) != null)
            {
                if (lines.Length == len_num)
                    Console.WriteLine(lines);
            }
        }
    }
}
