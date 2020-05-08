
namespace PeopleDatabase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PeopleDatabase
    {
        private List<Man> people;
        public PeopleDatabase()
        {
            this.people = new List<Man>();
        }  
        public PeopleDatabase(IEnumerable<Man> people)
        {
            this.people = people.ToList();
        }
        public IEnumerable<Man> People => this.people;
        public int Count()
        {
            int count = 0;
            foreach (var item in this.people)
            {
                count++;
            }
            return count;
        }
        public void Add(Man man)
        {
            if (this.people.Any(x => x.Username == man.Username) || this.people.Any(x => x.ID == man.ID))
            {
                throw new InvalidOperationException("Cannot have the same person twice");
            }
            else
            {
                this.people.Add(man);
            }
        }
        public void Remove(Man man)
        {
            if (this.people.Contains(man))
            {
                this.people.Remove(man);
            }
            else
            {
                throw new InvalidOperationException("Person does not exist to remove him");
            }
        }
        public Man FindById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Cannot have a negative id");
            }
            else if(this.people.Any(x => x.ID == id))
            {
                return this.people.Find(x => x.ID == id);
            }
            else
            {
                throw new InvalidOperationException("No such person found");
            }
        }
        public Man FindByUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("Username cannot be null");
            }
            else if (this.people.Any(x => x.Username == username))
            {
                return this.people.Find(x => x.Username == username);
            }
            else
            {
                throw new InvalidOperationException("No such person found");
            }
        }
    }
}
