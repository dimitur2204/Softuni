using System;
using System.Collections.Generic;
using System.Text;

namespace BoxFormulas
{
    class Box
    {
        private double length;
        private double width;
        private double height;
        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }
        public double Length
        {
            get => this.length;
            private set 
            {
                if (!ValidateSide(value))
                {
                    throw new ArgumentException($"{nameof(this.Length)} cannot be zero or negative.");
                }
                else
                {
                    this.length = value;
                }
            }
        }
        public double Width
        {
            get => this.width;
            private set
            {
                if (!ValidateSide(value))
                {
                    throw new ArgumentException($"{nameof(this.Width)} cannot be zero or negative.");                   
                }
                else
                {
                    this.width = value;
                }
            }
        }
        public double Height
        {
            get => this.height;
            private set
            {
                if (!ValidateSide(value))
                {
                    throw new ArgumentException($"{nameof(this.Height)} cannot be zero or negative.");                    
                }
                else
                {
                    this.height = value;
                }
            }
        }
        public double GetSurfaceArea() 
        {
            double surfaceArea = 2 * length * width + 2 * length * height + 2 * width * height;
            return surfaceArea;
        }
        public double GetLateralSurfaceArea() 
        {
            double lateralSurfaceArea = 2 * length * height + 2 * width * height;
            return lateralSurfaceArea;
        }
        public double GetVolume() 
        {
            double volume = length * width * height;
            return volume;
        }
        public bool ValidateSide(double side) 
        {
            if (side <= 0)
            {
                return false;
            }
            return true;
        }
    }
}
