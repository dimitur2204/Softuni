using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Soldiers.Privates.SpecialisedSoldiers.Commandos
{
    public class Mission
    {
        private string codeName;
        private string state;
        public Mission(string codeName, string state)
        {
            this.codeName = codeName;
            this.State = state;
        }
        public string CodeName => this.codeName;
        public string State 
        {
            get => this.state;
            private set 
            {
                if (value == "inProgress" || value == "Finished")
                {
                    this.state = value;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
        }
        public void CompleteMission() 
        {
            this.state = "Finished";
        }
        public override string ToString()
        {
            return $"Code Name: {codeName} State: {state}";
        }
    }
}
