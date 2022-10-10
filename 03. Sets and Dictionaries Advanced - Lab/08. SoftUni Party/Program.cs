using System;
using System.Collections.Generic;

namespace _08._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> partyMembers = new HashSet<string>();

            string command = null;

            while ((command = Console.ReadLine()) != "PARTY")
            {
                if (command.Length == 8)
                    partyMembers.Add(command);
            }

            while ((command = Console.ReadLine()) != "END")
            {
                partyMembers.Remove(command);
            }

            Console.WriteLine(partyMembers.Count);

            HashSet<string> vip = new HashSet<string>();
            HashSet<string> ordinary = new HashSet<string>();

            foreach (var member in partyMembers)
            {
                if (char.IsDigit(member[0]))
                {
                    vip.Add(member);
                }
                else
                {
                    ordinary.Add(member);
                }
            }


            foreach (var member in vip)
            {
                Console.WriteLine(member);
            }

            foreach (var member in ordinary)
            {
                Console.WriteLine(member);
            }
        }
    }
}
