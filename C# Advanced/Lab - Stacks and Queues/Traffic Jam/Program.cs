using System;
using System.Collections;

namespace Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            var carsToPass = int.Parse(Console.ReadLine());
            var totalCarsPassed = 0;
            var cars = new Queue();
            var command = Console.ReadLine();
            while (command != "end")
            {
                if (command == "green")
                {
                    if (cars.Count >= carsToPass)
                    {
                        for (int i = 0; i < carsToPass; i++)
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            totalCarsPassed++;
                        }
                    }
                    else
                    {
                        while (cars.Count > 0)
                        {
                            Console.WriteLine($"{cars.Dequeue()} passed!");
                            totalCarsPassed++;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"{totalCarsPassed} cars passed the crossroads.");
        }
    }
}
