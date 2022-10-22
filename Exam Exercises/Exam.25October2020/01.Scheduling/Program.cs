using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Scheduling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tasks = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            var threads = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            int taskForKill = int.Parse(Console.ReadLine());

            while (true)
            {
                int task = tasks.Pop();
                int thread = threads.Peek();

                if (task == taskForKill)
                {
                    Console.WriteLine($"Thread with value {thread} killed task {task}");
                    Console.WriteLine(string.Join(" ", threads));
                    return;
                }

                if (thread < task)
                {
                    tasks.Push(task);
                }

                threads.Dequeue();
            }
        }
    }
}
