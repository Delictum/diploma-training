using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            //Найти сумму чисел кратных трем в массиве целых чисел. 
            Console.WriteLine("Задание 1.");
            int[] mas1 = new int[10];
            int count1 = 0;
            Console.WriteLine("Массив: ");
            for (int i = 0; i < 10; i++)
            {
                mas1[i] = rand.Next(0, 10);
                Console.Write(mas1[i] + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
                if (mas1[i] % 3 == 0)
                    count1 += mas1[i];
            Console.WriteLine("Сумма чисел массива, кратных трем: " + count1);
            Console.WriteLine();

            //Cумму элементов массива с нечетными номерами; 
            Console.WriteLine("Задание 2.");
            int[] mas2 = new int[10];
            int count2 = 0;
            Console.WriteLine("Массив: ");
            for (int i = 0; i < 10; i++)
            {
                mas2[i] = rand.Next(0, 10);
                Console.Write(mas2[i] + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
                if (i % 2 != 0)
                    count2 += mas2[i];
            Console.WriteLine("Сумма чисел массива на нечетных позициях: " + count1);
            Console.WriteLine();

            //В массиве содержатся результаты измерений температуры воздуха, которые проводились ежедневно в течение декабря месяца. 
            //Определите: день, когда температура была наименьшей; 
            Console.WriteLine("Задание 3.");
            int[] mas3 = new int[31];
            int sum3 = 0, min3 = 10, k3, imin3 = 0;
            for (int i = 0; i < mas3.Length; i++)
            {
                mas3[i] = rand.Next(-30, 10);
                Console.Write("День {0}: {1} ", i + 1, mas3[i]);
                sum3 += mas3[i];
                if (min3 > mas3[i])
                {
                    min3 = mas3[i];
                    imin3 = i + 1;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Наименьшая температура - {0}, номер дня - {1}", min3, imin3);
            Console.WriteLine();

            /* Пусть даны целые числа а1, ..., а25, b1, ..., b25. 
             * Преобразуйте последовательность b1, ..., b25 по правилу, 
             * согласно которому если ai <= 0, то bi увеличивается в 10 раз, 
             * иначе bi заменяется нулем (i = 1, …, 25). 
             */
            Console.WriteLine("Задание 4.");
            int[] mas4a = new int[25];
            int[] mas4b = new int[25];
            Console.WriteLine("Последовательность a: ");
            for (int i = 0; i < 25; i++)
            {
                mas4a[i] = rand.Next(-9, 10);
                Console.Write(mas4a[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Последовательность b: ");
            for (int i = 0; i < 25; i++)
            {
                mas4b[i] = rand.Next(-9, 10);
                Console.Write(mas4b[i] + " ");
            }
            Console.WriteLine();
            
            for (int i = 0; i < 25; i++)
            {
                if (mas4a[i] <= 0)
                    mas4b[i] *= 10;
                else
                    mas4b[i] = 0;
            }
            Console.WriteLine("Новая последовательность b: ");
            for (int i = 0; i < 25; i++)
                Console.Write(mas4b[i] + " ");
            Console.WriteLine();
            Console.WriteLine();

            //В одномерном массиве все его элементы уменьшить на число А; 
            Console.WriteLine("Задание 5.");
            int[] mas5 = new int[10];
            Console.WriteLine("Массив: ");
            for (int i = 0; i < 10; i++)
            {
                mas5[i] = rand.Next(0, 10);
                Console.Write(mas5[i] + " ");
            }
            Console.WriteLine();
            Console.Write("Введите число A: ");
            int A5 = int.Parse(Console.ReadLine());
            Console.WriteLine("Новый массив: ");
            for (int i = 0; i < 10; i++)
            {
                mas5[i] -= A5;
                Console.Write(mas5[i] + " ");
            }
            Console.WriteLine();

            /* В массиве записаны оценки по информатике 22 учащихся группы. 
             * Определить количество учащихся группы, 
             * оценка которых меньше средней оценки по группе, 
             * и вывести номера элементов массива, соответствующих таким учащимся. 
             */
            Console.WriteLine("Задание 6.");
            int[] mas6 = new int[22];
            int count6 = 0;
            double srednee6 = 0;
            Console.WriteLine("Оценки всех учащихся: ");
            for (int i = 0; i < 22; i++)
            {
                mas6[i] = rand.Next(1, 11);
                Console.Write(mas6[i] + " ");
                srednee6 += Convert.ToDouble(mas6[i]);
            }
            srednee6 /= 22;
            Console.WriteLine("Средняя оценка: " + srednee6);
            Console.WriteLine("Номер учащегося, с оценкой меньше средней: ");
            for (int i = 0; i < 22; i++)
            {
                if (Convert.ToDouble(mas6[i]) < srednee6)
                    Console.Write(i + " ");
            }
            Console.WriteLine();

            //Транспонировать матрицу В(8х8) и вывести ее таблицей. 
            Console.WriteLine("Задание 7.");
            int[,] mas7 = new int[8, 8];
            Console.WriteLine("Исходная матрица: ");
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    mas7[i, j] = rand.Next(0, 10);
                    Console.Write(mas7[i, j] + " ");
                }
                Console.WriteLine();
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    int tmp = mas7[i, j];
                    mas7[i, j] = mas7[j, i];
                    mas7[j, i] = tmp;
                }
            }
            Console.WriteLine("Полученная матрица: ");
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                    Console.Write(mas7[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();

            //Найти произведение элементов в тех строках, которые не содержат отрицательных элементов.
            Console.WriteLine("Задание 8.");
            int[,] mas8 = new int[5, 4];
            int[] imas8 = new int[5]; //Массив для включения индексов строк с отрицательными элементами
            Random rand8 = new Random();
            int ii = 0, sum8 = 0;

            //Задали матрицу
            Console.WriteLine("Матрица:");
            for (int i8 = 0; i8 < 5; i8++)
            {
                for (int j8 = 0; j8 < 4; j8++)
                {
                    mas8[i8, j8] = rand8.Next(-1, 6);
                    Console.Write("{0} ", mas8[i8, j8]);
                }
                Console.WriteLine();
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (mas8[i, j] < 0)
                        break;     
                    if (mas8[i, j] > 0 && j == 3)
                    {
                        imas8[ii] = i; //Номер строки 
                        ii += 1; //Количество строк
                    }
                }                
            }

            //Считаем произведение элементов
            for (int i8 = 0; i8 < ii; i8++) //Берем из массива номер строки с отриц элем
            {
                sum8 = 1;
                for (int j8 = 0; j8 < 4; j8++) //Обходим все столбцы строки и суммируем
                    sum8 *= mas8[imas8[i8], j8];
                Console.WriteLine("Произведение элементов в строке {0} = {1}", imas8[i8], sum8);
            }
            Console.WriteLine();

            /*В двумерном массиве хранится информация о количестве студентов 
             * в той и иной группе каждого курса института с первого по пятый 
             * (в первом столбце – информация о группах первого курса, во втором – второго и т.д.). 
             * На каждом курсе имеется 10 групп. Определить общее число студентов на пятом курсе. 
             */
            Console.WriteLine("Задание 9.");
            int[,] mas9 = new int[10, 5];
            Console.WriteLine("Массив: ");
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    mas9[i, j] = rand.Next(5, 30);
                    Console.Write(mas9[i, j] + " ");
                }
                Console.WriteLine();
            }

            int count9 = 0;
            for (int i = 0; i < 10; i++)
                count9 += mas9[i, 4];
            Console.WriteLine("Общее количество студентов на 5 курсе: " + count9);
            Console.WriteLine();

            /* Составить программу нахождения номера столбца, 
             * в котором расположен максимальный элемент любой строки двумерного массива. 
             * Если элементов с максимальным значением в этой строке несколько, 
             * то должен быть найден номер столбца самого правого из них. 
             */
            Console.WriteLine("Задание 10.");
            int[,] mas10 = new int[5, 5];
            int max10 = 0, imax10 = 0;
            Console.WriteLine("Массив: ");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    mas10[i, j] = rand.Next(0, 10);
                    Console.Write(mas10[i, j] + " ");
                    if (max10 <= mas10[i, j])
                    {
                        imax10 = j;
                        max10 = mas10[i, j];
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("Максимальный элемент: {0}; номер столбца: {1}", max10, imax10);
            Console.WriteLine();

            /* Дан двумерный массив целых чисел. 
             * Составить программу, определяющую, верно ли, 
             * что сумма элементов столбца массива с известным номером кратна заданному числу. 
             */
            Console.WriteLine("Задание 11.");
            int[,] mas11 = new int[5, 5];
            Console.WriteLine("Массив: ");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    mas11[i, j] = rand.Next(0, 10);
                    Console.Write(mas11[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.Write("Введите номер столбца: ");
            int number10 = int.Parse(Console.ReadLine());
            Console.Write("Введите число: ");
            int x11 = int.Parse(Console.ReadLine());
            int count11 = 0;
            for (int i = 0; i < 5; i++)
                count11 += mas11[i, number10];
            Console.WriteLine("Сумма элементов столбца: " + count11);
            if (count11 % x11 == 0)
                Console.WriteLine("Верно, число кратно сумме элементов столбца");
            else
                Console.WriteLine("Неверно, число некратно сумме элементов столбца");

            /* Заменить все элементы k-й строки и s-го столбца двумерного массива
             * на противоположные по знаку (элемент, стоящий на пересечении, не изменять).
             */
            Console.WriteLine("Задание 12.");
            int[,] mas12 = new int[5, 5];
            Console.WriteLine("Исходный массив: ");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    mas12[i, j] = rand.Next(0, 10);
                    Console.Write(mas12[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.Write("Введите номер строки: ");
            int k12 = int.Parse(Console.ReadLine());
            Console.Write("Введите номер столбца: ");
            int s12 = int.Parse(Console.ReadLine());

            for (int i = 0; i < 5; i++ )
                mas12[k12, i] = -mas12[k12, i];
            for (int i = 0; i < 5; i++)
                mas12[i, s12] = -mas12[i, s12];

            Console.WriteLine("Полученный массив: ");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                    Console.Write(mas12[i, j] + " ");
                Console.WriteLine();
            }

            //Значения элементов двумерного массива из m строк и n столбцов скопировать в одномерный массив размером m*n. 
            //Копирование проводить по столбцам начиная с первого (а в нем – с самого верхнего элемента).
            Console.WriteLine("Задание 13.");
            Console.Write("Введите число строк: ");
            int m13 = int.Parse(Console.ReadLine());
            Console.Write("Введите число столбцов: ");
            int n13 = int.Parse(Console.ReadLine());
            int[,] mas13a = new int[m13, n13];
            int[] mas13b = new int[m13 * n13];

            Console.WriteLine("Исходный массив: ");
            for (int i = 0; i < m13; i++)
            {
                for (int j = 0; j < n13; j++)
                {
                    mas13a[i, j] = rand.Next(0, 10);
                    Console.Write(mas13a[i, j] + " ");
                }
                Console.WriteLine();
            }

            int count13 = 0;
            for (int i = 0; i < n13; i++)
                for (int j = 0; j < m13; j++)
                {
                    mas13b[count13] = mas13a[j, i];
                    count13++;
                }

            for (int i = 0; i < count13; i++)
                Console.Write(mas13b[i] + " ");
            Console.ReadKey();
        }
    }
}
