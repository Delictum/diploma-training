using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StructApp
{
    abstract class Place
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
        }
    }

    class Megapolis : City
    {
        public string mesto;
        public virtual void Place()
        {
            Console.WriteLine("Площадь: " + mesto);
        }
    }

    class Capital : City
    {
        public string popular;
        public virtual void Popular()
        {
            Console.WriteLine("Площадь: " + popular);
        }
    }
    /*
    class Admin : Inzener
    {
        public string nomer;
        public virtual void Kab()
        {
            Console.WriteLine("Номер личного кабинета: " + nomer);
        }
    }
    */
    class Program
    {
        static void Main(string[] args)
        {
            Megapolis a1 = new Megapolis();
            a1.pol = "40.7143528, -74.0059731";
            a1.number = "5";
            a1.name = "New-York";
            a1.mesto = "789 км2";
            a1.Write();
            a1.Vyvod();
            a1.Name();
            a1.Place();

            Console.WriteLine();

            Capital a2 = new Capital();
            a2.pol = "55.4521, 37.3704";
            a2.number = "125";
            a2.name = "Москва";
            a2.popular = "15 512 000";
            a2.Write();
            a2.Vyvod();
            a2.Name();
            a2.Popular();
            Console.ReadKey();
        }
    }
}