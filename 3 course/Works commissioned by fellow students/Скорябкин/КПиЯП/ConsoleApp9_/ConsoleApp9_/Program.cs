using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9_
{
    namespace vector
    {
        class Program
        {
            class Param
            {
                public int Length;
                public int Start;
                public int End;
                int[] Arr;

                public void Cr_arr(int[] Arr, int Length, int Start, int End)
                {
                    Console.WriteLine("Вывод массива: ");
                    Random R = new Random();
                    for (int i = 0; i < Length; i++)
                    {
                        Arr[i] = R.Next(Start, End);
                        Console.Write("{0} ", Arr[i]);
                    }
                    Console.WriteLine();
                }
                public void SumArr(int[] a, int[] b, int[] c)
                {
                    Console.WriteLine("Сложение массивов: ");
                    for (int i = 0; i < Length; i++)
                    {
                        c[i] = a[i] + b[i];
                        Console.Write("{0} ", c[i]);                        
                    }
                    Console.WriteLine();
                }
                public void SustractArr(int[] a, int[] b, int[] c)
                {
                    Console.WriteLine("Вычитание массивов: ");
                    for (int i = 0; i < Length; i++)
                    {                        
                        c[i] = a[i] - b[i];
                        Console.Write("{0} ", c[i]);                        
                    }
                    Console.WriteLine();
                }
                public void skal_mult(int[] a, int temp)
                {
                    Console.WriteLine("Сколярное сложение массива: ");
                    for (int i = 0; i < Length; i++)
                    {                        
                        a[i] *= temp;
                        Console.Write("{0} ", a[i]);                        
                    }
                    Console.WriteLine();
                }
                public void skal_del(int[] a, int temp)
                {
                    Console.WriteLine("Сколярное вычитание массива: ");
                    for (int i = 0; i < Length; i++)
                    {                        
                        a[i] /= temp;
                        Console.Write("{0} ", a[i]);                        
                    }
                    Console.WriteLine();
                }
            }

            static void Main()
            {
                Param one = new Param();
                Param two = new Param();
                Param three = new Param();

                one.Length = 10;
                one.Start = 1;
                one.End = 12;

                two.Length = 10;
                two.Start = -3;
                two.End = 9;

                three.Length = 10;
                three.Start = 1;
                three.End = 12;

                int[] One = new int[one.Length];
                int[] Two = new int[two.Length];
                int[] Three = new int[three.Length];

                one.Cr_arr(One, one.Length, one.Start, one.End);
                two.Cr_arr(Two, two.Length, two.Start, two.End);
                three.Cr_arr(Three, three.Length, three.Start, three.End);

                try
                {
                    Console.Write("индекс элемента = ");
                    int i = Int16.Parse(Console.ReadLine());
                    Console.WriteLine("One[{0}]={1}", i, One[i]);
                }
                catch { Console.WriteLine("индекс элемента выходит за рамки массива"); }

                one.SumArr(One, Two, Three);
                one.SustractArr(One, Two, Three);
                one.skal_mult(One, 3);
                one.skal_del(One, 2);
                Console.ReadKey();

            }
        }        
    }
}
