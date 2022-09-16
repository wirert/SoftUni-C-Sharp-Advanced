using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();

            for (int i = 1; i <= n; i++)
            {
                int[] cmd = Console.ReadLine().Split().Select(int.Parse).ToArray();

                switch (cmd[0])
                {
                    case 1:
                        stack.Push(cmd[1]);
                        break;
                    case 2:
                        if (stack.Count > 0)
                        {
                            stack.Pop();
                        }
                        break;
                    case 3:
                        if (stack.Count == 0)
                        {
                            continue;
                        }
                        Console.WriteLine(stack.Max());
                        break;
                    case 4:
                        if (stack.Count == 0)
                        {
                            continue;
                        }
                        Console.WriteLine(stack.Min());
                        break;
                }
            }

            Console.WriteLine(String.Join(", ", stack));
        }
    }
}
