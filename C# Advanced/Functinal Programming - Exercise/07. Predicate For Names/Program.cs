using System;
using System.Linq;

namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int criteria = int.Parse(Console.ReadLine());
            Func<string,bool> predicate = x => x.Length <= criteria;
            Console.ReadLine().Split().Where(predicate).ToList().ForEach(Console.WriteLine);
        }
    }
}
