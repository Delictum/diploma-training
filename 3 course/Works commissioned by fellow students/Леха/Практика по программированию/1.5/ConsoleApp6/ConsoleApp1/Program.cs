using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
       /*
        *Для заданного одномерного массива X из N элементов найти произведение множителей, вычисляемых по формуле. 
        * В рекурсивной функции каждый раз отделять первый элемент рассматриваемой части массива от остальных ее элементов, 
        * сразу вычисляя указанное выражение сначала для первого элемента, 
        * а затем с помощью этой же функции вычисляя указанное произведение для остальных элементов рассматриваемой части массива.
        * Рекурсивные вызовы заканчивать, когда в рассматриваемой части останется только один или два элемента.
        * Например, для N = 5:   
        */
        static double sum = 1; //Счётчик
        static int[] X; //Массив
        static double Rec(int c, int n)
        {
            sum *= X[c] - (Math.Pow(X[c], 2)) / (1 + c);

            //Вызов функции, если не пройдено по всем элементам
            if (c < n - 1)
            {
                Rec(c + 1, n);
            }

            return sum;
        }

        static void Main(string[] args)
        {            
            Random rand = new Random();

            //Размерность массива
            Console.Write("Введите кол-во элементов: ");
            int N = int.Parse(Console.ReadLine());
            X = new int[N];

            //Заполнение и вывод массива
            for (int i = 0; i < N; i++)
            {
                X[i] = rand.Next(-9, 10);
                Console.Write("{0} ", X[i]);
            }
            Console.WriteLine();

            int count = 0;
            //Реккурентная функция и необходимое к ней
            Console.WriteLine(Rec(count, N));
        }
    }
}
