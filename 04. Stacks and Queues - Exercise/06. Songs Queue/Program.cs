using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<string>(Console.ReadLine().Split(", "));

            while (queue.Any())
            {
                string[] cmd = Console.ReadLine().Split(" ");

                string command = cmd[0];
                string song = String.Join(" ", cmd.Skip(1));

                switch (command)
                {
                    case "Play":
                        queue.Dequeue();
                        break;
                    case "Add":
                        if (queue.Contains(song))
                        {
                            Console.WriteLine($"{song} is already contained!");
                        }
                        else
                        {
                            queue.Enqueue(song);
                        }
                        break;
                    case "Show":
                        Console.WriteLine(String.Join(", ", queue));
                        break;
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
