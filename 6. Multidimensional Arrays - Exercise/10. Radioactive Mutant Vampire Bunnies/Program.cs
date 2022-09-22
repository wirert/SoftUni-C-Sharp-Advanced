using System;
using System.Linq;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = sizes[0];
            int cols = sizes[1];
            var matrix = new char[rows, cols];

            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < rows; row++)
            {
                string inputRow = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = inputRow[col];

                    if (inputRow[col] != 'P') continue;

                    playerRow = row;
                    playerCol = col;
                }
            }

            string moves = Console.ReadLine();

            foreach (var move in moves)
            {
                bool win = false;
                bool lose = false;

                int newPlayerRow = playerRow;
                int newPlayerCol = playerCol;

                switch (move)
                {
                    case 'U':
                        matrix[newPlayerRow, newPlayerCol] = '.';
                        newPlayerRow--;
                        MovePlayer(newPlayerRow, newPlayerCol, matrix, ref win, ref lose);
                        break;
                    case 'D':
                        matrix[newPlayerRow, newPlayerCol] = '.';
                        newPlayerRow++;
                        MovePlayer(newPlayerRow, newPlayerCol, matrix, ref win, ref lose);
                        break;
                    case 'L':
                        matrix[newPlayerRow, newPlayerCol] = '.';
                        newPlayerCol--;
                        MovePlayer(newPlayerRow, newPlayerCol, matrix, ref win, ref lose);
                        break;
                    case 'R':
                        matrix[newPlayerRow, newPlayerCol] = '.';
                        newPlayerCol++;
                        MovePlayer(newPlayerRow, newPlayerCol, matrix, ref win, ref lose);
                        break;
                }

                matrix = SpreadBunnies(matrix, ref lose);

                if (win)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"won: {playerRow} {playerCol}");
                    return;
                }

                playerRow = newPlayerRow;
                playerCol = newPlayerCol;

                if (lose)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"dead: {newPlayerRow} {newPlayerCol}");
                    return;
                }
            }
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static char[,] SpreadBunnies(char[,] matrix, ref bool lose)
        {
            char[,] copyMatrix = CopyMatrix(matrix);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] != 'B') continue;

                    if (IsIndexValid(row - 1, col, matrix))
                    {
                        if (matrix[row - 1, col] == 'P')
                        {
                            lose = true;
                        }

                        copyMatrix[row - 1, col] = 'B';
                    }

                    if (IsIndexValid(row + 1, col, matrix))
                    {
                        if (matrix[row + 1, col] == 'P')
                        {
                            lose = true;
                        }

                        copyMatrix[row + 1, col] = 'B';
                    }

                    if (IsIndexValid(row, col - 1, matrix))
                    {
                        if (matrix[row, col - 1] == 'P')
                        {
                            lose = true;
                        }

                        copyMatrix[row, col - 1] = 'B';
                    }

                    if (IsIndexValid(row, col + 1, matrix))
                    {
                        if (matrix[row, col + 1] == 'P')
                        {
                            lose = true;
                        }

                        copyMatrix[row, col + 1] = 'B';
                    }
                }
            }

            return copyMatrix;
        }

        private static char[,] CopyMatrix(char[,] matrix)
        {
            char[,] copy = new char[matrix.GetLength(0), matrix.GetLength(1)];

            for (int row = 0; row < copy.GetLength(0); row++)
            {
                for (int col = 0; col < copy.GetLength(1); col++)
                {
                    copy[row, col] = matrix[row, col];
                }
            }

            return copy;
        }

        private static void MovePlayer(int playerRow, int playerCol, char[,] matrix, ref bool win, ref bool lose)
        {
            if (IsIndexValid(playerRow, playerCol, matrix))
            {
                if (matrix[playerRow, playerCol] == 'B')
                {
                    lose = true;
                }
                else
                {
                    matrix[playerRow, playerCol] = 'P';
                }
            }
            else
            {
                win = true;
            }
        }

        private static bool IsIndexValid(int playerRow, int playerCol, char[,] matrix)
        {
            return (playerRow >= 0 && playerRow < matrix.GetLength(0)
                                   && playerCol >= 0
                                   && playerCol < matrix.GetLength(1));
        }
    }
}
