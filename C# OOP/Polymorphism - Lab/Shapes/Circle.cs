using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius { get; }

        public override double CalculateArea()
        {
            return Math.Pow(this.Radius,2) * Math.PI;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * this.Radius;
        }
        public override string Draw()
        {
            return "Drawing circle...";
        }
    }
}
