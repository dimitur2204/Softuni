using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Player
    {
        public Player(string name, string Class)
        {
            this.Name = name;
            this.Class = Class;
            this.Rank = "Trial";
            this.Description = "n/a";
        }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Rank { get; set; }
        public string Description { get; set; }
        public override string ToString()
        {
            var report = new StringBuilder();
            report.AppendLine($"Player {Name}: {Class}");
            report.AppendLine($"Rank: {Rank}");
            report.AppendLine($"Description: {Description}");
            return report.ToString().Trim();
        }
    }
}
