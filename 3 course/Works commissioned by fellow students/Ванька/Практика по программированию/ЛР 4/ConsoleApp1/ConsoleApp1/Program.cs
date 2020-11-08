using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static int min = 10000000; //Счётчик
        static int mini = 0;
        static int[] B; //Массив

        static int Rec(int c, int n)
        {
            //При выполнении условия увеличиваем счётчик на 1
            if (Math.Pow(B[c], 2) + B[c] * Math.Sin(B[c]) < min)
            {
                min = Convert.ToInt32(Math.Pow(B[c], 2) + B[c] * Math.Sin(B[c]));
                mini = c;
                Console.WriteLine("min = {0}, c = {1}", min, mini);                             
            }

            //Вызов функции, если не пройдено по всем элементам
            if (c < n - 1)
            {
                Rec(c + 1, n);
            }

            return mini;
        }

        static void Main(string[] args)
        {            
            Random rand = new Random();

            //Размерность массива
            Console.Write("Введите кол-во элементов: ");
            int N = int.Parse(Console.ReadLine());
            B = new int[N];

            //Заполнение и вывод массива
            for (int i = 0; i < N; i++)
            {
                B[i] = rand.Next(-9, 10);
                Console.Write("{0} ", B[i]);
            }
            Console.WriteLine();

            //Подсчет трети
            int tret = (N / 3) * 2;
            Console.WriteLine("Первые две трети равны {0}.", tret);

            //Реккурентная функция и необходимое к ней
            int count1 = 0, count2 = tret;
            int Count = Rec(count1, tret);
            Count = Rec(count2, N);
            Console.WriteLine("Номер минимального значения выражения = {0}", Count);
        }
    }
}
