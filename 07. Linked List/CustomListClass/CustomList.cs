using System;

namespace CustomListClass
{
    public class CustomList<T>
    {
        private const int InitialCapacity = 2;

        private T[] items;

        public CustomList()
        {
            this.items = new T[InitialCapacity];
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
        public T this[int index]
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

        public void Add(T element)
        {
            if (this.Count == this.Capacity)
            {
                Resize();
            }

            this.items[this.Count] = element;
            this.Count++;
        }

        public void AddRange(T[] elements)
        {
            foreach (var element in elements)
            {
                this.Add(element);
            }
        }

        public void Insert(int index, T item)
        {
            CheckIndex(index);

            if (this.Count == this.Capacity)
            {
                Resize();
            }

            this.ShiftLeft(index);

            this.items[index] = item;
            this.Count++;

        }

        public T RemoveAt(int index)
        {
            CheckIndex(index);

            T item = this.items[index];

            this.ShiftRight(index);

            this.items[this.Count - 1] = default(T);
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

        //public bool Contains(T element)
        //{
        //    foreach (var item in this.items)
        //    {
        //        if (item.CompareTo(element) == 0)
        //        {
        //            return true;
        //        }
        //    }

        //    return false;
        //}

        public void Swap(int firstIndex, int secondIndex)
        {
            this.CheckIndex(firstIndex);
            this.CheckIndex(secondIndex);

            T copy = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = copy;
        }

        public void ForEach(Action<T> action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                action(this.items[i]);
            }
        }

        public T[] ToArray() => this.items;

        public void Clear()
        {
            this.items = new T[InitialCapacity];
            this.Count = 0;
        }

        private void Resize()
        {
            T[] resized = new T[this.Capacity * 2];

            for (int i = 0; i < this.Count; i++)
            {
                resized[i] = items[i];
            }

            items = resized;
        }

        private void Shrink()
        {
            T[] resized = new T[this.Capacity / 2];

            for (int i = 0; i < this.Count; i++)
            {
                resized[i] = items[i];
            }

            items = resized;
        }

        private void ShiftRight(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
        }

        private void ShiftLeft(int index)
        {
            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }

        private void ChangeCapacity(int capacity)
        {
            T[] resized = new T[capacity];

            for (int i = 0; i < this.Count; i++)
            {
                resized[i] = items[i];
            }

            items = resized;
        }
    }
}
