﻿using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            Multiprocessor = new List<CPU>();
        }

        public string Model { get; set; }
        public int Capacity { get; set; }
        public List<CPU> Multiprocessor { get; private set; }
        public int Count => Multiprocessor.Count;

        public void Add(CPU cpu)
        {
            if (Capacity > Count)
            {
                Multiprocessor.Add(cpu);
            }
        }

        public bool Remove(string brand) => Multiprocessor.Remove(Multiprocessor.FirstOrDefault(p => p.Brand == brand));

        public CPU MostPowerful() => Multiprocessor.OrderByDescending(p => p.Frequency).FirstOrDefault();

        public CPU GetCPU(string brand) => Multiprocessor.FirstOrDefault(p => p.Brand == brand);

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"CPUs in the Computer {Model}:");

            foreach (var cpu in Multiprocessor)
            {
                sb.AppendLine(cpu.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
