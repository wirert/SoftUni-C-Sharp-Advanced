using System;

namespace CustomQueueClass
{
    public class CustomQueue
    {
        private Node head;
        private Node tail;

        public int Count { get; private set; }

        public void Enqueue(int item)
        {
            var newTail = new Node(item);

            if (this.Count == 0)
            {
                this.head = newTail;
                this.tail = this.head;
            }
            else
            {
                this.tail.Next = newTail;
                newTail.Previous = this.tail;
                this.tail = newTail;
            }

            this.Count++;
        }

        public int Dequeue()
        {
            if (this.Count == 0)
            {
                throw new ArgumentOutOfRangeException("The Queue is Empty");
            }

            int value = this.head.Value;
            this.head = this.head.Next;

            if (this.head == null)
            {
                this.tail = null;
            }
            else
            {
                this.head.Previous = null;
            }

            this.Count--;
            return value;
        }

        public int Peek()
        {
            if (this.Count == 0)
            {
                throw new ArgumentOutOfRangeException("The Queue is Empty");
            }

            return this.head.Value;
        }

        public void Clear()
        {
            this.head = null;
            this.tail = null;
            this.Count = 0;
        }

        public void ForEach(Action<int> action)
        {
            int count = this.Count;
            var currNode = this.head;

            while (count != 0)
            {
                action(currNode.Value);
                currNode = currNode.Next;
                count--;
            }
        }

        public bool Contains(int value)
        {
            int count = this.Count;
            var currNode = this.head;

            while (count != 0)
            {
                if (currNode.Value == value)
                {
                    return true;
                }
                currNode = currNode.Next;
                count--;
            }

            return false;
        }

        public int[] ToArray()
        {
            int[] array = new int[this.Count];
            var currNode = this.head;

            for (int i = 0; i < this.Count; i++)
            {
                array[i] = currNode.Value;
                currNode = currNode.Next;
            }

            return array;
        }
    }
}
