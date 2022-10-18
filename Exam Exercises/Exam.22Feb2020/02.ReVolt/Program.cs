using System;

namespace _02.ReVolt
{
    public class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int moves = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            int curRow = 0;
            int curCol = 0;
            bool isWin = false;

            for (int row = 0; row < size; row++)
            {
                string cols = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = cols[col];

                    if (cols[col] == 'f')
                    {
                        curRow = row;
                        curCol = col;
                    }
                }
            }

            for (int move = 0; move < moves; move++)
            {
                string direction = Console.ReadLine();
                int oldRow = curRow;
                int oldCol = curCol;

                matrix[oldRow, oldCol] = '-';

                MoveIntoDirection(size, ref curRow, ref curCol, direction);

                switch (matrix[curRow, curCol])
                {
                    case 'B':
                        MoveIntoDirection(size, ref curRow, ref curCol, direction);

                        if (matrix[curRow,curCol] == 'F')
                        {
                            isWin = true;
                        }
                        break;
                    case 'T':
                        curRow = oldRow;
                        curCol = oldCol;
                        break;
                    case 'F':
                        isWin = true;
                        break;
                }

                matrix[curRow, curCol] = 'f';

                if (isWin) break;
            }

            Console.WriteLine("Player " + (isWin ? "won!" : "lost!"));

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void MoveIntoDirection(int size, ref int curRow, ref int curCol, string direction)
        {
            switch (direction)
            {
                case "up":
                    curRow--;
                    if (curRow < 0)
                        curRow = size - 1;
                    break;
                case "down":
                    curRow++;
                    if (curRow == size)
                        curRow = 0;
                    break;
                case "left":
                    curCol--;
                    if (curCol < 0)
                        curCol = size - 1;
                    break;
                case "right":
                    curCol++;
                    if (curCol == size)
                        curCol = 0;
                    break;
            }
        }
    }
}
