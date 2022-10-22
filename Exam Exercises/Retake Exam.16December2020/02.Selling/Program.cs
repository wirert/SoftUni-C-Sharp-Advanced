using System;

namespace _02.Selling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] bakery = new char[size, size];

            int curRow = 0;
            int curCol = 0;

            for (int row = 0; row < size; row++)
            {
                string cols = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    bakery[row, col] = cols[col];

                    if (cols[col] == 'S')
                    {
                        curRow = row;
                        curCol = col;
                    }
                }
            }

            int money = 0;

            while (true)
            {
                string direction = Console.ReadLine();
                int oldRow = curRow;
                int oldCol = curCol;

                bakery[oldRow, oldCol] = '-';

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
                    Console.WriteLine("Bad news, you are out of the bakery.");

                    break;
                }

                if (bakery[curRow, curCol] == 'O')
                {
                    bakery[curRow, curCol] = '-';

                    for (int row = 0; row < size; row++)
                    {
                        bool isFound = false;

                        for (int col = 0; col < size; col++)
                        {
                            if (bakery[row, col] == 'O')
                            {
                                curRow = row;
                                curCol = col;
                                isFound = true;
                                break;
                            }
                        }

                        if (isFound) break;
                    }
                }
                else if (char.IsDigit(bakery[curRow, curCol]))
                {
                    money += int.Parse(bakery[curRow, curCol].ToString());
                }

                bakery[curRow, curCol] = 'S';

                if (money >= 50)
                {
                    Console.WriteLine("Good news! You succeeded in collecting enough money!");

                    break;
                }
            }

            Console.WriteLine($"Money: {money}");

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(bakery[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
