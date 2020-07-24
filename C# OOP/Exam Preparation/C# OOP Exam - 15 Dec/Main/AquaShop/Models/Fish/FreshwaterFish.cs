
namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish
    {
        public FreshwaterFish(decimal price, string species, string name) 
            : base(price, species, name)
        {
            this.Size = 3;
        }

        public override void Eat()
        {
            this.Size += 3;
        }
    }
}
