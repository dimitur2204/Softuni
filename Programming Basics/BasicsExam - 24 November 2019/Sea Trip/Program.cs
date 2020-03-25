using System;

namespace Sea_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            double distanceToSea = 210;
            int tripLength = 3;
            double moneyForBenzin = (420 / 100.0 * 7) * 1.85;
            double moneyForFood = double.Parse(Console.ReadLine());
            double moneyForSouvenirs = double.Parse(Console.ReadLine());
            double moneyForHotel = double.Parse(Console.ReadLine());
            double moneyDay1 = moneyForFood + moneyForSouvenirs + 0.9 * moneyForHotel;
            double moneyDay2 = moneyForFood + moneyForSouvenirs + 0.85 * moneyForHotel;
            double moneyDay3 = moneyForFood + moneyForSouvenirs + 0.8 * moneyForHotel;
            double totalMoney = moneyDay1 + moneyDay2 + moneyDay3 + moneyForBenzin;
            Console.WriteLine($"Money needed: {totalMoney:F2}");

        }
    }
}
