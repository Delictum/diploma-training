using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary14
{
    public class tovar
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
    }
}
