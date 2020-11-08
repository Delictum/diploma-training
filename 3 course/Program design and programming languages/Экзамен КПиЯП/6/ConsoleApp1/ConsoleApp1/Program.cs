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
            StreamWriter streamWriter = new StreamWriter("1.txt");
            double[] x = { 0.1, 0.2, 0.25, 0.33, 1.78, 2.05, 2.23 };
            double y = 1;
            for (int i = 0; i < x.Length; i++)            
                y += Math.Sin(x[i]) + 2 * Math.Cos(x[i]);
            streamWriter.Write(y.ToString());
            streamWriter.Close();
        }
    }
}
