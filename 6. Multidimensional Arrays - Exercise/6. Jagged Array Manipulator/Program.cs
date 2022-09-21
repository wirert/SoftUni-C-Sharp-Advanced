using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            double[][] jaggedMatrix = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                jaggedMatrix[row] = Console.ReadLine().Split().Select(double.Parse).ToArray();
            }

            MultiplyOrDivideElementsInRows(rows, jaggedMatrix);

            string[] command = Console.ReadLine().Split();

            while (command[0] != "End")
            {
                AddOrSubtractElementsIfValid(rows, jaggedMatrix, command);

                command = Console.ReadLine().Split();
            }

            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine(string.Join(" ", jaggedMatrix[row]));
            }
        }

        private static void MultiplyOrDivideElementsInRows(int rows, double[][] jaggedMatrix)
        {
            for (int row = 0; row < rows - 1; row++)
            {
                if (jaggedMatrix[row].Length == jaggedMatrix[row + 1].Length)
                {
                    for (int element = 0; element < jaggedMatrix[row].Length; element++)
                    {
                        jaggedMatrix[row][element] *= 2;
                        jaggedMatrix[row + 1][element] *= 2;
                    }
                }
                else
                {
                    for (int element = 0; element < jaggedMatrix[row].Length; element++)
                    {
                        jaggedMatrix[row][element] /= 2;
                    }

                    for (int element = 0; element < jaggedMatrix[row + 1].Length; element++)
                    {
                        jaggedMatrix[row + 1][element] /= 2;
                    }
                }
            }
        }

        static void AddOrSubtractElementsIfValid(int rows, double[][] jaggedMatrix, string[] command)
        {
            int row = int.Parse(command[1]);
            int col = int.Parse(command[2]);
            int value = int.Parse(command[3]);

            if (row < 0 || row >= rows || col < 0 || col >= jaggedMatrix[row].Length) return;

            if (command[0] == "Add")
            {
                jaggedMatrix[row][col] += value;
            }
            else
            {
                jaggedMatrix[row][col] -= value;
            }
        }
    }
}
