using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodQnt = int.Parse(Console.ReadLine());

            var ordersQueue = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());

            Console.WriteLine(ordersQueue.Max());
            while (ordersQueue.Count != 0)
            {
                if (ordersQueue.Peek() > foodQnt)
                {
                    Console.WriteLine($"Orders left: {String.Join(" ", ordersQueue)}");
                    return;
                }

                foodQnt -= ordersQueue.Dequeue();
            }

            Console.WriteLine("Orders complete");
        }
    }
}
