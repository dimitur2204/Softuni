using System;
using System.Linq;

namespace LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfField = int.Parse(Console.ReadLine());
            int[] ladyBugIndexes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int[] initialField = new int[0];
            if (sizeOfField >= 0)
            {
                initialField = new int[sizeOfField];
            }

            for (int i = 0; i < ladyBugIndexes.Length; i++)
            {
                if (ladyBugIndexes[i] >= 0)
                {
                    if (ladyBugIndexes[i] < initialField.Length)
                    {
                        initialField[ladyBugIndexes[i]] = 1;
                    }
                }
            }
            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] newCommands = command
                    .Split()
                    .ToArray();
                int ladybugIndex = int.Parse(newCommands[0]);
                string direction = newCommands[1];
                int flyLength = int.Parse(newCommands[2]);
                if (initialField.Length > 0 && ladybugIndex >= 0 && ladybugIndex < initialField.Length && initialField[ladybugIndex] == 1)
                {
                    if (direction == "right")
                    {
                        bool isFlying = false;
                        if ((ladybugIndex + flyLength) >= initialField.Length)
                        {
                            isFlying = true;
                        }
                        while (!isFlying && initialField[ladybugIndex + flyLength] == initialField[ladybugIndex])
                        {
                            flyLength++;
                            if ((ladybugIndex + flyLength) >= initialField.Length)
                            {
                                isFlying = true;
                                break;
                            }
                        }
                        initialField[ladybugIndex] = 0;
                        if (!isFlying)
                        {
                            initialField[ladybugIndex + flyLength] = 1;
                        }
                    }
                    else if(direction == "left")
                    {
                        bool isFlying = false;
                        if ((ladybugIndex - flyLength) < 0)
                        {
                            isFlying = true;
                        }
                        while (!isFlying && initialField[ladybugIndex - flyLength] == initialField[ladybugIndex])
                        {
                            flyLength++;
                            if ((ladybugIndex - flyLength) < 0)
                            {
                                isFlying = true;
                                break;
                            }
                        }
                        initialField[ladybugIndex] = 0;
                        if (!isFlying)
                        {
                            initialField[ladybugIndex - flyLength] = 1;
                        }
                    }
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(String.Join(" ", initialField));
        }
    }
}
