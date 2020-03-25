using System;

namespace World_Snooker_Championship
{
    class Program
    {
        static void Main(string[] args)
        {
            string roundOfCompetition = Console.ReadLine();
            string typeOfTicket = Console.ReadLine();
            int numberOfTickets = int.Parse(Console.ReadLine());
            char pictureWithTrophy = char.Parse(Console.ReadLine());
            double sumOfMoney = 0;
            if (roundOfCompetition == "Quarter final")
            {
                if (typeOfTicket == "Standard")
                {
                    sumOfMoney = sumOfMoney + (numberOfTickets * 55.5);
                }
                else if (typeOfTicket == "Premium")
                {
                    sumOfMoney = sumOfMoney + (numberOfTickets * 105.2);
                }
                else if (typeOfTicket == "VIP")
                {
                    sumOfMoney = sumOfMoney + (numberOfTickets * 118.9);
                }
            }
            else if (roundOfCompetition == "Semi final")
            {
                if (typeOfTicket == "Standard")
                {
                    sumOfMoney = sumOfMoney + (numberOfTickets * 75.88);
                }
                else if (typeOfTicket == "Premium")
                {
                    sumOfMoney = sumOfMoney + (numberOfTickets * 125.22);
                }
                else if (typeOfTicket == "VIP")
                {
                    sumOfMoney = sumOfMoney + (numberOfTickets * 300.4);
                }
            }
            else if (roundOfCompetition == "Final")
            {
                if (typeOfTicket == "Standard")
                {
                    sumOfMoney = sumOfMoney + (numberOfTickets * 110.1);
                }
                else if (typeOfTicket == "Premium")
                {
                    sumOfMoney = sumOfMoney + (numberOfTickets * 160.66);
                }
                else if (typeOfTicket == "VIP")
                {
                    sumOfMoney = sumOfMoney + (numberOfTickets * 400);
                }
            }
            if (sumOfMoney > 4000)
            {
                Console.WriteLine($"{(sumOfMoney * 0.75):f2}");
            }
            else if (sumOfMoney > 2500)
            {
                if (pictureWithTrophy == 'Y')
                {
                    
                    Console.WriteLine($"{(sumOfMoney * 0.9 + 40 * numberOfTickets):f2}");
                }
                else
                {
                    Console.WriteLine($"{(sumOfMoney * 0.9):f2}");
                }
            }
            else
            {
                if (pictureWithTrophy == 'Y')
                {
                    sumOfMoney = sumOfMoney + 40 * numberOfTickets;
                    Console.WriteLine($"{sumOfMoney:f2}");
                }
                else
                {
                    Console.WriteLine($"{sumOfMoney:f2}");
                }
            }
        }
    }
}
