using System;
using System.Collections.Generic;
using System.Linq;

namespace Dating_App
{
    class Program
    {
        static void Main(string[] args)
        {
            var males = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            var females = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            var matchesCount = 0;
            while (true)
            {
                if (!males.Any() || !females.Any())
                {
                    break;
                }
                var maleValue = males.Peek();
                 var femaleValue = females.Peek();
                while (maleValue <= 0 && males.Any())
                {
                    males.Pop();
                    if (males.Any())
                    {
                        maleValue = males.Peek();
                    }
                }
                if (!males.Any() || !females.Any())
                {
                    break;
                }
                while (femaleValue <= 0 && females.Any())
                {
                    females.Dequeue();
                    if (females.Any())
                    {
                        femaleValue = females.Peek();
                    }
                }
                if (!males.Any() || !females.Any())
                {
                    break;
                }
                maleValue = males.Peek();
                femaleValue = females.Peek();
                while (femaleValue % 25 == 0 && females.Any())
                {
                    females.Dequeue();
                    if (females.Any())
                    {
                        females.Dequeue();
                    }
                }
                if (!males.Any() || !females.Any())
                {
                    break;
                }
                while (maleValue % 25 == 0 && males.Any())
                {
                    males.Pop();
                    if (males.Any())
                    {
                        males.Pop();
                    }
                }
                if (!males.Any() || !females.Any())
                {
                    break;
                }
                maleValue = males.Peek();
                femaleValue = females.Peek();
                if (maleValue == femaleValue)
                {
                    males.Pop();
                    females.Dequeue();
                    matchesCount++;
                }
                else
                {
                    females.Dequeue();
                    males.Push(males.Pop() - 2);
                }
            }

            Console.WriteLine($"Matches: {matchesCount}");
            if (males.Any())
            {
                Console.WriteLine($"Males left: {String.Join(", ",males)}");
            }
            else
            {
                Console.WriteLine("Males left: none");
            }
            if (females.Any())
            {
                Console.WriteLine($"Females left: {String.Join(", ", females)}");
            }
            else
            {
                Console.WriteLine("Females left: none");
            }
        }
    }
}
