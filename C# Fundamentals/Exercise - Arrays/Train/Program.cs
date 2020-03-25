using System;

namespace Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfWagons = int.Parse(Console.ReadLine());
            int[] peopleInWagon = new int[numberOfWagons];
            int sum = 0;
            for (int i = 0; i < peopleInWagon.Length; i++)
            {
                peopleInWagon[i] = int.Parse(Console.ReadLine()); 
            }
            for (int i = 0; i < peopleInWagon.Length; i++)
            {
                sum += peopleInWagon[i];
                Console.Write(peopleInWagon[i] + " ");               
            }
            Console.WriteLine();
            Console.WriteLine(sum);
        }
    }
}
