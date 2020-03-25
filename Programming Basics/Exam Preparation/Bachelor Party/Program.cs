using System;

namespace Bachelor_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            double sumForPerformer = double.Parse(Console.ReadLine());
            string command = Console.ReadLine();
            double sumOfMoney = 0;
            int numberOfGuests = 0; 
            while (command != "The restaurant is full")
            {
                int groupOfPeople = int.Parse(command);
                numberOfGuests = numberOfGuests + groupOfPeople;
                if (groupOfPeople >= 5)
                {
                     sumOfMoney = sumOfMoney + groupOfPeople * 70;
                }
                else
                {
                    sumOfMoney = sumOfMoney + groupOfPeople * 100;
                }
                command = Console.ReadLine();
            }
            if (sumOfMoney >= sumForPerformer)
            {
                Console.WriteLine($"You have {numberOfGuests} guests and {(sumOfMoney - sumForPerformer)} leva left.");
            }
            else
            {
                Console.WriteLine($"You have {numberOfGuests} guests and {sumOfMoney} leva income, but no singer.");
            }
        }
    }
}
