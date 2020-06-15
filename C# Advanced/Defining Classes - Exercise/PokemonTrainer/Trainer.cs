
using System.Collections.Generic;

namespace PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name, List<Pokemon> pokemons)
        {
            Name = name;
            Badges = 0;
            Pokemons = pokemons;
        }
        public string Name { get;  }
        public int Badges { get; set; }
        public List<Pokemon> Pokemons { get; set; }
    }
}
