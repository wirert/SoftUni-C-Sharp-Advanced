using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private Dictionary<string, Racer> data;

        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            this.data = new Dictionary<string, Racer>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => data.Count;

        public void Add(Racer racer)
        {
            if (Capacity > Count)
            {
                data.Add(racer.Name, racer);
            }
        }

        public bool Remove(string name) => data.Remove(name);

        public Racer GetOldestRacer() => data.Values.OrderByDescending(r => r.Age).First();

        public Racer GetRacer(string name) => data[name];

        public Racer GetFastestRacer() => data.Values.OrderByDescending(r => r.Car.Speed).First();

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Racers participating at {Name}:");

            foreach (var racer in data.Values)
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
