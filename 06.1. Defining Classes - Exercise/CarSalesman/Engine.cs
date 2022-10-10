using System.Text;

namespace CarSalesman
{
    public class Engine
    {
        public Engine(string model, int power)
        {
            Model = model;
            Power = power;
            Efficiency = "n/a";
            Displacement = 0;
        }
        public Engine(string model, int power, int displacement, string efficiency) : this(model, power)
        {
            Displacement = displacement;
            Efficiency = efficiency;
        }

        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }

        public override string ToString()
        {
            StringBuilder printPattern = new StringBuilder();

            printPattern.AppendLine($"  {this.Model}:");
            printPattern.AppendLine($"    Power: {this.Power}");

            if (this.Displacement == 0)
            {
                printPattern.AppendLine("    Displacement: n/a");
            }
            else
            {
                printPattern.AppendLine($"    Displacement: {this.Displacement}");
            }

            printPattern.AppendLine($"    Efficiency: {this.Efficiency}");

            return printPattern.ToString();
        }
    }
}
