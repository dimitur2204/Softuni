using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUni_Course_Planning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> schedule = Console.ReadLine()
        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
        .ToList();
            string command = Console.ReadLine();
            while (command != "course start")
            {
                string[] commandSeparated = command.Split(":", StringSplitOptions.RemoveEmptyEntries);
                if (commandSeparated[0] == "Add" && !schedule.Contains(commandSeparated[1]))
                {
                    schedule.Add(commandSeparated[1]);
                }
                else if (commandSeparated[0] == "Insert" && !schedule.Contains(commandSeparated[1]))
                {
                    schedule.Insert(int.Parse(commandSeparated[2]), commandSeparated[1]);
                }
                else if (commandSeparated[0] == "Remove" && schedule.Contains(commandSeparated[1]))
                {
                    if (HasExercise(commandSeparated[1], schedule))
                    {
                    schedule.Remove(commandSeparated[1]);
                    schedule.Remove(commandSeparated[1] + "-" + "Exercise");
                    }
                    else
                    {
                        schedule.Remove(commandSeparated[1]);
                    }
                }
                else if (commandSeparated[0] == "Swap" && schedule.Contains(commandSeparated[1]) && schedule.Contains(commandSeparated[2]))
                {
                    if (HasExercise(commandSeparated[1], schedule) && HasExercise(commandSeparated[2], schedule))
                    {
                        schedule = Swap(commandSeparated[1], commandSeparated[2], schedule);
                        schedule = Swap(commandSeparated[1] + "-" + "Exercise", commandSeparated[2] + "-" + "Exercise", schedule);
                    }
                    else if (HasExercise(commandSeparated[1], schedule))
                    {
                        schedule = Swap(commandSeparated[1], commandSeparated[2], schedule);
                        schedule.Remove(commandSeparated[1] + "-" + "Exercise");
                        schedule.Insert(schedule.IndexOf(commandSeparated[1]) + 1, commandSeparated[1] + "-" + "Exercise");
                        
                    }
                    else if (HasExercise(commandSeparated[2], schedule))
                    {
                        schedule = Swap(commandSeparated[1], commandSeparated[2], schedule);
                        schedule.Remove(commandSeparated[2] + "-" + "Exercise");
                        schedule.Insert(schedule.IndexOf(commandSeparated[2]) + 1, commandSeparated[2] + "-" + "Exercise");
                    }
                    else
                    {
                        schedule = Swap(commandSeparated[1], commandSeparated[2], schedule);
                    }
                    
                }
                else if (commandSeparated[0] == "Exercise")
                {
                    if (schedule.Contains(commandSeparated[1]))
                    {
                        if (!HasExercise(commandSeparated[1], schedule))
                        {
                            schedule.Insert(schedule.IndexOf(commandSeparated[1]) + 1, commandSeparated[1] + "-" + "Exercise");
                        }
                    }
                    else
                    {
                        schedule.Add(commandSeparated[1]);
                        schedule.Add(commandSeparated[1] + "-" + "Exercise");
                    }
                }
                command = Console.ReadLine();
            }
            int i = 1;
            foreach (var item in schedule)
            {              
                Console.WriteLine($"{i++}.{item}");
            }
        }

        static bool HasExercise(string v1, List<string> schedule) 
        {
            if (schedule.IndexOf(v1) == schedule.Count - 1)
            {
                return false;
            }

            if (schedule[schedule.IndexOf(v1) + 1] == (v1 + "-" + "Exercise"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static List<string> Swap(string v1, string v2, List<string> schedule)
        {
            int index1 = schedule.IndexOf(v1);
            int index2 = schedule.IndexOf(v2);
            string temp = schedule[index1];
            schedule[index1] = schedule[index2];
            schedule[index2] = temp;
            return schedule;
        }
    }
}
