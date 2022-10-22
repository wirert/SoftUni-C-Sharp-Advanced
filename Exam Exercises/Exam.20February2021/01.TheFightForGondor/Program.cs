using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TheFightForGondor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int orcWaves = int.Parse(Console.ReadLine());

            var plates = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            int plate = plates.Peek();

            for (int i = 1; i <= orcWaves; i++)
            {
                var wave = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

                if (i % 3 == 0)
                {
                    plates.Enqueue(int.Parse(Console.ReadLine()));
                }

                int orc = wave.Pop();

                while (true)
                {
                    if (plate > orc)
                    {
                        plate -= orc;

                        if (wave.Count == 0) break;

                        orc = wave.Pop();
                    }
                    else if (plate < orc)
                    {
                        orc -= plate;

                        plates.Dequeue();

                        if (plates.Any())
                        {
                            plate = plates.Peek();
                        }
                        else
                        {
                            wave.Push(orc);
                            Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                            Console.WriteLine($"Orcs left: {string.Join(", ", wave)}");

                            return;
                        }
                    }
                    else
                    {
                        plates.Dequeue();

                        if (plates.Count == 0)
                        {
                            Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                            Console.WriteLine($"Orcs left: {string.Join(", ", wave)}");

                            return;
                        }

                        plate = plates.Peek();

                        if (wave.Count == 0) break;

                        orc = wave.Pop();
                    }
                }
            }

            List<int> leftPlates = new List<int>(plates);
            leftPlates[0] = plate;

            Console.WriteLine("The people successfully repulsed the orc's attack.");
            Console.WriteLine($"Plates left: {string.Join(", ", leftPlates)}");
        }
    }
}
