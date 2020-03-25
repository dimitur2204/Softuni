using System;

namespace PointInRectangle
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] rectangleInfo = Console.ReadLine().Split();
            Point topLeft = new Point(int.Parse(rectangleInfo[0]),int.Parse(rectangleInfo[1]));
            Point bottomRight = new Point(int.Parse(rectangleInfo[2]), int.Parse(rectangleInfo[3]));
            Rectangle rectangle = new Rectangle(topLeft, bottomRight);
            int numberOfInputs = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfInputs; i++)
            {
                string[] pointInfo = Console.ReadLine().Split();
                int pointX = int.Parse(pointInfo[0]);
                int pointY = int.Parse(pointInfo[1]);
                Point point = new Point(pointX, pointY);
                if (rectangle.ContainsPoint(point))
                {
                    Console.WriteLine("True");
                }
                else
                {
                    Console.WriteLine("False");
                }
            }
        }
    }
}
