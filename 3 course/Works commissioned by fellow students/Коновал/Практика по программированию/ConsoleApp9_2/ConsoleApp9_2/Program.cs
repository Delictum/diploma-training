using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    //товар, канцтовары, ручки, диски
    abstract class tovar
    {
        public string name_tovara;
        public double mani_tovara;
        public int shtrix_tovara;

        public tovar()
        {
            name_tovara = "Ракетка";
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

        public virtual void print()
        {
            Console.WriteLine("Название товара: {0}\nЦена товара: {1}\nСштри-код товара: {2}\n", name_tovara, mani_tovara, shtrix_tovara);
            Console.WriteLine();
        }

        public static tovar operator ++(tovar obj1)
        {
            obj1.mani += 1;
            return obj1;
        }
    }

    class canctovar : tovar
    {
        public int count;

        public canctovar(int count, string name_tovara, double mani_tovara, int shtrix_tovara) : base (name_tovara, mani_tovara, shtrix_tovara)
        {
            this.name_tovara = name_tovara;
            this.mani_tovara = mani_tovara;
            this.shtrix_tovara = shtrix_tovara;
            this.count = count;
        }

        public override void print()
        {
            Console.WriteLine("Название товара: {0}\nЦена товара: {1}\nСштри-код товара: {2}\nКоличество товара: {3}\n", name_tovara, mani_tovara, shtrix_tovara, count);
        }
    }

    class pencil : canctovar
    {
        public string color;

        public pencil(int count, string name_tovara, double mani_tovara, int shtrix_tovara) : base(count, name_tovara, mani_tovara, shtrix_tovara)
        {
            color = "Черный";
        }

        public override void print()
        {
            Console.WriteLine("Название товара: {0}\nЦена товара: {1}\nСштри-код товара: {2}\nКоличество товара: {3}\nЦвет: {4}", 
                name_tovara, mani_tovara, shtrix_tovara, count, color);
        }

    }

    class disk : tovar
    {
        public string type;

        public disk(string type, string name_tovara, double mani_tovara, int shtrix_tovara) : base(name_tovara, mani_tovara, shtrix_tovara)
        {
            this.name_tovara = name_tovara;
            this.mani_tovara = mani_tovara;
            this.shtrix_tovara = shtrix_tovara;
            this.type = type;
        }

        public override void print()
        {
            Console.WriteLine("Название товара: {0}\nЦена товара: {1}\nСштри-код товара: {2}\nТип диска: {3}\n", name_tovara, mani_tovara, shtrix_tovara, type);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Канцтовар: ");
            string name_tovara;
            int shtrix_tovara, count;
            double mani_tovara;
            Console.Write("Введите название товара: ");
            name_tovara = Console.ReadLine();
            Console.Write("Введите стоимость товара: ");
            mani_tovara = double.Parse(Console.ReadLine());
            Console.Write("Введите сштрих-код товара: ");
            shtrix_tovara = int.Parse(Console.ReadLine());
            Console.Write("Введите количество товара: ");
            count = int.Parse(Console.ReadLine());
            canctovar c = new canctovar(count, name_tovara, mani_tovara, shtrix_tovara);
            c.print();
            c.mani_tovara = c.mani_tovara + 3.00;
            Console.WriteLine("--------------Увеличиваем цену товара---------------------");
            Console.WriteLine("Цена товара будет увеличиваться на 3");
            c.print();
            Console.WriteLine();

            Console.WriteLine("Ручка: ");
            pencil p = new pencil(count, name_tovara, mani_tovara, shtrix_tovara);
            p.print();
            Console.WriteLine();
                        
            Console.WriteLine("Диск: ");
            Console.Write("Введите количество дисков: ");
            int n = int.Parse(Console.ReadLine());
            disk[] d = new disk[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Введите название товара: ");
                name_tovara = Console.ReadLine();
                Console.Write("Введите стоимость товара: ");
                mani_tovara = double.Parse(Console.ReadLine());
                Console.Write("Введите сштрих-код товара: ");
                shtrix_tovara = int.Parse(Console.ReadLine());
                Console.Write("Введите тип диска: ");
                string type = Console.ReadLine();
                d[i] = new disk(type, name_tovara, mani_tovara, shtrix_tovara);
            }
            for (int i = 0; i < n; i++)
                d[i].print();

            Console.ReadKey();
        }
    }
}