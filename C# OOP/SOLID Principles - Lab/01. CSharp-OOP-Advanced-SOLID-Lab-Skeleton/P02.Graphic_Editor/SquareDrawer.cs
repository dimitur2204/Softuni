using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    class SquareDrawer : GraphicEditor
    {
        public override void DrawShape(IShape shape)
        {
            var square = shape as Square;
            Console.WriteLine("Drawing square");
        }
    }
}
