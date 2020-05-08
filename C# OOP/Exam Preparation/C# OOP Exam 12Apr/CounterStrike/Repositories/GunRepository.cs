
namespace CounterStrike.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CounterStrike.Models.Guns.Contracts;
    using CounterStrike.Repositories.Contracts;

    public class GunRepository : IRepository<IGun>
    {
        private readonly List<IGun> guns;
        public GunRepository()
        {
            this.guns = new List<IGun>();
        }
        public IReadOnlyCollection<IGun> Models 
        {
            get => this.guns.AsReadOnly();
        }
        public void Add(IGun model)
        {
            if (model == null)
            {
                throw new ArgumentException("Cannot add null in Gun Repository");
            }
            guns.Add(model);
        }

        public IGun FindByName(string name)
        {
            try
            {
               return guns.First(x => x.Name == name);

            }
            catch (Exception)
            {
                return null;   
            }
            
        }

        public bool Remove(IGun model)
        {
            if (!guns.Contains(model))
            {
                return false;
            }
            guns.Remove(model);
            return true;
        }
    }
}
