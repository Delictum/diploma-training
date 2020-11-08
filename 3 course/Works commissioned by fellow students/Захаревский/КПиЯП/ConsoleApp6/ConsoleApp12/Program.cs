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
            Дана строка символов. 
            Вывести на экран количество строчных русских букв, 
            входящих в эту строку. 
            */
            Console.WriteLine("Задание 1.");
            string str_new1 = "";
            Console.WriteLine("Введите строку: ");
            string str1 = Console.ReadLine();
            char[] D = { 'а', 'б', 'в', 'г', 'д', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
            foreach (char ch in str1)
            {
                if (Array.IndexOf(D, ch) >= 0)
                    str_new1 += (ch);
            }
            Console.WriteLine("Количество русских строчных символов в строке: {0}", str_new1.Length);

            Console.WriteLine();


            /*
            Задание 2-3.
            1. Дана строка символов, среди которых есть двоеточие (:). Определить, сколько символов ему предшествует.
            2. Удалить часть символьной строки, заключенной в скобки (вместе со скобками)

            */
            Console.WriteLine("Задание 2-3.");
            Console.WriteLine("Введите строку: ");
            string str2 = Console.ReadLine();
            
            Console.WriteLine("Двоеточию предшествует {0} символов", str2.IndexOf(":"));
            Console.WriteLine(Regex.Replace(str2, @"\(.+?\)", ""));

            Console.WriteLine();

            /*
            Задание 4.
            6.	Строка, содержащая произвольный русский текст, состоит не более чем из 200 символов. 
            Написать, какие буквы и сколько раз встречаются в этом тексте. 
            Ответ должен приводиться в грамматически правильной форме: например: а — 25 раз, к — 3 раза и т.д.
            */
            Console.WriteLine("Задание 4.");
            Console.WriteLine("Введите строку: ");
            Console.WriteLine(string.Join("\n", Console.ReadLine().GroupBy(x => Char.ToLower(x)).Select(x => string.Format("{0} встречается {1} раз", x.Key, x.Count()) + ((x.Count() > 10 && x.Count() < 20) || !"234".Contains(x.Count().ToString().Last()) ? "" : "а"))));

            Console.WriteLine();
            /*
             * Задание 5.
             * 6.	В записке слова зашифрованы – каждое из них написано наоборот. Написать программу расшифровки текста.
             */

            Console.WriteLine("Задание 5.");
            
            Console.WriteLine("Введите строку: ");
            string text = Console.ReadLine();                  

            char[] arr = text.ToCharArray();
            Array.Reverse(arr);
            Console.WriteLine(arr);

            Console.ReadKey();
            
        }            
    }
}
 