using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = null;

            var queue = new Queue<string>();

            while ((input = Console.ReadLine()) != "End")
            {
                if (input != "Paid")
                {
                    queue.Enqueue(input);
                }
                else
                {
                    while (queue.Any())
                    {
                        Console.WriteLine(queue.Dequeue());
                    }
                }
            }

            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
