using System;
using System.Linq;

namespace CarSalesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            int numEngines = int.Parse(Console.ReadLine());

            Engine[] engines = new Engine[numEngines];

            for (int i = 0; i < numEngines; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                AddEngine(engines, i, input);
            }

            int numCars = int.Parse(Console.ReadLine());

            Car[] cars = new Car[numCars];

            for (int i = 0; i < numCars; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                AddCar(cars, engines, i, input);

            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString().TrimEnd());
            }
        }

        private static void AddEngine(Engine[] engines, int i, string[] input)
        {
            if (input.Length == 4)
            {
                engines[i] = new Engine(input[0], int.Parse(input[1]), int.Parse(input[2]), input[3]);
            }
            else
            {
                engines[i] = new Engine(input[0], int.Parse(input[1]));

                if (input.Length == 3)
                {
                    int displacemt;

                    if (int.TryParse(input[2], out displacemt))
                    {
                        engines[i].Displacement = displacemt;
                    }
                    else
                    {
                        engines[i].Efficiency = input[2];
                    }
                }
            }
        }

        private static void AddCar(Car[] cars, Engine[] engines, int i, string[] input)
        {
            Engine engine = engines.FirstOrDefault(e => e.Model == input[1]);

            if (input.Length == 4)
            {
                cars[i] = new Car(input[0], engine, int.Parse(input[2]), input[3]);
            }
            else
            {
                cars[i] = new Car(input[0], engine);

                if (input.Length == 3)
                {
                    int weight;

                    if (int.TryParse(input[2], out weight))
                    {
                        cars[i].Weight = weight;
                    }
                    else
                    {
                        cars[i].Color = input[2];
                    }
                }
            }
        }
    }
}
