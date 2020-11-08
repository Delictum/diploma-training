using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Задание 1.
            Дана строка, состоящая из групп нулей и единиц. Посчитать количество нулей и едениц.
            */
            Console.WriteLine("Задание 1.");
            string str = "sdfsdf00001111000111001111";
            int Num0 = str.Count(x => x == '0');
            int Num1 = str.Count(x => x == '1');
            Console.WriteLine("Количество нулей в строке: {0}", Num0);
            Console.WriteLine("Количество единиц в строке: {0}", Num1);
            Console.WriteLine("Количество нулей и единиц в строке: {0}", Num0 + Num1);

            Console.WriteLine();


            /*
            Задание 2-3.
            1. Дана строка, заканчивающаяся точкой. Подсчитать, сколько слов в строке.
            2. Дана строка. Указать те слова, которые содержат хотя бы одну букву (с).


            */
            Console.WriteLine("Задание 2-3.");
            Console.WriteLine("Введите строку: ");
            string str2 = Console.ReadLine();
            string[] words2 = str2.Split(' ', '.');
            Console.WriteLine("{0} слов(а) в тексте", words2.Length);

            Console.Write("Слова, содержащие хотя бы одну букву 'с': ");
            for (int i = 0; i < words2.Length; i++)
                if (-1 != words2[i].IndexOf('с'))
                    Console.Write(" " + words2[i]);
            Console.WriteLine();

            Console.WriteLine();

            /*
            Задание 4.
            3.	Составить программу, которая будет вводить строку в переменную string. Подсчитать, сколько различных символов встречаются в ней. Вывести их на экран.
            */
            Console.WriteLine("Задание 4.");
            Console.WriteLine("Введите строку: ");
            Console.WriteLine(string.Join("\n", Console.ReadLine().GroupBy(x => Char.ToLower(x)).Select(x => string.Format("{0} встречается {1} раз", x.Key, x.Count()) + ((x.Count() > 10 && x.Count() < 20) || !"234".Contains(x.Count().ToString().Last()) ? "" : "а"))));

            Console.WriteLine();
            /*
             * Задание 5.
             * 4.	Дана строка, содержащая зашифрованный русский текст. Каждая буква заменяется на следующую за ней (буква я заменяется на а). 
             * Получить новую расшифрованную строку.
             */

            Console.WriteLine("Задание 5.");

            string Alphavit = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            Console.WriteLine(Alphavit.Length);
            Console.Write("Введите строку: ");
            string WordIn = Console.ReadLine();
            int Position = 1;
            string WordOut = "";

            for (int i = 0; i < WordIn.Length; i++)
            {
                int buf = Alphavit.IndexOf(WordIn[i]);
                int temp = buf + Position;
                if (temp > 33)
                    temp = temp - 34;
                WordOut += Alphavit[temp];
            }

            Console.WriteLine(WordOut);
            Console.ReadKey();            
        }            
    }
}
 