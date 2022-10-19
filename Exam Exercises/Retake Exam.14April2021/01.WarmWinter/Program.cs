using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.WarmWinter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var hats = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            var scarfs = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            var sets = new Queue<int>();

            while (hats.Count > 0 && scarfs.Count > 0)
            {
                int hat = hats.Pop();
                int scarf = scarfs.Peek();

                if (hat > scarf)
                {
                    sets.Enqueue(hat + scarfs.Dequeue());
                }
                else if (hat == scarf)
                {
                    scarfs.Dequeue();
                    hats.Push(hat + 1);
                }
            }

            Console.WriteLine($"The most expensive set is: {sets.Max()}");
            Console.WriteLine(string.Join(" ", sets));
        }
    }
}
