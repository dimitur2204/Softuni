using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            this.Name = name;
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (!Person.ValidateName(value))
                {
                    throw new ArgumentException("Team name cannot be less than 3 symbols");
                }
                this.name = value;
            }
        }
        public IReadOnlyCollection<Person> FirstTeam
        {
            get => this.firstTeam.AsReadOnly();
        }
        public IReadOnlyCollection<Person> ReserveTeam
        {
            get => this.reserveTeam.AsReadOnly();
        }
        public void AddPlayer(Person player) 
        {
            if (player.Age > 40)
            {
                this.reserveTeam.Add(player);
            }
            else
            {
                this.firstTeam.Add(player);
            }
        }
    }
}
