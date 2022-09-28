using System;

namespace _01._Action_Print
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> print = p => Console.WriteLine(String.Join(Environment.NewLine, p));

            print(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
