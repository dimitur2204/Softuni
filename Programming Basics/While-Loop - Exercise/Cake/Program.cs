using System;

namespace Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int cakeLength = int.Parse(Console.ReadLine());
            int cakeWidth = int.Parse(Console.ReadLine());
            int initialCakeArea = cakeLength * cakeWidth;
            int cakeArea = initialCakeArea;
            int sumOfPieces = 0;
            while(cakeArea >= 0) 
            {
                
                string command = Console.ReadLine();

                if (command == "STOP")
                {
                    Console.WriteLine($"{cakeArea} pieces are left.");
                    break;
                }
                else
                {
                    sumOfPieces += int.Parse(command);
                    cakeArea -= int.Parse(command);
                }
            }

            if(cakeArea <= 0)
            {
                Console.WriteLine($"No more cake left! You need {sumOfPieces - initialCakeArea} pieces more.");
            }
        }
    }
}
