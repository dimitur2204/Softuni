using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _03StudentSystem
{
    class Parser
    {
        public Command Parse(string command)
        {
            string[] commands = command.Split();

            return new Command
            {
                Name = commands[0],
                Arguments = commands.Skip(1).ToArray()
            };
        }
    }
}
