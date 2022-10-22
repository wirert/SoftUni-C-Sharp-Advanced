using System;

namespace _02.Bee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] field = new char[size, size];
            int beeRow = 0;
            int beeCol = 0;

            for (int row = 0; row < size; row++)
            {
                string cols = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    field[row, col] = cols[col];

                    if (cols[col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }

            int polinatedFlowers = 0;
            string direction = null;

            while ((direction = Console.ReadLine()) != "End")
            {
                int oldRow = beeRow;
                int oldCol = beeCol;

                field[oldRow, oldCol] = '.';

                if (!IsInFieldAndMove(field, direction, ref beeRow, ref beeCol, ref polinatedFlowers))
                {
                    break;
                }
            }

            Console.WriteLine(polinatedFlowers >= 5
                ? $"Great job, the bee managed to pollinate {polinatedFlowers} flowers!"
                : $"The bee couldn't pollinate the flowers, she needed {5 - polinatedFlowers} flowers more");

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(field[row, col]);
                }
                Console.WriteLine();
            }
        }

        public static bool IsInFieldAndMove(char[,] field, string direction, ref int beeRow, ref int beeCol, ref int polinatedFlowers)
        {
            switch (direction)
            {
                case "up":
                    beeRow--;
                    break;
                case "down":
                    beeRow++;
                    break;
                case "left":
                    beeCol--;
                    break;
                case "right":
                    beeCol++;
                    break;
            }

            if (beeRow < 0 || beeRow >= field.GetLength(0) || beeCol < 0 || beeCol >= field.GetLength(0))
            {
                Console.WriteLine("The bee got lost!");
                return false;
            }

            if (field[beeRow, beeCol] == 'f')
            {
                polinatedFlowers++;
            }
            else if (field[beeRow, beeCol] == 'O')
            {
                field[beeRow, beeCol] = '.';

                if (!IsInFieldAndMove(field, direction, ref beeRow, ref beeCol, ref polinatedFlowers))
                    return false;
            }

            field[beeRow, beeCol] = 'B';

            return true;
        }
    }
}
