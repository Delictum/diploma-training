using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    struct PEREVOZKI
    {
        public string type;
        public int count, hours, km;
    }

    //Описать структуру PEREVOZKI(тип самолета, количество рейсов, налет в часах, налет в тысячах километров). 
    //Введите данные в массив, состоящий из шести элементов типа PEREVOZKI.
    //    Выведите на экран информацию о самолетах, налет часов которых больше введенного с клавиатуры числа.
    //    Если такого самолета нет, то программа должна выдать соответствующее сообщение на экран.

    public class Program
    {
        static void Main(string[] args)
        {
            PEREVOZKI[] p = new PEREVOZKI[6];
            Console.WriteLine("Заполнение данных:");
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine("Книга №{0}:", i + 1);
                Console.Write("Введите тип самолета: ");
                p[i].type = Console.ReadLine();
                Console.Write("Введите количество рейсов: ");
                p[i].count = int.Parse(Console.ReadLine());
                Console.Write("Введите налет в часах: ");
                p[i].hours = int.Parse(Console.ReadLine());
                Console.Write("Введите налет в тысячах километров: ");
                p[i].km = int.Parse(Console.ReadLine());
            }

            Console.Write("Введите налет часов: ");
            int vvod = int.Parse(Console.ReadLine());
            int count = 0;

            bool b = false;
            for (int i = 0; i < 6; i++)
            {
                if (p[i].hours > vvod)
                {
                    count++;
                    Console.WriteLine("{0}) тип самолета '{1}', количество рейсов {2}, налет в часах {3} и налет в тысячах километров {4}", count, p[i].type, p[i].count, p[i].hours, p[i].km);
                    b = true;
                }
            }

            if (b == false)
            {
                Console.WriteLine("Нет таких самолетов.");
            }

            Console.ReadKey();
        }
    }
}
