using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_Bottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cups = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            var bottles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int waterWasted = 0;

            int cup = cups.Dequeue();

            while (bottles.Any())
            {
                int bottle = bottles.Pop();

                if (bottle >= cup)
                {
                    waterWasted += bottle - cup;

                    if (!cups.Any() || !bottles.Any()) break;

                    cup = cups.Dequeue();
                }
                else
                {
                    cup -= bottle;
                }
            }

            Console.WriteLine(bottles.Any()
                ? $"Bottles: {String.Join(" ", bottles)}"
                : $"Cups: {String.Join(" ", cups)}");

            Console.WriteLine($"Wasted litters of water: {waterWasted}");
        }
    }
}
