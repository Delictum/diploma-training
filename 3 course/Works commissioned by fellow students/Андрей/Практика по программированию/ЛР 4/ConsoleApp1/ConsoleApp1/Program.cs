using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {        
        static int sum = 0; //Счётчик
        static int[] Z; //Массив
        static int Rec(int c, int n)
        {            
            //При выполнении условия увеличиваем счётчик на 1
            if (Math.Pow((Math.Abs(Z[c]) + 1), 1 / 3.0) < c)
            {
                sum++;
                Console.WriteLine("Количество = {0} под индексом {1}", sum, c);                             
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
            Z = new int[N];

            //Заполнение и вывод массива
            for (int i = 0; i < N; i++)
            {
                Z[i] = rand.Next(-9, 10);
                Console.Write("{0} ", Z[i]);
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
            Console.WriteLine("Полученное количество элементов = {0}", Count);
        }
    }
}
