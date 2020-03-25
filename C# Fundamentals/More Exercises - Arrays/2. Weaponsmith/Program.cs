using System;

namespace _2._Weaponsmith
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] weaponName =
                Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries);
            string command = Console.ReadLine();
            while (command != "Done")
            {
                string[] commandSeparated = command
                    .Split();
                if (commandSeparated[0] == "Move")
                {
                    int indexOfCommand = int.Parse(commandSeparated[2]);
                    if (commandSeparated[1] == "Left" && indexOfCommand - 1 >= 0 && indexOfCommand < weaponName.Length)
                    {
                        string temp = weaponName[indexOfCommand];
                        weaponName[indexOfCommand] = weaponName[indexOfCommand - 1];
                        weaponName[indexOfCommand - 1] = temp;
                    }
                    else if (commandSeparated[1] == "Right" && indexOfCommand >= 0 && indexOfCommand + 1 < weaponName.Length)
                    {
                        string temp = weaponName[indexOfCommand];
                        weaponName[indexOfCommand] = weaponName[indexOfCommand + 1];
                        weaponName[indexOfCommand + 1] = temp;
                    }
                }
                else if (commandSeparated[0] == "Check")
                {
                    if (commandSeparated[1] == "Even")
                    {
                        for (int i = 0; i < weaponName.Length; i += 2)
                        {
                            Console.Write(weaponName[i] + " ");
                        }
                        Console.WriteLine();
                    }
                    else if (commandSeparated[1] == "Odd")
                    {
                        for (int i = 1; i < weaponName.Length; i += 2)
                        {
                            Console.Write(weaponName[i] + " ");
                        }
                        Console.WriteLine();
                    }
                }
                command = Console.ReadLine();
            }

            Console.WriteLine($"You crafted {String.Join("", weaponName)}!");
        }
    }
}
