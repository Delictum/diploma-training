using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Matrix
    {
        public int[,] A, B;
        public int n, Z, x, y;

        public Matrix(int n)
        {
            this.A = new int[n, n];
            this.B = new int[n, n];
            this.n = n;
        }

        public int MtIn()
        {
            Random rand = new Random();
            Console.WriteLine("Матрица A: ");
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)         
                    A[i, j] = rand.Next(0, 10);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)                
                    Console.Write("{0} ", A[i, j]);                
                Console.WriteLine();
            }
            MtX();

            Console.WriteLine("Матрица B: ");
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    B[i, j] = rand.Next(0, 10);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                    Console.Write("{0} ", B[i, j]);
                Console.WriteLine();
            }

            MtY();
            Vector();
            return (0);
        }

        protected int MtX()
        {
            int min = 10;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (i == j && min > A[i, j])
                    {
                        min = A[i, j];
                        x = i;
                    }            
            return x;
        }

        protected int MtY()
        {
            int min = 10;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    if (i == j && min > B[i, j])
                    {
                        min = B[i, j];
                        y = i;
                    }
            return y;
        }

        protected int Vector()
        {
            Console.WriteLine("X: {0}, Y: {1}", x, y);
            Z = MtX() + MtY();
            Console.WriteLine("Вектор: {0}", Z);
            return Z;
        }
    }

    public class Program
    {
        /*
         * Заданы две матрицы А (4, 4) и В (4, 4). 
         * Написать программу вычисления вектора Z = X + Y, где X - строка матрицы А,
         * включающая минимальный элемент ее главной диагонали, Y - то же для матрицы В.      
         */
        static void Main(string[] args)
        {
            Matrix Mt = new Matrix(4);
            
            Mt.MtIn();                      
            
            Console.ReadKey();
        }
    }
}
