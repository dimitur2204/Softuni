using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2._Oldest_Family_Member
{
    class Family
    {        
        public List<Person> People { get; set; } = new List<Person>();

        public void AddMember(Person person) 
        {
            People.Add(person);
        }
        public Person GetOldestPerson()
        {
            return this.People.OrderByDescending(x => x.Age).First();
        }
    }
}
