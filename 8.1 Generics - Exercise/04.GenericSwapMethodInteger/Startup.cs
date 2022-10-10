using System;
using System.Linq;

namespace _04.GenericSwapMethodInteger
{
    public class Startup
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            GenericList<int> list = new GenericList<int>();

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());

                list.List.Add(input);
            }

            int[] indexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            list.Swap(indexes[0], indexes[1]);

            Console.WriteLine(list);
        }
    }
}
