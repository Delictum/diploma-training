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
            Посчитать в строке количество слов.
            */
            Console.WriteLine("Задание 1.");
            Console.WriteLine("Введите строку: ");
            string str1 = Console.ReadLine();
            string[] words1 = str1.Split(' ');
            Console.WriteLine("{0} слов(а) в тексте", words1.Length);

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

            /*
            Задание 4.
            Компания учитывает расходы своих служащих в долларах. После поездки они могут представить свои расходы в одной из следующих валют:
            	Фунтах стерлингов (£2050);
            	Евро (€5196);
            	Канадские доллары (C$4987);
            	Доллары США ($5000);
            	Йены (¥2000);
            	Шведские кроны (7000kr).
            Составить программу, которая читает статьи расходов и переводит в доллары США.

            */
            Console.WriteLine("Задание 4.");
            Console.WriteLine("Введите валюту: ");
            string str4 = Console.ReadLine();
            double val = 0;
            string str4n = "";
            if (str4.IndexOf('£') != -1)
            {
                str4n = str4.Trim(new Char[] { '£' });
                val = double.Parse(str4n) * 1.2;
            }
            else if (str4.IndexOf('€') != -1)
            {
                str4n = str4.Trim(new Char[] { '€' });
                val = double.Parse(str4n) * 1.1;
            }
            else if (str4.IndexOf('C') != -1 && str4.IndexOf('$') != -1)
            {
                str4n = str4.Trim(new Char[] { 'C', '$' });
                val = double.Parse(str4n) * 0.9;
            }
            else if (str4.IndexOf('$') != -1)
            {
                str4n = str4.Trim(new Char[] { '$' });
                val = double.Parse(str4n) * 1.0;
            }
            else if (str4.IndexOf('¥') != -1)
            {
                str4n = str4.Trim(new Char[] { '¥' });
                val = double.Parse(str4n) * 0.7;
            }
            else if (str4.IndexOf('k') != -1 && str4.IndexOf('r') != -1)
            {
                str4n = str4.Trim(new Char[] { 'k', 'r' });
                val = double.Parse(str4n) * 0.8;
            }

            Console.WriteLine(val);
            Console.WriteLine();
            /*
             * Задание 5.
             */

            Console.WriteLine("Задание 5.");
            string text = Console.ReadLine();
            Console.WriteLine("Исходный текст: '{0}'", text);
            string[] words = text.Split('_');
            Console.WriteLine("{0} слов(а) в тексте", words.Length);
            for (int i = 0; i < words.Length; i++)
                words[i] += " ";
            ShowAllCombinations(words);

            Console.ReadKey();
            
        }            
    }
}
 