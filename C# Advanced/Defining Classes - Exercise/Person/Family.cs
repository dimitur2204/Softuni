
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;
        public Family()
        {
            this.people = new List<Person>();
        }
        public void AddMember(Person person) 
        {
            people.Add(person);
        }
        public Person GetOldestMember() 
        {
            return people.OrderByDescending(p => p.Age).ToList()[0];
        }
        public IEnumerable<Person> SortAlphabeticalAndFilterAge() 
        {
            return people.OrderBy(p => p.Name).Where(p => p.Age > 30);
        }
    }
}
