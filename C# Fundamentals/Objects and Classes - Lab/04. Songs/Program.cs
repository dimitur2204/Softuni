using System;
using System.Collections.Generic;

namespace _04._Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<Song> allSongs = new List<Song>();
            for (int i = 0; i < count; i++)
            {
                string[] inputInfo = Console.ReadLine()
                    .Split('_', StringSplitOptions.RemoveEmptyEntries);
                string typeList = inputInfo[0];
                string name = inputInfo[1];
                string time = inputInfo[2];
                Song song = new Song();
                song.TypeList = typeList;
                song.Name = name;
                song.Time = time;
                allSongs.Add(song);
            }
            string typeListWanted = Console.ReadLine();
            if (typeListWanted == "all")
            {
                foreach (var item in allSongs)
                {
                    Console.WriteLine(item.Name);
                }
            }
            else
            {
                foreach (Song song in allSongs)
                {
                    if (song.TypeList == typeListWanted)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }
        }
    }
}
