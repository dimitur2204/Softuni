using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;
        public Rectangle(double height, double width)
        {
            this.height = height;
            this.width = width;
        }

        public double Height => this.height;
        public double Width => this.width;

        public override double CalculateArea()
        {
            return Height * Width;
        }

        public override double CalculatePerimeter()
        {

            return 2 * Height + 2 * Width;
        }
        public override string Draw()
        {
            return "Drawing a rectangle...";
        }
    }
}
