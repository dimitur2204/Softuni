using System;

namespace Golf
{
    class Program
    {
        static void Main(string[] args)
        {
            int recordHits = int.Parse(Console.ReadLine());
            int numberOfHoles = int.Parse(Console.ReadLine());
            int numberOfHits = 0;
            for (int holeNumber = 1; holeNumber <= numberOfHoles; holeNumber++)
            {
                int powerRequired = int.Parse(Console.ReadLine());
                int sumOfPower = 0;
                
                while (powerRequired > sumOfPower)
                {
                    string hit = Console.ReadLine();
                    int sumOfChars = 0;
                    for (int i = 0; i < hit.Length; i++)
                    {
                        sumOfChars = sumOfChars + (int)hit[i];                       
                    }
                    sumOfPower = sumOfPower + (sumOfChars / hit.Length);
                    numberOfHits++;
                }
                Console.WriteLine($"New hole reached! Hits so far: {numberOfHits}");
            }
            if (numberOfHits < recordHits)
            {
                Console.WriteLine($"Yes, you won! Total hits: {numberOfHits}");
            }
            else
            {
                Console.WriteLine($"Better luck next time... Total hits: {numberOfHits}");
            }
        }
    }
}
