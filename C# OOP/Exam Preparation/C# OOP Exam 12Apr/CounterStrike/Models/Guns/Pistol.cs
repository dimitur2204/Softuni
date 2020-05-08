﻿
namespace CounterStrike.Models.Guns
{
    using CounterStrike.Models.Guns.Contracts;
    public class Pistol : Gun, IGun
    {
        private const int bulletsPerFire = 1;
        public Pistol(string name, int bulletsCount)
            :base(name,bulletsCount)
        {
            
        }
        public override int Fire()
        {
            if (this.BulletsCount == 0)
            {
                return 0;
            }
            this.BulletsCount -= bulletsPerFire;
            return bulletsPerFire;
        }
    }
}
