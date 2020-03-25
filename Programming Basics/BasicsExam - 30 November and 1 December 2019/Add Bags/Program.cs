using System;

namespace Add_Bags
{
    class Program
    {
        static void Main(string[] args)
        {
            double tax ;
            double priceOver20kg = double.Parse(Console.ReadLine());
            double kilosOfLuggage = double.Parse(Console.ReadLine());
            int daysToGoing = int.Parse(Console.ReadLine());
            int numberOfLuggages = int.Parse(Console.ReadLine());
            if (kilosOfLuggage < 10)
            {
                tax = priceOver20kg * 0.2;
            }
            else if (kilosOfLuggage >= 10 && kilosOfLuggage <=20)
            {
                tax = priceOver20kg * 0.5;
            }
            else
            {
                tax = priceOver20kg;
            }

            if (daysToGoing > 30)
            {
                tax = tax + 0.1 * tax;
            }
            else if (daysToGoing <= 30 && daysToGoing >= 7)
            {
                tax = tax + 0.15 * tax;
            }
            else
            {
                tax = tax + 0.4 * tax;
            }
            double totalPrice = tax * numberOfLuggages;
            Console.WriteLine($"The total price of bags is: {totalPrice:f2} lv.");
        }
    }
}
