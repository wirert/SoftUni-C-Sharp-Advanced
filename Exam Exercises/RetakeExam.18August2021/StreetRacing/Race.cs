using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            Participants = new Dictionary<string, Car>();
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }
        public Dictionary<string, Car> Participants { get; private set; }
        public int Count { get { return this.Participants.Count; } }

        public void Add(Car car)
        {
            if (!Participants.ContainsKey(car.LicensePlate)
                && this.Count < this.Capacity
                && car.HorsePower <= this.MaxHorsePower)
            {
                Participants.Add(car.LicensePlate, car);
            }
        }

        public bool Remove(string licensePlate) => Participants.Remove(licensePlate);

        public Car FindParticipant(string licensePlate)
        {
            if (Participants.ContainsKey(licensePlate))
            {
                return Participants[licensePlate];
            }

            return null;
        }

        public Car GetMostPowerfulCar()
        {
            if (Count == 0) return null;

            return Participants.Values.OrderByDescending(v => v.HorsePower).First();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");

            foreach (var car in Participants)
            {
                sb.AppendLine(car.Value.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
