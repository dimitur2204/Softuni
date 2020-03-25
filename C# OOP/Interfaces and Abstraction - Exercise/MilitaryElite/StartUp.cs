using System;
using System.Collections.Generic;
using System.Linq;
using MilitaryElite.Interfaces;
using MilitaryElite.Soldiers.Privates;
using MilitaryElite.Soldiers.Privates.SpecialisedSoldiers;
using MilitaryElite.Soldiers.Spies;

namespace MilitaryElite
{
    public class StartUp
    {
        private static void Main(string[] args)
        {
            _ = new List<Soldier>();
            var command = Console.ReadLine();
            var listPrivates = new List<Private>();
            while (command != "End")
            {
                var tokens = command.Split();
                var id = tokens[1];
                var firstName = tokens[2];
                var lastName = tokens[3];               
                if (tokens[0] == "Private")
                {
                    var salary = decimal.Parse(tokens[4]);
                    var myPrivate = new Private(id,firstName,lastName,salary);
                    listPrivates.Add(myPrivate);
                    Console.WriteLine(myPrivate);
                }
                else if (tokens[0] == "LieutenantGeneral")
                {
                    var salary = decimal.Parse(tokens[4]);
                    var privateIds = tokens
                        .Skip(5)
                        .ToArray();
                    var general = new LieutenantGeneral(id,firstName,lastName,salary);
                    var privates = Parser.ParsePrivates(privateIds, listPrivates);
                    general.Privates = privates;
                    Console.WriteLine(general);
                }
                else if (tokens[0] == "Engineer")
                {
                    var salary = decimal.Parse(tokens[4]);
                    var corp = tokens[5];
                    var repairsInArr = tokens
                        .Skip(6)
                        .ToArray();
                    try
                    {
                        var engineer = new Engineer(id, firstName, lastName, salary, corp)
                        {
                            Repairs = Parser.ParseRepairs(repairsInArr)
                        };
                        Console.WriteLine(engineer);
                    }
                    catch (Exception)
                    {
                        command = Console.ReadLine();
                        continue;
                    }                                     
                }           
                else if (tokens[0] == "Commando")
                {
                    var salary = decimal.Parse(tokens[4]);
                    var corp = tokens[5];
                    var missionsInArr = tokens
                        .Skip(6)
                        .ToArray();
                    try
                    {
                        var commando = new Commando(id, firstName, lastName, salary, corp)
                        {
                            Missions = Parser.ParseMissions(missionsInArr)
                        };
                        Console.WriteLine(commando);
                    }
                    catch (Exception)
                    {
                        command = Console.ReadLine();
                        continue;
                    }                    
                }
                else if (tokens[0] == "Spy")
                {
                    var codeNumber = int.Parse(tokens[4]);
                    var spy = new Spy(id,firstName,lastName,codeNumber);
                    Console.WriteLine(spy);
                }
                command = Console.ReadLine();
            }          
        }
    }
}
