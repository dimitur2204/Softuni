using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MilitaryElite.Soldiers.Privates.SpecialisedSoldiers.Commandos;
namespace MilitaryElite.Soldiers.Privates.SpecialisedSoldiers
{
    public class Commando:SpecialisedSoldier
    {

        public Commando(string id, string firstName, string lastName, decimal salary, string corp) :
    base(id, firstName, lastName, salary, corp)
        {
            this.Missions = new List<Mission>();
        }
        public List<Mission> Missions { get; set; }
        public override string ToString()
        {
            if (Missions.Count == 0)
            {
                return $"Name: {FirstName} {LastName} Id: {ID} Salary: {Salary:f2}\nCorps: {Corp}\nMissions:{String.Join("\n", Missions.Select(x => x.ToString()))}";
            }
            return $"Name: {FirstName} {LastName} Id: {ID} Salary: {Salary:f2}\nCorps: {Corp}\nMissions:\n{String.Join("\n", Missions.Select(x=>x.ToString()))}";
        }
    }
}
