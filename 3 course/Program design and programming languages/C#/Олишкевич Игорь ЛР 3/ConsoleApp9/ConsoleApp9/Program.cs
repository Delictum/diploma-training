using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Program
    {
        public static int NOD(int a, int b)
        {
            if (a == b)
                return a;
            else
                if (a > b)
                return NOD(a - b, b);
            else
                return NOD(b - a, a);
        }

        static void Main(string[] args)
        {
            /*
            Задание 1            
                 {(x - 2)^2 + 6, 1 < x < 2
             y = {
                 {ln(x + 3 * sqrt(x)), x >= 2            
            */

            Console.WriteLine("Задание 1");
            start1: Console.Write("Введите х для промежутка (1; +∞): ");
            double y1 = 0, x1 = 0;
            x1 = double.Parse(Console.ReadLine());
            if (x1 >= 2)
            {
                y1 = Math.Log10(x1 + 3 * Math.Sqrt(x1));
            }
            else if (x1 > 1 && x1 < 2)
            {
                y1 = Math.Pow((x1 - 2), 2) + 6;
            }
            else
            {
                goto start1;
            }
            Console.WriteLine("y1 =  {0}", y1);
            Console.WriteLine();

            /*
            Задание 2
            Написать программу, которая определяет: кратна ли трем сумма цифр двухзначного числа.
            */

            Console.WriteLine("Задание 2");
            Console.WriteLine("Введите двухзначное число");
            string two = Console.ReadLine();
            double buf = two[0] + two[1] - 96;
            Console.WriteLine("Сумма цифр = {0}", buf);
            if (buf % 3 == 0)
            {
                Console.WriteLine("Сумма цифр кратна трем");
            }
            else
            {
                Console.WriteLine("Сумма цифр не кратна трем");
            }
            Console.WriteLine();

            /*
            Задание 3
            Дана точка на плоскости с координатами(х, у). 
            Составить программу, которая выдает одно из сообщений "Да", "Нет", "На границе" 
            в зависимости от того, лежит ли точка внутри заштрихованной области, 
            вне заштрихованной области или на ее границе.
            */
            Console.WriteLine("Задание 3");
           Console.Write("x=");
           double x3, y;
           x3 = double.Parse(Console.ReadLine());
           Console.Write("y=");
           y = double.Parse(Console.ReadLine());
           if (x3 < 50 && x3 > -50 && y < 25 && y > -25) 
                Console.WriteLine("Да");
            else if (((x3 == 50 || x3 == -50) && (y <= 25 && y >= -25)) || ((x3 <= 50 && x3 >= -50) && (y == 25 || y == -25)))
                Console.WriteLine("На границе");
            else Console.WriteLine("Нет");
            Console.WriteLine();

            /*
            Задание 4
            Составить программу(при решении данных задач использовать оператор switch или вложенные операторы if):
            С некоторой даты по настоящий день прошло n дней, найти неизвестную дату. 
            */
            int n, day4, month4, year4, all, day4new = 0, month4new = 0, year4new = 0;
            Console.WriteLine("Задание 4");            
            Console.Write("Введите количество пройденных дней: n = ");
            n = Int32.Parse(Console.ReadLine());

            DateTime dateGregorian = DateTime.Today;
            day4 = dateGregorian.Day;
            month4 = dateGregorian.Month;
            year4 = dateGregorian.Year;
            all = day4 + month4 * 30 + year4 * 365 - n;

            if (all > 365)
            {
                year4new = all / 365;
                all = all - year4new * 365;
            }
            if (all > 30)
            {
                month4new = all / 30;
                day4new = all - month4new * 30;
            }
            if (day4new == 0)
            {
                day4new = 30;
                month4new = month4new - 1;
            }

            Console.WriteLine("Полученная дата: {0:00}.{1:00}.{2:0000}", day4new, month4new, year4new);
            Console.WriteLine();

            /*
            Задание 5            
            Составить программу решения задачи:
            В соревнованиях по фигурному катанию N судей независимо выставляют оценки спортсмену. 
            Затем из объявленных оценок удаляют самую высокую (одну, если самую высокую оценку выставили несколько судей). 
            Аналогично поступают с самой низкой оценкой. Для оставшихся оценок вычисляется среднее арифметическое, 
            которое и становится зачетной оценкой. По заданным оценкам судей определить зачетную оценку спортсмена.
            */
            Console.WriteLine("Задание 5");
            int bufMax, bufMin;
            double srednee;
            Console.Write("Введите кол-во судей: ");
            int N = Int32.Parse(Console.ReadLine());
            int[] Ocenki = new int[N];
            Random rand = new Random();
            srednee = 0;
            for (int i = 0; i < N; i++) //Задаем случайные оценки и выводим на экран, подсчитываем общую сумму оценок
            {                
                Ocenki[i] = rand.Next(0, 6);
                Console.Write("{0} ", Ocenki[i]);
                srednee += Ocenki[i];
            }
            int maxValue = Ocenki.Max<int>(); //Находим мин и макс
            int minValue = Ocenki.Min<int>();
            Console.WriteLine();

            bufMax = 0;
            bufMin = 0;
            for (int i = 0; i < N; i++) 
            {
                if (maxValue == Ocenki[i])
                    bufMax += 1;
                if (minValue == Ocenki[i])
                    bufMin += 1;
            }
            if (bufMax > 1)
            {
                srednee = srednee - maxValue * bufMax;
                N = N - bufMax;
            }

            if (bufMin > 1)
            {
                srednee = srednee - minValue * bufMin;
                N = N - bufMin;
            }
            srednee = srednee / N;
            Console.WriteLine("Зачетная оценка: {0}", srednee);
            Console.WriteLine();

            /*
            Задание 6
            Составить программу решения задачи:
            По дате (месяц и день) рождения определите знак Зодиака.
            */
            string month, day, zodiak = "";
            Console.WriteLine("Задание 6");
            Console.Write("Введите месяц: ");
            month = Console.ReadLine();
            Console.Write("Введите день: ");
            day = Console.ReadLine();
            Console.WriteLine();

            if ((Convert.ToInt32(day) > 20 && Convert.ToInt32(month) == 3) | (Convert.ToInt32(day) < 21 && Convert.ToInt32(month) == 4))
            {
                zodiak = "Овен";
            }
            else if ((Convert.ToInt32(day) > 20 && Convert.ToInt32(month) == 4) | (Convert.ToInt32(day) < 22 && Convert.ToInt32(month) == 5))
            {
                zodiak = "Телец";
            }
            else if ((Convert.ToInt32(day) > 21 && Convert.ToInt32(month) == 5) | (Convert.ToInt32(day) < 22 && Convert.ToInt32(month) == 6))
            {
                zodiak = "Близнецы";
            }
            else if ((Convert.ToInt32(day) > 21 && Convert.ToInt32(month) == 6) | (Convert.ToInt32(day) < 24 && Convert.ToInt32(month) == 7))
            {
                zodiak = "Рак";
            }
            else if ((Convert.ToInt32(day) > 23 && Convert.ToInt32(month) == 7) | (Convert.ToInt32(day) < 24 && Convert.ToInt32(month) == 8))
            {
                zodiak = "Лев";
            }
            else if ((Convert.ToInt32(day) > 23 && Convert.ToInt32(month) == 8) | (Convert.ToInt32(day) < 24 && Convert.ToInt32(month) == 9))
            {
                zodiak = "Дева";
            }
            else if ((Convert.ToInt32(day) > 23 && Convert.ToInt32(month) == 9) | (Convert.ToInt32(day) < 24 && Convert.ToInt32(month) == 10))
            {
                zodiak = "Весы";
            }
            else if ((Convert.ToInt32(day) > 23 && Convert.ToInt32(month) == 10) | (Convert.ToInt32(day) < 23 && Convert.ToInt32(month) == 11))
            {
                zodiak = "Скорпион";
            }
            else if ((Convert.ToInt32(day) > 22 && Convert.ToInt32(month) == 11) | (Convert.ToInt32(day) < 22 && Convert.ToInt32(month) == 12))
            {
                zodiak = "Стрелец";
            }
            else if ((Convert.ToInt32(day) > 21 && Convert.ToInt32(month) == 12) | (Convert.ToInt32(day) < 21 && Convert.ToInt32(month) == 1))
            {
                zodiak = "Козерог";
            }
            else if ((Convert.ToInt32(day) > 20 && Convert.ToInt32(month) == 1) | (Convert.ToInt32(day) < 20 && Convert.ToInt32(month) == 2))
            {
                zodiak = "Водолей";
            }
            else 
            {
                zodiak = "Рыба";
            }         
            
            Console.WriteLine("Ваш знак задиака: {0}", zodiak);
            Console.WriteLine();

            /*
            Задание 7
            Даны цифры двух целых чисел: двузначного а2а1 и однозначного b, где а1 – число единиц, а2 – число десятков. 
            Получить цифры числа, равного сумме заданных чисел (известно, что это число двузначное). 
            Слагаемое – двузначное число и число-результат не определить; условный оператор не использовать.
            */
            Console.WriteLine("Задание 7");
            int a1, a2, b, c1, c2;
            Console.Write("Введите a2: ");
            a2 = Int32.Parse(Console.ReadLine());

            Console.Write("Введите a1: ");
            a1 = Int32.Parse(Console.ReadLine());
            
            Console.Write("Введите b: ");
            b = Int32.Parse(Console.ReadLine());
            if (a1 + b >= 10)
            {
                c1 = a1 + b - 10;
                c2 = a2 + 1;                
            }
            else
            {
                c1 = a1 + b;
                c2 = a2;
            }
            Console.WriteLine("Цифры полученного числа: {0}, {1}", c2, c1);
            Console.WriteLine();

           /*
           Задание 8
           Вывести на экран (задачу решите тремя способами - используя операторы цикла while, do while и for):
           Только положительные целые числа из диапазона от А до В ( );
           */
           Console.WriteLine("Задание 8");
            Console.Write("Задайте диапазон от A: ");
            int A = Int32.Parse(Console.ReadLine());
            Console.Write(" до B: ");
            int B = Int32.Parse(Console.ReadLine());

            int temp = A;
            for (int i = A; i < B; i++)
            {                
                if (temp > 0)
                {
                    Console.Write("{0} ", temp);
                }
                temp += 1;
            }
            Console.WriteLine();

            temp = A;
            while (temp < B)
            {
                if (temp > 0)
                {
                    Console.Write("{0} ", temp);
                }
                temp += 1;
            }
            Console.WriteLine();

            temp = A;
            do
            {
                if (temp > 0)
                {
                    Console.Write("{0} ", temp);
                }
                temp += 1;
            }
            while (temp < B);
            Console.WriteLine();

            /*
            Задание 9
            Вывести на экран числа следующим образом:
            1
            1 2
            1 2 3
            1 2 3 4
            1 2 3 4 5
            */
            Console.WriteLine("Задание 9");
            for (int i = 1; i < 7; i++)
            { 
                for (int j = 1; j < i; j++)
                {
                    Console.Write("{0} ", j);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            /*
            Задание 10
            Решите задачу:
            Дано натуральное число n. 
            Получить все натуральные числа, меньшие n и взаимно простые с ним 
            (два натуральных числа называются взаимно простыми, если их наибольший общий делитель равен 1).
            */
            Console.WriteLine("Задание 10");
            Console.Write("Введите n: ");
            int n10 = Int32.Parse(Console.ReadLine());
            HashSet<int> primes = new HashSet<int>(Enumerable.Range(2, n10 - 1));            
            for (int i10 = 2; i10 < n10; i10++)
            {
                if (primes.Contains(i10))
                {
                    primes.RemoveWhere(x => x > i10 && x % i10 == 0);
                }
            }            

            primes.Remove(2);
            Console.Write("1, ");
            Console.WriteLine(String.Join(", ", primes));
            Console.WriteLine();

            /*
            Задание 11
            Дано натуральное число. Определить:
            Сколько раз в нем встречаются цифры х и у;
            */
            Console.WriteLine("Задание 11");
                string nat, x11, y11;
                Console.Write("Введите натуральное число: ");
                nat = Console.ReadLine();
                Console.Write("Введите x: ");
                x11 = Console.ReadLine();
                Console.Write("Введите y: ");
                y11 = Console.ReadLine();
                int count;
                count = (nat.Length - nat.Replace(x11, "").Length) / x11.Length;
                count = count + (nat.Length - nat.Replace(y11, "").Length) / y11.Length;

                Console.WriteLine("Символы встречаются: {0}", count);
            Console.WriteLine();

            /*
            Задание 12
            Решите задачу:
            Известны оценки каждого из студентов университета по физике. 
            Посчитать количество пятерок, количество четверок, количество троек и количество двоек.
            */
            Console.WriteLine("Задание 12");
            Console.Write("Введите количество студентов: ");
            int students = Int32.Parse(Console.ReadLine());
            int[] Students = new int[students];
            Random rand12 = new Random();
            int o5 = 0, o4 = 0, o3 = 0, o2 = 0;
            for (int i12 = 0; i12 < students; i12++)
            {
                Students[i12] = rand12.Next(0, 6);
                Console.Write("{0} ", Students[i12]);
                if (Students[i12] == 5)
                {
                    o5++;
                }
                if (Students[i12] == 4)
                {
                    o4++;
                }
                if (Students[i12] == 3)
                {
                    o3++;
                }
                if (Students[i12] == 2)
                {
                    o2++;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Количество 5 = {0}, 4 = {1}, 3 = {2}, 2 = {3}", o5, o4, o3, o2);
    Console.ReadKey();
        }
    }
}
