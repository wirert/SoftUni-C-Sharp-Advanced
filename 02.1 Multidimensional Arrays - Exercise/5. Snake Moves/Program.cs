using System;
using System.Linq;

namespace _5._Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[,] matrix = new char[size[0], size[1]];
            string snake = Console.ReadLine();
            int indexSnake = 0;

            for (int row = 0; row < size[0]; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < size[1]; col++)
                    {
                        matrix[row, col] = snake[indexSnake];
                        indexSnake++;

                        if (indexSnake == snake.Length)
                        {
                            indexSnake = 0;
                        }
                    }
                }
                else
                {
                    for (int col = size[1] - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snake[indexSnake];
                        indexSnake++;

                        if (indexSnake == snake.Length)
                        {
                            indexSnake = 0;
                        }
                    }
                }
            }

            for (int row = 0; row < size[0]; row++)
            {
                for (int col = 0; col < size[1]; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
