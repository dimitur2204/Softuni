using System;

namespace Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int pokePower = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustion = int.Parse(Console.ReadLine());
            int pokedTargets = 0;
            int newPokePower = pokePower;
            while (newPokePower >=  distance)
            {
                
                newPokePower -= distance;
                pokedTargets++;
                if (newPokePower == 0.5m * pokePower)
                {
                    if (newPokePower >= exhaustion && exhaustion != 0)
                    {
                        newPokePower /= exhaustion;
                        continue;
                    }
                    else
                    {
                        continue;
                    }
                } 
            }
            Console.WriteLine(newPokePower);
            Console.WriteLine(pokedTargets);
        }
    }
}
