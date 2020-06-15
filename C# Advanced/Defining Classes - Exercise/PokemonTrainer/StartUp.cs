using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{

    public class StartUp
    {
        static void Main()
        {
            var command = Console.ReadLine();
            var trainers = new List<Trainer>();
            while (command != "Tournament")
            {
                var trainerInfo = command.Split(' ',StringSplitOptions.RemoveEmptyEntries);
                Trainer trainer;
                if (trainers.Any(t => t.Name == trainerInfo[0]))
                {
                    trainer = trainers.First(t => t.Name == trainerInfo[0]);
                }
                else
                {
                    trainer = new Trainer(trainerInfo[0], new List<Pokemon>());
                    trainers.Add(trainer);
                }
                trainer.Pokemons.Add(new Pokemon(trainerInfo[1],trainerInfo[2],int.Parse(trainerInfo[3])));
                command = Console.ReadLine();
            }

            var element = Console.ReadLine();
            while (element != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(p => p.Element == element))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        foreach (var pokemon in trainer.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }

                        trainer.Pokemons = trainer.Pokemons.Where(p => p.Health > 0).ToList();
                    }
                }

                element = Console.ReadLine();
            }

            foreach (var trainer in trainers.OrderByDescending(t => t.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }
        }
    }
}
