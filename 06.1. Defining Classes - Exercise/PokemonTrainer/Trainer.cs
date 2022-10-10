using System.Collections.Generic;

namespace PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name, int badges)
        {
            Name = name;
            Badges = badges;
            Pokemons = new List<Pokemon>();
        }

        public string Name { get; set; }
        public int Badges { get; set; }
        public List<Pokemon> Pokemons { get; set; }

        public void DecreaseHealth()
        {
            for (int i = 0; i < Pokemons.Count; i++)
            {
                Pokemons[i].Health -= 10;

                if (Pokemons[i].Health <= 0)
                {
                    Pokemons.RemoveAt(i);
                }
            }
        }
    }
}
