using System;
using System.Collections.Generic;

namespace _06._Record_Unique_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<string> uniqueNamesCollection = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                uniqueNamesCollection.Add(Console.ReadLine());
            }

            foreach (var name in uniqueNamesCollection)
            {
                Console.WriteLine(name);
            }
        }
    }
}
