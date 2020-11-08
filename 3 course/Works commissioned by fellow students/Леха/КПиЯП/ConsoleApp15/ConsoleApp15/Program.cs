using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr_C = { 2, 5, 7, -3, 5, -1 };
            int[] arr_D = { 3, 65, 78, 23, -54, 23, 13, 41, -9, 32 };

            var operation = new ClassLibrary1.ArrayOperation();

            try
            {
                int[] changedArray_C = operation.getChangedArray(arr_C);
                int[] changedArray_D = operation.getChangedArray(arr_D);

                Console.WriteLine("First Array:");
                foreach (int i in arr_C)
                {
                    Console.Write("{0} ", i);
                }
                Console.WriteLine("\nChanged First Array:");
                foreach (int i in changedArray_C)
                {
                    Console.Write("{0} ", i);
                }

                Console.WriteLine();

                Console.WriteLine("Second Array");
                foreach (int i in arr_D)
                {
                    Console.Write("{0} ", i);
                }
                Console.WriteLine("\nChanged Second Array:");
                foreach (int i in changedArray_D)
                {
                    Console.Write("{0} ", i);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
