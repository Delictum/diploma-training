using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] PasR = new string[5];
            PasR[0] = "а";
            PasR[1] = "б";
            PasR[2] = "в";

            string Pas = "", buf, login;
            int n, temp;

            Console.WriteLine("Придумайте логин");
            login = Console.ReadLine();

            back: Console.WriteLine("Задайте длину пароля от 6 до 20.");
            n = Int32.Parse(Console.ReadLine());
            if (n < 6 | n > 20)
            {
                Console.Clear();
                goto back;
            }

            Console.WriteLine("Для усиления пароля введите 1.");
            string y = Console.ReadLine();

            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                temp = rand.Next(0, 2);
                if (temp == 1 && y == "1")
                {
                    buf = PasR[rand.Next(0, 3)];
                    Pas = Pas + buf;
                }
                else
                    Pas = Pas + rand.Next(0, 10);
            }

            Console.WriteLine("Ваш пароль: {0}", Pas);

            LogPas: Console.WriteLine("Введите ваши данные для входа в программу:");
            Console.WriteLine("Логин:");
            string loginP = Console.ReadLine();
            Console.WriteLine("Пароль:");
            string PasswordP = Console.ReadLine();
            if (login == loginP && Pas == PasswordP)
            {
                Console.WriteLine("Вы успешно вошли в программу.");
            }
            else
            {
                Console.WriteLine("Данные введены неверно, повторите попытку.");
                goto LogPas;
            }
        }
    }
}
