using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private Dictionary<int, Ski> skis;

        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            this.skis = new Dictionary<int, Ski>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => skis.Count;

        public void Add(Ski ski)
        {
            if (Capacity > Count)
            {
                skis.Add(ski.Year, ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Ski ski = skis.Values.FirstOrDefault(s => s.Model == model && s.Manufacturer == manufacturer);

            if (ski != null)
            {
                skis.Remove(ski.Year);
                return true;
            }

            return false;
        }

        public Ski GetNewestSki()
        {
            if (Count == 0) return null;

            return skis.Values.OrderByDescending(s => s.Year).First();
        }

        public Ski GetSki(string manufacturer, string model) => skis.Values
            .SingleOrDefault(s => s.Manufacturer == manufacturer && s.Model == model);

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The skis stored in {Name}:");

            foreach (var ski in skis.Values)
            {
                sb.AppendLine(ski.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
