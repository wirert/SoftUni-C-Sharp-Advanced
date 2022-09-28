using System;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, int> calculate = (a, c) =>
            {
                switch (a)
                {
                    case "add": return c + 1;
                    case "subtract": return c - 1;
                    case "multiply": return c * 2;
                    default:
                        Console.Write($"{c} ");
                        return c;
                }
            };

            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            string action = null;

            while ((action = Console.ReadLine()) != "end")
            {
                for (int i = 0; i < input.Length; i++)
                {
                    input[i] = calculate(action, input[i]);
                }

                if (action == "print")
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
