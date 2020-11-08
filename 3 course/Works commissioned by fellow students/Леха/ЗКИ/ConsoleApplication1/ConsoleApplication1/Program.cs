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
            string alphavit = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя ";
            Console.Write("Введите фразу: ");
            string text = Console.ReadLine();
            Console.Write("Введите на какое количество позиций делать смещение: ");
            int n = int.Parse(Console.ReadLine());
            string result = "";
            int pos = 0;
            Console.WriteLine("Алфавит: {0}", alphavit);
            for (int i = 0; i < text.Length; i++) 
            {
                pos = alphavit.IndexOf(text.Substring(i, 1)) + n; //Присваиваем предположительный номер нового символа 
                if (pos >= alphavit.Length) //Если номер больше количества позиций в алфавите, то начинаем отсчет символа с начала алфавита
                    pos = pos - alphavit.Length;
                result += alphavit.Substring(pos, 1); //Добавляем новый символ в строку               
            }
            Console.WriteLine(result);
        }
    }
}
