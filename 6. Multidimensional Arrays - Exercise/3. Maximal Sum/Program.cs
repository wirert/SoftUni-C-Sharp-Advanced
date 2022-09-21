using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[,] matrix = new int[size[0], size[1]];

            for (int row = 0; row < size[0]; row++)
            {
                int[] inputRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < size[1]; col++)
                {
                    matrix[row, col] = inputRow[col];
                }
            }

            int maxSum = int.MinValue;
            int startRow = 0;
            int startCol = 0;

            for (int row = 0; row < size[0] - 2; row++)
            {
                for (int col = 0; col < size[1] - 2; col++)
                {
                    int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                              + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                              + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (sum <= maxSum) continue;

                    maxSum = sum;
                    startCol = col;
                    startRow = row;
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int row = startRow; row < startRow + 3; row++)
            {
                for (int col = startCol; col < startCol + 3; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
