
namespace CommandPattern.Core.Models
{
    using CommandPattern.Core.Contracts;
    class HelloCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return $"Hello, {args[0]}";
        }
    }
}
