using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        private static byte Prioritet(char v)
        {
            switch (v)
            {
                case '(':
                    return 0;
                case ')':
                    return 1;
                case '+':
                    return 2;
                case '-':
                    return 2;
                case '*':
                    return 3;
                case '/':
                    return 3;
                default:
                    return 3;
            }
        }

        private static bool operat(char v)
        {
            if (("+-/*^()".IndexOf(v) != -1))
                return true;
            return false;
        }

        //5,6-(3,2/0,9*(1,7+4,8))
        static void Main(string[] args)
        {
            Console.Write("Введите выражение: ");
            string input = Console.ReadLine();
            string output = string.Empty;

            Stack<char> Operacii = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                //При числе во входной строке записывает в результативную
                if (Char.IsDigit(input[i]))
                {
                    while (!operat(input[i]))
                    {
                        output += input[i];
                        i++;
                        if (i == input.Length)
                            break;
                    }
                    output = output + " ";
                    i--;
                }

                //При символе во входной строке записывает в результативную
                if (operat(input[i]))
                {
                    //Добавление в коллекцию при начале выражения в скобках
                    if (input[i] == '(')
                        Operacii.Push(input[i]);
                    //Извлечение из коллекции и запись в результативную пока не найдено начало нового выражения в скобках
                    else if (input[i] == ')')
                    {
                        char s = Operacii.Pop();
                        while (s != '(')
                        {
                            output += s.ToString() + ' ';
                            s = Operacii.Pop();
                        }
                    }
                    //Иначе если коллекция не пуста по приоритету записываем в результативную строку элемент
                    else
                    {
                        if (Operacii.Count > 0)
                            if (Prioritet(input[i]) <= Prioritet(Operacii.Peek()))
                                output = output + Operacii.Pop().ToString() + " ";
                        Operacii.Push(char.Parse(input[i].ToString()));
                    }
                }
            }
            //Извлечение оставшихся объектов в результативную строку
            while (Operacii.Count > 0)
                output += Operacii.Pop() + " ";
            Console.WriteLine("Выражение в обратной польской записи: " + output);

            double result = 0;
            Stack<double> StackReshenie = new Stack<double>();

            //Проход по результативной строке
            for (int i = 0; i < output.Length; i++)
            {
                //Записываем в новую строку до тех пор пока число, затем добавляем в коллекцию
                if (Char.IsDigit(output[i]))
                {
                    string a = string.Empty;
                    while (output[i] != ' ' && !operat(output[i]))
                    {
                        a = a + output[i];
                        i++;
                        if (i == output.Length)
                            break;
                    }
                    StackReshenie.Push(double.Parse(a));
                    i--;
                }
                //При встреченной операции извлекаем числа из коллекции и выполняем арифметическое действие
                else if (operat(output[i]))
                {
                    double a = StackReshenie.Pop();
                    double b = StackReshenie.Pop();
                    switch (output[i])
                    {
                        case '+': 
                            result = b + a;
                            break;
                        case '-': 
                            result = b - a;
                            break;
                        case '*': 
                            result = b * a;
                            break;
                        case '/': 
                            result = b / a;
                            break;
                    }
                    StackReshenie.Push(result); //Вставка результата в коллекцию
                }
            }
            Console.WriteLine("Ответ: " + StackReshenie.Peek()); //Выдача ответа
            Console.ReadKey();
        }        
    }
} 
