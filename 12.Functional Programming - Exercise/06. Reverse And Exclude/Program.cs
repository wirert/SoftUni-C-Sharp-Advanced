using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse()
                .ToList();
            
            int divider = int.Parse(Console.ReadLine());

            List<int> OnlyNonDivisible(List<int> nums, Predicate<int> condition) => nums.FindAll(condition);

            Console.WriteLine(string.Join(" ", OnlyNonDivisible(input, num => num % divider != 0)));
        }
    }
}

//int[] input = Console.ReadLine()
//    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
//    .Select(int.Parse)
//    .Reverse()
//    .ToArray();

//int num = int.Parse(Console.ReadLine());

//Func<int, int[], int[]> ifDivisible = (n, nums) =>
//{
//    return nums.Where(x => x % n != 0).ToArray();
//};

//Console.WriteLine(string.Join(' ', ifDivisible(num, input)));