using System;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            string filterString = Console.ReadLine().Trim();

            Predicate<string> isEvenCondition = w => w == "even";
            Predicate<int> isEvenOrOdd = n => n % 2 == 0;

            for (int i = range[0]; i <= range[1]; i++)
            {
                if (isEvenCondition(filterString))
                {
                    if (isEvenOrOdd(i))
                        Console.Write($"{i} ");
                }
                else
                {
                    if (!isEvenOrOdd(i))
                        Console.Write($"{i} ");
                }
            }
        }
    }
}
