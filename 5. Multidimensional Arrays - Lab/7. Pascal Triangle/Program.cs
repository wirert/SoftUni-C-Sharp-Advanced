using System;

namespace _7._Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            long [][] pascalTriangle = new long[rows][];

            pascalTriangle[0] = new long[] { 1 };

            for (int row = 1; row < rows; row++)
            {
                pascalTriangle[row] = new long[row + 1];

                for (int col = 0; col < row + 1; col++)
                {
                    if (col == 0 || col == row)
                    {
                        pascalTriangle[row][col] = 1;
                    }
                    else
                    {
                        pascalTriangle[row][col] = pascalTriangle[row - 1][col] + pascalTriangle[row - 1][col - 1];
                    }
                }
            }

            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine(string.Join(" ", pascalTriangle[row]));
            }
        }
    }
}
