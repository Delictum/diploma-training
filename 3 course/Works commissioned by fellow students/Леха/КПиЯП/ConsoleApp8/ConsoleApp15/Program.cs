using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConsoleApp3
{
    struct Worker
    {        
        public string Name;
        public string Dolz;
        public DateTime DP;
        public DateTime SDK;
        public int Oklad;

        public Worker(string Name, string Dolz, DateTime DP,
            DateTime SDK, int Oklad)
        {
            this.Name = Name;
            this.Dolz = Dolz;
            this.DP = DP;
            this.SDK = SDK;
            this.Oklad = Oklad;
        }

    }

    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("Кол-во работников: ");
                int n = int.Parse(Console.ReadLine());
                Worker[] Workers = new Worker[n];
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Заполнение данных {0} работника.", i + 1);
                    Console.Write("Фамилия: ");
                    string Name = Console.ReadLine();
                    Console.Write("Должность: ");
                    string Dolz = Console.ReadLine();
                    Console.Write("Дата подписания контракта: ");
                    DateTime DP = DateTime.Parse(Console.ReadLine());
                    Console.Write("Срок действия контракта: ");
                    DateTime SDK = DateTime.Parse(Console.ReadLine());                                   
                    Console.Write("Оклад: ");
                    int Oklad = Int32.Parse(Console.ReadLine());
                    Console.WriteLine();
                    Workers[i] = new Worker(Name, Dolz, DP, SDK, Oklad);
                }

                Console.WriteLine("Информация о работниках с истечением контракта через 5 дней:");
                foreach (Worker a in Workers)
                {
                    if (a.SDK == DateTime.Today.AddDays(5))
                    {
                        Console.WriteLine("Фамилия: {0}", a.Name);
                        Console.WriteLine("Должность:{0}", a.Dolz);
                        Console.WriteLine("Дата подписания контракта: {0}", a.DP);
                        Console.WriteLine("Срок действия контракта: {0}", a.SDK);
                        Console.WriteLine("Оклад: {0}", a.Oklad);
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}
