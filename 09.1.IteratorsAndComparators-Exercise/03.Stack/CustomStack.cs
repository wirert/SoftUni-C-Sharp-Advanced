using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _03.Stack
{
    public class CustomStack : IEnumerable
    {
        private const int initialCapacity = 4;
        private int[] stack;

        public CustomStack()
        {
            this.stack = new int[initialCapacity];
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void Push(params int[] nums)
        {
            foreach (int num in nums)
            {
                if (stack.Length == Count)
                {
                    Resize();
                }

                stack[Count] = num;
                Count++;
            }
        }

        public int Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }

            Count--;
            int element = stack[Count];

            return element;
        }

        private void Resize()
        {
            int[] copy = new int[stack.Length * 2];

            for (int i = 0; i < stack.Length; i++)
            {
                copy[i] = stack[i];
            }

            stack = copy;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return stack[i];
            }
        }
    }
}
