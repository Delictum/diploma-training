using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Дана строка, в которой содержится осмысленное текстовое сообщение. 
             * Слова сообщения разделяются пробелами и знаками препинания. 
             * Выведите все слова заданной длины. 
             */
            Console.WriteLine("Задание 1.");
            string stroka = "Сегодняшний день полон неожиданностей и сюрпризов, думаю, что к вечеру состояние стабилизируется в лучшую сторону - иначе дело полная дрянь.";
            Console.WriteLine("Введите необходимую длину слова: ");
            int x = int.Parse(Console.ReadLine());
            foreach (string word in stroka.Split(new char[] { ' ', ',', '.', ';', ':' }, StringSplitOptions.RemoveEmptyEntries))
                if (word.Length == x)
                    Console.WriteLine(word);


            /* 
            1. Шаблоны регулярных выражений для групп 
            time, ip и site записаны в упрощенном виде. 
            Преобразуйте их к такому виду, чтобы они соответствовали ограничениям, 
            накладываемым на формат времени, ip-адреса и адреса web-сайта. 
            2. Используя дополнительную литературу и Интернет, 
            более подробно изучите работу с классом Group и коллекцией Groups класса Match. 
            */
            Console.WriteLine("Задание 2.");
            string text = @"04:55:34 223.345.12.158 www.aaa.ru
                 04:59:55 213.134.112.56 www.bbb.net
                 05:05:01 223.34.12.156 www.aaa.by";

            Regex theReg = new Regex(@"(?<time>(\d|\:)+)\s" +
                                      @"(?<ip>(\d|\.)+)\s" +
                                      @"(?<site>\S+)");
            MatchCollection theMatches = theReg.Matches(text);
            foreach (Match theMatch in theMatches)
            {
                if (theMatch.Length != 0)
                {
                    Console.WriteLine("\ntheMatch: {0}", theMatch.ToString()); //1
                    Console.WriteLine("time: {0}", theMatch.Groups["time"]);  //2
                    Console.WriteLine("ip: {0}", theMatch.Groups["ip"]);  //3
                    Console.WriteLine("site: {0}", theMatch.Groups["site"]);  //4
                }
            }
            Console.WriteLine();

            Console.WriteLine("Правильные ограничения:");
            Console.WriteLine();
            Regex theReg1 = new Regex(@"(?<time1>\d{1,2}:\d{1,2}:\d{1,2})\s" +
                @"(?<ip1>\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})\s" +
                @"(?<site1>\S{1,3}\.\S*\.by|\S{1,3}\.\S*\.net)");
            MatchCollection thematches1 = theReg1.Matches(text);
            foreach (Match sss in thematches1)
            {
                Console.WriteLine("\ntheMatch: {0}", sss.ToString()); //1
                Console.WriteLine("time: {0}", sss.Groups["time1"]);  //2
                Console.WriteLine("ip: {0}", sss.Groups["ip1"]);  //3
                Console.WriteLine("site: {0}", sss.Groups["site1"]);  //4
            }
            Console.ReadKey();
        }
    }
}
