using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Garden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[,] garden = new int[size[0], size[1]];
            string command = null;
            List<Tuple<int, int>> flowers = new List<Tuple<int, int>>();

            while ((command = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] coordinates = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int row = coordinates[0];
                int col = coordinates[1];

                if (row >= 0 && row < size[0] && col >= 0 && col < size[1])
                {
                    flowers.Add(new Tuple<int, int>(row, col));
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }
            }

            foreach (var flower in flowers)
            {
                int row = flower.Item1;
                int col = flower.Item2;

                for (int i = 0; i < size[1]; i++)
                {
                    garden[row, i]++;
                }
                for (int i = 0; i < size[0]; i++)
                {
                    garden[i, col]++;
                }

                garden[row, col]--;
            }

            for (int row = 0; row < size[0]; row++)
            {
                for (int col = 0; col < size[1]; col++)
                {
                    Console.Write($"{garden[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
