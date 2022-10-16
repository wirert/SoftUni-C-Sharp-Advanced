using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        public Zoo(string name, int capacity)
        {
            Animals = new List<Animal>();
            Name = name;
            Capacity = capacity;
        }

        public List<Animal> Animals { get; private set; }
        public string Name { get; private set; }
        public int Capacity { get; private set; }

        public string AddAnimal(Animal animal)
        {
            if (string.IsNullOrEmpty(animal.Species)) return "Invalid animal species.";

            if (animal.Diet != "herbivore" && animal.Diet != "carnivore") return "Invalid animal diet.";

            if (this.Animals.Count >= Capacity) return "The zoo is full.";

            Animals.Add(animal);

            return $"Successfully added {animal.Species} to the zoo.";
        }

        public int RemoveAnimals(string species)
        {
            return Animals.RemoveAll(a => a.Species == species);
        }

        public	List<Animal> GetAnimalsByDiet(string diet)
        {
            return Animals.FindAll(a => a.Diet == diet);
        }

        public	Animal GetAnimalByWeight(double weight)
        {
            return Animals.FirstOrDefault(a => a.Weight == weight);
        }

        public	string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int count = 0;

            foreach (var animal in Animals)
            {
                if (animal.Length >= minimumLength && animal.Length <= maximumLength)
                {
                    count++;
                }
            }

            return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }

    }
}
