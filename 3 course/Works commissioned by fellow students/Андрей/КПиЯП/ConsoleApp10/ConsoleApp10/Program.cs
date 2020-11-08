using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StructApp
{
    abstract public class Rassa
    {
        public string naimenovanie;
        public void Write()
        {
            Console.WriteLine("Расса - " + naimenovanie);
        }
    }

    class Persona : Rassa
    {
        public string FIO;
        public virtual void Vyvod()
        {
            Console.WriteLine("ФИО - " + FIO);
        }
    }

    class Sluzh : Persona
    {
        public string srok;
        public virtual void Srok()
        {
            Console.WriteLine("Срок службы - " + srok);
        }
    }
    class Worker : Sluzh
    {
        public string rabot;
        public virtual void Rabot()
        {
            Console.WriteLine("Количество выполненных работ - " + rabot);
        }
    }

    class Inzener : Sluzh
    {
        public string proekt;
        public virtual void Proekt()
        {
            Console.WriteLine("Количество завершенных проектов - " + proekt);
        }
    }




    class Program
    {
        static void Main(string[] args)
        {
            Inzener people1 = new Inzener();
            people1.naimenovanie = "Человек";
            people1.FIO = "Мнелик И.И.";
            people1.srok = "12";
            people1.proekt = "19";
            people1.Write();
            people1.Vyvod();
            people1.Srok();
            people1.Proekt();

            Console.WriteLine();

            Worker people2 = new Worker();
            people2.naimenovanie = "Гуманоид";
            people2.FIO = "Ланда В.Б.";
            people2.srok = "3";
            people2.rabot = "256";
            people2.Write();
            people2.Vyvod();
            people2.Srok();
            people2.Rabot();
            Console.ReadKey();
        }
    }
}