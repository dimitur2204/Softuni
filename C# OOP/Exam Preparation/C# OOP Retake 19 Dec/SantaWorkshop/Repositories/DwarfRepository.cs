
using System.Collections.Generic;
using System.Linq;
using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Repositories.Contracts;

namespace SantaWorkshop.Repositories
{
    public class DwarfRepository : IRepository<IDwarf>
    {
        private readonly List<IDwarf> _models;

        public DwarfRepository()
        {
            this._models = new List<IDwarf>();
        }
        public IReadOnlyCollection<IDwarf> Models => this._models;

        public void Add(IDwarf model)
        {
            this._models.Add(model);
        }

        public bool Remove(IDwarf model)
        {
            return this._models.Remove(model);
        }

        public IDwarf FindByName(string name)
        {
            return this._models.FirstOrDefault(d => d.Name == name);
        }
    }
}
