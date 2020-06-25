
namespace InterfaceExample
{
    public class Fruit : StoreItem, IItem
    {
        private string name;
        private double price;
        public Fruit(string name, double price,double calories) : base(calories)
        {
            this.name = name;
            this.price = price;
        }
        public override double Price => this.price;
        public string Name => this.name;
    }
}
