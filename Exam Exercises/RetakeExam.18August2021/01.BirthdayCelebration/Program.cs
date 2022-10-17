using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BirthdayCelebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var guests = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray().Reverse());
            var plates = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            int wastedFood = 0;
            

            while (guests.Count != 0 && plates.Count != 0)
            {
                int plate = plates.Pop();
                int guest = guests.Pop();                

                if (plate >= guest)
                {
                    wastedFood += plate - guest;                    
                }
                else
                {
                    guest -= plate;
                    guests.Push(guest);
                }
            }

            Console.WriteLine(plates.Count == 0 ? $"Guests: {string.Join(" ", guests)}"
                : $"Plates: {string.Join(" ", plates.Reverse())}");

            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}
