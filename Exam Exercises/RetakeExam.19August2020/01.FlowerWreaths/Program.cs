using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FlowerWreaths
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lilies = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            var roses = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            int storedFlowers = 0;
            int wreaths = 0;

            while (lilies.Any() && roses.Any())
            {
                int lily = lilies.Pop();
                int sum = lily + roses.Peek();

                if (sum == 15)
                {
                    wreaths++;
                    roses.Dequeue();
                }
                else if (sum > 15)
                {
                    lilies.Push(lily - 2);
                }
                else
                {
                    storedFlowers += sum;
                    roses.Dequeue();
                }
            }

            wreaths += storedFlowers / 15;

            Console.WriteLine(wreaths >= 5
                ? $"You made it, you are going to the competition with {wreaths} wreaths!"
                : $"You didn't make it, you need {5 - wreaths} wreaths more!");
        }
    }
}
