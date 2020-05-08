using System;
using System.Collections.Generic;
using System.Text;

namespace P02.Graphic_Editor
{
    class CircleDrawer : GraphicEditor
    {
        public override void DrawShape(IShape shape)
        {
            var circle = shape as Circle;
            Console.WriteLine("Drawing Circle");
        }
    }
}
