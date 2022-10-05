using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            while (true)
            {
                string[] command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "Tournament") break;

                Pokemon pokemon = new Pokemon(command[1], command[2], int.Parse(command[3]));

                Trainer trainer = trainers.SingleOrDefault(t => t.Name == command[0]);

                if (trainer == null)
                {
                    trainer = new Trainer(command[0], 0);
                    trainers.Add(trainer);
                }

                trainer.Pokemons.Add(pokemon);
            }

            string input = null;

            while ((input = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(p => p.Element == input))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        trainer.DecreaseHealth();
                    }
                }
            }

            foreach (var trainer in trainers.OrderByDescending(t => t.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }
        }
    }
}

