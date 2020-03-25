using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Teamwork_Projects
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTeams = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();
            for (int i = 0; i < numberOfTeams; i++)
            {
                string[] inputTokens = Console.ReadLine().
                    Split("-", StringSplitOptions.RemoveEmptyEntries);
                string creator = inputTokens[0];
                string name = inputTokens[1];
                Team currentTeam = new Team(creator, name);
                if (TeamExists(currentTeam, teams))
                {
                    Console.WriteLine($"Team {currentTeam.Name} was already created!"); 
                    continue;
                }
                else if (CreatorHasTeam(currentTeam, teams))
                {
                    Console.WriteLine($"{currentTeam.Creator} cannot create another team!");
                    continue;
                }
                else
                {
                    teams.Add(currentTeam);
                    Console.WriteLine($"Team {currentTeam.Name} has been created by {currentTeam.Creator}!");
                }
            }
            string input = Console.ReadLine();
            while (input != "end of assignment")
            {
                string[] inputTokens = input.Split("->", StringSplitOptions.RemoveEmptyEntries);
                string userName = inputTokens[0];
                string teamName = inputTokens[1];
                if (!IsTeamExistant(teamName,teams))
                {
                    Console.WriteLine($"Team {teamName} does not exist!"); 
                }
                else if (IsMemberInTeam(userName, teams))
                {
                    Console.WriteLine($"Member {userName} cannot join team {teamName}!");
                }
                else
                {
                    AddUserToTeam(userName, teamName, teams);
                }
                input = Console.ReadLine();
            }
            List<Team> invalidTeams = new List<Team>();
            List<Team> validTeams = new List<Team>();
            foreach (var team in teams)
            {
                if (IsTeamValid(team))
                {
                    validTeams.Add(team);
                }
                else
                {
                    invalidTeams.Add(team);
                }
            }
            ////"{teamName}:
            //- { creator}
            //-- { member}…"
            foreach (var team in validTeams.OrderByDescending(x => x.Members.Count).ThenBy(x => x.Name))
            {
                Console.WriteLine($"{team.Name}\n- {team.Creator}");
                foreach (var member in team.Members.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {member}");
                }
            }
            Console.WriteLine("Teams to disband:");
            foreach (var team in invalidTeams.OrderBy(x => x.Name))
            {
                Console.WriteLine(team.Name);
            }
        }
        static bool IsTeamValid(Team team) 
        {
            bool isValid = true;
            if (team.Members.Count == 0)
            {
                isValid = false;
            }
            return isValid;
        }
        private static bool IsMemberInTeam(string userName, List<Team> teams)
        {
            bool isMember = false;
            foreach (var team in teams)
            {
                if (team.Members.Contains(userName) || team.Creator == userName)
                {
                    isMember = true;
                    break;
                }
            }
            return isMember;
        }

        static bool IsTeamExistant (string teamName, List<Team> teams) 
        {
            bool isExistanat = false;
            foreach (var team in teams)
            {
                if (team.Name == teamName)
                {
                    isExistanat = true;
                    break;
                }
            }
            return isExistanat;
        }
        static void AddUserToTeam(string userName, string teamName, List<Team> teams) 
        {
            foreach (var team in teams)
            {
                if (team.Name == teamName)
                {
                    team.UserJoin(userName);
                }
            }
        }
        static bool TeamExists(Team currentTeam, List<Team> teams)
        {
            bool hasTeam = false;
            foreach (var team in teams)
            {
                if (currentTeam.Name == team.Name)
                {
                    hasTeam = true;
                    break;
                }
            }
            return hasTeam;
        }
        static bool CreatorHasTeam (Team currentTeam, List<Team> teams) 
        {
            bool hasTeam = false;
            foreach (var team in teams)
            {
                if (currentTeam.Creator == team.Creator)
                {
                    hasTeam = true;
                    break;
                }
            }
            return hasTeam;
        }
    }
}
