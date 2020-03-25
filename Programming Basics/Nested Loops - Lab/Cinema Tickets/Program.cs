using System;

namespace Cinema_Tickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string filmName = Console.ReadLine();
            double kidsPercentage;
            double studentsPercentage;
            double standardPercentage;
            double fullPercentage;
            double sumOfKids = 0;
            double sumOfStudents = 0;
            double sumOfStandard = 0;
            int ticketsCounter = 0;
            while (filmName != "Finish")
            {            
                double studentCounter = 0.0;
                double kidsCounter = 0.0;
                double standardCounter = 0.0;
                int numberOfTickets = int.Parse(Console.ReadLine());
                int ticketsLeft = numberOfTickets;
                string typeOfTicket = ""; 
                while (typeOfTicket != "End" && ticketsLeft != 0)
                {
                    typeOfTicket = Console.ReadLine();                   
                    if (typeOfTicket == "standard")
                    {
                        standardCounter++;
                        ticketsLeft--;
                        ticketsCounter++;
                    }
                    else if (typeOfTicket == "kid")
                    {
                        kidsCounter++;
                        ticketsLeft--;
                        ticketsCounter++;
                    }
                    else if (typeOfTicket == "student")
                    {
                        studentCounter++;
                        ticketsLeft--;
                        ticketsCounter++;
                    }                  
                    
                }
                sumOfKids += kidsCounter;
                sumOfStandard += standardCounter;
                sumOfStudents += studentCounter;
                double sumOfPeople = kidsCounter + studentCounter + standardCounter;
                fullPercentage = (sumOfPeople / numberOfTickets) * 100;
                Console.WriteLine($"{filmName} - {fullPercentage:f2}% full.");
                filmName = Console.ReadLine();
            }
                kidsPercentage = (sumOfKids / ticketsCounter) * 100;
                studentsPercentage = (sumOfStudents / ticketsCounter) * 100;
                standardPercentage = (sumOfStandard / ticketsCounter) * 100;
            Console.WriteLine($"Total tickets: {ticketsCounter}");
            Console.WriteLine($"{studentsPercentage:f2}% student tickets.");
            Console.WriteLine($"{standardPercentage:f2}% standard tickets.");
            Console.WriteLine($"{kidsPercentage:f2}% kids tickets.");
        }
    }
}
