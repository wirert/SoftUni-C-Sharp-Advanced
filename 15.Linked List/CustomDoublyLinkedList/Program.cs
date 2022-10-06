using System;

namespace CustomDoublyLinkedList
{
    public class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList list = new DoublyLinkedList();

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

            list.PrintList();
        }
    }
}
