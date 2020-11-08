using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StructApp
{

    class Transport
    {
        public string toplivo;
        public virtual void Vyvod()
        {
            Console.WriteLine("Источник энергии - " + toplivo);
        }
    }

    class Express : Transport
    {
        public string nomer;
        public virtual void Number()
        {
            Console.WriteLine("Номер маршрута - " + nomer + "\"Э\"");
        }
    }
    class Auto : Express
    {
        public string mesto;
        public virtual void Place()
        {
            Console.WriteLine("Место - " + mesto);
        }
    }

    class Train : Express
    {
        public string vagon;
        public virtual void Wagon()
        {
            Console.WriteLine("Вагон - " + vagon);
        }
    }




    class Program
    {
        static void Main(string[] args)
        {
            Auto transport1 = new Auto();
            transport1.toplivo = "бензин";
            transport1.nomer = "134";
            transport1.mesto = "19";
            transport1.Vyvod();
            transport1.Number();
            transport1.Place();

            Console.WriteLine();

            Train transport2 = new Train();
            transport2.toplivo = "электричество";
            transport2.nomer = "563";
            transport2.vagon = "07С";
            transport2.Vyvod();
            transport2.Number();
            transport2.Wagon();
            Console.ReadKey();
        }
    }
}