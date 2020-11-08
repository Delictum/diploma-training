using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

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

    public interface ISort<T>
       where T : struct
    {
        void ReWrite();
    }

    class MyObj<T> : ISort<T> where T : struct
    {
        public int longOb { get; set; }
        T[] myarr;

        public MyObj(int i)
        {
            longOb = i;
        }

        public MyObj(int i, T[] arr)
        {
            longOb = i;
            myarr = new T[i];
            for (int j = 0; j < arr.Length; j++)
                myarr[j] = arr[j];
        }

        public void ReWrite()
        {
            Console.WriteLine("Тип: {0}", typeof(T));
            Console.WriteLine("Количество ручек, карандашей, пеналов, стержней, циркулей: ");
            foreach (T t in myarr)
                Console.Write("{0}; ", t);
            Console.WriteLine("\n");
        }

        public static int SumInt(int a, int b)
        {
            return a + b;
        }
    }

    delegate T MyDel<T>(T obj1, T obj2);

    public class Program
    {
        static void ThreadFunction(Object input)
        {
            int flag = (int)input;
            if (flag == 1)
            {
                Console.WriteLine("Это первый поток!");
            }
            else
            {
                Console.WriteLine("Это второй поток!");
            }
        }

        static void Sort<T>(ref T[] a) where T : IComparable<T>
        {
            T buf;
            int n = a.Length;
            for (int i = 0; i < n; i++)
            {
                int im = i;
                for (int j = i + 1; j < n; j++)
                    if (a[j].CompareTo(a[im]) < 0) im = j;
                buf = a[i]; a[i] = a[im]; a[im] = buf;
            }
        }

        static void Main(string[] args)
        {
            MyDel<int> del1 = MyObj<int>.SumInt;
            Console.WriteLine("Делегат = " + del1(136, 74));

            int[] MyArrByte = new int[6] { 41, 50, 183, 566, 87, 65 };
            MyObj<int> ByteConst = new MyObj<int>(MyArrByte.Length, MyArrByte);
            ByteConst.ReWrite();

            Console.WriteLine("Наименования товаров: ");
            string[] av = { "Ручки", "Карандаши", "Пеналы", "Скотч", "Циркули", "Стержни" };
            foreach (string x in av) Console.Write(x + "; ");
            Console.WriteLine();
            Console.WriteLine("Упорядочивание названий: ");
            Sort<string>(ref av);
            foreach (string x in av) Console.Write(x + "; ");
            Console.WriteLine();
            Console.WriteLine();

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

            Thread thread1 = new Thread(ThreadFunction);
            thread1.Start(1);
            Thread thread2 = new Thread(ThreadFunction);
            thread2.Start(2);

            c.event_print += new Del(c.events_job);
            c.events_now();

            Console.WriteLine("Делегат - увеличиваем штрихкод в два раза: {0}", a.on_delegat(shtrix_tovara));
            Console.ReadKey();
        }
    }
}
 