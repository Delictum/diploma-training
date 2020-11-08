using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace задание_9
{
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
            Console.WriteLine("Номера чековых квитанций: ");
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
    public delegate void UI();
    class Program
         
    {
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

        public delegate int BinaryOp(int data, int time);
   
        static void Main(string[] args)
        {
            MyDel<int> del1 = MyObj<int>.SumInt;
            Console.WriteLine("Количество документов в очереди на ксерокс = " + del1(136, 74));

            int[] MyArrByte = new int[6] { 41, 50, 183, 566, 87, 65 };
            MyObj<int> ByteConst = new MyObj<int>(MyArrByte.Length, MyArrByte);
            ByteConst.ReWrite();

            Console.WriteLine("Учредители, чьи документы отправлены в печать в порядке следования: ");
            string[] a = { "Сколков", "Форграт", "Мехов", "Зыков", "Норри", "Хох", "Альков" };
            foreach (string x in a) Console.Write(x + "; ");
            Console.WriteLine();
            Console.WriteLine("Упорядочивание учредителей в алфавитном порядке: ");
            Sort<string>(ref a);
            foreach (string x in a) Console.Write(x + "; ");
            Console.WriteLine();
            Console.WriteLine();

            Document doc = new Kvitancia();
            Random rnd = new Random();
            doc.Number = rnd.Next(123, 500);
             
            doc.Print();
            Document doc1 = new Document();
            ///////////
            Document doc2 = new Nakladnaia();
            doc2.Number = rnd.Next(123, 500);
            ///////////
            doc2.Print();
            ///////////////
            Document doc3 = new Schet();
            doc3.Number = rnd.Next(123, 500);
        
            doc3.Print();
            Potoki();
        }
        static int DelegateThread(int data, int time)
        {
            Console.WriteLine("DelegateThread запущен");
            Thread.Sleep(time);
            Console.WriteLine("DelegateThread завершен");
            return ++data;
        }

        public static void Potoki()
        {
            Console.WriteLine("\nАсинхронный вызов метода с двумя потоками: \n");
            BinaryOp bo = DelegateThread;
            IAsyncResult ar = bo.BeginInvoke(1, 5000, null, null);
            IAsyncResult ar1 = bo.BeginInvoke(1, 8000, null, null);
            while (!ar.IsCompleted)
            {
                Console.Write(".");
                Thread.Sleep(50);
            }
            while (!ar1.IsCompleted)
            {
                Console.Write(".");
                Thread.Sleep(50);
            }
            int result = bo.EndInvoke(ar);
            Console.WriteLine("Result: " + result);
            Console.ReadLine();

        }

    }

}
   

    public class Document
    {
        public string soderz, face;
        private int number;
        public Document(string soderz, string face)
        {
            this.soderz = soderz;
            this.face = face;
        }
        public Document()
        {
            soderz = "";
            face = "";
            number = 123;
        }
   
    public string Soderz
        {
            get { return soderz; }
            set { soderz = value; }
        }
        public string Face
        {
            get { return face; }
            set { face = value; }
        }
        public int Number
        {
            get { return number; }
            set { number = value; }
        }

    public virtual void Print()
        {
            Console.WriteLine($"содержимое документа:{soderz}\nОтветственное лицо:{face}\nНомер:{number}\n");
        }
        public static Document operator ++(Document obj1)
        {
            obj1.number += 1;
            return obj1;
        }
    }
   public class Kvitancia : Document
    {
        public Kvitancia(string soderz1 = "Квитанция об оплате", string face1 = "Шиман.О.К", int number1 = 334)
        {
            this.soderz = soderz1;
            this.face = face1;
            this.Number = number1;
        }
        public override void Print()
        {
            base.Print();
        }
    public static void UserInfoHandler()
    {
        Console.WriteLine("Событие вызвано!\n");
    }

}
   public class Nakladnaia : Document
    {

        public Nakladnaia(string soderz2 = "Накладная на товар", string face2 = "Житко.Т.К", int number2 = 354)
        {
            this.soderz = soderz2;
            this.face = face2;
            this.Number = number2;
        }
        public override void Print()
        {
            base.Print();
        }
    public static void UserInfoHandler()
    {
        Console.WriteLine("Событие вызвано!\n");
    }
}
   public class Schet : Nakladnaia
    {
        public Schet(string soderz33 = "Счет за воду", string face33 = "Чичкин.Д.К", int number33 = 3542)
        {
            this.soderz = soderz33;
            this.face = face33;
            this.Number = number33;
        }
        public override void Print()
        {
            base.Print();
        }
       
    }


