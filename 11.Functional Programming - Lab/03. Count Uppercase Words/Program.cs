using System;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> isStartWithUpper = w => char.IsUpper(w[0]);

            Console.WriteLine(string.Join(Environment.NewLine, Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(isStartWithUpper)
                .ToArray()));
        }
    }
}
