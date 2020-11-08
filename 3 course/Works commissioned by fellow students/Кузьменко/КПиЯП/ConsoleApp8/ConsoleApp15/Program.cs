using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConsoleApp3
{
    struct Auto
    {
        public string MA;
        public string PR;
        public string TY;
        public int GV;
        public DateTime DR;

        public Auto(string MA, string PR, string TY, int GV, DateTime DR)
        {
            this.MA = MA;
            this.PR = PR;
            this.TY = TY;
            this.GV = GV;
            this.DR = DR;
        }
    }

    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("Кол-во машин: ");
                int n = int.Parse(Console.ReadLine());
                Auto[] au = new Auto[n];
                double sum = 0, sr = 0;
                int[] mas = new int[n];
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Заполнение данных {0} машины.", i + 1);
                    Console.Write("Марка: ");
                    string MA = Console.ReadLine();
                    Console.Write("Производитель: ");
                    string PR = Console.ReadLine();
                    Console.Write("Тип: ");
                    string TY = Console.ReadLine();
                    Console.Write("Год выпуска: ");
                    int GV = Int32.Parse(Console.ReadLine());
                    Console.Write("Дата регистрации: ");
                    DateTime DR = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine();
                    au[i] = new Auto(MA, PR, TY, GV, DR);                    
                }
                
                Console.WriteLine("Сведения о машинах, произведенных до 2010-го года и зарегистрированных менее года назад: ");
                foreach (Auto a in au)
                {
                    if (a.GV < 2010 && a.DR > DateTime.Today.AddDays(-365))
                    {
                        Console.WriteLine("Марка: {0}", a.MA);
                        Console.WriteLine("Производитель: {0}", a.PR);
                        Console.WriteLine("Тип: {0}", a.TY);
                        Console.WriteLine("Год выпуска: {0}", a.GV);
                        Console.WriteLine("Дата регистрации: {0}", a.DR);
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
