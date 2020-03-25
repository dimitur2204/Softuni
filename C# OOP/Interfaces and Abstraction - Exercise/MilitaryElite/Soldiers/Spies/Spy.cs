using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Interfaces;
namespace MilitaryElite.Soldiers.Spies
{
    public class Spy : Soldier, ISpy
    {
        private string id;
        private string firstName;
        private string lastName;
        private int codeNumber;
        public Spy(string id, string firstName, string lastName, int codeNumber):
            base(id,firstName,lastName)
        {
            this.codeNumber = codeNumber;
        }
        public int CodeNumber => this.codeNumber;
        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Id: {ID}\nCode Number: {CodeNumber}";
        }
    }
}
