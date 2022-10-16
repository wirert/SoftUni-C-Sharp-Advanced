using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var steels = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());
            var carbons = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            List<Sword> swords = new List<Sword>()
            {
                new Sword("Gladius", 70),
                new Sword("Shamshir", 80),
                new Sword("Katana", 90),
                new Sword("Sabre", 110),
                new Sword("Broadsword", 150)
            };

            while (steels.Count > 0 && carbons.Count > 0)
            {
                int steel = steels.Dequeue();
                int carbon = carbons.Pop();
                int alloy = steel + carbon;

                var sword = swords.SingleOrDefault(s => s.ResourcesNeeded == alloy);

                if (sword != null)
                {
                    sword.Amount++;
                }
                else
                {
                    carbon += 5;
                    carbons.Push(carbon);
                }
            }

            int forgedSwords = swords.Sum(s => s.Amount);

            Console.WriteLine(forgedSwords == 0
                ? "You did not have enough resources to forge a sword."
                : $"You have forged {forgedSwords} swords.");
            
            Console.WriteLine(steels.Count == 0
                ? "Steel left: none"
                : $"Steel left: {string.Join(", ", steels)}");

            Console.WriteLine(carbons.Count == 0
               ? "Carbon left: none"
               : $"Carbon left: {string.Join(", ", carbons)}");

            foreach (var sword in swords.Where(s => s.Amount != 0).OrderBy(s => s.Name))
            {
                Console.WriteLine(sword);
            }
        }
    }

    class Sword
    {
        public Sword(string name, int resourcesNeeded)
        {
            Name = name;
            ResourcesNeeded = resourcesNeeded;
            Amount = 0;
        }

        public string Name { get; private set; }
        public int ResourcesNeeded { get; private set; }
        public int Amount { get; set; }

        public override string ToString() => $"{Name}: {Amount}";
    }
}
