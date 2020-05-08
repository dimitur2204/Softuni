
namespace CounterStrike.Models.Guns
{
    using CounterStrike.Models.Guns.Contracts;
    public class Rifle : Gun, IGun
    {
        private const int bulletsPerFire = 10;
        public Rifle(string name, int bulletsCount)
            : base(name, bulletsCount)
        {

        }
        public override int Fire()
        {
            this.BulletsCount -= bulletsPerFire;
            return bulletsPerFire;
        }
    }
}
