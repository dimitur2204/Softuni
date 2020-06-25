
namespace InterfaceExample
{
    public class Vegetable : StoreItem, IItem
    {
        private string name;
        private double price;
        public Vegetable(double price,string name, double calories):base(calories)
        {
            this.name = name;
            this.price = price;
        }
        public override double Price => this.price;

        public string Name => name;
    }
}
