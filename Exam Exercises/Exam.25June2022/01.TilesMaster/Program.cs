using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TilesMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> whites = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            Queue<int> grays = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            List<Location> locations = new List<Location>()
            {
                new Location( "Sink", 40),
                new Location( "Oven", 50),
                new Location( "Countertop", 60),
                new Location( "Wall", 70),
            };

            var floor = new Location("Floor", -1);
            locations.Add(floor);

            while (whites.Count != 0 && grays.Count != 0)
            {
                int white = whites.Pop();
                int gray = grays.Dequeue();

                if (white == gray)
                {
                    int tile = white + gray;

                    var location = locations.FirstOrDefault(l => l.TileArea == tile);

                    if (location == null)
                    {
                        floor.CountTiles++;
                    }
                    else
                    {
                        location.CountTiles++;
                    }
                }
                else
                {
                    whites.Push(white / 2);
                    grays.Enqueue(gray);
                }
            }

            string whiteLeft = whites.Count == 0 ? "none" : $"{string.Join(", ", whites)}";
            string grayLeft = grays.Count == 0 ? "none" : $"{string.Join(", ", grays)}";

            Console.WriteLine($"White tiles left: {whiteLeft}");
            Console.WriteLine($"Grey tiles left: {grayLeft}");

            var orderedLocations = locations.Where(l => l.CountTiles != 0)
                .OrderByDescending(l => l.CountTiles)
                .ThenBy(l => l.Name);

            foreach (var location in orderedLocations)
            {
                Console.WriteLine($"{location.Name}: {location.CountTiles}");
            }
        }
    }

    class Location
    {
        public Location(string name, int tileArea)
        {
            Name = name;
            TileArea = tileArea;
            CountTiles = 0;
        }

        public string Name { get; set; }
        public int TileArea { get; set; }
        public int CountTiles { get; set; }
    }
}
