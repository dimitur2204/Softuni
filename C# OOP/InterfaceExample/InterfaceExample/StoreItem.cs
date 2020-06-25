
namespace InterfaceExample
{
   public abstract class StoreItem
    {
        public StoreItem(double calories)
        {
            this.Calories = calories;
        }
        public abstract double Price { get;}

        public double Calories { get; set; }

    }
}
