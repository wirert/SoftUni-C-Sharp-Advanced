using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jaggedArr = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                jaggedArr[row] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            string[] command = Console.ReadLine().Split();

            while (command[0] != "END")
            {
                int row = int.Parse(command[1]);
                int col = int.Parse(command[2]);
                int value = int.Parse(command[3]);

                if (row < 0 || row >= rows || col < 0 || col >= jaggedArr[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else
                {
                    if (command[0] == "Add")
                    {
                        jaggedArr[row][col] += value;
                    }
                    else
                    {
                        jaggedArr[row][col] -= value;
                    }
                }

                command = Console.ReadLine().Split();
            }

            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine(string.Join(" ", jaggedArr[row]));
            }

        }
    }
}
