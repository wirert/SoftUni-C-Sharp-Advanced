using System;

namespace _02.Armory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] armory = new char[size, size];
            int curRow = 0;
            int curCol = 0;

            for (int row = 0; row < size; row++)
            {
                string cols = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    armory[row, col] = cols[col];

                    if (cols[col] == 'A')
                    {
                        curRow = row;
                        curCol = col;
                    }
                }
            }

            int moneySpend = 0;

            while (true)
            {
                string direction = Console.ReadLine();
                int oldRow = curRow;
                int oldCol = curCol;

                armory[oldRow, oldCol] = '-';

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
                    Console.WriteLine("I do not need more swords!");

                    break;
                }

                if (char.IsDigit(armory[curRow, curCol]))
                {
                    moneySpend += int.Parse(armory[curRow, curCol].ToString());
                }
                else if (armory[curRow, curCol] == 'M')
                {
                    bool foundM = false;
                    armory[curRow, curCol] = '-';

                    for (int row = 0; row < size; row++)
                    {
                        for (int col = 0; col < size; col++)
                        {
                            if (armory[row, col] == 'M')
                            {
                                curRow = row;
                                curCol = col;
                                foundM = true;

                                break;
                            }
                        }

                        if (foundM) break;
                    }
                }
                
                armory[curRow, curCol] = 'A';

                if (moneySpend >= 65)
                {
                    Console.WriteLine("Very nice swords, I will come back for more!");
                    break;
                }
            }

            Console.WriteLine($"The king paid {moneySpend} gold coins.");

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write(armory[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
