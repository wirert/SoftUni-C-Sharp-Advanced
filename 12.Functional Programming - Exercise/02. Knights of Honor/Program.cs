using System;
using System.Linq;

namespace _02._Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> printSir = a => Console.WriteLine(string
                .Join(Environment.NewLine, a
                    .Select(w => $"Sir {w}")));

            printSir(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
