using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();

            var numOccurrences = new Dictionary<double, int>();

            foreach (var number in numbers)
            {
                if (!numOccurrences.ContainsKey(number))
                {
                    numOccurrences.Add(number, 0);
                }

                numOccurrences[number]++;
            }

            foreach (var number in numOccurrences)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }
        }
    }
}
