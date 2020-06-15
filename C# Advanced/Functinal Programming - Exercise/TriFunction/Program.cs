using System;
using System.Collections.Generic;
using System.Linq;

namespace TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> checkName = (n, v) => 
            {
                var sum = 0;
                foreach (var symbol in n)
                {
                    sum += symbol;
                }
                if (sum >= v)
                {
                    return true;
                }
                return false;
            };
            int n = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split().ToList();
            Func<List<string>, Func<string, int, bool>, string> func = (l, f) => 
            {
                foreach (var name in l)
                {
                    if (f(name,n))
                    {
                        return name;
                    }
                }
                return null;
            };
            Console.WriteLine(func(names,checkName));
        }
    }
}
