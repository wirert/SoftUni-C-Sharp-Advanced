using System;
using System.Linq;

namespace _02.Warships
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string[] coordinates = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);

            char[,] field = new char[size, size];
            int firstPlayerShips = 0;
            int secondPlayerShips = 0;

            for (int row = 0; row < size; row++)
            {
                var cols = string.Join("",Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
                    
                for (int col = 0; col < size; col++)
                {
                    field[row, col] = cols[col];

                    if (cols[col] == '<')
                    {
                        firstPlayerShips++;
                    }
                    else if (cols[col] == '>')
                    {
                        secondPlayerShips++;
                    }
                }
            }

            int firstPlSunkShips = 0;
            int secondPlSunkShips = 0;            

            foreach (var item in coordinates)
            {
                var coordinate =item.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (!int.TryParse(coordinate[0], out int row)) continue;
                if (!int.TryParse(coordinate[1], out int col)) continue;
                                

                ShootToCoordinates(field, row, col, ref firstPlSunkShips, ref secondPlSunkShips);

                if (secondPlayerShips == secondPlSunkShips)
                {
                    Console.WriteLine($"Player One has won the game! {firstPlSunkShips + secondPlSunkShips} ships have been sunk in the battle.");

                    return;
                }

                if (firstPlayerShips == firstPlSunkShips)
                {
                    Console.WriteLine($"Player Two has won the game! {firstPlSunkShips + secondPlSunkShips} ships have been sunk in the battle.");

                    return;
                }
            }

            Console.WriteLine($"It's a draw! Player One has {firstPlayerShips - firstPlSunkShips} ships left. Player Two has {secondPlayerShips - secondPlSunkShips} ships left.");
        }

        private static void ShootToCoordinates(char[,] field, int row, int col, ref int firstPlSunkShips, ref int secondPlSunkShips)
        {
            if (!IsCoordinatesValid(row, col, field.GetLength(0)) || field[row, col] == '*' || field[row, col] == 'X')
                return;

            if (field[row, col] == '>')
            {
                secondPlSunkShips++;
            }
            else if (field[row, col] == '<')
            {                
                firstPlSunkShips++;
            }
            else if (field[row, col] == '#')
            {
                ShootToCoordinates(field, row - 1, col - 1, ref firstPlSunkShips, ref secondPlSunkShips);
                ShootToCoordinates(field, row - 1, col, ref firstPlSunkShips, ref secondPlSunkShips);
                ShootToCoordinates(field, row - 1, col + 1, ref firstPlSunkShips, ref secondPlSunkShips);
                ShootToCoordinates(field, row, col - 1, ref firstPlSunkShips, ref secondPlSunkShips);
                ShootToCoordinates(field, row, col + 1, ref firstPlSunkShips, ref secondPlSunkShips);
                ShootToCoordinates(field, row + 1, col - 1, ref firstPlSunkShips, ref secondPlSunkShips);
                ShootToCoordinates(field, row + 1, col, ref firstPlSunkShips, ref secondPlSunkShips);
                ShootToCoordinates(field, row + 1, col + 1, ref firstPlSunkShips, ref secondPlSunkShips);
            }

            field[row, col] = 'X';
        }

        private static bool IsCoordinatesValid(int row, int col, int size)
            => row >= 0 && row < size
            && col >= 0 && col < size;
    }
}
