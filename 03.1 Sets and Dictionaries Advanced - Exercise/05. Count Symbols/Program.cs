using System;
using System.Collections.Generic;

namespace _05._Count_Symbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputText = Console.ReadLine();

            SortedDictionary<char, int> lettersCount = new SortedDictionary<char, int>();

            foreach (var symbol in inputText)
            {
                if (!lettersCount.ContainsKey(symbol))
                {
                    lettersCount.Add(symbol, 0);
                }

                lettersCount[symbol]++;
            }

            foreach (var symbol in lettersCount)
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}
