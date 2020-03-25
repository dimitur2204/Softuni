using System;

namespace Spaceship
{
    class Program
    {
        static void Main(string[] args)
        {
            double shipWidth = double.Parse(Console.ReadLine());
            double shipLength = double.Parse(Console.ReadLine());
            double shipHeight = double.Parse(Console.ReadLine());
            double averageHeight = double.Parse(Console.ReadLine());
            double volumeOfShip = shipHeight * shipLength * shipWidth;
            double volumeForOneRoom = (averageHeight + 0.4) * 2 * 2;
            double austronautsInTheShip = Math.Floor((volumeOfShip / volumeForOneRoom));
            if (austronautsInTheShip<3)
            {
                Console.WriteLine("The spacecraft is too small.");
            }
            else if (austronautsInTheShip > 10)
            {
                Console.WriteLine("The spacecraft is too big.");
            }
            else
            {
                Console.WriteLine($"The spacecraft holds {austronautsInTheShip} astronauts.");
            }

        }
    }
}
