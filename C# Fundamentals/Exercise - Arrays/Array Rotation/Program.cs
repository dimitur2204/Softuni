using System;
using System.Linq;

namespace Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int numberOfRotations = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfRotations; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    int temp = arr[arr.Length - j - 1];
                    arr[arr.Length - j - 1] = arr[0];
                    arr[0] = temp;
                }
            }
            Console.WriteLine(String.Join(" ",arr));
        }
    }
}
