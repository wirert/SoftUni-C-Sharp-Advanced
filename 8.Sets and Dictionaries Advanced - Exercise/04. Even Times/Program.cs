using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Even_Times
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numberAppearing = new Dictionary<int, int>();

            int inputsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputsCount; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (!numberAppearing.ContainsKey(number))
                {
                    numberAppearing.Add(number, 0);
                }

                numberAppearing[number]++;
            }

            Console.WriteLine(numberAppearing.Single(x => x.Value % 2 == 0).Key);
        }
    }
}
