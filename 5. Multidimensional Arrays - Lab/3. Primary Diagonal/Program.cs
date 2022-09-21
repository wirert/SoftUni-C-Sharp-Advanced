﻿using System;
using System.Linq;

namespace _3._Primary_Diagonal
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

            int diagonalSum = 0;

            for (int row = 0; row < size; row++)
            {
                diagonalSum += matrix[row, row];
            }

            Console.WriteLine(diagonalSum);
        }
    }
}
