using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BaristaContest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> quantityDrinks = new Dictionary<int, string>
            {
                {50, "Cortado" },
                {75, "Espresso" },
                {100, "Capuccino" },
                {150, "Americano" },
                {200, "Latte" },
            };

            Dictionary<string, int> drinksMade = new Dictionary<string, int>
            {
                {"Cortado", 0 },
                {"Espresso", 0 },
                {"Capuccino", 0 },
                {"Americano", 0 },
                {"Latte", 0 },
            };

            Queue<int> coffees = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            Stack<int> milks = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            while (coffees.Any() && milks.Any())
            {
                int milk = milks.Pop();
                int quantity = coffees.Dequeue() + milk;

                if (!quantityDrinks.ContainsKey(quantity))
                {
                    milks.Push(milk - 5);
                    continue;
                }

                drinksMade[quantityDrinks[quantity]]++;
            }

            if (coffees.Count == 0 && milks.Count == 0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }

            string leftCoffee = coffees.Count == 0 ? "none" : $"{string.Join(", ", coffees)}";
            string leftMilk = milks.Count == 0 ? "none" : $"{string.Join(", ", milks)}";

            Console.WriteLine($"Coffee left: {leftCoffee}");
            Console.WriteLine($"Milk left: {leftMilk}");

            var orderedDrinks = drinksMade.Where(d => d.Value != 0).OrderBy(d => d.Value).ThenByDescending(d => d.Key);

            foreach (var drink in orderedDrinks)
            {
                Console.WriteLine($"{drink.Key}: {drink.Value}");
            }
        }
    }
}
