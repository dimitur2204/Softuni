using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine()); 
            string typeOfGroup = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();
            decimal totalPrice = 0.0m;
            decimal price = 0.0m;
            if (dayOfWeek == "Friday")
            {
                if (typeOfGroup == "Students")
                {
                    totalPrice = numberOfPeople * 8.45m;
                    price = 8.45m;
                }
               else if (typeOfGroup == "Business")
                {
                    totalPrice = numberOfPeople * 10.90m;
                    price = 10.90m;
                }
                else if (typeOfGroup == "Regular")
                {
                    totalPrice = numberOfPeople * 15.0m;
                    price = 15.0m;
                }
            }
            else if (dayOfWeek == "Saturday")
            {
                if (typeOfGroup == "Students")
                {
                    totalPrice = numberOfPeople * 9.80m;
                    price = 9.80m;
                }
                else if (typeOfGroup == "Business")
                {   
                    totalPrice = numberOfPeople * 15.60m;
                    price = 15.60m;
                }
                else if (typeOfGroup == "Regular")
                {
                    totalPrice = numberOfPeople * 20.0m;
                    price = 20.0m;
                }
            }
            else if (dayOfWeek == "Sunday")
            {
                if (typeOfGroup == "Students")
                {
                    totalPrice = numberOfPeople * 10.46m;
                    price = 10.46m;
                }
                else if (typeOfGroup == "Business")
                {
                    totalPrice = numberOfPeople * 16.0m;
                    price = 16.0m;
                }
                else if (typeOfGroup == "Regular")
                {
                    totalPrice = numberOfPeople * 22.50m;
                    price = 22.50m;
                }
            }

            if (numberOfPeople >= 30 && typeOfGroup == "Students")
            {
                totalPrice = totalPrice * 0.85m;
            }
             if (numberOfPeople >= 100 && typeOfGroup == "Business")
            {
                totalPrice = (numberOfPeople - 10) * price;
            }
            if (numberOfPeople >= 10 && numberOfPeople <= 20 && typeOfGroup == "Regular")
            {
                totalPrice = totalPrice * 0.95m;
            }
            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
