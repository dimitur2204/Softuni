using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Interfaces;
namespace MilitaryElite
{
    public class Soldier:ISoldier
    {
        public Soldier(string id, string firstName, string lastName)
        {
            this.ID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public string ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

    }
}
