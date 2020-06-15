
namespace DefiningClasses
{

    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var family = new Family();
            for (int i = 0; i < n; i++)
            {
                var personInfo = Console.ReadLine().Split();
                var personName = personInfo[0];
                var personAge = int.Parse(personInfo[1]);
                var currentPerson = new Person(personName,personAge);
                family.AddMember(currentPerson);
            }
            var sortedFamily = family.SortAlphabeticalAndFilterAge();
            foreach (var member in sortedFamily)
            {
                Console.WriteLine($"{member.Name} - {member.Age}");
            }
        }
    }
}
