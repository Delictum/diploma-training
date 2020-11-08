using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StructApp
{
    delegate void D();
    delegate void De();
    delegate string Del();

    abstract public class Persona
    {
        public string FIO;
        public virtual void Vyvod()
        {
            Console.WriteLine("ФИО - " + FIO);
        }
    }

    class Events
    {
        public event D E;
        public void EOn()
        {
            E();
            Console.WriteLine("Событие 1 произошло.");
        }

        public event De Ev;
        public void EvOn()
        {
            Ev();
            Console.WriteLine("Событие 2 произошло.");
        }

        public event Del Eve;
        public string EveOn()
        {
            Console.WriteLine("Общее событие произошло.");
            return Eve();            
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
            D d = delegate ()
            {
                Console.WriteLine("Анонимный метод 2.");
            };
            d();
        }
    }

    class Inzener : Sluzh
    {
        public string proekt;
        public virtual void Proekt()
        {
            Console.WriteLine("Количество завершенных проектов - " + proekt);
            De de = delegate ()
            {
                Console.WriteLine("Анонимный метод 1.");
            };
            de();
        }
    }

    class Program
    {
        static Del D()
        {
            Del del = delegate ()
            {
                string ss = "Общий анонимный метод.";
                return ss;
            };
            return del;
        }

        static void Main(string[] args)
        {
            Events evt = new Events();
            evt.Eve += D();
            Console.WriteLine(evt.EveOn());
            Console.WriteLine();

            Inzener people1 = new Inzener();
            people1.FIO = "Мнелик И.И.";
            people1.srok = "12";
            people1.proekt = "19";
            people1.Vyvod();
            evt.E += people1.Proekt;
            people1.Srok();
            evt.EOn();

            Console.WriteLine();

            Worker people2 = new Worker();
            people2.FIO = "Ланда В.Б.";
            people2.srok = "3";
            people2.rabot = "256";
            people2.Vyvod();
            people2.Srok();
            evt.Ev += people2.Rabot;
            evt.EvOn();
            Console.ReadKey();
        }
    }
}