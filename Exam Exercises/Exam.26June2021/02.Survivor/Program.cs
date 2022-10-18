using System;

namespace _02.Survivor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            char[][] beach = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                beach[row] = string.Join("", Console.ReadLine().
                    Split(" ", StringSplitOptions.RemoveEmptyEntries)).ToCharArray();
            }

            int tokens = 0;
            int opponentTokens = 0;

            string command = null;

            while ((command = Console.ReadLine()) != "Gong")
            {
                string[] action = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int row = int.Parse(action[1]);
                int col = int.Parse(action[2]);

                if (!IsIndexesValid(row, col, beach)) continue;


                if (action[0] == "Find")
                {
                    if (beach[row][col] == 'T')
                    {
                        beach[row][col] = '-';
                        tokens++;
                    }
                }
                else
                {
                    string direction = action[3];

                    for (int i = 0; i < 4; i++)
                    {
                        if (beach[row][col] == 'T')
                        {
                            beach[row][col] = '-';
                            opponentTokens++;
                        }

                        switch (direction)
                        {
                            case "up":
                                row--;
                                break;
                            case "down":
                                row++;
                                break;
                            case "left":
                                col--;
                                break;
                            case "right":
                                col++;
                                break;
                        }

                        if (!IsIndexesValid(row, col, beach)) break;
                    }
                }
            }

            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine(string.Join(" ", beach[row]));
            }

            Console.WriteLine($"Collected tokens: {tokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }

        static bool IsIndexesValid(int row, int col, char[][] beach)
        {
            return row >= 0 && col >= 0 && row < beach.GetLength(0) && col < beach[row].Length;
        }
    }
}
