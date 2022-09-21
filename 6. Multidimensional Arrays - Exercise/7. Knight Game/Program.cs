using System;

namespace _7._Knight_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] board = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string inputRow = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    board[row, col] = inputRow[col];
                }
            }

            int knightsRemoved = 0;

            while (true)
            {
                int mostAttacks = 0;
                int rowMostAttack = 0;
                int colMostAttack = 0;

                for (int row = 0; row < size; row++)
                {

                    for (int col = 0; col < size; col++)
                    {
                        if (board[row, col] == '0') continue;

                        int attacks = 0;

                        attacks = CountCurrentKnightAttacks(row, size, col, board, attacks);

                        if (attacks > mostAttacks)
                        {
                            mostAttacks = attacks;
                            rowMostAttack = row;
                            colMostAttack = col;
                        }
                    }
                }

                if (mostAttacks == 0) break;

                board[rowMostAttack, colMostAttack] = '0';
                knightsRemoved++;
            }

            Console.WriteLine(knightsRemoved);
        }

        private static int CountCurrentKnightAttacks(int row, int size, int col, char[,] board, int attacks)
        {
            if (row - 1 >= 0 && row - 1 < size && col - 2 >= 0 && col - 2 < size && board[row - 1, col - 2] == 'K')
            {
                attacks++;
            }

            if (row + 1 >= 0 && row + 1 < size && col - 2 >= 0 && col - 2 < size && board[row + 1, col - 2] == 'K')
            {
                attacks++;
            }

            if (row - 1 >= 0 && row - 1 < size && col + 2 >= 0 && col + 2 < size && board[row - 1, col + 2] == 'K')
            {
                attacks++;
            }

            if (row + 1 >= 0 && row + 1 < size && col + 2 >= 0 && col + 2 < size && board[row + 1, col + 2] == 'K')
            {
                attacks++;
            }

            if (row - 2 >= 0 && row - 2 < size && col - 1 >= 0 && col - 1 < size && board[row - 2, col - 1] == 'K')
            {
                attacks++;
            }

            if (row - 2 >= 0 && row - 2 < size && col + 1 >= 0 && col + 1 < size && board[row - 2, col + 1] == 'K')
            {
                attacks++;
            }

            if (row + 2 >= 0 && row + 2 < size && col - 1 >= 0 && col - 1 < size && board[row + 2, col - 1] == 'K')
            {
                attacks++;
            }

            if (row + 2 >= 0 && row + 2 < size && col + 1 >= 0 && col + 1 < size && board[row + 2, col + 1] == 'K')
            {
                attacks++;
            }

            return attacks;
        }
    }
}
