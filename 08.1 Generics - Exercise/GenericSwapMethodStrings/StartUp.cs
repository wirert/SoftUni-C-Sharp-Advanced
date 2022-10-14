using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            GenericList<string> list = new GenericList<string>();

            for (int i = 0; i < n; i++)
            {
                list.List.Add(Console.ReadLine());
            }

            int[] indexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            list.Swap(indexes[0], indexes[1]);

            Console.WriteLine(list);
        }
    }
}
