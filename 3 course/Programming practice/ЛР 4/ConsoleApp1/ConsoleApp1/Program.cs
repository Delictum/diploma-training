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
        static int[] A; //Массив
        static int Rec(int c, int n)
        {            
            //При выполнении условия увеличиваем счётчик на 1
            if (Math.Sin(A[c]) < Math.Cos(A[c]))
            {
                sum++;
                Console.WriteLine("sum = {0}, c = {1}", sum, c);                             
            }

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
            A = new int[N];

            //Заполнение и вывод массива
            for (int i = 0; i < N; i++)
            {
                A[i] = rand.Next(-9, 10);
                Console.Write("{0} ", A[i]);
            }
            Console.WriteLine();

            //Подсчет трети
            int tret = (N / 3) * 2;
            Console.WriteLine("Первые две трети равны {0}.", tret);

            //Реккурентная функция и необходимое к ней
            int count1 = 0, count2 = tret;
            int Count = Rec(count1, tret);
            sum = 0;
            Count += Rec(count2, N);
            Console.WriteLine("Количество элементов, где его синус меньше косинуса = {0}", Count);
        }
    }
}
