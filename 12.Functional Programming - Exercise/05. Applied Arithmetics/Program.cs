using System;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, int> calculate = (action, num) =>
            {
                switch (action)
                {
                    case "add": return ++num;
                    case "subtract": return --num;
                    case "multiply": return num * 2;
                    default:
                        Console.Write($"{num} ");
                        return num;
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
