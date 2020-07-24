
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Fish;
using AquaShop.Repositories;

namespace AquaShop.Core
{
    public class Controller: IController
    {
        private readonly List<IAquarium> aquariums;
        private readonly DecorationRepository decorations;

        public Controller()
        {
            this.aquariums = new List<IAquarium>();
            this.decorations = new DecorationRepository();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType == "FreshwaterAquarium")
            {
                this.aquariums.Add(new FreshwaterAquarium(aquariumName));
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                this.aquariums.Add(new SaltwaterAquarium(aquariumName));
            }
            else
            {
                throw new InvalidOperationException("Invalid aquarium type.");
            }
            return $"Successfully added {aquariumType}.";
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType == "Ornament")
            {
                this.decorations.Add(new Ornament());
            }
            else if (decorationType == "Plant")
            {
                this.decorations.Add(new Plant());
            }
            else
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }
            return $"Successfully added {decorationType}.";
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            if (decorationType == "Ornament" || decorationType == "Plant")
            {
                var decoration = this.decorations.FindByType(decorationType);
                if (decoration != null)
                {
                    this.aquariums
                        .FirstOrDefault(a => a.Name == aquariumName)
                        .AddDecoration(
                            decoration
                        );
                    this.decorations.Remove(decoration);
                }
            }
            else
            {
                throw new InvalidOperationException("Invalid decoration type.");
            }

            return $"Successfully added {decorationType} to {aquariumName}.";
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            var aquarium = this.aquariums
                .FirstOrDefault(a => a.Name == aquariumName);
            if (fishType == "FreshwaterFish")
            {
                if (aquarium.GetType().Name != "FreshwaterAquarium")
                {
                    return "Water not suitable.";
                }
                aquarium.AddFish(new FreshwaterFish(price,fishSpecies,fishName));
            }
            else if (fishType == "SaltwaterFish")
            {
                if (aquarium.GetType().Name != "SaltwaterAquarium")
                {
                    return "Water not suitable.";
                }
                aquarium.AddFish(new SaltwaterFish(price, fishSpecies, fishName));
            }
            else
            {
                throw new InvalidOperationException("Invalid fish type.");
            }

            return $"Successfully added {fishType} to {aquariumName}.";
        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = this.aquariums
                .FirstOrDefault(a => a.Name == aquariumName);
            var count = 0;
            aquarium.Fish.ToList().ForEach(f =>
            {
                f.Eat();
                count++;
            });
            return $"Fish fed: {count}";
        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = this.aquariums
                .FirstOrDefault(a => a.Name == aquariumName);
            var value = 0.0m;
            aquarium.Fish.ToList().ForEach(f => { value += f.Price; });
            aquarium.Decorations.ToList().ForEach(d => { value += d.Price; });
            return $"The value of Aquarium {aquariumName} is {value:F2}.";
        }

        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().Trim();
        }
    }
}
