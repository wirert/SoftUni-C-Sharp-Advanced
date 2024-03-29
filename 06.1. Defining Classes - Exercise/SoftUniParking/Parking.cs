﻿using System.Collections.Generic;

namespace SoftUniParking
{
    public class Parking
    {
        private int capacity;
        private Dictionary<string, Car> cars;

        public Parking(int capacity)
        {
            this.capacity = capacity;
            this.cars  = new Dictionary<string, Car>();
        }

        public int Count { get { return cars.Count; } }

        // public int Count { get { return this.cars.Count; } }

        public string AddCar(Car car)
        {
            if (cars.ContainsKey(car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";                
            }

            if (this.Count == this.capacity)
            {
                return "Parking is full!";                 
            }

            cars.Add(car.RegistrationNumber, car);

            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            if (!cars.ContainsKey(registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }

            cars.Remove(registrationNumber);

            return $"Successfully removed {registrationNumber}";
        }

        public Car GetCar(string registrationNumber) => cars[registrationNumber];
        
        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var number in registrationNumbers)
            {
                if (cars.ContainsKey(number))
                {
                    cars.Remove(number);
                }
            }
        }
    }
}
