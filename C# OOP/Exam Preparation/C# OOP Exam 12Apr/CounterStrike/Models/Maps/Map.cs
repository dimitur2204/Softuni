
namespace CounterStrike.Models.Maps
{
    using CounterStrike.Models.Maps.Contracts;
    using CounterStrike.Models.Players;
    using CounterStrike.Models.Players.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    public class Map : IMap
    {
        public string Start(ICollection<IPlayer> players)
        {
            var terrorists = new List<Terrorist>();
            var counterTerrorist = new List<CounterTerrorist>();
            foreach (var player in players)
            {
                if (player.GetType().Name == "Terrorist")
                {
                    terrorists.Add((Terrorist)player);
                }
                else
                {
                    counterTerrorist.Add((CounterTerrorist)player);
                }
            }
            while (terrorists.Any(x => x.IsAlive) && counterTerrorist.Any(x => x.IsAlive)) 
            {
                for (int i = 0; i < counterTerrorist.Count; i++)
                {
                    for (int j = 0; j < terrorists.Count; j++)
                    {
                        if (counterTerrorist[i].IsAlive && terrorists[j].IsAlive)
                        {
                            counterTerrorist[i].TakeDamage(terrorists[j].Gun.Fire());
                        }
                    }
                }
                for (int i = 0; i < terrorists.Count; i++)
                {
                    for (int j = 0; j < counterTerrorist.Count; j++)
                    {
                        if (terrorists[i].IsAlive && counterTerrorist[j].IsAlive)
                        {
                            terrorists[i].TakeDamage(counterTerrorist[j].Gun.Fire());
                        }
                    }
                }
            }
            if (counterTerrorist.Any(x => x.IsAlive))
            {
                return "Counter Terrorist wins!";

            }
            else
            {
                return "Terrorist wins!";
            }
        }
    }
}
