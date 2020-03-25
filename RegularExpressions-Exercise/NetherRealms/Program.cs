using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NetherRealms
{
    class Program
    {
        static void Main(string[] args)
        {
            var demons = new List<Demon>();
            var names = Console.ReadLine()
                .Split(new char[] { ',', ' '}, StringSplitOptions.RemoveEmptyEntries);
            names = names.Select(x => x.Trim()).ToArray();
            foreach (var name in names)
            {               
                var demonHealth = CalculateHealth(name);
                var demonDamage = CalculateDamage(name);
                var demon = new Demon(name,demonHealth,demonDamage);
                demons.Add(demon);
            }
            demons = demons.OrderBy(x => x.Name).ToList();
            foreach (var demon in demons)
            {
                Console.WriteLine($"{demon.Name} - {demon.Health} health, {demon.Damage:f2} damage"); 
            }
        }
        public static int CalculateHealth(string name)
        {
            var health = 0;
            var regex = @"[^\d+\-*/.]";
            var symbols = Regex.Matches(name, regex);
            foreach (var symbol in symbols)
            {
                health += (int)symbol
                    .ToString()
                    .ToCharArray()[0];
            }
            return health;
        }
        public static decimal CalculateDamage(string name)         
        {
            var regex = @"([-+]?(\d+\.)?\d+)";
            var numbers = Regex.Matches(name, regex);
            var damage = 0.0m;
            foreach (var number in numbers)
            {
                damage += decimal.Parse(number.ToString());
            }
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] == '*')
                {
                    damage *= 2m;
                }
                else if (name[i] == '/')
                {
                    damage /= 2m;
                }
            }
            return damage;
        }
    }
    class Demon
    {
        public Demon(string name, int health, decimal damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        public string Name { get; }
        public int Health { get; }
        public decimal Damage { get; }
    }
}
