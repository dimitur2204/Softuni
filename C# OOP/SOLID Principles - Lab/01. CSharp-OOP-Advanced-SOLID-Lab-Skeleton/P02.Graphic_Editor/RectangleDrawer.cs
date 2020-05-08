
using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    class RectangleDrawer : GraphicEditor
    {
        public override void DrawShape(IShape shape)
        {
            var rectangle = shape as Rectangle;
            Console.WriteLine("Drawing Rectangle");
        }
    }
}
