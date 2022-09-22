using System;
using System.Collections.Generic;

namespace _05._Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var continents = new Dictionary<string, Dictionary<string, List<string>>>();

            int numCmd = int.Parse(Console.ReadLine());

            for (int i = 0; i < numCmd; i++)
            {
                string[] input = Console.ReadLine().Split();
                string continent = input[0];
                string country = input[1];
                string town = input[2];

                if (!continents.ContainsKey(continent))
                {
                    continents.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!continents[continent].ContainsKey(country))
                {
                    continents[continent].Add(country,new List<string>());
                }

                continents[continent][country].Add(town);
            }

            foreach (var continent in continents)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}
