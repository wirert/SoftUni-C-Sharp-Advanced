using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();

            string command = null;

            while ((command = Console.ReadLine()) != "No more tires")
            {
                AddTires(tires, command);
            }

            List<Engine> engines = new List<Engine>();

            while ((command = Console.ReadLine()) != "Engines done")
            {
                AddEngine(engines, command);
            }

            List<Car> cars = new List<Car>();

            while ((command = Console.ReadLine()) != "Show special")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string make = tokens[0];
                string model = tokens[1];
                int year = int.Parse(tokens[2]);
                double fuelQuantity = double.Parse(tokens[3]);
                double fuelConsumption = double.Parse(tokens[4]);
                int engineIndex = int.Parse(tokens[5]);
                int tiresIndex = int.Parse(tokens[6]);

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex]);

                var sumPressure = car.Tires.Sum(x => x.Pressure);

                cars.Add(car);
            }

            PrintSpecialCars(cars);
        }

        public static void AddTires(List<Tire[]> tires, string command)
        {
            string[] tiresInfo = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Tire[] carTires = new Tire[tiresInfo.Length / 2];

            for (int i = 0; i < tiresInfo.Length - 1; i++)
            {
                if (i % 2 == 0)
                {
                    int year = int.Parse(tiresInfo[i]);
                    double pressure = double.Parse(tiresInfo[i + 1]);

                    carTires[i / 2] = new Tire(year, pressure);
                }
            }

            tires.Add(carTires);
        }

        public static void AddEngine(List<Engine> engines, string command)
        {
            string[] engineInfo = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int horsePower = int.Parse(engineInfo[0]);
            double cubicCapacity = double.Parse(engineInfo[1]);

            Engine engine = new Engine(horsePower, cubicCapacity);

            engines.Add(engine);
        }

        public static void PrintSpecialCars(List<Car> cars)
        {
            foreach (var car in cars)
            {
                if (car.Year >= 2017
                    && car.Engine.HorsePower > 330
                    && car.Tires.Sum(tire => tire.Pressure) >= 9
                    && car.Tires.Sum(tire => tire.Pressure) <= 10)
                {
                    car.Drive(20);

                    Console.WriteLine($"Make: {car.Make}\nModel: {car.Model}\nYear: {car.Year}\nHorsePowers: {car.Engine.HorsePower}\nFuelQuantity: {car.FuelQuantity}");
                }
            }
        }
    }
}
