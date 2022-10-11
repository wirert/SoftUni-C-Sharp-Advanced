using System;
using System.Collections.Generic;
using System.Text;

namespace _06.GenericCountMethodDouble
{
    public class GenericList<T> where T : IComparable<T>
    {
        public GenericList()
        {
            List = new List<T>();
        }

        public List<T> List { get; set; }

        public void Swap(int index1, int index2)
        {
            if (index1 < 0 || index1 >= this.List.Count || index2 < 0 || index2 >= this.List.Count)
            {
                throw new IndexOutOfRangeException();
            }

            T copy = List[index1];
            List[index1] = List[index2];
            List[index2] = copy;
        }

        public int CompareAndCount(T elementToCompareWith)
        {
            int count = 0;

            foreach (var item in this.List)
            {
                if (item.CompareTo(elementToCompareWith) > 0)
                {
                    count++;
                }
            }

            return count;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (T item in this.List)
            {
                sb.AppendLine($"{typeof(T)}: {item}");
            }
            return sb.ToString();
        }
    }
}
