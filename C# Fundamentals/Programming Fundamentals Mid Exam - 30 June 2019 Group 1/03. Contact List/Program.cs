using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Contact_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> contacts = Console.ReadLine()
                .Split()
                .ToList();
            string command = Console.ReadLine();
            while (true)
            {
                string[] commandSeparated = command.Split();
                string givenCommand = commandSeparated[0];
                if (givenCommand == "Add")
                {
                    string contact = commandSeparated[1];
                    int index = int.Parse(commandSeparated[2]);
                    if (IsIndexValid(index, contacts))
                    {
                        if (contacts.Contains(contact))
                        {
                            contacts.Insert(index, contact);
                        }
                        else
                        {
                            contacts.Add(contact);
                        }
                    }
                }
                else if (givenCommand == "Remove")
                {
                    int index = int.Parse(commandSeparated[1]);
                    if (IsIndexValid(index, contacts))
                    {
                        contacts.RemoveAt(index);
                    }
                }
                else if (givenCommand == "Export")
                {
                    int startIndex = int.Parse(commandSeparated[1]);
                    int count = int.Parse(commandSeparated[2]);
                    if (IsIndexValid(startIndex, contacts))
                    {
                        if (count >= contacts.Count)
                        {
                            Console.WriteLine(String.Join(" ",contacts.GetRange(startIndex, contacts.Count - startIndex)));
                        }
                        else
                        {
                            Console.WriteLine(String.Join(" ", contacts.GetRange(startIndex, count)));
                        }
                    }
                }
                else if (givenCommand == "Print")
                {
                    if (commandSeparated[1] == "Normal")
                    {
                        Console.WriteLine("Contacts: " + String.Join(" ", contacts));
                        break;
                    }
                    else
                    {
                        contacts.Reverse();
                        Console.WriteLine("Contacts: " + String.Join(" ", contacts));
                        break;
                    }
                }
                command = Console.ReadLine();
            }
        }

        private static bool IsIndexValid(int index, List<string> contacts)
        {
            if (index < 0 || index >= contacts.Count)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
