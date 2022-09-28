using System;
using System.Linq;

namespace _04.AddVAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, string> addVAT = n => (double.Parse(n) * 1.2).ToString("f2");

            Console.WriteLine(string.Join(Environment.NewLine,
                Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(addVAT)));
        }
    }
}
