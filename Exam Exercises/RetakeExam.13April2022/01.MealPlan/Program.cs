using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.MealPlan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> meals = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));

            var daysCalories = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            Dictionary<string, int> mealCalories = new Dictionary<string, int>()
            {
                { "salad", 350}, { "soup", 490}, { "pasta", 680}, { "steak", 790}
            };

            int leftCalories = 0;
            int mealsAte = 0;

            while (true)
            {
                int calories = daysCalories.Pop() - leftCalories;
                leftCalories = 0;

                if (meals.Count == 0)
                {
                    daysCalories.Push(calories);
                    break;
                }

                while (meals.Count != 0)
                {
                    string meal = meals.Dequeue();

                    if (!mealCalories.ContainsKey(meal)) continue;
                    
                    mealsAte++;

                    if (calories - mealCalories[meal] <= 0)
                    {
                        leftCalories = mealCalories[meal] - calories;
                        calories = leftCalories;
                        
                        break;
                    }

                    calories -= mealCalories[meal];
                }

                if ((meals.Count == 0 && calories > 0 && leftCalories == 0) || daysCalories.Count == 0)
                {
                    daysCalories.Push(calories);
                    break;
                }                              
            }

            if (meals.Count == 0)
            {
                Console.WriteLine($"John had {mealsAte} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", daysCalories)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {mealsAte} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals.Reverse())}.");
            }
        }
    }
}
