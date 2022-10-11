using System;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        public void AddLast(T value)
        {
            if (this.Count == 0)
            {
                this.head = new Node<T>(value);
                this.tail = this.head;
            }
            else
            {
                Node<T> newTail = new Node<T>(value);
                newTail.PreviousNode = this.tail;
                this.tail.NextNode = newTail;
                this.tail = newTail;
            }

            this.Count++;
        }

        public void AddFirst(T value)
        {
            if (Count == 0)
            {
                this.head = new Node<T>(value);
                this.tail = this.head;
            }
            else
            {
                Node<T> newHead = new Node<T>(value);
                newHead.NextNode = this.head;
                this.head.PreviousNode = newHead;
                this.head = newHead;
            }

            this.Count++;
        }

        public T RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("This List Is Empty");
            }

            T currValue = this.head.Value;
            this.head = this.head.NextNode;

            if (this.head == null)
            {
                this.tail = null;
            }
            else
            {
                this.head.PreviousNode = null;
            }

            Count--;
            return currValue;
        }

        public T RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("This List Is Empty");
            }

            T currValue = this.tail.Value;
            this.tail = this.tail.PreviousNode;

            if (this.tail == null)
            {
                this.head = null;
            }
            else
            {
                this.tail.NextNode = null;
            }

            Count--;
            return currValue;
        }

        public void ForEach(Action<T> action)
        {
            var currNode = this.head;

            while (currNode != null)
            {
                action(currNode.Value);
                currNode = currNode.NextNode;
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Count];

            var currNode = this.head;

            for (int i = 0; i < this.Count; i++)
            {
                array[i] = currNode.Value;
                currNode = currNode.NextNode;
            }

            return array;
        }

        public void PrintList()
        {
            Node<T> currNode = this.head;

            StringBuilder sb = new StringBuilder();

            while (currNode != null)
            {
                sb.Append($"{currNode.Value} ");
                currNode = currNode.NextNode;
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
