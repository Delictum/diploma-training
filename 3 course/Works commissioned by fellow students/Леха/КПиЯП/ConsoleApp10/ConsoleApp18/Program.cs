using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StructApp
{
    //Тест, экзамен, выпускной экзамен, испытание 
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
        }
    }
    class Vipusk : Exzamen
    {
        public string ocenka;
        public virtual void P()
        {
            Console.WriteLine("Оценка выпускного экзамена " + ocenka);
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
        static void Main(string[] args)
        {
            Vipusk t1 = new Vipusk();
            t1.testing = "1";
            t1.nomer = "7";
            t1.ocenka = "4";
            t1.Vyvod();
            t1.Number();
            t1.P();

            Console.WriteLine();

            Ispit t2 = new Ispit();
            t2.testing = "2";
            t2.nomer = "5";
            t2.time = "3 часа";
            t2.Vyvod();
            t2.Number();
            t2.T();
            Console.ReadKey();
        }
    }
}