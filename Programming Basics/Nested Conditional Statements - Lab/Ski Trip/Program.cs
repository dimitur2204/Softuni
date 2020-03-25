using System;

namespace Ski_Trip
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string typeOfRoom = Console.ReadLine();
            string evalutaion = Console.ReadLine();
            double price = 0.0;
            
            if(typeOfRoom == "room for one person") 
            {
                price = (days - 1) * 18.00;
            }
            else if (typeOfRoom == "apartment")
            {
                if (days <= 10)
                {
                    price = 0.7 * (25.00 * (days - 1));
                    
                }
                else if (days > 10 && days <= 15)
                {
                    price = 0.65 * (25.00 * (days - 1));
                    
                }
                else if (days > 15)
                {
                    price = 0.5 * (25.00 * (days - 1));
                    
                }
            }
            else if (typeOfRoom == "president apartment")
            {
                if (days <= 10)
                {
                    price = 0.9 * (35.00 * (days - 1));
                    
                }
                else if (days > 10 && days <= 15)
                {
                    price = 0.85 * (35.00 * (days - 1));
                    
                }
                else if (days > 15)
                {
                    price = 0.8 * (35.00 * (days - 1));
                    
                }
            }

            if (evalutaion == "positive")
            {
                Console.WriteLine($"{(price + price * 0.25):f2}"); 
            }
            else
            {
                Console.WriteLine($"{(price - price * 0.1):f2}");
            }
        }
    }
}
