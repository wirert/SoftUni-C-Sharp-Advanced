using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Lootbox
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var box1 = new Queue<int>(Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse).ToArray());
            var box2 = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            int sumLootValues = 0;

            while (box1.Count > 0 && box2.Count > 0)
            {
                int lootBox1 = box1.Peek();
                int lootBox2 = box2.Pop();
                int lootSum = lootBox1 + lootBox2;

                if (lootSum % 2 == 0)
                {
                    sumLootValues += lootSum;
                    box1.Dequeue();
                }
                else
                {
                    box1.Enqueue(lootBox2);
                }
            }

            string box = box1.Count == 0 ? "First" : "Second";

            Console.WriteLine($"{box} lootbox is empty");

            Console.WriteLine("Your loot was "
                + (sumLootValues >= 100
                ? $"epic! Value: {sumLootValues}"
                : $"poor... Value: {sumLootValues}"));
        }
    }
}
