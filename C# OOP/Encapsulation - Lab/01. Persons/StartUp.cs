using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());
            var persons = new List<Person>();
            var team = new Team("whaddup");
            var player1 = new Person("Pesho","Peshov" ,29, 700);
            var player2 = new Person("Gosho", "Goshov", 55, 700);
            team.AddPlayer(player1);
            team.AddPlayer(player2);
            foreach (var player in team.FirstTeam)
            {
                Console.WriteLine(player.FirstName);
            }
            foreach (var player in team.ReserveTeam)
            {
                Console.WriteLine(player.FirstName);
            }
                       
            //for (int i = 0; i < lines; i++)
            //{
            //    var cmdArgs = Console.ReadLine().Split();
            //    var person = new Person(cmdArgs[0],
            //                            cmdArgs[1],
            //                            int.Parse(cmdArgs[2]),
            //                            decimal.Parse(cmdArgs[3]));

            //    persons.Add(person);
            //}
            //var parcentage = decimal.Parse(Console.ReadLine());
            //persons.ForEach(p => p.IncreaseSalary(parcentage));
            //persons.ForEach(p => Console.WriteLine(p.ToString()));

        }
    }
}
