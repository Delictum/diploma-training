using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Program
    {
        class Massiv
        {
            public int[] m;
            public int n1;
            public int n2;

            public Massiv(int[] m, int n1, int n2)
            {
                this.m = m;
                this.n1 = n1;
                this.n2 = n2;
            }

            public int MasIn()
            {
                Random rand = new Random();
                for (int i = n1; i < n2; i++)
                    m[i] = rand.Next(0, 10);
                return (0);
            }

            public void MasOut()
            {
                for (int i = n1; i < n2; i++)
                    Console.Write("{0} ", m[i]);
                Console.WriteLine();
            }

            public void MasElemOut(int nn)
            {
                Console.WriteLine("{0} ", m[nn]);
            }
        }

        /*
         * Составить описание класса для определения одномерных массивов целых чисел (векторов). 
         * Матрицы заполняются с помощью генератора случайных чисел. 
         * Предусмотреть возможность выполнения следующих операций, для чего разработать соответствующие методы:

         * · обращения к отдельному элементу массива с контролем выхода за пределы массива;
         * · возможность задания произвольных границ индексов при создании объекта;
         * · выполнение операций поэлементного сложения и вычитания массивов с одинаковыми границами индексов;
         * · умножения и деления всех элементов массива на скаляр;
         * · вывода на экран элемента массива по заданному индексу;
         * · вывода на экран всего массива. 
         */
        static void Main(string[] args)
        {
            int menu;
            Console.Write("Введите количество массивов: ");
            int count = int.Parse(Console.ReadLine());
            Massiv[] mas = new Massiv[count];

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Данные {0} массива", i);
                Console.Write("Введите начало границы массива: ");
                int n1 = int.Parse(Console.ReadLine());
                Console.Write("Введите конец границы массива: ");
                int n2 = int.Parse(Console.ReadLine());
                int[] m = new int[n2 - n1];
                mas[i] = new Massiv(m, n1, n2);
                mas[i].MasIn();
            }
            try
            {
                do
                {
                    Console.Write("Меню:\n1) Вывод всего массива 1\n2) Вывод элемента массива 2\n3) Выйти из программы\n\nВаше решение: ");
                    menu = int.Parse(Console.ReadLine());
                    switch (menu)
                    {
                        case 1:                       
                            Console.Write("Введите номер массива: ");
                            back1: int NumMas = int.Parse(Console.ReadLine());
                            if (NumMas >= count)
                            {
                                Console.Write("Массива под данным номером не существует. Повторите ввод: ");
                                goto back1;
                            }
                            mas[NumMas].MasOut();
                            break;

                        case 2:
                            Console.Write("Введите номер массива: ");
                            back2: NumMas = int.Parse(Console.ReadLine());
                            if (NumMas >= count)
                            {
                                Console.Write("Массива под данным номером не существует. Повторите ввод: ");
                                goto back2;
                            }
                            Console.Write("Введите номер элмента массива: ");
                            back3: int NumMasElem = int.Parse(Console.ReadLine());
                            if (NumMasElem < mas[NumMas].n1 || NumMasElem > mas[NumMas].n2)
                            {
                                Console.Write("Элемент не входит в границу массива. Повторите ввод: ");
                                goto back3;
                            }
                            mas[NumMas].MasElemOut(NumMasElem);
                            break;

                        case 3:
                            Console.WriteLine("Вы решили выйти");
                            break;
                        default:
                            Console.WriteLine("Вы что-то другое нажали...");
                            break;
                    }
                    Console.Write("\n\n\t\t\tНажмите любую клавишу...");
                    Console.ReadLine();
                    Console.Clear();
                }
                while (menu != 3);
            }
            catch (Exception Chto_to_poshlo_ne_tak)
            {
                Console.WriteLine("Произошла ошибка: \"{0}\"", Chto_to_poshlo_ne_tak);
            }
            finally
            {
                Console.WriteLine("Конец.");
                Console.ReadKey();
            }
        }
    }
}
