using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
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
            1. Дана строка, содержащая текст, заканчивающийся точкой. Вывести на экран слова, содержащие три буквы. 
            2. Определить сколько раз в строке встречается заданное слово. Заданное слово ввести с клавиатуры. 
            */
            Console.WriteLine("Задание 2-3.");
            Console.WriteLine("Введите строку: ");
            string str2 = Console.ReadLine();
            Console.Write("Введите слово: ");
            string word2 = Console.ReadLine();
            str2 = "  " + str2;
            int n = str2.Length;
            int nsl = 0, kol = 0;

            int count = 0;
            string[] mas = str2.Split(' ');
            foreach (string s in mas)
            {
                if (s == word2)
                    count++;
            }

            Console.WriteLine("Слово '{0}' встречается в тексте {1} раз", word2, count);

            for (int i = 0; i < n - 1; i++)
            {
                if (str2.Substring(i, 1) == " " && str2.Substring(i + 1, 1) != " " && str2.Substring(i + 1, 1) != ".") 
                           nsl = i + 1;

                if (str2.Substring(i, 1) != " " && str2.Substring(i, 1) != "." && (str2.Substring(i + 1, 1) == "." || str2.Substring(i + 1, 1) == " "))
                {
                    int ksl = i;
                    if ((ksl - nsl) + 1 == 3)
                        kol++;
                }
            }            

            Console.WriteLine("Слов из 3-х букв {0}", kol);
            Console.WriteLine();

            /*
            Задание 4.
            Двумерный массив cодержит некоторые буквы русского алфавита, расположенные в произвольном порядке. 
            Написать программу, проверяющую, можно ли из этих букв составить данное слово S. 
            */
            Console.WriteLine("Задание 4.");

            char[,] a = new char[3, 2];
            a[1, 1] = 'а'; a[2, 1] = 'е'; a[3, 1] = 'б'; a[1, 2] = 'г'; a[2, 2] = 'з'; a[3, 2] = 'м'; 
            Console.Write("Введите слово: ");
            string s4 = Console.ReadLine();
            Boolean g = true;
            {
                if (s4.Length > 6)
                    Console.WriteLine("Нельзя.");
                for (int ij = 0; ij < s4.Length; ij++)
                {
                    for (int i = 0; i < 3; i++)
                        for (int j = 0; j < 2; j++)
                            if (s4.Substring(ij, 1) == Convert.ToString(a[i, j]))
                                g = true;
                            else
                            {
                                g = false;
                                break;
                            }
                }
                if (g == true)
                    Console.WriteLine("Можно.");
                else
                    Console.WriteLine("Нельзя.");
                Console.WriteLine();

                /*
                Задание 5.
                Зашифровать введенный текст, написав каждое слово наоборот. 
                */
                Console.WriteLine("Задание 5.");
                Console.WriteLine("Введите строку: ");
                string str5 = Console.ReadLine();

                //Переворачиваем строку в результатную
                char[] str5new = str5.ToCharArray();
                Array.Reverse(str5new);
                Console.WriteLine(str5new);

                Console.ReadKey();
            }
        }            
    }
}
 