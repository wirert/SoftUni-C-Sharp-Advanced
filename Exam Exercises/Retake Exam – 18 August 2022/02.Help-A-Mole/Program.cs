using System;

namespace _02.Help_A_Mole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int currRow = 0;
            int currCol = 0;
            int points = 0;

            for (int row = 0; row < n; row++)
            {
                string cols = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = cols[col];

                    if (cols[col] == 'M')
                    {
                        currRow = row;
                        currCol = col;
                    }
                }
            }

            string command;
            bool isWin = false;

            while ((command = Console.ReadLine()) != "End")
            {
                int oldRow = currRow;
                int oldCol = currCol;
                switch (command)
                {
                    case "up":
                        currRow--;
                        break;
                    case "down":
                        currRow++;
                        break;
                    case "left":
                        currCol--;
                        break;
                    case "right":
                        currCol++;
                        break;
                }

                if (currRow < 0 || currCol < 0 || currRow >= n || currCol >= n)
                {
                    Console.WriteLine("Don't try to escape the playing field!");
                    currRow = oldRow;
                    currCol = oldCol;

                    continue;
                }

                matrix[oldRow, oldCol] = '-';

                if (matrix[currRow, currCol] == 'S')
                {
                    matrix[currRow, currCol] = '-';

                    for (int row = 0; row < n; row++)
                    {
                        bool findS = false;
                        for (int col = 0; col < n; col++)
                        {
                            if (matrix[row, col] == 'S')
                            {
                                currRow = row;
                                currCol = col;
                                points -= 3;
                                findS = true;
                                break;
                            }
                        }

                        if (findS) break;
                    }
                }

                if (char.IsDigit(matrix[currRow, currCol]))
                {
                    points += int.Parse(matrix[currRow, currCol].ToString());
                }

                matrix[currRow, currCol] = 'M';

                if (points >= 25)
                {
                    isWin = true;
                    break;
                }
            }

            if (isWin)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {points} points.");
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
