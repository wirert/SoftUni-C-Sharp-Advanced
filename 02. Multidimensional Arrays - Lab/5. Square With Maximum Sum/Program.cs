using System;
using System.Linq;

namespace _5._Square_With_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int[,] matrix = new int[size[0], size[1]];

            for (int row = 0; row < size[0]; row++)
            {
                int[] inputRow = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < size[1]; col++)
                {
                    matrix[row, col] = inputRow[col];
                }
            }

            int maxSum = int.MinValue;
            int rowStartIndex = 0;
            int colStartIndex = 0;

            for (int row = 0; row < size[0] - 1; row++)
            {
                for (int col = 0; col < size[1] - 1; col++)
                {
                    int subMatrixSum = matrix[row, col] + matrix[row + 1, col] + matrix[row, col + 1] + matrix[row + 1, col + 1];

                    if (subMatrixSum <= maxSum) continue;

                    maxSum = subMatrixSum;
                    rowStartIndex = row;
                    colStartIndex = col;
                }
            }

            Console.WriteLine($"{matrix[rowStartIndex, colStartIndex]} {matrix[rowStartIndex, colStartIndex + 1]}");
            Console.WriteLine($"{matrix[rowStartIndex + 1, colStartIndex]} {matrix[rowStartIndex + 1, colStartIndex + 1]}");
            Console.WriteLine(maxSum);
        }
    }
}
