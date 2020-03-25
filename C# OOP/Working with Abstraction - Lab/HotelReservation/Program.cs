using System;

namespace HotelReservation
{
    class Program
    {
        static void Main(string[] args)
        {
            //50.25 5 Summer VIP
            //PPD NumD Season Discount
            string[] commands = Console.ReadLine().Split();
            double pricePerDay = double.Parse(commands[0]);
            int days = int.Parse(commands[1]);
            string season = commands[2];
            string discount = "None";
            Discount discount1 = new Discount();
            Season season1 = new Season();
            if (commands.Length > 3)
            {
                discount = commands[3];
            }

            if (season == "Autumn")
            {
                season1 = Season.Autumn;
            }
            else if (season == "Spring")
            {
                season1 = Season.Spring;
            }
            else if (season == "Winter")
            {
                season1 = Season.Winter;
            }
            else if (season == "Summer")
            {
                season1 = Season.Summer;
            }

            if (discount == "None")
            {
                discount1 = Discount.None;
            }
            else if (discount == "SecondVisit")
            {
                discount1 = Discount.SecondVisit;
            }
            else if (discount == "VIP")
            {
                discount1 = Discount.VIP;
            }

            var calculator = new PriceCalculator();
            Console.WriteLine($"{calculator.GetPrice(pricePerDay, days, discount1, season1):f2}");
        }
    }
}