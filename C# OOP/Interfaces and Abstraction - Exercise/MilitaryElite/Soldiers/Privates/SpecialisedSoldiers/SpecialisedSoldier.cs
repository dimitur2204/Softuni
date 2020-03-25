using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Interfaces;
namespace MilitaryElite.Soldiers.Privates
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string corp;
        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corp) :
    base(id, firstName, lastName, salary)
        {
            this.Corp = corp;
        }
        public string Corp
        {
            get => this.corp;
            private set 
            {
                if (value == "Airforces" || value == "Marines")
                {
                    this.corp = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
    }
}
