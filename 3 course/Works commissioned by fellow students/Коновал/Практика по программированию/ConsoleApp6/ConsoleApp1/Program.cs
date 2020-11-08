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
         * Для заданного одномерного массива A из N элементов найти количество элементов массива, 
         * для которых выполняется условие sin Ai < cos Ai. 
         * В рекурсивной функции каждый раз отделять последнюю треть от первых двух третей рассматриваемой части массива
         * и применять эту же функцию к обеим частям. Рекурсивные вызовы заканчивать, 
         * когда останется только один элемент в рассматриваемой части массива. Например, для N=12: 
         */
        static int sum = 0; //Счётчик
        static int[] Y; //Массив
        static void Rec(int c, int n)
        {            
            //При выполнении условия увеличиваем счётчик на 1
            if (Y[c] * Math.Sin(Y[c]) > 5)
            {                
                Console.WriteLine("Для элемента = {0} под индексом {1} условие выполняется", Y[c], c);                             
            }

            //Вызов функции, если не пройдено по всем элементам
            if (c > 1)
            {
                Rec(c - 1, n);
            }
        }

        static void Main(string[] args)
        {            
            Random rand = new Random();

            //Размерность массива
            Console.Write("Введите кол-во элементов: ");
            int N = int.Parse(Console.ReadLine());
            Y = new int[N];

            //Заполнение и вывод массива
            for (int i = 0; i < N; i++)
            {
                Y[i] = rand.Next(-99, 100);
                Console.Write("{0} ", Y[i]);
            }
            Console.WriteLine();

            int count = N - 1;
            //Реккурентная функция и необходимое к ней
            Rec(count, N);
        }
    }
}
