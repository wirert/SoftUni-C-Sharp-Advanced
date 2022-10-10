using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var queue = new Queue<int>();

            foreach (var curNum in nums)
            {
                if (curNum % 2 == 0)
                {
                    queue.Enqueue(curNum);
                }
            }

            Console.WriteLine(String.Join(", ", queue));
        }
    }
}
