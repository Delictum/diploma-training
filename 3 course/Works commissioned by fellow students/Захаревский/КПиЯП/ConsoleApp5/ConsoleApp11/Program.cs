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
            6.	В массиве вещественных чисел найти количество отрицательных элементов.
            */
            Console.WriteLine("Задание 1.");
            double[] mas1 = new double[10];
            int count1 = 0;
            
            Console.WriteLine("Массив: ");
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
            6.	сумму элементов массива, расположенных между первым и последним нулевыми элементами;
            */
            Console.WriteLine("Задание 2.");
            int[] mas2 = new int[39];
            int nul1 = 0, nul2 = 0, sum2 = 0;
            Boolean g = true;
            for (int i = 0; i < 39; i++)
            {                
                mas2[i] = rand.Next(0, 10);
                Console.Write("{0} ", mas2[i]);
                if (mas2[i] == 0 && g == true)
                {
                    nul1 = i;
                    g = false;
                }
                else if (mas2[i] == 0)
                {
                    nul2 = i;
                }
            }
            Console.WriteLine();

            for (int i = nul1 + 1; i < nul2; i++)
                sum2 += mas2[i];
            Console.WriteLine("Сумма элементов массива, расположенных между первым и последним нулевыми элементами: {0}", sum2);
            Console.WriteLine();

            /*
            Задание 3.
            6.	среднемесячную температуру первой и второй декады декабря;
            */
            Console.WriteLine("Задание 3.");
            int[] mas3 = new int[31];
            double sr3_1 = 0, sr3_2 = 0, sum3_1 = 0, sum3_2 = 0;
            for (int i = 0; i < mas3.Length; i++)
            {
                mas3[i] = rand.Next(-30, 10);
                Console.Write("День {0}: {1} ", i + 1, mas3[i]);
                if (i < 11)
                    sum3_1 += mas3[i];
                else if (i < 21)
                    sum3_2 += mas3[i];
            }
            Console.WriteLine();

            sr3_1 = sum3_1 / 10;
            sr3_2 = sum3_2 / 10;

            Console.WriteLine("Среднемесячная температура первой и второй декады декабря соответсвенно: {0} и {1}", sr3_1, sr3_2);
            Console.WriteLine();

            /*
           Задание 4.
           6.	Пусть даны целые числа а1, ..., а100. Получите новую последовательность из 100 целых чисел, заменяя аi - нулями, 
           если значение Math.Abs(ai) не равно максимальному из а1, ..., а100, и заменяя аi, единицей - в противном случае (i = 1,..., 100).
           */
            Console.WriteLine("Задание 4.");
            int[] mas4 = new int[100];
            int max4 = 0;

            //Заводим массив
            Console.WriteLine("Массив:");
            for (int i = 0; i < mas4.Length; i++) 
            {
                mas4[i] = rand.Next(-9, 10);
                Console.Write("{0} ", mas4[i]);
                if (max4 < mas4[i])                
                    max4 = mas4[i];
            }
            Console.WriteLine();

            Console.WriteLine("Новый массив:");
            for (int i = 0; i < mas4.Length; i++)
            {
                if (Math.Abs(mas4[i]) == max4)
                    mas4[i] = 0;
                else
                    mas4[i] = 1;
                Console.Write("{0} ", mas4[i]);
            }
            Console.WriteLine();
            Console.WriteLine();

            /*
            Задание 5.
            Дан одномерный массив из действительных чисел.
            6.	Все его элементы увеличить в 2 раза;
            */
            Console.WriteLine("Задание 5.");
            int[] mas5 = new int[10];

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
                mas5[i] *= 2;
                Console.Write("{0} ", mas5[i]);
            }
            Console.WriteLine();

            Console.WriteLine();

            /*
            Задание 6.
            Решите задачу. 
            6.	Известны стоимости нескольких марок легковых автомобилей и мотоциклов. 
            Верно ли что средняя стоимость автомобилей превышает среднюю стоимость мотоциклов более чем в 3 раза? 
            Стоимость одного автомобиля превышает 5000, что больше стоимости любой марки мотоцикла.
            */
            Console.WriteLine("Задание 6.");
            int[] mas6_1 = new int[10];
            int[] mas6_2 = new int[10];
            double sum6_1 = 0, sr6_1 = 0, sum6_2 = 0, sr6_2 = 0;

            Console.WriteLine("Стоимость марок автомобилей: ");
            for (int i = 0; i < mas6_1.Length; i++)
            {
                mas6_1[i] = rand.Next(5000, 15000);
                Console.Write("{0} ", mas6_1[i]);
                sum6_1 += mas6_1[i];
            }
            Console.WriteLine();

            Console.WriteLine("Стоимость марок мотоциклов: ");
            for (int i = 0; i < mas6_2.Length; i++)
            {
                mas6_2[i] = rand.Next(1000, 4999);
                Console.Write("{0} ", mas6_2[i]);
                sum6_2 += mas6_2[i];
            }
            Console.WriteLine();

            sr6_1 = sum6_1 / mas6_1.Length;            
            Console.WriteLine("Средняя цена за марки автомобилей: " + sr6_1);
            sr6_2 = sum6_2 / mas6_2.Length;
            Console.WriteLine("Средняя цена за марки мотоциклов: " + sr6_2);

            if (sr6_1 > sr6_2 * 3)
                Console.WriteLine("Средняя стоимость автомобилей превышает среднюю стоимость мотоциклов более чем в 3 раза");
            else
                Console.WriteLine("Средняя стоимость автомобилей не превышает среднюю стоимость мотоциклов более чем в 3 раза");
            Console.WriteLine();

            /*
            Задание 7.
            6.	Найти в каждой строке матрицы А(8х10) максимальный и минимальный элементы. Матрицу вывести в виде таблицы.
            */
            Console.WriteLine("Задание 7.");
            int[,] mas7 = new int[8, 10];
            int max7 = 0, min7 = 10;

            //Задали матрицу
            Console.WriteLine("Матрица:");
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    mas7[i, j] = rand.Next(1, 10);
                    Console.Write("{0} ", mas7[i, j]);                    
                }
                Console.WriteLine();
            }

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (min7 > mas7[i, j])
                        min7 = mas7[i, j];
                    if (max7 < mas7[i, j])
                        max7 = mas7[i, j];
                }
                Console.WriteLine("Максимальный и минмальный элемент строки {0} соответсвенно: {1} и {2}", i, min7, max7);
                max7 = 0;
                min7 = 10;
            }
            Console.WriteLine();

            /*
            Задание 8.
            6.	Найти номер строки, в которой находится самая длинная серия одинаковых элементов.
            */
            Console.WriteLine("Задание 8.");
            int[,] array = new int[3, 7];
            int numberi = 0;

            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    array[i, j] = rand.Next(0, 5);

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                    Console.Write(array[i, j] + " ");
                Console.WriteLine();
            }

            var k = 0;
            var kMax = 1;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1) - 1; j++)
                {
                    if (array[i, j] == array[i, j + 1])
                    {
                        k++;
                        if (k > kMax)
                        {
                            kMax = k;
                            numberi = i;
                        }
                    }
                    else k = 1;
                }
            }

            Console.WriteLine("Максимальная последовательность одинаковых чисел имеет длину: {0}, строка нахождения: {1}", kMax, numberi);

            Console.WriteLine();

            /*
            Задание 9.
            Решите задачу. 
            6.	В двумерном массиве хранится информация о зарплате 18 человек за каждый месяц года 
            (за январь – в первом столбце, за февраль – во втором и т. д.). Определить общую зарплату, выплаченную в июне.
            */
            Console.WriteLine("Задание 9.");
            int[,] mas9 = new int[18, 12];
            int sum9 = 0;

            //Задали матрицу
            Console.WriteLine("Матрица:");
            for (int i = 0; i < 18; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    mas9[i, j] = rand.Next(100, 1000);
                    Console.Write("{0} ", mas9[i, j]);
                    if (i == 5)
                        sum9 += mas9[i, j];
                }
                Console.WriteLine();
            }

            Console.WriteLine("Общая зарплата за июнь: " + sum9);
            Console.WriteLine();

            /*
            Задание 10.
            6.	Составить программу нахождения номера столбца, в котором расположен минимальный элемент любой строки двумерного массива. 
            Если элементов с минимальным значением в этой строке несколько, то должен быть найден номер столбца самого левого из них.
            */
            Console.WriteLine("Задание 10.");
            int[,] mass = new int[7, 5];
            int imin10 = 0, min10 = 10, jmin10 = 0;

            for (int i = 0; i < mass.GetLength(0); i++)
            {
                for (int j = 0; j < mass.GetLength(1); j++)
                {
                    mass[i, j] = rand.Next(0, 10);
                    Console.Write("{0} ", mass[i, j]);
                    if (min10 > mass[i, j])
                    {
                        min10 = mass[i, j];
                        imin10 = i;
                        jmin10 = j;
                    }
                    else if (min10 == mass[i, j] && jmin10 > j)
                    {
                        imin10 = i;
                        jmin10 = j;
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("Минимальный элемент: {0}, его столбец: {1}", min10, jmin10);
            Console.WriteLine();

            /*
            Задание 11.
            6.	В поезде 18 вагонов, в каждом по 36 мест. Информация о проданных на поезд билетах хранится в двумерном массиве,
            номера строк которого соответствуют номерам вагонов, а номера столбцов – номерам мест. 
            Если билет на то или иное место продан, то соответствующий элемент массива имеет значение 1, в противном случае – 0. 
            Составить программу, определяющую, имеются ли свободные места в том или ином вагоне поезда.
            */
            Console.WriteLine("Задание 11.");
            int[,] mas11 = new int[18, 36];
            int sum11_1 = 0, sum11_2 = 0;

            //Задали матрицу
            Console.WriteLine("Матрица:");
            for (int i = 0; i < 18; i++)
            {
                for (int j = 0; j < 36; j++)
                {
                    mas11[i, j] = rand.Next(0, 2);
                    Console.Write("{0} ", mas11[i, j]);
                }
                Console.WriteLine();
            }

            Console.Write("Введите номер вагона: ");
            int number10 = int.Parse(Console.ReadLine());

            Console.WriteLine("Номера свободных мест в вагоне {0}: ", number10);
            for (int j = 0; j < 36; j++)
            {
                if (mas11[number10, j] == 0)
                    Console.Write("{0} ", j);
            }
            Console.WriteLine();

            Console.WriteLine();

            /*
            Задание 12.
            6.	К элементам k1-го столбца двумерного массива прибавить элементы k2-го столбца.
            */
            Console.WriteLine("Задание 12.");
            int[,] mas12 = new int[5, 5];

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

            Console.WriteLine("Введите номера двух столбцов: ");
            int x12 = int.Parse(Console.ReadLine());
            int y12 = int.Parse(Console.ReadLine());

            for (int i = 0; i < 5; i++)
                mas12[i, x12] += mas12[i, y12];

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
            6.	Значения элементов двумерного массива из m строк и n столбцов скопировать в одномерный массив размером m*n.
            Копирование проводить по строкам начиная с первой (а в ней – с крайнего левого элемента).
            */
            Console.WriteLine("Задание 13.");
            Console.WriteLine("Задайте количество строк и столбцов массива: ");
            int m = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            int[,] Arr = new int[m, n];
            int[] a = new int[m * n];
            int c = 0;

            Console.WriteLine("Матрица:");
            for (int i = 0; i < Arr.GetLength(0); i++)
            {
                for (int j = 0; j < Arr.GetLength(1); j++)
                {
                    Arr[i, j] = rand.Next(0, 10);
                    Console.Write("{0} ", Arr[i, j]);
                }
                Console.WriteLine();
            }

            for (int i = 0; i < Arr.GetLength(0); i++)
                for (int j = 0; j < Arr.GetLength(1); j++)
                {
                    a[c] = Arr[j, i];
                    c++;
                }
            
            Console.WriteLine("Массив: ");
            for (int j = 0; j < a.Length; j++)
            {
                Console.Write(a[j] + " ");
            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
