using System;

namespace Back_In_30_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputHours = int.Parse(Console.ReadLine());
            int inputMinutes = int.Parse(Console.ReadLine());
            int minutesHalfLater = inputMinutes + 30;
            if (minutesHalfLater >= 60)
            {
                inputHours++;
                minutesHalfLater = minutesHalfLater - 60;
            }

            if (inputHours >= 24)
            {
                inputHours =  inputHours - 24;
            }
            Console.WriteLine($"{inputHours}:{minutesHalfLater:D2}");
        }
    }
}
