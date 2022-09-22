
using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._Miner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            var moves = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));

            char[,] matrix = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                char[] inputRow = Console.ReadLine().Split().Select(char.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = inputRow[col];
                }
            }

            int allCoals = 0;
            int minerRow = 0;
            int minerCol = 0;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == '*') continue;

                    switch (matrix[row, col])
                    {
                        case 'c':
                            allCoals++;
                            break;
                        case 's':
                            minerRow = row;
                            minerCol = col;
                            matrix[row, col] = '*';
                            break;
                    }
                }
            }

            int coalCollected = 0;

            while (moves.Any())
            {
                string move = moves.Dequeue();

                switch (move)
                {
                    case "left":
                        if (minerCol - 1 >= 0)
                        {
                            minerCol -= 1;

                            if (IsExitFound(matrix, minerRow, minerCol)) return;

                            coalCollected = AddCoalIfFound(matrix, minerRow, minerCol, coalCollected);
                        }
                        break;
                    case "right":
                        if (minerCol + 1 < size)
                        {
                            minerCol += 1;

                            if (IsExitFound(matrix, minerRow, minerCol)) return;

                            coalCollected = AddCoalIfFound(matrix, minerRow, minerCol, coalCollected);
                        }
                        break;
                    case "up":
                        if (minerRow - 1 >= 0)
                        {
                            minerRow -= 1;

                            if (IsExitFound(matrix, minerRow, minerCol)) return;

                            coalCollected = AddCoalIfFound(matrix, minerRow, minerCol, coalCollected);
                        }
                        break;
                    case "down":
                        if (minerRow + 1 < size)
                        {
                            minerRow += 1;

                            if (IsExitFound(matrix, minerRow, minerCol)) return;

                            coalCollected = AddCoalIfFound(matrix, minerRow, minerCol, coalCollected);
                        }
                        break;
                }

                if (coalCollected == allCoals)
                {
                    Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
                    return;
                }
            }

            Console.WriteLine($"{allCoals - coalCollected} coals left. ({minerRow}, {minerCol})");
        }

        private static int AddCoalIfFound(char[,] matrix, int minerRow, int minerCol, int coalCollected)
        {
            if (matrix[minerRow, minerCol] == 'c')
            {
                coalCollected++;
                matrix[minerRow, minerCol] = '*';
            }

            return coalCollected;
        }

        private static bool IsExitFound(char[,] matrix, int minerRow, int minerCol)
        {
            if (matrix[minerRow, minerCol] != 'e') return false;

            Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
            return true;

        }
    }
}
