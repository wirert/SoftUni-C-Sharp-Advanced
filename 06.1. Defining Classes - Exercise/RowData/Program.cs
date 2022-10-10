using System;
using System.Collections.Generic;
using System.Linq;

namespace RowData
{
    public class Program
    {
        static void Main(string[] args)
        {
            int numCars = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < numCars; i++)
            {
                string[] inputCarInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Car car = new Car(inputCarInfo[0],
                    new Engine(int.Parse(inputCarInfo[1]), int.Parse(inputCarInfo[2])),
                    new Cargo(inputCarInfo[4], int.Parse(inputCarInfo[3])));
                Tire[] tires = new Tire[4]
                {
                    new Tire(int.Parse(inputCarInfo[6]), double.Parse(inputCarInfo[5])),
                    new Tire(int.Parse(inputCarInfo[8]), double.Parse(inputCarInfo[7])),
                    new Tire(int.Parse(inputCarInfo[10]), double.Parse(inputCarInfo[9])),
                    new Tire(int.Parse(inputCarInfo[12]), double.Parse(inputCarInfo[11])),
                };

                car.Tires = tires;

                cars.Add(car);
            }

            if (Console.ReadLine() == "fragile")
            {
                Console.WriteLine(string.Join(Environment.NewLine, cars.Where(c => c.Tires.Any(t => t.Pressure < 1))));
            }
            else
            {
                Console.WriteLine(string.Join(Environment.NewLine, cars.Where(c => c.Engine.Power > 250)));
            }
        }
    }
}
