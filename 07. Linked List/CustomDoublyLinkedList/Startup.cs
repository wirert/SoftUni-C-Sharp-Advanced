using System;

namespace CustomDoublyLinkedList
{
    public class Startup
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();

            for (int i = 1; i <= 10; i++)
            {
                list.AddLast(i);
            }

            list.PrintList();

            list.RemoveLast();
            list.RemoveFirst();
            list.AddLast(43);
            list.AddFirst(-57);

            list.ForEach(i => Console.Write($"{i} "));
            Console.WriteLine();

            list.PrintList();
        }
    }
}
