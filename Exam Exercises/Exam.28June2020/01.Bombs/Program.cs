using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var effects = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            var casings = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            var bombs = new Dictionary<int, Bomb>
            {
                {40, new Bomb("Datura Bombs") },
                {60, new Bomb("Cherry Bombs") },
                {120, new Bomb("Smoke Decoy Bombs") },
            };

            while (effects.Any() && casings.Any())
            {
                int casing = casings.Pop();
                int sum = casing + effects.Peek();

                if (bombs.ContainsKey(sum))
                {
                    bombs[sum].Count++;
                    effects.Dequeue();
                }
                else
                {
                    casings.Push(casing - 5);
                }

                if (bombs.Values.All(b => b.Count >= 3))
                {
                    break;
                }
            }

            Console.WriteLine(bombs.Values.All(b => b.Count >= 3)
                ? "Bene! You have successfully filled the bomb pouch!"
                : "You don't have enough materials to fill the bomb pouch.");

            string leftEffects = effects.Any() ? $"{string.Join(", ", effects)}" : "empty";
            string leftCasings = casings.Any() ? $"{string.Join(", ", casings)}" : "empty";

            Console.WriteLine("Bomb Effects: " + leftEffects);
            Console.WriteLine("Bomb Casings: " + leftCasings);

            foreach (var bomb in bombs.Values.OrderBy(b => b.Name))
            {
                Console.WriteLine(bomb);
            }
        }
    }

    class Bomb
    {
        public Bomb(string name)
        {
            Name = name;
            Count = 0;
        }

        public string Name { get; set; }
        public int Count { get; set; }

        public override string ToString() => $"{Name}: {Count}";
    }
}
