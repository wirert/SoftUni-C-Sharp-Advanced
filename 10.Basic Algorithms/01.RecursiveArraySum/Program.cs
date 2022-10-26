using System;
using System.Linq;

namespace _01.RecursiveArraySum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int index = 0;

            Console.WriteLine(SumNums(arr, index));
        }

        private static int SumNums(int[] arr, int index)
        {            
            if (index == arr.Length)
            {
                return 0;
            }

            int result = SumNums(arr, index + 1) + arr[index];

            return result;
        }
    }
}
