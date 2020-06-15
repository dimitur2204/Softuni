
using System.Drawing;

namespace CarSalesman
{
    public class Car
    {
        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = -1;
            this.Color = "n/a";
        }

        public string Model { get; }
        public Engine Engine { get; }
        public int Weight { get; set; }
        public string Color { get; set; }
        public override string ToString()
        {
            if (this.Weight == -1)
            {
                return $"{this.Model}:\n  {Engine}\n  Weight: {"n/a"}\n  Color: {this.Color}";
            }
            return $"{this.Model}:\n  {Engine}\n  Weight: {this.Weight}\n  Color: {this.Color}";
        }
    }
}
