using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            var alphabetMatrix = new char[34, 34];
            const string alphabetStart = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            var alphabet = alphabetStart;

            //Формирование квадрата Виженера
            for (var i = 0; i < alphabetStart.Length; i++)
            {
                for (var j = 0; j < alphabetStart.Length; j++)
                {
                    alphabetMatrix[i, j] = char.Parse(alphabet.Substring(j, 1));
                    Console.Write("{0} ", alphabetMatrix[i, j]);
                }

                alphabet = string.Join(string.Empty, alphabet.Substring(1, alphabetStart.Length - 1), alphabetStart.Substring(i, 1)); //Смещение символов алфавита
                Console.WriteLine();
            }
            
            //Инициализация переменных
            var encryptedPhrase = string.Empty;
            var key = string.Empty;
            Console.Write("Введите фразу: ");
            var inputPhrase = Console.ReadLine();
            Console.Write("Введите ключ: ");
            var startKey = Console.ReadLine();

            //Задание шифровочного ключа
            int k = 0;
            for (var i = 0; i < inputPhrase.Length; i++)
            {
                key += startKey.Substring(k, 1);
                if (k < startKey.Length - 1)
                {
                    k++;
                }
                else
                {
                    k = 0;
                }
            }
            Console.WriteLine("Полученный ключ: {0}", key);

            //Шифрование фразы
            int n = 0, m = 0; //номера столбца и строки буквы
            for (var f = 0; f < inputPhrase.Length; f++)
            {
                var isSpace = false;
                for (var i = 0; i < 34; i++)
                {
                    if (char.Parse(key.Substring(f, 1).ToLower()) == alphabetMatrix[i, 0])
                    {
                        n = i;
                    }

                }

                for (var i = 0; i < 34; i++)
                {
                    var currentChar = inputPhrase.Substring(f, 1);
                    if (currentChar == " ")
                    {
                        isSpace = true;
                        continue;
                    }

                    if (char.Parse(currentChar.ToLower()) == alphabetMatrix[0, i])
                    {
                        m = i;
                    }

                }

                if (isSpace)
                {
                    encryptedPhrase += " ";
                }
                else
                {
                    encryptedPhrase += alphabetMatrix[n, m];
                }
            }

            Console.WriteLine("Зашифрованная фраза: {0}", encryptedPhrase);
            Console.ReadKey();
        }
    }
}
