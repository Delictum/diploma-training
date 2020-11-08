using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class Program
    {
        /* Укажите все целые числа, которые увеличатся на 20%,
         * если их цифры записать в обратном порядке.
         */
        static void Main(string[] args)
        {            
            for (double i = 1; i < 100000; i++)
            {
                string a = "";
                string temp1 = Convert.ToString(i);
                for (int j = temp1.Length - 1; j > -1; j--)
                    a += temp1.Substring(j, 1);
                double temp2 = double.Parse(a);
                double temp3 = i * 1.2;

                if (temp3 == temp2)
                    Console.WriteLine(i);                
            }
        }
    }
}
