using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MilitaryElite.Interfaces;
namespace MilitaryElite.Soldiers.Privates
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary):
            base(id, firstName, lastName,salary)
        {
            this.Privates = new List<Private>();
        }
        public List<Private> Privates { get; set; }
        public override string ToString()
        {
            if (Privates.Count == 0)
            {
                return $"Name: {FirstName} {LastName} Id: {ID} Salary: {Salary:f2}\nPrivates:{String.Join("\n", Privates.Select(x => x.ToString()))}";
            }
            return $"Name: {FirstName} {LastName} Id: {ID} Salary: {Salary:f2}\nPrivates:\n{String.Join("\n", Privates.Select(x => x.ToString()))}";
        }
    }
}
