using System;
using System.Collections.Generic;

namespace CustomListClass
{
    public class Program
    {
        static void Main(string[] args)
        {
            CustomList customList = new CustomList();

            customList.Add(1);
            customList.AddRange(new[] { 2, 3, 4, 5, 6, 7, 8 });

            customList.ForEach(x => Console.Write(x + " "));
            Console.WriteLine();

            customList.Swap(1, 6);

            customList.ForEach(x => Console.Write(x + " "));
            Console.WriteLine();

            Console.WriteLine("Capacity:" + customList.Capacity);

            customList.RemoveAt(1);

            Console.WriteLine(customList.Contains(50));
            Console.WriteLine(customList.Contains(4));

            customList.ForEach(x => Console.Write(x + " "));
            Console.WriteLine();

            customList.Capacity = 20;
            Console.WriteLine("Capacity:" + customList.Capacity);

            customList.RemoveRange(1, 3);

            customList.ForEach(x => Console.Write(x + " "));
            Console.WriteLine();

            customList.Capacity = 4;
            Console.WriteLine("Capacity:" + customList.Capacity);

            customList.Insert(0, 60);

            customList.ForEach(x => Console.Write(x + " "));
            Console.WriteLine();

            
            Console.WriteLine("Capacity:" + customList.Capacity);

        }
    }
}
