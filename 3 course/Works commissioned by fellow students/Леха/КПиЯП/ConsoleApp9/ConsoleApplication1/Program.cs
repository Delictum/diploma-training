using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class ArrayOperation
    {

        public int[] getChangedArray(int[] inArray)
        {
            int[] temp = new int[inArray.Length];
            Array.Copy(inArray, temp, temp.Length);

            int index_1 = Array.FindIndex(temp, i => (i < 0));
            int index_2 = Array.FindLastIndex(temp, i => (i < 0));

            if ((index_1 == temp.Length - 1) | (index_1 == index_2) | (index_2 == 0))
            {
                throw new InvalidOperationException("Операция невозможна для данного аргумента!");
            }
            else
            {
                int n = temp[0];
                temp[0] = temp[Array.FindIndex(temp, index_1 + 1, l => (l < 0))];
                temp[Array.FindIndex(temp, index_1 + 1, f => (f < 0))] = n;
            }
            return temp;
        }
    }

        class Program
    {
        static void Main(string[] args)
        {
            int[] arr_C = { 2, 5, 7, -3, 5, -1 };
            int[] arr_D = { 3, 65, 78, 23, -54, 23, 13, 41, -9, 32 };

            ArrayOperation operation = new ArrayOperation();

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
