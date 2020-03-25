using System;

namespace Cruise_Ship
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfCruise = Console.ReadLine();
            string typeOfCabin = Console.ReadLine();
            int numberOfNights = int.Parse(Console.ReadLine());
            double pricePerNight = 0.0;
            if (typeOfCruise == "Mediterranean")
            {
                if (typeOfCabin == "standard cabin")
                {
                    pricePerNight = 27.50;
                }
                else if (typeOfCabin == "cabin with balcony")
                {
                    pricePerNight = 30.20;
                }
                else if (typeOfCabin == "apartment")
                {
                    pricePerNight = 40.5;
                }
            }
            else if (typeOfCruise == "Adriatic")
            {
                if (typeOfCabin == "standard cabin")
                {
                    pricePerNight = 22.99;
                }
                else if (typeOfCabin == "cabin with balcony")
                {
                    pricePerNight = 25.00;
                }
                else if (typeOfCabin == "apartment")
                {
                    pricePerNight = 34.99;
                }
            }
            else if (typeOfCruise == "Aegean")
            {
                if (typeOfCabin == "standard cabin")
                {
                    pricePerNight = 23.0;
                }
                else if (typeOfCabin == "cabin with balcony")
                {
                    pricePerNight = 26.60;
                }
                else if (typeOfCabin == "apartment")
                {
                    pricePerNight = 39.8;
                }
            }
            double priceForCruise = pricePerNight * numberOfNights * 4;
            if (numberOfNights >= 7)
            {
                priceForCruise = priceForCruise * 0.75;
            }
            Console.WriteLine($"Annie's holiday in the {typeOfCruise} sea costs {(priceForCruise):f2} lv.");
        }
    }
}
