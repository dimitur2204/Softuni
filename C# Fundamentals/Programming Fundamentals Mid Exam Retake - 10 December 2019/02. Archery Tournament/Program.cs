using System;
using System.Linq;

namespace _02._Archery_Tournament
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine()
                            .Split("|", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();
            string command = Console.ReadLine();
            char[] delimeters = { '@', '}', '{', ' ' };
        
            int sumOfPoints = 0;
            while (command != "Game over")
            {
                string[] commandSeparated = command
                    .Split(delimeters, StringSplitOptions.RemoveEmptyEntries);
                if (commandSeparated[0] == "Shoot")
                {
                    int startingIndex = int.Parse(commandSeparated[2]);
                    int length = int.Parse(commandSeparated[3]);
                    if (startingIndex >= targets.Length || startingIndex < 0)
                    {
                        command = Console.ReadLine();
                        continue;
                    }
                    if (commandSeparated[1] == "Left")
                    {
                        int index = ShootLeft(targets, startingIndex, length);
                        if (targets[index] >= 5)
                        {
                            targets[index] -= 5;
                            sumOfPoints += 5;
                        }
                        else
                        {
                            sumOfPoints += targets[index];
                            targets[index] = 0;
                        }
                    }
                    else if (commandSeparated[1] == "Right")
                    {
                        int index = ShootRight(targets, startingIndex, length);
                        if (targets[index] >= 5)
                        {
                        targets[index] -= 5;
                        sumOfPoints += 5;
                        }
                        else
                        {
                            sumOfPoints += targets[index];
                            targets[index] = 0;
                        }                     
                    }
                }
                else
                {
                    targets = targets
                        .Reverse()
                        .ToArray();
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(String.Join(" - ",targets));
            Console.WriteLine($"Iskren finished the archery tournament with {sumOfPoints} points!");
        }

        static int ShootLeft(int[] targets, int startingIndex, int length) 
        {
            int positionAfterMoving = startingIndex - length;
            if (positionAfterMoving < 0)
            {
                positionAfterMoving = targets.Length + ((startingIndex - length) % targets.Length);
            }
            return positionAfterMoving;
        }

        static int ShootRight(int[] targets, int startingIndex, int length)
        {
            int positionAfterMoving = startingIndex + length;
            if (positionAfterMoving >= targets.Length)
            {
                positionAfterMoving = ((startingIndex + length) % targets.Length);
            }          
            return positionAfterMoving;
        }

    }
}
