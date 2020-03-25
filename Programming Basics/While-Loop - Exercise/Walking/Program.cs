using System;

namespace Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int stepsWalked = 0;

            while (stepsWalked < 10000)
            {
                string commandOrSteps = Console.ReadLine();
                
                if (commandOrSteps == "Going home")
                {
                    int stepsToHome = int.Parse(Console.ReadLine());
                    stepsWalked += stepsToHome;
                    break;
                }
                else
                {
                    stepsWalked += int.Parse(commandOrSteps);
                }
            }

            if (stepsWalked >= 10000) 
            {
                Console.WriteLine("Goal reached! Good job!");
            }
            else
            {
                Console.WriteLine($"{10000 - stepsWalked} more steps to reach goal.");            
            }
        }
    }
}
