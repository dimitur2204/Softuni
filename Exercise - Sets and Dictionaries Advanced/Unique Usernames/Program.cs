using System;
using System.Collections.Generic;
using System.Linq;
namespace Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfRows = int.Parse(Console.ReadLine());
            var names = new HashSet<string>();
            for (int i = 0; i < numberOfRows; i++)
            {
                var name = Console.ReadLine();
                names.Add(name);
            }
            Console.WriteLine(String.Join("\n",names));
        }
    }
}
