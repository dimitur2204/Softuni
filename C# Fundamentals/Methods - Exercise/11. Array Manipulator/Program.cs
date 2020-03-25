using System;
using System.Linq;

namespace _11._Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] initialArr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            string command = Console.ReadLine();
            while (command != "end")
            {
                string[] commandSeparated = command
                    .Split()
                    .ToArray();
                if (commandSeparated[0] == "exchange")
                {
                    int index = int.Parse(commandSeparated[1]);
                    if (index < 0 || index >= initialArr.Length)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        initialArr = Exchange(initialArr, index);
                    }
                }
                else if (commandSeparated[0] == "max")
                {
                    if (commandSeparated[1] == "even")
                    {
                        if (!AreThereEven(initialArr))
                        {
                            Console.WriteLine("No matches");
                        }
                        else
                        {
                            Console.WriteLine(MaxEvenIndex(initialArr));
                        }
                    }
                    else if (commandSeparated[1] == "odd")
                    {
                        if (!AreThereOdd(initialArr))
                        {
                            Console.WriteLine("No matches");
                        }
                        else
                        {
                            Console.WriteLine(MaxOddIndex(initialArr));
                        }
                    }
                }
                else if (commandSeparated[0] == "min")
                {
                    if (commandSeparated[1] == "even")
                    {
                        if (!AreThereEven(initialArr))
                        {
                            Console.WriteLine("No matches");
                        }
                        else
                        {
                            Console.WriteLine(MinEvenIndex(initialArr));
                        }
                    }
                    else if (commandSeparated[1] == "odd")
                    {
                        if (!AreThereOdd(initialArr))
                        {
                            Console.WriteLine("No matches");
                        }
                        else
                        {
                            Console.WriteLine(MinOddIndex(initialArr));
                        }
                    }
                }
                else if (commandSeparated[0] == "first")
                {
                    int index = int.Parse(commandSeparated[1]);
                    if (index > initialArr.Length || index <= 0)
                    {
                        Console.WriteLine("Invalid count");
                    }
                    else if (commandSeparated[2] == "even")
                    {
                        FirstCountEven(initialArr, index);
                    }
                    else if (commandSeparated[2] == "odd")
                    {
                        FirstCountOdd(initialArr, index);
                    }
                }
                else if (commandSeparated[0] == "last")
                {
                    int index = int.Parse(commandSeparated[1]);
                    if (index > initialArr.Length || index <= 0)
                    {
                        Console.WriteLine("Invalid count");
                    }
                    else if (commandSeparated[2] == "even")
                    {
                        LastCountEven(initialArr, index);
                    }
                    else if (commandSeparated[2] == "odd")
                    {
                        LastCountOdd(initialArr, index);
                    }
                }
                command = Console.ReadLine();
            }

            Console.WriteLine($"[{String.Join(", ", initialArr)}]");
        }

        public static bool AreThereOdd(int[] array)
        {
            bool ThereAre = false;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    ThereAre = true;
                }
            }
            return ThereAre;
        }
        public static bool AreThereEven(int[] array)
        {
            bool ThereAre = false;
            for (int i = 0; i < array.Length; i ++)
            {
                if (array[i] % 2 == 0 )
                {
                    ThereAre = true;
                }
            }
            return ThereAre;
        }
        public static int[] Exchange(int[] array, int index)
        {
            int[] firstArr = array.Take(index + 1).ToArray();
            int[] secondArr = array.TakeLast(array.Length - index - 1).ToArray();
            int[] exchangedArr = secondArr.Concat(firstArr).ToArray();
            return exchangedArr;
        }


        public static int MinOddIndex(int[] array)
        {
            int maxOddIndex = 0;
            int maxOddValue = int.MaxValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] <= maxOddValue && array[i] % 2 != 0)
                {
                    maxOddIndex = i;
                    maxOddValue = array[i];
                }
            }
            return maxOddIndex;
        }


        public static int MaxOddIndex(int[] array)
        {
            int maxOddIndex = 0;
            int maxOddValue = int.MinValue;
            for (int i = 0; i < array.Length; i ++)
            {
                if (array[i] >= maxOddValue && array[i] % 2 != 0)
                {
                    maxOddIndex = i;
                    maxOddValue = array[i];
                }
            }
            return maxOddIndex;
        }

        public static int MaxEvenIndex(int[] array)
        {
            int maxOddIndex = 0;
            int maxOddValue = int.MinValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] >= maxOddValue && array[i] % 2 == 0)
                {
                    maxOddIndex = i;
                    maxOddValue = array[i];
                }
            }
            return maxOddIndex;
        }

        public static int MinEvenIndex(int[] array)
        {
            int maxOddIndex = 0;
            int maxOddValue = int.MaxValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] <= maxOddValue && array[i] % 2 == 0)
                {
                    maxOddIndex = i;
                    maxOddValue = array[i];
                }
            }
            return maxOddIndex;
        }

        public static void FirstCountEven(int[] array, int countOfEvens)
        {
            int count = 0;
            string evens = "";
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    evens += array[i] + " ";
                    count++;
                }
                if (count == countOfEvens)
                {
                    break;
                }
            }
            int[] numbers = evens
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Console.Write($"[{String.Join(", ", numbers)}]");
            Console.WriteLine();
        }

        public static void FirstCountOdd(int[] array, int countOfEvens)
        {
            int count = 0;
            string evens = "";
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    evens += array[i] + " ";
                    count++;
                }
                if (count == countOfEvens)
                {
                    break;
                }
            }
            int[] numbers = evens
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Console.Write($"[{String.Join(", ", numbers)}]");
            Console.WriteLine();
        }

        public static void LastCountEven(int[] array, int countOfEvens)
        {
            int count = 0;
            string evens = "";
            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] % 2 == 0)
                {
                    evens += array[i] + " ";
                    count++;
                }
                if (count == countOfEvens)
                {
                    break;
                }
            }
            int[] numbers = evens
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Console.Write($"[{String.Join(", ", numbers.Reverse())}]");
            Console.WriteLine();
        }

        public static void LastCountOdd(int[] array, int countOfEvens)
        {
            int count = 0;
            string evens = "";
            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] % 2 != 0)
                {
                    evens += array[i] + " ";
                    count++;
                }
                if (count == countOfEvens)
                {
                    break;
                }
            }
            int[] numbers = evens
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Console.Write($"[{String.Join(", ", numbers.Reverse())}]");
            Console.WriteLine();
        }
    }
}
