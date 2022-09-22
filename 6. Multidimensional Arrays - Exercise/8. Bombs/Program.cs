using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Bombs
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

            var bombs = new Queue<string>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));

            while (bombs.Any())
            {
                int[] bomb = bombs.Dequeue().Split(',').Select(int.Parse).ToArray();
                int rowBomb = bomb[0];
                int colBomb = bomb[1];

                BombCells(rowBomb, colBomb, matrix);
            }

            PrintRequiredOutput(matrix, size);
        }

        static void BombCells(int row, int col, int[,] matrix)
        {
            int value = matrix[row, col];

            if (value <= 0) return;

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int curRow = row + i;
                    int curCol = col + j;

                    if (IsCellValid(curRow, curCol, matrix))
                    {
                        matrix[curRow, curCol] -= value;
                    }
                }
            }
        }

        static bool IsCellValid(int row, int col, int[,] matrix)
        {
            int size = matrix.GetLength(0);

            return (row >= 0 && row < size && col >= 0 && col < size && matrix[row, col] > 0);
        }

        private static void PrintRequiredOutput(int[,] matrix, int size)
        {
            int aliveCells = 0;
            int sumOfAliveCells = 0;

            foreach (var cell in matrix)
            {
                if (cell <= 0) continue;

                aliveCells++;
                sumOfAliveCells += cell;
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sumOfAliveCells}");

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
