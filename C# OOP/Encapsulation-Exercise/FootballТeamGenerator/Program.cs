using System;
using System.Collections.Generic;

namespace FootballТeamGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine();
            var teams = new List<Team>();
            while (command != "END")
            {
                var commandInfo = command
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);
                var action = commandInfo[0];
                if (action == "Team")
                {
                    var teamName = commandInfo[1];
                    var newTeam = new Team(teamName);
                    teams.Add(newTeam);
                }
                else if (action == "Add")
                {
                    try
                    {
                        var teamToJoin = commandInfo[1];
                        var newPlayer = InitializePlayer(
                            commandInfo[2],
                            double.Parse(commandInfo[3]),
                            double.Parse(commandInfo[4]),
                            double.Parse(commandInfo[5]),
                            double.Parse(commandInfo[6]),
                            double.Parse(commandInfo[7]));
                        if (IsTeamPresentByName(teams, teamToJoin))
                        {
                            teams
                                .Find(x => x.Name == teamToJoin)
                                .AddPlayer(newPlayer);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (action == "Remove")
                {
                    try
                    {
                        var teamToLeave = commandInfo[1];
                        var playerName = commandInfo[2];
                        if (IsTeamPresentByName(teams, teamToLeave))
                        {
                            teams
                                .Find(x => x.Name == teamToLeave)
                                .RemovePlayer(playerName);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (action == "Rating")
                {
                    var teamName = commandInfo[1];
                    if (IsTeamPresentByName(teams, teamName))
                    {
                        Console.WriteLine($"{teamName} - {teams.Find(x => x.Name == teamName).GetOverall()}");
                    }
                }
                command = Console.ReadLine();
            }

        }
        static Player InitializePlayer(string name, double endurance, double sprint, double dribble, double passing, double shooting)
        {
            var newPlayer = new Player(
                name,
                endurance,
                sprint,
                dribble,
                passing,
                shooting);
            return newPlayer;
        }
        static bool IsTeamPresentByName(List<Team> teams, string teamName)
        {
            if (teams.Exists(x => x.Name == teamName))
            {
                return true;
            }
            else
            {
                Console.WriteLine($"Team {teamName} does not exist.");
                return false;
            }
        }
    }
}
