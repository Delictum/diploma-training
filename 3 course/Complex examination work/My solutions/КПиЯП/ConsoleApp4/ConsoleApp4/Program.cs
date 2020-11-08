using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        /* В одномерном массиве, состоящем из n целых элементов, вычислить:
           •	номер минимального и максимального элементов массива;
           •	сумму элементов массива, расположенных между первым и вторым отрицательными элементами.
           Преобразовать массив так, чтобы в первой его половине располагались элементы, 
           стоящие в четных позициях, а во второй половине – элементы, стоявшие в нечетных позициях.
        */
        static void Main(string[] args)
        {
            Console.Write("Введите размерность массива: ");
            int n = int.Parse(Console.ReadLine());
            int[] mas = new int[n];
            int[] mass = new int[n];
            Random rand = new Random();
            int max = 0, maxi = 0, min = 0, mini = 0;
            int k = 0, ki1 = 0, ki2 = 0, ks = 0;

            Console.WriteLine("Массив: ");
            for (int i = 0; i < n; i++)
            {
                mas[i] = rand.Next(-10, 10);
                Console.Write("{0} ", mas[i]);

                if (mas[i] > max)
                {
                    max = mas[i];
                    maxi = i;
                }
                if (mas[i] < min)
                {
                    min = mas[i];
                    mini = i;
                }                
            }
            Console.WriteLine();

            for (int i = 0; i < n; i++)
            {
                if (mas[i] < 0 && k == 1)
                {
                    ki2 = i;
                    k++;
                }
                if (mas[i] < 0 && k == 0)
                {
                    ki1 = i;
                    k++;
                }                
            }
                Console.WriteLine("Номер первого отрицательного элемента: {0}; номер второго отрицательного элемента: {1}", ki1, ki2);
            for (int i = ki1 + 1; i < ki2; i++)            
                ks += mas[i];

            int j = 0;
            for (int i = 0; i < n / 2; i++)
            { 
                mass[i] = mas[j];
                j += 2;
            }
            j = 1;
            for (int i = n / 2; i < n - 1; i++)
            {
                mass[i] = mas[j];
                j += 2;
            }

            Console.WriteLine("Новый массив: ");
            for (int i = 0; i < n; i++)
            {
                Console.Write("{0} ", mass[i]);
            }
            Console.WriteLine();

            Console.WriteLine("Номер максимального элемента: {0}; номер минимального элемента: {1}", maxi, mini);
            Console.WriteLine("Сумма элементов массива, расположенных между первым и вторым отрицательными элементами: {0}", ks);
        }
    }
}
