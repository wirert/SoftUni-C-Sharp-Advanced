using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>();

            foreach (var num in input)
            {
                stack.Push(num);
            }

            var command = Console.ReadLine().ToLower().Split();

            while (command[0] != "end")
            {
                switch (command[0])
                {
                    case "add":
                        stack.Push(int.Parse(command[1]));
                        stack.Push(int.Parse(command[2]));
                        break;

                    case "remove":
                        int numToRemove = int.Parse(command[1]);

                        if (numToRemove > stack.Count)
                        {
                            command = Console.ReadLine().ToLower().Split();
                            continue;
                        }

                        for (int i = 0; i < numToRemove; i++)
                        {
                            stack.Pop();
                        }
                        break;
                }

                command = Console.ReadLine().ToLower().Split();
            }

            int sum = 0;
            int count = stack.Count;

            for (int i = 0; i < count; i++)
            {
                sum += stack.Pop();
            }
            
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
