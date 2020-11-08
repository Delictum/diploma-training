using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream file1 = new FileStream("1.txt", FileMode.Open); 
            StreamReader reader = new StreamReader(file1);
            string g = reader.ReadLine();
            if (Convert.ToInt32(g) > 0 && Convert.ToInt32(g) < 26)
                Console.WriteLine(reader.ReadLine());
            while (g != "")
            {
                g = reader.ReadLine();
                if (Convert.ToInt32(g) > 0 && Convert.ToInt32(g) < 26)
                    Console.WriteLine(g);
            }
            reader.Close();
            Console.ReadLine();
        }
    }
}
