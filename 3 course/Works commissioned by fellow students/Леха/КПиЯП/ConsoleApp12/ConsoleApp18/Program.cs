using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StructApp
{
    delegate void Deleg1();
    delegate void Deleg2();
    delegate string Deleg3();

    class Events
    {
        public event Deleg1 Ev1;
        public void OnEv1()
        {
            Ev1();
            Console.WriteLine("Событие 1.");
        }

        public event Deleg2 Ev2;
        public void OnEv2()
        {
            Ev2();
            Console.WriteLine("Событие 2.");
        }

        public event Deleg3 Ev3;
        public string OnEv3()
        {
            return Ev3();
        }
    }

    class Test
    {
        public string testing;
        public virtual void Vyvod()
        {
            Console.WriteLine("Тест " + testing);
        }
    }

    class Exzamen : Test
    {
        public string nomer;
        public virtual void Number()
        {
            Console.WriteLine("Экзамен " + nomer);
            Deleg1 del1 = delegate ()
            {
                Console.WriteLine("Анонимный метод 1");
            };
            del1();
        }
    }
    class Vipusk : Exzamen
    {
        public string ocenka;
        public virtual void P()
        {
            Console.WriteLine("Оценка выпускного экзамена " + ocenka);
            Deleg2 del2 = delegate ()
            {
                Console.WriteLine("Анонимный метод 2");
            };
            del2();
        }
    }    

    class Ispit : Exzamen
    {
        public string time;
        public virtual void T()
        {
            Console.WriteLine("Продолжительность испытания " + time);
        }
    }




    class Program
    {
        static Deleg3 D()
        {
            Console.WriteLine("Делегат");
            Deleg3 del3 = delegate ()
            {
                Console.WriteLine("Событие 3");
                return ("");
            };
            return del3;
        }

        static void Main(string[] args)
        {
            Events evt = new Events();
            evt.Ev3 += D();
            Console.WriteLine(evt.OnEv3());
            Console.WriteLine();

            Vipusk t1 = new Vipusk();
            t1.testing = "1";
            t1.nomer = "7";
            t1.ocenka = "4";
            t1.Vyvod();
            evt.Ev1 += t1.P;
            t1.Number();
            evt.OnEv1();

            Console.WriteLine();

            Ispit t2 = new Ispit();
            t2.testing = "2";
            t2.nomer = "5";
            t2.time = "3 часа";
            t2.Vyvod();
            evt.Ev2 += t2.Number;
            t2.T();
            evt.OnEv2();
            Console.ReadKey();
        }
    }
}