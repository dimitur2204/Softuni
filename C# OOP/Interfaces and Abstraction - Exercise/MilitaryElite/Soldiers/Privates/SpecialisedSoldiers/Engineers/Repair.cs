using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Soldiers.Privates.SpecialisedSoldiers.Engineers
{
    public class Repair
    {
        public Repair(string partName, int hoursWorked)
        {
            PartName = partName;
            HoursWorked = hoursWorked;
        }

        public string PartName { get; }
        public int HoursWorked { get; }
        public override string ToString()
        {
            return $"Part Name: {PartName} Hours Worked: {HoursWorked}";
        }
    }
}
