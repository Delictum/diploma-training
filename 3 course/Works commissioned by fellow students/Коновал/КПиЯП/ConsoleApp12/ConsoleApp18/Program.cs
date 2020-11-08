using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StructApp
{
    delegate void D();
    delegate void De();
    delegate string Del();

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

    class Place
    {
        public string pol;
        public void Write()
        {
            Console.WriteLine("Координаты: " + pol);
        }
    }

    class Oblast : Place
    {
        public string number;
        public virtual void Vyvod()
        {
            Console.WriteLine("Количество районов: " + number);
        }
    }

    class City : Oblast
    {
        public string name;
        public virtual void Name()
        {
            Console.WriteLine("Название: " + name);
            D d = delegate ()
            {
                Console.WriteLine("Анонимный метод 1.");
            };
            d();
        }
    }

    class Megapolis : City
    {
        public string mesto;
        public virtual void Place()
        {
            Console.WriteLine("Площадь: " + mesto);
            De de = delegate ()
            {
                Console.WriteLine("Анонимный метод 2.");
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

            Megapolis a1 = new Megapolis();
            a1.pol = "40.7143528, -74.0059731";
            a1.number = "5";
            a1.name = "New-York";
            a1.mesto = "789 км2";
            a1.Write();
            evt.E += a1.Vyvod;
            evt.EOn();
            a1.Name();
            evt.Ev += a1.Place;
            evt.EvOn();

            Console.ReadKey();
        }
    }
}