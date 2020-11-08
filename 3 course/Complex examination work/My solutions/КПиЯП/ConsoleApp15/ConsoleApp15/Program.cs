using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    class Program
    {
        /* Описать структуру с именем WORKER, содержащую следующие поля:
           •	Фамилия и инициалы работника;
           •	Название занимаемой должности;
           •	Год поступления на работу.
           Написать программу, выполняющую ввод с клавиатуры данных в массив, 
           состоящий из десяти структур типа WORKER; записи должны быть размещены по алфавиту.
        */
        struct Worker
        {
            public string FIO;
            public string Dolg;
            public int Year;

            public Worker(string fio, string dolg, int year)
            {
                this.FIO = fio;
                this.Dolg = dolg;
                this.Year = year;
            }
        }

        static void Main(string[] args)
        {
            int n = 2;
            Worker[] work = new Worker[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Заполнение данных {0} работника", i + 1);
                Console.Write("Введите ФИО: ");
                string fio = Console.ReadLine();
                Console.Write("Введите должность: ");
                string dolg = Console.ReadLine();
                Console.Write("Введите год поступления на работу: ");
                int year = int.Parse(Console.ReadLine());
                work[i] = new Worker(fio, dolg, year);
                Console.WriteLine();
            }

            foreach (Worker a in work.OrderBy(itm => itm.FIO))
            {
                Console.WriteLine("ФИО: {0}", a.FIO);
                Console.WriteLine("Название должности: {0}", a.Dolg);
                Console.WriteLine("Год поступления на работу: {0}", a.Year);
                Console.WriteLine();
            }
        }
    }
}
