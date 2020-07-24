
using System.Collections.Generic;
using System.Linq;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;

namespace AquaShop.Repositories
{
    public class DecorationRepository: IRepository<IDecoration>
    {
        private readonly List<IDecoration> _decorations;

        public DecorationRepository()
        {
            this._decorations =new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models => this._decorations.AsReadOnly();
        public void Add(IDecoration model)
        {
            this._decorations.Add(model);
        }

        public bool Remove(IDecoration model)
        {
            return this._decorations.Remove(model);
        }

        public IDecoration FindByType(string type)
        {
            return this._decorations.FirstOrDefault(d => d.GetType().Name == type);
        }
    }
}
