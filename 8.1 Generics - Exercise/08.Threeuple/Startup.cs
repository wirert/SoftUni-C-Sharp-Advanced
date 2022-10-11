using System;
using System.Collections.Generic;

namespace _08.Threeuple
{
    public class Startup
    {
        static void Main(string[] args)
        {
            string[] nameInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] drinkInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] numsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        
            string town = nameInput.Length == 5 ? $"{nameInput[3]} {nameInput[4]}" : nameInput[3];

            Threeuple<string, string, string> nameAddress = new Threeuple<string, string, string>
                ($"{nameInput[0]} {nameInput[1]}", nameInput[2], town);

            Threeuple<string, int, bool> nameDrinks = new Threeuple<string, int, bool>
               (drinkInput[0], int.Parse(drinkInput[1]), drinkInput[2] == "drunk");

            Threeuple<string, double, string> bankAccount = new Threeuple<string, double, string>
               (numsInput[0], double.Parse(numsInput[1]), numsInput[2]);

            Console.WriteLine(nameAddress);
            Console.WriteLine(nameDrinks);
            Console.WriteLine(bankAccount);
        }
    }
}
