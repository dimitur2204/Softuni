using System;
using System.Collections.Generic;
using System.Text;

namespace _05._Teamwork_Projects
{
    class Team
    {
        public Team(string creator, string name)
        {
            Creator = creator;
            Name = name;
            Members = new List<string>();
        }
        public string Name { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }
        public int Count() 
        {
            return Members.Count + 1;
        }
        public void UserJoin(string userName) 
        {
            Members.Add(userName);
        }

    }
}
