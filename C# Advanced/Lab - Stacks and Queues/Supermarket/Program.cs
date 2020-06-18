﻿using System;
using System.Collections;

namespace Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine();
            var people = new Queue();
            while (command != "End")
            {
                if (command == "Paid")
                {
                    while (people.Count > 0)
                    {
                        Console.WriteLine(people.Dequeue());
                    }
                }
                else
                {
                    people.Enqueue(command);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"{people.Count} people remaining.");
        }
    }
}