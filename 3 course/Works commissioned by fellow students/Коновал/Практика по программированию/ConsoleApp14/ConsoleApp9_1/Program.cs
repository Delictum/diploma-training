using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary14;

namespace ConsoleApplication3
{  
    public class Program
    {
        static void Main(string[] args)
        {
            tovar a = new tovar();
            a.print();

            string name_tovara;
            int shtrix_tovara;
            double mani_tovara;
            Console.Write("Введите название товара: ");
            name_tovara = Console.ReadLine();
            Console.Write("Введите стоимость товара: ");
            mani_tovara = double.Parse(Console.ReadLine());
            Console.Write("Введите сштрих-код товара: ");
            shtrix_tovara = int.Parse(Console.ReadLine());
            tovar c = new tovar(name_tovara, mani_tovara, shtrix_tovara);
            c.print();
            c.mani_tovara = c.mani_tovara + 3.00;
            Console.WriteLine("--------------Увеличиваем цену товара---------------------");
            Console.WriteLine("Цена товара будет увеличиваться на 3");
            c.print();
            Console.ReadKey();
        }
    }
}