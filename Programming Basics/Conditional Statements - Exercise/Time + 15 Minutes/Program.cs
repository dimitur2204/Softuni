using System;

namespace Time___15_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            if (minutes + 15 > 59)
            {
                minutes = 15 - (60 - minutes);
                hours = hours + 1;
            }
            else
            {
                minutes = minutes + 15;
            }

            if (hours > 23)
            {
                hours = 24 - hours;
            }

            if (minutes < 10)
            {
                Console.WriteLine($"{hours}:0{minutes}");
            }
            else
            {
                Console.WriteLine($"{hours}:{minutes}");
            }
        }
    }
}
