using System;
using System.Drawing;
using System.Linq;

namespace _02.TruffleHunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] forest = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                char[] cols = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    forest[row, col] = cols[col];
                }
            }

            int whiteTruffles = 0;
            int blackTruffles = 0;
            int summerTruffles = 0;
            int eatenTrufflesByBoar = 0;

            string command;

            while ((command = Console.ReadLine()) != "Stop the hunt")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (tokens[0])
                {
                    case "Collect":
                        int row = int.Parse(tokens[1]);
                        int col = int.Parse(tokens[2]);

                        if (row >= 0 && row < size && col >= 0 && col < size)
                        {
                            switch (forest[row, col])
                            {
                                case 'W':
                                    whiteTruffles++;
                                    break;
                                case 'B':
                                    blackTruffles++;
                                    break;
                                case 'S':
                                    summerTruffles++;
                                    break;
                            }

                            forest[row, col] = '-';
                        }

                        break;
                    case "Wild_Boar":

                        eatenTrufflesByBoar = BoarEatTruffles(forest, eatenTrufflesByBoar, tokens);

                        break;
                }
            }

            Console.WriteLine($"Peter manages to harvest {blackTruffles} black, {summerTruffles} summer, and {whiteTruffles} white truffles.");

            Console.WriteLine($"The wild boar has eaten {eatenTrufflesByBoar} truffles.");

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write($"{forest[row, col]} ");
                }

                Console.WriteLine();
            }
        }

        private static int BoarEatTruffles(char[,] forest, int eatenTrufflesByBoar, string[] tokens)
        {
            int size = forest.Length;
            int row = int.Parse(tokens[1]);
            int col = int.Parse(tokens[2]);
            string direction = tokens[3];

            switch (direction)
            {
                case "up":
                    for (int i = row; i >= 0; i -= 2)
                    {
                        if (forest[i, col] == '-') continue;

                        forest[i, col] = '-';

                        eatenTrufflesByBoar++;
                    }
                    break;
                case "down":
                    for (int i = row; i < size; i += 2)
                    {
                        if (forest[i, col] == '-') continue;

                        forest[i, col] = '-';

                        eatenTrufflesByBoar++;
                    }
                    break;
                case "left":
                    for (int i = col; i >= 0; i -= 2)
                    {
                        if (forest[row, i] == '-') continue;

                        forest[row, i] = '-';

                        eatenTrufflesByBoar++;
                    }
                    break;
                case "right":
                    for (int i = col; i < size; i += 2)
                    {
                        if (forest[row, i] == '-') continue;

                        forest[row, i] = '-';

                        eatenTrufflesByBoar++;
                    }
                    break;
            }

            return eatenTrufflesByBoar;
        }
    }
}
