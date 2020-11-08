using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9_
{
    class Account
    {
        public string family;
        public int number;
        public double procent;
        public double sum;

        public Account(string family, int number, double procent, double sum)
        {
            this.family = family;
            this.number = number;
            this.procent = procent;
            this.sum = sum;
        }

        public void Info()
        {
            Console.WriteLine("Данные владельца: ");
            Console.WriteLine("1) фамилия: {0};", family);
            Console.WriteLine("2) номер счёта: {0};", number);
            Console.WriteLine("3) процент начисления: {0};", procent);
            Console.WriteLine("4) сумма в рублях: {0}р.", sum);        
        }

        public double SumM(double n)
        {
            if (sum > n)
                sum = sum - n;
            else
            {
                Console.WriteLine("Недостаточная суммы на счёте для снятия денег, повторите ввод.");
                n = double.Parse(Console.ReadLine());
                SumM(n);                
            }
            return sum;
        }

        public double SumP(double n)
        {
            return sum += n;
        }   
        
        public void Propis()
        {
            int number = Convert.ToInt32(sum);
            int[] array_int = new int[4];
            string[,] array_string = new string[4, 3] {{" миллиард", " миллиарда", " миллиардов"},
                {" миллион", " миллиона", " миллионов"},
                {" тысяча", " тысячи", " тысяч"},
                {"", "", ""}};
            array_int[0] = (number - (number % 1000000000)) / 1000000000;
            array_int[1] = ((number % 1000000000) - (number % 1000000)) / 1000000;
            array_int[2] = ((number % 1000000) - (number % 1000)) / 1000;
            array_int[3] = number % 1000;
            string result = "";
            for (int i = 0; i < 4; i++)
            {
                if (array_int[i] != 0)
                {
                    if (((array_int[i] - (array_int[i] % 100)) / 100) != 0)
                        switch (((array_int[i] - (array_int[i] % 100)) / 100))
                        {
                            case 1: result += " сто"; break;
                            case 2: result += " двести"; break;
                            case 3: result += " триста"; break;
                            case 4: result += " четыреста"; break;
                            case 5: result += " пятьсот"; break;
                            case 6: result += " шестьсот"; break;
                            case 7: result += " семьсот"; break;
                            case 8: result += " восемьсот"; break;
                            case 9: result += " девятьсот"; break;
                        }
                    if (((array_int[i] % 100) - ((array_int[i] % 100) % 10)) / 10 != 1)
                    {
                        switch (((array_int[i] % 100) - ((array_int[i] % 100) % 10)) / 10)
                        {
                            case 2: result += " двадцать"; break;
                            case 3: result += " тридцать"; break;
                            case 4: result += " сорок"; break;
                            case 5: result += " пятьдесят"; break;
                            case 6: result += " шестьдесят"; break;
                            case 7: result += " семьдесят"; break;
                            case 8: result += " восемьдесят"; break;
                            case 9: result += " девяносто"; break;
                        }
                    }
                    switch (array_int[i] % 10)
                    {
                        case 1: if (i == 2) result += " одна"; else result += " один"; break;
                        case 2: if (i == 2) result += " две"; else result += " два"; break;
                        case 3: result += " три"; break;
                        case 4: result += " четыре"; break;
                        case 5: result += " пять"; break;
                        case 6: result += " шесть"; break;
                        case 7: result += " семь"; break;
                        case 8: result += " восемь"; break;
                        case 9: result += " девять"; break;
                    }
                }
                else switch (array_int[i] % 100)
                    {
                        case 10: result += " десять"; break;
                        case 11: result += " одиннадцать"; break;
                        case 12: result += " двенадцать"; break;
                        case 13: result += " тринадцать"; break;
                        case 14: result += " четырнадцать"; break;
                        case 15: result += " пятнадцать"; break;
                        case 16: result += " шестнадцать"; break;
                        case 17: result += " семнадцать"; break;
                        case 18: result += " восемннадцать"; break;
                        case 19: result += " девятнадцать"; break;
                    }
                if (array_int[i] % 100 >= 10 && array_int[i] % 100 <= 19) result += " " + array_string[i, 2] + " ";
                else switch (array_int[i] % 10)
                    {
                        case 1: result += " " + array_string[i, 0] + " "; break;
                        case 2:
                        case 3:
                        case 4: result += " " + array_string[i, 1] + " "; break;
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9: result += " " + array_string[i, 2] + " "; break;
                    }
            }
            Console.WriteLine("Сумма прописью: " + result);
        }

        /* 
           Реализовать класс Account, представляющий собой банковский счет. 
           В классе должны быть четыре поля: фамилия владельца, номер счета, процент начисления, сумма в рублях. 
           Открытие нового счета выполняется операцией инициализации. Предусмотреть возможность выполнения следующих операций:
           •	смена владельца счета;
           •	снятие некоторой суммы со счета;
           •	добавление некоторой суммы на счет;
           •	начисление процентов;
           •	перевод суммы в доллары;
           •	перевод суммы в евро;
           •	получение суммы прописью (преобразовать в числительное).
        */

        class Program
        {
            static void Main(string[] args)
            {
                Account acc = new Account("Кузьменко", 532521621, 1.43, 531.63);
                acc.Info();

                acc.family = "Новый_владелец";
                Console.WriteLine("Фамилия нового владельца: " + acc.family);

                Console.Write("Введите сумму для снятия со счета: ");
                double n = double.Parse(Console.ReadLine());
                acc.SumM(n);
                Console.WriteLine("Оставшаяся сумма на счёте: {0}р.", acc.sum);

                Console.Write("Введите сумму для увеличения счета: ");
                n = double.Parse(Console.ReadLine());
                acc.SumP(n);
                Console.WriteLine("Новая сумма на счёте: {0}р.", acc.sum);

                acc.sum *= acc.procent;
                Console.WriteLine("Сумма с начисленными процентами: {0}р.", acc.sum);

                Console.WriteLine("Сумма в долларах: {0}$", acc.sum * 0.9);
                Console.WriteLine("Сумма в евро: {0}€", acc.sum * 0.45);

                acc.Propis();
            }
        }
    }
}
