using System;
using System.Numerics;

namespace _3._Biscuits_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int biscuitsPerWorker = int.Parse(Console.ReadLine());
            int numberOfWorkers = int.Parse(Console.ReadLine());
            int biscuitsCompetingFact = int.Parse(Console.ReadLine());
            double biscuitsPerMonth = ((Math.Floor(10*0.75 * biscuitsPerWorker * numberOfWorkers) + (20.0 * biscuitsPerWorker * numberOfWorkers)));
            Console.WriteLine($"You have produced {biscuitsPerMonth} biscuits for the past month.");
            double percentageOfProduction;
            if (biscuitsPerMonth > biscuitsCompetingFact)
            {
                percentageOfProduction = ((biscuitsPerMonth - biscuitsCompetingFact) / biscuitsCompetingFact) * 100.0;
                Console.WriteLine($"You produce {percentageOfProduction:f2} percent more biscuits.");
            }
            else
            {
                
                percentageOfProduction = ((biscuitsCompetingFact - biscuitsPerMonth) / biscuitsCompetingFact) * 100.0;
                Console.WriteLine($"You produce {percentageOfProduction:f2} percent less biscuits.");
            }
        }
    }
}
