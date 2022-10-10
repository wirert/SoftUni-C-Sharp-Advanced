using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            string[,] matrix = new string[size[0], size[1]];

            for (int row = 0; row < size[0]; row++)
            {
                string[] inputRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < size[1]; col++)
                {
                    matrix[row, col] = inputRow[col];
                }
            }

            string[] cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (cmd[0] != "END")
            {
                if (!IsCommandValid(cmd, size[0], size[1]))
                {
                    Console.WriteLine("Invalid input!");
                }
                else
                {
                    int row1 = int.Parse(cmd[1]);
                    int col1 = int.Parse(cmd[2]);
                    int row2 = int.Parse(cmd[3]);
                    int col2 = int.Parse(cmd[4]);

                    (matrix[row1, col1], matrix[row2, col2]) = (matrix[row2, col2], matrix[row1, col1]);

                    PrintMatrix(matrix);
                }

                cmd = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

        }

        static bool IsCommandValid(string[] cmd, int rows, int cols)
        {
            return cmd.Length == 5 && cmd[0] == "swap"
                                       && int.Parse(cmd[1]) >= 0 && int.Parse(cmd[1]) < rows
                                       && int.Parse(cmd[2]) >= 0 && int.Parse(cmd[2]) < cols
                                       && int.Parse(cmd[3]) >= 0 && int.Parse(cmd[3]) < rows
                                       && int.Parse(cmd[4]) >= 0 && int.Parse(cmd[4]) < cols;
        }

        static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
