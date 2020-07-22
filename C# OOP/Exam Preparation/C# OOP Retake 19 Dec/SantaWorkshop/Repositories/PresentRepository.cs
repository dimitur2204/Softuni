
using System.Collections.Generic;
using System.Linq;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Repositories.Contracts;

namespace SantaWorkshop.Repositories
{
    class PresentRepository : IRepository<IPresent>
    {
        private readonly List<IPresent> _models;

        public PresentRepository()
        {
            this._models = new List<IPresent>();
        }

        public IReadOnlyCollection<IPresent> Models => this._models;
        public void Add(IPresent model)
        {
           this._models.Add(model);
        }

        public bool Remove(IPresent model)
        {
            return this._models.Remove(model);
        }

        public IPresent FindByName(string name)
        {
            return this._models.FirstOrDefault(p => p.Name == name);
        }
    }
}
