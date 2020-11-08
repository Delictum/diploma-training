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
            char[,] AM = new char[26, 26];
            string AS = "abcdefghijklmnopqrstuvwxyz ";
            string A = AS;

            //Формирование квадрата Виженера
            for (int i = 0; i < 26; i++)
            {
                for (int j = 0; j < 26; j++)
                {
                    AM[i, j] = Char.Parse(A.Substring(j, 1));
                    Console.Write("{0} ", AM[i, j]);
                }
                A = A.Substring(1, 25) + AS.Substring(i, 1); //Смещение символов алфавита
                Console.WriteLine();
            }

            //Инициализация переменных
            string WO = "", K = "";
            Console.Write("Введите фразу: ");
            string WordIn = Console.ReadLine();
            Console.Write("Введите ключ: ");
            string KS = Console.ReadLine();

            //Задание шифровочного ключа
            int k = 0;
            for (int i = 0; i < WordIn.Length; i++)
            {
                K += KS.Substring(k, 1);
                if (k < KS.Length - 1)
                    k++;
                else
                    k = 0;
            }
            Console.WriteLine("Полученный ключ: {0}", K);

            //Шифрование фразы
            int n = 0, m = 0; //номера столбца и строки буквы
            for (int f = 0; f < WordIn.Length; f++)
            {
                for (int i = 0; i < 26; i++)
                    if (Char.Parse(K.Substring(f, 1)) == AM[i, 0])
                        n = i;
                for (int i = 0; i < 26; i++)
                    if (Char.Parse(WordIn.Substring(f, 1)) == AM[0, i])
                        m = i;
                WO += AM[n, m];
            }

            Console.WriteLine("Зашифрованная фраза: {0}", WO);

            Console.ReadKey();
        }
    }
}
