
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CounterStrike.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private readonly List<IPlayer> players;
        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }
        public IReadOnlyCollection<IPlayer> Models => this.players.AsReadOnly();

        public void Add(IPlayer model)
        {
            if (model == null)
            {
                throw new ArgumentException("Cannot add null in Player Repository");
            }
            players.Add(model);
        }

        public IPlayer FindByName(string name)
        {
            return players.First(x => x.Username == name);
        }

        public bool Remove(IPlayer model)
        {
            if (!players.Contains(model))
            {
                return false;
            }
            players.Remove(model);
            return true;
        }
    }
}
