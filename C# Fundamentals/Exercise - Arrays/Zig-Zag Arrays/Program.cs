using System;
using System.Linq;
using System.Text;

namespace Zig_Zag_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());
            int[] firstArr = new int[numberOfInputs];
            int[] secondArr = new int[numberOfInputs];
            for (int i = 0; i < numberOfInputs; i++)
            {
                int[] input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < input.Length - 1; j++)
                {
                    secondArr[i] = input[j]; 
                    firstArr[i] = input[j + 1]; 
                }
            }
            for (int i = 0; i < firstArr.Length; i+=2)
            {
                int temp = firstArr[i];
                firstArr[i] = secondArr[i];
                secondArr[i] = temp;
            }
            Console.WriteLine(String.Join(" ",firstArr));
            Console.WriteLine(String.Join(" ", secondArr));
        }
    }
}
