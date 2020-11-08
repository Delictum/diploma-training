using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            //Удалите из сообщения только те русские слова, которые начинаются на гласную букву. 
            string inputMessage = Console.ReadLine();
            string[] inputWords = inputMessage.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            char[] filterArray = new char[] { 'а', 'у', 'о', 'ы', 'и', 'э', 'я', 'ю', 'ё', 'е' };

            string[] resultWords = inputWords.Where(i => !filterArray.Contains(char.ToLower(i[0]))).ToArray();
            string resultMessage = string.Join(" ", resultWords);

            Console.WriteLine("Вывод: " + resultMessage);
        }
    }
}
