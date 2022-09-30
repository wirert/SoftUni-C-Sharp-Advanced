using System;
using System.Linq;

namespace _11._TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Func<string, int, bool> isSumLarger = (name, num) => name.Sum(ch => ch) >= num;

            Func<string[], Func<string, int, bool>, string> getFirstName = (names, isSumLarger) =>
              names.FirstOrDefault(name => isSumLarger(name, number));
            
            Console.WriteLine(getFirstName(names, isSumLarger));
        }
    }
}
