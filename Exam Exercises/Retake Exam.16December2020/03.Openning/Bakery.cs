using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> data;

        public Bakery(string name, int capacity)
        {
            this.data = new List<Employee>();
            Name = name;
            Capacity = capacity;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => data.Count;

        public void Add(Employee employee)
        {
            if (Count < Capacity)
            {
                data.Add(employee);
            }
        }

        public bool Remove(string name) => data.Remove(data.FirstOrDefault(e => e.Name == name));

        public Employee GetOldestEmployee() => data.OrderByDescending(e => e.Age).First();

        public Employee GetEmployee(string name) => data.First(e => e.Name == name);

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Employees working at Bakery {Name}:");

            foreach (Employee employee in data)
            {
                sb.AppendLine(employee.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
