using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    class ClassInsert
    {
        static public int[] SortInsertMethod(int[] arr)
        {
            int x, i, j;
            for (i = 0; i < arr.Length; i++)
            {
                x = arr[i];
                for (j = i - 1; j >= 0 && arr[j] > x; j--)
                    arr[j + 1] = arr[j];

                arr[j + 1] = x;
            }
            return arr;
        }
    }
}
