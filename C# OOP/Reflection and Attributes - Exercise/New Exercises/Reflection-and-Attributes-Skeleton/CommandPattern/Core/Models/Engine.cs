
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core.Models
{
    using Contracts;
    public class Engine : IEngine
    {
        public Engine(ICommandInterpreter command)
        {
            this.CommandInterpreter = command;
        }

        public ICommandInterpreter CommandInterpreter { get; }

        public void Run()
        {
            var command = Console.ReadLine();
            while (command != "Exit")
            {
                Console.WriteLine(this.CommandInterpreter.Read(command));
                command = Console.ReadLine();
            }
        }
    }

}
