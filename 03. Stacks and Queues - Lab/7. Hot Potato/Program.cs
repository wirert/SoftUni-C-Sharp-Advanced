using System;
using System.Collections.Generic;

namespace _7._Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<string>(Console.ReadLine().Split());
            int tossCount = int.Parse(Console.ReadLine());

            while (queue.Count != 1)
            {
                for (int i = 1; i <= tossCount; i++)
                {
                    if (i == tossCount)
                    {
                        Console.WriteLine($"Removed {queue.Dequeue()}");
                    }
                    else
                    {
                        string kid = queue.Dequeue();
                        queue.Enqueue(kid);
                    }
                }
            }

            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
