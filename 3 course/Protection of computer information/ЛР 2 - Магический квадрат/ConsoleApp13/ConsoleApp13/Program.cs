using System;
using System.Text;

namespace MagicSquare.Console
{
    class Program
    {
        static void Main(string[] args)
        {            
            int side;
            do
            {
                System.Console.Write("Введите размерность квадрата (нечетное) N от 3 до 10: ");
                side = int.Parse(System.Console.ReadLine());
            } while (side > 10 | side < 2 | side % 2 != 1);

            var squareNumber = 0;
            var encryptPhrase = new StringBuilder();
            var dimension = Convert.ToInt32(Math.Pow(side, 2));

            string inputPhrase;
            do
            {
                System.Console.WriteLine($"Введите фразу длиной в n^2 ({dimension}) или более:");
                inputPhrase = System.Console.ReadLine();
            } while (inputPhrase.Length < Math.Pow(side, 2));

            var count = inputPhrase.Length;
            var countBox = count % dimension == 0 ? count / dimension: count / dimension + 1;

            var magicSquare = MagicSquare.CreateMagicSquare(side);
            PrintMagicSquare(magicSquare, side);
            for (var currentSquareNumber = 0; currentSquareNumber < countBox; currentSquareNumber++)
            {
                var encryptMagicSquare = MagicSquare.EncryptMagicSquare(inputPhrase.Substring(squareNumber * dimension), side, magicSquare);
                encryptPhrase.Append(MagicSquare.EncryptPhrase(side, encryptMagicSquare));

                System.Console.WriteLine("Зашифрованный квадрат №{0}: ", currentSquareNumber + 1);
                PrintEncryptMagicSquare(side, encryptMagicSquare);

                squareNumber++;
            }

            System.Console.WriteLine("Зашифрованная фраза: ");
            System.Console.WriteLine(encryptPhrase);
            System.Console.ReadKey();
        }

        private static void PrintMagicSquare(int[,] magicSquare, int n)
        {
            System.Console.WriteLine("Магический квадрат: ");
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    System.Console.Write("{0}  ", magicSquare[i, j]);
                }

                System.Console.WriteLine();
            }
        }

        public static void PrintEncryptMagicSquare(int side, string[,] encryptMagicSquare)
        {
            for (var i = 0; i < side; i++)
            {
                for (var j = 0; j < side; j++)
                {
                    System.Console.Write("{0}  ", encryptMagicSquare[i, j]);
                }

                System.Console.WriteLine();
            }
        }
    }
}