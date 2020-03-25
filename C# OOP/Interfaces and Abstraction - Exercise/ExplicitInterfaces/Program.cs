using System;

namespace ExplicitInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine();
            while (command != "End")
            {
                var citizenInfo = command.Split();
                var citizen = new Citizen(citizenInfo[0],citizenInfo[1],int.Parse(citizenInfo[2]));
                IPerson person = citizen;
                Console.WriteLine(person.GetName()); 
                IResident resident = citizen;
                Console.WriteLine(resident.GetName());
                command = Console.ReadLine();
            }
        }
    }
}
