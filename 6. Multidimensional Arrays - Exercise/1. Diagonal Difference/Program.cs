using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] inputRow = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = inputRow[col];
                }
            }

            int firstDiagonal = 0;
            int secondDiagonal = 0;

            for (int i = 0, j = size - 1; i < size; i++, j--)
            {
                firstDiagonal += matrix[i, i];
                secondDiagonal += matrix[i, j];
            }

            Console.WriteLine(Math.Abs(firstDiagonal - secondDiagonal));
        }
    }
}
