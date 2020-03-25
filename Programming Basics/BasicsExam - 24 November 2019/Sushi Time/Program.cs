using System;

namespace Sushi_Time
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfSushi = Console.ReadLine();
            string restaurantName = Console.ReadLine();
            int numberOfPortions = int.Parse(Console.ReadLine());
            char delivery = char.Parse(Console.ReadLine());
            double priceOfSushi = 0;
            if (restaurantName != "Sushi Zone" && restaurantName != "Sushi Time" && restaurantName != "Sushi Bar" && restaurantName != "Asian Pub")
            {
                Console.WriteLine($"{restaurantName} is invalid restaurant!");
            }
            else
            {
                if (restaurantName == "Sushi Zone")
                {
                    if (typeOfSushi == "sashimi")
                    {
                        priceOfSushi = numberOfPortions * 4.99;   
                    }
                    if (typeOfSushi == "maki")
                    {
                        priceOfSushi = numberOfPortions * 5.29;
                    }
                    if (typeOfSushi == "uramaki")
                    {
                        priceOfSushi = numberOfPortions * 5.99;
                    }
                    if (typeOfSushi == "temaki")
                    {
                        priceOfSushi = numberOfPortions * 4.29;
                    }
                }

                if (restaurantName == "Sushi Time")
                {
                    if (typeOfSushi == "sashimi")
                    {
                        priceOfSushi = numberOfPortions * 5.49;
                    }
                    if (typeOfSushi == "maki")
                    {
                        priceOfSushi = numberOfPortions * 4.69;
                    }
                    if (typeOfSushi == "uramaki")
                    {
                        priceOfSushi = numberOfPortions * 4.49;
                    }
                    if (typeOfSushi == "temaki")
                    {
                        priceOfSushi = numberOfPortions * 5.19;
                    }
                }

                if (restaurantName == "Sushi Bar")
                {
                    if (typeOfSushi == "sashimi")
                    {
                        priceOfSushi = numberOfPortions * 5.25;
                    }
                    if (typeOfSushi == "maki")
                    {
                        priceOfSushi = numberOfPortions * 5.55;
                    }
                    if (typeOfSushi == "uramaki")
                    {
                        priceOfSushi = numberOfPortions * 6.25;
                    }
                    if (typeOfSushi == "temaki")
                    {
                        priceOfSushi = numberOfPortions * 4.75;
                    }
                }

                if (restaurantName == "Asian Pub")
                {
                    if (typeOfSushi == "sashimi")
                    {
                        priceOfSushi = numberOfPortions * 4.5;
                    }
                    if (typeOfSushi == "maki")
                    {
                        priceOfSushi = numberOfPortions * 4.8;
                    }
                    if (typeOfSushi == "uramaki")
                    {
                        priceOfSushi = numberOfPortions * 5.5;
                    }
                    if (typeOfSushi == "temaki")
                    {
                        priceOfSushi = numberOfPortions * 5.5;
                    }
                }
                if (delivery == 'Y')
                {
                    priceOfSushi = priceOfSushi + priceOfSushi * 0.2;
                }
                Console.WriteLine($"Total price: {Math.Ceiling(priceOfSushi)} lv.");
            }
        }
    }
}
