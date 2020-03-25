using System;
using System.Linq;
using System.Text;

namespace _01._Warrior_s_Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder encrypted = new StringBuilder(Console.ReadLine());
            string command = Console.ReadLine();
            while (command != "For Azeroth")
            {
                string[] tokens = command.Split();
                if (tokens[0] == "GladiatorStance")
                {
                    encrypted = new StringBuilder(
                        encrypted
                         .ToString()
                         .ToUpper());
                    Console.WriteLine(encrypted);
                }
                else if (tokens[0] == "DefensiveStance")
                {
                    encrypted = new StringBuilder(
                         encrypted
                            .ToString()
                            .ToLower());
                    Console.WriteLine(encrypted);
                }
                else if (tokens[0] == "Dispel")
                {
                    int index = int.Parse(tokens[1]);
                    if (index >= encrypted.Length || index < 0)
                    {
                        Console.WriteLine("Dispel too weak.");
                        command = Console.ReadLine();
                        continue;
                    }
                    char letter = char.Parse(tokens[2]);
                    encrypted.Insert(index, letter);
                    encrypted.Remove(index + 1, 1);
                    Console.WriteLine("Success!");
                }
                else if (tokens[0] == "Target" && tokens[1] == "Change")
                {
                    string toReplace = tokens[2];
                    string replacement = tokens[3];
                    encrypted.Replace(toReplace, replacement);
                    Console.WriteLine(encrypted);
                }
                else if (tokens[0] == "Target" && tokens[1] == "Remove")
                {
                    string toRemove = tokens[2];
                    encrypted.Replace(toRemove, "");
                    Console.WriteLine(encrypted);
                }
                else
                {
                    Console.WriteLine("Command doesn't exist!");
                }
                command = Console.ReadLine();
            }
        }
    }
}
