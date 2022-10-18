using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ingredients = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());
            var freshness = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            Dictionary<int, Dish> dishes = new Dictionary<int, Dish>
            {
                {150, new Dish("Dipping sauce", 150) },
                {250, new Dish("Green salad", 250) },
                {300, new Dish("Chocolate cake", 300) },
                {400, new Dish("Lobster", 400) }
            };

            while (freshness.Count > 0 && ingredients.Count > 0)
            {
                int ingredient = ingredients.Dequeue();

                if (ingredient == 0) continue;

                int totalFreshness = ingredient * freshness.Pop();

                if (dishes.ContainsKey(totalFreshness))
                {
                    dishes[totalFreshness].Count++;
                }
                else
                {
                    ingredients.Enqueue(ingredient + 5);
                }
            }

            var dishesMade = dishes.Values.Where(d => d.Count > 0).OrderBy(d => d.Name);

            if (dishesMade.Count() == 4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }

            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            foreach (var dish in dishesMade)
            {
                Console.WriteLine(dish);
            }
        }
    }

    class Dish
    {
        public Dish(string name, int freshness)
        {
            Name = name;
            Freshness = freshness;
            Count = 0;
        }

        public string Name { get; private set; }
        public int Freshness { get; private set; }
        public int Count { get; set; }

        public override string ToString()
        {
            return $" # {Name} --> {Count}";
        }
    }
}
