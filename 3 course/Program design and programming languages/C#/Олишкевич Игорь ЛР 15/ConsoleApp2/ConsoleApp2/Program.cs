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
            var g = new Goods.Goods("Йогурт", DateTime.Today, 89, 73, 124235);
            g.ToString();
            Console.Write("Введите на какую сумму изменить цену. Для уменьшения ввод отрицательного числа, иначе - положительного: ");
            int buf = int.Parse(Console.ReadLine());
            g.DisPrice(buf);
            g.ToString();
            Console.Write("Введите на какое количество изменить товары. Для уменьшения ввод отрицательного числа, иначе - положительного: ");
            buf = int.Parse(Console.ReadLine());
            g.DisCount(buf);
            g.ResPrice();

            Console.ReadKey();
        }
    }
}
