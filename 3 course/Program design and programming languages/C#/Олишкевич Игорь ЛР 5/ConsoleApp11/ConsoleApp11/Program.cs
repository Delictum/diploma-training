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
            /*
            Задание 1.
            Вывести на экран дисплея положительные элементы массива и найти их количество.
            */

            Console.WriteLine("Задание 1.");
            int[] mas1 = new int[10];
            Random rand1 = new Random();
            int count1 = 0;
            Console.WriteLine("Весь массив: ");
            for (int i1 = 0; i1 < mas1.Length; i1++)
            {
                mas1[i1] = rand1.Next(-10, 10); 
                
                    Console.Write("{0} ", mas1[i1]);
                
            }
            Console.WriteLine();

            Console.WriteLine("Искомый массив: ");
            for (int i1 = 0; i1 < mas1.Length; i1++)
            {
                mas1[i1] = rand1.Next(-10, 10);
                if (mas1[i1] > 0)
                {
                    Console.Write("{0} ", mas1[i1]);
                    count1 += 1;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Количество положительных = {0}", count1);
            Console.WriteLine();

            /*
            Задание 2.
            В одномерном массиве, состоящем из n вещественных элементов,
            вычислить минимальный элемент массива.
            */
            Console.WriteLine("Задание 2.");
            Console.Write("Введите количество элементов массива: ");
            int n2 = Int32.Parse(Console.ReadLine());
            int[] mas2 = new int[n2];
            Random rand2 = new Random();
            for (int i2 = 0; i2 < n2; i2++)
            {                
                mas2[i2] = rand2.Next(0, 100);
                Console.Write("{0} ", mas2[i2]);
            }
            Console.WriteLine();
            Console.WriteLine("Min = {0}", mas2.Min());
            Console.WriteLine();

            /*
            Задание 3.
            В массиве содержатся результаты измерений температуры воздуха, 
            которые проводились ежедневно в течение декабря месяца. 
            Определите день, когда температура была ближе всего к средней температуре в декабре.
            */
            Console.WriteLine("Задание 3.");
            int[] mas3 = new int[31];
            Random rand3 = new Random();
            int sum3 = 0, min3, k3;
            double srednee3 = 0;
            for (int i3 = 0; i3 < mas3.Length; i3++)
            {
                mas3[i3] = rand3.Next(-30, 10);
                Console.Write("День {0}: {1} ", i3 + 1, mas3[i3]);
                sum3 += mas3[i3];
            }
            srednee3 = sum3 / 31;
            Console.WriteLine();
            Console.WriteLine("Средняя температура = {0}", srednee3);

            min3 = Math.Abs(mas3[0] - Convert.ToInt32(srednee3));
            k3 = 1;
            for (int i03 = 1; i03 < mas3.Length; i03++)
                if (Math.Abs(mas3[i03] - srednee3) < min3)
                {
                    min3 = Math.Abs(mas3[i03] - Convert.ToInt32(srednee3));
                    k3 = i03;
                }
            Console.WriteLine("Наиболее приближенная температура - {0}, номер дня - {1}, разность со средней - {2}.", mas3[k3], k3, min3);
            Console.WriteLine();

            /*
           Задание 4.
           Напишите программу для решения задачи.
           Пусть дана последовательность из 100 различных целых чисел. 
           Найдите среднее арифметическое чисел этой последовательности, 
           расположенных между максимальным и минимальным числами (в сумму включить и оба этих числа).
           */
            Console.WriteLine("Задание 4.");
            int[] mas4 = new int[100];
            Random rand4 = new Random();
            int min4, max4, imin4, imax4, index4 = 0;
            double srednee4 = 0, sum4 = 0;

            //Заводим массив
            Console.WriteLine("Изначальный массив:");
            for (int i4 = 0; i4 < mas4.Length; i4++) 
            {
                mas4[i4] = rand4.Next(0, 100);
                Console.Write("{0} ", mas4[i4]);                
            }
            Console.WriteLine();

            //Находим мин и макс и их индексы
            min4 = mas4.Min();
            imin4 = Array.IndexOf(mas4, min4);
            max4 = mas4.Max();
            imax4 = Array.IndexOf(mas4, max4);

            //Выводим массив от минимального до максимального если индекс минимального элемента < индекса максимального, иначе вывод после изменения порядка            
            Console.WriteLine("Полученный массив:");
            if (imin4 > imax4)
            {
                mas4.Reverse();
                min4 = mas4.Min();
                imin4 = Array.IndexOf(mas4, min4);
                max4 = mas4.Max();
                imax4 = Array.IndexOf(mas4, max4);
            }
            for (int i4 = imin4; i4 < imax4 + 1; i4++)
            {
                index4 += 1;
                sum4 += mas4[i4];
                Console.Write("{0} ", mas4[i4]);
            }

            srednee4 = sum4 / index4;
            Console.WriteLine();
            Console.WriteLine("Среднее значение = {0}", srednee4);
            Console.WriteLine();

            /*
            Задание 5.
            Дан одномерный массив из действительных чисел.
            Определить сумму шести первых элементов массива.
            */
            Console.WriteLine("Задание 5.");
            int[] mas5 = new int[10];
            Random rand5 = new Random();
            int sum5 = 0;

            for (int i5 = 0; i5 < mas5.Length; i5++)
            {
                mas5[i5] = rand5.Next(-10, 10);
                Console.Write("{0} ", mas5[i5]);
                if (i5 < 6)
                    sum5 += mas5[i5];
            }
            Console.WriteLine();
            Console.WriteLine("Сумма первых шести элементов = {0}", sum5);
            Console.WriteLine();

            /*
            Задание 6.
            Решите задачу. 
            В массиве хранится информация о максимальной скорости каждой из 40 марок легковых автомобилей. 
            Определить порядковый номер самого быстрого автомобиля. 
            Если таких автомобилей несколько, то должен быть найден номер последнего из них.
            */
            Console.WriteLine("Задание 6.");
            int[] mas6 = new int[40];
            Random rand6 = new Random();
            int max6 = 0, index6 = 0;
            
            for (int i6 = 0; i6 < mas6.Length; i6++)
            {
                mas6[i6] = rand6.Next(150, 155);
                Console.Write("Номер {0} - {1}. ", i6 + 1, mas6[i6]);
                if (max6 <= mas6[i6])
                {
                    max6 = mas6[i6];
                    index6 = i6;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Последний номер самого скоростного автомобиля = {0}", index6 + 1);
            Console.WriteLine();

            /*
            Задание 7.
            Найти наибольший и наименьший элементы матрицы и поменять их местами.
            */
            Console.WriteLine("Задание 7.");
            int[,] mas7 = new int[3, 3];
            Random rand7 = new Random();
            int max7, min7, imax7 = 0, jmax7 = 0, imin7 = 0, jmin7 = 0, buf7;

            //Задали матрицу
            Console.WriteLine("Изначальная матрица:");
            for (int i7 = 0; i7 < 3; i7++)
            {
                for (int j7 = 0; j7 < 3; j7++)
                {
                    mas7[i7, j7] = rand7.Next(0, 10);
                    Console.Write("{0} ", mas7[i7, j7]);
                }
                Console.WriteLine();
            }

            //Ищем мин и макс с их индексами
            max7 = mas7[1, 1];
            min7 = mas7[1, 1];
            for (int i7 = 0; i7 < 3; i7++)
                for (int j7 = 0; j7 < 3; j7++)
                {
                    if (min7 > mas7[i7, j7])
                    {
                        min7 = mas7[i7, j7];
                        imin7 = i7;
                        jmin7 = j7;
                    }
                    if (max7 < mas7[i7, j7])
                    {
                        max7 = mas7[i7, j7];
                        imax7 = i7;
                        jmax7 = j7;
                    }
                }

            //Меняем местами макс и мин
            buf7 = mas7[imin7, jmin7];
            mas7[imin7, jmin7] = mas7[imax7, jmax7];
            mas7[imax7, jmax7] = buf7;

            //Выводим результат
            Console.WriteLine("Полученная матрица:");
            for (int i7 = 0; i7 < 3; i7++)
            {
                for (int j7 = 0; j7 < 3; j7++)
                {
                    Console.Write("{0} ", mas7[i7, j7]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            /*
            Задание 8.
            Дана целочисленная прямоугольная матрица.
            Найти сумму элементов в тех строках, которые содержат хотя бы один отрицательный элемент.
            */
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

            //Вбиваем номера строк с отрицательными элементами в новый массив
            for (int i8 = 0; i8 < 5; i8++)
            {
                for (int j8 = 0; j8 < 4; j8++)
                    if (mas8[i8, j8] < 0)
                    {
                        imas8[ii] = i8; //Номер строки
                        ii += 1; //Количество строк
                        break;
                    }
            }

            //Считаем сумму элементов
            for (int i8 = 0; i8 < ii; i8++) //Берем из массива номер строки с отриц элем
            {
                sum8 = 0;
                for (int j8 = 0; j8 < 4; j8++) //Обходим все столбцы строки и суммируем
                    sum8 += mas8[imas8[i8], j8];
                Console.WriteLine("Сумма элементов в строке {0} = {1}", imas8[i8], sum8);
            }
            Console.WriteLine();

            /*
            Задание 9.
            Решите задачу. 
            Фирма имеет 10 магазинов. 
            Информация о доходе каждого магазина за каждый месяц года хранится в двумерном массиве 
            (первого магазина – в первой строке, второго во второй и т.д.). 
            Составить программу для расчета среднемесячного дохода любого магазина.
            */
            Console.WriteLine("Задание 9.");
            int[,] mas9 = new int[10, 12];
            Random rand9 = new Random();
            double srednee = 0, sum9 = 0;

            //Задали матрицу
            Console.WriteLine("Матрица:");
            for (int i9 = 0; i9 < 10; i9++)
            {
                for (int j9 = 0; j9 < 12; j9++)
                {
                    mas9[i9, j9] = rand9.Next(0, 5);
                    Console.Write("{0} ", mas9[i9, j9]);
                }
                Console.WriteLine();
            }

            Console.Write("Введите номер магазина для подсчета его среднемесячного дохода: ");
            int n10 = Int32.Parse(Console.ReadLine());
            for (int j9 = 0; j9 < 12; j9++)
                sum9 += mas9[n10 - 1, j9];
            srednee = sum9 / 12;
            Console.Write("Среднемесячный доход = {0}", srednee);
            Console.WriteLine();

            /*
            Задание 10.
            Нахождение максимума и минимума. Дан двумерный массив. 
            В каждой его строке найти координаты минимального элемента. 
            Если элементов с минимальным значением в строке несколько, 
            то должны быть найдены координаты самого правого из них.
            */
            Console.WriteLine("Задание 10.");
            int[,] mas10 = new int[5, 5];
            Random rand10 = new Random();
            int min10 = 0, imin10 = 0, jmin10 = 0;

            //Задали матрицу
            Console.WriteLine("Матрица:");
            for (int i10 = 0; i10 < 5; i10++)
            {
                for (int j10 = 0; j10 < 5; j10++)
                {
                    mas10[i10, j10] = rand10.Next(0, 5);
                    Console.Write("{0} ", mas10[i10, j10]);
                }
                Console.WriteLine();
            }

            for (int i10 = 0; i10 < 5; i10++)
            {
                min10 = mas10[i10, 0];
                imin10 = i10;
                jmin10 = 0;
                for (int j10 = 0; j10 < 5; j10++)                
                    if (min10 >= mas10[i10, j10])
                    {
                        min10 = mas10[i10, j10];
                        imin10 = i10;
                        jmin10 = j10;
                    }
                Console.WriteLine("Минимум в строке {0} = {1}. Координата y = {2}.", i10 + 1, min10, jmin10 + 1);
            }
            Console.WriteLine();

            /*
            Задание 11.
            Решить задачу на проверку условий после выполнения расчетов.
            Информация о количестве жильцов в каждой из четырех квартир каждого этажа 12-этажного дома хранится в двумерном массиве 
            (в первой строке – информация о квартирах первого этажа, во второй – второго и т.д.). 
            На каком этаже проживает больше людей: на третьем или на пятом?
            */
            Console.WriteLine("Задание 11.");
            int[,] mas11 = new int[12, 4];
            Random rand11 = new Random();
            int sum11_3 = 0, sum11_5 = 0;

            //Задали матрицу
            Console.WriteLine("Матрица:");
            for (int i11 = 0; i11 < 12; i11++)
            {
                for (int j11 = 0; j11 < 4; j11++)
                {
                    mas11[i11, j11] = rand11.Next(1, 6);
                    Console.Write("{0} ", mas11[i11, j11]);
                }
                Console.WriteLine();
            }

            for (int j11 = 0; j11 < 4; j11++)
            {
                sum11_3 += mas11[2, j11];
                sum11_5 += mas11[4, j11];
            }
            Console.Write("На 3 этаже проживает {0}, а на 5 - {1}. ", sum11_3, sum11_5);
            if (sum11_3 > sum11_5)
                Console.WriteLine("На 3 проживает больше человек.");
            else if (sum11_3 < sum11_5)
                Console.WriteLine("На 5 проживает больше человек.");
            else
                Console.WriteLine("Проживает одинаковое количество человек.");
            Console.WriteLine();

            /*
            Задание 12.
            Решить задачу по изменению исходного массива.
            Дан двумерный массив целых чисел. 
            Все элементы массива, оканчивающиеся на 2, 
            умножить на последний элемент соответствующего столбца.
            */
            Console.WriteLine("Задание 12.");
            int[,] mas12 = new int[5, 5];
            Random rand12 = new Random();

            //Задали матрицу
            Console.WriteLine("Матрица:");
            for (int i12 = 0; i12 < 5; i12++)
            {
                for (int j12 = 0; j12 < 5; j12++)
                {
                    mas12[i12, j12] = rand12.Next(-2, 13);
                    Console.Write("{0} ", mas12[i12, j12]);
                }
                Console.WriteLine();
            }

            for (int i12 = 0; i12 < 5; i12++)            
                for (int j12 = 0; j12 < 5; j12++)
                {
                    string str12 = Convert.ToString(mas12[i12, j12]).Substring(Convert.ToString(mas12[i12, j12]).Length - 1); //Нахождение последнего символа строки
                    if (str12 == "2")
                    {
                        mas12[i12, j12] *= mas12[4, j12];
                    }
                }

            Console.WriteLine("Полученная матрица:");
            for (int i12 = 0; i12 < 5; i12++)
            {
                for (int j12 = 0; j12 < 5; j12++)
                {
                    Console.Write("{0} ", mas12[i12, j12]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            /*
            Задание 13.
            Работа с несколькими массивами. 
            Дан двумерный массив размером n*n. 
            Сформировать одномерный массив из элементов заданного массива,
            расположенных под побочной диагональю.
            */
            Console.WriteLine("Задание 13.");
            Console.Write("Введите размерность массива: ");
            int n13 = Int32.Parse(Console.ReadLine());
            int[,] mas13 = new int[n13, n13];
            Random rand13 = new Random();

            int n13_new = 0;
            for (int i13 = 0; i13 < n13; i13++)
                n13_new += i13;
            int[] mas13_new = new int[n13_new];
            int ii13 = 0;

            //Задали матрицу
            Console.WriteLine("Матрица:");
            for (int i13 = 0; i13 < n13; i13++)
            {
                for (int j13 = 0; j13 < n13; j13++)
                {
                    mas13[i13, j13] = rand13.Next(0, 10);
                    Console.Write("{0} ", mas13[i13, j13]);
                }
                Console.WriteLine();
            }

            for (int i13 = 0; i13 < n13; i13++)
                for (int j13 = 0; j13 < n13; j13++)
                    if (i13 + j13 > n13 - 1)
                    {
                        mas13_new[ii13] = mas13[i13, j13];
                        ii13 += 1;
                    }

            Console.WriteLine("Новый массив:");
            for (int i13 = 0; i13 < n13_new; i13++)
                Console.Write("{0} ", mas13_new[i13]);
            Console.ReadKey();
        }
    }
}
