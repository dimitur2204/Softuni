using System;
using System.Collections.Generic;
using System.Text;

namespace PointInRectangle
{
    public class Rectangle
    {
        public Rectangle(Point topLeft, Point bottomRight)
        {
            this.topLeft = topLeft;
            this.bottomRight = bottomRight;
        }
        private Point topLeft { get; set; }
        private Point bottomRight { get; set; }
        public bool ContainsPoint(Point point) 
        {
            if ((point.X >= topLeft.X && point.X <= bottomRight.X) && (point.Y >= topLeft.Y && point.Y <= bottomRight.Y))
            {
                    return true;
            }
            return false;
        }
    }
}
