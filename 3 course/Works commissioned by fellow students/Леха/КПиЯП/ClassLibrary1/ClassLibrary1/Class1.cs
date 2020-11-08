using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class ArrayOperation
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
}
