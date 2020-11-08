using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    class Program
    {       

        static void Main(string[] args)
        {
            Random rand = new Random();
            /*
            Задание 1.
            Найти количество отрицательных элементов массива А.
            */
            Console.WriteLine("Задание 1.");
            int[] mas1 = new int[10];
            
            int count1 = 0;
            Console.WriteLine("Весь массив: ");
            for (int i = 0; i < mas1.Length; i++)
            {
                mas1[i] = rand.Next(-10, 10);                 
                Console.Write("{0} ", mas1[i]);
                if (mas1[i] < 0)
                    count1++;
            }
            Console.WriteLine();

            Console.WriteLine("Количество отрицательных элементов: {0}", count1);
            Console.WriteLine();

            /*
            Задание 2.
            Максимальный элемент массива
            */
            Console.WriteLine("Задание 2.");
            int[] mas2 = new int[10];
            for (int i = 0; i < 10; i++)
            {                
                mas2[i] = rand.Next(1, 10);
                Console.Write("{0} ", mas2[i]);
            }
            Console.WriteLine();
            
            Console.WriteLine("Максимальный элемент: {0}", mas2.Max());
            Console.WriteLine();

            /*
            Задание 3.
            Любой из самых холодных дней декабря
            */
            Console.WriteLine("Задание 3.");
            int[] mas3 = new int[31];
            int min3 = 10, imin3 = 10;
            for (int i = 0; i < mas3.Length; i++)
            {
                mas3[i] = rand.Next(-30, 10);
                Console.Write("День {0}: {1} ", i + 1, mas3[i]);
                if (mas3[i] < min3)
                {
                    min3 = mas3[i];
                    imin3 = i;
                }                    
            }
            Console.WriteLine();
            Console.WriteLine("Один из самых холодных дней декабря: " + imin3);
            Console.WriteLine();

            /*
           Задание 4.
           Пусть даны целые числа а1, ..., а99. Получите новую последовательность, выбросив из исходной максимальный и минимальный члены.
           */
            Console.WriteLine("Задание 4.");
            int[] mas4 = new int[100];
            int min4 = 100, imin4 = 100, max4 = 0, imax4 = 100;

            //Заводим массив
            Console.WriteLine("Массив:");
            for (int i = 0; i < mas4.Length; i++) 
            {
                mas4[i] = rand.Next(0, 30);
                Console.Write("{0} ", mas4[i]);
                if (min4 > mas4[i])
                {
                    min4 = mas4[i];
                    imin4 = i;
                }
                if (max4 < mas4[i])
                {
                    max4 = mas4[i];
                    imax4 = i;
                }
            }
            Console.WriteLine();

            Console.WriteLine("Новый массив:");
            for (int i = 0; i < mas4.Length; i++)
            {
                if (i != imin4 | i != imax4)
                    Console.Write("{0} ", mas4[i]);
            }
            Console.WriteLine();
            Console.WriteLine();

            /*
            Задание 5.
            Дан одномерный массив из действительных чисел.
            Все его элементы умножить на последний элемент
            */
            Console.WriteLine("Задание 5.");
            double[] mas5 = new double[10];
            double sr5 = 0;

            Console.WriteLine("Массив: ");
            for (int i = 0; i < mas5.Length; i++)
            {
                mas5[i] = rand.Next(0, 10);
                Console.Write("{0} ", mas5[i]);
            }
            Console.WriteLine();

            Console.WriteLine("Новый массив: ");
            for (int i = 0; i < mas5.Length; i++)
            {
                mas5[i] *= mas5[mas5.Length - 1];
                Console.Write("{0} ", mas5[i]);
            }
            Console.WriteLine();

            Console.WriteLine();

            /*
            Задание 6.
            Решите задачу. 
            Известно количество осадков (в миллиметрах), выпавших в Москве за каждый год в течение первых 50 лет нашего столетии. 
            Выяснить среднее количество осадков и отклонение от среднего для каждого года.
            */
            Console.WriteLine("Задание 6.");
            int[] mas6 = new int[50];
            double sum6 = 0, sr6 = 0;

            Console.WriteLine("Осадки за год: ");
            for (int i = 0; i < mas6.Length; i++)
            {
                mas6[i] = rand.Next(100, 1000);
                Console.Write("Год {0}: {1}мм ", i + 1967, mas6[i]);
                sum6 += mas6[i];
            }
            Console.WriteLine();

            sr6 = sum6 / mas6.Length;
            
            Console.WriteLine("Среднее количество осадков: " + sr6);

            Console.WriteLine("Отклонение осадков за год от средней величины: ");
            for (int i = 0; i < mas6.Length; i++)
            {
                Console.Write("Год {0}: {1}мм ", i + 1967, mas6[i] - sr6);
            }
            Console.WriteLine();

            Console.WriteLine();

            /*
            Задание 7.
            Найти максимальный элемент матрицы А(6х10) и его порядковый номер.
            */
            Console.WriteLine("Задание 7.");
            int[,] mas7 = new int[6, 10];
            int max7 = 0, imax7 = 0, jmax7 = 0;

            //Задали матрицу
            Console.WriteLine("Изначальная матрица:");
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    mas7[i, j] = rand.Next(10, 100);
                    Console.Write("{0} ", mas7[i, j]);
                    if (max7 < mas7[i, j])
                    {
                        max7 = mas7[i, j];
                        imax7 = i;
                        jmax7 = j;
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("Максимальный элемент матрицы: {0}, индекс i и j: {1} и {2}", max7, imax7, jmax7);
            Console.WriteLine();

            /*
            Задание 8.
            Найти сумму элементов в тех столбцах, которые не содержат отрицательных элементов.
            */
            Console.WriteLine("Задание 8.");
            int[,] mas8 = new int[5, 4];
            int[] imas8 = new int[4]; //Массив для включения индексов строк с отрицательными элементами
            int sum8 = 0, ii = 0, temp = 0;

            //Задали матрицу
            Console.WriteLine("Матрица:");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    mas8[i, j] = rand.Next(-5, 10);
                    Console.Write("{0} ", mas8[i, j]);
                }
                Console.WriteLine();
            }

            int result = 0;
            for (int i = 0; i < 4; i++)
            {
                temp = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (mas8[j, i] < 0)
                    {
                        temp = 0;
                        break;
                    }
                    temp += mas8[j, i];
                }
                result += temp;
            }
            Console.WriteLine("Сумма равна " + result);            

            Console.WriteLine();

            /*
            Задание 9.
            Решите задачу. 
            В двумерном массиве хранится информация о баллах, полученных спортсменами-пятиборцами в каждом из пяти видов спорта 
            (в первом столбце – информация о баллах первого спортсмена,  во втором – второго и т.д.). 
            Общее число спортсменов равно 20. Составить программу для расчета общей суммы баллов, набранных любым спортсменом.
            */
            Console.WriteLine("Задание 9.");
            int[,] mas9 = new int[5, 20];
            int[] mas9n = new int[20];
            int sum9 = 0, c9 = 0;

            //Задали матрицу
            Console.WriteLine("Матрица:");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    mas9[i, j] = rand.Next(0, 10);
                    Console.Write("{0} ", mas9[i, j]);
                    mas9n[c9] += mas9[i, j];
                }
                c9++;
                Console.WriteLine();
            }

            for (int j = 0; j < 20; j++)
                Console.WriteLine("Общая сумма баллов: " + mas9n[j]);
            Console.WriteLine();

            /*
            Задание 10.
            Дан двумерный массив. В каждой его строке найти минимальный элемент.
            */
            Console.WriteLine("Задание 10.");
            int[,] mass = new int[4, 6];
            Random ran = new Random();

            for (int i = 0; i < mass.GetLength(0); i++)
            {
                for (int j = 0; j < mass.GetLength(1); j++)
                {
                    mass[i, j] = ran.Next(0, 100);
                    Console.Write("{0} ", mass[i, j]);
                }
                Console.WriteLine();
            }


                int[] temparray = new int[mass.GetLength(1)];
            for (int i = 0; i < mass.GetLength(0); i++)
            {

                for (int j = 0; j < mass.GetLength(1); j++)
                    temparray[j] = mass[i, j];

                Console.WriteLine("Строка '{0}' массива, индекс эл-та ={1}, минимум ={2}"
                                    , i, Array.IndexOf(temparray, temparray.Min()), temparray.Min());
            }
            Console.WriteLine();

            /*
            Задание 11.
            Дан двумерный массив. Определить в какой строке массива сумма элементов больше: в первой или в предпоследней.
            */
            Console.WriteLine("Задание 11.");
            int[,] mas11 = new int[4, 4];
            int sum11_1 = 0, sum11_2 = 0;

            //Задали матрицу
            Console.WriteLine("Матрица:");
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    mas11[i, j] = rand.Next(0, 10);
                    Console.Write("{0} ", mas11[i, j]);
                    if (i == 0)
                        sum11_1 += mas11[i, j];
                    if (i == 2)
                        sum11_2 += mas11[i, j];
                }
                Console.WriteLine();
            }

            if (sum11_1 >= sum11_2)
                Console.WriteLine("Сумма элементов в первой строке массива больше.");
            else
                Console.WriteLine("Сумма элементов в предпоследней строке массива больше.");
            Console.WriteLine();

            /*
            Задание 12.
            Дан двумерный массив. Составить программу, которая переставляет две любые строки массива.
            */
            Console.WriteLine("Задание 12.");
            int[,] mas12 = new int[5, 5];
            int[] m12 = new int[5];

            //Задали матрицу
            Console.WriteLine("Исходная матрица: ");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    mas12[i, j] = rand.Next(0, 10);
                    Console.Write("{0} ", mas12[i, j]);                    
                }
                Console.WriteLine();
            }

            Console.WriteLine("Введите номера двух строк: ");
            int x12 = int.Parse(Console.ReadLine());
            int y12 = int.Parse(Console.ReadLine());

            for (int i = 0; i < 5; i++)
            {
                m12[i] = mas12[x12, i];
                mas12[x12, i] = mas12[y12, i];
                mas12[y12, i] = m12[i];
            }


            Console.WriteLine("Полученная матрица:");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                    Console.Write("{0} ", mas12[i, j]);
                Console.WriteLine();
            }
            Console.WriteLine();

            /*
            Задание 13.
            Работа с несколькими массивами. 
            Дан двумерный массив размером NxN. Сформировать одномерный массив из элементов заданного массива, расположенных под главной диагональю
            */
            Console.WriteLine("Задание 13.");
            Random rnd = new Random(DateTime.UtcNow.Millisecond);
            int[,] Arr = new int[5, 5];
            // Заполняем массив
            for (int i = 0; i < Arr.GetLength(0); i++)
            {
                for (int j = 0; j < Arr.GetLength(1); j++)
                {
                    Arr[i, j] = rnd.Next(0, 10);
                }
            }
            // Выводим на экран
            for (int i = 0; i < Arr.GetLength(0); i++)
            {
                for (int j = 0; j < Arr.GetLength(1); j++)
                {
                    Console.Write(Arr[i, j] + " ");
                }
                Console.WriteLine();
            }

            int[] res = new int[(Arr.GetLength(0) * Arr.GetLength(1) - Arr.GetLength(0)) / 2];
            int count = 0;
            // Набиваем резултирующий массив
            for (int i = 0; i < Arr.GetLength(0) - 1; i++)
            {
                for (int j = i + 1; j < Arr.GetLength(1); j++)
                {
                    res[count++] = Arr[j, i];
                }
            }

            // Выводим результ
            Console.WriteLine();
            for (int j = 0; j < res.Length; j++)
            {
                Console.Write(res[j] + " ");
            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
