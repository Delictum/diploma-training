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
            char[,] AlphavitMatrix = new char[34, 34]; //Задаем матрицу для значений
            string AlphavitStart = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя "; //Задаем алфавит
            string Alphavit = AlphavitStart;

            //Формирование квадрата Виженера
            for (int i = 0; i < 34; i++) //Выполнять до длины алфавита
            {
                for (int j = 0; j < 34; j++) //Выполнять до длины алфавита
                {
                    AlphavitMatrix[i, j] = Char.Parse(Alphavit.Substring(j, 1)); //Переводим позицию элемента строки в символ под номер столбца и присваиваем массиву символов
                    Console.Write("{0} ", AlphavitMatrix[i, j]); //Выводим массив
                }
                Alphavit = Alphavit.Substring(1, 33) + AlphavitStart.Substring(i, 1); //Смещение символов алфавита
                Console.WriteLine();
            }
            
            //Инициализация переменных
            string WordOut = "", Key = "";
            Console.Write("Введите фразу: ");
            string WordIn = Console.ReadLine();
            Console.Write("Введите ключ: ");
            string KeyStart = Console.ReadLine();

            //Задание шифровочного ключа
            int k = 0;
            for (int i = 0; i < WordIn.Length; i++) //Выполнять до длины введенной фразы
            {
                Key += KeyStart.Substring(k, 1); //Присваиваем новому ключу символ из введенного ключа
                if (k < KeyStart.Length - 1) //Если длина нового ключа меньше длины введенного ключа
                    k++; //Добавляем позицию символов
                else
                    k = 0; //Возвращаем позицию символов на ноль
            }
            Console.WriteLine("Полученный ключ: {0}", Key);

            //Шифрование фразы
            int n = 0, m = 0; //номера столбца и строки буквы
            for (int f = 0; f < WordIn.Length; f++) //Выполнять до длины введенной фразы
            {
                for (int i = 0; i < 34; i++) //Выполнять до длины алфавита
                    if (Char.Parse(Key.Substring(f, 1)) == AlphavitMatrix[i, 0]) //По номеру строки выбираем символ из нового ключа
                        n = i; //Присваиваем номер строки
                for (int i = 0; i < 34; i++) //Выполнять до длины алфавита
                    if (Char.Parse(WordIn.Substring(f, 1)) == AlphavitMatrix[0, i]) //По номеру столбца выбираем символ из фразы
                        m = i; //Присваиваем номер столбца
                WordOut += AlphavitMatrix[n, m]; //Присваиваем символ в шифрованную фразу из массива по найденному номеру строки и столбца
            }

            Console.WriteLine("Зашифрованная фраза: {0}", WordOut); //Выводим фразу

            Console.ReadKey();
        }
    }
}
