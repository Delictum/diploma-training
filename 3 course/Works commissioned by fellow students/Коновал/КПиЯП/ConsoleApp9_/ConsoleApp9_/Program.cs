using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9_
{
    class Time
    {
        public int h;
        public int m;
        public int s;
        public string hms;
        public DateTime st;
        public TimeSpan sec;

        public Time(int h, int m, int s, string hms, DateTime st, TimeSpan sec)
        {
            this.h = h;
            this.m = m;
            this.s = s;
            this.hms = hms;
            this.st = st;
            this.sec = sec;
        }

        public void Info()
        {            
            Console.WriteLine("Время числами - {0}:{1}:{2}", h, m, s);
            Console.WriteLine("Время строкой - " + hms);
            Console.WriteLine("Время датой - {0}", st.ToLongTimeString());
            Console.WriteLine("Время секундами - {0}", sec);        
        }

        protected int SecInt()
        {
            return h * 3600 + m * 60 + s;
        }

        protected int SecStr()
        {
            return int.Parse(hms.Substring(0, 2)) * 3600 + int.Parse(hms.Substring(3, 2)) * 60 + int.Parse(hms.Substring(6, 2));
        }

        protected double SecDT()
        {
            DateTime dt1970 = new DateTime(2017, 12, 23, 0, 0, 0);
            TimeSpan tsInterval = st.Subtract(dt1970);
            return tsInterval.TotalSeconds;
        }        

        public int SecR()
        {
            return SecInt() - SecStr();
        }

        public void SecS()
        {
            st.Add(sec);
            Console.WriteLine(st.ToLongTimeString());
        }

        public TimeSpan TimeR(int seconds)
        {
            TimeSpan interval = TimeSpan.FromSeconds(seconds);
            return sec - interval;
        }

        public void TimeSravn()
        {
            if (SecInt() > SecStr())
                Console.WriteLine("Время из величин целого типа больше времени строкового представления.");
            else if (SecInt() < SecStr())
                Console.WriteLine("Время из величин целого типа меньше времени строкового представления.");
            else
                Console.WriteLine("Время из величин целого типа равно времени строкового представления.");
        }

        public void SecTranslate()
        {
            Console.WriteLine("Перевод времени в секунды: ");
            Console.WriteLine("Целый тип: " + SecInt());
            Console.WriteLine("Строковый тип: " + SecStr());
            Console.WriteLine("Тип даты: " + SecDT());
        }

        protected int MinInt()
        {
            if (s >= 30)
                return h * 60 + m + 1;
            else
                return h * 60 + m;
        }

        protected int MinStr()
        {
            if (int.Parse(hms.Substring(6, 2)) >= 30)
                return int.Parse(hms.Substring(0, 2)) * 60 + int.Parse(hms.Substring(3, 2)) + 1;
            else
                return int.Parse(hms.Substring(0, 2)) * 60 + int.Parse(hms.Substring(3, 2));
        }

        protected double MinDT()
        {
            DateTime dt1970 = new DateTime(2017, 12, 23, 0, 0, 0);
            TimeSpan tsInterval = st.Subtract(dt1970);
            return Math.Round(tsInterval.TotalMinutes);
        }

        public void MinTranslate()
        {
            Console.WriteLine("Перевод времени в минуты: ");
            Console.WriteLine("Целый тип: " + MinInt());
            Console.WriteLine("Строковый тип: " + MinStr());
            Console.WriteLine("Тип даты: " + MinDT());
        }
    }

    /* Создать класс Time для работы со временем в формате «час:минута:секунда». 
     * Класс должен включать в себя не менее четырех функций инициализации: числами, строкой (например, «23:59:59»), секундами и временем. 
     * Обязательными являются операции:
       •	вычисления разницы между двумя моментами времени в секундах;
       •	сложение времени и заданного количества секунд;
       •	вычитание из времени заданного количества секунд;
       •	сравнение моментов времени;
       •	перевод в секунды;
       •	перевод в минуты (с округлением до целой минуты).
    */

    class Program
    {
        static void Main(string[] args)
        {
            DateTime dt = new DateTime(2017, 12, 23, 23, 30, 25);
            Time t = new Time(12, 12, 12, "04:50:49", dt, TimeSpan.FromSeconds(69));
            t.Info();
            Console.WriteLine("Вычитание из времени целого типа время строкового типа: " + t.SecR());
            Console.WriteLine("Сложение времени из соответсвующего типа с типом временного интервала секунд: ");
            t.SecS();            
            Console.Write("Задайте количество секунд для вычета: ");
            int sec = int.Parse(Console.ReadLine());
            Console.WriteLine(t.TimeR(sec));
            t.TimeSravn();
            t.SecTranslate();
            t.MinTranslate();
        }
    }
}
