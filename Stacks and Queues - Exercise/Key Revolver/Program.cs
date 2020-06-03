using System;
using System.Collections.Generic;
using System.Linq;

namespace Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            var pricePerBullet = int.Parse(Console.ReadLine());
            var sizeOfBarrel = int.Parse(Console.ReadLine());
            var bullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            var locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            var valueOfTreasure = int.Parse(Console.ReadLine());
            var bulletsCost = 0;
            var sizeOfBarrelCopy = sizeOfBarrel;
            while (true)
            {
                if (locks.Count == 0)
                {
                    if (sizeOfBarrelCopy == 0 && bullets.Count() >= sizeOfBarrel)
                    {
                        Console.WriteLine("Reloading!");
                        sizeOfBarrelCopy = sizeOfBarrel;
                    }
                    else if (sizeOfBarrelCopy == 0 && bullets.Any())
                    {
                        Console.WriteLine("Reloading!");
                        sizeOfBarrelCopy = bullets.Count();
                    }
                    Console.WriteLine($"{bullets.Count()} bullets left. Earned ${valueOfTreasure - bulletsCost}");
                    break;
                }
                if (bullets.Count == 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count()}");
                    break;
                }
                if (sizeOfBarrelCopy == 0 && bullets.Count() >= sizeOfBarrel)
                {
                    Console.WriteLine("Reloading!");
                    sizeOfBarrelCopy = sizeOfBarrel;
                }
                else if (sizeOfBarrelCopy == 0 && bullets.Any())
                {
                    Console.WriteLine("Reloading!");
                    sizeOfBarrelCopy = bullets.Count();
                }
                var bullet = bullets.Pop();
                sizeOfBarrelCopy--;
                bulletsCost += pricePerBullet;
                var Lock = locks.Peek();
                if (bullet <= Lock)
                {
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
            }
        }
    }
}
