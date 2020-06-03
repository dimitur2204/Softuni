using System;
using System.Collections.Generic;
using System.Linq;

namespace Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var songs = new Queue<string>(Console.ReadLine().Split(", "));
            var commands = Console.ReadLine().Split();
            while (songs.Count > 0)
            {
                var command = commands[0];
                if (command == "Play")
                {
                    songs.Dequeue();
                }
                if (command == "Add")
                {
                    var songName = String.Join(" ",commands.Skip(1));
                    if (songs.Contains(songName))
                    {
                        Console.WriteLine($"{songName} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(songName);
                    }
                }
                if (command == "Show")
                {
                    Console.WriteLine(String.Join(", ",songs));
                }
                commands = Console.ReadLine().Split();
            }
            Console.WriteLine("No more songs!");
        }
    }
}
