using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public delegate void Del();

    class tovar
    {
        public string name_tovara;
        public double mani_tovara;
        private int shtrix_tovara;

        public tovar()
        {
            name_tovara = "Сало";
            mani_tovara = 4;
            shtrix_tovara = 228322;
        }

        public tovar(string name_tovara, double mani_tovara, int shtrix_tovara)
        {
            this.name_tovara = name_tovara;
            this.mani_tovara = mani_tovara;
            this.shtrix_tovara = shtrix_tovara;
        }

        public string name
        {
            get { return name_tovara; }
            set { name_tovara = value; }
        }

        public double mani
        {
            get { return mani_tovara; }
            set
            {
                if (value >= 11)
                {
                    Console.WriteLine("Это дорогой товар");
                }
                else if (value <= 10)
                {
                    Console.WriteLine("Это не дорогой товар");
                }
            }
        }

        public int shtrix
        {
            get { return shtrix_tovara; }
            set
            {
                Console.WriteLine("12345");
            }
        }

        public void print()
        {
            Console.WriteLine("Название товара: {0}\nЦена товара: {1}\nСштри-код товара: {2}\n", name_tovara, mani_tovara, shtrix_tovara);
            Console.WriteLine();
        }

        public static tovar operator ++(tovar obj1)
        {
            obj1.mani += 1;
            return obj1;
        }        

        public int on_delegat(int dt)
        {
            return dt + dt;
        }

        public event Del event_print;

        public void events_now()
        {
            event_print();
        }

        public void events_job()
        {
            Console.WriteLine("Событие");
        }
    }


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

            c.event_print += new Del(c.events_job);
            c.events_now();

            Console.WriteLine("Делегат - увеличиваем штрихкод в два раза: {0}", a.on_delegat(shtrix_tovara));
            Console.ReadKey();
        }
    }
}
 