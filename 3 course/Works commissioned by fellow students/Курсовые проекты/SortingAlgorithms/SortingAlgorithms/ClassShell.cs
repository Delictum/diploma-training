using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    class ClassShell
    {
        public static double T(int n)
        {
            return n * Math.Pow(Math.Log(n), 2);
        }

        static public int[] shellSort(int[] vector)
        {
            int step = vector.Length / 2;
            while (step > 0)
            {
                int i, j;
                for (i = step; i < vector.Length; i++)
                {
                    int value = vector[i];
                    for (j = i - step; (j >= 0) && (vector[j] > value); j -= step)
                        vector[j + step] = vector[j];
                    vector[j + step] = value;
                }
                step /= 2;
            }
            return vector;
        }
    }
}
