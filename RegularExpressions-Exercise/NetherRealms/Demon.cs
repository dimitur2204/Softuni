using System;
using System.Collections.Generic;
using System.Text;

namespace NetherRealms
{
    class Demon
    {
        public Demon(string name,int health,decimal damage)
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
