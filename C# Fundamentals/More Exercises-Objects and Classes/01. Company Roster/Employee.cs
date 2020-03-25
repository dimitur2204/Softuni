using System;
using System.Collections.Generic;
using System.Text;

namespace _01._Company_Roster
{
    class Employee
    {
        public Employee(string name, double salary)
        {
            this.name = name;
            this.salary = salary;
        }
        public string name { get; set; }
        public double salary { get; set; }
    }
}
