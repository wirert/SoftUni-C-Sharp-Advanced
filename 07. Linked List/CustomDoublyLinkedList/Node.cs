﻿namespace CustomDoublyLinkedList
{
    public class Node<T>
    {
        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }
        public Node<T> PreviousNode { get; set; }
        public Node<T> NextNode { get; set; }

    }
}
