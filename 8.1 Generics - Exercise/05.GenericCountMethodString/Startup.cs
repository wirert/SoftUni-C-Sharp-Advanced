using System;
using System.Linq;

namespace _05.GenericCountMethodString
{
    internal class Startup
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            GenericList<string> list = new GenericList<string>();

            for (int i = 0; i < n; i++)
            {
                list.List.Add(Console.ReadLine());
            }

            string elementToCompare = Console.ReadLine();

            Console.WriteLine(list.CompareAndCount(elementToCompare));
        }
    }
}
