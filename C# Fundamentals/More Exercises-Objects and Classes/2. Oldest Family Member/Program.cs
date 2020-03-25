using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Oldest_Family_Member
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Family family1 = new Family();
            for (int i = 0; i < n; i++)
            {
                string[] personProps = Console.ReadLine().Split();
                string name = personProps[0];
                int age = int.Parse(personProps[1]);
                Person currentPerson = new Person(name,age);
                family1.AddMember(currentPerson);
            }
            Person oldestPerson = family1.GetOldestPerson();
            Console.WriteLine(oldestPerson.Name + " " + oldestPerson.Age);
        }
    }
}
