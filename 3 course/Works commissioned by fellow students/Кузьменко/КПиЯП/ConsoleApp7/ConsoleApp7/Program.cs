using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConsoleApp7
{
    class Program
    {
        public static IEnumerable<double> GetNumbers(string input)
        {
            var matches = Regex.Matches(input, @"-?\d+(?:\.\d+)?", RegexOptions.Compiled);
            return from Match match in matches select double.Parse(match.Value, CultureInfo.InvariantCulture);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Write text:");
            var text1 = Console.ReadLine();
            var numbers = GetNumbers(text1);
            if (numbers.Any())
                Console.WriteLine("Max number in the text is: {0}", numbers.Max());
            else
                Console.WriteLine("No numbers in the text");


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
            Regex theReg1 = new Regex(@"(?<time1>\d([0-9]{1,2}):\d([0-9]{1,2}):\d([0-9]{1,2}))\b\s" +
                @"(?<ip1>\d(\w+){1,3}\.\d(\w+){1,3}\.\d(\w+){1,3}\.\d(\w+){1,3})\b\s" +
                @"(?<site1>\S(\w+){1,3}\.\S*(\w+)\.by|\S(\w+){1,3}\.\S*(\w+)\.net)\b");
            MatchCollection thematches1 = theReg1.Matches(text);
            foreach (Match sss in thematches1)
            {
                Console.WriteLine("\ntheMatch: {0}", sss.ToString()); //1
                Console.WriteLine("time: {0}", sss.Groups["time1"]);  //2
                Console.WriteLine("ip: {0}", sss.Groups["ip1"]);  //3
                Console.WriteLine("site: {0}", sss.Groups["site1"]);  //4
            }
        }
    }
}
