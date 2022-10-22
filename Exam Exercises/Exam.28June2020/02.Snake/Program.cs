using System;

namespace _02.Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] lair = new char[size, size];
            int curRow = 0;
            int curCol = 0;

            for (int row = 0; row < size; row++)
            {
                string cols = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    lair[row, col] = cols[col];

                    if (cols[col] == 'S')
                    {
                        curRow = row;
                        curCol = col;
                    }
                }
            }

            int eatenFood = 0;

            while (true)
            {
                string direction = Console.ReadLine();

                int oldRow = curRow;
                int oldCol = curCol;

                lair[oldRow, oldCol] = '.';

                switch (direction)
                {
                    case "up":
                        curRow--;
                        break;
                    case "down":
                        curRow++;
                        break;
                    case "left":
                        curCol--;
                        break;
                    case "right":
                        curCol++;
                        break;
                }

                if (curRow < 0 || curRow >= size || curCol < 0 || curCol >= size)
                {
                    Console.WriteLine("Game over!");
                    break;
                }

                if (lair[curRow, curCol] == '*')
                {
                    eatenFood++;
                }
                else if (lair[curRow, curCol] == 'B')
                {
                    lair[curRow, curCol] = '.';

                    for (int row = 0; row < size; row++)
                    {
                        for (int col = 0; col < size; col++)
                        {
                            if (lair[row, col] == 'B')
                            {
                                curRow = row;
                                curCol = col;
                            }
                        }
                    }
                }

                lair[curRow, curCol] = 'S';

                if (eatenFood >= 10)
                {
                    Console.WriteLine("You won! You fed the snake.");
                    break;
                }

            }

            Console.WriteLine($"Food eaten: {eatenFood}");

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(lair[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
