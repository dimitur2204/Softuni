
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core.Models
{
    using CommandPattern.Core.Contracts;
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string command)
        {
            var tokens = command.Split();
            var commandName = tokens[0];
            var commandArgs = tokens.Skip(1);
            var commandType = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(x => x.Name == commandName + "Command");
            if (commandType == null)
            {
                return "Command does not exist";
            }
            var commandInstance = Activator.CreateInstance(commandType);
            var output = (string)commandType.GetMethod("Execute").Invoke(commandInstance, new[] {commandArgs.ToArray()});
            return output;
        }
    }
}
