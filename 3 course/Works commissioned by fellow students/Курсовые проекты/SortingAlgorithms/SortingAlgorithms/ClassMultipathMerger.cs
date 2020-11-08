using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    class ClassMultipathMerger
    {
        static public int[] Merger(int[] stwol)
        {
            int n = stwol.Length;
            int[,] yorg = new int[n, n];
            int[] mas = new int[n];
            for (int i = 0; i < n; i++)
                mas[i] = stwol[i];

            int a = 0;
            int b = 0;
            int leg = mas[0];
            yorg[a, b] = leg;

            for (int i = 1; i < n; i++)
            {
                if (mas[i] > leg)
                {
                    b++;
                    yorg[a, b] = mas[i];
                    leg = mas[i];
                }
                else
                {
                    a++;
                    b = 0;
                    yorg[a, b] = mas[i];
                    leg = mas[i];
                }
            }

            a++;
            int[] kaskad = new int[a];
            int[] stalagmit = new int[n];
            int min;
            min = stwol.Max();
            for (int j = 0; j < n; j++)
            {

                b = 0;
                for (int i = 0; i < a; i++)
                {
                    if (yorg[i, (kaskad[i])] < min && yorg[i, (kaskad[i])] != 0)
                    {
                        min = yorg[i, (kaskad[i])];
                        b = i;
                    }
                }
                stalagmit[j] = min;
                kaskad[b]++;
                min = stwol.Max();
            }
            return stalagmit;
        }
    }
}
