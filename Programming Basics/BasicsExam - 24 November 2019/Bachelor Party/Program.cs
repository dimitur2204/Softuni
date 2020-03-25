using System;

namespace Bachelor_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            int sumForSinger = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            double sumOfMoney = 0;
            int numberOfGuests = 0;
            while (command != "The restaurant is full")
            {
                int numberOfPeopleInGroup = int.Parse(command);
                numberOfGuests = numberOfGuests + numberOfPeopleInGroup;
                if (numberOfPeopleInGroup >= 5)
                {
                    sumOfMoney = sumOfMoney + numberOfPeopleInGroup * 70;
                }
                else
                {
                    sumOfMoney = sumOfMoney + numberOfPeopleInGroup * 100;
                }
                command = Console.ReadLine();
            }
            if (sumOfMoney >= sumForSinger)
            {
                double sumLeft = sumOfMoney - sumForSinger;
                Console.WriteLine($"You have {numberOfGuests} guests and {sumLeft} leva left.");
            }
            else
            {
                Console.WriteLine($"You have {numberOfGuests} guests and {sumOfMoney} leva income, but no singer.");
            }
        }
    }
}
