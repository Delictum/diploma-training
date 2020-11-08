using System;
using System.Collections;

namespace lab2223
{
    class Program
    {
        static void Main()
        {
            int m = 10;
            int[] chisla = new int[m];
            Random rand = new Random(((int)DateTime.Now.Ticks));
            for (int i = 0; i < chisla.Length; i++)
            {
                chisla[i] = rand.Next(1, 100);
            }


            Console.WriteLine("Heshirovanie so spiskami m=10");
            int[] chisla1 = new int[m];
            Random rand1 = new Random(((int)DateTime.Now.Ticks));
            for (int i = 0; i < chisla1.Length; i++)
            {
                chisla1[i] = rand.Next(1, 1000);
            }
            Hashtable ht2 = new Hashtable();
            for (int i = 0; i < 10; i++)
            {
                ht2.Add(chisla1[i] + " ", " " + chisla1[i] / 2 + 6);
            }
            ICollection keys1 = ht2.Keys;
            foreach (string s1 in keys1)
                Console.WriteLine(s1 + ": " + ht2[s1]);
            Console.ReadKey();
        }
    }
}

