using System;
using System.Linq;

namespace _08._List_Of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int range = int.Parse(Console.ReadLine());

            int[] dividers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Action<int, int[]> PrintIfDivisible = (i, nums) =>
            {
                if (nums.Any(num => i % num != 0))
                {
                    return;
                }

                Console.Write($"{i} ");
            };

            for (int i = 1; i <= range; i++)
            {
                PrintIfDivisible(i, dividers);
            }
        }
    }
}
