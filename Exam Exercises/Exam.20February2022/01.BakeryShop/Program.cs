using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BakeryShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<double> waters = new Queue<double>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse).ToArray());

            Stack<double> flours = new Stack<double>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse).ToArray());

            Dictionary<double, string> ratioProduct = new Dictionary<double, string>()
            {
                { 50, "Croissant" }, { 40, "Muffin" }, { 30, "Baguette" }, { 20, "Bagel" }
            };

            Dictionary<string, int> products = new Dictionary<string, int>()
            {
                { "Croissant", 0 }, { "Muffin", 0 }, { "Baguette", 0 }, { "Bagel", 0 }
            };


            while (waters.Count != 0 && flours.Count != 0)
            {
                double water = waters.Dequeue();
                double flour = flours.Pop();

                double ratio = water * 100 / (water + flour);

                if (ratioProduct.ContainsKey(ratio))
                {
                    products[ratioProduct[ratio]]++;
                }
                else
                {
                    products["Croissant"]++;
                    flours.Push(flour - water);
                }
            }

            foreach (var product in products.Where(p => p.Value != 0)
                .OrderByDescending(p => p.Value)
                .ThenBy(p => p.Key))
            {
                Console.WriteLine($"{product.Key}: {product.Value}");
            }

            string leftWater = waters.Count == 0 ? "None" : $"{string.Join(", ", waters)}";
            string leftFlour = flours.Count == 0 ? "None" : $"{string.Join(", ", flours)}";

            Console.WriteLine($"Water left: {leftWater}");
            Console.WriteLine($"Flour left: {leftFlour}");
        }
    }
}
