using System;
using System.Linq;

namespace _07._Predicate_For_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> isLengthEnough = (w, l) => w.Length <= l;

            int length = int.Parse(Console.ReadLine());

            Console.WriteLine(string.Join(Environment.NewLine, Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(w => isLengthEnough(w, length))
                ));
        }
    }
}
