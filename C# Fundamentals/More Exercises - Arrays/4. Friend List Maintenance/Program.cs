using System;

namespace _4._Friend_List_Maintenance
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string command = Console.ReadLine();
            int countOfBlacklisted = 0;
            int countOfLost = 0;
            while (command != "Report")
            {
                string[] commandSeparated = command
                .Split();
                if (commandSeparated[0] == "Blacklist")
                {
                    bool isFound = false;
                    for (int i = 0; i < names.Length; i++)
                    {
                        if (commandSeparated[1] == names[i])
                        {
                            isFound = true;
                            names[i] = "Blacklisted";
                            countOfBlacklisted++;
                        }
                    }

                    if (!isFound)
                    {
                        Console.WriteLine($"{commandSeparated[1]} was not found.");
                    }
                    else
                    {
                        Console.WriteLine($"{commandSeparated[1]} was blacklisted.");
                    }
                }
                else if (commandSeparated[0] == "Error")
                {
                    int index = int.Parse(commandSeparated[1]);
                    if (!(names[index] == "Lost" || names[index] == "Blacklisted"))
                    {
                        Console.WriteLine($"{names[index]} was lost due to an error.");
                        names[index] = "Lost";
                        countOfLost++;
                    }
                }
                else if (commandSeparated[0] == "Change")
                {
                    int index = int.Parse(commandSeparated[1]);
                    string newName = commandSeparated[2];
                    if (index >= 0 && index < names.Length)
                    {
                        Console.WriteLine($"{names[index]} changed his username to {newName}.");
                        names[index] = newName;
                    }
                }
                command = Console.ReadLine();
            }

            Console.WriteLine($"Blacklisted names: {countOfBlacklisted}");
            Console.WriteLine($"Lost names: {countOfLost}");
            Console.WriteLine(String.Join(" ",names));
        }
    }
}
