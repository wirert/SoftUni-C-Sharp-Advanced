using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Predicate_Party_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToList();


            string[] inputCommands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (inputCommands[0] != "Party!")
            {
                string action = inputCommands[0];
                string command = inputCommands[1];
                string value = inputCommands[2];

                if (action == "Remove")
                {
                    guests.RemoveAll(GetPredicate(command, value));
                }
                else
                {
                    List<string> guestsToDouble = guests.FindAll(GetPredicate(command, value));

                    foreach (var guest in guestsToDouble)
                    {
                        int index = guests.IndexOf(guest);
                        guests.Insert(index, guest);
                    }
                }

                inputCommands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            if (guests.Any())
            {
                Console.WriteLine(string.Join(", ", guests) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        static Predicate<string> GetPredicate(string command, string value)
        {
            switch (command)
            {
                case "StartsWith":
                    return guest => guest.StartsWith(value);
                case "EndsWith":
                    return guest => guest.EndsWith(value);
                case "Length":
                    return guest => guest.Length == int.Parse(value);
                default:
                    return null;
            }
        }
    }
}
