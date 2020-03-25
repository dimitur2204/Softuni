using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Order_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Woman> women = new List<Woman>();
            while (input != "End")
            {
                string[] inputSeparated = input.Split();
                string name = inputSeparated[0];
                string ID = inputSeparated[1];
                int age = int.Parse(inputSeparated[2]);
                Woman currentWoman = new Woman(name, ID, age);
                women.Add(currentWoman);
                input = Console.ReadLine();
            }
            women.OrderBy(x => x.Age).ToList().ForEach(x => Console.WriteLine(x));
        }
    }
}
