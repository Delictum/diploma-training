using System.Text;

namespace MagicSquare
{
    public static class MagicSquare
    {
        public static StringBuilder EncryptPhrase(int side, string[,] encryptMagicSquare)
        {
            var encryptPhrase = new StringBuilder();
            for (var i = 0; i < side; i++)
            {
                for (var j = 0; j < side; j++)
                {
                    encryptPhrase.Append(encryptMagicSquare[i, j]);
                }
            }

            return encryptPhrase;
        }

        public static string[,] EncryptMagicSquare(string inputPhrase, int side, int[,] magicSquare)
        {
            var encryptMagicSquare = new string[side, side];
            for (var i = 0; i < side; i++)
            {
                for (var j = 0; j < side; j++)
                {
                    if (inputPhrase.Length > magicSquare[i, j] - 1)
                    {
                        encryptMagicSquare[i, j] = inputPhrase.Substring(magicSquare[i, j] - 1, 1);
                    }
                    else
                    {
                        encryptMagicSquare[i, j] = string.Empty;
                    }
                }
            }

            return encryptMagicSquare;
        }

        public static int[,] CreateMagicSquare(int side)
        {
            var dimension = side * side;
            var magicSquare = new int[dimension, dimension];
            for (var i = 0; i < side; i++)
            {
                for (var j = 0; j < side; j++)
                {
                    magicSquare[i, j] = 1 + (i + j - 1 + (side - 1) / 2) % side * side + (i + 2 * j + 2) % side;
                }
            }

            return magicSquare;
        }
    }
}
