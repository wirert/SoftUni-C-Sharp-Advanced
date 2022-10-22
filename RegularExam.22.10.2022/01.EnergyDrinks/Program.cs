using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.EnergyDrinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var coffeins = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            var energyDrinks = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int drankCoffeine = 0;

            while (coffeins.Any() && energyDrinks.Any())
            {
                int drink = energyDrinks.Dequeue();
                int drinkCoffeine = drink * coffeins.Pop();

                if (drankCoffeine + drinkCoffeine <= 300)
                {
                    drankCoffeine += drinkCoffeine;
                }
                else
                {
                    energyDrinks.Enqueue(drink);
                    if (drankCoffeine >= 30)
                    {
                        drankCoffeine -= 30;
                    }
                }
            }

            Console.WriteLine(energyDrinks.Any()
                ? $"Drinks left: {string.Join(", ", energyDrinks)}"
                : "At least Stamat wasn't exceeding the maximum caffeine.");

            Console.WriteLine($"Stamat is going to sleep with {drankCoffeine} mg caffeine.");
        }
    }
}
