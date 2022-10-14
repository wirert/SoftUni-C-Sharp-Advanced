using System;
using System.Collections.Generic;

namespace _01.ListyIterator
{
    public class ListyIterator<T>
    {
        private List<T> list;
        private int index;

        public ListyIterator(List<T> list)
        {
            this.list = list;
            index = 0;
        }

        public bool Move()
        {
            if(HasNext())
            {
                index++;
                return true;
            }
            
            return false;
        }

        public bool HasNext() => index < list.Count - 1;

        public void Print()
        {
            if (list.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(list[index]);
        }
    }
}
