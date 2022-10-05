using System.Text;

namespace CarSalesman
{
    public class Car
    {
        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
            Weight = 0;
            Color = "n/a";
        }

        public Car(string model, Engine engine, int weight, string color) : this(model, engine)
        {
            Weight = weight;
            Color = color;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder printCar = new StringBuilder();

            printCar.AppendLine($"{this.Model}:");
            printCar.AppendLine(this.Engine.ToString().TrimEnd());

            if (this.Weight == 0)
            {
                printCar.AppendLine("  Weight: n/a");
            }
            else
            {
                printCar.AppendLine($"  Weight: {this.Weight}");
            }

            printCar.AppendLine($"  Color: {this.Color}");

            return printCar.ToString();
        }
    }
}
