using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Reverse();

            var stack = new Stack<string>(input);
            int sum = int.Parse(stack.Pop());
            while (stack.Count != 0)
            {
                var action = stack.Pop();

                if (action == "+")
                {
                    sum += int.Parse(stack.Pop());
                }
                else
                {
                    sum -= int.Parse(stack.Pop());
                }
            }

            Console.WriteLine(sum);
        }
    }
}
