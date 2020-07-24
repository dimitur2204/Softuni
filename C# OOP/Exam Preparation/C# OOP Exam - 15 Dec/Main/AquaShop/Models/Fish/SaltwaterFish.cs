
namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Fish
    {
        public SaltwaterFish(decimal price, string species, string name)
            : base(price, species, name)
        {
            this.Size = 5;
        }

        public override void Eat()
        {
            this.Size += 2;
        }
    }
}
