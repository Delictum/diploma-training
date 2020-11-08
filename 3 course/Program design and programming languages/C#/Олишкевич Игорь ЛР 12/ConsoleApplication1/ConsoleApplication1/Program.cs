using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
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
            Console.WriteLine("Шепот: \"Свет меня предал, во тьме я обрету отмщение\".");
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
            s += "! ";
            return Ev3(s);
        }
    }

    class Program
    {
        abstract public class Transport
        {
            public string toplivo;
            public void Vyvod()
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
                Deleg2 del2 = delegate ()
                {
                    Console.WriteLine("Анонимный метод автомобиля.");
                };
                del2();
            }                        
        }

        class Train : Express
        {
            public string vagon;
            public virtual void Wagon()
            {
                Console.WriteLine("Вагон - " + vagon);
                Deleg1 del1 = delegate ()
                {
                    Console.WriteLine("Аноним: 'Справедливость восторжествует!'");
                };
                del1();
            }
        }

        static Deleg3 D(string sss)
        {
            string ss = "Hey, ";
            Deleg3 del3 = delegate (string s)
            {
                ss += s + "Very well.";
                return ss;
            };
            return del3;
        }

        static void Main(string[] args)
        {
            {
                Events evt = new Events();
                string sss = "good play";                               
                evt.Ev3 += D(sss);
                Console.WriteLine("Событие: {0}", evt.OnEv3(sss));
                Console.WriteLine();

                Auto transport1 = new Auto();
                transport1.toplivo = "бензин";
                transport1.nomer = "134";
                transport1.mesto = "19";
                transport1.Vyvod();                
                evt.Ev2 += transport1.Place;
                transport1.Number();
                evt.OnEv2();

                Console.WriteLine();

                Train transport2 = new Train();
                transport2.toplivo = "электричество";
                transport2.nomer = "563";
                transport2.vagon = "07С";
                transport2.Vyvod();
                evt.Ev1 += transport2.Wagon;
                transport2.Number();
                evt.OnEv1();
                Console.ReadKey();
            }

        }
    }
}
