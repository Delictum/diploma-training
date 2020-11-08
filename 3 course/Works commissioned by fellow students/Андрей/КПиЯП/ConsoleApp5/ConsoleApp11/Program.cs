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
            Вычислить сумму и количество элементов массива вещественных чисел.
            */
            Console.WriteLine("Задание 1.");
            double[] mas1 = new double[10];
            
            double count1 = 0;
            Console.WriteLine("Весь массив: ");
            for (int i = 0; i < mas1.Length; i++)
            {
                mas1[i] = rand.Next(-10, 10);                 
                Console.Write("{0} ", mas1[i]);
                count1 += mas1[i];
            }
            Console.WriteLine();

            Console.WriteLine("Сумма элементов: {0}, длина массива: {1}", count1, mas1.Length);
            Console.WriteLine();

            /*
            Задание 2.
            Произведение элементов массива, расположенных между максимальным и минимальным элементами
            */
            Console.WriteLine("Задание 2.");
            int[] mas2 = new int[10];
            int min = 10, imin = 0, max = 0, imax = 0;
            for (int i = 0; i < 10; i++)
            {                
                mas2[i] = rand.Next(1, 10);
                Console.Write("{0} ", mas2[i]);
                if (min > mas2[i])
                {
                    min = mas2[i];
                    imin = i;
                }
                if (max < mas2[i])
                {
                    max = mas2[i];
                    imax = i;
                }
            }
            Console.WriteLine();
            int p2 = 1;
            if (imin < imax)
                for (int i = imin; i <= imax; i++)
                    p2 *= mas2[i];

            else
                for (int i = imax; i <= imin; i++)
                    p2 *= mas2[i];
            Console.WriteLine("Минимальный элемент: {0}, его индекс: {1}. Максимальный элемент: {2}, его индекс: {3}", min, imin, max, imax);
            Console.WriteLine("Произведение элементов между минимальным и максимальным элементом массива: " + p2);
            Console.WriteLine();

            /*
            Задание 3.
            Сколько раз температура была выше 0°С
            */
            Console.WriteLine("Задание 3.");
            int[] mas3 = new int[31];
            int c3 = 0;
            for (int i = 0; i < mas3.Length; i++)
            {
                mas3[i] = rand.Next(-30, 10);
                Console.Write("День {0}: {1} ", i + 1, mas3[i]);
                if (mas3[i] > 0)
                    c3++;
            }
            Console.WriteLine();
            Console.WriteLine("Температура была выше 0°С " + c3 + " раз.");
            Console.WriteLine();

            /*
           Задание 4.
           Пусть дано 50 чисел. Определите, сколько среди них отличных от последнего числа
           */
            Console.WriteLine("Задание 4.");
            int[] mas4 = new int[50];
            int last, c4 = 0;

            //Заводим массив
            Console.WriteLine("Массив:");
            for (int i = 0; i < mas4.Length; i++) 
            {
                mas4[i] = rand.Next(0, 30);
                Console.Write("{0} ", mas4[i]);                
            }
            Console.WriteLine();
            last = mas4[49];
            for (int i = 0; i < mas4.Length; i++)
                if (last != mas4[i])
                    c4++;
            Console.WriteLine("Чисел, отличных от {0} равно {1}", last, c4);
            Console.WriteLine();

            /*
            Задание 5.
            Дан одномерный массив из действительных чисел.
            Составить программу расчета среднего арифметического двух любых элементов массива
            */
            Console.WriteLine("Задание 5.");
            double[] mas5 = new double[10];
            double sr5 = 0;

            for (int i = 0; i < mas5.Length; i++)
            {
                mas5[i] = rand.Next(-10, 10);
                Console.Write("{0} ", mas5[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Введите два номера элемента массива от 0 до 10: ");
            back5_1: int elem1 = int.Parse(Console.ReadLine());
            if (elem1 < 0 | elem1 > 10)
                goto back5_1;
            back5_2: int elem2 = int.Parse(Console.ReadLine());
            if (elem2 < 0 | elem2 > 10)
                goto back5_2;
            sr5 = (mas5[elem1] + mas5[elem2]) / 2;
            Console.WriteLine("Среднее арифметическое элементов = {0}", sr5);
            Console.WriteLine();

            /*
            Задание 6.
            Решите задачу. 
            В массиве хранится информация о численности книг в каждом из 35 разделов библиотеки. 
            Выяснить, верно ли, что общее число книг в библиотеке есть шестизначное число.
            */
            Console.WriteLine("Задание 6.");
            int[] mas6 = new int[35];
            int sum6 = 0;
            
            for (int i = 0; i < mas6.Length; i++)
            {
                mas6[i] = rand.Next(700, 30000);
                Console.Write("{0} ", mas6[i]);
                sum6 += mas6[i];
            }
            Console.WriteLine();
            Console.WriteLine(sum6);
            if (Convert.ToString(sum6).Length == 6)
                Console.WriteLine("Общее число книг в библиотеке есть шестизначное число");
            else
                Console.WriteLine("Общее число книг в библиотеке не шестизначное число");
            Console.WriteLine();

            /*
            Задание 7.
            Вычислить сумму и число элементов матрицы А(10х10), находящихся под главной диагональю и над ней.
            */
            Console.WriteLine("Задание 7.");
            int[,] mas7 = new int[10, 10];
            int c7 = 0, sum = 0;

            //Задали матрицу
            Console.WriteLine("Изначальная матрица:");
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    mas7[i, j] = rand.Next(0, 10);
                    Console.Write("{0} ", mas7[i, j]);
                    if (i != j)
                    {
                        sum += mas7[i, j];
                        c7++;
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("Сумма элементов: {0}, их количество: {1}", sum, c7);
            Console.WriteLine();

            /*
            Задание 8.
            Найти максимальное из чисел, встречающихся в заданной матрице более одного раза.
            */
            Console.WriteLine("Задание 8.");
            int[,] mas8 = new int[5, 4];
            int max8 = 0, cm = 0, never8 = 0;

            //Задали матрицу
            Console.WriteLine("Матрица:");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    mas8[i, j] = rand.Next(0, 10);
                    Console.Write("{0} ", mas8[i, j]);
                    if (max8 < mas8[i, j])                
                        max8 = mas8[i, j];
                }
                Console.WriteLine();
            }

            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 4; j++)
                    if (max8 == mas8[i, j])
                    {
                        max8 = mas8[i, j];
                        cm++;
                    }
            back8: if (cm >= 2)
                Console.WriteLine("Максимальное из чисел, встречающихся в заданной матрице более одного раза: {0}", max8);
            else if (max8 == 0 && cm == 1)
                Console.WriteLine("Максимальных из чисел, встречающихся в заданной матрице более одного раза, не существует");
            else
            {
                cm = 0;
                never8 = max8;
                max8 = 0;
                for (int i = 0; i < 5; i++)
                    for (int j = 0; j < 4; j++)
                        if (max8 <= mas8[i, j] && mas8[i, j] < never8)
                        {
                            max8 = mas8[i, j];
                            cm++;
                        }
                goto back8;
            }            
            Console.WriteLine();

            /*
            Задание 9.
            Решите задачу. 
            В зрительном зале 25 рядов, в каждом их которых 36 мест (кресел). 
            Информация о проданных билетах храниться в двумерном массиве, 
            номера строк которого соответствуют номерам рядов, 
            а номера столбцов – номерам мест. Если билет на то или иное место продан, 
            то соответствующий элемент массива имеет значение 1, в противном случае – 0. 
            Составить программу, определяющую число проданных билетов на места в 12 ряду.
            */
            Console.WriteLine("Задание 9.");
            int[,] mas9 = new int[25, 36];
            int sum9 = 0;

            //Задали матрицу
            Console.WriteLine("Матрица:");
            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 36; j++)
                {
                    mas9[i, j] = rand.Next(0, 2);
                    Console.Write("{0} ", mas9[i, j]);
                    if (i == 11 && mas9[i, j] == 1)
                        sum9++;
                }
                Console.WriteLine();
            }

            Console.Write("Проданные билеты в 12 ряду: " + sum9);
            Console.WriteLine();

            /*
            Задание 10.
            Составить программу нахождения минимального значения среди элементов любой строки двумерного массива.
            */
            Console.WriteLine("Задание 10.");
            int[,] mas10 = new int[5, 5];
            int min10 = 10;

            Console.Write("Введите номер строки: ");
            int stroka = int.Parse(Console.ReadLine());
            //Задали матрицу
            Console.WriteLine("Матрица:");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    mas10[i, j] = rand.Next(0, 10);
                    Console.Write("{0} ", mas10[i, j]);
                    if (i == stroka && min > mas10[i, j])
                        min10 = mas10[i, j];
                }
                Console.WriteLine();
            }
            Console.WriteLine("Минимальный элемент в {0} строке равен: {1}", stroka, min10);
            Console.WriteLine();

            /*
            Задание 11.
            Решить задачу на проверку условий после выполнения расчетов.
            Дан двумерный массив. Составить программу, определяющую, верно ли, 
            что сумма элементов строки массива с известным номером превышает заданное число?
            */
            Console.WriteLine("Задание 11.");
            int[,] mas11 = new int[12, 4];
            int sum11 = 0;
            Console.Write("Введите номер строки: ");
            int strok = int.Parse(Console.ReadLine());
            Console.Write("Введите число: ");
            int blablabla = int.Parse(Console.ReadLine());

            //Задали матрицу
            Console.WriteLine("Матрица:");
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    mas11[i, j] = rand.Next(0, 10);
                    Console.Write("{0} ", mas11[i, j]);
                }
                Console.WriteLine();
            }

            for (int j = 0; j < 4; j++)
                sum11 += mas11[strok, j];
            if (sum11 > blablabla)
                Console.WriteLine("Сумма элементов строки массива с известным номером превышает заданное число.");
            else
                Console.WriteLine("Сумма элементов строки массива с известным номером не превышает заданное число.");
            Console.WriteLine();

            /*
            Задание 12.
            Решить задачу по изменению исходного массива.
            Дан двумерный массив. Поменять местами первый максимальный и последний минимальный элементы массива. 
            Принять, что массив просматривается построчно сверху вниз, а в каждой строке – слева направо.
            */
            Console.WriteLine("Задание 12.");
            int[,] mas12 = new int[5, 5];
            int min12 = 10, max12 = 0, imin12 = 0, jmin12 = 0, imax12 = 0, jmax12 = 0;

            //Задали матрицу
            Console.WriteLine("Исходная матрица: ");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    mas12[i, j] = rand.Next(0, 10);
                    Console.Write("{0} ", mas12[i, j]);
                    if (min12 > mas12[i, j])
                    {
                        min12 = mas12[i, j];
                        imin12 = i;
                        jmin12 = j;
                    }
                    if (max12 <= mas12[i, j])
                    {
                        max12 = mas12[i, j];
                        imax12 = i;
                        jmax12 = j;
                    }
                }
                Console.WriteLine();
            }

            int buffer = mas12[imin12, jmin12];
            mas12[imin12, jmin12] = mas12[imax12, jmax12];
            mas12[imax12, jmax12] = buffer;


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
            Даны два двумерных массива одинаковых размеров. 
            Создать третий массив такого же размера, 
            каждый элемент которого равен разности суммы соответствующих элементов двух первых массивов.
            */
            Console.WriteLine("Задание 13.");
            Console.Write("Введите размерность массива: ");
            int n13 = Int32.Parse(Console.ReadLine());
            int[,] mas13_1 = new int[n13, n13];
            int[,] mas13_2 = new int[n13, n13];
            int[,] mas13_3 = new int[n13, n13];

            int n13_new = 0;
            for (int i13 = 0; i13 < n13; i13++)
                n13_new += i13;
            int[] mas13_new = new int[n13_new];
            int ii13 = 0;

            //Задали матрицу
            Console.WriteLine("Матрица 1:");
            for (int i = 0; i < n13; i++)
            {
                for (int j = 0; j < n13; j++)
                {
                    mas13_1[i, j] = rand.Next(0, 10);
                    Console.Write("{0} ", mas13_1[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("Матрица 2:");
            for (int i = 0; i < n13; i++)
            {
                for (int j = 0; j < n13; j++)
                {
                    mas13_2[i, j] = rand.Next(0, 10);
                    Console.Write("{0} ", mas13_2[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("Матрица 3:");
            for (int i = 0; i < n13; i++)
            {
                for (int j = 0; j < n13; j++)
                {
                    mas13_3[i, j] = mas13_1[i, j] - mas13_2[i, j];
                    Console.Write("{0} ", mas13_3[i, j]);
                }
                Console.WriteLine();
            }
            
            Console.ReadKey();
        }
    }
}
