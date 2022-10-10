using System;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList
    {
        private Node head;
        private Node tail;

        public int Count { get; private set; }

        public void AddLast(int value)
        {
            if (this.Count == 0)
            {
                this.head = new Node(value);
                this.tail = this.head;
            }
            else
            {
                Node newTail = new Node(value);
                newTail.PreviousNode = this.tail;
                this.tail.NextNode = newTail;
                this.tail = newTail;
            }

            this.Count++;
        }

        public void AddFirst(int value)
        {
            if (Count == 0)
            {
                this.head = new Node(value);
                this.tail = this.head;
            }
            else
            {
                Node newHead = new Node(value);
                newHead.NextNode = this.head;
                this.head.PreviousNode = newHead;
                this.head = newHead;
            }

            this.Count++;
        }

        public int RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("This List Is Empty");
            }

            int currValue = this.head.Value;
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

        public int RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("This List Is Empty");
            }

            int currValue = this.tail.Value;
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

        public void ForEach(Action<int> action)
        {
            var currNode = this.head;

            while (currNode != null)
            {
                action(currNode.Value);
                currNode = currNode.NextNode;
            }
        }

        public int[] ToArray()
        {
            int[] array = new int[this.Count];

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
            Node currNode = this.head;

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
