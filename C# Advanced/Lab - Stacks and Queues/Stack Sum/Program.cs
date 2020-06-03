
namespace Stack_Sum
{
    using System;
    using System.Collections;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var numbers = input
                .Split(" ")
                .Select(x => int.Parse(x))
                .ToList();
            string command = Console.ReadLine();
            Stack stackToSum = new Stack();
            foreach (var number in numbers)
            {
                stackToSum.Push(number);
            }
            while (command.ToLower() != "end")
            {
                var tokens = command.Split();
                var currentCommand = tokens[0];
                if (currentCommand.ToLower() == "add")
                {
                    var firstNumber = int.Parse(tokens[1]);
                    var secondNumber = int.Parse(tokens[2]);
                    stackToSum.Push(firstNumber);
                    stackToSum.Push(secondNumber);
                }
                else if (currentCommand.ToLower() == "remove")
                {
                    var count = int.Parse(tokens[1]);
                    if (stackToSum.Count < count)
                    {
                        command = Console.ReadLine();
                        continue;
                    }
                    for (int i = 0; i < count; i++)
                    {
                        stackToSum.Pop();
                    }
                }
                command = Console.ReadLine();
            }
            var sum = 0;
            while (stackToSum.Count >0)
            {
                sum += (int)stackToSum.Pop();
            }
            Console.WriteLine("Sum: " + sum);
        }
    }
}
