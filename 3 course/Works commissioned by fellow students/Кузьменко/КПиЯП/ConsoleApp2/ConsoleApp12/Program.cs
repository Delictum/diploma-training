using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        public static void ShowAllCombinations<T>(IList<T> arr, string current = "")
        {
            if (arr.Count == 0) //если все элементы использованы, выводим на консоль получившуюся строку и возвращаемся
            {
                Console.WriteLine(current);
                return;
            }
            for (int i = 0; i < arr.Count; i++) //в цикле для каждого элемента прибавляем его к итоговой строке, создаем новый список из оставшихся элементов, и вызываем эту же функцию рекурсивно с новыми параметрами.
            {
                List<T> lst = new List<T>(arr);
                lst.RemoveAt(i);
                ShowAllCombinations(lst, current + arr[i].ToString());
            }
        }

        static void Main(string[] args)
        {
            /*
            Задание 1.
            Запрашивает с клавиатуры два вещественных числа, и выводит на экран сумму данных чисел 
            (вещественные числа выводятся с точностью до 2 знаков после запятой): 
            */
            Console.WriteLine("Задание 1.");
            Console.WriteLine("Введите два числа: ");
            double x1 = Convert.ToDouble(Console.ReadLine());
            double y1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(x1 + y1);

            Console.WriteLine();

            /*
            Задание 2.
            Дано четырехзначное число. Найти сумму его цифр.
            */
            Console.WriteLine("Задание 2.");
            int number = new Random().Next(1000, 10000);
            int sum = number.ToString().Select(x => x - '0').
                Cast<int>().Sum();
            Console.WriteLine("Число: {0}\nСумма: {1}", number, sum);

            Console.WriteLine();

            /*
            Задание 3.
            Вычислить ребро куба, площадь полной поверхности которого равна s; 
            */
            Console.WriteLine("Задание 3.");
            Console.Write("Введите площадь полной поверхности куба: ");
            double cubeArea = Convert.ToDouble(Console.ReadLine());
            double edge = Math.Sqrt(cubeArea / 6);
            Console.WriteLine("Длина ребра:{0}", edge);

            Console.WriteLine();

            /*
            Задание 4.
            Расстояние до ближайшей к Земле звезды Альфа Центавра 4,3 световых года. 
            Скорость света – 300 000 км/с. Скорость земного звездолета 100 км/с. 
            За сколько лет звездолет долетит до звезды 
            */
            Console.WriteLine("Задание 4.");
            Console.WriteLine("Долетит за " + (4.3 * 300000 / 100) + " лет");
                
            Console.WriteLine();
            /*
             * Задание 5.
             * Найдите сумму n членов арифметической прогрессии, первый член которой равен n, а разность равна d.
             */

            Console.WriteLine("Задание 5.");
            Console.WriteLine("Введите n: ");
            int n5 = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите d: ");
            int d5 = int.Parse(Console.ReadLine());
            int a1 = n5;
            int sum5 = ((2 * a1 + (n5 - 1) * d5) / (2)) * n5;
            Console.WriteLine(sum5);

            Console.WriteLine();

            Console.WriteLine("Задание 6.");
            double x6 = 4.3;
            double y6 = (1 + Math.Sqrt(Math.Abs(3 - Math.Pow(x6, 2)))) / (Math.Atan(Math.Pow(x6, 2))) - Math.Pow(Math.E, (Math.Sin(Math.Sqrt(x6))));
            Console.WriteLine(y6);

            Console.WriteLine();

            //а21 за шесть операции, а – действительное число, при этом, не пользуясь никакими другими арифметическими операциями, кроме умножения.
            Console.WriteLine("Задание 7.");
            a1 = 2;
            int a2 = a1 * a1; //2
            int a3 = a2 * a2; //4
            int a4 = a3 * a1; //5
            int a5 = a4 * a4; //10
            int a6 = a5 * a5; //20
            int a7 = a6 * a1;
            Console.WriteLine(a7);

            Console.ReadKey();
            
            
        }            
    }
}
 