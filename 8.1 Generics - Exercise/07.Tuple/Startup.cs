using System;

namespace _07.Tuple
{
    public class Startup
    {
        static void Main(string[] args)
        {
            string[] nameInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] drinkInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] numsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string address = nameInput.Length == 4 ? $"{nameInput[2]} {nameInput[3]}" : nameInput[2];

            Tuple<string, string> nameAddress = new Tuple<string, string>
                ($"{nameInput[0]} {nameInput[1]}", address);

            Tuple<string, int> nameDrinks = new Tuple<string, int>
               (drinkInput[0], int.Parse(drinkInput[1]));

            Tuple<int, double> nums = new Tuple<int, double>
               (int.Parse(numsInput[0]), double.Parse(numsInput[1]));

            Console.WriteLine(nameAddress);
            Console.WriteLine(nameDrinks);
            Console.WriteLine(nums);
        }
    }
}
