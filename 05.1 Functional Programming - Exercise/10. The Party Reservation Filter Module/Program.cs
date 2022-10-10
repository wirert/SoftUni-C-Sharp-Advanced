using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._The_Party_Reservation_Filter_Module
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Predicate<string>> filters = new Dictionary<string, Predicate<string>>();
            
            List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string cmd = null;
            int count = 0;

            while ((cmd = Console.ReadLine()) != "Print")
            {
                string[] tokens = cmd.Split(';', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string action = tokens[0];
                string condition = tokens[1];
                string value = tokens[2];

                if (action == "Add filter")
                {
                   filters.Add(condition + value, GetFilter(condition, value)); 
                }
                else
                {
                    filters.Remove(condition + value);
                }
            }

            foreach (var filter in filters)
            {
                names.RemoveAll(filter.Value);
            }

            Console.WriteLine(string.Join(" ", names));
        }

        private static Predicate<string> GetFilter(string condition, string value)
        {
            switch (condition)
            {
                case "Starts with": return name => name.StartsWith(value);
                case "Ends with": return name => name.EndsWith(value);
                case "Length": return name => name.Length == int.Parse(value);
                case "Contains": return name => name.Contains(value);
            }

            return null;
        }
    }
}
