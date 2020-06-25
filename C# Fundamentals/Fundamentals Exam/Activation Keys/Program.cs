using System;
using System.Text;

namespace Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            var key = new StringBuilder(Console.ReadLine());
            var command = Console.ReadLine();
            while (command != "Generate")
            {
                var commands = command.Split(">>>", StringSplitOptions.RemoveEmptyEntries);
                if (commands[0] == "Contains")
                {
                    var subst = commands[1];
                    if (key.ToString().Contains(subst))
                    {
                        Console.WriteLine($"{key} contains {subst}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (commands[0] == "Flip")
                {
                    var start = int.Parse(commands[2]);
                    var end = int.Parse(commands[3]);
                    var substring = key.ToString().Substring(start, end - start);
                    if (commands[1] == "Upper")
                    {
                        key.Replace(substring, substring.ToUpper());
                    }
                    else
                    {
                        key.Replace(substring, substring.ToLower());
                    }
                    Console.WriteLine(key);
                }
                else if (commands[0] == "Slice")
                {
                    var start = int.Parse(commands[1]);
                    var end = int.Parse(commands[2]);
                    key.Remove(start, end - start);
                    Console.WriteLine(key);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Your activation key is: {key}");
        }
    }
}
