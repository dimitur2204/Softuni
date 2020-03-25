using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MilitaryElite.Soldiers.Privates.SpecialisedSoldiers.Engineers;
namespace MilitaryElite.Soldiers.Privates.SpecialisedSoldiers
{
    public class Engineer:SpecialisedSoldier
    {
        public Engineer(string id, string firstName, string lastName, decimal salary, string corp) :
    base(id, firstName, lastName, salary, corp)
        {
            this.Repairs = new List<Repair>();
        }
        public List<Repair> Repairs { get; set; }
        public override string ToString()
        {
            if (Repairs.Count == 0)
            {
                return $"Name: {FirstName} {LastName} Id: {ID} Salary: {Salary:f2}\nCorps: {Corp}\nRepairs:{String.Join("\n", Repairs.Select(x => x.ToString()))}";
            }
            return $"Name: {FirstName} {LastName} Id: {ID} Salary: {Salary:f2}\nCorps: {Corp}\nRepairs:\n{String.Join("\n", Repairs.Select(x => x.ToString()))}";
        }
    }
}
