using System;
using System.Collections.Generic;

namespace _02._A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = Console.ReadLine(); ;
            Dictionary<string, int> quantities = new Dictionary<string, int>();
            while (key != "stop")
            {
                int value = int.Parse(Console.ReadLine());
                if (!quantities.ContainsKey(key))
                {
                    quantities.Add(key, value);
                }
                else
                {
                    quantities[key] += value;
                }
                key = Console.ReadLine();
            }
            foreach (var item in quantities)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
