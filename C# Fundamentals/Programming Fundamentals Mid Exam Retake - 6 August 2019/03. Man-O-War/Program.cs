using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Man_O_War
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pirateShip = Console.ReadLine()
        .Split(">", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToList();
            List<int> enemyShip = Console.ReadLine()
        .Split(">", StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToList();
            int maxHealthCap = int.Parse(Console.ReadLine());
            pirateShip = maxCapTransform(maxHealthCap, pirateShip);
            enemyShip = maxCapTransform(maxHealthCap, enemyShip);
            string command = Console.ReadLine();
            while (command != "Retire")
            {
               string[] commandSeparated = command.Split();
                if (commandSeparated[0] == "Fire")
                {
                    int index = int.Parse(commandSeparated[1]);
                    int damage = int.Parse(commandSeparated[2]);
                    if (isIndexValid(index, enemyShip))
                    {
                        enemyShip[index] -= damage;
                    }

                    if (isSectionBroken(enemyShip))
                    {
                        Console.WriteLine("You won! The enemy ship has sunken.");
                        return;
                    }
                }
                else if (commandSeparated[0] == "Defend")
                {
                    int startIndex = int.Parse(commandSeparated[1]);
                    int endIndex = int.Parse(commandSeparated[2]);
                    int damage = int.Parse(commandSeparated[3]);
                    if (isIndexValid(startIndex, pirateShip) && isIndexValid(endIndex, pirateShip))
                    {
                        pirateShip = Defend(startIndex, endIndex, damage, pirateShip);
                    }

                    if (isSectionBroken(pirateShip))
                    {
                        Console.WriteLine("You lost! The pirate ship has sunken.");
                        return;
                    }
                }
                else if (commandSeparated[0] == "Repair")
                {
                    int index = int.Parse(commandSeparated[1]);
                    int health = int.Parse(commandSeparated[2]);
                    if (isIndexValid(index, pirateShip))
                    {
                        pirateShip[index] += health;
                        pirateShip = maxCapTransform(maxHealthCap, pirateShip);
                    }
                }
                else if (commandSeparated[0] == "Status")
                {
                    Console.WriteLine($"{SectionsToRepair(maxHealthCap, pirateShip)} sections need repair.");
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"Pirate ship status: {pirateShip.Sum()}");
            Console.WriteLine($"Warship status: {enemyShip.Sum()}");
        }
        static int SectionsToRepair(int maxHealthCap, List<int> list) 
        {
            double criticalHealth = maxHealthCap * 0.2;
            int countOfSections = 0;
            foreach (var item in list)
            {
                if (item < criticalHealth)
                {
                    countOfSections++;
                }
            }
            return countOfSections;
        }

        private static List<int> Defend(int startIndex, int endIndex, int damage, List<int> pirateShip)
        {
            for (int i = startIndex; i <= endIndex; i++)
            {
                pirateShip[i] -= damage;
            }
            return pirateShip;
        }

        static bool isSectionBroken(List<int> list) 
        {
            foreach (var item in list)
            {
                if (item <= 0)
                {
                    return true;
                }
            }
            return false;
        }

        static bool isIndexValid(int index, List<int> list) 
        {
            if (index < 0 || index >= list.Count)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        static List<int> maxCapTransform(int maxCap, List<int> list) 
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] > maxCap)
                {
                    list[i] = maxCap;
                }
            }
            return list;
        }
    }
}
