using System;
using System.Collections.Generic;

namespace _05._SoftUni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var userLicensePlate = new Dictionary<string, string>();
            for (int i = 0; i < n; i++)
            {
                string[] userInfo = Console.ReadLine()
                    .Split();
                string username = userInfo[1];
                if (userInfo[0] == "register")
                {
                    string licensePlate = userInfo[2];
                    if (userLicensePlate.ContainsKey(username))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {licensePlate}");
                        continue;
                    }
                    else
                    {
                        userLicensePlate.Add(username, licensePlate);
                        Console.WriteLine($"{username} registered {licensePlate} successfully");
                    }
                }
                else
                {
                    if (userLicensePlate.ContainsKey(username))
                    {
                        userLicensePlate.Remove(username);
                        Console.WriteLine($"{username} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {username} not found");
                        continue;
                    }
                }              
            }

            foreach (var item in userLicensePlate)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
