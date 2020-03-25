using System;

namespace Public_Transport
{
    class Program
    {
        static void Main(string[] args)
        {
            string lineChosen = Console.ReadLine();
            string season = Console.ReadLine();
            double time = 0.0;
            if (season == "Winter")
            {
                if (lineChosen == "208")
                {
                    time = 65;
                }
                else if (lineChosen == "15")
                {
                    time = 57;
                }
                else if (lineChosen == "240")
                {
                    time = 48;
                }
                else if (lineChosen == "Subway")
                {
                    time = 35;
                }
            }
            else if (season == "Autumn")
            {
                if (lineChosen == "208")
                {
                    time = 45;
                }
                else if (lineChosen == "15")
                {
                    time = 42;
                }
                else if (lineChosen == "240")
                {
                    time = 37;
                }
                else if (lineChosen == "Subway")
                {
                    time = 35;
                }
            }
            else if (season == "Spring")
            {
                if (lineChosen == "208")
                {
                    time = 39;
                }
                else if (lineChosen == "15")
                {
                    time = 36;
                }
                else if (lineChosen == "240")
                {
                    time = 31;
                }
                else if (lineChosen == "Subway")
                {
                    time = 35;
                }
            }
            else if (season == "Summer")
            {
                Console.WriteLine("No lectures! It's summer!");
                return;
            }
            if (lineChosen == "15" || lineChosen == "Subway")
            {
                time = time + 21;
            }
            else
            {
                time = time + 18;      
            }
            Console.WriteLine($"Total travel time: {time} minutes");
        }
    }
}
