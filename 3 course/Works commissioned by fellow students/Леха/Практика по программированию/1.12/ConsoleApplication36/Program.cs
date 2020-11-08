using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace задание_9
{
    class Program
    {
        static void Main(string[] args)
        {
            Document doc = new Document();
            Random rnd = new Random();
            doc.Number = rnd.Next(123, 500);
            doc.Print();
            doc.Number++;
            doc.Print();
        }
    }
    
}
