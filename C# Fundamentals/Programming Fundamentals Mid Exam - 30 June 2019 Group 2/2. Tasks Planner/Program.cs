using System;
using System.Linq;

namespace _2._Tasks_Planner
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] delimeters = { '{', '}', ' ' };
            int[] taskTimes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            string command = Console.ReadLine();
            while (command!="End")
            {
                string[] commandArr = command.Split();
                if (commandArr[0] == "Complete")
                {
                   taskTimes = Complete(taskTimes, commandArr);
                }
                else if (commandArr[0] == "Change")
                {
                    taskTimes = Change(taskTimes, commandArr);
                }
                else if (commandArr[0] == "Drop")
                {
                    taskTimes = Drop(taskTimes, commandArr);
                }
                else if (commandArr[0] == "Count" && commandArr[1] == "Completed")
                {
                    Completed(taskTimes);
                }
                else if (commandArr[0] == "Count" && commandArr[1] == "Dropped")
                {
                    Dropped(taskTimes);
                }
                else if (commandArr[0] == "Count" && commandArr[1] == "Incomplete")
                {
                    Incomplete(taskTimes);
                }
                command = Console.ReadLine();
            }
            GetIncomplete(taskTimes);
        }

        static int[] Complete(int[] arr, string[] commandSeparated) 
        {
            int index = int.Parse(commandSeparated[1]);
            if (index < 0 || index >= arr.Length)
            {
                return arr;
            }
            else
            {               
                arr[index] = 0;
                return arr;
            }
        }


        static int[] Change(int[] arr, string[] commandSeparated)
        {
            int index = int.Parse(commandSeparated[1]);
            if (index < 0 || index >= arr.Length)
            {
                return arr;
            }
            else
            {
            int newTime = int.Parse(commandSeparated[2]);
            arr[index] = newTime;
            return arr;
            }           
        }

        static int[] Drop(int[] arr, string[] commandSeparated) 
        {
            int index = int.Parse(commandSeparated[1]);
            if (index < 0 || index >= arr.Length)
            {
                return arr;
            }
            else
            {
                arr[index] = -1;
                return arr;
            }

        }

        static void Completed(int[] arr) 
        {
            int count = 0;
            foreach (var item in arr)
            {
                if (item == 0)
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }

        static void Incomplete(int[] arr)
        {
            int count = 0;
            foreach (var item in arr)
            {
                if (item > 0)
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }

        static void Dropped(int[] arr)
        {
            int count = 0;
            foreach (var item in arr)
            {
                if (item <= -1)
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }

        static void GetIncomplete(int[] arr) 
        {
            foreach (var item in arr)
            {
                if (item > 0)
                {
                    //Console.Write("{" + item + "} ");
                    Console.Write(item + " ");
                }
            }

        }
    }
}
