using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StructApp
{
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
        }
    }

    class Admin : Inzener
    {
        public string nomer;
        public virtual void Kab()
        {
            Console.WriteLine("Номер личного кабинета: " + nomer);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Work a1 = new Work();
            a1.pol = "Ж";
            a1.number = "532121";
            a1.fio = "Топарь Г.Ж.";
            a1.mesto = "19Б-3";
            a1.Write();
            a1.Vyvod();
            a1.FIO();
            a1.Place();

            Console.WriteLine();

            Admin a2 = new Admin();
            a2.pol = "М";
            a2.number = "315235";
            a2.fio = "Ждук Б.С.";
            a2.nomer = "107";
            a2.Write();
            a2.Vyvod();
            a2.FIO();
            a2.Kab();
            Console.ReadKey();
        }
    }
}