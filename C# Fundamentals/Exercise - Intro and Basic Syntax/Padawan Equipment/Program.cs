using System;

namespace Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal amountOfMoney = decimal.Parse(Console.ReadLine());
            int countOfStudents = int.Parse(Console.ReadLine());
            decimal priceOfLightsabers = decimal.Parse(Console.ReadLine()); 
            decimal priceOfRobes = decimal.Parse(Console.ReadLine());
            decimal priceOfBelts = decimal.Parse(Console.ReadLine());
            decimal sumOfLightsabers = (Math.Ceiling(countOfStudents * 1.1m)) * priceOfLightsabers;
            decimal sumOfRobes = priceOfRobes * countOfStudents;
            decimal sumOfBelts = (countOfStudents - countOfStudents / 6) * priceOfBelts;
            decimal sumOfAll = sumOfLightsabers + sumOfBelts + sumOfRobes;
            if (sumOfAll <= amountOfMoney)
            {
                Console.WriteLine($"The money is enough - it would cost {sumOfAll:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {(sumOfAll - amountOfMoney):f2}lv more.");
            }
        }
    }
}
