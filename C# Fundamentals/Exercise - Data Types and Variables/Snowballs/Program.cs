using System;
using System.Numerics;

namespace Snowballs
{
    class Program
    {
        static BigInteger IntPow(BigInteger x, BigInteger pow)
        {
            BigInteger ret = 1;
            while (pow != 0)
            {
                if ((pow & 1) == 1)
                    ret *= x;
                x *= x;
                pow >>= 1;
            }
            return ret;
        }
        static void Main(string[] args)
        {
            BigInteger numberOfSnowballs = int.Parse(Console.ReadLine());
            BigInteger maxSnowballValue = 0;
            BigInteger maxSnowballSnow = 0;
            BigInteger maxSnowballTime = 1;
            BigInteger maxSnowballQuality = 0;
            for (int i = 0; i < numberOfSnowballs; i++)
            {
                BigInteger snowballSnow = int.Parse(Console.ReadLine());
                BigInteger snowballTime = int.Parse(Console.ReadLine());
                BigInteger snowballQuality = int.Parse(Console.ReadLine());
                BigInteger snowballDelenie = (snowballSnow / snowballTime);
                BigInteger currentSnowballValue = IntPow(snowballDelenie,snowballQuality);
                if (i == 0)
                {
                    maxSnowballValue = currentSnowballValue;
                    maxSnowballSnow = snowballSnow;
                    maxSnowballTime = snowballTime;
                    maxSnowballQuality = snowballQuality;
                }
                else
                {
                    if (currentSnowballValue > maxSnowballValue)
                    {
                        maxSnowballValue = currentSnowballValue;
                        maxSnowballSnow = snowballSnow;
                        maxSnowballTime = snowballTime;
                        maxSnowballQuality = snowballQuality;
                    }
                }
            }
            Console.WriteLine($"{maxSnowballSnow} : {maxSnowballTime} = {maxSnowballValue} ({maxSnowballQuality})");
        }
    }
}
