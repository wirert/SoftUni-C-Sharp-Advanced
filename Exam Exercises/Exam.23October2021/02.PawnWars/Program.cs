using System;

namespace _02.PawnWars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[,] board = new char[8, 8];

            int blackRow = 0;
            int blackCol = 0;
            int whiteRow = 0;
            int whiteCol = 0;

            for (int row = 0; row < 8; row++)
            {
                string cols = Console.ReadLine();

                for (int col = 0; col < 8; col++)
                {
                    board[row, col] = cols[col];

                    if (cols[col] == 'w')
                    {
                        whiteRow = row;
                        whiteCol = col;
                    }
                    else if (cols[col] == 'b')
                    {
                        blackRow = row;
                        blackCol = col;
                    }
                }
            }

            Func<int, int, string> TransformCoordinates = (row, col) =>
            {
                return ((char)(col + 97)).ToString() + (8 - row).ToString();
            };

            while (true)
            {
                if (whiteRow == 0)
                {
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {TransformCoordinates(whiteRow, whiteCol)}.");

                    return;
                }

                bool isWhiteWin = false;

                if (whiteRow - 1 >= 0 && whiteCol - 1 >= 0
                    && board[whiteRow - 1, whiteCol - 1] == 'b')
                {
                    isWhiteWin = true;
                }
                else if (whiteRow - 1 >= 0 && whiteCol + 1 < 8
                    && board[whiteRow - 1, whiteCol + 1] == 'b')
                {
                    isWhiteWin = true;
                }

                if (isWhiteWin)
                {
                    Console.WriteLine($"Game over! White capture on {TransformCoordinates(blackRow, blackCol)}.");
                    return;
                }

                board[whiteRow - 1, whiteCol] = 'w';
                board[whiteRow, whiteCol] = '-';
                whiteRow--;

                if (blackRow == 7)
                {
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {TransformCoordinates(blackRow, blackCol)}.");

                    return;
                }

                if (blackRow + 1 < 8 && blackCol + 1 < 8
                    && board[blackRow + 1, blackCol + 1] == 'w' || board[blackRow + 1, blackCol - 1] == 'w')
                {
                    Console.WriteLine($"Game over! Black capture on {TransformCoordinates(whiteRow, whiteCol)}.");
                    return;
                }
                else if (blackRow + 1 < 8 && blackCol - 1 >= 0
                    && board[blackRow + 1, blackCol - 1] == 'w')
                {
                    Console.WriteLine($"Game over! Black capture on {TransformCoordinates(whiteRow, whiteCol)}.");
                    return;
                }

                board[blackRow, blackCol] = '-';
                blackRow++;
                board[blackRow, blackCol] = 'b';
            }
        }
    }
}
