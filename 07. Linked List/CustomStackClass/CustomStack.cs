using System;

namespace CustomStackClass
{
    public class CustomStack
    {
        private const int InitialCapacity = 4;
        private int[] items;
        private int count;        

        public CustomStack()
        {
            this.count = 0;
            this.items = new int[InitialCapacity];
        }

        public int Count
        {
            get { return this.count; }
        }
       

        public void Push(int item)
        {
            if (this.Count == this.items.Length)
            {
                Resize();
            }

            this.items[this.count] = item;
            this.count++;
        }

        public int Peek()
        {
            if (this.count == 0)
            {
                throw new IndexOutOfRangeException("CustomStack is empty");
            }

            return this.items[this.count - 1];
        }

        public int Pop()
        {
            if (this.count == 0)
            {
                throw new IndexOutOfRangeException("CustomStack is empty");
            }

            int item = this.items[this.count - 1];
            this.items[this.count - 1] = default(int);
            this.count--;

            return item;
        }

        public void Clear()
        {
            this.items = new int[InitialCapacity];
            this.count = 0;
        }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < this.count; i++)
            {
                action(items[i]);
            }
        }

        private void Resize()
        {
            int[] copy = new int[this.items.Length * 2];

            for (int i = 0; i < this.items.Length; i++)
            {
                copy[i] = items[i];
            }

            items = copy;
        }
    }
}
