using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vlogger> vloggersList = new List<Vlogger>();

            string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "Statistics")
            {
                string vloggerName = command[0];

                if (command[1] == "joined")
                {
                    Vlogger vlogger = new Vlogger(vloggerName);

                    if (vloggersList.All(v => v.Name != vloggerName))
                        vloggersList.Add(vlogger);
                }
                else
                {
                    string vloggerToFollow = command[2];

                    if (vloggerToFollow != vloggerName && vloggersList.Any(v => v.Name == vloggerToFollow) && vloggersList.Any(v => v.Name == vloggerName))
                    {
                        vloggersList.Single(v => v.Name == vloggerName).Following.Add(vloggerToFollow);
                        vloggersList.Single(v => v.Name == vloggerToFollow).Followers.Add(vloggerName);
                    }
                }

                command = Console.ReadLine().Split(' ');
            }

            PrintVloggersList(vloggersList);
        }

        static void PrintVloggersList(List<Vlogger> vloggersList)
        {
            Console.WriteLine($"The V-Logger has a total of {vloggersList.Count} vloggers in its logs.");

            vloggersList = vloggersList.OrderByDescending(v => v.Followers.Count).ThenBy(v => v.Following.Count).ToList();

            for (int i = 0; i < vloggersList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {vloggersList[i].Name} : {vloggersList[i].Followers.Count} followers, {vloggersList[i].Following.Count} following");

                if (i == 0)
                {
                    foreach (var follower in vloggersList[i].Followers)
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
            }
        }
    }

    class Vlogger
    {
        public Vlogger(string name)
        {
            this.Name = name;
            this.Followers = new SortedSet<string>();
            this.Following = new HashSet<string>();
        }

        public string Name { get; set; }
        public SortedSet<string> Followers { get; set; }
        public HashSet<string> Following { get; set; }

    }
}
