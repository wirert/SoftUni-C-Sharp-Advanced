using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace CocktailParty
{
    public class Cocktail
    {
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            this.Ingredients = new Dictionary<string, Ingredient>();            
        }

        public string Name { get; set; }
        public int Capacity { get; private set; }
        public int MaxAlcoholLevel { get; private set; }
        public Dictionary<string, Ingredient> Ingredients { get; private set; }
        public int CurrentAlcoholLevel => Ingredients.Values.Sum(i => i.Alcohol);
        public int Count => Ingredients.Count;

        public void Add(Ingredient ingredient)
        {
            if (Ingredients.ContainsKey(ingredient.Name)
            || Capacity == Count
            || CurrentAlcoholLevel + ingredient.Alcohol > MaxAlcoholLevel)
            {
                return;
            }

            Ingredients.Add(ingredient.Name, ingredient);
        }

        public bool Remove(string name) => Ingredients.Remove(name);

        public Ingredient FindIngredient(string name) => Ingredients.FirstOrDefault(i => i.Key == name).Value;

        public Ingredient GetMostAlcoholicIngredient() => Ingredients.Values.OrderByDescending(i => i.Alcohol).First();
        
        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");

            foreach (var ingredient in Ingredients)
            {
                sb.AppendLine(ingredient.Value.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }
}
