using System;

namespace _01._Spring_Vacation_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysOfTheTrip = int.Parse(Console.ReadLine());
            decimal budget = decimal.Parse(Console.ReadLine());
            int countOfPeople = int.Parse(Console.ReadLine());
            decimal fuelPerKm = decimal.Parse(Console.ReadLine());
            decimal foodExpensesPerPerson = decimal.Parse(Console.ReadLine());
            decimal priceForOneNightPerPerson = decimal.Parse(Console.ReadLine());
            
            if (countOfPeople > 10)
            {
                priceForOneNightPerPerson *= 0.75m;
            }

            decimal currentExpenses = daysOfTheTrip * countOfPeople * (foodExpensesPerPerson + priceForOneNightPerPerson);
            for (int i = 1; i <= daysOfTheTrip; i++)
            {
                decimal travelDistance = decimal.Parse(Console.ReadLine());
                currentExpenses += travelDistance * fuelPerKm;
                if (i % 3 == 0 || i % 5 == 0)
                {
                    currentExpenses *= 1.4m;
                }

                if (i % 7 == 0)
                {
                    currentExpenses -= currentExpenses/countOfPeople;
                }
                
                if (currentExpenses > budget)
                {
                    Console.WriteLine($"Not enough money to continue the trip. You need {(currentExpenses - budget):f2}$ more.");
                    return;
                }             
            }
            Console.WriteLine($"You have reached the destination. You have {(budget - currentExpenses):f2}$ budget left.");                  
        }
    }
}
