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
            17.	Найти количество и сумму положительных элементов в массиве вещественных чисел, удовлетворяющих условию 0<xi<5,7.
            */
            Console.WriteLine("Задание 1.");
            double[] mas1 = new double[10];
            int count1 = 0;
            double sum1 = 0;

            Console.WriteLine("Массив: ");
            for (int i = 0; i < mas1.Length; i++)
            {
                mas1[i] = rand.Next(-5, 10);
                Console.Write("{0} ", mas1[i]);
                if (mas1[i] > 0 && mas1[i] < 5.7)
                {
                    count1++;
                    sum1 += mas1[i];
                }
            }
            Console.WriteLine();

            Console.WriteLine("Количество и сумма положительных элементов в массиве вещественных чисел, удовлетворяющих условию 0 < xi < 5,7:\n{0}\n{1}", count1, sum1);
            Console.WriteLine();

            /*
            Задание 2.
            17.	сумму элементов массива, расположенных между первым и вторым положительными элементами;
            */
            Console.WriteLine("Задание 2.");
            int[] mas2 = new int[20];
            int plus1 = 0, plus2 = 0, sum2 = 0;
            Boolean g1 = true, g2 = true;
            for (int i = 0; i < 20; i++)
            {
                mas2[i] = rand.Next(-9, 5);
                Console.Write("{0} ", mas2[i]);
                if (mas2[i] > 0 && g1 == true)
                {
                    plus1 = i;
                    g1 = false;
                }
                else if (mas2[i] > 0 && g2 == true)
                {
                    plus2 = i;
                    g2 = false;
                }
            }
            Console.WriteLine();

            for (int i = plus1 + 1; i < plus2; i++)
                sum2 += mas2[i];
            Console.WriteLine("Сумма элементов массива, расположенных между первым и последним нулевыми элементами: {0}", sum2);
            Console.WriteLine();

            /*
            Задание 3.
            17.	среднюю температуру тех дней, которые предшествуют первому из самых холодных дней в декабре;
            */
            Console.WriteLine("Задание 3.");
            int[] mas3 = new int[31];
            double sr3 = 0, sum3 = 0, min3 = 10, imin3 = 0;
            int count3 = 0;
            for (int i = 0; i < mas3.Length; i++)
            {
                mas3[i] = rand.Next(-30, 10);
                Console.Write("День {0}: {1} ", i + 1, mas3[i]);
                if (min3 > mas3[i])
                {
                    min3 = mas3[i];
                    imin3 = i;
                }
            }
            Console.WriteLine();

            for (int i = 0; i < imin3; i++)
            {
                sum3 += mas3[i];
                count3++;
            }

            sr3 = sum3 / count3;

            Console.WriteLine("Средня температура тех дней, которые предшествуют первому из самых холодных дней в декабре (день номер {0} - его температура {1}): {2}", imin3 + 1, min3, sr3);
            Console.WriteLine();

            /*
           Задание 4.
           17.	Пусть даны натуральные числа n, а1, ..., аn. Определите количество членов ак последовательности а1, ..., аn,
           удовлетворяющих условию: ak < (ak-1 + ak+1) / 2;
           */
            Console.WriteLine("Задание 4.");
            Console.Write("Введите количество членов последовательности n: ");
            int n4 = int.Parse(Console.ReadLine());
            int[] mas4 = new int[n4];
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
            for (int i = 1; i < mas4.Length - 1; i++)
            {
                if (mas4[i] < (mas4[i - 1] + mas4[i + 1]) / 2)
                    Console.Write("{0} ", mas4[i]);
            }
            Console.WriteLine();
            Console.WriteLine();

            /*
            Задание 5.
            17.	Все элементы с нечетными номерами увеличить на 1, с четными – уменьшить на 1;
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
                if (mas5[i] % 2 == 0)
                    mas5[i] -= 1;
                else
                    mas5[i] += 1;
                Console.Write("{0} ", mas5[i]);
            }
            Console.WriteLine();

            Console.WriteLine();

            /*
            Задание 6.
            Решите задачу. 
            17.	При выборе места строительства жилого комплекса при металлургическом комбинате необходимо учитывать «розу ветров» 
            (следует расположить жилой комплекс так, чтобы частота ветра со стороны металлургического комбината была бы минимальной). 
            Для этого в течение года проводилась регистрация направления ветра в районе строительства. Данные представлены в виде массива, 
            в котором направление ветра за каждый день кодируется следующим образом: 
            1 – северный, 2 – южный, 3 – восточный, 4 – западный, 5 – ceверо-западный, 6 – северо-восточный, 7 – юго-западный, 8 – юго-восточный. 
            Определить, как должен быть расположен жилой комплекс по отношению к комбинату.
            */
            Console.WriteLine("Задание 6.");
            string[] mas6 = new string[8];
            mas6[0] = "северный"; mas6[1] = "южный"; mas6[2] = "восточный"; mas6[3] = "западный";
            mas6[4] = "ceверо-западный"; mas6[5] = "северо-восточный"; mas6[6] = "юго-западный"; mas6[7] = "юго-восточный";
            int countS = 0, countZ = 0, countW = 0, countY = 0;
            string strS = "север", strZ = "запад", strW = "вост", strY = "ю";

            for (int i = 0; i < mas6.Length; i++)
            {
                if (mas6[i].Contains(strS) == true)
                    countS++;
                else if (mas6[i].Contains(strZ) == true)
                    countZ++;
                else if (mas6[i].Contains(strW) == true)
                    countW++;
                else if (mas6[i].Contains(strY) == true)
                    countY++;
            }

            Console.WriteLine("Частота по годам за всё время:\nСевер - {0}, запад - {1}, восток - {2}, юг - {3}", countS, countZ, countW, countY);

            Console.Write("Наименьшая частота ветра ");
            if (countS <= countW && countS <= countY && countS <= countZ)
                Console.Write("на севере ");
            if (countZ <= countW && countZ <= countY && countZ <= countS)
                Console.Write("на западе ");
            if (countW <= countZ && countW <= countY && countW <= countS)
                Console.Write("на востоке ");
            if (countY <= countW && countY <= countZ && countY <= countS)
                Console.Write("на юге ");

            Console.WriteLine();

            /*
            Задание 7.
            17.	Определить число четных элементов матрицы А(10х6).
            */
            Console.WriteLine("Задание 7.");
            int[,] mas7 = new int[10, 6];
            int count7 = 0;

            //Задали матрицу
            Console.WriteLine("Матрица:");
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    mas7[i, j] = rand.Next(0, 10);
                    Console.Write("{0} ", mas7[i, j]);
                    if (mas7[i, j] % 2 == 0)
                        count7++;
                }
                Console.WriteLine();
            }

            Console.WriteLine("Количество четных элементов матрицы: {0}", count7);
            Console.WriteLine();

            /*
            Задание 8.
            17.	В сглаженной матрице найти сумму модулей элементов, расположенных ниже главной диагонали
            */
            Console.WriteLine("Задание 8.");
            int n8 = 5;
            double[,] m1 = new double[n8, n8];
            double[,] m2 = new double[n8, n8];
            double s = 0;

            Console.WriteLine("Матрица:");
            for (int i = 0; i < n8; i++)
            {
                for (int j = 0; j < n8; j++)
                {
                    m1[i, j] = rand.Next(1, 10);
                    Console.Write("{0} ", m1[i, j]);
                }
                Console.WriteLine();
            }

            for (int i = 1; i < n8 - 1; i++)
                for (int j = 1; j < n8 - 1; j++)
                {
                    s = (m1[i, j] + m1[i - 1, j] + m1[i + 1, j] + m1[i, j - 1] + m1[i, j + 1] + m1[i - 1, j - 1] + m1[i - 1, j + 1] + m1[i + 1, j - 1] + m1[i + 1, j + 1]) / 9;
                    m2[i - 1, j - 1] = s;
                }

            Console.WriteLine("Сглаженная матрица:");
            for (int i = 0; i < n8 - 2; i++)
            {
                for (int j = 0; j < n8 - 2; j++)
                    Console.Write("{0:0.0} ", m2[i, j]);
                Console.WriteLine();
            }

            s = 0;
            for (int i = 0; i < n8 - 2; i++)
                for (int j = 0; j < i; j++)
                    s += m2[i, j];

            Console.WriteLine("Сумма = " + s);
            Console.WriteLine();

            /*
            Задание 9.
            Решите задачу. 
            17.	В двумерном массиве хранится информация о количестве студентов в той или иной группе каждого курса института с первого по пятый 
            (в первой строке – информация о группах первого курса, во второй – второго и т.д.). На каждом. курсе имеется 8 групп. 
            Определить среднее число студентов в одной группе.
            */
            Console.WriteLine("Задание 9.");
            int[,] mas9 = new int[5, 8];
            int sum9 = 0, sr9 = 0;

            //Задали матрицу
            Console.WriteLine("Матрица:");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    mas9[i, j] = rand.Next(12, 36);
                    Console.Write("{0} ", mas9[i, j]);
                    sum9 += mas9[i, j];
                }
                Console.WriteLine();
            }

            sr9 = sum9 / 40;

            Console.WriteLine("Среднее число студентов в одной группе: " + sr9);
            Console.WriteLine();

            /*
            Задание 10.
            17.	Информация о количестве жильцов и каждой из четырех квартир каждого этажа 12-этажного дома хранится в двумерном массиве 
            (в первой строке – информация о квартирах первого этажа, во второй – второго и т.д.). Определить на каком этаже проживает меньше всего людей.
            */
            Console.WriteLine("Задание 10.");
            int[,] mas10_1 = new int[12, 4];
            int[] mas10_2 = new int[12];
            int sum10 = 0, imin10 = 0;

            Console.WriteLine("Матрица:");
            for (int i = 0; i < mas10_1.GetLength(0); i++)
            {
                for (int j = 0; j < mas10_1.GetLength(1); j++)
                {
                    mas10_1[i, j] = rand.Next(1, 7);
                    Console.Write("{0} ", mas10_1[i, j]);
                    mas10_2[i] += mas10_1[i, j];
                }
                Console.WriteLine();
            }

            for (int i = 0; i < mas10_1.GetLength(0); i++)
            {
                for (int j = 0; j < mas10_1.GetLength(1); j++)
                {
                    sum10 += mas10_1[i, j];
                }
                if (mas10_2.Min() == sum10)
                    imin10 = i;
            }

            Console.WriteLine("Минимальное количество жильцов проживает на {0} этаже", imin10 + 1);

            Console.WriteLine();

            /*
            Задание 11.
            17.	Фирма имеет 10 магазинов. Информация о доходе каждого магазина за каждый месяц года хранится в двумерном массиве.
            Верно ли, что общий доход фирмы за год превысил некоторое заданное число
            */
            Console.WriteLine("Задание 11.");
            int[,] mas11 = new int[10, 12];
            int sum11 = 0;

            //Задали матрицу
            Console.WriteLine("Матрица:");
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    mas11[i, j] = rand.Next(1000, 10000);
                    Console.Write("{0} ", mas11[i, j]);
                    sum11 += mas11[i, j];
                }
                Console.WriteLine();
            }

            Console.Write("Введите число: ");
            int number11 = int.Parse(Console.ReadLine());

            if (sum11 < number11)
                Console.WriteLine("Неверно - общий доход фирмы за год не превысил некоторое заданное число");
            else
                Console.WriteLine("Верно - общий доход фирмы за год превысил некоторое заданное число");

            Console.WriteLine();

            /*
            Задание 12.
            17.	В каждой строке двумерного массива поменять местами первый нулевой элемент и последний отрицательный. 
            Если таких элементов нет, то должно быть выдано соответствующее сообщение.
            */
            Console.WriteLine("Задание 12.");
            int[,] mas12 = new int[5, 5];
            Boolean b1 = true, nk1 = false, nk2 = false;
            int k1 = 0, k2 = 0;

            //Задали матрицу
            Console.WriteLine("Исходная матрица: ");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    mas12[i, j] = rand.Next(-3, 4);
                    Console.Write("{0} ", mas12[i, j]);
                }
                Console.WriteLine();
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (mas12[i, j] == 0 && b1 == true)
                    {
                        b1 = false;
                        k1 = j;
                        nk1 = true;
                    } 

                    if (mas12[i, j] < 0)
                    {
                        k2 = j;
                        nk2 = true;
                    }
                }

                if (nk1 == true && nk2 == true)
                {
                    int buf = mas12[i, k1];
                    mas12[i, k1] = mas12[i, k2];
                    mas12[i, k2] = buf;
                }
                else
                    Console.WriteLine("В строке {0} нет необходимого элемента", i);

                b1 = true;
                nk1 = false;
                nk2 = false;
            }

            Console.WriteLine("Новая матрица: ");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write("{0} ", mas12[i, j]);
                }
                Console.WriteLine();
            }


            Console.WriteLine();

            /*
            Задание 13.
            Работа с несколькими массивами. 
            17.	Дан двумерный массив. Сформировать одномерный массив, 
            каждый элемент которого равен сумме элементов соответствующей строки двумерного массива, меньших данного числа.
            */
            Console.WriteLine("Задание 13.");            

            int[,] mas13 = new int[5, 5];
            int[] a = new int[5];
            int c = 0, sum13 = 0;

            Console.Write("Задайте число: ");
            int n13 = int.Parse(Console.ReadLine());

            Console.WriteLine("Матрица:");
            for (int i = 0; i < mas13.GetLength(0); i++)
            {
                for (int j = 0; j < mas13.GetLength(1); j++)
                {
                    mas13[i, j] = rand.Next(0, 10);
                    Console.Write("{0} ", mas13[i, j]);
                }
                Console.WriteLine();
            }

            for (int i = 0; i < mas13.GetLength(0); i++)
            {
                for (int j = 0; j < mas13.GetLength(1); j++)
                    sum13 += mas13[i, j];
                if (sum13 < n13)
                {
                    a[c] = sum13;
                    c++;
                }
                sum13 = 0;
            }
            
            Console.WriteLine("Массив: ");
            for (int j = 0; j < c; j++)
            {
                Console.Write(a[j] + " ");
            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
