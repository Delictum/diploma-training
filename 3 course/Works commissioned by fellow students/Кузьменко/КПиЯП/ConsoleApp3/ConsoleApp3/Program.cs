using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
             * Задание 1
             *     {Math.PI * Math.Pow(x, 2) - 7 / Math.Sqrt(Math.Abs(x));
             * y = {
             *     {3 * x - Math.Pow(Math.Cos(x), 2)
             */
            Console.WriteLine("Задание 1");
            Console.Write("Введите x: ");
            back1: double x1 = double.Parse(Console.ReadLine());
            if (x1 < Math.PI)
                Console.WriteLine(x1 + 2 * x1 * Math.Sin(3 * x1));
            else if (x1 > Math.PI)
                Console.WriteLine(Math.Cos(x1) + 2);
            else
                goto back1;
            Console.WriteLine();

            /* 
             * Задание 2
             * Является ли сумма цифр двухзначного числа четной 
             */
            Console.WriteLine("Задание 2");
            Console.Write("Введите целое число: ");
            string x2 = Console.ReadLine();
            int result = Convert.ToInt32(x2[0].ToString()) + Convert.ToInt32(x2[1].ToString());
            if (result % 2 == 0)
            {
                Console.WriteLine("Число чётное");
            }
            else
            {
                Console.WriteLine("Число не чётное");
            }
            Console.WriteLine();

            /* 
             * Задание 3
             * Дана точка на плоскости с координатами (х, у). 
             * Составить программу, которая выдает одно из сообщений "Да", "Нет", "На границе" 
             * в зависимости от того, лежит ли точка внутри заштрихованной области, вне заштрихованной области или на ее границе. 
            */
            Console.WriteLine("Задание 3");
            Console.WriteLine("Введите точку по x и y соответственно:");
            double x3 = Convert.ToDouble(Console.ReadLine());
            double y3 = Convert.ToDouble(Console.ReadLine());

            if (y3 < 12 && y3 > 0 && x3 < (x3 * Math.Sqrt(2)) && x3 > -(x3 * Math.Sqrt(2)))
                Console.WriteLine("Да");
            else if (y3 == 12 && x3 == (x3 * Math.Sqrt(2)) | x3 == -(x3 * Math.Sqrt(2)) || y3 == 0 && x3 == (x3 * Math.Sqrt(2)) | x3 > -(x3 * Math.Sqrt(2)))
                Console.WriteLine("На границе");
            else
                Console.WriteLine("Нет");
            Console.WriteLine();

            /* 
             * Задание 4
             * С некоторой даты по настоящий день прошло m месяцев, определить название месяца неизвестной даты. 
             */
            int n, month4, year4, all, month4new = 0;
            Console.WriteLine("Задание 4");
            Console.Write("Введите количество пройденных месяцев: m = ");
            n = Int32.Parse(Console.ReadLine());

            DateTime dateGregorian = DateTime.Today;
            month4 = dateGregorian.Month;
            year4 = dateGregorian.Year;
            all = month4 + year4 * 12 - n;

            month4new = all % 12;

            if (month4new == 1)
                Console.WriteLine("Январь");
            else if (month4new == 2)
                Console.WriteLine("Февраль");
            else if (month4new == 3)
                Console.WriteLine("Март");
            else if (month4new == 4)
                Console.WriteLine("Апрель");
            else if (month4new == 5)
                Console.WriteLine("Май");
            else if (month4new == 6)
                Console.WriteLine("Июнь");
            else if (month4new == 7)
                Console.WriteLine("Июль");
            else if (month4new == 8)
                Console.WriteLine("Август");
            else if (month4new == 9)
                Console.WriteLine("Сентябрь");
            else if (month4new == 10)
                Console.WriteLine("Октябрь");
            else if (month4new == 11)
                Console.WriteLine("Ноябрь");
            else if (month4new == 12)
                Console.WriteLine("Декабрь");
            else
                Console.WriteLine("Ошибка");

            Console.WriteLine();

            /* 
             * Задание 5
             * Даны три числа. Выбрать те из них, которые принадлежат заданному отрезку [e, f]. 
             */
            Console.WriteLine("Задание 5");
            Console.WriteLine("Введите A, B и C:");
            int A5 = int.Parse(Console.ReadLine());
            int B5 = int.Parse(Console.ReadLine());
            int C5 = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите e и f:");
            int e5 = int.Parse(Console.ReadLine());
            int f5 = int.Parse(Console.ReadLine());

            for (int i = e5; i <= f5; i++)
            {
                if (i == A5)
                    Console.WriteLine("A принадлежит отрезку");
                if (i == B5)
                    Console.WriteLine("B принадлежит отрезку");
                if (i == C5)
                    Console.WriteLine("C принадлежит отрезку");
            }
            /* 
             * Задание 6
             * С автостанции автобусы отправляются по 16 маршрутам и переезжают через реку по 4-м мостам:
             * 1, 2, 3, 5 - по Южному, 4, 6, 7, 8 - по Центральному, 9, 10, 11, 12 - по Северному, 13, 14, 15, 16 - по Окружному. 
             * Ввести с клавиатуры номер маршрута. Определить, по какому мосту он пойдет.
             */
            Console.WriteLine("Задание 6");
            Console.WriteLine("Введите номер маршрута от 1 до 16:");
            back6: int n6 = int.Parse(Console.ReadLine());
            if (n6 < 1 | n6 >= 17)
                goto back6;
            if (n6 <= 3 | n6 == 5)
                Console.WriteLine("По Южному");
            else if (n6 >= 6 && n6 <= 8 | n6 == 4)
                    Console.WriteLine("По Центральному");
            else if (n6 >= 9 && n6 <= 12)
                Console.WriteLine("По Северному");
            else
                Console.WriteLine("По Окружному");
            Console.WriteLine();

            /* 
             * Задание 7
             * В трехзначном числе х зачеркнули его последнюю цифру. 
             * Когда в оставшимся двузначном числе переставили цифры, а затем приписали к ним слева последнюю цифру числа х, 
             * то получилось число 654. Найти число х.
             */
            Console.WriteLine("Задание 7");
            string x7 = "654";
            string x7_1 = x7.Substring(1, 2) + x7.Substring(0, 1);
            string x7_2 = x7_1.Substring(1, 1) + x7_1.Substring(0, 1) + x7_1.Substring(2, 1);
            Console.WriteLine("Первоначальное число было: {0}", x7_2);
            Console.WriteLine();

            /* 
             * Задание 8
             * Все целые числа из диапазона от А до В (A <= B), оканчивающиеся на цифру Х или У;   
             */
            Console.WriteLine("Задание 8");
            Console.Write("Введите A: ");
            int A8 = int.Parse(Console.ReadLine());
            Console.Write("Введите B: ");
            int B8 = int.Parse(Console.ReadLine());
            Console.Write("Введите x: ");
            string x8 = Console.ReadLine();
            Console.Write("Введите y: ");
            string y8 = Console.ReadLine();

            for (int i = A8; i <= B8; i++)
            {
                string temp = Convert.ToString(i);
                if (temp.Substring(temp.Length - 1, 1) == x8 | temp.Substring(temp.Length - 1, 1) == y8)
                    Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            /* 
             * Задание 9
             * 7
             * 6 6
             * 5 5 5
             * 4 4 4 4
             * 3 3 3 3 3
             */
            Console.WriteLine("Задание 9");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j <= i; j++)
                    Console.Write("{0} ", 7 - i);
                Console.WriteLine();
            }
            Console.WriteLine();

            /* 
             * Задание 10
             * Дано натуральное число n. Напечатать разложение этого числа на простые множители. 
             * Реализовать вариант каждый простой множитель должен быть напечатан столько раз сколько раз он входит в разложение.  
            */
            Console.WriteLine("Задание 10");
            Console.WriteLine("Введите натуральное число: ");
            int b = int.Parse(Console.ReadLine());
            List<int> ls = new List<int>();
            bool[] table = new bool[b + 1];

            for (int i = 0; i < table.Length; i++)
                table[i] = true;

            for (int i = 2; i * i < table.Length; i++)
                if (table[i])
                    for (int j = 2 * i; j < table.Length; j += i)
                        table[j] = false;

            for (int i = 1; i < table.Length; i++)
                if (table[i])
                {
                    if (i >= 1)
                        ls.Add(i);
                }

            bool results = false;
            List<int> lstemp1 = new List<int>();
            List<int> lstemp2 = new List<int>();
            foreach (int nn in ls)
            {
                if (b % n == 0)
                {
                    results = true;
                    lstemp1.Add(nn);

                }
            }

            foreach (int n1 in lstemp1)
            {
                foreach (int n2 in lstemp1)
                {

                    if (n1 * n2 <= b && !lstemp2.Contains(n1))
                    {
                        lstemp2.Add(n1);
                    }

                }

            }

            Console.Write("\nЧисло {0} состоит из простых множетелей -> ", b);
            foreach (int nn in lstemp2) Console.Write(nn + "; ");
            Console.WriteLine();
            Console.WriteLine();

            /* 
             * Задание 11
             * Дано натуральное число. Количество его цифр кратных z (значение z вводится с клавиатуры;  z = 2, 3, 4);  
             */
            Console.WriteLine("Задание 11");
            int count11 = 0;
            Console.Write("Введите число: ");
            string a11 = Console.ReadLine();
            Console.Write("Введите z: ");
            int z11 = int.Parse(Console.ReadLine());
            for (int i = 0; i < a11.Length - 1; i++)
                if (int.Parse(a11.Substring(i, 1)) % z11 == 0)
                    count11++;

            Console.WriteLine(count11);
            Console.WriteLine();

            /* 
             * Задание 12
             * Для каждой команды-участницы чемпионата по футболу известно ее количество выигрышей и количество проигрышей. 
             * Определить, сколько команд имеют больше выигрышей, чем проигрышей.
             */
            Console.WriteLine("Задание 12");
            int count12 = 0;
            int n12_1w = 3, n12_1l = 4, n12_2w = 5, n12_2l = 4, n12_3w = 1, n12_3l = 1;
            if (n12_1w > n12_1l)
                count12++;
            if (n12_2w > n12_2l)
                count12++;
            if (n12_3w > n12_3l)
                count12++;

            Console.WriteLine(count12);
        }
    }
}
