using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    internal class Parking
    {
        private List<Car> data;

        public Parking(string type, int capacity)
        {
            this.data = new List<Car>();
            Type = type;
            Capacity = capacity;
        }

        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count => data.Count;

        public void Add(Car car)
        {
            if (Capacity > Count)
            {
                data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
            => data.Remove(data.FirstOrDefault(c => c.Model == model && c.Manufacturer == manufacturer));

        public Car GetLatestCar() => data.OrderByDescending(c => c.Year).FirstOrDefault();

        public Car GetCar(string manufacturer, string model)
            => data.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {Type}:");

            foreach (var car in data)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
