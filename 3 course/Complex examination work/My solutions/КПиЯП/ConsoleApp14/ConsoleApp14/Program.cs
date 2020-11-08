using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    class Program
    {
        /* Пусть даны натуральные числа n, а1, ..., аn
         * (количество элементов и сами элементы ввести с клавиатуры). 
         * Определите количество членов ак последовательности а1, ..., аn, удовлетворяющих условию:
         * ak < (ak-1 + ak+1) / 2
         * Решить задачу двумя способами: с использованием массивов и без использования массивов. 
         * На экран вывести исходные данные и результаты. Предусмотреть исключительные ситуации.
         */
        static void Main(string[] args)
        {
            Console.WriteLine("Вариант 1: ");
            Console.Write("Введите кол-во элементов: ");
            int n = int.Parse(Console.ReadLine());
            double[] natn = new double[n];
            Console.WriteLine("Введите элементы: ");
            for (int i = 0; i < n; i++)
                natn[i] = int.Parse(Console.ReadLine());

            Console.WriteLine("Исходные числа: ");
            for (int i = 0; i < n; i++)
                Console.Write("{0} ", natn[i]);
            Console.WriteLine();
            
            int l = 0;
            double[] natk = new double[n];
            for (int k = 1; k < n - 1; k++)
                if (natn[k] < (natn[k - 1] + natn[k + 1]) / 2)
                {
                    natk[l] = natn[k];
                    l++;
                }

            Console.WriteLine("Полученные числа: ");
            for (int i = 0; i < l + 1; i++)
                if (natk[i] > 0)
                    Console.Write("{0} ", natk[i]);
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Вариант 2: ");
            string temp = "";
            Console.WriteLine("Введите элементы: ");
            for (int i = 0; i < n; i++)
            {
                int temp1 = int.Parse(Console.ReadLine());
                temp += Convert.ToString(temp1);
            }
            Console.WriteLine("Исходные числа: ");
            Console.WriteLine(temp);

            Console.WriteLine("Полученные числа: ");
            for (int i = 1; i < temp.Length - 1; i++)
            {
                string buf = "";
                if (int.Parse(temp.Substring(i, 1)) < (int.Parse(temp.Substring(i - 1, 1)) + int.Parse(temp.Substring(i + 1, 1))) / 2)
                    buf = temp.Substring(i, 1);
                Console.Write("{0} ", buf);
            }
        }
    }
}
