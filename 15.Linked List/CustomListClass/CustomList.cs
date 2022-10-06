using System;

namespace CustomListClass
{
    public class CustomList
    {
        private const int InitialCapacity = 2;

        private int[] items;

        public CustomList()
        {
            this.items = new int[InitialCapacity];
        }

        public int Count { get; private set; }
        public int Capacity
        {
            get
            {
                return this.items.Length;
            }
            set
            {
                if (value < this.Count)
                {
                    throw new ArgumentException();
                }
               
                this.ChangeCapacity(value);
            }
        }
        public int this[int index]
        {
            get
            {
                CheckIndex(index);

                return this.items[index];
            }
            set
            {
                CheckIndex(index);

                this.items[index] = value;
            }
        }

        public void CheckIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void Add(int element)
        {
            if (this.Count == this.Capacity)
            {
                Resize();
            }

            this.items[this.Count] = element;
            this.Count++;
        }

        public void AddRange(int[] elements)
        {
            foreach (var element in elements)
            {
                this.Add(element);
            }
        }

        public int RemoveAt(int index)
        {
            CheckIndex(index);

            int item = this.items[index];

            this.Shift(index);

            this.items[this.Count - 1] = default(int);
            this.Count--;

            if (this.Count <= this.Capacity / 4)
            {
                this.Shrink();
            }

            return item;
        }

        public void RemoveRange(int index, int count)
        {
            CheckIndex(index);
            CheckIndex(index + count);

            if (count < 0) throw new IndexOutOfRangeException();

            for (int i = 0; i < count; i++)
            {
                this.RemoveAt(index);
            }
        }

        public bool Contains(int element)
        {
            foreach (var item in this.items)
            {
                if (item == element)
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            this.CheckIndex(firstIndex);
            this.CheckIndex(secondIndex);

            int copy = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = copy;
        }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                action(this.items[i]);
            }
        }

        public int[] ToArray() => this.items;

        public void Clear()
        {
            this.items = new int[InitialCapacity];
            this.Count = 0;
        }

        private void Resize()
        {           
            int[] resized = new int[this.Capacity * 2];

            for (int i = 0; i < this.Count; i++)
            {
                resized[i] = items[i];
            }

            items = resized;
        }

        private void Shrink()
        {
            int[] resized = new int[this.Capacity / 2];

            for (int i = 0; i < this.Count; i++)
            {
                resized[i] = items[i];
            }

            items = resized;
        }

        private void Shift(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
        }

        private void ChangeCapacity(int capacity)
        {
            int[] resized = new int[capacity];

            for (int i = 0; i < this.Count; i++)
            {
                resized[i] = items[i];
            }

            items = resized;
        }
    }
}
