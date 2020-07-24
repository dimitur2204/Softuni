
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium: IAquarium
    {
        private string _name;
        private readonly List<IDecoration> _decorations = new List<IDecoration>();
        private readonly List<IFish> _fish = new List<IFish>();

        protected Aquarium(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
        }
        public string Name
        {
            get => _name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Fish species cannot be null or empty");
                }

                _name = value;
            }
        }

        public int Capacity { get; }

        
        public ICollection<IDecoration> Decorations => this._decorations;
        public int Comfort => this.Decorations.Select(d => d.Comfort).Sum();
        public ICollection<IFish> Fish => this._fish;
        public void AddFish(IFish fish)
        {
            if (this.Fish.Count == this.Capacity)
            {
                throw new InvalidOperationException("Not enough capacity.");
            }
            this.Fish.Add(fish);
        }

        public bool RemoveFish(IFish fish)
        {
            return this.Fish.Remove(fish);
        }

        public void AddDecoration(IDecoration decoration)
        {
            this.Decorations.Add(decoration);
        }

        public void Feed()
        {
            this.Fish.ToList().ForEach(f => f.Eat());
        }

        public string GetInfo()
        {
            var sb = new StringBuilder();
            if (!this.Fish.Any())
            {
                sb.AppendLine($"{this.Name} ({this.GetType().Name}):");
                sb.AppendLine($"Fish: none");
                sb.AppendLine($"Decorations: {this.Decorations.Count}");
                sb.AppendLine($"Comfort: {this.Comfort}");
            }
            else
            {
                sb.AppendLine($"{this.Name} ({this.GetType().Name}):");
                sb.AppendLine($"Fish: {String.Join(", ", this.Fish.Select(f => f.Name))}");
                sb.AppendLine($"Decorations: {this.Decorations.Count}");
                sb.AppendLine($"Comfort: {this.Comfort}");
            }
            return sb.ToString().Trim();
        }
    }
}
