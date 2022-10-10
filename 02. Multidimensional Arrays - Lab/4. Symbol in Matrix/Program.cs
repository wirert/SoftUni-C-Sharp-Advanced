using System;

namespace _4._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string inputRow = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = inputRow[col];
                }
            }

            char charToLookFor = char.Parse(Console.ReadLine());

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] != charToLookFor) continue;

                    Console.WriteLine($"({row}, {col})");
                    return;
                }
            }

            Console.WriteLine($"{charToLookFor} does not occur in the matrix");
        }
    }
}
