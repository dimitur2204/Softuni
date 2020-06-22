using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;
        private int capacity;
        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.capacity = capacity;
            this.roster = new List<Player>();
        }
        public string Name { get; private set; }
        public int Count => this.roster.Count;

        public void AddPlayer(Player player)
        {
            if (roster.Count != capacity)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            return roster.Remove(roster.Find(x => x.Name == name));
        }

        public void PromotePlayer(string name)
        {
            if (roster.First(x => x.Name == name).Rank != "Member")
            {
                roster.First(x => x.Name == name).Rank = "Member";
            }
        }
        public void DemotePlayer(string name)
        {
            if (roster.First(x => x.Name == name).Rank != "Trial")
            {
                roster.First(x => x.Name == name).Rank = "Trial";
            }
        }
        public Player[] KickPlayersByClass(string Class)
        {
            var arr = roster.FindAll(x => x.Class == Class).ToArray();
            this.roster.RemoveAll(x => x.Class == Class);
            return arr;
        }

        public string Report()
        {
            var report = new StringBuilder();
            report.AppendLine($"Players in the guild: {this.Name}");
            foreach (var player in this.roster)
            {
                report.AppendLine(player.ToString());
            }
            return report.ToString().Trim();
        }
    }
}
