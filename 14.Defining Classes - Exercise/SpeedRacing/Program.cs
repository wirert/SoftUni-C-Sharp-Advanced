using System;
using System.Collections.Generic;

namespace SpeedRacing
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> modelsCars = new Dictionary<string, Car>();

            int numCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numCars; i++)
            {
                string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = carInfo[0];
                double fuel = double.Parse(carInfo[1]);
                double fuelConsumption = double.Parse(carInfo[2]);

                modelsCars.Add(model, new Car(model, fuel, fuelConsumption));
            }

            string[] command = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "End")
            {
                string model = command[1];
                double distanceToTravel = double.Parse(command[2]);

                modelsCars[model].Drive(distanceToTravel);

                command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var model in modelsCars)
            {
                Console.WriteLine($"{model.Key} {model.Value.FuelAmount:F2} {model.Value.TravelledDistance}");
            }
        }
    }
}
