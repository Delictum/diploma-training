using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StructApp
{
    delegate void Deleg1();
    delegate void Deleg2();
    delegate string Deleg3(string s);

    class Events
    {
        public event Deleg1 Ev1;
        public void OnEv1()
        {
            Ev1();
            Console.WriteLine("Произошло событие");
        }

        public event Deleg2 Ev2;
        public void OnEv2()
        {
            Ev2();
            Console.WriteLine("Событие произошло.");
        }

        public event Deleg3 Ev3;
        public string OnEv3(string s)
        {
            return Ev3(s);
        }
    }

    abstract class People
    {
        public string pol;
        public void Write()
        {
            Console.WriteLine("Пол: " + pol);
        }
    }    

    class Kadr : People
    {
        public string number;
        public virtual void Vyvod()
        {
            Console.WriteLine("Номер кадра: " + number);
        }
    }

    class Inzener : Kadr
    {
        public string fio;
        public virtual void FIO()
        {
            Console.WriteLine("ФИО: " + fio);
        }
    }

    class Work : Inzener
    {
        public string mesto;
        public virtual void Place()
        {
            Console.WriteLine("Цех: " + mesto);
            Deleg2 del2 = delegate ()
            {
                Console.WriteLine("Анонимный");
            };
            del2();
        }
    }

    class Admin : Inzener
    {
        public string nomer;
        public virtual void Kab()
        {
            Console.WriteLine("Номер личного кабинета: " + nomer);
            Deleg1 del1 = delegate ()
            {
                Console.WriteLine("Метод");
            };
            del1();
        }
    }

    class Program
    {
        static Deleg3 D(string sss)
        {
            string ss = "1";
            Deleg3 del3 = delegate (string s)
            {
                ss += s + "2";
                return ss;
            };
            return del3;
        }

        static void Main(string[] args)
        {
            Events evt = new Events();
            string sss = "3";
            evt.Ev3 += D(sss);
            Console.WriteLine("Событие: {0}", evt.OnEv3(sss));
            Console.WriteLine();

            Work a1 = new Work();
            a1.pol = "Ж";
            a1.number = "532121";
            a1.fio = "Топарь Г.Ж.";
            a1.mesto = "19Б-3";
            a1.Write();
            a1.Vyvod();
            a1.FIO();
            evt.Ev2 += a1.Place;
            evt.OnEv2();

            Console.WriteLine();

            Admin a2 = new Admin();
            a2.pol = "М";
            a2.number = "315235";
            a2.fio = "Ждук Б.С.";
            a2.nomer = "107";
            a2.Write();
            a2.Vyvod();
            a2.FIO();
            evt.Ev1 += a2.Kab;
            evt.OnEv1();
            Console.ReadKey();
        }
    }
}