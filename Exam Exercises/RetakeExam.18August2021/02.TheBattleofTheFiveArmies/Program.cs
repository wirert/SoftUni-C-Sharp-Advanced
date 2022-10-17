using System;

namespace _02.TheBattleOfTheFiveArmies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int armyArmor = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());
            char[][] field = new char[size][];

            int armyRow = 0;
            int armyCol = 0;

            for (int row = 0; row < size; row++)
            {
                field[row] = Console.ReadLine().ToCharArray();

                for (int col = 0; col < field[row].Length; col++)
                {
                    if (field[row][col] == 'A')
                    {
                        armyRow = row;
                        armyCol = col;
                    }
                }
            }

            while (true)
            {
                if (armyArmor <= 0)
                {
                    field[armyRow][armyCol] = 'X';
                    Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");

                    break;
                }

                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string direction = tokens[0];

                field[int.Parse(tokens[1])][int.Parse(tokens[2])] = 'O';

                int oldRow = armyRow;
                int oldCol = armyCol;

                field[oldRow][oldCol] = '-';

                switch (direction.ToLower())
                {
                    case "up":
                        armyRow--;
                        break;
                    case "down":
                        armyRow++;
                        break;
                    case "left":
                        armyCol--;
                        break;
                    case "right":
                        armyCol++;
                        break;
                }

                armyArmor--;

                if (armyRow < 0 || armyRow >= size || armyCol < 0 || armyCol >= size)
                {
                    armyRow = oldRow;
                    armyCol = oldCol;
                }
                else
                {
                    if (field[armyRow][armyCol] == 'O')
                    {
                        armyArmor -= 2;
                    }
                    else if (field[armyRow][armyCol] == 'M')
                    {
                        field[armyRow][armyCol] = '-';

                        Console.WriteLine($"The army managed to free the Middle World! Armor left: {armyArmor}");

                        break;
                    }
                }

                field[armyRow][armyCol] = 'A';
            }

            for (int row = 0; row < size; row++)
            {
                Console.WriteLine(string.Join("", field[row]));
            }
        }
    }
}
