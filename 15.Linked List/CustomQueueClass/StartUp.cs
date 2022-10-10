using System;

namespace CustomQueueClass
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            CustomQueue queue = new CustomQueue();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            queue.Dequeue();

            Console.WriteLine(string.Join(" ", queue.ToArray()));

            Console.WriteLine(queue.Peek());

            Console.WriteLine(queue.Contains(7));
            Console.WriteLine(queue.Contains(3));
        }
    }
}
