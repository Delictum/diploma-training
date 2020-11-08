using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace задание_9
{
    public delegate void info_print();

    public delegate void UI();
    class Program
    {
        public delegate int Del();

        static int on_date_time()
        {
            return 40;
        }
        public delegate int BinaryOp(int data, int time);

        static void Main(string[] args)
        {
            Del d = new Del(on_date_time);
            Console.WriteLine("Делегат = {0}", d());
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
            doc.event_print += new info_print(doc.events_job);
            doc.events_now();
            Console.ReadKey();
        }
    }

    class Document
    {
        public event info_print event_print;
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
        public void events_now()
        {
            event_print();
        }

        public void events_job()
        {
            Console.WriteLine("Обработчик события");
        }
        public void print()
        {

        }
    }
    class Kvitancia : Document
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
    class Nakladnaia : Document
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
        public void journal_e_p(string spam)
        {
            Console.WriteLine("Обработчик события {0} вызван.", spam);
        }
    }
    class Schet : Nakladnaia
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
}
