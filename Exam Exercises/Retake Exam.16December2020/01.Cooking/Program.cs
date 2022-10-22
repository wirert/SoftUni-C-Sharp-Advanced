using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Cooking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var liquids = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            var ingredients = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            var foods = new Dictionary<int, Food>
            {
                {25, new Food("Bread", 25) },
                {50, new Food("Cake", 50) },
                {75, new Food("Pastry", 75) },
                {100, new Food("Fruit Pie", 100) }
            };

            while (liquids.Any() && ingredients.Any())
            {
                int ingredient = ingredients.Pop();
                int value = liquids.Dequeue() + ingredient;

                if (foods.ContainsKey(value))
                {
                    foods[value].Cooked++;
                }
                else
                {
                    ingredients.Push(ingredient + 3);
                }
            }

            Console.WriteLine(foods.Values.All(f => f.Cooked > 0)
                ? "Wohoo! You succeeded in cooking all the food!"
                : "Ugh, what a pity! You didn't have enough materials to cook everything.");

            string leftLiquid = liquids.Any() ? string.Join(", ", liquids) : "none";
            string leftIngredients = ingredients.Any() ? string.Join(", ", ingredients) : "none";

            Console.WriteLine("Liquids left: " + leftLiquid);
            Console.WriteLine("Ingredients left: " + leftIngredients);

            foreach (var food in foods.Values.OrderBy(f => f.Name))
            {
                Console.WriteLine(food);
            }
        }
    }

    class Food
    {
        public Food(string name, int value)
        {
            Name = name;
            ValueNeeded = value;
            Cooked = 0;
        }

        public string Name { get; private set; }
        public int ValueNeeded { get; private set; }
        public int Cooked { get; set; }

        public override string ToString()
        {
            return $"{Name}: {Cooked}";
        }
    }
}

