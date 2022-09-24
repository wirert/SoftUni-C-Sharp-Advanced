using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, SortedSet<string>> sideForceUsers = new SortedDictionary<string, SortedSet<string>>();

            string command = null;

            while ((command = Console.ReadLine()) != "Lumpawaroo")
            {
                string side = null;
                string user = null;

                if (command.Contains('|'))
                {
                    string[] tokens = command.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                    side = tokens[0];
                    user = tokens[1];

                    if (sideForceUsers.Any(s => s.Value.Contains(user))) continue;
                    
                    if (!sideForceUsers.ContainsKey(side))
                    {
                        sideForceUsers.Add(side, new SortedSet<string>());
                    }

                    sideForceUsers[side].Add(user);
                }
                else
                {
                    string[] tokens = command.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    side = tokens[1];
                    user = tokens[0];

                    Console.WriteLine($"{user} joins the {side} side!");

                    if (sideForceUsers.Any(s => s.Value.Contains(user)))
                    {
                        sideForceUsers.First(s => s.Value.Contains(user)).Value.Remove(user);
                    }

                    if (!sideForceUsers.ContainsKey(side))
                    {
                        sideForceUsers.Add(side, new SortedSet<string>());
                    }

                    sideForceUsers[side].Add(user);
                }
            }

            foreach (var side in sideForceUsers.OrderByDescending(s => s.Value.Count))
            {
                if (!side.Value.Any()) continue;

                Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");

                foreach (var user in side.Value)
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }
    }
}
