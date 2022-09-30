using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._List_Of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());

            HashSet<int> dividers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToHashSet();

            List<Predicate<int>> filters = new List<Predicate<int>>();

            foreach (int divider in dividers)
            {
                filters.Add(num => num % divider == 0);
            }

            int[] nums = Enumerable.Range(1, range).ToArray();

            foreach (var num in nums)
            {
                if (filters.Any(filter => !filter(num))) continue;

                Console.Write($"{num} ");
            }


            //Action<int, HashSet<int>> PrintIfDivisible = (i, nums) =>
            //{
            //    if (nums.Any(num => i % num != 0))
            //    {
            //        return;
            //    }

            //    Console.Write($"{i} ");
            //};

            //for (int i = 1; i <= range; i++)
            //{
            //    PrintIfDivisible(i, dividers);
            //}
        }
    }
}
