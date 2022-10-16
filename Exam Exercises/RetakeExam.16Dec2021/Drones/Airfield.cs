using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        public Airfield(string name, int capacity, double landingStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
            Drones = new List<Drone>();
        }

        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public double LandingStrip { get; set; }
        public List<Drone> Drones { get; private set; }
        public int Count { get { return Drones.Count; } }

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name)
                || string.IsNullOrEmpty(drone.Brand)
                || drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }

            if (Count == Capacity) return "Airfield is full.";

            Drones.Add(drone);

            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            bool hasSuchDrone = Drones.Any(d => d.Name == name);

            if (hasSuchDrone)
            {
                Drone drone = Drones.First(d => d.Name == name);
                Drones.Remove(drone);
            }

            return hasSuchDrone;
        }

        public int RemoveDroneByBrand(string brand) => Drones.RemoveAll(d => d.Brand == brand);

        public Drone FlyDrone(string name)
        {
            Drone drone = Drones.FirstOrDefault(d => d.Name == name);

            if (drone != null)
            {
                drone.Available = false;
            }

            return drone;
        }

        public List<Drone> FlyDronesByRange(int range)
        {
            if (Drones.Where(d => d.Available).All(d => d.Range < range))
            {
                return new List<Drone>();
            }

            var flownDrones = Drones.Where(d => d.Available).ToList().FindAll(d => d.Range >= range);

            foreach (var drone in flownDrones)
            {
                drone.Available = false;
            }

            return flownDrones;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Drones available at {this.Name}:");

            foreach (var drone in Drones.Where(d => d.Available))
            {
                sb.AppendLine(drone.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
