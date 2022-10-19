using System;
using System.Linq;

namespace _02.SuperMario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lives = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());

            char[][] maze = new char[rows][];
            int curRow = 0;
            int curCol = 0;

            for (int row = 0; row < rows; row++)
            {
                string inputCol = Console.ReadLine();
                maze[row] = inputCol.ToCharArray();

                if (inputCol.Contains('M'))
                {
                    curRow = row;
                    curCol = inputCol.IndexOf('M');
                }
            }

            while (true)
            {
                string[] action = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int spawnRow = int.Parse(action[1]);
                int spawnCol = int.Parse(action[2]);

                maze[spawnRow][spawnCol] = 'B';
                int oldRow = curRow;
                int oldCol = curCol;
                maze[oldRow][oldCol] = '-';

                switch (action[0])
                {
                    case "W":
                        curRow--;
                        break;
                    case "S":
                        curRow++;
                        break;
                    case "A":
                        curCol--;
                        break;
                    case "D":
                        curCol++;
                        break;
                }

                lives--;

                if (curRow < 0 || curRow >= rows || curCol < 0 || curCol >= maze[curRow].Length)
                {
                    curRow = oldRow;
                    curCol = oldCol;
                }

                if (maze[curRow][curCol] == 'B')
                {
                    lives -= 2;
                }
                else if (maze[curRow][curCol] == 'P')
                {
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                    maze[curRow][curCol] = '-';
                    break;
                }

                if (lives <= 0)
                {
                    Console.WriteLine($"Mario died at {curRow};{curCol}.");
                    maze[curRow][curCol] = 'X';
                    break;
                }

                maze[curRow][curCol] = 'M';
            }

            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine(string.Join("", maze[row]));
            }
        }
    }
}
