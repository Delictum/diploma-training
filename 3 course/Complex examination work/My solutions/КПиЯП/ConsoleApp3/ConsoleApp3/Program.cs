using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        /*В одномерном массиве, состоящем из n целых элементов, вычислить:
          •	произведение положительных элементов массива, из некоторого заданного промежутка [a,b];
          •	произведение элементов массива, расположенных между минимальным и максимальным элементами массива.
          Изменить порядок следования элементов массива на обратный.
        */
        static void Main(string[] args)
        {
            Console.Write("Введите размерность массива: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Введите a: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Введите b: ");
            int b = int.Parse(Console.ReadLine());

            int[] mas = new int[n];
            Random rand = new Random();
            int poloz = 1, mm = 1, maxi = 0, mini = 0, max = 0, min = 0;

            Console.WriteLine("Массив: ");
            for (int i = 0; i < n; i++)
            {
                mas[i] = rand.Next(-10, 10);
                Console.Write("{0} ", mas[i]);           
            }
            Console.WriteLine();

            for (int i = 0; i < n; i++)
            {
                if (mas[i] > 0 && mas[i] >= a && mas[i] <= b)
                    poloz *= mas[i];

                if (max < mas[i])
                {
                    max = mas[i];
                    maxi = i;
                }
                if (min > mas[i])
                {
                    min = mas[i];
                    mini = i;
                }
            }
            Console.WriteLine("Максимум и минимум: {0} и {1}. Их индексы: {2} и {3}", max, min, maxi, mini);

            if (mini < maxi)
                for (int i = mini; i < maxi; i++)
                {
                    mm *= mas[i];
                }
            else
                for (int i = maxi; i > mini; i++)
                {
                    mm *= mas[i];
                }

            Console.WriteLine("Массив в обратной последовательности: ");
            for (int i = n - 1; i > -1; i--)
            {
                Console.Write("{0} ", mas[i]);
            }
            Console.WriteLine();

            Console.WriteLine("Произведение положительных элементов массива, промежутка[a, b]: {0}", poloz);
            Console.WriteLine("Произведение элементов массива, расположенных между минимальным и максимальным элементами массива: {0}", mm);
        }
    }
}
