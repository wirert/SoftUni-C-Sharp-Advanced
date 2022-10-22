using System;

namespace _02.RallyRacing
{
    public class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string racingNumber = Console.ReadLine();
            char[][] raceRoute = new char[size][];

            for (int row = 0; row < size; row++)
            {
                char[] cols = string.Join("", Console.ReadLine().
                    Split(" ", StringSplitOptions.RemoveEmptyEntries)).ToCharArray();

                raceRoute[row] = cols;
            }

            int curRow = 0;
            int curCol = 0;
            int kilometers = 0;

            string direction = null;

            bool isCarFinishes = IsFinish(raceRoute, curRow, curCol);

            while ((direction = Console.ReadLine()) != "End" && !isCarFinishes)
            {
                if (IsTunnel(raceRoute, ref curRow, ref curCol))
                {
                    kilometers += 30;
                }

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

                if (raceRoute[curRow][curCol] == '.')
                {
                    kilometers += 10;
                }
                else if (IsTunnel(raceRoute, ref curRow, ref curCol))
                {
                    kilometers += 30;
                }
                else if (IsFinish(raceRoute, curRow, curCol))
                {
                    isCarFinishes = true;
                    kilometers += 10;
                }

                raceRoute[curRow][curCol] = '.';
            }

            raceRoute[curRow][curCol] = 'C';

            Console.WriteLine(isCarFinishes
                ? $"Racing car {racingNumber} finished the stage!"
                : $"Racing car {racingNumber} DNF.");

            Console.WriteLine($"Distance covered {kilometers} km.");

            for (int row = 0; row < size; row++)
            {
                Console.WriteLine(string.Join("", raceRoute[row]));
            }
        }

        public static bool IsFinish(char[][] raceRoute, int curRow, int curCol)
        {
            if (raceRoute[curRow][curCol] != 'F') return false;

            return true;
        }

        public static bool IsTunnel(char[][] raceRoute, ref int curRow, ref int curCol)
        {
            if (raceRoute[curRow][curCol] != 'T') return false;

            raceRoute[curRow][curCol] = '.';

            for (int row = 0; row < raceRoute.GetLength(0); row++)
            {
                bool foundT = false;

                for (int col = 0; col < raceRoute[row].Length; col++)
                {
                    if (raceRoute[row][col] == 'T')
                    {
                        curRow = row;
                        curCol = col;
                        foundT = true;
                        break;
                    }
                }

                if (foundT) break;
            }

            return true;
        }
    }
}
