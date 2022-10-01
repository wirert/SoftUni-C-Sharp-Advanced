using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string make = Console.ReadLine();
            string model = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            double fuelQuantity = double.Parse(Console.ReadLine());
            double fuelConsumption = double.Parse(Console.ReadLine());

            Car firstCar = new Car();

            Car secondCar = new Car(make, model, year);

            Car thirdCar = new Car(make, model, year, fuelQuantity, fuelConsumption);

            Engine engine = new Engine(175, 1900);

            Tire[] tires = new Tire[4]
            {
                new Tire(2022, 2.50),
                new Tire(2022, 2.50),
                new Tire(2022, 2.50),
                new Tire(2022, 2.50),
            };

            thirdCar.Tires = tires;
            thirdCar.Engine = engine;

            Car car = new Car("Saab", "9-5", 2012, 72, 7, engine, tires);
        }
    }
}
