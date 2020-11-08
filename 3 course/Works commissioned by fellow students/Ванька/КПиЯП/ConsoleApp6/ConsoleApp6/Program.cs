using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleLab2Yana
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