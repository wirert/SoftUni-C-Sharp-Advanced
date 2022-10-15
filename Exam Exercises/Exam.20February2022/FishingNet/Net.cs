using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
            Fish = new List<Fish>();
        }

        public List<Fish> Fish { get; private set; }
        public string Material { get; private set; }
        public int Capacity { get; private set; }
        public int Count { get { return Fish.Count; } }

        public string AddFish(Fish fish)
        {
            if (string.IsNullOrEmpty(fish.FishType) || fish.Length <= 0 || fish.Weight <= 0)
            {
                return "Invalid fish.";
            }

            if (Count == Capacity)
            {
                return "Fishing net is full.";
            }

            Fish.Add(fish);
            
            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            var fish = this.Fish.FirstOrDefault(f => f.Weight == weight);

            if (fish != null)
            {
                this.Fish.Remove(fish);
                return true;
            }

            return false;
        }

        public Fish GetFish(string fishType) => Fish.First(f => f.FishType == fishType);

        public Fish GetBiggestFish()
        {
           var fish = Fish.OrderByDescending(f => f.Length).Take(1).ToList();

            return fish[0];
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Into the {Material}:");

            foreach (var fish in Fish.OrderByDescending(f => f.Length))
            {
                sb.AppendLine(fish.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }
}
