
namespace CounterStrike.Core
{
    using CounterStrike.Core.Contracts;
    using CounterStrike.Models.Guns;
    using CounterStrike.Models.Maps;
    using CounterStrike.Models.Maps.Contracts;
    using CounterStrike.Models.Players;
    using CounterStrike.Repositories;
    using System;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private readonly GunRepository guns;
        private readonly PlayerRepository players;
        private readonly IMap map;
        public Controller()
        {
            this.guns = new GunRepository();
            this.players = new PlayerRepository();
            this.map = new Map();
        }
        public string AddGun(string type, string name, int bulletsCount)
        {
            if (type == "Pistol")
            {
                this.guns.Add(new Pistol(name, bulletsCount));
                return $"Successfully added gun {name}.";
                
            }
            else if (type == "Rifle") 
            {
                this.guns.Add(new Rifle(name, bulletsCount));
                return $"Successfully added gun {name}.";
            }
            else
            {
                throw new ArgumentException("Invalid gun type.");
            }
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            if (this.guns.FindByName(gunName) == null)
            {
                throw new ArgumentException("Gun cannot be found!");
            }
            if (type == "Terrorist")
            {
                this.players.Add(new Terrorist(username, health, armor, this.guns.FindByName(gunName)));
                return $"Successfully added player {username}.";
               
            }
            else if(type == "CounterTerrorist")
            {
                this.players.Add(new CounterTerrorist(username, health, armor, this.guns.FindByName(gunName)));
                return $"Successfully added player {username}.";
                
            }
            else
            {
                throw new ArgumentException("Invalid player type!");
            }
        }

        public string Report()
        {
            var sortedPlayers = this.players.Models
                .OrderBy(x => x.GetType().Name)
                .ThenByDescending(x => x.Health)
                .ThenBy(x => x.Username);
            var information = new StringBuilder();
            foreach (var player in sortedPlayers)
            {
                information.AppendLine(player.ToString());
            }
            return information.ToString().Trim();
        }

        public string StartGame()
        {
            return this.map.Start(this.players.Models.ToList());
        }
    }
}
