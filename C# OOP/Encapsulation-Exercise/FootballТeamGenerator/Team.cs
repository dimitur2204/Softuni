using System;
using System.Collections.Generic;
using System.Text;

namespace FootballТeamGenerator
{
    class Team
    {
        private string name;
        private List<Player> players = new List<Player>();
        public Team(string name)
        {
            this.Name = name;            
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (ValidateName(value))
                {
                    this.name = value;
                }
            }
        }
        public double GetOverall() 
        {
            double allPlayersOverall = 0;
            if (this.players.Count > 0)
            {
                foreach (var player in this.players)
                {
                    allPlayersOverall += player.Overall;
                }
                return Math.Round(allPlayersOverall / this.players.Count);
            }
            else
            {
                return 0;
            }
        }
        public void RemovePlayer(string player) 
        {
            if (this.players.Exists(x => x.Name == player))
            {
                this.players.Remove(players.Find(x => x.Name == player));
            }
            else
            {
                Console.WriteLine($"Player {player} is not in {this.name} team.");
            }
        }
        public void AddPlayer(Player player) 
        {
            if (this.players.Contains(player))
            {
                Console.WriteLine($"Player {player.Name} is already in {this.name} team.");
            }
            else
            {
                this.players.Add(player);
            }
        }
        private bool ValidateName(string name)
        {
            if (String.IsNullOrEmpty(name) || String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException($"A name should not be empty.");
            }
            return true;
        }
    }
}
